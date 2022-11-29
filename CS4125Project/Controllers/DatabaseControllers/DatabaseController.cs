using CS4125Project.Models.EmployeeModels;
using CS4125Project.Models;
using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using CS4125Project.Controllers.EmployeeControllers;

namespace CS4125Project.Controllers.DatabaseControllers
{
    public class DatabaseController : Controller
    {
        public static List<EmployeeModel> GetEmployeesFromSerializable()
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

        public static void SerializeEmployees(List<EmployeeControllerBase> employees)
        {
            var empModels = EmployeeToModel(employees);
            using (var reader = new StreamWriter("CSV\\Employees.txt"))
            using (var csv = new CsvWriter(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<EmployeeMapperModel>();
                csv.WriteRecords(empModels);

            }
        }

        public static List<EmployeeModel> EmployeeToModel(List<EmployeeControllerBase> employees)
        {
            List<EmployeeModel> empModels = new List<EmployeeModel>();
            foreach (EmployeeControllerBase employee in employees)
            {
                empModels.Add(employee.employeeModel);
            }
            return empModels;
        }

        public static List<EmployeeControllerBase> ModelToEmployee(List<EmployeeModel> employees)
        {
            List<EmployeeControllerBase> emps = new List<EmployeeControllerBase>();
            foreach (EmployeeModel employee in employees)
            {
                emps.Add(new EmployeeControllerBase(employee));
            }
            return emps;
        }
    }
}
