using KnightsChallenge.Core.Entitys;
using KnightsChallenge.Core.Models;
using KnightsChallenge.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace KnightsChallenge.API.Controllers
{
    [Route("[controller]")]
    public class KnightController : Controller
    {
        private readonly KnightService _knightService;
        private readonly HallOfHeroesService _hallOfHeroesService;

        public KnightController(KnightService booksService, HallOfHeroesService hallOfHeroesService)
        { 
            _knightService = booksService;
            _hallOfHeroesService = hallOfHeroesService;
        }



        [HttpGet]
        public async Task<ActionResult> ListarKnights(string? filter)
        {
            List<Knight> knights;
            if (filter == "heroes")
                knights = await _hallOfHeroesService.GetAsync();
            else
                knights = await _knightService.GetAsync();

            List<KnightDTO> knightsDto = new List<KnightDTO>();
            knights.ForEach(e => knightsDto.Add(e.ToDTO()));

            return new OkObjectResult(knightsDto);
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

                return new CreatedAtRouteResult($"", null);
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpPut("{id}")]
        public ActionResult AlterarKnight([FromBody] Knight knight, string id)
        {
            try
            {
                _knightService.UpdateAsync(id, knight).Wait();

                return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletarKnight(string id)
        {
            try
            {
                Knight heroe = await _knightService.GetAsync(id);
                if (heroe == null)
                    return new NotFoundResult();

                _knightService.RemoveAsync(id).Wait();

                // Eterniza como heroi
                _hallOfHeroesService.CreateAsync(heroe).Wait();

                return new OkResult();
            }
            catch (Exception)
            {
                return new BadRequestResult();
            }
        }
    }
}
