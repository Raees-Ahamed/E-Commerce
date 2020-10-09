using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PlaceMe.Core.ResourceParameters;
using PlaceMe.Core.ServiceInterface;
using PlaceMe.Infrastructure.Entities;
using PlaceMe.Models;
using System;
using System.Collections.Generic;

namespace PlaceMe.Controllers
{
    [ApiController]
    [Route("api/orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly IMapper mapper;

        public OrderController(IOrderService orderService, IMapper mapper)
        {
            this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet()]
        public ActionResult<IEnumerable<OrderDto>> GetOrders()
        {
            var orders = orderService.GetOrders();

            return Ok(mapper.Map<IEnumerable<OrderDto>>(orders));
        }

        [HttpGet("detail")]
        public ActionResult<IEnumerable<OrderDto>> GetOrder([FromQuery] UserResourceParameter userResourceParameter)
        {
            var order = orderService.GetOrderByEmail(userResourceParameter.Email);
            return Ok(mapper.Map<IEnumerable<OrderDto>>(order));
        }

        [HttpPost]
        public ActionResult Create(OrderDto orderDto)
        {
            orderDto.Status = StatusTypeDto.Pending;
            var order = mapper.Map<Order>(orderDto);
            orderService.CreateOrder(order);

            return Ok("Order placed successfully");
        }
    }
}
