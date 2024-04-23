// Hamper is another Model class that defines the properties of a hamper and the columns of the Hamper table
// System.Collections.Generic is a module that allows us to create ICollections that define relationships between different tables from one table's side
using System.Collections.Generic;
// System.ComponentModel.DataAnnotations is a module that allows us to create primary keys for tables across the Bean and Brew database
using System.ComponentModel.DataAnnotations;

namespace Beanbrew.Models
{
    // this class defined Hamper properties
    public class Hamper
    {
        // every class and table must have a primary key before being uploaded to the database, so we have created a HamperId auto-incrementing key
        [Key]
        public int HamperId { get; set; }
        // different baked goods come in different sizes, so having different hamper sizes allow the user to select a hamper size; hamper size is a decimal because size is a continuous datum, this means that size is a numeric quantity and it can be in between 2 whole numbers (or integers)
        public decimal Size { get; set; }
        // hampers look nicer when they are in different colours, and they provide another indicator for what hampers to use for what baked goods orders
        public string Colour { get; set; }
        // finally, knowing the price of a hamper allows us to know how must it costs to order the required hampers to keep Bean and Brew running; also, this allows us to know the proportion of revenue made from orders lost to hamper orders, allowing Bean and Brew to make informed decisions about whether to invest or save money
        // create a private decimal for use as a setter
        public decimal Price { get; set; }
        // one hamper can be used in many baked goods orders, hence the iCollection below defining a one-to-many relationship
        public virtual ICollection<BakedGoodsOrder> BakedGoodsOrders { get; set; }
    }
}
