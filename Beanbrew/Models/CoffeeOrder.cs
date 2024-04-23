using System.ComponentModel.DataAnnotations;

// abstract container storing all models
namespace Beanbrew.Models
{
    public class CoffeeOrder
    {
        [Key]
        public int CoffeeOrderId { get; set; }
        // the Customer ID and Coffee ID are foreign keys
        public int CoffeeId { get; set; }
        public int CustomerId { get; set; }
        // we need a quantity and a price
        public int Quantity { get; set; }
        private decimal OrderPrice { get; set; }
        public decimal Price { get; set; }
        // we must create the relationships to the Customer table and the Coffee table
        public virtual Coffee Coffees { get; set; }
        public virtual Customer Customers { get; set; }

    }
}
