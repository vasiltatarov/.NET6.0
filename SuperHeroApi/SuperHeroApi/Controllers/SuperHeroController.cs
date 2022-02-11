namespace SuperHeroApi.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;
    using SuperHeroApi.Data;
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
        private readonly DataContext context;

        public SuperHeroController(DataContext context)
        {
            this.context = context;
        }

        [HttpGet(Name = "GetSuperHeroes")]
        public async Task<ActionResult<List<SuperHero>>> Get()
        {
            return Ok(await this.context.SuperHeroes.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<SuperHero>> GetById(int id)
        {
            var hero = await this.context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }

            return Ok(hero);
        }

        [HttpPost(Name = "AddHero")]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
            await this.context.SuperHeroes.AddAsync(hero);
            await this.context.SaveChangesAsync();

            return Ok(await this.context.SuperHeroes.ToListAsync());
        }

        [HttpPut]
        public async Task<ActionResult<SuperHero>> UpdateHero(SuperHero request)
        {
            var hero = await this.context.SuperHeroes.FindAsync(request.Id);

            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }

            hero.Name = request.Name;
            hero.Place = request.Place;
            hero.FirstName = request.FirstName;
            hero.LastName = request.LastName;

            await this.context.SaveChangesAsync();

            return Ok(await this.context.SuperHeroes.ToListAsync());
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var hero = await this.context.SuperHeroes.FindAsync(id);

            if (hero == null)
            {
                return BadRequest("Hero not found.");
            }

            this.context.Remove(hero);
            await this.context.SaveChangesAsync();

            return Ok(await this.context.SuperHeroes.ToListAsync());
        }
    }
}
