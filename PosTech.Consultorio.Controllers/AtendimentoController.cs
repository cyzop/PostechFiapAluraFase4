using PosTech.Consultorio.Adapters;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.UseCases.AtendimentoMedico;

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
            var medico = _medicoGateway.ObterPorIdentificacao(atendimento.Medico.CRM);
            var paciente = _pacienteGateway.ObterPorIdentificacao(atendimento.Paciente.Identificacao);

            var atendimentoEntity = new AtendimentoMedicoEntity(
                atendimento.Id,
                atendimento.DataAtendimento,
                atendimento.Anamnese,
                atendimento.Sintoma,
                atendimento.Diagnostico,
                atendimento.Diagnostico,
                new IdentificadorMedicoEntity(
                    medico?.Nome,
                    atendimento.Medico.CRM),
                new IdentificadorPacienteEntity(
                    paciente?.Nome,
                    atendimento.Paciente.Identificacao));

            var registrarAtendimentoMedico = new RegistrarAtendimentoUseCase(atendimentoEntity);
            //RN verifica se ainda não existe
            registrarAtendimentoMedico.Verificar();

            _atendimentoGateway.RegistrarAtendimentoMedico(atendimentoEntity);

            return AtendimentoMedicoAdapter.FromEntityToJson(atendimentoEntity);
        }

        public string IncluirAtendimento(AtendimentoMedicoDAO atendimento)
        {
            var medico = _medicoGateway.ObterPorIdentificacao(atendimento.Medico.CRM);
            var paciente = _pacienteGateway.ObterPorIdentificacao(atendimento.Paciente.Identificacao);

            var atendimentoEntity = new AtendimentoMedicoEntity( 
                atendimento.Id,
                atendimento.DataAtendimento,
                atendimento.Anamnese,
                atendimento.Sintoma,
                atendimento.Diagnostico,
                atendimento.Diagnostico,
                new IdentificadorMedicoEntity(
                    medico?.Nome,
                    atendimento.Medico.CRM),
                new IdentificadorPacienteEntity(
                    paciente?.Nome,
                    atendimento.Paciente.Identificacao));

            var registrarAtendimentoMedico = new RegistrarAtendimentoUseCase(atendimentoEntity);
            //RN verifica se ainda não existe
            registrarAtendimentoMedico.Verificar();

            _atendimentoGateway.RegistrarAtendimentoMedico(atendimentoEntity);

            return AtendimentoMedicoAdapter.FromEntityToJson(atendimentoEntity);
        }

        public List<AtendimentoMedicoDAO> ListarAtendimentosPorData(int dateFormatyyyyMMdd)
        {
            DateTime data = DateTime.ParseExact(dateFormatyyyyMMdd.ToString(), "yyyyMMdd", new System.Globalization.CultureInfo("pt-BR", true));
            
            var atendimentos = _atendimentoGateway.ObterAtendimentosPorData(data);
            var atendimentosMedicoDao = atendimentos?.Select(e => new AtendimentoMedicoDAO()
            {
                Anamnese = e.Anamnese,
                DataAtendimento = e.DataAtendimento,                
                Diagnostico = e.Diagnostico,
                Sintoma = e.Sintoma,
                Tratamento = e.Tratamento,
                Medico = new IdentificadorMedicoDAO()
                {
                    CRM = e.Medico.CRM,
                    Nome = e.Medico.Nome
                },
                Paciente = new IdentificadorPacienteDAO() { 
                    Identificacao = e.Paciente.Identificacao,
                    Nome = e.Paciente.Nome
                }
            });
            return atendimentosMedicoDao?.ToList();
        }

        public List<AtendimentoMedicoDAO> ListarAtendimentosPorMedico(string medicoId)
        {
            var atendimentos = _atendimentoGateway.ObterAtendimentosPorMedico(medicoId);
            var atendimentosMedicoDao = atendimentos?.Select(e => new AtendimentoMedicoDAO()
            {
                Anamnese = e.Anamnese,
                DataAtendimento = e.DataAtendimento,
                Diagnostico = e.Diagnostico,
                Sintoma = e.Sintoma,
                Tratamento = e.Tratamento,
                Medico = new IdentificadorMedicoDAO()
                {
                    CRM = e.Medico.CRM,
                    Nome = e.Medico.Nome
                },
                Paciente = new IdentificadorPacienteDAO()
                {
                    Identificacao = e.Paciente.Identificacao,
                    Nome = e.Paciente.Nome
                }
            });
            return atendimentosMedicoDao?.ToList();
        }

        public List<AtendimentoMedicoDAO> ListarAtendimentosPorPaciente(string pacienteId)
        {
            var atendimentos = _atendimentoGateway.ObterAtendimentosPorPaciente(pacienteId);
            var atendimentosMedicoDao = atendimentos?.Select(e => new AtendimentoMedicoDAO()
            {
                Anamnese = e.Anamnese,
                DataAtendimento = e.DataAtendimento,
                Diagnostico = e.Diagnostico,
                Sintoma = e.Sintoma,
                Tratamento = e.Tratamento,
                Medico = new IdentificadorMedicoDAO()
                {
                    CRM = e.Medico.CRM,
                    Nome = e.Medico.Nome
                },
                Paciente = new IdentificadorPacienteDAO()
                {
                    Identificacao = e.Paciente.Identificacao,
                    Nome = e.Paciente.Nome
                }
            });
            return atendimentosMedicoDao?.ToList();
        }
    }
}