using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Paciente
{
    public class AtualizarPacienteUseCase
    {
        private readonly PacienteEntity _novoPaciente;
        private readonly PacienteEntity _paciente;

        public AtualizarPacienteUseCase(PacienteEntity novoPaciente, PacienteEntity registroBase) 
        {
            _novoPaciente = novoPaciente;
            _paciente = registroBase;
        }

        public PacienteEntity VerificarNovo()
        {
            if (_novoPaciente?.Identificacao != _paciente?.Identificacao)
                throw new Exception($"Paciente {_novoPaciente.Nome} não encontrado!");

            return _novoPaciente;
        }
    }
}
