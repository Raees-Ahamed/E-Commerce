using System.ComponentModel.DataAnnotations;

namespace PlaceMe.Models
{
    public class UserDto
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
        public AddressLineDto AddressLines { get; set; }
        public string ContactNo { get; set; }
        public RoleDto Role { get; internal set; }
        public string Token { get; internal set; }

    }
}
