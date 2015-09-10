using Microsoft.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Sample.Models
{
    public class WestWindContext: DbContext
    {
        public DbSet<Customer> Customers { get; set; }

    }
}
