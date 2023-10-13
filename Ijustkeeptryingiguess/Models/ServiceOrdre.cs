using System.ComponentModel.DataAnnotations;

namespace Ijustkeeptryingiguess.Models
{
    public class ServiceOrdre
    {
        public string? serienummer { get; set; }

        public string? fornavn { get; set; }
        public string? etternavn { get; set; }
        public string? mobil { get; set; }
        public string? email { get; set; }
        public string? addresse { get; set; }
        public string? feil_beskrivelse { get; set; }
        public string? bestillingsnummer { get; set; }
        public string? produkttype { get; set; }
        public DateTime? dato { get; set; }
        public int? aarsmodell { get; set; }
        public bool? Garanti { get; set; }
        public bool? Service { get; set; }
        public bool? Reparasjon { get; set; }
        public string? kunde_kommentar { get; set; }
    }
}
