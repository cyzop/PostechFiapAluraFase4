using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Interfaces.Gateways
{
    public interface IMedicoGateway
    {
        void IncluirMedico(MedicoEntity medico);
        MedicoEntity ObterPorIdentificacao(string identificacao);

        ICollection<MedicoEntity> ObterMedicos();

        void RemoverMedico(MedicoEntity paciente);

        void AtualizarMedico(MedicoEntity paciente);
    }
}
