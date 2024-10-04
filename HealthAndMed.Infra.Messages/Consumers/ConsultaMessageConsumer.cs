using HealthAndMed.Domain.Models.Dtos;
using HealthAndMed.Infra.Messages.Services;
using HealthAndMed.Infra.Messages.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Messages.Consumers
{
    public class ConsultaMessageConsumer
    {
        /// <summary>
        /// Esta classe será executada como um serviço da aplicação, ou seja,
        /// ao rodar o projeto esta classe já será inicializada e ficará
        /// constantemente conectada e lendo o conteúdo da fila.
        /// </summary>
        public class UsuarioMessageConsumer : BackgroundService
        {
            //atributos
            private readonly IServiceProvider? _serviceProvider;
            private IConnection? _connection;
            private IModel? _model;

            public UsuarioMessageConsumer(IServiceProvider? serviceProvider)
            {
                _serviceProvider = serviceProvider;

                #region Fazendo conexão com o servidor e a fila do RabbitMQ

                //conectando com o servidor do RabbitMQ (AMQP)
                var factory = new ConnectionFactory { Uri = new Uri(MessageSettings.Url) };
                _connection = factory.CreateConnection();
                _model = _connection.CreateModel();

                //conectando na fila
                _model?.QueueDeclare(
                    queue: MessageSettings.QueueName,
                    durable: true,
                    exclusive: false,
                    autoDelete: false,
                    arguments: null
                    );

                #endregion
            }

            protected override Task ExecuteAsync(CancellationToken stoppingToken)
            {
                var consumer = new EventingBasicConsumer(_model);

                //programando a leitura da fila..
                consumer.Received += async (sender, args) =>
                {
                    //ler o conteudo de cada mensagem gravada na fila 
                    var contentString = Encoding.UTF8.GetString(args.Body.ToArray());
                    //deserializar o conteudo
                    var dto = JsonConvert.DeserializeObject<ConsultaMensagemDto>(contentString);

                    //processando o item da fila
                    using (var scope = _serviceProvider?.CreateScope())
                    {
                        var usuarioMessageService = new ConsultaMessageService();

                        //verificando o tipo da mensagem..
                        switch (dto.TipoMensagem)
                        {
                            case TipoMensagem.BoasVindas:
                                break;

                            case TipoMensagem.ConsultaMarcada:
                                usuarioMessageService.GerarMensagemDeBoasVidas(dto.Usuario);
                                break;
                        }

                        //remover/retirar a mensagem da fila
                        _model.BasicAck(args.DeliveryTag, false);
                    }
                };

                //finalizando o processo do consumer..
                _model.BasicConsume(MessageSettings.QueueName, false, consumer);
                return Task.CompletedTask;
            }
        }
    }
}
