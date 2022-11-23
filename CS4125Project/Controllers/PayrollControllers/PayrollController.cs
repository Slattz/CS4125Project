using CS4125Project.Models;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Observer;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;

namespace CS4125Project.Controllers
{
    public class PayrollController : Controller, IObserver
    {
        private readonly ILogger<HomeController> _logger;

        public PayrollController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public void Update(ISubject subject)
        {
            List<EmployeeModel> employees = GetEmployeesFromSerializable();

            //for each employee in payroll, notify them that a new rota is available
            foreach (EmployeeModel employee in employees)
            {
                employee.notification = "New rota available as of: " + DateTime.Now.ToString();
            }
            SerializeEmployees(employees);
        }

        public List<EmployeeModel> GetEmployeesFromSerializable()
        {
            List<EmployeeModel> employeesList = new List<EmployeeModel>();
            using (var reader = new StreamReader("CSV\\Employees.txt"))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<EmployeeMapperModel>();
                var records = csv.GetRecords<EmployeeModel>();
                List<EmployeeModel> employees = records.ToList();
                foreach (EmployeeModel employee in employees)
                {
                    employeesList.Add(employee);
                }

            }
            return employeesList;
        }

        public void SerializeEmployees(List<EmployeeModel> employees)
        {
            using (var reader = new StreamWriter("CSV\\Employees.txt"))
            using (var csv = new CsvWriter(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<EmployeeMapperModel>();
                csv.WriteRecords(employees);

            }
        }
    }
}
