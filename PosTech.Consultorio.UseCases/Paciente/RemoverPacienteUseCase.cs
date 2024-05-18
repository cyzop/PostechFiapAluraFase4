using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Paciente
{
    public class RemoverPacienteUseCase : PessoaUseCaseBase
    {
        private readonly string _identificadorRemocao;
        private PacienteEntity _paciente;

        public RemoverPacienteUseCase(PacienteEntity paciente, string identificacao) : base(paciente)
        {
            _identificadorRemocao = identificacao;
            _paciente = paciente;
        }

        public string VerificarPacienteExistente()
        {
            if (_paciente?.Identificacao != _identificadorRemocao)
                throw new Exception($"Paciente com identificação {_identificadorRemocao} não encontrado!");

            return _identificadorRemocao;
        }
    }
}
