using SuperHeroes.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SuperHeroes.Controllers
{
    public class SuperHeroController : Controller
    {
        ApplicationDbContext db = new ApplicationDbContext();
        // GET: SuperHero
        public ActionResult Index()
        {
            var hero = new SuperHero { Name = "Nipples" };
            return View(hero);
        }
        public ActionResult Create()
        {
            //ViewBag.Id = new SelectList(db.SuperHero, "Id", "Name");
            return View();
        }
        public ActionResult Read()
        {
            var heroes = db.SuperHero.ToList();
            return View(heroes);
        }
        public ActionResult Update()
        {
            var heroes = db.SuperHero.ToList();
            return View(heroes);
        }
        public ActionResult Delete()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHero superHero)
        {
            db.SuperHero.Add(superHero);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id)
        {
            var hero = db.SuperHero.Where(s => s.Id == id).Single();

            //db.SuperHero.Remove(hero);
            //db.SaveChanges();
            return View(hero);
        }
    }
}