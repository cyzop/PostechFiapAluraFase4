using PosTech.Consultorio.DAO;

namespace PosTech.Consultorio.Interfaces
{
    public interface IPacienteController
    {
        string RegistrarPaciente(PacienteDao pacienteDAO);
        string AtualizarPaciente(PacienteDao pacienteDAO);
        IEnumerable<PacienteDao> ListarPacientes();
        void RemoverPaciente(string identificacao);
       
    }
}
