using System;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PrinterTestAPI.Model;
using PrinterTestAPI.Services;

namespace PrinterTestAPI.Controllers
{
    [EnableCors("CorsPolicy")]
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
            var response = _printerService.PrintReceipt(model.Printcommand, 
                model.Adress + ":" + model.Port);
            if (response)
            {
                return Ok("Veri Yazıcıya Gönderildi");
            }
            else
            {
                return Ok("Yazdırma işlemi başarısız oldu.");
            }
        }
    }
}