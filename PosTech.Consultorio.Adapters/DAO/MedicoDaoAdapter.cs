using PosTech.Consultorio.DAO;

namespace PosTech.Consultorio.Adapters.DAO
{
    public class MedicoDaoAdapter
    {
        public static string ToJson(MedicoDAO medico)
        {
            return System.Text.Json.JsonSerializer.Serialize(medico);
        }
    }
}
