namespace ExchangeRate.DTOs
{
    public class RQProcessDTO
    {
        public string SourceCurrency { get; set; }
        public string TargetCurrency { get; set; }
        public decimal Amount { get; set; }
    }
}
