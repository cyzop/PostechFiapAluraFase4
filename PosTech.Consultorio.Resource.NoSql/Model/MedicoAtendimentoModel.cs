namespace PosTech.Consultorio.Resource.NoSql.Model
{
    public class MedicoAtendimentoModel
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

        public MedicoAtendimentoModel(string identificacao, string nome)
        {
            Identificacao = identificacao;
            Nome = nome;
        }
    }
}
