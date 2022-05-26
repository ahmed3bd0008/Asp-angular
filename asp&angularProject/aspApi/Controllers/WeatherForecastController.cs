using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace TestApplication.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;

        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }
        [HttpGet("GetFile")]
        public  IActionResult GetFile(){
            MemoryStream stream = new MemoryStream();
            using(ExcelPackage excelPackage=new ExcelPackage(stream))
            {
                var workShop = excelPackage.Workbook.Worksheets.Add("User");
                var workStyle = excelPackage.Workbook.Styles.CreateNamedStyle("CUSTOMSTYLE");
                workStyle.Style.Font.UnderLine = true;
                excelPackage.Workbook.Worksheets[0].BackgroundColor(color: System.Drawing.Color.Blue);
                workShop.Cells["A1"].Value = "Ahmed";
                using(var r= workShop.Cells["A1:C1"])
                {
                    r.Merge = true;
                    r.Style.Font.Color.SetColor(color: System.Drawing.Color.Blue);
                    r.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                    r.Style.Fill.BackgroundColor.SetColor(color: Color.Red);

                }
                excelPackage.Save();

            }
                stream.Position = 0;
            return File(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "User.xlsx");
        }
    }
}
