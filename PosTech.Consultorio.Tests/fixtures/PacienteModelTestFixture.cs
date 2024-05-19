using Bogus;
using PosTech.Consultorio.Resource.NoSql.Model;

namespace PosTech.Consultorio.Tests.fixtures
{
    public class PacienteModelTestFixture
    {
        private readonly Faker _faker;

        public PacienteModelTestFixture()
        {
            _faker = new Faker();
        }

        public List<PacienteModel> GerarListaPacientes(int quantidade = 5)
        {
            var retorno = new List<PacienteModel>();
            for(int i=0; i < quantidade; i++)
                retorno.Add(GerarPacienteModel($"{i+1}"));
            return retorno;
        }

        public PacienteModel GerarPacienteModel(string id = null)
        {
            var identificador = id==null ?_faker.Random.Number().ToString() : id;
            var email = _faker.Person.Email;
            var nome = _faker.Name.FullName();
            var dataNascimento = DateTime.Today.AddYears(-_faker.Random.Number(100));

            return new PacienteModel(Guid.NewGuid().ToString(), identificador, nome, dataNascimento, email);
        }
    }
}
