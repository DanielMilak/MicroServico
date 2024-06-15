using Pizzas;
using System.Data;
using System.Reflection.Metadata.Ecma335;
using static System.Net.WebRequestMethods;

namespace Tizza
{
    public interface IServPizza
    {
        void Inserir(InserirPizzaDTO inserirPizzariaDto);
        PizzaView BuscarPizza(int id);
        List<Pizza> BuscarTodas();

        void InformarPromocaoPizza(int codigoPizza, InformarPromocaoPizzaDTO informarPromocaoPizzaDto);
    }

    public class ServPizza : IServPizza
    {
        public DataContext _dataContext;
        private IPizzariaHelper _pizzariaHelper;

        public ServPizza(DataContext dataContext, IPizzariaHelper pizzariaHelper)
        {
            _dataContext = dataContext;
            _pizzariaHelper = pizzariaHelper;
        }

        public void Inserir(InserirPizzaDTO inserirPizzariaDto)
        {
            var pizza = new Pizza();

            ValidarPizzaria(inserirPizzariaDto.CodigoPizzaria);

            pizza.Titulo = inserirPizzariaDto.Titulo;
            pizza.Ingredientes = inserirPizzariaDto.Ingredientes;
            pizza.CodigoPizzaria = inserirPizzariaDto.CodigoPizzaria;

            _dataContext.Add(pizza);

            _dataContext.SaveChanges();
        }

        public void ValidarPizzaria(int codigoPizzaria)
        {
            var pizzaria = _pizzariaHelper.RetornarPizzaria(codigoPizzaria);

            if (pizzaria == null || !pizzaria.Ativo)
            {
                throw new Exception("Pizzaria não está ativa");
            }
        }

        public PizzaView BuscarPizza(int id)
        {
            var pizza = _dataContext.Pizza.FirstOrDefault(p => p.Id == id);

            if (pizza == null)
            {
                throw new Exception("Pizza não encontrada");
            }

            var pizzaria = _pizzariaHelper.RetornarPizzariaComCache(pizza.CodigoPizzaria);

            var view = new PizzaView();

            view.Id = pizza.Id;
            view.CodigoPizzaria = pizza.CodigoPizzaria;
            view.Titulo = pizza.Titulo;
            view.Ingredientes = pizza.Ingredientes;
            view.Pizzaria = pizzaria;

            return view;
        }

        public List<Pizza> BuscarTodas()
        {
            var listaPizza = _dataContext.Pizza.ToList();

            return listaPizza;
        }

        public void InformarPromocaoPizza (int codigoPizza, InformarPromocaoPizzaDTO informarPromocaoPizzaDto)
        {
            var pizza = _dataContext.Pizza.FirstOrDefault(p => p.Id == codigoPizza);

            ValidarPromocaoPizza(pizza, informarPromocaoPizzaDto);

            pizza.ValorPromocao = informarPromocaoPizzaDto.ValorPromocao;
            pizza.DataVigenciaPromocao = informarPromocaoPizzaDto.DataVigenciaPromocao;

            _dataContext.SaveChanges();
        }

        public void ValidarPromocaoPizza(Pizza pizza, InformarPromocaoPizzaDTO informarPromocaoPizzaDto)
        {
            if (pizza == null)
            {
                throw new Exception("Pizza não encontrada");
            }
        }
    }
}
