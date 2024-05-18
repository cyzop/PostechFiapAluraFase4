namespace PosTech.Consultorio.Entities
{
    public class PessoaEntity
    {
        public string Nome { get; }
        public DateTime DataNascimento { get; }

        public PessoaEntity(string nome, DateTime dataNascimento)
        {
            Nome = nome;
            DataNascimento = dataNascimento;
        }
    }
}
