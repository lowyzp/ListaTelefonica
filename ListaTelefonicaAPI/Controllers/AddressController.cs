using ListaTelefonicaAPI.Data;
using ListaTelefonicaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ListaTelefonicaAPI.Controllers
{
    [Route("api/adresses")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly ContactContext _context;

        public AddressController(ContactContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public List<Address> Get()
        {
            return _context.Addresses.ToList();
        }

        [HttpGet("{id}")]
        public Address Get(int id)
        {
            return _context.Addresses.FirstOrDefault(a => a.Id == id);
        }

        [HttpPost]
        public void Post([FromBody] Address value)
        {
            var address = _context.Addresses.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<ContactsController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Address value)
        {
            Address address = _context.Addresses.FirstOrDefault(a => a.Id == id);
            address.Country = value.Country;
            address.Street = value.Street;
            address.Number = value.Number;
            address.Complement = value.Complement;
            address.State = value.State;
            address.City = value.City;
            address.Zip = value.Zip;
            address.Marker = value.Marker;

            _context.SaveChanges();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }

}