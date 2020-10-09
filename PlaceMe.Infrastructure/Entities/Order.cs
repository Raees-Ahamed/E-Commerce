using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceMe.Infrastructure.Entities
{
    public class Order
    {
        [Key]
        public string Id { get; set; }
        public virtual List<OrderLine> OrderLines { get; set; }
        public string Email { get; set; }
        [ForeignKey("Email")]
        public virtual User Customers { get; set; }
        [Required]
        public DateTime Date { get; set; }
        public StatusType Status { get; set; }
    }
}
