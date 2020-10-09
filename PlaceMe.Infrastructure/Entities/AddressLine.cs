using System.ComponentModel.DataAnnotations.Schema;

namespace PlaceMe.Infrastructure.Entities
{
    public class AddressLine
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string Email { get; set; }
        [ForeignKey("Email")]
        public virtual User User { get; set; }
    }
}
