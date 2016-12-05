using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Training.Programming.FinalTask.Models;

namespace Training.Programming.FinalTask.Repositories
{
    public class ProductRepository
    {
        public Product GetProductByName(string productName)
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products.FirstOrDefault(x => x.ProductName == productName);
            }
        }

        public List<Product> All()
        {
            using (var db = new ApplicationDbContext())
            {
                return db.Products.ToList();
            }
        }

        public void Add(Product newProduct)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Products.Add(newProduct);
                db.SaveChanges();
            }
        }

        public void Save(Product product)
        {
            using (var db = new ApplicationDbContext())
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
            }
        }
    }
}