using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AtivosTC5.Infra.Data.Contexts
{
    public partial class SqlServerContext : DbContext
    {
        public SqlServerContext():base()
        {
        }

        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options)
        {

        }

        /// <summary>
        /// Método para definir o caminho do banco de dados (ConnectionString)
        /// </summary>

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=HealthAndMed_BD");

        /// <summary>
        /// Método para adicionar as classes de mapeamento do projeto
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(SqlServerContext).Assembly);
        }

        /// <summary>
        /// Provedor de métodos para o repositorio (CRUD)
        /// </summary>
        public virtual DbSet<EspecialidadeMedica> EspecialidadeMedidas { get; set; }
        public virtual DbSet<MedicoEspecialidade> MedicoEspecialidades { get; set; }
        public virtual DbSet<UsuarioBase> Usuarios { get; set; }
        public virtual DbSet<Agenda> Agendas { get; set; }
    }
}
