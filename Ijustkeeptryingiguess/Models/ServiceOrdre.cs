using System.ComponentModel.DataAnnotations;

namespace Ijustkeeptryingiguess.Models
{
    public class ServiceOrdre
    {   
        public int Id { get; set; }
        public string? Serienummer { get; set; }

        public string? Fornavn { get; set; }
        public string? Etternavn { get; set; }
        public string? Mobil { get; set; }
        public string? Email { get; set; }
        public string? Addresse { get; set; }
        public string? Feil_beskrivelse { get; set; }
        public string? Bestillingsnummer { get; set; }
        public string? Produkttype { get; set; }
        public DateTime? Dato { get; set; }
        public int? Aarsmodell { get; set; }
        public bool Garanti { get; set; }
        public bool Service { get; set; }
        public bool Reparasjon { get; set; }
        public string? Kunde_kommentar { get; set; }
    }
}
