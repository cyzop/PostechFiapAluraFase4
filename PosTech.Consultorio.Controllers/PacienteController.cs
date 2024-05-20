using PosTech.Consultorio.Adapters.OutPut;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Gateways;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.Interfaces.Repositories;
using PosTech.Consultorio.UseCases.Paciente;

namespace PosTech.Consultorio.Controllers
{
    public class PacienteController : IPacienteController
    {
        private readonly IPacienteGateway pacienteGateway;

        public PacienteController(IPatientRepository databaseClient)
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
            registroPaciente.VerificarNovo();

            //RN formatar nome            
            var pacienteFormatter = new FormataNomePacienteUseCase(pacienteEntity);
            var pacienteFormatado = pacienteFormatter.Formatar();
            
            pacienteGateway.RegistrarPaciente(pacienteFormatado);

            return PacienteAdapter.FromEntityToJson(pacienteFormatado);
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
            atualizacaoPaciente.VerificarNovo();

            //RN formatar nome
            var pacienteFormatter = new FormataNomePacienteUseCase(pacienteEntity);
            var pacienteFormatado = pacienteFormatter.Formatar();

            pacienteGateway.AtualizarPaciente(pacienteFormatado);

            return PacienteAdapter.FromEntityToJson(pacienteFormatado);
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
            remocaoPaciente.VerificarPacienteExistente();

            pacienteGateway.RemoverPaciente(pacienteRemover);
        }


    }
}
