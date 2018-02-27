using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using taskLec1_new.Models;

namespace taskLec1_new.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ApplicationDbContext DB = new ApplicationDbContext();
        public ActionResult Index()
        {
            List<Models.Product> Products = new List<Models.Product>();
            Products = DB.Products.ToList();
            return View(Products);
        }
        public ActionResult Create(Models.Product insert)
        {
            if (ModelState.IsValid)
            {
                DB.Products.Add(new Product { name = insert.name, Description = insert.Description, salary = insert.salary, quantity = insert.quantity, DateAdd = DateTime.Now });
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
        }
        public ActionResult Edit(int id, Product Update)
        {
            var product = DB.Products.Where(fun => fun.Id == id).SingleOrDefault();
            if (ModelState.IsValid)
            {
                DB.Entry(new Product { Id = id, name = Update.name, Description = Update.Description, salary = Update.salary, quantity = Update.quantity, DateAdd = DateTime.Now }).State = System.Data.Entity.EntityState.Modified;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
        public ActionResult GetData(int id)
        {
            return View(DB.Products.Where(fun => fun.Id == id).SingleOrDefault());
        }
        public ActionResult Delete(int id)
        {
            if (ModelState.IsValid)
            {
                DB.Entry(new Product { Id = id }).State = System.Data.Entity.EntityState.Deleted;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(DB.Products.Where(fun => fun.Id == id).SingleOrDefault());

        }
    }
}