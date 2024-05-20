using PosTech.Consultorio.Adapters.Data;
using PosTech.Consultorio.Adapters.OutPut;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Tests.UnitTests.Adapters
{
    public class ClienteAdapterTest
    {
        [Fact(DisplayName = "Teste unitário do Adapter de serialização de entidate Paciente para Json")]
        [Trait("MedicoEntity", "Teste unitário do Adapter de serialização de entidate Paciente para Json")]
        public void Should_Serialize_EntityToJson()
        {
            //Arrange
            var entidade = new PacienteEntity("1234567", "nome", DateTime.Now.AddYears(-50), "teste@teste.com");

            //Act
            var act = PacienteAdapter.FromEntityToJson(entidade);

            var jsonObject = System.Text.Json.JsonSerializer.Deserialize<PacienteAdapterData>(act);

            //Assert
            Assert.Equal(true, jsonObject != null);
            Assert.Equal(true, jsonObject.Identificacao == entidade.Identificacao);
            Assert.Equal(true, jsonObject.Nome == entidade.Nome);
        }

        [Fact(DisplayName = "Teste unitário do Adapter de serialização de DAO Paciente para Json")]
        [Trait("MedicoDao", "Teste unitário do Adapter de serialização de DAO Paciente para Json")]
        public void Should_Serialize_DaoToJson()
        {
            //Arrange
            var dao = new PacienteDao()
            {
                Identificacao = "1234567",
                Nome = "nome",
                DataNascimento = DateTime.Now.AddYears(-50),
                Email = "teste@teste.com"
            };

            //Act
            var act = PacienteAdapter.FromDaoToJson(dao);

            var jsonObject = System.Text.Json.JsonSerializer.Deserialize<PacienteDao>(act);

            //Assert
            Assert.Equal(true, jsonObject != null);
            Assert.Equal(true, jsonObject.Identificacao == dao.Identificacao);
            Assert.Equal(true, jsonObject.Nome == dao.Nome);
        }
    }
}
