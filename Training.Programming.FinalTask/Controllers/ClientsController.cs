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
        
        public ActionResult Index()
        {
            var clients = _clientDb.All();

            return View(clients);
        }

        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var allClients = _clientDb.All();

            Client client = null;

            foreach (var allClient in allClients)
            {

                    if (allClient.ClientId == id)
                   {
                       client = allClient;
                   }
            }

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClientId,Name,Surname,SocialSecurityNumber,Sex")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientDb.Add(client);

                return RedirectToAction("Index");
            }

            return View(client);
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var allClients = _clientDb.All();

            Client client = null;

            foreach (var allClient in allClients)
            {

                if (allClient.ClientId == id)
                {
                    client = allClient;
                }
            }

            

            if (client == null)
            {
                return HttpNotFound();
            }
            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ClientId,Name,Surname,SocialSecurityNumber,Sex")] Client client)
        {
            if (ModelState.IsValid)
            {
                _clientDb.Save(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }
    }
}