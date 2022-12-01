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

        public void RequestShiftSwap(int shiftID, int newEmployeeID)
        {
            ShiftSwapRequestModel swapRequest = new ShiftSwapRequestModel
            {
                approved = false,
                workerID = this.employeeModel.id,
                newWorkerID = newEmployeeID,
                newWorkerAgreed = false,
                shiftID = shiftID,
                requestID = ShiftSwapRequestsDatabase.Instance.GetNextRequestID(),
            };
            ShiftSwapRequestsDatabase.Instance.InsertRequest(swapRequest);
        }

        public void AgreeShiftSwap(int requestID, bool agree)
        {
            ShiftSwapRequestModel swapRequest = ShiftSwapRequestsDatabase.Instance.GetRequestByID(requestID);
            if (swapRequest != null)
            {
                swapRequest.newWorkerAgreed = agree;
                ShiftSwapRequestsDatabase.Instance.UpdateRequest(swapRequest, swapRequest.closed);
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
            sickRequest.requestID = SickRequestsDatabase.Instance.GetNextRequestID();
            SickRequestsDatabase.Instance.InsertRequest(sickRequest);
        }

        public void AgreeShortNotice(int shiftID)
        {
            ShortNoticeRequestModel snRequest = ShortNoticeRequestsDatabase.Instance.GetRequestByShiftID(shiftID);
            if (snRequest != null )
            {
                snRequest.approved = true;
                ShortNoticeRequestsDatabase.Instance.UpdateRequest(snRequest, true);
            }
        }

        public int getNextRequestId()
        {
            return requests.openRequests.Count + requests.closedRequests.Count + 1;
        }
    }
}
