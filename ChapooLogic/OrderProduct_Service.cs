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

        public void UpdateStatus(int orderProductId, bool status, int orderId)
        {
            DAO_OrderProduct.UpdateOrderProductByIds(orderProductId, status, orderId);
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
                ProductId = orderProduct.ProductId,
                Supply = orderProduct.Product.Supply,
                Status = orderProduct.Status,
                OrderProductId = orderProduct.OrderProductId
            };
            
            return orderProductViewModel;
        }
    }
}
