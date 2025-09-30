using CsvToJsonDemo.Services;
using Microsoft.AspNetCore.Mvc;

namespace CsvToJsonDemo.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly CsvHelperService _csvService;

        public EmployeesController(CsvHelperService csvService)
        {
            _csvService = csvService;
        }

        [HttpGet("import-csv")]
        public IActionResult ImportCsv()
        {
            var employees = _csvService.ReadEmployeesFromCsv();
            return Ok(employees);
        }

        [HttpPost("import-to-db")]
        public IActionResult ImportCsvToDb()
        {
            _csvService.ImportEmployeesToDb();
            return Ok("Employees imported to database successfully.");
        }
    }
}
