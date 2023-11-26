// CheckListViewModel representerer modellen for sjekklisten og inneholder egenskaper for å lagre sjekkpunktene.

namespace Ijustkeeptryingiguess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CheckListViewModel
    {
        // Serienummeret som sjekklisten gjelder. Påkrevd felt med tilhørende feilmelding.
        [Required(ErrorMessage = "Serie nr er påkrevd")]
        public string SerialNumber { get; set; }

        // Typen enhet som sjekklisten gjelder. Påkrevd felt med tilhørende feilmelding.
        [Required(ErrorMessage = "Type er påkrevd")]
        public string Type { get; set; }

        // Status for sjekkpunktet "Sjekk clutch lameller for slitasje".
        public string ClutchLamellStatus { get; set; }

        // Status for sjekkpunktet "Sjekk bremser. Bånd/Pal".
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

        // Status for sjekkpunktet "Sjekk kile på kjedehjul".
        public string KileStatus { get; set; }
    }

    // ErrorViewModel brukes til å håndtere feil og vise feilmeldinger.
    public class ErrorViewModel
    {
        // Unik forespørsels-ID for å identifisere feilen.
        public string? RequestId { get; set; }

        // Angir om forespørselen har en gyldig forespørsels-ID for å vise feilmeldinger.
        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}