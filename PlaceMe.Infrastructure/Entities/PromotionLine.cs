﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceMe.Infrastructure.Entities
{
    public class PromotionLine
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product Products { get; set; }
        public string PromotionId { get; set; }
        [ForeignKey("PromotionId")]
        public virtual Promotion Promotions { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public double UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
