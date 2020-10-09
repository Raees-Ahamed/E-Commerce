using System;
using System.Collections.Generic;

namespace PlaceMe.Models
{
    public class PromotionDto
    {
        public string Id { get; set; }
        public virtual List<PromotionLineDto> PromotionLines { get; set; }
        public string promotionImage { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
