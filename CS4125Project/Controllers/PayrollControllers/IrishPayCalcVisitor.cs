
using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.EmployeeServices;
using System.Diagnostics.Contracts;

namespace CS4125Project.Controllers.PayrollControllers
{
    public class IrishPayCalcVisitor : IPayCalcVisitor
    {
        public float VisitEmployee(EmployeeControllerBase employee)
        {
            //Super complicated ultra powerful calculator
            float base_pay = employee.employeeModel.basePay;
            base_pay -= CalculateUSC(base_pay);
            base_pay -= CalculatePRSI(base_pay);
            base_pay -= CalculateTax(base_pay);
            return base_pay;
        }

        public float VisitManager(ManagerController manager)
        {
            //Super complicated ultra powerful calculator
            float base_pay = (float)(1.1 * manager.employeeModel.basePay);
            base_pay -= CalculateUSC(base_pay);
            base_pay -= CalculatePRSI(base_pay);
            base_pay -= CalculateTax(base_pay);
            return base_pay;
        }

        public float VisitGeneralManager(GeneralManagerController gManager)
        {
            //Super complicated ultra powerful calculator
            float base_pay = (float)(1.2 * gManager.employeeModel.basePay);
            base_pay -= CalculateUSC(base_pay);
            base_pay -= CalculatePRSI(base_pay);
            base_pay -= CalculateTax(base_pay);
            return base_pay;
        }

        private float CalculatePRSI(float pay)
        {
            float prsi = 10;
            Contract.Ensures(prsi > 0 && prsi < pay);
            return prsi;
        }
        private float CalculateUSC(float pay)
        {
            float usc = 30;
            Contract.Ensures(usc > 0 && usc < pay);
            return usc;
        }
        private float CalculateTax(float pay)
        {
            float tax = 50;
            Contract.Ensures(tax > 0 && tax < pay);
            return tax;
        }
    }
}