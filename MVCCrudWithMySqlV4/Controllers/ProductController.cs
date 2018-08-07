using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrudWithMySqlV4.Models;

namespace MVCCrudWithMySqlV4.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        public ActionResult Index()
        {
            List<product> productList = new List<product>();
            using (DBModels dbModel = new DBModels())
            {
                productList = dbModel.products.ToList<product>();
            }
            return View(productList);
        }

        // GET: Product/Details/5
        public ActionResult Details(int id)
        {
            product productModel = new product();
            using (DBModels dbmodel = new DBModels())
            {
                productModel = dbmodel.products.Where(x => x.ProductID == id).FirstOrDefault();
            }
            return View(productModel);
        }

        // GET: Product/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Product/Create
        [HttpPost]
        public ActionResult Create(product productModel)
        {
            using (DBModels dbmodels = new DBModels())
            {
                dbmodels.products.Add(productModel);
                dbmodels.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: Product/Edit/5
        public ActionResult Edit(int id)
        {
            product productModel = new product();
            using (DBModels dbmodel = new DBModels())
            {
                productModel = dbmodel.products.Where(x => x.ProductID == id).FirstOrDefault();
            }
            return View(productModel);
        }

        // POST: Product/Edit/5
        [HttpPost]
        public ActionResult Edit(product productModel)
        {
            using (DBModels dbmodel = new DBModels())
            {
                dbmodel.Entry(productModel).State = System.Data.Entity.EntityState.Modified;
                dbmodel.SaveChanges();
            }

            return RedirectToAction("index");
        }

        // GET: Product/Delete/5
        public ActionResult Delete(int id)
        {
            product productModel = new product();
            using (DBModels dbmodel = new DBModels())
            {
                productModel = dbmodel.products.Where(x => x.ProductID == id).FirstOrDefault();
            }
            return View(productModel);
        }

        // POST: Product/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            using (DBModels dbmodels = new DBModels())
            {
                product productModel = dbmodels.products.Where(x => x.ProductID == id).FirstOrDefault();
                dbmodels.products.Remove(productModel);

                dbmodels.SaveChanges();
            }

            return RedirectToAction("index");
        }
    }
}
