using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Paciente
{
    public class RegistrarPacienteUseCase : PessoaUseCaseBase
    {
        private readonly PacienteEntity _novoPaciente;
        private readonly PacienteEntity _paciente;

        public RegistrarPacienteUseCase(PacienteEntity novoPaciente, PacienteEntity pacienteBase) : base(pacienteBase)
        {
            _novoPaciente = novoPaciente;
            _paciente = pacienteBase;
        }

        public PacienteEntity VerificarNovo()
        {
            if (_novoPaciente?.Identificacao == _paciente?.Identificacao)
                throw new Exception($"Paciente {_novoPaciente.Nome} já cadastrado!");

            return _novoPaciente;
        }
    }
}