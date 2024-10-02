using AtivosTC5.Infra.Data.Contexts;
using HealthAndMed.Domain.Interfaces.Repositories;
using HealthAndMed.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Infra.Data.Repositories
{
    public class AgendaRepository:IAgendaRepository
    {
        protected SqlServerContext _context;
        protected DbSet<Agenda> _dbSet;

        public AgendaRepository()
        {
            _context = new SqlServerContext();
            _dbSet = _context.Set<Agenda>();
        }


        public virtual void Alterar(Agenda entidade)
        {
            _dbSet.Update(entidade);
            _context.SaveChanges();
        }

        public virtual void Cadastrar(Agenda entidade)
        {
            _dbSet.Add(entidade);
            _context.SaveChanges();
        }

        public virtual void Deletar(int medicoIde, DateTime dtAtendimento)
        {
            var agenda = ObterPorIdMedicoEData(medicoIde, dtAtendimento);
            _dbSet.Remove(agenda.Result);
            _context.SaveChanges();
        }

        public virtual async Task<IList<Agenda>> ObterPorIdMedico(int id)
        {
            return await _dbSet.Where(t => t.Medico_Id == id && t.DataAtendimento >= DateTime.Today).ToListAsync();
        }

        public virtual async Task<Agenda> ObterPorIdMedicoEData(int id, DateTime dtAgenda)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Medico_Id == id && t.DataAtendimento == dtAgenda);
        }

        public virtual async Task<IList<Agenda>> ObterPorIdPaciente(int id)
        {
            return await _dbSet.Where(t => t.Paciente_Id == id && t.DataAtendimento >= DateTime.Today).ToListAsync();
        }

        public virtual async Task<Agenda> ObterPorIdPacienteEData(int id, DateTime dtAgenda)
        {
            return await _dbSet.FirstOrDefaultAsync(t => t.Paciente_Id == id && t.DataAtendimento == dtAgenda);
        }

        public virtual async Task<IList<Agenda>> ObterPorIdEspecialidade(int id)
        {
            return await _dbSet
                .Include(x => x.Medico)
                .Where(t => t.Medico.Especialidade_Id == id && t.DataAtendimento >= DateTime.Today).ToListAsync();
        }

        public virtual async Task<IList<Agenda>> ObterPorIdMedicoNaData(int id, DateTime dtAgenda)
        {
            return await _dbSet
               .Where(t => t.Medico_Id == id && t.DataAtendimento.Date == DateTime.Today).ToListAsync();
        }
    }
}
