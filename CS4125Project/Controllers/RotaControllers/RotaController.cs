using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;
using CS4125Project.Models;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Models.RotaModels;
using CS4125Project.Observer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace CS4125Project.Controllers.RotaControllers
{
    public class RotaController : Controller, ISubject
    {
        private readonly ILogger<RotaController> _logger;
        private RotaModel rota;
        private List<IObserver> _observers = new List<IObserver>();
        private EmployeeSelector selector = new EmployeeSelector();

        public RotaController(ILogger<RotaController> logger, RotaModel r)
        {
            _logger = logger;
            rota = r;
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
            foreach (ShiftModel s in rota.shifts)
            {
                if (shiftID == s.id)
                {
                    s.employeeID = emp.id;
                    return true;
                }
            }
            return false;
        }

        /*[HttpPost]
        public DateTime AddShift(string role, Day workday, DateTime startTime, DateTime endTime)
        {
            
        }*/

        [HttpPost]
        public void RemoveShift(int shiftID)
        {

        }

        [HttpPost]
        public void UnassignShift(int shiftID)
        {

        }

        [HttpPost]
        /*public <ShiftModel> GetRota()
        {

        }*/

        public void Attach(IObserver observer)
        {
            Console.WriteLine("Subject: Attached an observer.");
            this._observers.Add(observer);
        }

        public void Detach(IObserver observer)
        {
            this._observers.Remove(observer);
            Console.WriteLine("Subject: Detached an observer.");
        }

        public void Notify()
        {
            Console.WriteLine("Subject: Notifying observers...");

            foreach (var observer in _observers)
            {
                observer.Update(this);
            }
        }

        public void UpdateCurrentRota()
        {
            Console.WriteLine("\nSubject: I'm updating the current rota");

            this.Notify();
        }

        public void assignWeeksShifts()
        {
            ShiftCommander commader = new ShiftCommander();
            Dictionary<int, EmployeeModel> shiftEmployeeMap = selector.getEmployeesToCover(rota.shifts, rota.employees);
            foreach(KeyValuePair<int, EmployeeModel> mapping in shiftEmployeeMap)
            {
                AssignShiftCommand assignCommand = new AssignShiftCommand(mapping.Value, mapping.Key, this);
                commader.SetToExecute(assignCommand);
                commader.Execute();
            }
        }
    }
}
