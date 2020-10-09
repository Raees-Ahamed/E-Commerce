using System;
using System.Collections.Generic;

namespace PlaceMe.Models
{
    public class OrderDto
    {
        public string Id { get; set; }
        public virtual List<OrderLineDto> OrderLines { get; set; }
        public string Email { get; set; }
        public virtual UserDto Customers { get; set; }
        public DateTime Date { get; set; }
        public StatusTypeDto Status { get; set; }
    }
}
