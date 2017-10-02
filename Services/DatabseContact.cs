using System.Collections.Generic;
using aspconsoleapp.Models;
using aspconsoleapp.Data;
using System.Linq;

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

        public void DeleteContact(int id)
        {
           var contact = _dbContext.Contacts.FirstOrDefault(c => c.id ==id );
           _dbContext.Contacts.Remove(contact);
           _dbContext.SaveChanges();
        }

        public IEnumerable<Contact> GetallContacts()
        {
           return _dbContext.Contacts; 
        }

        public Contact GetContact(int id)
        {
            return _dbContext.Contacts.FirstOrDefault(c => c.id == id);
        }
    }
}