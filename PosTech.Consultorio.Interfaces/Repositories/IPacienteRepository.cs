using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Interfaces.Repositories
{
    public interface IPacienteRepository
    {
        void IncluirPaciente(PacienteEntity paciente);
        PacienteEntity? ObterPacientePorIdentificacao(string identificacao);
        void AtualizarPaciente(PacienteEntity paciente);

        ICollection<PacienteEntity> ObterPacientes();

        void RemoverPaciente(PacienteEntity paciente);
    }
}