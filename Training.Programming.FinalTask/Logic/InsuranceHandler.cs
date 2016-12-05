using System;
using Training.Programming.FinalTask.Models;
using Training.Programming.FinalTask.Repositories;

namespace Training.Programming.FinalTask.Logic
{
    public class InsuranceHandler
    {
        private readonly ProductRepository _products = new ProductRepository();
        private readonly PolicyRepository _policies = new PolicyRepository();
        private readonly ClientRepository _clients = new ClientRepository();
       // private Policy newPolicy;

        public Policy GetPolicy(string ssn, string productName)
        {
            var product = _products.GetProductByName(productName);
            var client = _clients.GetBySocialSecurityNumber(ssn);

            Policy newPolicy = null;

            newPolicy.Client = client;
            newPolicy.Product = product;
            
            if (newPolicy == null)
           {
                throw new ApplicationException(":(");
            } 

          _policies.Add(newPolicy);

            return newPolicy;
        }

        public void BuyInsurance(Policy policy)
        {
          
          //this will change inserted Policy state to Active
            policy.PolicyState = State.Active;

        }
    }
}