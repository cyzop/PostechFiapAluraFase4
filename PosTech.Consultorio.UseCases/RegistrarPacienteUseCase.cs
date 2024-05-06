using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases
{
    public class RegistrarPacienteUseCase : PacienteUseCaseBase
    {
        private readonly PacienteEntity _novoPaciente;

        public RegistrarPacienteUseCase(PacienteEntity novoPaciente, PacienteEntity pacienteBase) : base(pacienteBase)
        {
            _novoPaciente = novoPaciente;
        }

        public PacienteEntity VerificaNovoPaciente()
        {
            if (_novoPaciente?.Identificacao == base.Paciente?.Identificacao)
                throw new Exception($"Paciente {_novoPaciente.Nome} já cadastrado!");

            return _novoPaciente;
        }
    }
}