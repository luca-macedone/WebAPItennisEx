using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAPItennisEx.DTOs
{
    public class PlayerDTO
    {
        [Required]
        public int Player_id { get; set; }
        
        [Required]
        public string Name_first { get; set; }

        [Required]
        public string Name_last { get; set; }

        [Required]
        public string Hand { get; set; }

        [MaybeNull]
        public int? Dob { get; set; }

        [Required]
        public string Ioc { get; set; }

        [MaybeNull]
        public int? Height { get; set; }

        [Required]
        public string Wikidata_id { get; set; }
    }
}
