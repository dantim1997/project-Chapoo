using ChapooModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChapooDAL;

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

        public List<Bill_ViewModel> FromProductToBill_ViewModel(List<Product> products)
        {
            List<Bill_ViewModel> bills = new List<Bill_ViewModel>();
            foreach (Product product in products)
            {
                Bill_ViewModel bill = new Bill_ViewModel()
                {
                    ProductId = product.ProductId,
                    ProductName = product.ProductName,
                    Amount = product.Supply
           
                };
                bills.Add(bill);
            }
            return bills;
        }
    }
}
