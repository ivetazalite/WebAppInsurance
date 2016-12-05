using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Training.Programming.FinalTask.Models;
using Training.Programming.FinalTask.Repositories;

namespace Training.Programming.FinalTask.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ProductRepository _productDb = new ProductRepository();

        public ActionResult Index()
        {
            var products = _productDb.All();
            return View(products);
        }
        
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var allProducts = _productDb.All();

            Product product = null;

            foreach (var allProduct in allProducts)
            {

                if (allProduct.ProductId == id)
                {
                    product = allProduct;
                }
            }

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,Name,CreatedDateTime,Premium")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productDb.Add(product);

                return RedirectToAction("Index");
            }

            return View(product);
        }
        
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var allProducts = _productDb.All();

            Product product = null;

            foreach (var allProduct in allProducts)
            {

                if (allProduct.ProductId == id)
                {
                    product = allProduct;
                }
            }

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,Name,CreatedDateTime,Premium")] Product product)
        {
            if (ModelState.IsValid)
            {
                _productDb.Save(product);

                return RedirectToAction("Index");
            }
            return View(product);
        }
    }
}
