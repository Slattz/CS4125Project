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
            shift.employeeID = -1;
            rmodel.shifts = new List<ShiftModel> { shift };
            RotaController rota = new RotaController(logger, rmodel);
            var res = rota.Index();
            Assert.IsInstanceOfType(res, typeof(ViewResult));
            res = rota.Privacy();
            Assert.IsInstanceOfType(res, typeof(ViewResult));
            EmployeeModel emp = new EmployeeModel();
            //IObserver rotaObserver = ;
            emp.id = 1;
            rota.AssignShift(emp, shift.id);
            //Assert.IsTrue()
        }
    }
}