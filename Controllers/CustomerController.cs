using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GeneralStoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private GeneralStoreDBContext _db;
        public CustomerController(GeneralStoreDBContext db)
        {
            _db = db;
        }

        [HttpPost]
        public async Task<IActionResult> CreateCustomer([FromForm] CustomerEdit newCustomer)
        {
            Customer customer = new Customer()
            {
                Name = newCustomer.Name,
                Email = newCustomer.Email,
            };
            _db.Customers.Add(customer);
            await _db.SaveChangesAsync();
            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _db.Customers.ToListAsync();
            return Ok(customers);
        }
    }
}