using EFCore.WebApp.Model;

namespace EFCore.WebApp.Data
{
    public class HeroiBatalha
    {
        public int HeroId { get; set; }
        public Heroi Heroi { get; set; }

        public int BatalhaId { get; set; }
        public Batalha Batalha { get; set; }

    }
}
