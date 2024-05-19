using PosTech.Consultorio.Adapters;
using PosTech.Consultorio.Adapters.DAO;
using PosTech.Consultorio.Adapters.Entity;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.UseCases.AtendimentoMedico;
using PosTech.Consultorio.UseCases.Medico;

namespace PosTech.Consultorio.Controllers
{
    public class AtendimentoController : IAtendimentoController
    {
        private readonly IAtendimentoMedicoGateway _atendimentoGateway;
        private readonly IMedicoGateway _medicoGateway;
        private readonly IPacienteGateway _pacienteGateway;

        public AtendimentoController(IAtendimentoMedicoGateway atendimentoGateway, IMedicoGateway medicoGateway, IPacienteGateway pacienteGateway)
        {
            _atendimentoGateway = atendimentoGateway;
            _medicoGateway = medicoGateway;
            _pacienteGateway = pacienteGateway;
        }

        public string AtualizarAtendimento(AtendimentoMedicoDAO atendimento)
        {
            var verificarCRM = new VerificarRegistroCRMUseCase(atendimento.Medico.CRM);
            verificarCRM.Verificar();

            var medico = _medicoGateway.ObterPorIdentificacao(atendimento.Medico.CRM);
            var paciente = _pacienteGateway.ObterPorIdentificacao(atendimento.Paciente.Identificacao);

            var atendimentoEntity = AtendimentoMedicoEntityAdapter.FromDAO(atendimento, medico?.Nome, paciente?.Nome);

            var registrarAtendimentoMedico = new RegistrarAtendimentoUseCase(atendimentoEntity);
            registrarAtendimentoMedico.Verificar();

            _atendimentoGateway.RegistrarAtendimentoMedico(atendimentoEntity);

            return AtendimentoMedicoAdapter.FromEntityToJson(atendimentoEntity);
        }

        public string IncluirAtendimento(AtendimentoMedicoDAO atendimento)
        {
            var verificarCRM = new VerificarRegistroCRMUseCase(atendimento.Medico.CRM);
            verificarCRM.Verificar();

            var medico = _medicoGateway.ObterPorIdentificacao(atendimento.Medico.CRM);
            var paciente = _pacienteGateway.ObterPorIdentificacao(atendimento.Paciente.Identificacao);

            var atendimentoEntity = AtendimentoMedicoEntityAdapter.FromDAO(atendimento, medico?.Nome, paciente?.Nome);

            var registrarAtendimentoMedico = new RegistrarAtendimentoUseCase(atendimentoEntity);
            registrarAtendimentoMedico.Verificar();

            _atendimentoGateway.RegistrarAtendimentoMedico(atendimentoEntity);

            return AtendimentoMedicoAdapter.FromEntityToJson(atendimentoEntity);
        }

        public List<AtendimentoMedicoDAO> ListarAtendimentosPorData(int dateFormatyyyyMMdd)
        {
            DateTime data = DateTime.ParseExact(dateFormatyyyyMMdd.ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("pt-BR", true));
            
            var atendimentos = _atendimentoGateway.ObterAtendimentosPorData(data);
            return atendimentos?.Select(e => AtendimentoDaoAdapter.FromEntity(e)).ToList();
        }

        public List<AtendimentoMedicoDAO> ListarAtendimentosPorMedico(string medicoId)
        {
            var atendimentos = _atendimentoGateway.ObterAtendimentosPorMedico(medicoId);
            return atendimentos?.Select(e => AtendimentoDaoAdapter.FromEntity(e)).ToList();
        }

        public List<AtendimentoMedicoDAO> ListarAtendimentosPorPaciente(string pacienteId)
        {
            var atendimentos = _atendimentoGateway.ObterAtendimentosPorPaciente(pacienteId);
            return atendimentos?.Select(e => AtendimentoDaoAdapter.FromEntity(e)).ToList();
        }
    }
}