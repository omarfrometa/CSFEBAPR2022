using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CS.BO;
using CS.WEB.Models;

namespace CS.WEB.Controllers
{
    public class UserController : Controller
    {
        CSFEBAPR2022Entities db = new CSFEBAPR2022Entities();
        // GET: User
        public ActionResult Index()
        {
            return View(db.User.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Countries = db.Country.ToList();
            ViewBag.Provincias = db.PlaceBirth.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(UserModel model)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Username = model.Username,
                Password = model.Password,
                Email = model.Email,
                Enabled = true,
                CreatedDate = DateTime.Now
            };

            var profile = new UserProfile {
                Id = Guid.NewGuid(),
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = "M",
                DOB = DateTime.Now.AddYears(-18),
                PlaceBirthId = model.PlaceBirthId,
                CountryId = model.CountryId,
                AddressLine1 = model.AddressLine1,
                AddressLine2 = model.AddressLine2
            };

            user.UserProfile.Add(profile);

            db.User.Add(user);
            var result = db.SaveChanges() > 0;

            return RedirectToAction("Index");
        }
    }
}