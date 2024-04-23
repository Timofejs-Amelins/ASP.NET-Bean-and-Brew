using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// abstract container storing all models
namespace Beanbrew.Models
{
    public class Coffee
    {
        // just like Customers each object must have a primary key
        [Key]
        public int CoffeeId { get; set; }
        // we are storing coffee name and coffee price in the database
        public string CoffeeName { get; set; }
        public decimal UnitPrice { get; set; }
        // we must create the relationship between the Coffee table and the CoffeeOrder table
        public virtual ICollection<CoffeeOrder> CoffeeOrders { get; set; }
    }
}
