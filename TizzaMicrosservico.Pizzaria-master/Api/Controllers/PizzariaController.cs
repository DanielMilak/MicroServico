using Microsoft.AspNetCore.Mvc;
using Tizza.Pizzaria.DTO;
using Tizza.Pizzaria.Servicos;

namespace Tizza.Pizzaria
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzariaController : Controller
    {
        private IServPizzaria _servPizzaria;

        public PizzariaController(IServPizzaria servPizzaria)
        {
            _servPizzaria = servPizzaria;
        }

        [HttpPost]
        public IActionResult Inserir(InserirPizzariaDTO inserirPizzariaDto)
        {
            try
            {
                var pizzaria = new Pizzaria();

                pizzaria.Nome = inserirPizzariaDto.Nome;
                pizzaria.Cnpj = inserirPizzariaDto.Cnpj;
                pizzaria.Endereco = inserirPizzariaDto.Endereco;
                pizzaria.Telefone = inserirPizzariaDto.Telefone;
                pizzaria.NomeContato = inserirPizzariaDto.NomeContato;
                pizzaria.Ativo = true;

                _servPizzaria.Inserir(pizzaria);

                var retornoInsercao = new { CodigoPizzaria = pizzaria.Id };

                return Ok(retornoInsercao);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]/{id}")]
        [HttpPut]
        public IActionResult Editar(int id, EditarPizzariaDTO editarPizzariaDto)
        {
            try
            {
                var pizzaria = _servPizzaria.BuscarPizzaria(id);

                pizzaria.Nome = editarPizzariaDto.Nome;
                pizzaria.Cnpj = editarPizzariaDto.Cnpj;
                pizzaria.Endereco = editarPizzariaDto.Endereco;
                pizzaria.Telefone = editarPizzariaDto.Telefone;
                pizzaria.NomeContato = editarPizzariaDto.NomeContato;
                pizzaria.Ativo = editarPizzariaDto.Ativo;

                _servPizzaria.Editar(pizzaria);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]/{id}")]
        [HttpGet]
        public IActionResult BuscarPizzaria(int id)
        {
            try
            {
                var pizzaria = _servPizzaria.BuscarPizzaria(id);

                return Ok(pizzaria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("/api/[Controller]")]
        [HttpGet]
        public IActionResult BuscarTodos()
        {
            try
            {
                var listaPizzaria = _servPizzaria.BuscarTodos();

                return Ok(listaPizzaria);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
