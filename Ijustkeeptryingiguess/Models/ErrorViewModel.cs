namespace Ijustkeeptryingiguess.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CheckListViewModel
    {
        [Required(ErrorMessage = "Serie nr er påkrevd")]
        public string SerialNumber { get; set; }

        [Required(ErrorMessage = "Type er påkrevd")]
        public string Type { get; set; }

        public string ClutchLamellStatus { get; set; }
        public string BremserStatus { get; set; }
        public string TrommelLagerStatus { get; set; }
        public string PTOStatus { get; set; }
        public string KjedestrammerStatus { get; set; }
        public string WireStatus { get; set; }
        public string PinionLagerStatus { get; set; }
        public string KileStatus { get; set; }
    }

    public class ErrorViewModel
    {
        public string? RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}