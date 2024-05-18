using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.Interfaces.Repositories;

namespace PosTech.Consultorio.Gateways
{
    public class MedicoGateway : IMedicoGateway
    {
        readonly IMedicalDoctorRepository database;

        public MedicoGateway(IMedicalDoctorRepository database)
        {
            this.database = database;
        }

        public void AtualizarMedico(MedicoEntity medico)
        {
            database.AtualizarMedico(medico);
        }

        public void IncluirMedico(MedicoEntity medico)
        {
            database.IncluirMedico(medico);
        }

        public ICollection<MedicoEntity> ObterMedicos()
        {
            return database.ObterMedicos();
        }

        public MedicoEntity ObterPorIdentificacao(string identificacao)
        {
            return database.ObterPorIdentificacao(identificacao);
        }

        public void RemoverMedico(MedicoEntity medico)
        {
            database.RemoverMedico(medico);
        }
    }
}
