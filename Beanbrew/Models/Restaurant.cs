using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Beanbrew.Models
{
    public class Restaurant
    {
        [Key]
        public int RestaurantId { get; set; }
        public string RestaurantName { get; set; }
        public virtual ICollection<SpaceBooking> SpaceBookings { get; set; }
    }
}
