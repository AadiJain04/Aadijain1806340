using System.Linq;
using System.Web.Mvc;
using AssessmentQues1.Models;

public class CodeController : Controller
{
    private NorthwindEntities db = new NorthwindEntities();
    public ActionResult CustomersInGermany()
    {
        var customersInGermany = db.Customers
                                    .Where(c => c.Country == "Germany")
                                    .ToList();

       
        return View(customersInGermany);
    }

    public ActionResult CustomerOrderDetails(int orderId)
    {
        var customerOrder = db.Order
                              .Where(o => o.OrderID == orderId)
                              .Select(o => new
                              {
                                  o.OrderID,
                                  o.OrderDate,
                                  o.RequiredDate,
                                  o.ShippedDate,
                                  CustomerName = o.Customer.CompanyName,
                                  CustomerContact = o.Customer.ContactName,
                                  CustomerCountry = o.Customer.Country
                              }).FirstOrDefault();
        return View(customerOrder);
    }
}
