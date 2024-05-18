using PosTech.Consultorio.DAO;

namespace PosTech.Consultorio.Adapters.DAO
{
    public static class AtendimentoDaoAdapter
    {
        public static string ToJson(AtendimentoMedicoDAO atendimento)
        {
            return System.Text.Json.JsonSerializer.Serialize(atendimento);
        }
    }
}
