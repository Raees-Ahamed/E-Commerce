namespace PlaceMe.Models
{
    public class DescriptionLineDto
    {
        public int ProductId { get; set; }
        public string ShortDescription { get; set; }
        public int UnitPrice { get; set; }
        public int Quantity { get; set; }
        public double Rating { get; set; }
        public int SalesCount { get; set; }
        public virtual ProductDto SingleProduct { get; set; }
    }
}
