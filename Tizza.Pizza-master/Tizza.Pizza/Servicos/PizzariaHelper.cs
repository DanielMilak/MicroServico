using Microsoft.Extensions.Caching.Memory;
using static System.Net.WebRequestMethods;

namespace Tizza
{
    public interface IPizzariaHelper
    {
        PizzariaDTO RetornarPizzaria(int codigoPizzaria);
        PizzariaDTO RetornarPizzariaComCache(int codigoPizzaria);
    }

    public class PizzariaHelper : IPizzariaHelper
    {
        private const string _pizzariaController = "api/Pizzaria/";
        private IMemoryCache _memoryCache;

        public PizzariaHelper(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public PizzariaDTO RetornarPizzaria(int codigoPizzaria)
        {
            var httpClient = new HttpClient();

            var urlPizzaria = BuscarUrlPizzaria();

            var url = urlPizzaria  + _pizzariaController + codigoPizzaria;



            var resposta = httpClient.GetAsync(url).Result;

            if (!resposta.IsSuccessStatusCode)
            {
                throw new Exception("Pizzaria " + codigoPizzaria + " não encontrada.");
            }

            if (resposta.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return null;
            }

            var pizzaria = resposta.Content.ReadFromJsonAsync<PizzariaDTO>().Result;

            InserirPizzariaNoCache(pizzaria);

            return pizzaria;
        }

        public void InserirPizzariaNoCache(PizzariaDTO pizzariaDto)
        {
            _memoryCache.Set("Pizzaria" +  pizzariaDto.Id, pizzariaDto, TimeSpan.FromHours(1));
        }

        public PizzariaDTO RetornarPizzariaComCache(int codigoPizzaria)
        {
            var pizzaria = _memoryCache.Get<PizzariaDTO>("Pizzaria" + codigoPizzaria);

            if (pizzaria != null)
            {
                return pizzaria;
            }

            pizzaria = RetornarPizzaria(codigoPizzaria);

            return pizzaria;
        }

        public string BuscarUrlPizzaria()
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json")
            .Build();

            string url = configuration["UrlPizzaria"];

            return url;
        }
    }
}
