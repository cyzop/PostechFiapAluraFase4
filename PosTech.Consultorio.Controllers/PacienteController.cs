using PosTech.Consultorio.Adapters;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Gateways;
using PosTech.Consultorio.Interfaces;
using PosTech.Consultorio.UseCases;

namespace PosTech.Consultorio.Controllers
{
    public class PacienteController : IPacienteController
    {
        private readonly IPacienteGateway pacienteGateway;

        public PacienteController(IDatabaseClient databaseClient)
        {
            this.pacienteGateway = new PacienteGateway(databaseClient);
        }

        public string RegistrarPaciente(PacienteDao pacienteDAO)
        {
            var pacienteBase = pacienteGateway.ObterPorIdentificacao(pacienteDAO.Identificacao);

            var pacienteEntity = new PacienteEntity(
                                pacienteDAO.Identificacao,
                                pacienteDAO.Nome,
                                pacienteDAO.DataNascimento,
                                pacienteDAO.Email);

            var registroPaciente = new RegistrarPacienteUseCase(pacienteEntity, pacienteBase);
            //RN verifica se ainda não existe
            registroPaciente.VerificaNovoPaciente();
            
            pacienteGateway.RegistrarPaciente(pacienteEntity);

            return PacienteAdapter.ToJson(pacienteDAO);
        }
        
        public string AtualizarPaciente(PacienteDao pacienteDAO)
        {
            var pacienteBase = pacienteGateway.ObterPorIdentificacao(pacienteDAO.Identificacao);

            var pacienteEntity = new PacienteEntity(
                            pacienteDAO.Identificacao,
                            pacienteDAO.Nome,
                            pacienteDAO.DataNascimento,
                            pacienteDAO.Email);

            var atualizacaoPaciente = new AtualizarPacienteUseCase(pacienteEntity, pacienteBase);
            atualizacaoPaciente.VerificaNovoPaciente();

            pacienteGateway.AtualizarPaciente(pacienteEntity);

            return PacienteAdapter.ToJson(pacienteDAO);
        }

        public IEnumerable<PacienteDao> ListarPacientes()
        {
            var pacientes = pacienteGateway.ObterPacientes();
            var pacientesDao = pacientes?.Select(e => new PacienteDao
            {
                Nome = e.Nome,
                DataNascimento = e.DataNascimento,
                Identificacao = e.Identificacao,
                Email = e.Email
            });
            return pacientesDao?.ToList();
        }

        public void RemoverPaciente(string identificacao)
        {
            var pacienteRemover = pacienteGateway.ObterPorIdentificacao(identificacao);

            var remocaoPaciente = new RemoverPacienteUseCase(pacienteRemover, identificacao);
            //RN verifica se existe
            remocaoPaciente.VerificaPaciente();

            pacienteGateway.RemoverPaciente(pacienteRemover);
        }


    }
}
