using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using ExchangeRate.Utils;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExchangeRate.Persistence.Repositories
{
    public class Api2Repository : IObtenerRemesaRepository
    {
        //Estoy utilizando método async para simular EF (Entity Framework)
        public async Task<RSProcessDTO> ObtenerMejorOferta(RQProcessDTO rQProcessDTO)
        {

            ExchangeRateRandom exchangeRateRandom = new ExchangeRateRandom();
            var valor = exchangeRateRandom.GenerarNumeroRandom();

            var xmlInput = new XElement("XML",
                new XElement("From", rQProcessDTO.SourceCurrency),
                new XElement("To", rQProcessDTO.TargetCurrency),
                new XElement("Amount", rQProcessDTO.Amount)
            );

            var xmlOutput = new XElement("XML", new XElement("Result", valor * rQProcessDTO.Amount));
            var rate = decimal.Parse(xmlOutput.Element("Result")!.Value) ;

            return new RSProcessDTO
            {
                Amount = rate * rQProcessDTO.Amount,
                ContenidoOriginal = xmlOutput.ToString(),
                Formato = "XML"
            };

        }
    }
}
