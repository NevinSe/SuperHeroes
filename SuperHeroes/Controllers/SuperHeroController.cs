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
        public ActionResult Index(int id)
        {
            var hero = db.SuperHero.Where(s => s.Id == id).Single();
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
        public ActionResult Update(int id)
        {
            var hero = db.SuperHero.Where(s => s.Id == id).Single();
            return View(hero);
        }
        [HttpPost]
        public ActionResult Update([Bind(Include = "Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHero superHero)
        {
            
            var updateSuperHero = db.SuperHero.Where(u => u.Id == superHero.Id).FirstOrDefault();
            updateSuperHero.Name = superHero.Name;
            updateSuperHero.AlterEgo = superHero.AlterEgo;
            updateSuperHero.PrimaryAbility = superHero.PrimaryAbility;
            updateSuperHero.SecondaryAbility = superHero.SecondaryAbility;
            updateSuperHero.CatchPhrase = superHero.CatchPhrase;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var hero = db.SuperHero.Where(s => s.Id == id).Single();
            return View(hero);
        }
        public ActionResult OnDelete(int id)
        {
            var hero = db.SuperHero.Where(s => s.Id == id).Single();
            db.SuperHero.Remove(hero);
            db.SaveChanges();
            var heroes = db.SuperHero.ToList();
            return RedirectToAction("Read", heroes);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,AlterEgo,PrimaryAbility,SecondaryAbility,CatchPhrase")] SuperHero superHero)
        {
            db.SuperHero.Add(superHero);
            db.SaveChanges();
            return RedirectToAction("Read");
        }
       
    }
}