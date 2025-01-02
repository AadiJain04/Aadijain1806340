using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Mvc;
using Assignment1.Models;
public class contactController : Controller
{
    private readonly ContactRepository _contactRepository;

    public contactController()
    {
        _contactRepository = new ContactRepository(); // Direct instantiation of ContactRepository
    }

    // GET: /Contact/Index
    public async Task<ActionResult> Index()
    {
        List<Contact> contacts = await _contactRepository.GetAllAsync();
        return View(contacts); // Pass the list of contacts to the view
    }

    // GET: /Contact/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: /Contact/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(Contact contact)
    {
        if (ModelState.IsValid)
        {
            await _contactRepository.CreateAsync(contact); // Create new contact asynchronously
            return RedirectToAction("Index"); // Redirect to Index view
        }
        return View(contact);
    }

    // GET: /Contact/Delete/{id}
    public async Task<ActionResult> Delete(long id)
    {
        var contact = await _contactRepository.GetAllAsync();
        return View(contact);
    }

    // POST: /Contact/DeleteConfirmed/{id}
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> DeleteConfirmed(long id)
    {
        await _contactRepository.DeleteAsync(id); // Delete contact asynchronously
        return RedirectToAction("Index"); // Redirect to Index view
    }
}
