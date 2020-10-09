using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PlaceMe.Core.Service
{
    public class OrderService : IOrderService
    {
        private readonly IProductService productService;
        private readonly IUnitOfWork unitOfWork;

        public OrderService(IUnitOfWork unitOfWork)
        {

            productService = new ProductService(unitOfWork) ?? throw new ArgumentNullException(nameof(productService));
            this.unitOfWork = unitOfWork;
        }

        public void CreateOrder(Order order)
        {
            try
            {
                order.Id = Guid.NewGuid().ToString();
                foreach (var item in order.OrderLines)
                {
                    //Updating the product
                    item.OrderId = order.Id;
                    productService.Update(null, item.ProductId, -(item.Quantity));
                }

                //This method will add orderlines as well, since this entity has the orderline list
                unitOfWork.OrderRepository.Create(order);
                unitOfWork.Save();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void DeleteOrder(string id)
        {
            try
            {
                var order = unitOfWork.OrderRepository.GetByID(id);

                if (order == null)
                    throw new ArgumentNullException(nameof(order));

                //Checks the status type
                if (order.Status == StatusType.Completed)
                {
                    //product quantity will not be update if the status is confirmed
                    unitOfWork.OrderRepository.Delete(order);
                }
                else
                {
                    //Retrieving the orderLine from the database, so that can get the quantity
                    var orderBOTemp = GetOrderById(id);

                    foreach (var temp in orderBOTemp.OrderLines)
                    {
                        //updates the quantity
                        productService.Update(null, temp.ProductId, temp.Quantity);
                    }

                    unitOfWork.OrderRepository.Delete(order);
                }
                //Records will be saved after checking the status type
                unitOfWork.Save();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private Order GetOrderById(string id)
        {
            try
            {
                var query = unitOfWork.OrderRepository.Get(includeProperties: "Customers,OrderLines").First(o => o.Id == id);
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Order> GetOrderByEmail(string email)
        {
            try
            {
                var query = unitOfWork.OrderRepository.Get(includeProperties: "Customers,OrderLines").Where(o => o.Email == email);
                return query;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public IEnumerable<Order> GetOrders()
        {
            try
            {
                var orders = unitOfWork.OrderRepository.Get(includeProperties: "OrderLines,Customers");

                if (orders != null)
                {
                    return orders;
                }
                else
                {
                    throw new ArgumentNullException(nameof(orders));
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void UpdateOrder(Order order)
        {
            try
            {
                var orderTemp = GetOrderById(order.Id);


                foreach (var item in order.OrderLines.ToList())
                {
                    if (item.Id != 0)
                    {
                        var orderItemQuantity = orderTemp.OrderLines.FirstOrDefault(o => o.Id == item.Id).Quantity;
                        var difference = orderItemQuantity - item.Quantity;
                        orderTemp.OrderLines.FirstOrDefault(o => o.Id == item.Id).Quantity = item.Quantity;

                        if (item.IsDeleted)
                        {
                            //Remove the orderline
                            var orderItem = orderTemp.OrderLines.FirstOrDefault(o => o.Id == item.Id);
                            orderTemp.OrderLines.Remove(orderItem);
                        }

                        //updates the difference quantity
                        productService.Update(null, item.ProductId, difference);
                    }
                    else
                    {
                        productService.Update(null, item.ProductId, -(item.Quantity));
                        orderTemp.OrderLines.Add(item);
                    }

                    //updates the order
                    unitOfWork.OrderRepository.Update(orderTemp);
                    unitOfWork.Save();
                    unitOfWork.Commit();
                }
            }
            catch (Exception ex)
            {
                unitOfWork.Rollback();
                throw ex;
            }
        }
    }
}
