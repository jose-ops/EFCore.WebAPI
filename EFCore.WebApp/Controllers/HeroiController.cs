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
        // GET: api/<ValuesController1>
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {

                return BadRequest($"Erro: {ex}");
            }
            
        }

        // GET api/<ValuesController1>/5
        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            return Ok("value");
        }

        // POST api/<ValuesController1>
        [HttpPost]
        public ActionResult Post()
        {
            try
            {
                var heroi = new Heroi//relacionamemteo 1 pra muitos
                {
                    Nome = "Homem de Ferro",
                    Armas = new List<Arma>
                    {
                        new Arma{ Nome = "MAC 3" },
                        new Arma{ Nome = "MAC 5"},
                    }
                };

                _context.Herois.Add(heroi);
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
        public ActionResult Put(int id)
        {
            try
            {
                var heroi = new Heroi
                {
                    Id = id,
                    Nome = "Homem De Ferro",
                    Armas = new List<Arma>
                    {
                        new Arma{ Id = 1, Nome = "MARK IV" },
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
