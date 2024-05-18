using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases.Medico
{
    public class FormatarCRMMedicoUseCase
    {
        private readonly MedicoEntity _medico;

        public FormatarCRMMedicoUseCase(MedicoEntity medico)
        {
            _medico = medico;
        }

        public MedicoEntity Formatar()
        {
            if (_medico != null)
            {
                FormatarStringCRMUseCase crmFormatter = new FormatarStringCRMUseCase(_medico.CRM.ToString());
          
                var crmFormatado = crmFormatter.Formatar();

                return new MedicoEntity(_medico.Nome,
                    _medico.DataNascimento,
                    crmFormatado,
                    _medico.DataEmissao,
                    _medico.Especialidade);
            }
            else
                return _medico;

        }
    }
}
