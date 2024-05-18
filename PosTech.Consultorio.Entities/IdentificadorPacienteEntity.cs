namespace PosTech.Consultorio.Entities
{
    public class IdentificadorPacienteEntity
    {
        public string Nome { get; }
        public string Identificacao { get; }

        public IdentificadorPacienteEntity(string nome, string identificacao)
        {
            Nome = nome;
            Identificacao = identificacao;
            ValidadeEntity();
        }

        public void ValidadeEntity()
        {
            AssertionConcern.AssertArgumentNotEmpty(Identificacao, "A Identificação do paciente não pode estar vazia!");
        }
    }
}
