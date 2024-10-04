using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Messages.Settings
{
    public class MessageSettings
    {
        /// <summary>
        /// URL para conexão com o servidor do RabbitMQ
        /// </summary>
        public static string Url
            => "amqps://odxzqqww:qgtOJWdGfTQ7bBxEHIIU_9pZO2Q4QFE7@turkey.rmq.cloudamqp.com/odxzqqww";

        /// <summary>
        /// Nome da fila que iremos acessar no servidor
        /// </summary>
        public static string QueueName
            => "consulta_marcada";
    }
}
