using System.Collections.Generic;
using CS4125Project.Controllers.EmployeeServices;

namespace CS4125Project.Models.PayrollModels
{

    public class PayrollModel
    {
        public List<EmployeeController> employees;
        public IPayCalcVisitor calc;
        public List<PayslipModel> payslips;
    }
}
