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
        private RotaController? rota;
        private List<EmployeeModel>? emps;


        [TestInitialize]
        public void Initialize()
        {
            LoggerFactory factory = new LoggerFactory();
            ILogger<RotaController> logger = new Logger<RotaController>(factory);
            RotaModel rmodel = new RotaModel();
            ShiftModel shift = new ShiftModel();
            shift.id = 1;
            rmodel.shifts = new List<ShiftModel> { shift };

            ILogger<HomeController> plogger = new Logger<HomeController>(factory);
            PayrollController rotaObserver = new PayrollController(plogger);
            emps = rotaObserver.GetEmployeesFromSerializable();
            rmodel.employees = emps;
            rota = new RotaController(logger, rmodel);
            rota.Attach(rotaObserver);
        }

        [TestMethod]
        public void TestRotaViews()
        {
            var res = rota!.Index();
            Assert.IsInstanceOfType(res, typeof(ViewResult));
            res = rota.Privacy();
            Assert.IsInstanceOfType(res, typeof(ViewResult));
        }

        [TestMethod]
        public void TestRotaShiftManagement()
        {
            rota!.AssignShift(emps!.First(), 1);
            var notification = emps!.First().notification;
            Assert.AreNotEqual(notification, "");

            rota!.UnassignShift(1);
            Assert.AreNotEqual(notification, emps!.First().notification);
            notification = emps!.First().notification;

            rota!.RemoveShift(1);
            Assert.AreNotEqual(notification, emps!.First().notification);
            notification = emps!.First().notification;
        }
        [TestMethod]
        public void TestRotaWeeksShifts()
        {
            rota!.assignWeeksShifts();
            var notification = emps!.First().notification;
            Assert.AreNotEqual(notification, "");
        }
    }
}