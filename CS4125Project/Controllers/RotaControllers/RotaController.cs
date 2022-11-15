using CS4125Project.Models;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Models.RotaModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace CS4125Project.Controllers.RotaControllers
{
    public class RotaController : Controller
    {
        private readonly ILogger<RotaController> _logger;

        public RotaController(ILogger<RotaController> logger)
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

        [HttpPost]
        public bool AssignShift(EmployeeModel emp, int shiftID)
        {

        }

        [HttpPost]
        public DateTime AddShift(string role, Day workday, DateTime startTime, DateTime endTime)
        {

        }

        [HttpPost]
        public void RemoveShift(int shiftID)
        {

        }

        [HttpPost]
        public void UnassignShift(int shiftID)
        {

        }

        [HttpPost]
        public <ShiftModel> GetRota()
        {

        }
    }
}
