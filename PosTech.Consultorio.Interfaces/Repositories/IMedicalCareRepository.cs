using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Interfaces.Repositories
{
    public interface IMedicalCareRepository
    {
        void AtualizarAtendimentoMedico(AtendimentoMedicoEntity atendimento);
        ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorData(DateTime data);
        ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorIdentificadorMedico(string idMedico);
        ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorIdentificadorPaciente(string idPaciente);
        AtendimentoMedicoEntity ObterAtendimentoPorIdentificacao(string identificacao);
        void RegistrarAtendimentoMedico(AtendimentoMedicoEntity atendimento);
    }
}
