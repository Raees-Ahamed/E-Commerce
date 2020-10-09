using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PlaceMe.Infrastructure.Entities
{
    public class DescriptionLine
    {
        public int Id { get; set; }
        public string ShortDescription{ get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product SingleProduct { get; set; }
        public double UnitPrice { get; set; }
        public int Quantity { get; set; }
        public int SalesCount { get; set; }
        public double Rating { get; set; }
    }
}
