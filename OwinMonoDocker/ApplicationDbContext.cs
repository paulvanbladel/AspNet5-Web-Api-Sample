using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OwinMonoDocker
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
            : base("myMysqldb")
        {
        }
        public IDbSet<Customer> Customers { get; set; }
    }
    
    public class ApplicationDbInitializer : CreateDatabaseIfNotExists<ApplicationDbContext>
    {
        protected override void Seed(ApplicationDbContext context)
        {
            base.Seed(context);
            context.Customers.Add(new Customer { Name = "Microsoft" });
            context.Customers.Add(new Customer { Name = "Google" });
            context.Customers.Add(new Customer { Name = "Apple" });
        }
    }
}
