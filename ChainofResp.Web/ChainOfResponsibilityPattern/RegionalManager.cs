using ChainofResp.Web.DataAccess;
using ChainofResp.Web.Entities;
using ChainofResp.Web.Models;

namespace ChainofResp.Web.ChainOfResponsibilityPattern
{
    public class RegionalManager(AppDbContext _context): Employee
    {
        public override void ProcessRequest(CustomerProcessViewModel request)
        {
            if (request.Amount <= 1000000)
            {
                // Approve the request
                var customerProcess = new CustomerProcess
                {
                    FullName = request.FullName,
                    Amount = request.Amount,
                    EmployeeName = "Bölge Müdürü - Ahmet Yılmaz",
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
                    EmployeeName = "Bölge Müdürü - Ahmet Yılmaz",
                    Description = "Para çekme tutarı bölge müdürünün ödeyebileceği miktarı aştığı için işlem gerçekleştirilemedi.Günlük para çekme limitini aştığı için, müşterinin birden fazla gün gelmesi gereklidir."
                };
                _context.CustomerProcesses.Add(customerProcess);
                _context.SaveChanges();
            }
        }
    }
}
