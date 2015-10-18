using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace SGURestaurant.Models
{
    public class Booking
    {
        [DisplayName("Mã số")]
        public virtual int Id { get; set; }

        [DisplayName("Thời gian")]
        public virtual DateTime Time { get; set; }

        [DisplayName("Trạng thái")]
        public virtual bool Status { get; set; }

        public virtual int TableId { get; set; }

        [DisplayName("Bàn")]
        public virtual Table Table { get; set; }

        [DisplayName("Chi tiết")]
        public virtual ICollection<BookingDetail> BookingDetails { get; set; }
        
        public virtual string UserId { get; set; }

        [DisplayName("Khách hàng")]
        public virtual ApplicationUser User { get; set; }
    }
}