using CS4125Project.Models.EmployeeModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace CS4125Project.Controllers.EmployeeControllers
{
    //
    public class EmployeeControllerBase : Controller
    {
        public EmployeeModel employeeModel;
        public RequestsModel requests;

        public EmployeeControllerBase()
        {
            this.employeeModel = new EmployeeModel();
        }
        public EmployeeControllerBase(EmployeeModel employeeModel)
        {
            this.employeeModel = employeeModel;
        }
        public virtual IActionResult GetView()
        {
            return View();
        }

        public virtual float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.VisitEmployee(this);
        }

        public void requestHoliday(DateTime start, DateTime end)
        {
            HolidayRequestModel holRequest = new HolidayRequestModel();
            holRequest.startDate = start;
            holRequest.endDate = end;
            holRequest.approved = false;
            holRequest.WorkerID = employeeModel.id;
            holRequest.requestID = getNextRequestId();
        }

        private int getNextRequestId()
        {
            return requests.openRequests.Count + requests.closedRequests.Count + 1;
        }
    }
}
