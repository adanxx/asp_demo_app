using System.Collections.Generic;
using aspconsoleapp.Models;
using aspconsoleapp.Data;

namespace aspconsoleapp.Services
{
    public class DatabseContact : IContact
    {
        private readonly ApplicationDbContext _dbContext;
        public DatabseContact(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        } 
        public void addContact(Contact contact)
        {
            _dbContext.Contacts.Add(contact);
            _dbContext.SaveChanges();

        }

        public IEnumerable<Contact> GetallContacts()
        {
           return _dbContext.Contacts; 
        }
    }
}