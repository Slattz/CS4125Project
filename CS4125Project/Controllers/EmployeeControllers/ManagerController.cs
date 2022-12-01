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

        public void ApproveRequest(WorkerRequestModel request, bool approve)
        {
            this.requests.openRequests.Remove(request);
            request.approved = approve;
            this.requests.closedRequests.Add(request);
        }

        public void ApproveShiftSwap(int requestID, bool approve)
        {
            ShiftSwapModel shiftRequest = (ShiftSwapModel)GetRequest(requestID);
            if (shiftRequest.newWorkerAgreed)
            {
                //change workerID on rota here
            }
            ApproveRequest(shiftRequest, shiftRequest.newWorkerAgreed && approve);
        }

        public void ApproveSickLeave(int requestID, bool approve)
        {
            SickDayRequestModel sickRequest = SickRequestsDatabase.Instance.GetSickRequestByID(requestID);
            sickRequest.approved = approve;
            SickRequestsDatabase.Instance.UpdateRequest(sickRequest, true);

            int newWorkerID = EmployeeSelector.getAvailableEmployee(sickRequest.shiftID).id;
            ShortNoticeRequestModel request = new ShortNoticeRequestModel
            {
                workerID = newWorkerID,
                shiftID = sickRequest.shiftID,
                approved = false,
                requestID = getNextRequestId()
            };
            this.requests.openRequests.Add(request);
        }

        public void ApproveShortNoticeRequest(ShortNoticeRequestModel request, bool approve)
        {
            request.approved = approve;
            this.requests.closedRequests.Add(request);
            this.requests.openRequests.Remove(request);
        }

        private WorkerRequestModel GetRequest(int rID)
        {
            foreach (WorkerRequestModel request in this.requests.openRequests)
            {
                if (request.requestID == rID)
                { 
                    return request;
                }
            }
            return null;
        }
        
    }
}
