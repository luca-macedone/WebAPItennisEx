using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace WebAPItennisEx.DTOs.Requests
{
    public class CreatePlayerRequest
    {
        [Required, MaybeNull]
        public string name_first { get; set; }

        [Required, MaybeNull]
        public string name_last { get; set; }

        [MaybeNull]
        public string hand { get; set; }

        [MaybeNull]
        public int? dob { get; set; }

        [MaybeNull]
        public string ioc { get; set; }

        [MaybeNull]
        public int? height { get; set; }

        [MaybeNull]
        public string wikidata_id { get; set; }
    }
}
