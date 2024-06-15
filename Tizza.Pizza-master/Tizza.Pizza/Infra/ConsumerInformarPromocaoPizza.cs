using RabbitMQ.Client.Events;
using RabbitMQ.Client;
using System.Threading.Channels;
using System.Text;
using Newtonsoft.Json;
using Pizzas;
using Tizza;

namespace MovtoFinanceiro.Infra
{
    public static class ConsumerFilaInformarPromocaoNaPizza
    {
        public static void FilaInformarPromocaoNaPizza(IModel channel)
        {
            var nomeFila = "InformarPromocaoNaPizza";

            channel.QueueDeclare(queue: nomeFila, durable: true, exclusive: false, autoDelete: false);

            var consumer = new EventingBasicConsumer(channel);


            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);

                var informarPromocaoDto = JsonConvert.DeserializeObject<InformarPromocaoPizzaPorFilaDTO>(message);

                try
                {
                    var servPizza = GeradorDeServicos.ServiceProvider.GetService<IServPizza>();

                    var infomarPromocaoDtoPadrao = new InformarPromocaoPizzaDTO() { DataVigenciaPromocao = informarPromocaoDto.DataVigenciaPromocao, ValorPromocao = informarPromocaoDto.ValorPromocao };

                    servPizza.InformarPromocaoPizza(informarPromocaoDto.CodigoPizza, infomarPromocaoDtoPadrao);

                    PublishResultInformarPromocaoPizza.Publicar(informarPromocaoDto.CodigoPizza, true, "Ok");
                }
                catch (Exception e)
                {
                    PublishResultInformarPromocaoPizza.Publicar(informarPromocaoDto.CodigoPizza, false, e.Message);
                }
            };

            channel.BasicConsume(queue: nomeFila,
                     autoAck: true,
                     consumer: consumer);
        }
    }
}
