using System.DAL.Models.Identity;

namespace System.DAL.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public int UserId { get; set; } // Assuming you have a User class
        public ApplicationUser User { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
