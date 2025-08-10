using System.ComponentModel.DataAnnotations;

namespace ExchangeRate.DTOs
{
    public class RQProcessDTO
    {
        [Required (ErrorMessage = "El campo 'SourceCurrency' es obligatorio y debe tener exactamente 3 caracteres."), MinLength(3),MaxLength(3)]
        public string SourceCurrency { get; set; }
        [Required(ErrorMessage = "El campo 'TargetCurrency' es obligatorio y debe tener exactamente 3 caracteres."), MinLength(3), MaxLength(3)]
        public string TargetCurrency { get; set; }
        [Required (ErrorMessage = "El campo 'Amount' es obligatorio.")]
        public decimal Amount { get; set; }
    }
}
