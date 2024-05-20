using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Adapters.DAO
{
    public static class AtendimentoDaoAdapter
    {
        public static string ToJson(AtendimentoMedicoDAO atendimento)
        {
            return System.Text.Json.JsonSerializer.Serialize(atendimento);
        }

        public static AtendimentoMedicoDAO FromEntity(AtendimentoMedicoEntity atendimento)
        {
            return new AtendimentoMedicoDAO()
            {
                Id = atendimento.Id,
                Anamnese = atendimento.Anamnese,
                DataAtendimento = atendimento.DataAtendimento,
                Diagnostico = atendimento.Diagnostico,
                Sintoma = atendimento.Sintoma,
                Tratamento = atendimento.Tratamento,
                Medico = new IdentificadorMedicoDAO()
                {
                    CRM = atendimento.Medico.CRM,
                    Nome = atendimento.Medico.Nome
                },
                Paciente = new IdentificadorPacienteDAO()
                {
                    Identificacao = atendimento.Paciente.Identificacao,
                    Nome = atendimento.Paciente.Nome
                }
            };
        }

        
    }
}
