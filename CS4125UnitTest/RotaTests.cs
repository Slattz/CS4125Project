using CS4125Project.Controllers;
using CS4125Project.Controllers.Database;
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
        private PayrollController? observer;


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
            EmployeeDatabase.Instance.GetAllEmployees(out rmodel.employees);
            rota = new RotaController(logger, rmodel);
            emps = rota.GetEmployees();

            observer = new PayrollController(plogger, EmployeeDatabase.ModelsToEmployee(emps));
            rota.Attach(observer);
        }

        [TestMethod]
        public void TestRotaViews()
        {
            var res = rota!.Index();
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

        [TestMethod]
        public void TestAddEmployee()
        {
            int count = rota!.GetEmployees().Count();
            rota!.AddEmployee("boss babe", AuthLevel.GeneralManager, (float)42069.05, "Nicki Minaj", "boo@slay.org");
            Assert.IsTrue(count + 1 == rota!.GetEmployees().Count());
        }

        [TestMethod]
        public void TestAddShift()
        {
            var notification = emps!.First().notification;
            rota!.Detach(observer);
            rota.AddShift(new ShiftModel());
            rota!.UpdateCurrentRota();
            Assert.AreEqual(notification, emps!.First().notification);
        }
    }
}