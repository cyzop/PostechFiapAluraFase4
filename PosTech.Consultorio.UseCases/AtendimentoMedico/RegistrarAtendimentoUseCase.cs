using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.AtendimentoMedico
{
    public class RegistrarAtendimentoUseCase
    {
        private readonly AtendimentoMedicoEntity _atendimentoMedico;

        public RegistrarAtendimentoUseCase(AtendimentoMedicoEntity atendimentoMedico)
        {
            _atendimentoMedico = atendimentoMedico;
        }

        public void Verificar()
        {
            if (string.IsNullOrEmpty(_atendimentoMedico?.Medico.Nome))
                throw new Exception($"Atendimento médico inválido, o médico não foi localizado!");

            if (string.IsNullOrEmpty(_atendimentoMedico?.Paciente.Nome))
                throw new Exception($"Atendimento médico inválido, o paciente não foi localizado!");
        }
    }
}
