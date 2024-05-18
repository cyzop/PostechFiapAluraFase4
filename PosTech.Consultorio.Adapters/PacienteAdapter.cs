

using PosTech.Consultorio.Adapters.Data;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Adapters
{
    public class PacienteAdapter
    {
        public static string FromDaoToJson(PacienteDao paciente)
        {
                var pacienteData = new PacienteAdapterData { Nome = paciente.Nome,
                    Identificacao = paciente.Identificacao,
                    DataNascimento = paciente.DataNascimento,
                    Email = paciente.Email,
                };

            return System.Text.Json.JsonSerializer.Serialize<PacienteAdapterData>(pacienteData);
        }

        public static string FromEntityToJson(PacienteEntity paciente)
        {
            var pacienteData = new PacienteAdapterData
            {
                Nome = paciente.Nome,
                Identificacao = paciente.Identificacao,
                DataNascimento = paciente.DataNascimento,
                Email = paciente.Email,
            };

            return System.Text.Json.JsonSerializer.Serialize<PacienteAdapterData>(pacienteData);
        }
    }
}