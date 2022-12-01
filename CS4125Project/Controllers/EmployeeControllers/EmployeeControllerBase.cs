using CS4125Project.Models.EmployeeModels;
using CS4125Project.Controllers.PayrollControllers;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using CS4125Project.Controllers.Database;

namespace CS4125Project.Controllers.EmployeeControllers
{
    //
    public class EmployeeControllerBase : Controller
    {
        internal EmployeeModel employeeModel;
        protected RequestsModel requests;

        public EmployeeControllerBase(EmployeeModel employeeModel)
        {
            this.employeeModel = employeeModel;
            requests = new RequestsModel()
            {
                openRequests = new List<WorkerRequestModel>(),
                closedRequests = new List<WorkerRequestModel>()
            };
        }
        public virtual IActionResult GetView()
        {
            return View();
        }

        public virtual float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.VisitEmployee(this);
        }

        public void requestShiftSwap(int shiftID, int newEmployeeID)
        {
            ShiftSwapModel swapRequest = new ShiftSwapModel();
            swapRequest.approved = false;
            swapRequest.workerID = this.employeeModel.id;
            swapRequest.requestID = newEmployeeID;
            swapRequest.newWorkerAgreed = false;
            swapRequest.shiftID = shiftID;
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
                    if(swapRequest.newWorkerID == this.employeeModel.GetID())
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
            holRequest.workerID = employeeModel.GetID();
            holRequest.requestID = getNextRequestId();
            this.requests.openRequests.Add(holRequest);
        }

        public void CallInSick(int shiftId)
        {
            SickDayRequestModel sickRequest = new SickDayRequestModel();
            sickRequest.shiftID = shiftId;
            sickRequest.workerID = employeeModel.GetID();
            sickRequest.approved = false;
            sickRequest.requestID = SickRequestsDatabase.Instance.GetNextSickRequestID();
            SickRequestsDatabase.Instance.InsertRequest(sickRequest);
        }

        public void agreeShortNotice(ShortNoticeRequestModel request)
        {
            this.requests.openRequests.Remove(request);
            request.approved = true;
            this.requests.closedRequests.Add(request);
        }

        public int getNextRequestId()
        {
            return requests.openRequests.Count + requests.closedRequests.Count + 1;
        }
    }
}
