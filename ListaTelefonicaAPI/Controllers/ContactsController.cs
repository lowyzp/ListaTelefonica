using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListaTelefonicaAPI.Models;
using ListaTelefonicaAPI.Data;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ListaTelefonicaAPI.Controllers
{
    [Route("api/contacts")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        private readonly ContactContext _context;

        public ContactsController(ContactContext context)
        {
            this._context = context;
        }

        [HttpGet]
        public List<Contact> Listar()
        {
            return _context
                .Contacts
                .Include("Phones")
                .Include("Phones.CountryCode")
                .Include("Addresses")
                .ToList();

        }

        // GET api/<ContactsController>/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _context
                .Contacts
                .Include("Phones")
                .Include("Phones.CountryCode")
                .Include("Addresses")
                .Single(c => c.Id == id);
        }

        [HttpGet("countrycodes")]
        public List<CountryCode> GetCountryCodes(int id)
        {
            return _context
                .CountryCodes.ToList();
        }

        // POST api/<ContactsController>
        [HttpPost]
        public void Post([FromBody] Contact value)
        {
            var contato = _context.Contacts.Add(value);
            _context.SaveChanges();
        }

        // PUT api/<ContactsController>/5
        [HttpPut]
        public void Put([FromBody] Contact value)
        {
            Contact contato = _context
                .Contacts
                .Include("Phones")
                .Include("Addresses")
                .Single(c => c.Id == value.Id);
            contato.Name = value.Name;
            contato.Email = value.Email;
            contato.Phones = value.Phones;
            contato.Addresses = value.Addresses;

            _context.SaveChanges();
        }

        // DELETE api/<ContactsController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            Contact contato = _context
                .Contacts.Single(c => c.Id == id);
            _context.Contacts.Remove(contato);
            _context.SaveChanges();
        }
    }
}
