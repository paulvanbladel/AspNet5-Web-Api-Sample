using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using System.Net.Http;
using OwinMonoDocker;
using System.Data.Entity;

namespace OwinMonoDocker
{
    public class CustomersController : ApiController
    {
        ApplicationDbContext _Db = new ApplicationDbContext();

        [HttpGet]
        [Route("api/Customers/MimicCustomerImport/{numberOfRecords}")]
        public async Task<IHttpActionResult> MimicCustomerImport(int numberOfRecords)
        {
            for (int i = 0; i < numberOfRecords; i++)
            {
                _Db.Customers.Add(new Customer { Name = DateTime.Now.ToShortTimeString() + " " + i });    
            }
            await _Db.SaveChangesAsync();
            return Ok();
        }

        
        public IEnumerable<Customer> Get()
        {
            return _Db.Customers;
        }


        public async Task<Customer> Get(int id)
        {
            var customer = await _Db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                throw new HttpResponseException(
                    System.Net.HttpStatusCode.NotFound);
            }
            return customer;
        }


        public async Task<IHttpActionResult> Post(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("No customer data provided");
            }
            var customerExists = await _Db.Customers.AnyAsync(c => c.Id == customer.Id);

            if (customerExists)
            {
                return BadRequest("Exists");
            }

            _Db.Customers.Add(customer);
            await _Db.SaveChangesAsync();
            return Ok();
        }


        public async Task<IHttpActionResult> Put(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest("No customer data provided");
            }
            var existing = await _Db.Customers.FirstOrDefaultAsync(c => c.Id == customer.Id);

            if (existing == null)
            {
                return NotFound();
            }

            existing.Name = customer.Name;
            await _Db.SaveChangesAsync();
            return Ok();
        }


        public async Task<IHttpActionResult> Delete(int id)
        {
            var customer = await _Db.Customers.FirstOrDefaultAsync(c => c.Id == id);
            if (customer == null)
            {
                return NotFound();
            }
            _Db.Customers.Remove(customer);
            await _Db.SaveChangesAsync();
            return Ok();
        }
    }
}