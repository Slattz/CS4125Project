using CS4125Project.Controllers;
using CS4125Project.Controllers.DatabaseControllers;
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
    public class EmployeeTests
    {
        private EmployeeModel? employee;
        private EmployeeControllerBase? worker;
        private ManagerController? manager;

        [TestInitialize]
        public void Initialize()
        {
            employee = new EmployeeModel();
        }

        [TestMethod]
        public void TestWorker()
        {
            employee!.level = AuthLevel.Worker;
            employee.SetID(1);
            employee.SetName("Bestie Baddy");
            employee.SetEmail("valid@mail.com");
            Assert.AreEqual(1, employee.GetID());
            Assert.AreEqual("Bestie Baddy", employee.GetName());
            Assert.AreEqual("valid@mail.com", employee.GetEmail());
        }

        [TestMethod]
        public void TestShiftSwap()
        {
            SetupScenario();
            int curId = worker!.getNextRequestId();
            worker.requestShiftSwap(1, 2);
            Assert.AreEqual(curId + 1, worker.getNextRequestId());
            curId = worker.getNextRequestId();
            manager!.ApproveShiftSwap(curId - 1, true);
            worker.agreeShiftSwap(curId - 1);
            Assert.AreEqual(curId, worker.getNextRequestId());
        }

        [TestMethod]
        public void TestHoliday()
        {
            SetupScenario();
            int curId = worker!.getNextRequestId();
            worker.requestHoliday(DateTime.Now, DateTime.MaxValue);
            Assert.AreEqual(curId + 1, worker.getNextRequestId());
            //curId = worker.getNextRequestId();
            //manager!.ApproveRequest();
        }

        [TestMethod]
        public void TestSick()
        {
            SetupScenario();
            int curId = worker!.getNextRequestId();
            worker.callInSick(1);
            Assert.AreEqual(curId + 1, worker.getNextRequestId());
            curId = worker.getNextRequestId();
            manager!.ApproveSickLeave(curId - 1, false); //Employees aren't allowed to be sick
            Assert.AreEqual(curId, worker.getNextRequestId());
        }

        [TestMethod]
        public void TestShortNotice()
        {
            //SetupScenario();
            //int curId = manager!.getNextRequestId();
        }

        private void SetupScenario()
        {
            TestWorker();
            worker = EmployeeFactory.GetEmployeeController(employee!);
            employee!.level = AuthLevel.Manager;
            manager = (ManagerController)EmployeeFactory.GetEmployeeController(employee);
        }
    }
}