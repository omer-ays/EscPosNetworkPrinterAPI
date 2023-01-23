using System;
namespace PrinterTestAPI.Model
{
	public class PrintModel
	{
        public string ConnectionType { get; set; } = "1";
        public string Port { get; set; } 
        public string Adress { get; set; }
        public string Portname { get; set; } = "COM5";
        public string FilePath { get; set; }
        public string Printcommand { get; set; }
        public int BaudRate { get; set; }
        public int Encoding { get; set; }



    }
}

