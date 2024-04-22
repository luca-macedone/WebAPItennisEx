using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAPItennisEx.DTOs
{
    public class PlayerDTO
    {
        [Required]
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
