using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using SportsStore.Domain.Entities;

namespace SportsStore.Domain.Abstract
{
    public interface IProductRepository
    {
        IEnumerable<Product> Products { get; }
        IEnumerable<History> Histories { get; }
        IEnumerable<User> Users { get; }
        IEnumerable<Order> Orders { get; }
        Product DeleteProduct(int productID);
        void AddProduct(Product product);
        void AddHistory(int productID);
        void AddOrder(Order order);
    }
}
