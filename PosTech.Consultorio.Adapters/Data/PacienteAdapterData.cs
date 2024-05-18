namespace PosTech.Consultorio.Adapters.Data
{
    public class PacienteAdapterData : PessoaAdapterData
    {
        public required string Identificacao { get; set; }
        public string? Email { get; set; }
    }
}
