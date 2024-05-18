using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Interfaces.Gateways
{
    public interface IAtendimentoMedicoGateway
    {
        void RegistrarAtendimentoMedico(AtendimentoMedicoEntity atendimento);
        AtendimentoMedicoEntity ObterPorIdentificacao(string identificacao);

        ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorData(DateTime data);

        ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorMedico(string IdMedico);

        ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorPaciente(string IdPaciente);

        void AtualizarAtendimentoMedico(AtendimentoMedicoEntity atendimento);
    }
}
