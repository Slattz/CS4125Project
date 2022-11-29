using CS4125Project.Controllers;
using CS4125Project.Controllers.DatabaseControllers;
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
        private ShiftModel? shift;


        [TestInitialize]
        public void Initialize()
        {
            LoggerFactory factory = new LoggerFactory();
            ILogger<RotaController> logger = new Logger<RotaController>(factory);
            RotaModel rmodel = new RotaModel();
            shift = new ShiftModel();
            shift.id = 1;
            rmodel.shifts = new List<ShiftModel> { shift };

            ILogger<HomeController> plogger = new Logger<HomeController>(factory);
            rmodel.employees = DatabaseController.GetEmployeesFromSerializable();
            rota = new RotaController(logger, rmodel);
            emps = rota.GetEmployees();
            PayrollController rotaObserver = new PayrollController(plogger, DatabaseController.ModelToEmployee(emps));
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
            //Thread.Sleep(1000);
            //Assert.AreNotEqual(notification, rota!.GetEmployees().First().notification);

            rota!.RemoveShift(1);
            Assert.IsFalse(rota!.GetShifts().Contains(shift));
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