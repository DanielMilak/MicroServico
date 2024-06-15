namespace Tizza
{
    public class MovimentacaoCaixa
    {
        public int Id { get; set; }

        public DateTime DataMovimento { get; set; }

        public EnumTipoDeMovimento TipoDeMovimento { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public EnumTipoVinculo TipoVinculo { get; set; }

        public int? CodigoVinculacao { get; set; }
    }

    public enum EnumTipoDeMovimento
    {
        Entrada = 1,
        Saida = 2
    }

    public enum EnumTipoVinculo
    { 
        SemVinculo = 1
    }
}
