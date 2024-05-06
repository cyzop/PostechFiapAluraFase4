using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces;

namespace PosTech.Consultorio.Gateways
{
    public class PacienteGateway : IPacienteGateway
    {
        readonly IDatabaseClient database;

        public PacienteGateway(IDatabaseClient database)
        {
            this.database = database;
        }

        public void RegistrarPaciente(PacienteEntity paciente)
        {
            database.IncluirPaciente(paciente);
        }

        public void AtualizarPaciente(PacienteEntity paciente)
        {
            database.AtualizarPaciente(paciente);
        }

        public PacienteEntity ObterPorIdentificacao(string identificacao)
        {
            return database.ObterPacientePorIdentificacao(identificacao);
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