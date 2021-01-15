using System.Threading.Tasks;
using InterestRate.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Softplan.InterestRateAPI.Controllers
{
    [ApiController]
    [Route("taxaJuros")]
    public class TaxaJurosController : ControllerBase
    {
        private readonly ITaxaJurosServices _taxaJurosServices;

        public TaxaJurosController(ITaxaJurosServices taxaJurosServices)
        {
            _taxaJurosServices = taxaJurosServices;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var taxaJuros = await _taxaJurosServices.GetTaxaJuros();

            return Ok(taxaJuros);
        }
    }
}