using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Training.Programming.FinalTask.Models;
using Training.Programming.FinalTask.Repositories;

namespace Training.Programming.FinalTask.Controllers
{
    public class ClientsController : Controller
    {
        private readonly ClientRepository _clientDb = new ClientRepository();

        // GET: Clients
        public ActionResult Index()
        {
            var clients = _clientDb.All();
            
            return View(clients);
        }

        // GET: Clients/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _clientDb.All().FirstOrDefault(x => x.ClientId == id.Value);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
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
                return RedirectToAction("Index");
            }

            return View(client);
        }

        // GET: Clients/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _clientDb.All().FirstOrDefault(x => x.ClientId == id.Value);

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // POST: Clients/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,Surname,SocialSecurityNumber,Sex,ClientType")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientDb.Save(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        // GET: Clients/Details/5
        public ActionResult CheckPrice(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _clientDb.All().FirstOrDefault(x => x.ClientId == id.Value);



            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        // GET: Clients/Delete/5
        public ActionResult Delete(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var client = _clientDb.All().FirstOrDefault(x => x.ClientId == id.Value);
          
            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete([Bind(Include = "ClientId,Name,Surname,SocialSecurityNumber,Sex,ClientType")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientDb.Delete(client);
                return RedirectToAction("Index");
            }
            //var clients = _clientDb.All();
             return View();
        }
    }
}
