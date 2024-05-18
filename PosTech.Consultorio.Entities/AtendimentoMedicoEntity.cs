namespace PosTech.Consultorio.Entities
{
    public class AtendimentoMedicoEntity
    {
        public string Id { get; }
        public IdentificadorMedicoEntity Medico { get; }
        public IdentificadorPacienteEntity Paciente { get; }

        public DateTime DataAtendimento { get; }
        public string Anamnese { get; }
        public string Sintoma { get; }
        public string Diagnostico { get; }
        public string Tratamento { get;  }

        public AtendimentoMedicoEntity(string id, DateTime dataAtendimento, string anamnese, string sintoma, string diagnostico, string tratamento, IdentificadorMedicoEntity medico, IdentificadorPacienteEntity paciente)
        {
            Id = id;
            Medico = medico;
            Paciente = paciente;
            DataAtendimento = dataAtendimento;
            Anamnese = anamnese;
            Sintoma = sintoma;
            Diagnostico = diagnostico;
            Tratamento = tratamento;

            ValidadeEntity();
        }

        public void ValidadeEntity()
        {
            AssertionConcern.AssertArgumentNotNull(Medico, "O Médico não pode estar vazio!");
            AssertionConcern.AssertArgumentNotNull(Paciente, "O Paciente não pode estar vazio!");

            AssertionConcern.AssertArgumentNotEmpty(Paciente.Identificacao, "A Identificação do paciente não pode estar vazia!");
            AssertionConcern.AssertArgumentNotEmpty(Medico.CRM, "O CRM do médico não pode estar vazio!");

            AssertionConcern.AssertArgumentMaxDate(DataAtendimento, DateTime.Today, "A data de atendimento não pode ser futura!");
        }
    }
}
