using Microsoft.EntityFrameworkCore.Metadata;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System.Text;
using Tizza;

namespace MovtoFinanceiro.Infra
{
    public static class RabbitMqManager
    {
        public static void Iniciar()
        {
            var factory = new ConnectionFactory
            {
                HostName = "chimpanzee-01.rmq.cloudamqp.com",
                UserName = "nyoghlda",
                Password = "KVnAk7M2S1t3SVQap8-fNkz1ohQueTQY",
                VirtualHost = "nyoghlda"
            };

            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();

            ConsumerFilaInformarPromocaoNaPizza.FilaInformarPromocaoNaPizza(channel);
            PublishResultInformarPromocaoPizza.Iniciar(channel);
        }

        


    }
}
