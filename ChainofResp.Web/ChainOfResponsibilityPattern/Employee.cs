using ChainofResp.Web.Entities;
using ChainofResp.Web.Models;

namespace ChainofResp.Web.ChainOfResponsibilityPattern
{
    public abstract class Employee
    {
        protected Employee NextApprover;
        public void SetNextApprover(Employee supervisor)
        {
            this.NextApprover = supervisor;
        }
        public abstract void ProcessRequest(CustomerProcessViewModel request);
    }
}
