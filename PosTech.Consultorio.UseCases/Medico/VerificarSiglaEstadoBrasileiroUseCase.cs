namespace PosTech.Consultorio.UseCases.Medico
{
    public class VerificarSiglaEstadoBrasileiroUseCase
    {
        //TODO: listagem de siglas para validação deve vir de uma fonte externa (api do ibge por exemplo)
        private string[] ESTADOS_SIGLA = new string[] { "RO", "AC", "AM", "RR", "PA", "AP", "TO", "MA", "PI", "CE", "RN", "PB", "PE", "AL", "SE", "BA", "MG", "ES", "RJ", "SP", "PR", "SC", "RS", "MS", "MT", "GO", "DF" };

        private readonly string _sigla;

        public VerificarSiglaEstadoBrasileiroUseCase(string sigla)
        {
            _sigla = sigla.Trim().ToUpper();
        }

        public void Verificar()
        {
            if(Array.IndexOf(ESTADOS_SIGLA, _sigla)<0)
                throw new Exception($"Sigla {_sigla} inválida, esta sigla não corresponde à um Estado Brasileiro!");
        }
    }
}
