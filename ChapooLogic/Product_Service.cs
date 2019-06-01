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
        public List<Product> GetProducts()
        {
            DAO_Product ProductDAO = new DAO_Product();
            List<Product> products = ProductDAO.GetProducts();
            return products;
        }

        public List<Product> GetDrinks()
        {
            DAO_Product ProductDAO = new DAO_Product();
            List<Product> products = ProductDAO.GetAllDrinks();
            return products;
        }

        public List<Product> GetLunch()
        {
            DAO_Product ProductDAO = new DAO_Product();
            List<Product> products = ProductDAO.GetAllLunch();
            return products;
        }

        public List<Product> GetDiner()
        {
            DAO_Product ProductDAO = new DAO_Product();
            List<Product> products = ProductDAO.GetAllDiner();
            return products;
        }
    }
}
