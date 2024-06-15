namespace Tizza
{
    public class PizzaView
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public string Ingredientes { get; set; }

        public int CodigoPizzaria { get; set; }

        public PizzariaDTO Pizzaria { get; set; }
    }
}
