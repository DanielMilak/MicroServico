using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Channels;
using System.Text;
using Newtonsoft.Json;

namespace Tizza
{
    public static class PublishResultInformarPromocaoPizza
    {
        public static IModel _channel;

        public static void Iniciar(IModel channel)
        {
            _channel = channel;
        }

        public static void Publicar(int codigoPizza, bool sucesso, string mensagemDeErro)
        {
            var result = new
            {
                CodigoPizza = codigoPizza,
                Sucesso = sucesso,
                MensagemDeErro = mensagemDeErro
            };

            var body = Encoding.Default.GetBytes(JsonConvert.SerializeObject(result));

            _channel.BasicPublish(exchange: string.Empty,
                     routingKey: "ResultInformarPromocaoPizza",
                     body: body);
        }
    }
}
