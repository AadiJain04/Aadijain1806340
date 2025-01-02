using System.Data.Entity;
using Assignment1.Models;
public class ContactContext : DbContext
{
    public ContactContext() : base("name=database")
    {
    }

    public DbSet<Contact> Contacts { get; set; }
}
