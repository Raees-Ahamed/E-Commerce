namespace PlaceMe.Models
{
    public class OrderLineDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDto Products { get; set; }
        public string OrderId { get; set; }
        public virtual OrderDto Orders { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
