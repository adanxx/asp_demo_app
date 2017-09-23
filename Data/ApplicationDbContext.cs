using aspconsoleapp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace aspconsoleapp.Data
{
    public class ApplicationDbContext : IdentityDbContext<IdentityUser>
    {
        
        public DbSet<Contact> Contacts {get;set;}
        
        public  ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
      
    }
}