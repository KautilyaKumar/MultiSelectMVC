using MultiSelectExample.Context;
using MultiSelectExample.Models;
using MultiSelectExample.ViewModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MultiSelectExample.Controllers
{
    public class HomeController : Controller
    {
        EntityContext _context = new EntityContext();

        public ActionResult Index()
        {
            return View(_context.Profile.ToList());
        }
        public ActionResult Add()
        {
            List<SelectListItem> CategoryCollection = null;
            var countrytip = new SelectListItem()
            {
                Value = (0).ToString(),
                Text = "--- Select Category ---"
            };

            CategoryCollection = _context.Category.AsNoTracking().OrderBy(n => n.CategoryID).Select(n => new SelectListItem { Value = n.CategoryID.ToString(), Text = n.CategoryName }).ToList(); //new List<SelectListItem>();
            CategoryCollection.Insert(0, countrytip);

            ViewBag.Categories = CategoryCollection;
            return View();
        }



        public ActionResult SaveProfile(ProfileViewModel _profile)
        {
            
            if(ModelState.IsValid)
            {
                Profile profile = new Profile();
                var Cid = string.Join(",", _profile.CategoryID);
                profile.ProfilerName = _profile.ProfilerName;
                profile.ProfilerNumber = _profile.ProfilerNumber;
                profile.CategoryID = Cid;
                if (_profile.ProfileID == 0)
                {
                    _context.Profile.Add(profile);
                    _context.SaveChanges();

                    
                }            
                else
                {
                    profile.ProfileID = _profile.ProfileID;
                    _context.Entry(profile).State = EntityState.Modified;
                    _context.SaveChanges();

                                  
                }
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View();
            }

            
        }

        public ActionResult Edit(int id)
        {
            var c = _context.Profile.Find(id);
            ProfileViewModel _profile = new ProfileViewModel();
            _profile.ProfileID = c.ProfileID;
            _profile.ProfilerName = c.ProfilerName;
            _profile.ProfilerNumber = c.ProfilerNumber;
             string[] data= c.CategoryID.Split(',');
            List<int> tmpSelected = new List<int>();
            foreach (string str in data)
            {
                int val = Convert.ToInt32(str);
                tmpSelected.Add(val);
            }
            
            List<SelectListItem> CategoryCollection = null;
            var countrytip = new SelectListItem()
            {
                Value = (0).ToString(),
                Text = "--- Select Category ---"
            };

            CategoryCollection = _context.Category.AsNoTracking().OrderBy(n => n.CategoryID).Select(n => new SelectListItem { Value = n.CategoryID.ToString(), Text = n.CategoryName }).ToList(); //new List<SelectListItem>();
            CategoryCollection.Insert(0, countrytip);


            ViewBag.Categories =new MultiSelectList( CategoryCollection,"Value","Text", tmpSelected);



            return View(_profile);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page!!!!!";
            int x = 100;
            // the above values is 100
            return View();
        }

    }
}