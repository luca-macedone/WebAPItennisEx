using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace WebAPItennisEx.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int player_id { get; set; }
        
        [Required]
        public string name_first { get; set; }
        
        [Required]
        public string name_last { get; set; }

        [Required]
        public string hand { get; set; }

        [MaybeNull]
        public int? dob { get; set; }

        [Required]
        public string ioc { get; set; }

        [MaybeNull]
        public int? height { get; set; }

        [Required]
        public string wikidata_id { get; set; }
    }
}
