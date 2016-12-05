using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.UI.WebControls;
using System.Web.WebPages;
using Microsoft.Ajax.Utilities;
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
          
            // before buy Insurance validate Client age 
            string clientSsn = policy.Client.ClientSsn;
            int age = GetClientsAge(clientSsn);

            if (age >= 18)
            {
                //this will change inserted Policy state to Active
                 policy.PolicyState = State.Active;
            }

            else
            {
               throw new ApplicationException($"You can't buy insurance if you are younger than 18 - and your SSN = {clientSsn}");  
            }
          }

        public int GetClientsAge(string ssn)
        {
            var today = DateTime.Today;
            int clientBirthdate = 0;

            var clientSsn = _clients.GetBySocialSecurityNumber(ssn).ClientSsn.Substring(0,6);

            int clientYear = clientSsn.Substring(0, 2).AsInt();

            if (clientYear < 16)
            {
                clientBirthdate = ("20" + clientSsn).AsInt();
                int d = clientBirthdate % 100;
                int m = (clientBirthdate / 100) % 100;
                int y = clientBirthdate / 10000;
                var result = new DateTime(y, m, d);
                int birthdayAdjustment = today < result ? -1 : 0;
                int clientAge = today.Year - result.Year + birthdayAdjustment;
                return clientAge;
            }

            else
            {
                 clientBirthdate = ("19" + clientSsn).AsInt();
                int d = clientBirthdate % 100;
                int m = (clientBirthdate / 100) % 100;
                int y = clientBirthdate / 10000;
                var result = new DateTime(y, m, d);
                int birthdayAdjustment = today < result ? -1 : 0;
                int clientAge = today.Year - result.Year + birthdayAdjustment;
                return clientAge; 
            }
             
         }
    }
}