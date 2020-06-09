using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLW.Models.Database
{
    [Table("pointitems")]
    public class PointItem
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Points))]

        [Column("point_id")]
        public int Point_id { get; set; }
        public Point Points { get; set; }


        [Required]
        [ForeignKey(nameof(Items))]
        public int Item_id { get; set; }

        [Column("item_id")]
        public Item Items { get; set; }


    }
}