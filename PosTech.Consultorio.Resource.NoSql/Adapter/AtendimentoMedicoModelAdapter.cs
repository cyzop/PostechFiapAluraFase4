using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Resource.NoSql.Model;

namespace PosTech.Consultorio.Resource.NoSql.Adapter
{
    public class AtendimentoMedicoModelAdapter
    {
        public static AtendimentoModel ModelFromEntity(AtendimentoMedicoEntity atendimento)
        {
            return new AtendimentoModel(
               new MedicoAtendimentoModel(atendimento.Medico.CRM, atendimento.Medico.Nome),
               new PacienteAtendimentoModel(atendimento.Paciente.Identificacao, atendimento.Paciente.Nome),
               atendimento.DataAtendimento,
               atendimento.Anamnese,
               atendimento.Sintoma,
               atendimento.Diagnostico,
               atendimento.Tratamento);
        }
        public static AtendimentoModel ModelFromEntity(string dbId, AtendimentoMedicoEntity atendimento)
        {
            return new AtendimentoModel(dbId,
                new MedicoAtendimentoModel(atendimento.Medico.CRM, atendimento.Medico.Nome),
                new PacienteAtendimentoModel(atendimento.Paciente.Identificacao, atendimento.Paciente.Nome),
                atendimento.DataAtendimento,
                atendimento.Anamnese,
                atendimento.Sintoma,
                atendimento.Diagnostico,
                atendimento.Tratamento);
        }
        public static AtendimentoMedicoEntity EntityFromModel(AtendimentoModel atendimento)
        {
            return new AtendimentoMedicoEntity(
                atendimento.Id, 
                atendimento.DataAtendimento, 
                atendimento.Anamnese, 
                atendimento.Sintoma, 
                atendimento.Diagnostico, 
                atendimento.Tratamento,
                new IdentificadorMedicoEntity(
                    atendimento.Medico.Nome, 
                    atendimento.Medico.Identificacao),
                new IdentificadorPacienteEntity(
                    atendimento.Paciente.Nome, 
                    atendimento.Paciente.Identificacao));
        }
    }
}
