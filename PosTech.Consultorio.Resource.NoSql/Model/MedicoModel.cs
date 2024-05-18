using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PosTech.Consultorio.Resource.NoSql.Model
{
    public class MedicoModel : IdentityModel
    {
        public MedicoModel(string id, string identificacao, DateTime dataEmissao, string nome, DateTime dataNascimento, string especialidade) : base(id)
        {
            Identificacao = identificacao;
            DataEmissao = dataEmissao;
            Nome = nome;
            DataNascimento = dataNascimento;
            Especialidade = especialidade;
        }

        public MedicoModel(string identificacao, DateTime dataEmissao, string nome, DateTime dataNascimento, string especialidade):base(null)
        {
            Identificacao = identificacao;
            DataEmissao = dataEmissao;
            Nome = nome;
            DataNascimento = dataNascimento;
            Especialidade = especialidade;
        }

        public string Identificacao { get; private set; }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataEmissao
        {
            get;
            private set;
        }
        public string Nome
        {
            get;
            private set;
        }
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataNascimento
        {
            get;
            private set;
        }
        public string Especialidade
        {
            get;
            private set;
        }
    }
}
