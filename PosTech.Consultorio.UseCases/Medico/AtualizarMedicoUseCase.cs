using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Medico
{
    public class AtualizarMedicoUseCase 
    {
        private readonly MedicoEntity _novo;
        private readonly MedicoEntity _medico;

        public AtualizarMedicoUseCase(MedicoEntity novo, MedicoEntity registroBase)
        {
            _novo = novo;
            _medico = registroBase;
        }

        public MedicoEntity VerificaNovo()
        {
            if (_novo?.CRM.ToString() != _medico.CRM.ToString())
                throw new Exception($"Medico {_novo.Nome} não encontrado!");

            return _novo;
        }
    }
}
