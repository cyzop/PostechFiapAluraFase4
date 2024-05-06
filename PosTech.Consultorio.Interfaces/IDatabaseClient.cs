using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Interfaces
{
    public interface IDatabaseClient
    {
        void IncluirPaciente(PacienteEntity paciente);
        PacienteEntity? ObterPacientePorIdentificacao(string identificacao);
        void AtualizarPaciente(PacienteEntity paciente);

        ICollection<PacienteEntity> ObterPacientes();

        void RemoverPaciente(PacienteEntity paciente);
    }
}