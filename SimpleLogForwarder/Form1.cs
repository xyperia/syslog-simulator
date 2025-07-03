using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace SimpleLogForwarder
{
    public partial class Form1 : Form
    {
        private List<string> messageLines = new List<string>();
        private int currentLineIndex = 0;
        private Timer schedulerTimer;

        string[] ipCat1 = { "10.100.33.97", "10.100.33.137", "10.100.33.181", "10.100.33.208", "10.100.33.189" };
        string[] ipCat2 = { "10.100.34.134", "10.100.34.192", "10.100.34.111", "10.100.34.135", "10.100.34.130" };
        string[] ipCat3 = { "10.99.34.28", "10.99.34.137", "10.98.37.211", "10.99.34.138", "10.99.37.127" };
        string[] ports = { "12020", "10999", "8088", "9090", "8000" };

        

        Dictionary<string, string> logSample = new Dictionary<string, string>()
        {
            { "Fortigate", "date=2019-03-31 time=06:42:54 logid=\"0002000012\" type=\"traffic\" subtype=\"multicast\" level=\"notice\" vd=\"vdom1\" eventtime=1554039772 srcip=172.16.200.55 srcport=60660 srcintf=\"port25\" srcintfrole=\"undefined\" dstip=230.1.1.2 dstport=7878 dstintf=\"port3\" dstintfrole=\"undefined\" sessionid=1162 proto=17 action=\"accept\" policyid=1 policytype=\"multicast-policy\" service=\"udp/7878\" dstcountry=\"Reserved\" srccountry=\"Reserved\" trandisp=\"noop\" duration=22 sentbyte=5940 rcvdbyte=0 sentpkt=11 rcvdpkt=0 appcat=\"unscanned\"" },
            { "Mikrotik", "Feb 20 04:38:02 192.168.202.101 id=firewall sn=C0EAE45CA55 time=\"2021-02-20 12:54:43\" fw=188.126.145.3 pri=6 c=1 m=911 msg=\"Added host entry to dynamic address object\" n=6776584 note=\"FQDN=*.microsoft.com; TTL=56; Host=20.49.150.241\" fw_action=\"NA\"" }
        };

    public Form1()
        {
            InitializeComponent();

            cmbProtocol.Items.Add("UDP");
            cmbProtocol.Items.Add("TCP");
            cmbProtocol.SelectedIndex = 0;

            cmbLogType.Items.Add("Fortigate");
            cmbLogType.Items.Add("Mikrotik");
            cmbLogType.Items.Add("Custom");


            cmbLogType.SelectedIndex = 0;
            cmbLogType.SelectedIndexChanged += cmbLogType_SelectedIndexChanged;

            schedulerTimer = new Timer();
            schedulerTimer.Tick += SchedulerTimer_Tick;

            // Load saved settings
            txtIP.Text = Properties.Settings.Default.LastIP;
            txtPort.Text = Properties.Settings.Default.LastPort;
            cmbProtocol.SelectedItem = Properties.Settings.Default.LastProtocol;
            cmbLogType.SelectedItem = Properties.Settings.Default.LastLogType;
            txtMessage.Text = Properties.Settings.Default.LastMessage;
            numInterval.Value = Properties.Settings.Default.LastInterval;

            this.FormClosing += Form1_FormClosing;

            refreshTxtMessage();
        }

        private void refreshTxtMessage()
        {
            if (cmbLogType.SelectedItem.ToString() == "Custom")
            {
                txtMessage.Text = "";
                txtMessage.Enabled = true;
            }
            else
            {
                txtMessage.Text = logSample[cmbLogType.SelectedItem.ToString()];
                txtMessage.Enabled = false;
            }
        }

        private void cmbLogType_SelectedIndexChanged(object sender, EventArgs e)
        {
            refreshTxtMessage();
            Form1.ActiveForm.Text = $"{cmbLogType.SelectedItem.ToString()} - {Properties.Resources.appTitle}";
        }

        private void sendOnce_Click(object sender, EventArgs e)
        {
            string ip = txtIP.Text.Trim();
            string portText = txtPort.Text.Trim();
            string protocol = cmbProtocol.SelectedItem.ToString();

            if (!IPAddress.TryParse(ip, out IPAddress ipAddress))
            {
                eventMsg.Text = "Invalid IP address.";
                return;
            }

            if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
            {
                eventMsg.Text = "Invalid port number.";
                return;
            }

            string selectedLine;

            if (cmbLogType.SelectedItem.ToString() == "Fortigate")
            {
                selectedLine = GenerateFortigateLog();
            }
            else if (cmbLogType.SelectedItem.ToString() == "Mikrotik")
            {
                selectedLine = GenerateMikrotikLog();
            }
            else
            {
                messageLines = txtMessage.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
                if (messageLines.Count == 0)
                {
                    eventMsg.Text = "Message must contain at least one non-empty line.";
                    return;
                }

                Random rnd = new Random();
                selectedLine = messageLines[rnd.Next(messageLines.Count)];
            }

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(selectedLine);

                if (protocol == "UDP")
                {
                    using (UdpClient udpClient = new UdpClient())
                    {
                        udpClient.Send(data, data.Length, ip, port);
                    }
                }
                else if (protocol == "TCP")
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(ip, port);
                        using (NetworkStream stream = tcpClient.GetStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                    }
                }

                eventMsg.Text = "Log sent successfully!";
            }
            catch (Exception ex)
            {
                eventMsg.Text = $"Failed to send message: {ex.Message}";
            }
        }

        private void btnSendAlways_Click(object sender, EventArgs e)
        {
            if (schedulerTimer.Enabled)
            {
                schedulerTimer.Stop();
                btnSendAlways.Text = "Send Always";
                SetInputState(true);
                eventMsg.Text = "Stopped sending logs.";
                return;
            }

            string ip = txtIP.Text.Trim();
            string portText = txtPort.Text.Trim();
            string protocol = cmbProtocol.SelectedItem.ToString();

            if (!IPAddress.TryParse(ip, out IPAddress ipAddress))
            {
                eventMsg.Text = "Invalid IP address.";
                return;
            }

            if (!int.TryParse(portText, out int port) || port < 1 || port > 65535)
            {
                eventMsg.Text = "Invalid port number.";
                return;
            }

            if (cmbLogType.SelectedItem.ToString() == "Custom")
            {
                messageLines = txtMessage.Lines.Where(line => !string.IsNullOrWhiteSpace(line)).ToList();
                if (messageLines.Count == 0)
                {
                    eventMsg.Text = "Message must contain at least one non-empty line.";
                    return;
                }
            }

            currentLineIndex = 0;
            schedulerTimer.Tag = new SyslogContext { IP = ip, Port = port, Protocol = protocol };
            schedulerTimer.Interval = (int)(numInterval.Value * 1000);
            schedulerTimer.Start();

            btnSendAlways.Text = "Stop";
            SetInputState(false);
            eventMsg.Text = "Started sending logs repeatedly.";
        }

        private void SchedulerTimer_Tick(object sender, EventArgs e)
        {
            if (cmbLogType.SelectedItem.ToString() == "Custom" && messageLines.Count == 0)
            {
                schedulerTimer.Stop();
                btnSendAlways.Text = "Send Always";
                SetInputState(true);
                return;
            }

            var ctx = (SyslogContext)schedulerTimer.Tag;
            string lineToSend;

            if (cmbLogType.SelectedItem.ToString() == "Fortigate")
            {
                lineToSend = GenerateFortigateLog();
            }
            else
            {
                lineToSend = messageLines[currentLineIndex];
                currentLineIndex++;
                if (currentLineIndex >= messageLines.Count)
                    currentLineIndex = 0;
            }

            try
            {
                byte[] data = Encoding.UTF8.GetBytes(lineToSend);

                if (ctx.Protocol == "UDP")
                {
                    using (UdpClient udpClient = new UdpClient())
                    {
                        udpClient.Send(data, data.Length, ctx.IP, ctx.Port);
                    }
                }
                else if (ctx.Protocol == "TCP")
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.Connect(ctx.IP, ctx.Port);
                        using (NetworkStream stream = tcpClient.GetStream())
                        {
                            stream.Write(data, 0, data.Length);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                schedulerTimer.Stop();
                btnSendAlways.Text = "Send Always";
                SetInputState(true);
                eventMsg.Text = $"Failed during scheduled send: {ex.Message}";
            }
        }

        private void SetInputState(bool enabled)
        {
            txtIP.Enabled = enabled;
            txtPort.Enabled = enabled;
            cmbProtocol.Enabled = enabled;
            cmbLogType.Enabled = enabled;
            txtMessage.Enabled = enabled;
            numInterval.Enabled = enabled;
            sendOnce.Enabled = enabled;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Properties.Settings.Default.LastIP = txtIP.Text.Trim();
            Properties.Settings.Default.LastPort = txtPort.Text.Trim();
            Properties.Settings.Default.LastProtocol = cmbProtocol.SelectedItem?.ToString() ?? "UDP";
            Properties.Settings.Default.LastLogType = cmbProtocol.SelectedItem?.ToString() ?? "Custom";
            Properties.Settings.Default.LastMessage = txtMessage.Text;
            Properties.Settings.Default.LastInterval = (int)numInterval.Value;
            Properties.Settings.Default.Save();
        }

        private class SyslogContext
        {
            public string IP { get; set; }
            public int Port { get; set; }
            public string Protocol { get; set; }
        }

        public static string GetRandomNumber(int length)
        {
            long epochNow = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();
            return epochNow.ToString().Substring(epochNow.ToString().Length - length);
        }

        private string GenerateFortigateLog()
        {
            Random rand = new Random();

            string datenow = DateTime.UtcNow.ToString("yyyy-MM-dd");
            string timenow = DateTime.UtcNow.ToString("HH:mm:ss");
            long epochNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string randomSip = ipCat1[rand.Next(ipCat1.Length)];
            string randomDip = ipCat2[rand.Next(ipCat2.Length)];
            string randomPort = ports[rand.Next(ports.Length)];

            return $"date={datenow} time={timenow} logid=\"{GetRandomNumber(10)}\" type=\"traffic\" subtype=\"multicast\" level=\"notice\" vd=\"vdom{GetRandomNumber(1)}\" eventtime={epochNow} srcip={randomSip} srcport={randomPort} srcintf=\"port{GetRandomNumber(2)}\" srcintfrole=\"undefined\" dstip={randomDip} dstport={randomPort} dstintf=\"port{GetRandomNumber(2)}\" dstintfrole=\"undefined\" sessionid={GetRandomNumber(4)} proto={GetRandomNumber(2)} action=\"accept\" policyid=1 policytype=\"multicast-policy\" service=\"udp/{GetRandomNumber(4)}\" dstcountry=\"Reserved\" srccountry=\"Reserved\" trandisp=\"noop\" duration={GetRandomNumber(2)} sentbyte={GetRandomNumber(5)} rcvdbyte=0 sentpkt={GetRandomNumber(2)} rcvdpkt=0 appcat=\"unscanned\" ";
        }

        private string GenerateMikrotikLog()
        {
            Random rand = new Random();

            string datenow = DateTime.UtcNow.ToString("yyyy-MM-dd");
            string shortMonth = DateTime.Now.ToString("MMM");
            string shortDay = DateTime.Now.ToString("DD");
            string timenow = DateTime.UtcNow.ToString("HH:mm:ss");
            long epochNow = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            string randomSip = ipCat1[rand.Next(ipCat1.Length)];
            string randomDip = ipCat2[rand.Next(ipCat2.Length)];
            string randomOip = ipCat3[rand.Next(ipCat3.Length)];
            string randomPort = ports[rand.Next(ports.Length)];

            return $"{shortMonth} {shortDay} {timenow} {randomSip} id=\"firewall\" sn=C0EAE45CA55 time=\"{datenow} {timenow}\" fw={randomOip} pri={GetRandomNumber(1)} c={GetRandomNumber(1)} m=911 msg=\"Added host entry to dynamic address object\" n=6776584 n=6776584 note=\"FQDN=*.microsoft.com; TTL=56; Host={randomOip} fw_action=\"NA\"";
        }
    }
}
