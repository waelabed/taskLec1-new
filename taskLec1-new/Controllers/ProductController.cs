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
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
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
        public ActionResult Edit(int id)
        {
            var product = DB.Products.Find(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            var _product = DB.Products.Find(id);
            if (ModelState.IsValid)
            {
                _product.DateAdd = product.DateAdd;
                _product.Description = product.name;
                _product.quantity = product.quantity;
                _product.salary = product.salary;
                DB.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(_product);
        }
        public ActionResult GetData(int id)
        {
            return View(DB.Products.Find(id));
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