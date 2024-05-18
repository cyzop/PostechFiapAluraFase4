using System.Globalization;

namespace PosTech.Consultorio.UseCases
{
    public class FormatarNomeUseCase
    {
        private string _value;

        public FormatarNomeUseCase(string value)
        {
            _value = value;
        }

        public string Formatar()
        {
            TextInfo nomeInfo = CultureInfo.CurrentCulture.TextInfo;
            return nomeInfo.ToTitleCase(_value);
        }
    }
}
