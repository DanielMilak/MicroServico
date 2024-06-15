using RabbitMQ.Client.Events;
using RabbitMQ.Client;

namespace MovtoFinanceiro.Infra
{
    public static class ConsumerFilaHello
    {
        public static void FilaHello(RabbitMQ.Client.IModel channel)
        {
            var nomeFila = "FilaHello";

            channel.QueueDeclare(nomeFila);

            var consumer = new EventingBasicConsumer(channel);


            consumer.Received += (model, ea) =>
            {
                throw new Exception("AAA");
            };

            channel.BasicConsume(queue: nomeFila,
                     autoAck: true,
                     consumer: consumer);
        }
    }
}
