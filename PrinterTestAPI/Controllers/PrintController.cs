using System;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrinterTestAPI.Model;
using PrinterTestAPI.Services;

namespace PrinterTestAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PrintController : ControllerBase
	{
        PrinterService _printerService;
		public PrintController()
		{
            _printerService = new PrinterService();
		}

        [ActionName("Print")]
        [HttpPost]
        public IActionResult PrintReceipt([FromBody] PrintModel model)
        {
            var response = _printerService.PrintReceipt(model.Base64, model.IpAndPort);
            if (response)
            {
                return Ok("İşlem Başarılı");
            }
            else
            {
                return Ok("Yazdırma işlemi başarısız oldu.");
            }
            GC.SuppressFinalize(_printerService);
        }
    }
}