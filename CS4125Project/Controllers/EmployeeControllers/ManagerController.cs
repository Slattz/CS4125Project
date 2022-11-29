using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Controllers.PayrollControllers;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class ManagerController : EmployeeBaseDecorator
    {
        List<EmployeeModel> employees;
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

        public void approveRequest(WorkerRequestModel request, bool approve)
        {
            request.approved = approve;
            this.requests.closedRequests.Add(request);
            this.requests.closedRequests.Remove(request);
        }

        public void approveShiftSwap(int requestID, bool approve)
        {
            ShiftSwapModel shiftRequest = (ShiftSwapModel)getRequest(requestID);
            if (shiftRequest.newWorkerAgreed)
            {
                //change workerID on rota here
            }
            approveRequest(shiftRequest, shiftRequest.newWorkerAgreed && approve);

        }

        public void approveSickLeave(int requestID, bool approve)
        {
            SickDayRequestModel sickRequest = (SickDayRequestModel)getRequest(requestID);
            approveRequest(sickRequest, approve);
            int newWorkerID = EmployeeSelector.getAvailableEMployee(sickRequest.shiftId).id;
            ShortNoticeRequest request = new ShortNoticeRequest();
            request.WorkerID = newWorkerID;
            request.shiftId = sickRequest.shiftId;
            request.approved = false;
            request.requestID = getNextRequestId();
            this.requests.openRequests.Add(request);
        }

        public void approveShortNoticeRequest(ShortNoticeRequest request, bool approve)
        {
            request.approved = approve;
            this.requests.closedRequests.Add(request);
            this.requests.openRequests.Remove(request);
        }

        private WorkerRequestModel getRequest(int rID)
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
