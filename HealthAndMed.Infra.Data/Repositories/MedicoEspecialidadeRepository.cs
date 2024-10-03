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
    public class MedicoEspecialidadeRepository : IMedicoEspecialidadeRepository
    {
        protected SqlServerContext _context;
        protected DbSet<MedicoEspecialidade> _dbSet;

        public MedicoEspecialidadeRepository()
        {
            _context = new SqlServerContext();
            _dbSet = _context.Set<MedicoEspecialidade>();
        }

        public async Task<MedicoEspecialidadeAgendaResponseModel> AgendaPorEspecialidade(int idMedico, int idEspecialidade)
        {
            try
            {
                var Agenda = await _dbSet.Where(x => x.Medico_Id == idMedico && x.EspecialidadeMedica_Id==idEspecialidade)
                                    .Select(x => new MedicoEspecialidadeAgendaResponseModel
                                    {
                                        Especialidade_Id = idEspecialidade,
                                        Especialidade_Nome = x.Especialidade.Nome,
                                        Medico_Id = x.Medico_Id,
                                        Nome=x.Medico.Nome,
                                        Agenda=x.Medico.Agendas.Where(x=>x.DataAtendimento.Date>=DateTime.Today && (x.Paciente_Id??0)==0)
                                                                .Select(x=>x.DataAtendimento).ToList()
                                    }).FirstOrDefaultAsync();
                return Agenda;
            }
            catch
            {
                throw;
            }
        }

        public virtual void Alterar(MedicoEspecialidade entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public virtual void Cadastrar(MedicoEspecialidade entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public async virtual void Deletar(MedicoEspecialidade entidade)
        {
            _dbSet.Remove(entidade);
            _context.SaveChanges();
        }

        public async Task<IList<MedicoEspecialidade>> ObterPorIdEspecialidade(int id)
        {
            return await _dbSet.Where(x => x.EspecialidadeMedica_Id == id)
                               .ToListAsync();
        }

        public async Task<IList<MedicoEspecialidade>> ObterPorIdMedico(int id)
        {
            return await _dbSet.Where(x => x.Medico_Id == id)
                                .ToListAsync();
        }

        public async Task<MedicoEspecialidade> ObterPorIdMedicoIdEspecialidade(int idMedico, int idEspecialidade)
        {
            return await _dbSet.Where(x => x.Medico_Id == idMedico && x.EspecialidadeMedica_Id == idEspecialidade)
                                .FirstOrDefaultAsync();
        }

        public virtual IList<MedicoEspecialidade> ObterTodos()
        {
            return _dbSet.ToList();
        }

        public virtual async Task<IList<MedicoEspecialidade>> ObterTodosAsync()
        {
            return await _dbSet.ToListAsync();
        }
    }
}
