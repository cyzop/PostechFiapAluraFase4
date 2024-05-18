using PosTech.Consultorio.Adapters.Data;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Adapters
{
    public static class AtendimentoMedicoAdapter
    {
        public static string FromEntityToJson(AtendimentoMedicoEntity atendimento)
        {
            var atendimentoData = new AtendimentoMedicoAdapterData
            {
                Anamnese = atendimento.Anamnese,
                DataAtendimento = atendimento.DataAtendimento,
                Diagnostico = atendimento.Diagnostico,
                Sintoma = atendimento.Sintoma,
                Tratamento = atendimento.Tratamento,
                Medico = new MedicoAtentimentoMedicoAdapterData
                {
                    CRM = atendimento.Medico.CRM,
                    Nome = atendimento.Medico.Nome
                },
                Paciente = new PacienteAtendimentoMedicoAdapterData
                {
                    Identificacao = atendimento.Paciente.Identificacao,
                    Nome = atendimento.Paciente.Nome
                }
            };

            return System.Text.Json.JsonSerializer.Serialize<AtendimentoMedicoAdapterData>(atendimentoData);
        }
    }
}
