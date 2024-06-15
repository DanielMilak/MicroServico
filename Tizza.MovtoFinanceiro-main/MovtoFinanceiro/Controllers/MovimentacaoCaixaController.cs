using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using MovtoFinanceiro.Infra;

namespace Tizza
{
    [ApiController]
    [Route("[Controller]")]
    public class MovimentacaoCaixaController : ControllerBase
    {
        public IServMovimentacaoCaixa _servMovimentacaoCaixa {  get; set; }

        public MovimentacaoCaixaController(IServMovimentacaoCaixa servMovimentacaoCaixa)
        {

            _servMovimentacaoCaixa = servMovimentacaoCaixa;
        }

        [Route("/api/[Controller]/InserirMovimentoDeEntrada")]
        [HttpPost]
        public IActionResult InserirMovimentoDeEntrada(InserirMovimentaoCaixaDTO inserirMovimentoCaixaDto)
        {
            try
            {
                _servMovimentacaoCaixa.InserirMovimentoDeEntrada(inserirMovimentoCaixaDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]/InserirMovimentoDeSaida")]
        [HttpPost]
        public IActionResult InserirMovimentoDeSaida(InserirMovimentaoCaixaDTO inserirMovimentoCaixaDto)
        {
            try
            {
                _servMovimentacaoCaixa.InserirMovimentoDeSaida(inserirMovimentoCaixaDto);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]/ListarMovimentacaoDeCaixa/{dataInicial}/{dataFinal}")]
        [HttpGet]
        public IActionResult ListarMovimentacaoDeCaixa(DateTime dataInicial, DateTime dataFinal)
        {
            try
            {
                PublishFilaHello.PublicarFilaHello();

                var movimentacoes = _servMovimentacaoCaixa.ListarMovimentacaoDeCaixa(dataInicial, dataFinal);

                return Ok(movimentacoes);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
