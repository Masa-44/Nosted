// Bruker nødvendig Microsoft-namespace
using Microsoft.AspNetCore.Identity;

namespace Ijustkeeptryingiguess.Models
{
    // Definerer en modellklasse for applikasjonsbrukere som utvider IdentityUser
    public class ApplicationUser : IdentityUser
    {
        // Egenskap for å lagre fornavn
        public string Firstname { get; set; }

        // Egenskap for å lagre etternavn
        public string Lastname { get; set; }
    }
}