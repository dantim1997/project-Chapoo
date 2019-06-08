using System;
using ChapooModels;
using ChapooDAL;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChapooLogic
{
    public class OrderProduct_Service
    {
        DAO_OrderProduct DAO_OrderProduct = new DAO_OrderProduct();
        public List<OrderProduct> GetAllByOrder(int OrderId, string type)
        {
            return DAO_OrderProduct.GetAllByOrder(OrderId, type);
        }

        public void UpdateStatus(int orderProductId, Statustype status, int orderId)
        {
           DAO_OrderProduct.UpdateOrderProductByIds(orderProductId, status, orderId);
        }

        public void UpdateAllStatus(List<OrderProduct> orderProduct, Statustype status)
        {
            DAO_OrderProduct.UpdateAllOrderProduct(orderProduct, status);
        }

        public List<OrderProductViewModel> OrderProductsToViewModels(List<OrderProduct> orderProducts)
        {
            List<OrderProductViewModel> orderProductViewModels = new List<OrderProductViewModel>();
            foreach (OrderProduct orderProduct in orderProducts)
            {
                orderProductViewModels.Add(OrderProductToViewModel(orderProduct));
            }
            return orderProductViewModels;
        }

        public OrderProductViewModel OrderProductToViewModel(OrderProduct orderProduct)
        {
            OrderProductViewModel orderProductViewModel = new OrderProductViewModel
            {
                Amount = orderProduct.Amount,
                Name = orderProduct.Product.ProductName,
                Supply = orderProduct.Product.Supply,
                OrderProductId = orderProduct.OrderProductId
            };
            
            return orderProductViewModel;
        }

        public void CreateOrderProduct(List<OrderProduct> orderProducts)
        {
            DAO_OrderProduct.CreateOrderPruduct(orderProducts);
        }

        public List<OrderProduct> GetActiveOrderProductList()
        {
            return DAO_OrderProduct.GetAllByActiveOrder();
        }

        public void UpdateOrderProductStatus(int TableNumber, Statustype Status, string type)
        {
            DAO_OrderProduct.UpdateOrderProductStatusByTablenumber(TableNumber, Status, type);
        }
    }
}
