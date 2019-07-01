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
        DAO_Product product_DAO = new DAO_Product();

        /// <summary>
        /// places all products from database in list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetProducts()
        {
            List<Product> products = product_DAO.GetProducts();
            return products;
        }

        /// <summary>
        /// places all drink products in a list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetDrinks()
        {
            List<Product> products = product_DAO.GetAllDrinks();
            return products;
        }

        /// <summary>
        /// places all lunch products in a list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetLunch()
        {
            List<Product> products = product_DAO.GetAllLunch();
            return products;
        }

        /// <summary>
        /// places all diner products in a list
        /// </summary>
        /// <returns></returns>
        public List<Product> GetDiner()
        {
            List<Product> products = product_DAO.GetAllDiner();
            return products;
        }
    }
}
