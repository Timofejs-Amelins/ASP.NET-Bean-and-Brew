// System.ComponentModel.DataAnnotations allows us to define primary keys for the tables in the Bean and Brew database
using System.ComponentModel.DataAnnotations;
// BakedGoodsOrder is part of the Models namespace where properties are defined with standard functionality
namespace Beanbrew.Models
{
    // BakedGoodsOrder model defines the properties of every baked goods object and the columns of the BakedGoodsOrder database
    public class BakedGoodsOrder
    {
        // The BakedGoodsOrderId is the primary key of BakedGoodsOrders
        [Key]
        public int BakedGoodsOrderId { get; set; }
        // the Quantity is an integer attribute that allows the user to specify the quantity of the baked good they are ordering, allowing multiple baked goods to be entered into a single order
        public int Quantity { get; set; }
        public int BakedGoodsId { get; set; }
        public int CustomerId { get; set; }
        public int HamperId { get; set; }
        public decimal Price { get; set; }
        // the table will store the CustomerId, HamperId, and BakedGoodsId as the foreign keys, one customers, hamper and bakedgood can be used on multiple orders; we first need to know who ordered the baked good
        public virtual Customer Customer { get; set; }
        // a hamper is the packaging used for a baked good order; we need to know the packaging the baked good order is going to come in
        public virtual Hamper Hampers { get; set; }
        // finally and most importantly, we must know the baked good that the customer ordered, and one baked good can be ordered many times
        public virtual BakedGood BakedGoods { get; set; }
    }
}
