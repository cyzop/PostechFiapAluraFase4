using Bogus;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Tests.Fixtures
{
    public class PacienteTestFixture
    {
        private readonly Faker _faker;

        public PacienteTestFixture()
        {
            _faker = new Faker();
        }

        public PacienteEntity GerarPacienteValido()
        {
            var identificador = _faker.Random.Number().ToString();
            var email = _faker.Person.Email;
            var nome = _faker.Name.FullName();

            return new PacienteEntity(identificador, nome, DateTime.Today.AddYears(-10), email); 
        }

        public PacienteEntity GerarPacienteNomeVazio()
        {
            var identificador = _faker.Random.Number().ToString();
            var email = _faker.Person.Email;

            return new PacienteEntity(identificador, string.Empty, DateTime.Today.AddYears(-10), email);
        }

        public PacienteEntity GerarPacienteDataInvalida()
        {
            var identificador = _faker.Random.Number().ToString();
            var email = _faker.Person.Email;
            var nome = _faker.Name.FullName();

            return new PacienteEntity(identificador, nome, DateTime.Today.AddDays(2), email);
        }
    }
}
