using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web.Helpers;
using SportsStore.Domain.Concrete;

namespace SportsStore.Domain.Entities
{
   public class Card
    {
        public List<CartLine> lineCollection = new List<CartLine>();

        public void AddItem(Product product, int quantity)
        {
            CartLine line = lineCollection.Where(p => p.Product.ProductID == product.ProductID).FirstOrDefault();
            if (line == null)
            {
                lineCollection.Add(new CartLine { Product = product, Quantity = quantity });
            }
            else
            {
                line.Quantity += quantity;
            }
        }  
        
        public void SendEmialWithOrder(ShoppingDetailscs shoppingdetailscs)
        {
            string str_with_full_adress = "Imie: " + shoppingdetailscs.name + " Nazwisko: " + shoppingdetailscs.surname + " Państwo: " + shoppingdetailscs.country + " Misato: " + shoppingdetailscs.city + " Ulica: " + shoppingdetailscs.street + " Kod Pocztowy: " + shoppingdetailscs.zip;

            WebMail.SmtpServer = "smtp.poczta.onet.pl";
            WebMail.SmtpPort = 587;
            WebMail.SmtpUseDefaultCredentials = true;
            WebMail.EnableSsl = true;

            WebMail.UserName = "umt@onet.eu";
            WebMail.Password = "mateusz1";

            WebMail.From = "umt@onet.eu";     
            WebMail.Send(to: "allegro8800@wp.pl", subject: "Dane klienta", body: str_with_full_adress);

            lineCollection.Clear();
        }

        public Guid Generate_guid()
        {
            Guid guid_for_order;
            guid_for_order = Guid.NewGuid();
            return guid_for_order;
        }

        public DateTime DataForOders()
        {
            DateTime data = DateTime.UtcNow.ToLocalTime();
            return data;
        }

        public void AddToMenageOrder(int SessionUserID)
        {
            EFProductRepository e = new EFProductRepository();
            Order order = new Order();
            Guid guid_form_Generate_guid = Generate_guid();
            DateTime data_form_DataForOders = DataForOders();

            foreach (int item in lineCollection.Select(x => x.Product.ProductID))
            {
                order.IdProduct = item;
                order.IdUser = SessionUserID;
                order.Guid = guid_form_Generate_guid.ToString();
                order.Data = data_form_DataForOders;
                e.AddOrder(order);
            }
        }

        public void RemoveLine(Product product)
        {
            lineCollection.RemoveAll(l => l.Product.ProductID == product.ProductID);
        }

        public decimal ComputeTotalValue()
        {
            return lineCollection.Sum(e => e.Product.Price * e.Quantity);                 
        }

        public void Rebate()
        {            
            foreach (var item in lineCollection)
             {
                if (item.licznik_rabate == 1)
                {
                    break;
                }
                else
                {
                    item.licznik_rabate = item.licznik_rabate + 1;
                    item.Product.Price = item.Product.Price * Decimal.Parse(0.50.ToString());
                }

            }
        }

        public IEnumerable<CartLine> Lines
        {
            get
            {
                return lineCollection;
            }
        }
    }

    public class CartLine
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public int licznik_rabate { get; set; }
    }
}
 