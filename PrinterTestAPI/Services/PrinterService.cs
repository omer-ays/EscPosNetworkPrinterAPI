using System;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;

namespace PrinterTestAPI.Services
{
    public class PrinterService : IDisposable
    {
        string ip = "";
        string port = "";
        string uuid = "";
        public string connectionType { get; set; }
        private ICommandEmitter emitter;
        public PrinterService()
        {
            emitter = new EPSON();
            //ip = Settings.PrinterIp;
            //port = Settings.PrinterPort;
            //uuid = Settings.BluetoothUUid;
            //connectionType = Settings.ThermalPrinterConnectionType;
        }
        public byte[][] ConvertBase64ToByteArray(string Base64String)
        {
            StringReader sr = new StringReader(Base64String);
            List<byte[]> bytes = new List<byte[]>();
            while (sr.Peek() >= 0)
            {
                string line = sr.ReadLine();
                try
                {
                    bytes.Add(Convert.FromBase64String(line));
                }
                catch (Exception ex)
                {
                }
            }
            return bytes.ToArray();
        }
        ImmediateNetworkPrinter printer;
        public Byte[][] byteArray { get; set; }

        public bool SendBinary(string base64CommandString, string ipAndPort = "192.168.1.114:9100")
        {
            try
            {
                byteArray = ConvertBase64ToByteArray(base64CommandString);

                printer = new ImmediateNetworkPrinter(new ImmediateNetworkPrinterSettings() { ConnectionString = ipAndPort });
                printer.WriteAsync(byteArray);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
            

        }
        private void NetworkPrinter_StatusChanged(object sender, System.EventArgs e)
        {
            var status = (PrinterStatusEventArgs)e;
        }
        public bool PrintReceipt(string text, string ipAndPort)
        {
            bool response = SendBinary(text,ipAndPort);
            return response;
        }

        public void Dispose()
        {
            this.Dispose();
        }
    }
}

