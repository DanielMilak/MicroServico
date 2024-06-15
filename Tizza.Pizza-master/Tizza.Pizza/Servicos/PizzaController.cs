using Microsoft.AspNetCore.Mvc;
using Pizzas;

namespace Tizza
{
    [ApiController]
    [Route("[controller]")]
    public class PizzaController : ControllerBase
    {
        private IServPizza _servPizza;

        public PizzaController(IServPizza servPizza)
        {
            _servPizza = servPizza;
        }

        [HttpPost]
        public ActionResult Inserir([FromBody] InserirPizzaDTO inserirDto)
        {
            try
            {
                _servPizza.Inserir(inserirDto);

                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/[controller]/{id}")]
        [HttpGet]
        public ActionResult BuscarPizza(int id)
        {
            try
            {
                var pizza = _servPizza.BuscarPizza(id);

                return Ok(pizza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/[controller]")]
        [HttpGet]
        public ActionResult BuscarTodas()
        {
            try
            {
                var listaPizza = _servPizza.BuscarTodas();

                return Ok(listaPizza);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Route("/api/[controller]/InformarPromocaoPizza/{codigoPizza}")]
        [HttpPost()]
        public ActionResult InformarPromocaoPizza(int codigoPizza, [FromBody] InformarPromocaoPizzaDTO informarPromocaoPizzaDto)
        {
            try
            {
                _servPizza.InformarPromocaoPizza(codigoPizza, informarPromocaoPizzaDto);

                return Ok("Ok");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
