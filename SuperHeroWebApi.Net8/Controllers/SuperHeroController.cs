using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SuperHeroWebApi.Net8.Data;
using SuperHeroWebApi.Net8.Entities;

namespace SuperHeroWebApi.Net8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        private readonly DataContext context;
        public SuperHeroController(DataContext context) {  this.context = context; }
         
        [HttpGet]
        public async Task<ActionResult<List<SuperHero>>> GetAllHeros()
        {
            var heroes = await context.superHeroes.ToListAsync();
                
            return Ok(heroes);


        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<SuperHero>>> GetHero(int id)
        {
            var hero = await context.superHeroes.FindAsync(id);

            if (hero is null)
            {
                return BadRequest("Hero not found");  
            }


            return Ok(hero);


        }


        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddHero(SuperHero hero)
        {
             context.superHeroes.Add(hero);
            await context.SaveChangesAsync();

            


            return Ok(await context.superHeroes.ToListAsync());


        }

        [HttpPut]
        public async Task<ActionResult<List<SuperHero>>> UpdateHero(SuperHero UpdatedHero)
        {
            var dhHero = await context.superHeroes.FindAsync(UpdatedHero.Id);

            if (dhHero is null)
                return BadRequest("Hero not found");

            dhHero.Name= UpdatedHero.Name;
            dhHero.FirstName= UpdatedHero.FirstName;
            dhHero.LastName= UpdatedHero.LastName;
            dhHero.Place= UpdatedHero.Place;

            await context.SaveChangesAsync();


            return Ok(await context.superHeroes.ToListAsync());


        }

        [HttpDelete]
        public async Task<ActionResult<List<SuperHero>>> DeleteHero(int id)
        {
            var dhHero = await context.superHeroes.FindAsync(id);

            if (dhHero is null)
                return BadRequest("Hero not found");

            context.superHeroes.Remove(dhHero);

          
            await context.SaveChangesAsync();


            return Ok(await context.superHeroes.ToListAsync());


        }
    }
}
