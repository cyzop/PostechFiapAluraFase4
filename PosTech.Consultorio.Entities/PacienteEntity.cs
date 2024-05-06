namespace PosTech.Consultorio.Entities
{
    public class PacienteEntity
    {
        public string Identificacao { get; }
        public string Nome { get; }
        public DateTime DataNascimento {  get; }
        public string? Email { get; }

        public PacienteEntity(string identificacao, string nome, DateTime dataNascimento, string? email)
        {
            Identificacao = identificacao;
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
        }
    }
}