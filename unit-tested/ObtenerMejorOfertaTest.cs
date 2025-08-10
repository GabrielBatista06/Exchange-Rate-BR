using ExchangeRate.Controllers;
using ExchangeRate.Domain.IRepositories;
using ExchangeRate.DTOs;
using ExchangeRate.Services;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace unit_tested
{
    public class ObtenerMejorOfertaTest
    {
        private readonly ObtenerMejorOfertaService _service;
        private readonly BestDealController _controller;

        public ObtenerMejorOfertaTest()
        {
            var mockRepo = new Mock<IObtenerRemesaRepository>();

            mockRepo.Setup(r => r.ObtenerMejorOferta(It.IsAny<RQProcessDTO>()))
                      .ReturnsAsync(new RSProcessDTO
                      {
                          Amount = 55.5m,
                          ContenidoOriginal = "{rate:55.5}",
                          Formato = "JSON"
                      });

            var repos = new List<IObtenerRemesaRepository> { mockRepo.Object };

            var mockLog = new Mock<ILogger<ObtenerMejorOfertaService>>();

            _service = new ObtenerMejorOfertaService(repos, mockLog.Object);

            _controller = new BestDealController(_service);
        }

        [Fact]
        public async Task ObtenerMejorOfertaTets()
        {
            var request = new RQProcessDTO
            {
                SourceCurrency = "USD",
                TargetCurrency = "DOP",
                Amount = 100
            };

            var result = await _controller.GetBestOffer(request);

            Assert.NotNull(result);
        }
    }

}

