using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.UseCases
{
    public class PessoaUseCaseBase
    {
        private readonly PessoaEntity _entityBase;

        public PessoaUseCaseBase(PessoaEntity pessoaBase)
        {
            _entityBase = pessoaBase;
        }

        protected PessoaEntity EntityBase
        {
            get { return _entityBase; }
        }
    }
}
