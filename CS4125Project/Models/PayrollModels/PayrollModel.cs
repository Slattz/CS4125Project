using System.Collections.Generic;
using CS4125Project.Controllers.EmployeeControllers;

namespace CS4125Project.Models.PayrollModels
{

    public class PayrollModel
    {
        public List<EmployeeControllerBase> employees;
        public IPayCalcVisitor calc;
        public List<PayslipModel> payslips;
    }
}
