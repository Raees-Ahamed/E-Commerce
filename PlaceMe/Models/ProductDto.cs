using System;
using System.Collections.Generic;

namespace PlaceMe.Models
{
    public class ProductDto
    {
        public int Id { get; set; }
        public virtual List<ImageLineDto> ImageLines { get; set; }
        public string Name { get; set; }
        public string LongDescription { get; set; }
        public virtual List<DescriptionLineDto> DescriptionLines { get; set; } 
        public CategoryTypeDto Category { get; set; }
        //public int Quantity { get; set; }
        //public double Rating { get; set; }
        //public int SalesCount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
