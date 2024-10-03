
using HealthAndMed.Application.Interfaces;
using HealthAndMed.Application.Services;
using HealthAndMed.Application.UseCases;
using HealthAndMed.Domain.Interfaces;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Interfaces.Services;
using HealthAndMed.Domain.Interfaces.UseCases;
using HealthAndMed.Domain.Services;
using HealthAndMed.Domain.UseCases;
using HealthAndMed.Infra.Authentication.Services;
using HealthAndMed.Infra.Data.Repositories;

namespace AtivosTC5.Services.Extensions
{
    /// <summary>
    /// Classe de extensão para configurarmos as injeções
    /// de dependência feitas no projeto
    /// </summary>
    public static class DependencyInjectionExtension
    {
        /// <summary>
        /// Método para configurarmos as injeções de dependência
        /// que serão adicionadas no projeto AspNet
        /// </summary>
        public static IServiceCollection AddDependencyInjection(this IServiceCollection services)
        {

            #region Configurando as injeção de dependência do projeto

            services.AddTransient<IAgendaRepository, AgendaRepository>();
            services.AddTransient<IEspecialidadeMedicaRepository, EspecialidadeMedicaRepository>();
            services.AddTransient<IMedicoEspecialidadeRepository, MedicoEspecialidadeRepository>();
            services.AddTransient<IUsuarioMedicoRepository, UsuarioMedicoRepository>();
            services.AddTransient<IUsuarioPacienteRepository, UsuarioPacienteRepository>();
            services.AddTransient<IUsuarioBaseRepository, UsuarioBaseRepository>();

            services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
            services.AddTransient<IUsuarioMedicoDomainService, UsuarioMedicoDomainService>();
            services.AddTransient<IUsuarioPacienteDomainService, UsuarioPacienteDomainService>();
            services.AddTransient<IEspecialidadeMedicaDomainService, EspecialidadeMedicaDomainService>();
            services.AddTransient<IUsuarioAuthentication, UsuarioAuthentication>();

            services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            services.AddTransient<IUsuarioMedicoAppService, UsuarioMedicoAppService>();
            services.AddTransient<IUsuarioPacienteAppService, UsuarioPacienteAppService>();
            services.AddTransient<IEspecialidadeMedicaAppService, EspecialidadeMedicaAppService>();

            services.AddTransient<ICriaAgendaDisponivel, CriaAgendaDisponivel>();
            services.AddTransient<IFinalizaConsultaAgenda, FinalizaConsultaAgenda>();
            services.AddTransient<IPacienteCancelaConsulta, PacienteCancelaConsulta>();
            services.AddTransient<IPacienteAgendaConsulta, PacienteAgendaConsulta>();

            #endregion

            return services;
        }
    }
}
