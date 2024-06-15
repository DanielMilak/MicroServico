using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Channels;
using System.Text;

namespace MovtoFinanceiro.Infra
{
    public static class PublishFilaHello
    {
        public static IModel _channel;

        public static void Iniciar(IModel channel)
        {
            _channel = channel;
        }

        public static void PublicarFilaHello()
        {
            var nomeFila = "Hello";

            var body = Encoding.UTF8.GetBytes("Hello Duds");

            _channel.BasicPublish(exchange: string.Empty,
                     routingKey: "FilaHello",
                     body: body);
        }
    }
}
