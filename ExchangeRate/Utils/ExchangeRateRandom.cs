using System;

namespace ExchangeRate.Utils
{
    public class ExchangeRateRandom
    {
        public decimal GenerarNumeroRandom()
        {
            Random rnd = new Random();
            double valor = rnd.NextDouble() * (100 - 50) + 50;
            return (decimal)valor;
        }
    }
}
