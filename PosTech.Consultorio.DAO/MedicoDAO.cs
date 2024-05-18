namespace PosTech.Consultorio.DAO
{
    public class MedicoDAO : PessoaDAO
    {
        public required string CRM { get; set; }
        public required DateTime DataInscricao { get; set; }
        public required string Especialidade { get; set; }
    }
}
