using System.ComponentModel.DataAnnotations;

namespace PlaceMe.Infrastructure.Entities
{
    public class User
    {
        [Required]
        [Key]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public virtual AddressLine AddressLines { get; set; }
        public string ContactNo { get; set; }
        public Role Role { get; internal set; }
        public string Token { get; set; }
    }
}
