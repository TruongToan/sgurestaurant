using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SGURestaurant.Models
{
    public class MealType
    {
        [DisplayName("Mã số")]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public virtual int Id { get; set; }

        [DisplayName("Tên loại")]
        public virtual string Name { get; set; }

        [DisplayName("Mô tả")]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        public virtual ICollection<Meal> Meals { get; set; }
    }
}