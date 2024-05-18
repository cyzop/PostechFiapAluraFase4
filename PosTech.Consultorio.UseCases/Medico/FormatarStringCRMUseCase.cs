namespace PosTech.Consultorio.UseCases.Medico
{
    public class FormatarStringCRMUseCase
    {
        private readonly string _value;

        public FormatarStringCRMUseCase(string value)
        {
            _value = value;
        }

        public string Formatar()
        {
            return _value.ToUpper();
        }
    }
}
