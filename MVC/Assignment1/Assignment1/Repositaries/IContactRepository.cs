using System.Collections.Generic;
using System.Threading.Tasks;
using Assignment1.Models;
public interface IContactRepository
{
    Task<List<Contact>> GetAllAsync();
    Task CreateAsync(Contact contact);
    Task DeleteAsync(long id);
}
