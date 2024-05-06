using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases
{
    public class PacienteUseCaseBase
    {
        private readonly PacienteEntity _pacienteBase;

        public PacienteUseCaseBase(PacienteEntity pacienteBase)
        {
            _pacienteBase = pacienteBase;
        }

        protected PacienteEntity Paciente
        {
            get { return _pacienteBase; }
        }
    }
}
