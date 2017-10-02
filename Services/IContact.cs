using System;
using System.Collections.Generic;
using aspconsoleapp.Models;

namespace aspconsoleapp.Services
{
    public interface IContact
    {
     IEnumerable<Contact> GetallContacts();   

      void addContact(Contact contact);    
      
      Contact GetContact(int id);
    
      void DeleteContact(int id);
    

   
    }
}