using System.Collections.Generic;
using SportsStore.Domain.Abstract;
using SportsStore.Domain.Entities;
namespace SportsStore.Domain.Concrete
{
    public class EFProductRepository : IProductRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Product> Products { get { return context.Products; } }

        public IEnumerable<History> Histories
        {
            get
            {
                return context.Histories;
            }
        }

        public IEnumerable<User> Users
        {
            get
            {
                return context.Users;
            }
        }

        public IEnumerable<Order> Orders
        {
            get
            {
                return context.Orders;
            }
        }

        public void AddOrder(Order order)
        {
            context.Orders.Add(order);
            context.SaveChanges();
        }

        public void AddHistory(int productID)
        {
            var history = new History { IdProducts = productID };
            {
                  context.Histories.Add(history);
                  context.SaveChanges();
            }
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public Product DeleteProduct(int productID)
        {
            Product dbEntry = context.Products.Find(productID);
            if (dbEntry != null)
            {
                context.Products.Remove(dbEntry);
                context.SaveChanges();
            }
            return dbEntry;
        }
    }

    public class EFInfoRepository : IInfoRepository
    {
        private EFDbContext context = new EFDbContext();

        public IEnumerable<Infoes> Infoes
        {
            get { return context.Infoes; }
        }
    }
}