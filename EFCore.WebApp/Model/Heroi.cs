using EFCore.WebApp.Data;

namespace EFCore.WebApp.Model
{
    public class Heroi
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public IdentidadeSecreta Identidade { get; set; }
        public List<Arma> Armas { get; set; }
        public List<HeroiBatalha> HeroiBatalhas { get; set; }
    }
}
