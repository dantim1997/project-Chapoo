using ChapooModels;
using ChapooDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class Product_Service
    {
        public List<Product> FromBillToProducts(List<Bill> bills)
        {
            List<Product> products = new List<Product>();
            foreach (Bill bill in bills)
            {
                products.Add(bill.product);
            }
            return products;
        }

        public List<Product> GetProducts()
        {
            DAO_Product ProductDAO = new DAO_Product();
            List<Product> products = ProductDAO.GetProducts();
            return products;
        }
    }
}
