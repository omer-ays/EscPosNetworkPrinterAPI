using System;
using ESCPOS_NET;
using ESCPOS_NET.Emitters;
using static System.Net.Mime.MediaTypeNames;

namespace PrinterTestAPI.Services
{
    public class PrinterService : IDisposable
    {
        public string connectionType { get; set; }
        private ICommandEmitter emitter;
        public PrinterService()
        {
            emitter = new EPSON();
        }
        public byte[][] ConvertBase64ToByteArray(string Base64String)
        {
            StringReader sr = new StringReader(Base64String);
            List<byte[]> bytes = new List<byte[]>();
            while (sr?.Peek() >= 0)
            {
                string line = sr?.ReadLine();
                try
                {
                    bytes.Add(Convert.FromBase64String(line));
                }
                catch (Exception)
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
        public void Dispose()
        {
            this.Dispose();
        }

        public bool PrintReceipt(string base64Text, string ipandPort)
        {
            bool response = SendBinary(base64Text, ipandPort);
            return response;
        }
    }
}

