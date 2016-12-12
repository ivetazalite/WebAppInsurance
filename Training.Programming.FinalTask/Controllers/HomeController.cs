using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Training.Programming.FinalTask.Models;
using Training.Programming.FinalTask.Repositories;

namespace Training.Programming.FinalTask.Controllers
{
    public class HomeController : Controller

           
    {
        private readonly ClientRepository _clientDb = new ClientRepository();
        private readonly ProductRepository _productDb = new ProductRepository();

        public ActionResult Index()
        {
             ViewBag.Message = "Hello! Do You need insurance? We can sell to you";

            return View();
        }

        // GET: Clients/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Clients/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Name,Surname,SocialSecurityNumber,Sex,ClientType")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientDb.Add(client);
                _productDb.All();

                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Hello! Do You need insurance? We can sell to you";

            return View();
        }



        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}