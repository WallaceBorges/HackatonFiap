using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Repositories
{
    public class UsuarioPacienteRepository : RepositoryBase<UsuarioPaciente> , IUsuarioPacienteRepository
    {
    }
}
