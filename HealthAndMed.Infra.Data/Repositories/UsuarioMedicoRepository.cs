using AtivosTC5.Infra.Data.Contexts;
using HealthAndMed.Domain.Entities;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.Models.Responses;
using HealthAndMed.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Repositories
{
    public class UsuarioMedicoRepository : RepositoryBase<UsuarioMedico> , IUsuarioMedicoRepository
    {
    
    }
}
