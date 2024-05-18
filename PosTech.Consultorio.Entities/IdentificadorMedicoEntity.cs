namespace PosTech.Consultorio.Entities
{
    public class IdentificadorMedicoEntity
    {
        public string Nome { get; }
        public string CRM { get; }

        public IdentificadorMedicoEntity(string nome, string cRM)
        {
            Nome = nome;
            CRM = cRM;

            ValidadeEntity();
        }

        public void ValidadeEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(CRM, "O CRN do médico não pode estar vazio!");
        }
    }
}
