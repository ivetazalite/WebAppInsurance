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

        // GET: Products
        public ActionResult Index()
        {
            var products = _productDb.All();

            return View(products);
        }

        // GET: Products/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productDb.All().FirstOrDefault(x => x.ProductId == id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Products/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var product = _productDb.All().FirstOrDefault(x => x.ProductId == id.Value);

            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
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
