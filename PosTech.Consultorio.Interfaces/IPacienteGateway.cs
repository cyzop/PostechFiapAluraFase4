using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Interfaces
{
    public interface IPacienteGateway
    {
        void RegistrarPaciente(PacienteEntity paciente);
        PacienteEntity ObterPorIdentificacao(string identificacao);

        ICollection<PacienteEntity> ObterPacientes();

        void RemoverPaciente(PacienteEntity paciente);

        void AtualizarPaciente(PacienteEntity paciente);
    }
}
