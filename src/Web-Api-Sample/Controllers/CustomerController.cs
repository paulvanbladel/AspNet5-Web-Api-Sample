using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using Web_Api_Sample.Models;
using Microsoft.Data.Entity;

namespace Web_Api_Sample.Controllers
{
    [Route("api/[controller]")]
    public class CustomerController : Controller
    {
        private readonly WestWindContext _context;
        public CustomerController(WestWindContext context)
        {
            _context = context;
        }


        [HttpGet]
        [Route("MimicCustomerImport/{numberOfRecords}")]
        public async Task<IActionResult> MimicCustomerImport(int numberOfRecords)
        {
            for (int i = 0; i < numberOfRecords; i++)
            {
                _context.Customers.Add(new Customer { CompanyName = DateTime.Now.ToString() + " " + i });
            }
            await _context.SaveChangesAsync();
            return Redirect("/api/customer");
        }


        // GET: api/customer
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET api/customer/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var item = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            return new ObjectResult(item);
        }

        // POST api/customer
        [HttpPost]
        public async Task<ActionResult> Post([FromBody]Customer item)
        {
            if (!ModelState.IsValid)
            {
                //Context.Response.StatusCode = 400;
                return HttpBadRequest();
            }

            else
            {
                var itemExists = await _context.Customers.AnyAsync(i => i.Id == item.Id);
                if (itemExists)
                {
                    return HttpBadRequest();
                }
                _context.Customers.Add(item);
                await _context.SaveChangesAsync();
                string url = Url.RouteUrl("GetByIdRoute", new { id = item.Id }, Request.Scheme, Request.Host.ToUriComponent());
                Context.Response.StatusCode = 201;
                Context.Response.Headers["Location"] = url;
                return Ok();
            }
        }

        // PUT api/customer/5
        [HttpPut("{id}")]
        public async Task<ActionResult> Put(string id, [FromBody]Customer item)
        {
            if (item == null)
            {
                return HttpBadRequest("No item data provided");
            }
            var existingItem = await _context.Customers.FirstOrDefaultAsync(i => i.Id == item.Id);
            if (existingItem == null)
            {
                return HttpNotFound("Item not found");
            }

            existingItem.CompanyName = item.CompanyName;
            existingItem.Address = item.Address;
            existingItem.City = item.City;
            existingItem.ContactTitle = item.ContactTitle;
            existingItem.Fax = item.Fax;
            existingItem.Phone = item.Phone;
            existingItem.PostalCode = item.PostalCode;
            existingItem.Region = item.Region;
            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE api/customer/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var item = await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return HttpNotFound();
            }
            _context.Customers.Remove(item);
            await _context.SaveChangesAsync();
            return new HttpStatusCodeResult(204); // 201 No Content
        }
    }
}
