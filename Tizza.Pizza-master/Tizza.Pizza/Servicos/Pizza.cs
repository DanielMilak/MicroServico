namespace Tizza
{
    public class Pizza
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Ingredientes { get; set; }

        public int CodigoPizzaria { get; set; }

        public DateTime DataVigenciaPromocao { get; set; }

        public decimal ValorPromocao { get; set; }
    }
}
