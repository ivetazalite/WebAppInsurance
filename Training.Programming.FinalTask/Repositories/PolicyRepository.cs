using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Training.Programming.FinalTask.Models;

namespace Training.Programming.FinalTask.Repositories
{
    public class PolicyRepository
    {
        public List<Policy> All()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Policies.ToList();
            }
        }

        public void Add(Policy newPolicy)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Policies.Add(newPolicy);
                db.SaveChanges();
            }
        }

        public void Save(Policy policy)
        {
            using (var db = new ApplicationDbContext())
            {
                //var updatedPolicy = db.Policies.FirstOrDefault(x => x.PolicyNumber == policy.PolicyNumber);

                //if (updatedPolicy == null)
                //{
                //    throw new ApplicationException(":(");
                //} 

                //updatedPolicy.State = policy.State;
                //updatedPolicy.EndDate = policy.EndDate;
                //updatedPolicy.Premium = policy.Premium;
                //updatedPolicy.StartDate = policy.StartDate;
                //updatedPolicy.Client = db.Clients.FirstOrDefault(x => x.ClientId == policy.Client.ClientId);
                //updatedPolicy.Product = db.Products.FirstOrDefault(x => x.ProductId == policy.Product.ProductId);

                db.Entry(policy).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}