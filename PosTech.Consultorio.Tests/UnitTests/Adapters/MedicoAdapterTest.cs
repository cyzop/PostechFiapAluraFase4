using PosTech.Consultorio.Adapters;
using PosTech.Consultorio.Adapters.Data;
using PosTech.Consultorio.Adapters.OutPut;
using PosTech.Consultorio.DAO;
using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Tests.UnitTests.Adapters
{
    public class MedicoAdapterTest
    {
        [Fact(DisplayName = "Teste unitário do Adapter de serialização de entidate Medico para Json")]
        [Trait("MedicoEntity", "Teste unitário do Adapter de serialização de entidate Medico para Json")]
        public void Should_Serialize_EntityToJson()
        {
            //Arrange
            var entidade = new MedicoEntity("nome", DateTime.Now.AddYears(-50), "123456-RJ", DateTime.Today.AddYears(-20), "Clínico");

            //Act
            var act = MedicoAdapter.FromEntityToJson(entidade);

            var jsonObject = System.Text.Json.JsonSerializer.Deserialize<MedicoAdapterData>(act);

            //Assert
            Assert.Equal(true, jsonObject != null);
        }
    }
}
