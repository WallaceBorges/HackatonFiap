using HealthAndMed.Domain.Models.Dtos;
using HealthAndMed.Infra.Messages.Helpers;

namespace HealthAndMed.Infra.Messages.Services
{
    public class ConsultaMessageService
    {
       
            //método para fazer o envio da mensagem de boas vindas no cadastro do usuário
            public void GerarMensagemDeBoasVidas(UsuarioDto usuario)
            {
                var subject = $"ˮHealth&Med - Nova consulta agendada";
                var body = $@"
                <div style='font: verdana; border: 1px solid #000; padding: 40px; margin: 40px;'>
                    <center>
                         <br/>
                        <h3>Olá, {usuario.Medico}!.</h3>
                        <p>Você tem uma nova consulta marcada! Paciente: {usuario.NomePaciente}.</p>
                        <p>Data e horário: {usuario.Data.Value.ToString("dd/MM/yyyy")} às {usuario.Data.Value.ToString("HH:mm")}.</p>
                        <p>Equipe Healp&Med</p>
                    </center>
                <div>
            ";

                MailHelper.SendMail(usuario.Email, subject, body);
            }

    
        
    }
}
