using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Adapters.Entity
{
    public class MedicoEntityAdapter
    {
        public static MedicoEntity FromDAO(MedicoDAO medico)
        {
            return new MedicoEntity(
                            medico.Nome,
                            medico.DataNascimento,
                            new CRMEntity(medico.CRM),
                            medico.DataInscricao,
                            medico.Especialidade);
        }
    }
}
