using ChainofResp.Web.Entities;
using Microsoft.EntityFrameworkCore;

namespace ChainofResp.Web.DataAccess
{
    public class AppDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Database=ChainOfRespDb;integrated Security=True;trustServerCertificate=true");
            base.OnConfiguring(optionsBuilder);
        }
        public DbSet<CustomerProcess> CustomerProcesses { get; set; }
    }
}
