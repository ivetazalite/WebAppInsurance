using System;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using Training.Programming.FinalTask.Models;
using Training.Programming.FinalTask.Repositories;

namespace Training.Programming.FinalTask.Controllers
{
    public class PoliciesController : Controller
    {
        private readonly PolicyRepository _policies = new PolicyRepository();
           


        public ActionResult Index()
        {
         var policies =  _policies.All();

            return View(policies);
        }
        
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var allPolicies = _policies.All();

            Policy policy = null;

            foreach (var allPolicie in allPolicies)
            {

                if (allPolicie.PolicyId == id)
                {
                    policy = allPolicie;
                }
            }

            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyId,PolicyNumber,Premium,StartDate,EndDate,State")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _policies.Add(policy);

                return RedirectToAction("Index");
            }

            return View(policy);
        }
        
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var allPolicies = _policies.All();

            Policy policy = null;

            foreach (var allPolicie in allPolicies)
            {

                if (allPolicie.PolicyId == id)
                {
                    policy = allPolicie;
                }
            }

            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyId,PolicyNumber,Premium,StartDate,EndDate,State")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _policies.Save(policy);

                return RedirectToAction("Index");
            }
            return View(policy);
        }
    }
}
