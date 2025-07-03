# Syslog Simulator

**Syslog Simulator** is a lightweight Windows Forms application written in C# for sending custom or simulated syslog messages over **UDP** or **TCP**.

It’s useful for:
- Testing SIEM tools  
- Simulating network device logs (e.g. FortiGate)  
- Load or log forwarding simulations  

---

## ✨ Features

- ✅ Send logs manually or on a schedule  
- ✅ Support for **UDP** and **TCP**  
- ✅ Random log line selection for manual sends  
- ✅ Line-by-line scheduling with custom interval  
- ✅ Built-in FortiGate log generator with real-time timestamp and random values  
- ✅ Remembers last-used input values  
- ✅ No installation needed – just run the EXE  

---

## 📷 Screenshot

![image](https://github.com/user-attachments/assets/a9b45156-ce9c-4f6c-8b07-2676e1c889d5)

---

## 🚀 Getting Started

### 1. Clone or Download

```bash
git clone https://github.com/yourusername/SimpleLogForwarder.git
cd SimpleLogForwarder
```

Or download the latest `.exe` from the [Releases](https://github.com/xyperia/syslog-simulator/releases) page.

### 2. Open in Visual Studio

- Open `SimpleLogForwarder.sln`
- Press **F5** to build and run

### 3. Build Executable

To generate a distributable `.exe`:
- Open *Build > Build Solution*
- Find the output in `bin\Release` or `bin\Debug`

---

## 🛠 How to Use

1. Enter the **IP** and **Port** of the syslog server  
2. Choose **Protocol**: *UDP* or *TCP*  
3. Choose **Log Type**:
   - *Custom*: Each line in the message box is a log
   - *Fortigate*: Sends randomized, real-time FortiGate-style logs
4. Click **Send Once** to send one message  
5. Click **Send Always** to send continuously at set interval  
6. Click **Stop** to cancel continuous sending  

---

## 📄 Sample FortiGate Log

*Example generated log:*

```text
date=2025-06-04 time=14:52:11 logid="1234567890" type="traffic" subtype="multicast" level="notice" vd="vdom1" eventtime=1622812345 srcip=10.0.0.1 dstip=10.0.0.2 srcport=1234 dstport=5678 ...
```

---

## 🧰 Tech Stack

- C# / .NET Framework  
- Windows Forms (WinForms)  
- Visual Studio  

---

## 💡 Ideas for Future

- TLS/SSL support  
- Export/Import log templates  
- Built-in log preview  
- Add RFC 5424 formatting option  

---

## 👨‍💻 Author

**XYPERIA**  
GitHub: [@xyperia](https://github.com/xyperia)  

---

## 📄 License

This project is licensed under the **MIT License**. Feel free to use, modify, and share it.
