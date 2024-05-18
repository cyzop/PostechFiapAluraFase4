using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.Interfaces.Repositories;

namespace PosTech.Consultorio.Gateways
{
    public class AtendimentoMedicoGateway : IAtendimentoMedicoGateway
    {
        readonly IMedicalCareRepository database;

        public AtendimentoMedicoGateway(IMedicalCareRepository database)
        {
            this.database = database;
        }

        public void AtualizarAtendimentoMedico(AtendimentoMedicoEntity atendimento)
        {
            this.database.AtualizarAtendimentoMedico(atendimento);
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorData(DateTime data)
        {
            return this.database.ObterAtendimentosPorData(data);
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorMedico(string IdMedico)
        {
            return this.database.ObterAtendimentosPorMedico(IdMedico);
        }

        public ICollection<AtendimentoMedicoEntity> ObterAtendimentosPorPaciente(string IdPaciente)
        {
            return this.database.ObterAtendimentosPorPaciente(IdPaciente);
        }

        public AtendimentoMedicoEntity ObterPorIdentificacao(string identificacao)
        {
            return this.database.ObterPorIdentificacao(identificacao);
        }

        public void RegistrarAtendimentoMedico(AtendimentoMedicoEntity atendimento)
        {
            this.database.RegistrarAtendimentoMedico(atendimento);
        }
    }
}
