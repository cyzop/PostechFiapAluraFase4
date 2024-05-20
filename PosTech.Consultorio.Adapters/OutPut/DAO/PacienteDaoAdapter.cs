using PosTech.Consultorio.DAO;

namespace PosTech.Consultorio.Adapters.DAO
{
    public class PacienteDaoAdapter
    {
        public static string ToJson(PacienteDao paciente)
        {
            return System.Text.Json.JsonSerializer.Serialize(paciente);
        }
    }
}
