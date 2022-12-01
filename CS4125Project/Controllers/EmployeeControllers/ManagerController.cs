using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Controllers.PayrollControllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using CS4125Project.Controllers.Database;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class ManagerController : EmployeeBaseDecorator
    {
        public ManagerController(EmployeeControllerBase controllerBase, EmployeeModel model) : base(controllerBase, model)
        {

        }

        public override IActionResult GetView()
        {
            return View();
        }

        public override float AcceptCalc(IPayCalcVisitor visitor)
        {
            return visitor.VisitManager(this);
        }

        public void ApproveShiftSwap(int requestID, bool approve)
        {
            ShiftSwapRequestModel swapRequest = ShiftSwapRequestsDatabase.Instance.GetRequestByID(requestID);
            if (swapRequest != null)
            {
                swapRequest.approved = approve;
                ShiftSwapRequestsDatabase.Instance.UpdateRequest(swapRequest, true);
            }
        }

        public void GenerateShortNoticeRequest(int newWorkerID, int shiftID)
        {
            ShortNoticeRequestModel request = new ShortNoticeRequestModel
            {
                workerID = newWorkerID,
                shiftID = shiftID,
                approved = false,
                closed = false,
                requestID = ShortNoticeRequestsDatabase.Instance.GetNextRequestID()
            };
            ShortNoticeRequestsDatabase.Instance.InsertRequest(request);
        }

        public void ApproveSickLeave(int requestID, bool approve)
        {
            SickDayRequestModel sickRequest = SickRequestsDatabase.Instance.GetRequestByID(requestID);

            if (sickRequest != null)
            {
                sickRequest.approved = approve;
                SickRequestsDatabase.Instance.UpdateRequest(sickRequest, true);
                int newWorkerID = EmployeeSelector.getAvailableEmployee(sickRequest.shiftID).id;

                GenerateShortNoticeRequest(newWorkerID, sickRequest.shiftID);
            }
        }

        public void ApproveShortNoticeRequest(int requestID, bool approve)
        {
            ShortNoticeRequestModel snRequest = ShortNoticeRequestsDatabase.Instance.GetRequestByID(requestID);
            if (snRequest != null) 
            {
                snRequest.approved = approve;
                ShortNoticeRequestsDatabase.Instance.UpdateRequest(snRequest, true);
            }
        }
    }
}
