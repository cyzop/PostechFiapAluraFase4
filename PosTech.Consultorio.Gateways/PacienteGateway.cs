using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.Interfaces.Repositories;

namespace PosTech.Consultorio.Gateways
{
    public class PacienteGateway : IPacienteGateway
    {
        readonly IPatientRepository database;

        public PacienteGateway(IPatientRepository database)
        {
            this.database = database;
        }

        public void RegistrarPaciente(PacienteEntity paciente)
        {
            database.RegistrarPaciente(paciente);
        }

        public void AtualizarPaciente(PacienteEntity paciente)
        {
            database.AtualizarPaciente(paciente);
        }

        public PacienteEntity ObterPorIdentificacao(string identificacao)
        {
            return database.ObterPorIdentificacao(identificacao);
        }

        public ICollection<PacienteEntity> ObterPacientes()
        {
            return database.ObterPacientes();
        }

        public void RemoverPaciente(PacienteEntity paciente)
        {
            database.RemoverPaciente(paciente) ; 
        }
    }
}