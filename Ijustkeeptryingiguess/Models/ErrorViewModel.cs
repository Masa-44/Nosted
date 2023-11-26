// CheckListViewModel representerer modellen for sjekklisten og inneholder egenskaper for � lagre sjekkpunktene.

namespace Ijustkeeptryingiguess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CheckListViewModel
    {
        // Serienummeret som sjekklisten gjelder. P�krevd felt med tilh�rende feilmelding.
        [Required(ErrorMessage = "Serie nr er p�krevd")]
        public string SerialNumber { get; set; }

        // Typen enhet som sjekklisten gjelder. P�krevd felt med tilh�rende feilmelding.
        [Required(ErrorMessage = "Type er p�krevd")]
        public string Type { get; set; }

        // Status for sjekkpunktet "Sjekk clutch lameller for slitasje".
        public string ClutchLamellStatus { get; set; }

        // Status for sjekkpunktet "Sjekk bremser. B�nd/Pal".
        public string BremserStatus { get; set; }

        // Status for sjekkpunktet "Sjekk lager for trommel".
        public string TrommelLagerStatus { get; set; }

        // Status for sjekkpunktet "Sjekk PTO og opplagring".
        public string PTOStatus { get; set; }

        // Status for sjekkpunktet "Sjekk kjedestrammer".
        public string KjedestrammerStatus { get; set; }

        // Status for sjekkpunktet "Sjekk wire".
        public string WireStatus { get; set; }

        // Status for sjekkpunktet "Sjekk pinion lager".
        public string PinionLagerStatus { get; set; }

        // Status for sjekkpunktet "Sjekk kile p� kjedehjul".
        public string KileStatus { get; set; }
    }

    // ErrorViewModel brukes til � h�ndtere feil og vise feilmeldinger.
    public class ErrorViewModel
    {
        // Unik foresp�rsels-ID for � identifisere feilen.
        public string? RequestId { get; set; }

        // Angir om foresp�rselen har en gyldig foresp�rsels-ID for � vise feilmeldinger.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}