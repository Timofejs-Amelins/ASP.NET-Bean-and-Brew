// System.ComponentModel.DataAnnotations is an ASP.NET module that allows us to define primary keys for baked goods
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
// BakedGood is a model class that gets baked goods data from the BakedGood table
namespace Beanbrew.Models
{
    // this file stores the BakedGood class
    public class BakedGood
    {
        // BakedGoodId is the primary key of a baked good, we have used a range of data types which are more suitable for the data that will be inside the column of the BakedGoods table
        [Key]
        public int BakedGoodsId { get; set; }
        // we must also store the name of the baked good, it is a string, its type, and the price - the name lets the customer know what the bakery is called
        public string BakedGoodName { get; set; }
        // knowing the type of a baked good order is useful for customers to order baked goods easily
        public string BakedGoodType { get; set; }
        // staff and customers must know the price for staff to charge the correct amount easily and customers to make informed decisions about baked goods purchases; price is a decimal number
        public decimal Price { get; set; }
        // one baked good can be ordered 0, 1, or many times, so there is an iCollection that defines the relationship between the BakedGood table and the BakedGoodsOrder table from the BakedGood side
        public virtual ICollection<BakedGoodsOrder> BakedGoodsOrders { get; set; }
    }
}
