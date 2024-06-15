using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using Tizza;
using System.Text.Unicode;
using System.Text;
using Newtonsoft.Json;

namespace MovtoFinanceiro.Infra
{
    public static class ConsumerFilaInserirMovtoEntrada
    {
        public static void FilaInserirMovtoEntrada(IModel channel)
        {
            var nomeFila = "InserirMovtoEntrada";

            channel.QueueDeclare(queue: nomeFila, durable: true, exclusive: false, autoDelete: false);

            var consumer = new EventingBasicConsumer(channel);


            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var movtoCaixa = JsonConvert.DeserializeObject<InserirMovimentaoCaixaDTO>(message);
;

                var servMovimentacaoCaixa = GeradorDeServicos.ServiceProvider.GetService<IServMovimentacaoCaixa>();

                servMovimentacaoCaixa.InserirMovimentoDeEntrada(movtoCaixa);
            };

            channel.BasicConsume(queue: nomeFila,
                     autoAck: true,
                     consumer: consumer);
        }
    }
}
