using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PosTech.Consultorio.Resource.NoSql.Model
{
    public class AtendimentoModel : IdentityModel
    {
        public MedicoAtendimentoModel Medico 
        { 
            get; 
            private set; 
        }
        public PacienteAtendimentoModel Paciente 
        { 
            get; 
            private set; 
        }
        
        [BsonRepresentation(BsonType.DateTime)]
        public DateTime DataAtendimento 
        { 
            get; 
            private set; 
        }
        public string Anamnese
        { 
            get;
            private set;
        }
        public string Sintoma 
        { 
            get; 
            private set; 
        }
        public string Diagnostico 
        { 
            get; 
            private set; 
        }
        public string Tratamento 
        { 
            get; 
            private set; 
        }

        public AtendimentoModel(string id, MedicoAtendimentoModel medico, PacienteAtendimentoModel paciente, DateTime dataAtendimento, string anamnese, string sintoma, string diagnostico, string tratamento): base(id)
        {
            Medico = medico;
            Paciente = paciente;
            DataAtendimento = dataAtendimento;
            Anamnese = anamnese;
            Sintoma = sintoma;
            Diagnostico = diagnostico;
            Tratamento = tratamento;
        }

        public AtendimentoModel(MedicoAtendimentoModel medico, PacienteAtendimentoModel paciente, DateTime dataAtendimento, string anamnese, string sintoma, string diagnostico, string tratamento) : base(null)
        {
            Medico = medico;
            Paciente = paciente;
            DataAtendimento = dataAtendimento;
            Anamnese = anamnese;
            Sintoma = sintoma;
            Diagnostico = diagnostico;
            Tratamento = tratamento;
        }
    }
}
