using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Resource.NoSql.Model;

namespace PosTech.Consultorio.Resource.NoSql.Adapter
{
    public class MedicoModelAdapter
    {
        public static MedicoModel ModelFromEntity(string dbId, MedicoEntity medico)
        {
            return new MedicoModel(dbId, medico.CRM.ToString(), medico.DataEmissao, medico.Nome, medico.DataNascimento, medico.Especialidade);
        }
        public static MedicoModel ModelFromEntity(MedicoEntity medico)
        {
            return new MedicoModel(medico.CRM.ToString(), medico.DataEmissao, medico.Nome, medico.DataNascimento, medico.Especialidade);
        }

        public static MedicoEntity EntityFromModel(MedicoModel medico)
        {
            return new MedicoEntity(medico.Nome,
               medico.DataNascimento,
               new CRMEntity(medico.Identificacao),
               medico.DataEmissao,
               medico.Especialidade);
        }
    }
}
