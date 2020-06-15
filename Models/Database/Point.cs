using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NLW.Models.Database
{
    [Table("points")]
    public class Point
    {
        [Column("id")]
        [Key]
        public int Id { get; set; }
       
        [Column("image")]
        [Required]
        public string Image { get; set; }
        
        [Column("name")]
        [Required]
        public string Name { get; set; }

        [Column("email")]
        [Required]
        public string Email { get; set; }

        [Column("whatsapp")]
        [Required]
        public string Whatsapp { get; set; }

        [Column("latidude")]
        [Required]
        public decimal Latidude { get; set; }

        [Column("longitude")]
        [Required]
        public decimal Longitude { get; set; }

        [Column("city")]
        [Required]
        public string City { get; set; }

        [Column("uf")]
        [Required]
        public string Uf { get; set; }

        public HashSet<PointItem> PointItems { get; set; }
        
        [NotMapped]
        public List<int> IntesId { get; set; }


    }
}