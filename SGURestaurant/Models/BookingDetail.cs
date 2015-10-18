using System.ComponentModel;

namespace SGURestaurant.Models
{
    public class BookingDetail
    {
        [DisplayName("Mã số")]
        public virtual int Id { get; set; }

        [DisplayName("Món ăn")]
        public virtual Meal Meal { get; set; }

        [DisplayName("Số lượng")]
        public virtual int Number { get; set; }

        public virtual int BookingId { get; set; }

        public virtual Booking Booking { get; set; }
    }
}