using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EFCore.WebApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HeroiController : ControllerBase
    {
        private readonly HeroiContext _context;

        public HeroiController(HeroiContext context)
        {
            _context = context;
        }
        // GET: api/Heroi
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok(new Heroi());
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
            
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public ActionResult Post(Heroi model)
        {
            try
            {
                _context.Herois.Add(model);
                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // PUT api/<ValuesController1>/5
        [HttpPut("{id}")]
        public ActionResult Put(int id) //insert dados relacionais
        {
            try
            {
                var heroi = new Heroi
                {
                    Id = id,
                    Nome = "Homem de Ferro",
                    Armas = new List<Arma>
                    {
                        new Arma{ Id = 1, Nome = "MARK Iv" },
                        new Arma{ Id = 2, Nome = "MARK VIII"},
                    }
                };

                _context.Update(heroi);
                _context.SaveChanges();

                return Ok("BAZINGA");
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
        }

        // DELETE api/<ValuesController1>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
