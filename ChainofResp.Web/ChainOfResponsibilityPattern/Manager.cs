using ChainofResp.Web.DataAccess;
using ChainofResp.Web.Entities;
using ChainofResp.Web.Models;

namespace ChainofResp.Web.ChainOfResponsibilityPattern
{
    public class Manager(AppDbContext _context):Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 500000)
            {
                // Approve the request
                var customerProcess = new CustomerProcess
                {
                    FullName = request.FullName,
                    Amount = request.Amount,
                    EmployeeName = "Şube Müdürü - Mehmet Demir",
                    Description = "Para Çekme İşlemi Onaylandı. Müşteriye tutar ödendi."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
            else
            {
                // Reject the request
                var customerProcess = new CustomerProcess
                {
                    FullName = request.FullName,
                    Amount = request.Amount,
                    EmployeeName = "Şube Müdürü - Mehmet Demir",
                    Description = "Para çekme tutarı şube müdürünün ödeyebileceği miktarı aştığı için işlem bölge müdürüne yönlendirildi."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
                NextApprover.ProcessRequest(request);
            }
        }
    }
}
