namespace PlaceMe.Models
{

    public class PromotionLineDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public virtual ProductDto Products { get; set; }
        public string PromotionId { get; set; }
        public virtual PromotionDto Promotions { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public bool IsDeleted { get; set; }
    }
}
