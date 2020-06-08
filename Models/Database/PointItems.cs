using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLW.Models.Database
{
    public class PointItems
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey(nameof(Points))]

        public int Point_id { get; set; }
        public Point Points { get; set; }


        [Required]
        [ForeignKey(nameof(Items))]
        public int Item_id { get; set; }

        public Item Items { get; set; }


    }
}