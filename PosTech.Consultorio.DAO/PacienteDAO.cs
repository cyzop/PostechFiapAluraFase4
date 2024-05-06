namespace PosTech.Consultorio.DAO
{
    public class PacienteDao
    {
        public required string Nome { get; set; }
        public required string Identificacao { get; set; }
        public required DateTime DataNascimento { get; set; }
        public string? Email { get; set; }
    }
}