using PosTech.Consultorio.DAO;

namespace PosTech.Consultorio.Interfaces.Controller
{
    public interface IMedicoController
    {
        string AtualizarMedico(MedicoDAO medico);
        List<MedicoDAO> ListarMedicos();
        string RegistrarMedico(MedicoDAO medico);
        void RemoverMedico(IdentificadorMedicoDAO medico);
    }
}
