using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceMe.Infrastructure.Entities
{
    public class ImageLine
    {
        public int Id { get; set; }
        [Required]
        public string Image { get; set; }
        public int ProductId { get; set; }
        [ForeignKey("ProductId")]
        public virtual Product SingleProduct { get; set; }
    }
}
