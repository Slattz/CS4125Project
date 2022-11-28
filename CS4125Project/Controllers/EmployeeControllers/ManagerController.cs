using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
using CS4125Project.Controllers.PayrollControllers;
using Microsoft.AspNetCore.Mvc;

namespace CS4125Project.Controllers.EmployeeServices
{
    public class ManagerController : EmployeeBaseDecorator
    {
        public ManagerController(EmployeeControllerBase controllerBase) : base(controllerBase)
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

        public void approveShiftSwap(int requestID)
        {
            ShiftSwapModel shiftRequest = (ShiftSwapModel)getRequest(requestID);
            if (shiftRequest.newWorkerAgreed)
            {
                //change workerID on rota here
            }
            approveRequest(shiftRequest, shiftRequest.newWorkerAgreed);

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
