using System.ComponentModel.DataAnnotations;
using Models;


namespace Models
{
    public class Customer
    {
        [Key]
        public int CustomerId { get; set; }


        [Required, StringLength(100)]
        public string Name { get; set; } = string.Empty;


        [Required, EmailAddress, StringLength(200)]
        public string Email { get; set; } = string.Empty;


        [Required, StringLength(200)]
        public string Password { get; set; } = string.Empty;


        public ICollection<Order> Orders { get; set; } = new List<Order>();
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}