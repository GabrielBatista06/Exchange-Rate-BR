using System.ComponentModel.DataAnnotations;

namespace ExchangeRate.DTOs
{
    public class RQProcessDTO
    {
        [Required(ErrorMessage = "El campo 'SourceCurrency' es obligatorio.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El campo 'SourceCurrency' debe tener exactamente 3 caracteres.")]
        public string SourceCurrency { get; set; }
        [Required(ErrorMessage = "El campo 'TargetCurrency' es obligatorio.")]
        [StringLength(3, MinimumLength = 3, ErrorMessage = "El campo 'TargetCurrency' debe tener exactamente 3 caracteres.")]
        public string TargetCurrency { get; set; }
        [Required(ErrorMessage = "El campo 'Amount' es obligatorio.")]
        public decimal Amount { get; set; }
    }
}
