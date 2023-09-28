using EFCore.Dominio;
using EFCore.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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


        [HttpGet("filtro/{nome}")]
        public ActionResult GetFiltro(string nome)
        {
            var listHerois = _context.Herois
                .Where(h => EF.Functions.Like(h.Nome, $"%{nome}%"))
                .OrderByDescending(h => h.Id)
                 .FirstOrDefault();//primeiro ou o deafult
                 //.SingleOrDefault();//se tiver dois ou maias igual levanta Exception
                 //.LastOrDefault();// ultimo da lista 

            //var listHerois = (from heroi in _context.Herois
            //                  where heroi.Nome.Contains(nome)
            //                  select heroi).ToList();     //faz mesma coisa mas diferentemente da de cima 
            return Ok(listHerois);
        }

        //GET api/values/5
        [HttpGet("Atualizar/{nameHero}")]
        public ActionResult Get(string nameHero)
        {
            //var heroi = new Heroi { Nome = nameHero };

            var heroi = _context.Herois
                .Where(h => h.Id == 1)
                .FirstOrDefault();
            heroi.Nome = "Homem De Ferro";
            //_context.Herois.Add(heroi);
            _context.SaveChanges();

            return Ok();
        }

        [HttpGet("AddRange")]
        public ActionResult GetAddRange()
        {
            //var heroi = new Heroi { Nome = nameHero };

            _context.AddRange(
                new Heroi { Nome = "Capitap America"},
                new Heroi { Nome = "Doutor Estranho" },
                new Heroi { Nome = "Pantera Negra" },
                new Heroi { Nome = "Viuva Negra" },
                new Heroi { Nome = "Hulk" },
                new Heroi { Nome = "Gaviao Arqueiro" },
                new Heroi { Nome = "Capita Marvel" }
                );
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var heroi = _context.Herois
                                .Where(x => x.Id == id)
                                .Single();
            _context.Herois.Remove(heroi);
            _context.SaveChanges();
        }
    }
}