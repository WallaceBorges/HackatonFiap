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
            _dbSet.Remove(ObterPorIdMedicoEData(medicoIde, dtAtendimento));
            _context.SaveChanges();
        }

        public virtual IList<Agenda> ObterPorIdMedico(int id)
        {
            return _dbSet.Where(t => t.Medico_Id == id && t.DataAtendimento >= DateTime.Today).ToList();
        }

        public virtual Agenda ObterPorIdMedicoEData(int id, DateTime dtAgenda)
        {
            return _dbSet.FirstOrDefault(t => t.Medico_Id == id && t.DataAtendimento == dtAgenda);
        }

        public virtual IList<Agenda> ObterPorIdPaciente(int id)
        {
            return _dbSet.Where(t => t.Paciente_Id == id && t.DataAtendimento >= DateTime.Today).ToList();
        }

        public virtual Agenda ObterPorIdPacienteEData(int id, DateTime dtAgenda)
        {
            return _dbSet.FirstOrDefault(t => t.Paciente_Id == id && t.DataAtendimento == dtAgenda);
        }

        public virtual IList<Agenda> ObterPorIdEspecialidade(int id)
        {
            return _dbSet
                .Include(x => x.Medico)
                .Where(t => t.Medico.Especialidade_Id == id && t.DataAtendimento >= DateTime.Today).ToList();
        }
    }
}
