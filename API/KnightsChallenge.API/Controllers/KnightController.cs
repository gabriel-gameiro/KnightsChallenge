using KnightsChallenge.Core.Entitys;
using KnightsChallenge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KnightsChallenge.API.Controllers
{
    [Route("[controller]")]
    public class KnightController : Controller
    {
        private readonly KnightService _knightService;

        public KnightController(KnightService booksService) =>
            _knightService = booksService;


        [HttpGet]
        public async Task<ActionResult<List<Knight>>> ListarKnights(string? filter)
        {
            var knights = await _knightService.GetAsync();

            return knights;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Knight>> ObterKnight(string id)
        {
            try
            {
                var knight = await _knightService.GetAsync(id);

                if (knight is null)
                {
                    return NotFound();
                }

                return knight;
            }
            catch (ApplicationException ex)
            {
                return new BadRequestObjectResult(ex);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPost]
        public ActionResult CriarKnight([FromBody] Knight knight)
        {
            try
            {
                _knightService.CreateAsync(knight).Wait();

                return new CreatedAtRouteResult("", null);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
