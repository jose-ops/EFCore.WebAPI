using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        public readonly HeroiContext _context;
        public ValuesController(HeroiContext context)
        {
            _context = context;
        }
        private readonly ILogger<ValuesController> _logger;


        [HttpGet]
        public ActionResult Get()
        {
            //var listHerois = _context.Herois.ToList();
            var listHerois = (from heroi in _context.Herois 
                              select heroi).ToList();
            return Ok(listHerois);
        }

        //GET api/values/5
        [HttpGet("{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            var heroi = new Heroi { Nome = nameHero };

            _context.Herois.Add(heroi);
            _context.SaveChanges();
            return Ok();
        }
    }
}