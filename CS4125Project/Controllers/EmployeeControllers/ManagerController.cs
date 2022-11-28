using CS4125Project.Controllers.EmployeeControllers;
using CS4125Project.Models.EmployeeModels;
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

        public void approveRequest(int requestId, bool approve)
        {
            foreach(WorkerRequestModel request in this.requests.openRequests){
                if(request.requestID == requestId)
                {
                    request.approved = approve;
                    this.requests.closedRequests.Add(request);
                    this.requests.closedRequests.Remove(request);
                }
            }
        }
    }
}
