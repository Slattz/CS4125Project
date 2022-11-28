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
                    s.employeeID = emp.GetID();
                    Notify();
                    return true;
                }
            }
            return false;
        }

        public void AddEmployee(string role, AuthLevel level, float basePay, string name, string email)
        {
            EmployeeModel emp = new EmployeeModel();
            emp.role = role;
            emp.sickDays = (float)4;
            emp.holidays = (float)20;
            emp.level = level;
            emp.notification = null;
            emp.basePay = basePay;
            emp.SetName(name);
            emp.SetEmail(email);
            emp.SetID(rota.employees.Count);
            Notify();
        }

        /*[HttpPost]
        public DateTime AddShift(string role, Day workday, DateTime startTime, DateTime endTime)
        {
            
        }*/

        [HttpPost]
        public void RemoveShift(int shiftID)
        {
            foreach (ShiftModel s in rota.shifts)
            {
                if (shiftID == s.id)
                {
                    rota.shifts.Remove(s);
                }
            }
            Notify();
        }

        public void AddShift(ShiftModel shift)
        {
            rota.shifts.Add(shift);
            Notify();
        }

        [HttpPost]
        public void UnassignShift(int shiftID)
        {
            foreach (ShiftModel s in rota.shifts)
            {
                if (shiftID == s.id)
                {
                    s.employeeID = -1;
                }
            }
            Notify();
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

            Notify();
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
            Notify();
        }
    }
}
