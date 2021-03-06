﻿using System;
using System.Security.Cryptography.X509Certificates;
using System.Web.Services.Description;
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
   
        public Policy GetPolicy(string ssn, string productName)
        {
            var product = _products.GetProductByName(productName);
            var client = _clients.GetBySocialSecurityNumber(ssn);

            Policy newPolicy = new Policy();

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
            string clientSsn = policy.Client.SocialSecurityNumber;
            int age = GetClientsAge(clientSsn);

            if (age >= 18)
            {
                //this will change inserted Policy state to Active
                if (IsPolicyExistForThisPeriod(policy) == false)
                {
                    policy.State = State.Active;
                    policy.Product.Premium = EmployeeDiscount(policy);
                    //calculate payment date
                    CalculatePaymentDate(policy);
                    //Some message about payment date
                }
                else
                {
                    throw new ApplicationException ($"You have already existing {policy.Product.Name} Policy for period from {policy.State} till {policy.EndDate}");
                }
             

                if (age > 75)
                {
                    throw new ApplicationException("You must call to office Phone number -> 67565656565 ");
                }

                else
                {
                    throw new ApplicationException($"You can't buy insurance if you are younger than 18 - and your SSN = {clientSsn }" );
                }
            }
        }

        public int GetClientsAge(string ssn)
        {
            var today = DateTime.Today;
            int clientBirthdate = 0;

            var clientSsn = _clients.GetBySocialSecurityNumber(ssn).SocialSecurityNumber.Substring(0,6);

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

        public int CalculatePolicyPeriod(Policy policy)
        {
            int period = 0;

            DateTime startDate = policy.StartDate;
            DateTime endDate = policy.EndDate;
            period = endDate.Month - startDate.Month;

            return period;
        }

        public decimal PriceChanges(Policy policy)
        {
          //  int period = 0;
         decimal halfYearPrice = policy.Product.Premium + (policy.Product.Premium * 5/100) ;
         decimal quarterYearPrice = policy.Product.Premium + (policy.Product.Premium * 7/100);
         var period = CalculatePolicyPeriod(policy);

            if (period  < 3 && period == 3)
            {
                return quarterYearPrice;
            }

            if (3 < period && period < 6 && period == 6)
            {
                return halfYearPrice;
            }

            else 
            {
                return policy.Product.Premium;
            }

        }
        public decimal EmployeeDiscount(Policy policy)
        {
            //verify Policy period 
            decimal  priceChanges = PriceChanges(policy);
            decimal discountPrice = priceChanges - (priceChanges * 50/100);
            //If Employee then add 50 % discount 
            decimal price = policy.Client.ClientType == Employee.Yes ? discountPrice : priceChanges;

            return price;
        }

        public bool IsPolicyExistForThisPeriod(Policy policy)
        {
            DateTime startDate = policy.StartDate;
            DateTime endDate = policy.EndDate;
            var client = policy.Client.SocialSecurityNumber;
            var product = policy.Product.Name;
            Policy existingPolicy = GetPolicy(ssn: client, productName: product);
            DateTime thisStartDate = existingPolicy.StartDate;
            DateTime thisEndDate = existingPolicy.EndDate;

            if (policy.Client.SocialSecurityNumber == existingPolicy.Client.SocialSecurityNumber &&
                policy.Product.Name == existingPolicy.Product.Name)
            {
                //Verify periods
                int resultStartDate = DateTime.Compare(startDate, thisStartDate);
                int resultEndDate = DateTime.Compare(endDate, thisEndDate);
                bool result = (resultStartDate == 0 && resultEndDate == 0) ? true : false;
                return result;
            }
            else
                return false;
        }

        public DateTime CalculatePaymentDate(Policy policy)
        {
            //Add 2 Monthes to Policy End date 
            return policy.EndDate.AddMonths(2);
        }

     }
 }
