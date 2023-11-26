// ServiceOrdre representerer modellen for en serviceordre og inneholder egenskaper som lagrer informasjon om en serviceforespørsel.

using System;
using System.ComponentModel.DataAnnotations;

namespace Ijustkeeptryingiguess.Models
{
    public class ServiceOrdre
    {
        // Unik identifikator for serviceordren.
        public int Id { get; set; }

        // Serienummeret til produktet knyttet til serviceordren.
        public string? Serienummer { get; set; }

        // Fornavnet til kunden som plasserte serviceordren.
        public string? Fornavn { get; set; }

        // Etternavnet til kunden som plasserte serviceordren.
        public string? Etternavn { get; set; }

        // Mobilnummeret til kunden som plasserte serviceordren.
        public string? Mobil { get; set; }

        // E-postadressen til kunden som plasserte serviceordren.
        public string? Email { get; set; }

        // Kundens adresse knyttet til serviceordren.
        public string? Addresse { get; set; }

        // Beskrivelse av feilen som krever service.
        public string? Feil_beskrivelse { get; set; }

        // Unikt bestillingsnummer for å identifisere serviceordren.
        public string? Bestillingsnummer { get; set; }

        // Typen produkt som serviceordren gjelder for.
        public string? Produkttype { get; set; }

        // Datoen serviceordren ble registrert.
        public DateTime? Dato { get; set; }

        // Årsmodellen til produktet knyttet til serviceordren.
        public int? Aarsmodell { get; set; }

        // Angir om serviceordren er innenfor garantiperioden.
        public bool Garanti { get; set; }

        // Angir om service er påkrevd for serviceordren.
        public bool Service { get; set; }

        // Angir om reparasjon er påkrevd for serviceordren.
        public bool Reparasjon { get; set; }

        // Eventuelle kommentarer eller beskjeder fra kunden knyttet til serviceordren.
        public string? Kunde_kommentar { get; set; }
    }
}

