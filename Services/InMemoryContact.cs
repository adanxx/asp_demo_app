using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using aspconsoleapp.Models;

namespace aspconsoleapp.Services
{
    public class InMemoryContact : IContact
    {
        private List<Contact> _contact = new List<Contact>
        {
             new Contact { id = 1, FirstName ="Jons", LastName ="Kels", PhoneNumber ="123457", EmailAddress="Ad@47hotmail.com"},
              new Contact { id = 2, FirstName ="Jons1", LastName ="Kels1", PhoneNumber ="12345745", EmailAddress="Ad@49hotmail.com"},
               new Contact { id = 3, FirstName ="Jons2", LastName ="Kels2", PhoneNumber ="12345755", EmailAddress="Ad@50hotmail.com"}
        };

        public void addContact(Contact contact)
        {
            contact.id = _contact.Max( c => c.id)+ 1;
            _contact.Add(contact);
        }

        public void DeleteContact(int id)
        {
            var contact = _contact.Find( c => c.id == id);
            _contact.Remove(contact);
        }

        public IEnumerable<Contact> GetallContacts()
        {
           return _contact;
        }

    } 
    
}