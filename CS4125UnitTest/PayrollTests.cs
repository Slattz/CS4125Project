using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;
using CS4125Project.Models.EmployeeModels;

namespace CS4125UnitTest
{
    [TestClass]
    public class PayrollTests
    {
        [TestMethod]
        public void TestPayCalcWorker()
        {
            IPayCalcVisitor visitor = new IrishPayCalcVisitor();
            EmployeeModel employee = new EmployeeModel();
            employee.level = AuthLevel.Worker;
            employee.id = 1;
            employee.basePay = 1000;
            WorkerController controller = (WorkerController)EmployeeFactory.GetEmployeeController(employee);
            float wage = controller.AcceptCalc(visitor);
            Assert.AreEqual(employee.basePay - 90, wage);
        }

        [TestMethod]
        public void TestPayCalcManager()
        {
            IPayCalcVisitor visitor = new IrishPayCalcVisitor();
            EmployeeModel employee = new EmployeeModel();
            employee.level = AuthLevel.Manager;
            employee.id = 2;
            employee.basePay = 10000;
            ManagerController controller = (ManagerController)EmployeeFactory.GetEmployeeController(employee);
            float wage = controller.AcceptCalc(visitor);
            Assert.AreEqual(employee.basePay - 90, wage);
        }

        [TestMethod]
        public void TestPayCalcGeneralManager() 
        {
            IPayCalcVisitor visitor = new IrishPayCalcVisitor();
            EmployeeModel employee = new EmployeeModel();
            employee.level = AuthLevel.GeneralManager;
            employee.id = 3;
            employee.basePay = 100000;
            GeneralManagerController controller = (GeneralManagerController)EmployeeFactory.GetEmployeeController(employee);
            float wage = controller.AcceptCalc(visitor);
            Assert.AreEqual(employee.basePay - 90, wage);
        }
    }
}