using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PosTech.Consultorio.Resource.NoSql.Model
{
    public class PacienteModel : IdentityModel
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
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataNascimento
        {
            get;
            private set;
        }
        public string Email
        {
            get;
            private set;
        }

        public PacienteModel(string identificacao, string nome, DateTime dataNascimento, string email) : base(null)
        {
            Identificacao = identificacao;
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
        }

        public PacienteModel(string id, string identificacao, string nome, DateTime dataNascimento, string email) : base(id)
        {
            Identificacao = identificacao;
            Nome = nome;
            DataNascimento = dataNascimento;
            Email = email;
        }

    }
}
