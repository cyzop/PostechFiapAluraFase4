using PosTech.Consultorio.Entities;
using PosTech.Consultorio.Resource.NoSql.Model;

namespace PosTech.Consultorio.Resource.NoSql.Adapter
{
    public class PacienteModelAdapter
    {
        public static PacienteModel ModelFromEntity(string dbId, PacienteEntity paciente)
        {
            return new PacienteModel(dbId,
               paciente.Identificacao,
               paciente.Nome,
               paciente.DataNascimento,
               paciente.Email);
        }

        public static PacienteModel ModelFromEntity(PacienteEntity paciente)
        {
            return new PacienteModel(paciente.Identificacao, paciente.Nome, paciente.DataNascimento, paciente.Email);
        }

        public static PacienteEntity EntityFromModel(PacienteModel paciente)
        {
            return new PacienteEntity(paciente.Identificacao, paciente.Nome, paciente.DataNascimento, paciente.Email);
        }
    }
}
