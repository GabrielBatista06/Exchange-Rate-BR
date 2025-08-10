using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ExchangeRate.Persistence.Repositories
{
    public class Api2Repository : IObtenerRemesaRepository
    {
        public async Task<decimal?> ObtenerMejorOferta(RQProcessDTO rQProcessDTO)
        {
            // Simula entrada XML
            var xmlInput = new XElement("XML",
                new XElement("From", rQProcessDTO.SourceCurrency),
                new XElement("To", rQProcessDTO.TargetCurrency),
                new XElement("Amount", rQProcessDTO.Amount)
            );

            // Simula salida XML: <Result>1.08</Result>
            var xmlOutput = new XElement("XML", new XElement("Result", 1.08m));

            var rate = decimal.Parse(xmlOutput.Element("Result")!.Value);
            return rate * rQProcessDTO.Amount;

        }
    }
}
