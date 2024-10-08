﻿using HealthAndMed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthAndMed.Domain.ValueObjects
{
    public class Agenda
    {
        public int Medico_Id { get; set; }
        public DateTime DataAtendimento { get; set; }
        public int? Paciente_Id { get; set; }
        public int? Especialidade_Id { get; set; }
        public DateTime? DataAgendou { get; set; }
        public bool? isAtendico { get; set; }
        public string? Prontuario { get; set; }
        public int? EspecialidadeMedicaId { get; set; }

        public UsuarioMedico Medico { get; set; }
        public UsuarioPaciente Paciente { get; set; }
        public MedicoEspecialidade MedicoEspecialidade { get; set; }

    }
}
