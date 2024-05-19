namespace PosTech.Consultorio.Entities
{
    public class PacienteEntity : PessoaEntity
    {
      
        public string? Email { get; }
        public string Identificacao { get; }

        public PacienteEntity(string identificacao, string nome, DateTime dataNascimento, string? email) : base(nome, dataNascimento)
        {
            Email = email;
            Identificacao = identificacao;

            ValidadeEntity();
        }

        public void ValidadeEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Identificacao, "A Identificação do paciente não pode estar vazia!");
            AssertionConcern.AssertArgumentNotEmpty(base.Nome, "O Nome do paciente não pode estar vazio!");
            //AssertionConcern.AssertArgumentDate(base.DataNascimento, DateTime.Today.AddYears(-110), DateTime.Today, "Data de nascimento do paciente inválida!");
            AssertionConcern.AssertArgumentMinDate(base.DataNascimento, DateTime.Today.AddYears(-110), "Data de nascimento do paciente inválida, ele não pode ter mais de 110 anos!");
            AssertionConcern.AssertArgumentMaxDate(base.DataNascimento, DateTime.Today, "Data de nascimento do paciente inválida, ele não pode nascer no futuro!");
        }
    }
}