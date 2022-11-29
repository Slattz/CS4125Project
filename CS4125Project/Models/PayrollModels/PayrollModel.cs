using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Controllers.PayrollControllers;
using CS4125Project.Models.EmployeeModels;
using System.Collections.Generic;

namespace CS4125Project.Models.PayrollModels
{

    public class PayrollModel
    {
        public List<EmployeeControllerBase> employees;
        public IPayCalcVisitor calc;
        public List<PayslipModel> payslips;
    }
}
