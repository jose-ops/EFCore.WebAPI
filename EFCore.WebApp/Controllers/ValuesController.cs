using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;

namespace EFCore.WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        
        private readonly ILogger<ValuesController> _logger;

        public ValuesController(ILogger<ValuesController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var heroi = new Heroi { Nome = "Homo de Ferra"};
            using (var contexto = new HeroiContext())
            {
                contexto.Herois.Add(heroi);
                contexto.SaveChanges();
            }
            return Ok();
        }
    }
}