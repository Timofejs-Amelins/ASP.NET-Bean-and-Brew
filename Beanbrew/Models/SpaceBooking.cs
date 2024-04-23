using System;
using System.ComponentModel.DataAnnotations;

namespace Beanbrew.Models
{
    public class SpaceBooking
    {
        [Key]
        public int SpaceBookingId { get; set; }
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public DateTime TimeSlot { get; set; }

        public virtual Customer Customers { get; set; }
        public virtual Restaurant Restaurants { get; set; }
    }
}
