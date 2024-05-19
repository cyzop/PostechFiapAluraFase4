using PosTech.Consultorio.Adapters;
using PosTech.Consultorio.Adapters.Entity;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Interfaces.Controller;
using PosTech.Consultorio.Interfaces.Gateways;
using PosTech.Consultorio.UseCases.Medico;

namespace PosTech.Consultorio.Controllers
{
    public class MedicoController : IMedicoController
    {
        private readonly IMedicoGateway _medicoGateway;

        public MedicoController(IMedicoGateway medicoGateway)
        {
            _medicoGateway = medicoGateway;
        }

        public string AtualizarMedico(MedicoDAO medico)
        {
            var verificarCRM = new VerificarRegistroCRMUseCase(medico.CRM);
            verificarCRM.Verificar();

            var medicoBase = _medicoGateway.ObterPorIdentificacao(medico.CRM);
          
            var medicoeEntity = MedicoEntityAdapter.FromDAO(medico);

            var registroAtualizar = new AtualizarMedicoUseCase(medicoeEntity, medicoBase);
            registroAtualizar.VerificaNovo();

            //RN formatar nome
            var nomeFormatter = new FormatarNomeMedicoUseCase(medicoeEntity);
            var nomeFormatado = nomeFormatter.Formatar();

            var crmFormatter = new FormatarCRMMedicoUseCase(nomeFormatado);
            var medicoFormatado = crmFormatter.Formatar();

            _medicoGateway.AtualizarMedico(medicoFormatado);

            return MedicoAdapter.FromEntityToJson(medicoFormatado);
        }

        public List<MedicoDAO> ListarMedicos()
        {
            var medicos = _medicoGateway.ObterMedicos();
            var medicosDao = medicos?.Select(e => new MedicoDAO
            {
                Nome = e.Nome,
                DataNascimento = e.DataNascimento,
                CRM = e.CRM.ToString(),
                DataInscricao = e.DataEmissao,
                Especialidade = e.Especialidade
            });
            return medicosDao?.ToList();
        }

        public string RegistrarMedico(MedicoDAO medico)
        {
            var verificarCRM = new VerificarRegistroCRMUseCase(medico.CRM);
            verificarCRM.Verificar();

            var registroBase = _medicoGateway.ObterPorIdentificacao(medico.CRM);

            var medicoEntity = new 
                MedicoEntity(
                medico.Nome,
                medico.DataNascimento,
                medico.CRM,
                medico.DataInscricao,
                medico.Especialidade);
                                
            var registrarMedico = new RegistrarMedicoUseCase(medicoEntity, registroBase);
            //RN verifica se ainda não existe
            registrarMedico.VerificarNovo();

            //RN formatar nome            
            var nomeFormatter = new FormatarNomeMedicoUseCase(medicoEntity);
            var medicoFormatado = nomeFormatter.Formatar();

            _medicoGateway.IncluirMedico(medicoFormatado);

            return MedicoAdapter.FromEntityToJson(medicoFormatado);
        }

        public void RemoverMedico(IdentificadorMedicoDAO medico)
        {
            var medicoRemover = _medicoGateway.ObterPorIdentificacao(medico.CRM);

            var removerMedico = new RemoverMedicoUseCase(medicoRemover, medico.CRM);
            //RN verifica se existe
            removerMedico.VerificarMedicoExistente();

            _medicoGateway.RemoverMedico(medicoRemover);
        }
    }
}
