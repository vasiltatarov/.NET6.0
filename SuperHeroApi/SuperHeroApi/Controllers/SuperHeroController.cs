namespace SuperHeroApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using SuperHeroApi.Models;

    [ApiController]
    [Route("[controller]")]
    public class SuperHeroController : ControllerBase
    {
        private static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero
            {
                Id = 1,
                Name = "Vasko",
                Place = "Chakalo"
            },
            new SuperHero
            {
                Id = 2,
                Name = "Sali",
                Place = "Chakalo"
            },
        };

        [HttpGet(Name = "GetSuperHeroes")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id)
        {
            var hero = heroes.FirstOrDefault(x => x.Id == id);

            if (hero == null)
            {
                return NotFound();
            }

            return Ok(hero);
        }

        [HttpPost(Name = "AddHero")]
        public async Task<ActionResult<int>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);

            return Ok(hero.Id);
        }
    }
}
