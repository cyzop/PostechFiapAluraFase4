using System.Data;
using System.Xml.Serialization;

namespace PosTech.Consultorio.Entities
{
    public class AssertionConcern
    {
        public static void AssertArgumentNotEmpty(string stringValue, string message)
        {
            if (string.IsNullOrEmpty(stringValue)) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentNotNull(object objectData, string message)
        {
            if(objectData == null) {  throw new ArgumentException(message);}
        }

        public static void AssertArgumentLength(string stringValue, int minLength, int maxLength, string message)
        {
            if (stringValue.Length < minLength || stringValue.Length > maxLength) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentDate(DateTime dateValue, DateTime minDate, DateTime maxData, string message)
        {
            if(dateValue <  minDate || dateValue > maxData) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentMaxDate(DateTime dateValue, DateTime maxData, string message)
        {
            if (dateValue > maxData) { throw new ArgumentException(message); }
        }
        public static void AssertArgumentMinDate(DateTime dateValue, DateTime minData, string message)
        {
            if (dateValue < minData) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentNumber(int number, int minValue, int maxValue, string message) {
            if (number < minValue || number > maxValue ) { throw new ArgumentException(message); }
        }

        public static void AssertArgumentIntegerParsed(string strNumber, string message)
        {
            if(! int.TryParse(strNumber, out var value)) { throw new ArgumentException(message); }
        }

    }
}
