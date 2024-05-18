namespace PosTech.Consultorio.DAO
{
    public class PacienteDao : PessoaDAO
    {
        public required string Identificacao { get; set; }
        public string? Email { get; set; }
    }
}