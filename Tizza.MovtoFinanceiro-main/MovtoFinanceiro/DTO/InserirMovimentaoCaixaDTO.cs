namespace Tizza
{
    public class InserirMovimentaoCaixaDTO
    {
        public DateTime DataMovimento { get; set; }

        public string Descricao { get; set; }

        public decimal Valor { get; set; }

        public EnumTipoVinculo TipoVinculo { get; set; }

        public int? CodigoVinculacao { get; set; }
    }
}
