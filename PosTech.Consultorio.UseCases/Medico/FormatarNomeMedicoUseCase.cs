using PosTech.Consultorio.Entities;
using System.Globalization;

namespace PosTech.Consultorio.UseCases.Medico
{
    public class FormatarNomeMedicoUseCase
    {
        private readonly MedicoEntity _medico;
        public FormatarNomeMedicoUseCase(MedicoEntity novoMedico)
        {
            _medico = novoMedico;
        }

        public MedicoEntity Formatar()
        {
            if (_medico != null)
            {
                FormatarNomeUseCase nameFormatter = new FormatarNomeUseCase(_medico.Nome);

                var nomeFormatado = nameFormatter.Formatar();

                return new MedicoEntity(nomeFormatado, 
                    _medico.DataNascimento, 
                    _medico.CRM, 
                    _medico.DataEmissao, 
                    _medico.Especialidade);
            }
            else
                return _medico;

        }
    }
}
