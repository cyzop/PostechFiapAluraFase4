using PosTech.Consultorio.Entities;

namespace PosTech.Consultorio.Tests.UnitTests.Entities
{
    public class CRMEntityTest
    {
        [Fact(DisplayName = "Teste unitário de validação de formato do CRM")]
        [Trait("MedicoEntity", "Teste unitário de validação de formato do CRM do Médico")]
        public void Should_Create_New_CRMEntity()
        {
            const string crmFake = "123456-RJ";

            //Arrange
            var entidade = new CRMEntity(crmFake);

            //Act
            var act = entidade != null;

            //Assert
            Assert.Equal(true, act);
        }
    }
}
