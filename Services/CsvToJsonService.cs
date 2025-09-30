using CsvToJsonDemo.Data;
using CsvToJsonDemo.Models;

namespace CsvToJsonDemo.Services
{
    public class CsvHelperService
    {
        private readonly string _filePath;
        private readonly AppDbContext _context;

        public CsvHelperService(IWebHostEnvironment env, AppDbContext context)
        {
            _filePath = Path.Combine(env.WebRootPath, "data", "employees.csv");
            _context = context;
        }

        public IEnumerable<Employee> ReadEmployeesFromCsv()
        {
            var employees = new List<Employee>();

            if (!File.Exists(_filePath))
                return employees;

            var lines = File.ReadAllLines(_filePath);

            foreach (var line in lines.Skip(1)) // Skip header
            {
                var parts = line.Split(',');
                if (parts.Length >= 3)
                {
                    employees.Add(new Employee
                    {
                        Id = int.TryParse(parts[0], out var id) ? id : 0,
                        Name = parts[1],
                        Department = parts[2]
                    });
                }
            }

            return employees;
        }

        public void ImportEmployeesToDb()
        {
            var employees = ReadEmployeesFromCsv();

            if (employees.Any())
            {
                _context.Employees.AddRange(employees);
                _context.SaveChanges();
            }
        }
    }
}
