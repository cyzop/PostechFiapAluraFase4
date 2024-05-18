namespace PosTech.Consultorio.Resource.NoSql.Model
{
    public class PacienteAtendimentoModel
    {
        public string Identificacao 
        { 
            get; 
            private set; 
        }

        public string Nome
        {
            get;
            private set;
        }

        public PacienteAtendimentoModel(string identificacao, string nome)
        {
            Identificacao = identificacao;
            Nome = nome;
        }
    }
}
