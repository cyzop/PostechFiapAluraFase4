

using PosTech.Consultorio.DAO;

namespace PosTech.Consultorio.Adapters
{
    class PacienteAdapterData
    {
        public required string Nome { get; set; }
        public required string Identificacao { get; set;}
        public required DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
    }
    
    public class PacienteAdapter
    {
        public static string ToJson(PacienteDao paciente)
        {
                var pacienteData = new PacienteAdapterData { Nome = paciente.Nome,
                    Identificacao = paciente.Identificacao,
                    DataNascimento = paciente.DataNascimento,
                    Email = paciente.Email,
                };

            return System.Text.Json.JsonSerializer.Serialize<PacienteAdapterData>(pacienteData);
        }



    }
}