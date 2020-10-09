namespace PlaceMe.Models
{
    public class ImageLineDto
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDto SingleProduct { get; set; }
    }
}
