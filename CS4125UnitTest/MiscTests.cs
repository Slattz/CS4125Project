using CS4125Project.Controllers.PayrollControllers;

namespace CS4125UnitTest
{
    [TestClass]
    public class MiscTests
    {
        [TestMethod]
        public void TestPayslip()
        {
            PayslipController payslipper = new PayslipController();
            payslipper.GeneratePayslip();
            Assert.IsNotNull(payslipper.Index());
        }
    }
}