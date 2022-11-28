using CS4125Project.Controllers;
using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;
using CS4125Project.Controllers.PayrollControllers;
using CS4125Project.Controllers.RotaControllers;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Models.RotaModels;
using CS4125Project.Observer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CS4125UnitTest
{
    [TestClass]
    public class RotaTests
    {
        [TestMethod]
        public void TestRota()
        {
            LoggerFactory factory = new LoggerFactory();
            ILogger<RotaController> logger = new Logger<RotaController>(factory);
            RotaModel rmodel = new RotaModel();
            ShiftModel shift = new ShiftModel();
            shift.id = 1;
            rmodel.shifts = new List<ShiftModel> { shift };
            RotaController rota = new RotaController(logger, rmodel);

            var res = rota.Index();
            Assert.IsInstanceOfType(res, typeof(ViewResult));
            res = rota.Privacy();
            Assert.IsInstanceOfType(res, typeof(ViewResult));

            ILogger<HomeController> plogger = new Logger<HomeController>(factory);
            PayrollController rotaObserver = new PayrollController(plogger);
            List<EmployeeModel> emps = rotaObserver.GetEmployeesFromSerializable();
            rota.Attach(rotaObserver);
            rota.AssignShift(emps.First(), shift.id);
            rota.Notify();
            Assert.IsNotNull(emps.First().notification);
        }
    }
}