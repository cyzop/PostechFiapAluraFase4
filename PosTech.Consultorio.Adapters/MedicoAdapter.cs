using PosTech.Consultorio.Adapters.Data;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Adapters
{
    public class MedicoAdapter
    {
        public static string FromEntityToJson(MedicoEntity medico)
        {
            var medicoData = new MedicoAdapterData
            {
                Nome = medico.Nome,
                DataNascimento = medico.DataNascimento,
                CRM = medico.CRM.ToString(),
                DataEmissao = medico.DataEmissao,
                Especialidade = medico.Especialidade,
            };

            return System.Text.Json.JsonSerializer.Serialize<MedicoAdapterData>(medicoData);
        }
    }
}
