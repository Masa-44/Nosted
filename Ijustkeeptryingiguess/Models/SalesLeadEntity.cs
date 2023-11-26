// SalesLeadEntity representerer modellen for en salgslidelse og inneholder egenskaper som lagrer informasjon om en potensiell kunde.

namespace Ijustkeeptryingiguess.Models
{
    public class SalesLeadEntity
    {
        // Unik identifikator for salgslidelsen.
        public int Id { get; set; }

        // Fornavnet til den potensielle kunden.
        public string FirstName { get; set; }

        // Etternavnet til den potensielle kunden.
        public string LastName { get; set; }

        // Mobilnummeret til den potensielle kunden.
        public string Mobile { get; set; }

        // E-postadressen.
        public string Email { get; set; }

        // Kilden som indikerer hvor salgslidelsen ble generert eller oppdaget.
        public string Source { get; set; }
    }
}

