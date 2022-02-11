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
                return BadRequest("Hero not found.");
            }

            return Ok(hero);
        }

        [HttpPost(Name = "AddHero")]
        public async Task<ActionResult<int>> AddHero(SuperHero hero)
        {
            heroes.Add(hero);

            return Ok(hero.Id);
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = heroes.FirstOrDefault(x => x.Id == request.Id);

            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }

            hero.Name = request.Name;
            hero.Place = request.Place;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;

            return Ok(hero);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = heroes.FirstOrDefault(x => x.Id == id);

            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }

            heroes.Remove(hero);

            return Ok(heroes);
        }
    }
}
