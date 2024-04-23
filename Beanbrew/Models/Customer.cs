using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

// abstract container storing all models
namespace Beanbrew.Models
{
    public class Customer
    {
        // we must set the Customer ID as the primary key
        [Key]
        public int CustomerId { get; set; }
        // other properties of the Customer class are the first name, last name, and date of birth
        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to give us your first name.")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give us your last name.")]
        public string LastName { get; set; }
        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to give us your date of birth.")]
        public DateTime DOB { get; set; }
        // we must define relationships to the CoffeeOrder and BakedGoodsOrder by creating an iCollection, allowing Customers to manipulate the CoffeeOrder collection
        public virtual ICollection<CoffeeOrder> CoffeeOrders { get; set; }
        public virtual ICollection<BakedGoodsOrder> BakedGoodsOrders { get; set; }
    }
}
