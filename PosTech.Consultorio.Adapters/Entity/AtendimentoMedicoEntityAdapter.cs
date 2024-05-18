using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PosTech.Consultorio.Adapters.Entity
{
    public class AtendimentoMedicoEntityAdapter
    {
        public static AtendimentoMedicoEntity FromDAO(AtendimentoMedicoDAO atendimento, string nomeMedico, string nomePaciente)
        {
            return new AtendimentoMedicoEntity(
               atendimento.Id,
               atendimento.DataAtendimento,
               atendimento.Anamnese,
               atendimento.Sintoma,
               atendimento.Diagnostico,
               atendimento.Diagnostico,
               new IdentificadorMedicoEntity(
                   nomeMedico,
                   atendimento.Medico.CRM),
               new IdentificadorPacienteEntity(
                   nomePaciente,
                   atendimento.Paciente.Identificacao));
        }
    }
}
