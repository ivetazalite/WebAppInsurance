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

        // GET: Policies
        public ActionResult Index()
        {
            var policies = _policies.All();

            return View(policies);
        }

        // GET: Policies/Details/5
        public ActionResult Details(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var policy = _policies.All().FirstOrDefault(x => x.PolicyId == id.Value);

            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // GET: Policies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Policies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "PolicyId,PolicyNumber,Premium,State,StartDate,EndDate")] Policy policy)
        {
            if (ModelState.IsValid)
            {
                _policies.Add(policy);
                return RedirectToAction("Index");
            }

            return View(policy);
        }

        // GET: Policies/Edit/5
        public ActionResult Edit(Guid? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var policy = _policies.All().FirstOrDefault(x => x.PolicyId == id.Value);

            if (policy == null)
            {
                return HttpNotFound();
            }
            return View(policy);
        }

        // POST: Policies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PolicyId,PolicyNumber,Premium,State,StartDate,EndDate")] Policy policy)
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
