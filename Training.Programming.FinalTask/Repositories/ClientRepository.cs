using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using Training.Programming.FinalTask.Models;

namespace Training.Programming.FinalTask.Repositories
{
    public class ClientRepository
    {
        public List<Client> All()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Clients.ToList();
            }
        }

        public void Add(Client newClient)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Clients.Add(newClient);
                db.SaveChanges();
            }
        }

        public void Save(Client client)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(client).State = EntityState.Modified;
                db.SaveChanges();
            }
        }

        public Client GetBySocialSecurityNumber(string ssn)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Clients.FirstOrDefault(x => x.SocialSecurityNumber == ssn);
            }
        }

      
    }
}