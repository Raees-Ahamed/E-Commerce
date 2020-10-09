using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaceMe.Infrastructure.Entities
{
    public class Promotion
    {
        [Key]
        public string Id { get; set; }
        public virtual List<PromotionLine> PromotionLines { get; set; }
        public string promotionImage { get; set; }
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public DateTime EndDate { get; set; }
    }
}
