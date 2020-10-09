namespace PlaceMe.Models
{
    public class AddressLineDto
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }

        public virtual UserDto User { get; set; }
    }
}
