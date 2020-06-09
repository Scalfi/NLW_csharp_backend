using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace NLW.Models.Database
{
    public class Point
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Whatsapp { get; set; }

        [Required]
        public decimal Latidude { get; set; }

        [Required]
        public decimal Longitude { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Uf { get; set; }

        public HashSet<PointItems> PointItems { get; set; }
        
        [NotMapped]
        [JsonIgnore]
        public List<int> IntesId { get; set; }


    }
}