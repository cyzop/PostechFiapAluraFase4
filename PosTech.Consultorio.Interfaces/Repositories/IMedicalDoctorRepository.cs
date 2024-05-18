using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Interfaces.Repositories
{
    public interface IMedicalDoctorRepository
    {
        void AtualizarMedico(MedicoEntity medico);
        void IncluirMedico(MedicoEntity medico);
        ICollection<MedicoEntity> ObterMedicos();
        MedicoEntity ObterPorIdentificacao(string identificacao);
        void RemoverMedico(MedicoEntity medico);
    }
}
