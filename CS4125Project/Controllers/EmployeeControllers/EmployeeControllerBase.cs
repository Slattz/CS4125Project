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

        public void requestShiftSwap(int shiftID, int employeeID, int newEmployeeID)
        {
            ShiftSwapModel swapRequest = new ShiftSwapModel();
            swapRequest.approved = false;
            swapRequest.WorkerID = employeeID;
            swapRequest.requestID = newEmployeeID;
            swapRequest.newWorkerAgreed = false;
            swapRequest.shiftId = shiftID;
            swapRequest.requestID = getNextRequestId();
            this.requests.openRequests.Add(swapRequest);
        }
        public void agreeShiftSwap(int requestId)
        {
            foreach(WorkerRequestModel request in this.requests.openRequests)
            {
                if(request.requestID == requestId)
                {
                    ShiftSwapModel swapRequest = (ShiftSwapModel)request;
                    if(swapRequest.newWorkerId == this.employeeModel.id)
                    {
                        swapRequest.newWorkerAgreed = true;
                    }
                    break;
                }
            }
        }

        public void requestHoliday(DateTime start, DateTime end)
        {
            HolidayRequestModel holRequest = new HolidayRequestModel();
            holRequest.startDate = start;
            holRequest.endDate = end;
            holRequest.approved = false;
            holRequest.WorkerID = employeeModel.id;
            holRequest.requestID = getNextRequestId();
            this.requests.openRequests.Add(holRequest);
        }

        public void callInSick(int shiftId)
        {
            SickDayRequestModel sickRequest = new SickDayRequestModel();
            sickRequest.shiftId = shiftId;
            sickRequest.WorkerID = employeeModel.id;
            sickRequest.approved = false;
            sickRequest.requestID = getNextRequestId();
            this.requests.openRequests.Add(sickRequest);
        }

        private int getNextRequestId()
        {
            return requests.openRequests.Count + requests.closedRequests.Count + 1;
        }
    }
}
