using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;
using CS4125Project.Controllers.PayrollControllers;
using CS4125Project.Models.EmployeeModels;

namespace CS4125UnitTest
{
    [TestClass]
    public class PayrollTests
    {
        private EmployeeModel? employee;
        private IPayCalcVisitor? visitor;

        [TestInitialize]
        public void Initialize()
        {
            visitor = new IrishPayCalcVisitor();
            employee = new EmployeeModel();
        }
        [TestMethod]
        public void TestPayCalcWorker()
        {
            employee!.level = AuthLevel.Worker;
            employee!.SetID(1);
            employee!.basePay = 1000;
            EmployeeControllerBase controller = EmployeeFactory.GetEmployeeController(employee);
            float wage = controller.AcceptCalc(visitor);
            Assert.AreEqual(employee!.basePay - 90, wage);
        }

        [TestMethod]
        public void TestPayCalcManager()
        {
            employee!.level = AuthLevel.Manager;
            employee!.SetID(2);
            employee!.basePay = 10000;
            EmployeeControllerBase controller = EmployeeFactory.GetEmployeeController(employee);
            float wage = controller.AcceptCalc(visitor);
            Assert.AreEqual(employee!.basePay * 1.1 - 90, wage);
        }

        [TestMethod]
        public void TestPayCalcGeneralManager() 
        {
            employee!.level = AuthLevel.GeneralManager;
            employee!.SetID(3);
            employee!.basePay = 100000;
            EmployeeControllerBase controller = EmployeeFactory.GetEmployeeController(employee);
            float wage = controller.AcceptCalc(visitor);
            Assert.AreEqual(employee!.basePay * 1.2 - 90, wage);
        }
    }
}