using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace NLW.Models.Database
{
    public class Item
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Title { get; set; }

        public HashSet<PointItems> PointItems { get; set; }

    }
}