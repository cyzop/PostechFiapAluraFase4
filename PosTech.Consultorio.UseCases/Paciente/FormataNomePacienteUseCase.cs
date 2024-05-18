using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Paciente
{
    public class FormataNomePacienteUseCase
    {
        private readonly PacienteEntity _paciente;
        public FormataNomePacienteUseCase(PacienteEntity novoPaciente)
        {
            _paciente = novoPaciente;
        }

        public PacienteEntity Formatar()
        {
            if (_paciente != null)
            {
                FormatarNomeUseCase formatador = new FormatarNomeUseCase(_paciente.Nome);

                var nomeFormatado = formatador.Formatar();
                return new PacienteEntity(_paciente.Identificacao,
                    nomeFormatado,
                    _paciente.DataNascimento,
                    _paciente.Email);
            }
            else
                return _paciente;

        }
    }
}
