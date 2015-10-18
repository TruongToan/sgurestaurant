using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGURestaurant.Models
{
    public class Table
    {
        [DisplayName("Mã số")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [DisplayName("Số ghế")]
        public virtual int ChairNumber { get; set; }

        [DisplayName("Đặc điểm")]
        [DataType(DataType.MultilineText)]
        public virtual string Feature { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}