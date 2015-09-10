using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web_Api_Sample.Models
{
    public class Order
    {
        public int OrderID { get; set; }

        public string CustomerID { get; set; }

        public int EmployeeID { get; set; }

        public DateTime? OrderDate { get; set; }

        public DateTime? RequiredDate { get; set; }

        public DateTime? ShippedDate { get; set; }

        public int ShipVia { get; set; }

        public decimal Freight { get; set; }

        public string ShipName { get; set; }

        public string ShipAddress { get; set; }

        public string ShipCity { get; set; }

        public string ShipRegion { get; set; }

        public string ShipCountry { get; set; }

        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
