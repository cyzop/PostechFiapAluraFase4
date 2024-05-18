using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.AtendimentoMedico
{
    public class AtualizarAtendimentoMedicoUseCase
    {
        private readonly AtendimentoMedicoEntity _atendimentoMedico;
        private readonly AtendimentoMedicoEntity _registroBase;

        public AtualizarAtendimentoMedicoUseCase(AtendimentoMedicoEntity atendimentoMedico, AtendimentoMedicoEntity registrobase)
        {
            _atendimentoMedico = atendimentoMedico;
            _registroBase = registrobase;
        }

        public void Verificar()
        {
            if (string.IsNullOrEmpty(_atendimentoMedico?.Medico.Nome))
                throw new Exception($"Atendimento médico inválido, o médico não foi localizado!");

            if (string.IsNullOrEmpty(_atendimentoMedico?.Paciente.Nome))
                throw new Exception($"Atendimento médico inválido, o paciente não foi localizado!");

            if(_atendimentoMedico.Id != _registroBase.Id)
                throw new Exception($"Atendimento médico {_registroBase.Id} não encontrado!");
        }
    }
}
