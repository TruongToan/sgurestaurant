using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGURestaurant.Models
{
    public class Table
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }
        
        public virtual int ChairNumber { get; set; }
        
        [DataType(DataType.MultilineText)]
        public virtual string Feature { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }
    }
}