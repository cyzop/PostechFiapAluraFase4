namespace PosTech.Consultorio.Adapters.Data
{
    public class MedicoAdapterData : PessoaAdapterData
    {
        public required string CRM { get; set; }
        public required DateTime DataEmissao { get; set; }
        public string Especialidade { get; set; }
    }
}
