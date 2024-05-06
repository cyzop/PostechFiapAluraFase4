using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases
{
    public class AtualizarPacienteUseCase : PacienteUseCaseBase
    {
        private readonly PacienteEntity _novoPaciente;

        public AtualizarPacienteUseCase(PacienteEntity novoPaciente, PacienteEntity pacienteBase) : base(pacienteBase)
        {
            _novoPaciente = novoPaciente;
        }

        public PacienteEntity VerificaNovoPaciente()
        {
            if (_novoPaciente?.Identificacao != base.Paciente?.Identificacao)
                throw new Exception($"Paciente {_novoPaciente.Nome} não encontrado!");

            return _novoPaciente;
        }
    }
}
