using CS4125Project.Controllers.Database;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Models.PayrollModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CS4125Project.Controllers.PayrollControllers
{
    public class PayslipController : Controller
    {
        private PayrollModel payroll;

        public PayslipController()
        {
            payroll = new PayrollModel();
            payroll.calc = new IrishPayCalcVisitor();
            EmployeeDatabase.Instance.GetAllEmployees(out List<EmployeeModel> employees);
            payroll.employees = EmployeeDatabase.ModelsToEmployee(employees);
        }
        public IActionResult Index()
        {
            return View();
        }

        public void GeneratePayslip()
        {
            payroll.payslips = new List<PayslipModel>();
            foreach (var employee in payroll.employees)
            {
                var payslip = new PayslipModel();
                payslip.pay = employee.AcceptCalc(payroll.calc);
                payroll.payslips.Add(payslip);
            }
        }
    }
}
