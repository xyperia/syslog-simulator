namespace SimpleLogForwarder
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.sendOnce = new System.Windows.Forms.Button();
            this.txtIP = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.cmbProtocol = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtMessage = new System.Windows.Forms.RichTextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.numInterval = new System.Windows.Forms.NumericUpDown();
            this.btnSendAlways = new System.Windows.Forms.Button();
            this.SchedulerTimer = new System.Windows.Forms.Timer(this.components);
            this.label6 = new System.Windows.Forms.Label();
            this.cmbLogType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.eventMsg = new System.Windows.Forms.RichTextBox();
            this.label7 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // sendOnce
            // 
            this.sendOnce.Location = new System.Drawing.Point(315, 379);
            this.sendOnce.Name = "sendOnce";
            this.sendOnce.Size = new System.Drawing.Size(138, 36);
            this.sendOnce.TabIndex = 0;
            this.sendOnce.Text = "Send Once";
            this.sendOnce.UseVisualStyleBackColor = true;
            this.sendOnce.Click += new System.EventHandler(this.sendOnce_Click);
            // 
            // txtIP
            // 
            this.txtIP.Location = new System.Drawing.Point(156, 33);
            this.txtIP.Name = "txtIP";
            this.txtIP.Size = new System.Drawing.Size(168, 26);
            this.txtIP.TabIndex = 1;
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(382, 33);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(99, 26);
            this.txtPort.TabIndex = 2;
            // 
            // cmbProtocol
            // 
            this.cmbProtocol.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProtocol.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbProtocol.FormattingEnabled = true;
            this.cmbProtocol.Location = new System.Drawing.Point(568, 31);
            this.cmbProtocol.Name = "cmbProtocol";
            this.cmbProtocol.Size = new System.Drawing.Size(121, 28);
            this.cmbProtocol.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(117, 20);
            this.label1.TabIndex = 4;
            this.label1.Text = "Destination IP :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(334, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 20);
            this.label2.TabIndex = 5;
            this.label2.Text = "Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(487, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 6;
            this.label3.Text = "Protocol :";
            // 
            // txtMessage
            // 
            this.txtMessage.Location = new System.Drawing.Point(37, 133);
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(652, 231);
            this.txtMessage.TabIndex = 7;
            this.txtMessage.Text = "Put your log here. Each line will be treated as a different log. If you add more " +
    "than one line, then it will be randomize or send in order. Select \"Custom\" as th" +
    "e Log Type to modify this.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 99);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(82, 20);
            this.label4.TabIndex = 8;
            this.label4.Text = "Message :";
            // 
            // numInterval
            // 
            this.numInterval.Location = new System.Drawing.Point(603, 382);
            this.numInterval.Maximum = new decimal(new int[] {
            3600,
            0,
            0,
            0});
            this.numInterval.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numInterval.Name = "numInterval";
            this.numInterval.Size = new System.Drawing.Size(48, 26);
            this.numInterval.TabIndex = 10;
            this.numInterval.Value = new decimal(new int[] {
            5,
            0,
            0,
            0});
            // 
            // btnSendAlways
            // 
            this.btnSendAlways.Location = new System.Drawing.Point(459, 379);
            this.btnSendAlways.Name = "btnSendAlways";
            this.btnSendAlways.Size = new System.Drawing.Size(138, 36);
            this.btnSendAlways.TabIndex = 11;
            this.btnSendAlways.Text = "Send every";
            this.btnSendAlways.UseVisualStyleBackColor = true;
            this.btnSendAlways.Click += new System.EventHandler(this.btnSendAlways_Click);
            // 
            // SchedulerTimer
            // 
            this.SchedulerTimer.Tick += new System.EventHandler(this.SchedulerTimer_Tick);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label6.Location = new System.Drawing.Point(657, 384);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 20);
            this.label6.TabIndex = 12;
            this.label6.Text = "sec";
            // 
            // cmbLogType
            // 
            this.cmbLogType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbLogType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cmbLogType.FormattingEnabled = true;
            this.cmbLogType.Location = new System.Drawing.Point(491, 78);
            this.cmbLogType.Name = "cmbLogType";
            this.cmbLogType.Size = new System.Drawing.Size(198, 28);
            this.cmbLogType.TabIndex = 14;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(402, 81);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 20);
            this.label5.TabIndex = 15;
            this.label5.Text = "Log Type :";
            // 
            // eventMsg
            // 
            this.eventMsg.Enabled = false;
            this.eventMsg.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.eventMsg.Location = new System.Drawing.Point(37, 436);
            this.eventMsg.Name = "eventMsg";
            this.eventMsg.Size = new System.Drawing.Size(652, 80);
            this.eventMsg.TabIndex = 16;
            this.eventMsg.Text = "Brought to you by XYPERIA";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(37, 410);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 20);
            this.label7.TabIndex = 17;
            this.label7.Text = "Log :";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(725, 563);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.eventMsg);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbLogType);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnSendAlways);
            this.Controls.Add(this.numInterval);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbProtocol);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.txtIP);
            this.Controls.Add(this.sendOnce);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "Syslog Simulator v1.1";
            ((System.ComponentModel.ISupportInitialize)(this.numInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sendOnce;
        private System.Windows.Forms.TextBox txtIP;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.ComboBox cmbProtocol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RichTextBox txtMessage;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numInterval;
        private System.Windows.Forms.Button btnSendAlways;
        private System.Windows.Forms.Timer SchedulerTimer;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cmbLogType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RichTextBox eventMsg;
        private System.Windows.Forms.Label label7;
    }
}

