using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Models.Dtos;
using HealthAndMed.Infra.Messages.Helpers;
using HealthAndMed.Infra.Messages.Settings;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Messages.Producers
{
    public class ConsultaMessageProducer : IConsultaMessageProduce
    {
        public void Send(ConsultaMensagemDto dto)
        {

            //endereço do servidor do RabbitMQ (AMQP CLOUD)
            var connectionFactory = new ConnectionFactory() { Uri = new Uri(MessageSettings.Url) };
            using (var connection = connectionFactory.CreateConnection())
            {
                //conectando na fila e gravando a mensagem
                using (var model = connection.CreateModel())
                {
                    //parametros para conexão na fila..
                    model.QueueDeclare(
                        queue: MessageSettings.QueueName, //nome da fila
                        durable: true, //a fila não será apagada (fila persistente)
                        exclusive: false, //fila pode ser acessada por multiplos programas
                        autoDelete: false, //o itens da fila não serão removidos automaticamente
                        arguments: null
                        );

                    //gravando os dados na fila
                    model.BasicPublish(
                        exchange: string.Empty,
                        routingKey: MessageSettings.QueueName,
                        basicProperties: null,
                        body: Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(dto))
                        );
                }
            }
        }

    }
}
