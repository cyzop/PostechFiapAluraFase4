using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases
{
    public class RemoverPacienteUseCase : PacienteUseCaseBase
    {
        private readonly string _identificadorRemocao;

        public RemoverPacienteUseCase(PacienteEntity paciente, string identificacao) : base(paciente)
        {
            _identificadorRemocao = identificacao;
        }

        public string VerificaPaciente()
        {
            if (base.Paciente?.Identificacao != _identificadorRemocao)
                throw new Exception($"Paciente com identificação {_identificadorRemocao} não encontrado!");

            return _identificadorRemocao;
        }
    }
}
