
using HealthAndMed.Domain.Interfaces.Repositories;
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
            services.AddTransient<IUsuarioMedicoRepository, UsuarioMedicoRepository>();
            services.AddTransient<IUsuarioPacienteRepository, UsuarioPacienteRepository>();

            #endregion

            return services;
        }
    }
}
