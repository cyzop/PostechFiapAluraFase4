namespace PosTech.Consultorio.Entities
{
    public class MedicoEntity : PessoaEntity
    {
        public CRMEntity CRM { get; }
        public DateTime DataEmissao { get; }

        public string Especialidade { get; }


        public MedicoEntity(string nome, DateTime dataNascimento, string crm, DateTime dataEmissao, string especialidade) : base(nome, dataNascimento)
        {
            DataEmissao = dataEmissao;
            Especialidade = especialidade;
            CRM = new CRMEntity(crm);

            ValidadeEntity();
        }
        public MedicoEntity(string nome, DateTime dataNascimento, CRMEntity crm, DateTime dataEmissao, string especialidade) : base(nome, dataNascimento)
        {
            DataEmissao = dataEmissao;
            Especialidade = especialidade;
            CRM = crm;

            ValidadeEntity();
        }
            
        public void ValidadeEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(base.Nome, "O Nome do médico não pode estar vazio!");
            AssertionConcern.AssertArgumentNotEmpty(Especialidade, "A especialidade do médico não pode estar vazia!");
            AssertionConcern.AssertArgumentMinDate(base.DataNascimento, DateTime.Today.AddYears(-70), "Data de nascimento do médico inválida, ele não pode ter mais de 70 anos!");
            AssertionConcern.AssertArgumentMaxDate(base.DataNascimento, DateTime.Today.AddYears(-21), "Data de nascimento do médico inválida, ele não pode ser menor de 21 anos!");
        }
    }
}
