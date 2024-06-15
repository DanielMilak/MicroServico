namespace Tizza
{
    public interface IServMovimentacaoCaixa
    {
        void InserirMovimentoDeEntrada(InserirMovimentaoCaixaDTO inserirDto);
        void InserirMovimentoDeSaida(InserirMovimentaoCaixaDTO inserirDto);
        List<MovimentacaoCaixa> ListarMovimentacaoDeCaixa(DateTime dataInicial, DateTime dataFinal);
    }

    public class ServMovimentacaoCaixa : IServMovimentacaoCaixa
    {
        public DataContext _dataContext { get; set; }

        public ServMovimentacaoCaixa(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void InserirMovimentoDeEntrada(InserirMovimentaoCaixaDTO inserirDto)
        {
            var movimentacaoCaixa = new MovimentacaoCaixa()
            {
                DataMovimento = inserirDto.DataMovimento,
                Descricao = inserirDto.Descricao,
                TipoDeMovimento = EnumTipoDeMovimento.Entrada,
                Valor = inserirDto.Valor
            };

            _dataContext.Add(movimentacaoCaixa);
            _dataContext.SaveChanges();
        }

        public void InserirMovimentoDeSaida(InserirMovimentaoCaixaDTO inserirDto)
        {
            var movimentacaoCaixa = new MovimentacaoCaixa()
            {
                DataMovimento = inserirDto.DataMovimento,
                Descricao = inserirDto.Descricao,
                TipoDeMovimento = EnumTipoDeMovimento.Saida,
                Valor = inserirDto.Valor
            };

            _dataContext.Add(movimentacaoCaixa);
            _dataContext.SaveChanges();
        }

        public List<MovimentacaoCaixa> ListarMovimentacaoDeCaixa(DateTime dataInicial, DateTime dataFinal)
        {
            var movimentacao = _dataContext.MovimentacoesCaixa.Where(p => p.DataMovimento >= dataInicial && p.DataMovimento <= dataFinal).ToList();

            return movimentacao;
        }
    }
}
