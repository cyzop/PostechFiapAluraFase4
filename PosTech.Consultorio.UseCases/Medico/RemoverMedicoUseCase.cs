using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Medico
{
    public class RemoverMedicoUseCase
    {
        private readonly string _identificadorRemocao;
        private readonly MedicoEntity _medico;

        public RemoverMedicoUseCase(MedicoEntity medico, string identificacao)
        {
            _identificadorRemocao = identificacao;
            _medico = medico;
        }

        public string VerificarMedicoExistente()
        {
            if (_medico?.CRM.ToString() != _identificadorRemocao)
                throw new Exception($"Medico com identificação {_identificadorRemocao} não encontrado!");

            return _identificadorRemocao;
        }
    }
}
