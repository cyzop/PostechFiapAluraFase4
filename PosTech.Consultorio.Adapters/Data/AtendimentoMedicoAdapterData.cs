using PosTech.Consultorio.DAO;

namespace PosTech.Consultorio.Adapters.Data
{
    public class AtendimentoMedicoAdapterData
    {
        public required string Anamnese { get; set; }
        public required string Sintoma { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamento { get; set; }
        public required DateTime DataAtendimento { get; set; }

        public required MedicoAtentimentoMedicoAdapterData Medico { get; set; }
        public required PacienteAtendimentoMedicoAdapterData Paciente { get; set; }
        
    }
}
