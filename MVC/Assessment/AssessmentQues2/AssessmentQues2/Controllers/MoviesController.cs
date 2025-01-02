using AssessmentQues2.Models;
using System;
using System.Linq;
using System.Web.Mvc;

namespace AssessmentQues2.Controllers
{
    public class MoviesController : Controller
    {
        private MoviesDbContext db = new MoviesDbContext();

        // Create Movie (GET)
        public ActionResult Create()
        {
            return View();
        }

        // Create Movie (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Movies.Add(movie); 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }

        //Edit Movie (GET)
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }

            Movie movie = db.Movies.Find(id);
            if (movie == null)
            {
                return HttpNotFound();
            }
            return View(movie);
        }

        //Edit Movie (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Movie movie)
        {
            if (ModelState.IsValid)
            {
                db.Entry(movie).State = System.Data.Entity.EntityState.Modified; 
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(movie);
        }
    }
}
