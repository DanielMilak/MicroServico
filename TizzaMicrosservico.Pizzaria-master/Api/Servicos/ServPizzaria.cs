using Tizza.Pizzaria.DTO;

namespace Tizza.Pizzaria.Servicos
{
    public interface IServPizzaria
    {
        void Inserir(Pizzaria pizzaria);
        void Editar(Pizzaria pizzaria);
        Pizzaria BuscarPizzaria(int id);
        List<Pizzaria> BuscarTodos();
    }

    public class ServPizzaria: IServPizzaria
    {
        private readonly DataContext _dataContext;

        public ServPizzaria(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public void Inserir(Pizzaria pizzaria)
        {
            ValidarDadosPizzaria(pizzaria);

            _dataContext.Add(pizzaria);

            _dataContext.SaveChanges();
        }

        public void Editar(Pizzaria pizzaria)
        {
            ValidarDadosPizzaria(pizzaria);

            _dataContext.SaveChanges();
        }

        public void ValidarDadosPizzaria(Pizzaria pizzaria)
        {
            if (pizzaria.Nome.Length < 30)
            {
                throw new Exception("O nome da pizzaria deve conter ao menos 30 caracteres.");
            }

            if (pizzaria.Cnpj.Length != 14)
            {
                throw new Exception("CNPJ inválido. Verifique o valor informado.");
            }
        }

        public Pizzaria BuscarPizzaria(int id)
        {
            var pizzaria = _dataContext.Pizzarias.FirstOrDefault(x => x.Id == id);

            return pizzaria;
        }

        public List<Pizzaria> BuscarTodos()
        {
            var listaPizzaria = _dataContext.Pizzarias.ToList();

            return listaPizzaria;
        }
    }
}
