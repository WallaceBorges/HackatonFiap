using HealthAndMed.Domain.Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.Interfaces.Services
{
    public interface IConsultaMessageProduce
    {
        void Send(ConsultaMensagemDto dto);
    }
}
