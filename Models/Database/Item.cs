using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NLW.Models.Database
{
    [Table("items")]
    public class Item
    {
        [Column("id")]
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("image")]
        [Required]
        public string Image { get; set; }

        [Column("title")]
        [Required]
        public string Title { get; set; }

        public HashSet<PointItem> PointItems { get; set; }
    }
}