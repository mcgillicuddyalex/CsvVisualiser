using CsvVisualiser.Common.Interfaces;
using CsvVisualiser.Common.Models;
using Microsoft.AspNetCore.Mvc;

namespace CsvVisualiser.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SalesController : ControllerBase
    {
        private readonly ICsvExtraction<Sales> _csvExtraction;
        public SalesController(ICsvExtraction<Sales> csvExtraction)
        {
            _csvExtraction = csvExtraction;
        }

        [HttpPost]
        public IEnumerable<Sales> ProcessFile(IFormFile file)
        {
            using (var fileInput = file.OpenReadStream())
            {
                return _csvExtraction.GetData(fileInput).ToList();
            }
        }
    }
}
