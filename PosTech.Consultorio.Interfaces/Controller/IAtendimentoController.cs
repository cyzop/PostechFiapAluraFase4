using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Interfaces.Gateways;

namespace PosTech.Consultorio.Interfaces.Controller
{
    public interface IAtendimentoController
    {
        string AtualizarAtendimento(AtendimentoMedicoDAO atendimento);
        string IncluirAtendimento(AtendimentoMedicoDAO atendimento);
        List<AtendimentoMedicoDAO> ListarAtendimentosPorData(int dateFormatyyyyMMdd);

        List<AtendimentoMedicoDAO> ListarAtendimentosPorMedico(string medicoId);
        List<AtendimentoMedicoDAO> ListarAtendimentosPorPaciente(string pacienteId);
    }
}
