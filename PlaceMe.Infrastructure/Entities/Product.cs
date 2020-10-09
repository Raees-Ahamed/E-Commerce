using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PlaceMe.Infrastructure.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public virtual List<ImageLine> ImageLines { get; set; }
        [Required]
        [Display(Name = "Product Name")]
        [StringLength(50, ErrorMessage = "Name cannot be too long")]
        public string Name { get; set; }
        [Required]
        public string LongDescription { get; set; }
        public CategoryType Category { get; set; }
        public virtual List<DescriptionLine> DescriptionLines { get; set; }
        //[Required]
        //public int Quantity { get; set; }
        //public double rating { get; set; }
        //public int SalesCount { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
