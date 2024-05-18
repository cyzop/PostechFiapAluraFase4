namespace PosTech.Consultorio.DAO
{
    public class AtendimentoMedicoDAO
    {
        public string? Id { get; set; }
        public required IdentificadorMedicoDAO Medico {  get; set; }
        public required IdentificadorPacienteDAO Paciente { get; set; }
        
        public required DateTime DataAtendimento { get; set; }
        public required string Anamnese { get; set; }
        public required string Sintoma { get; set; }
        public string Diagnostico { get; set; }
        public string Tratamento { get; set; }
               
    }
}
