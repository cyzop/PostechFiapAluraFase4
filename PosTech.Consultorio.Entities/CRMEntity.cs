namespace PosTech.Consultorio.Entities
{
    public class CRMEntity
    {
        private readonly string[] partes;

        public CRMEntity(string value)
        {
            partes = value.Split("-");
            ValidadeEntity();
        }

        public void ValidadeEntity()
        {
            AssertionConcern.AssertArgumentNumber(partes.Length, 2, 2, "O CRM está inválido, ele não pode estar vazio e deve estar no formato number-UF, onde o number pode conter até 9 números!");
            AssertionConcern.AssertArgumentIntegerParsed(partes[0], $"O CRM está inválido, valor {partes[0]} não é um número inteiro!");
            AssertionConcern.AssertArgumentNumber(int.Parse(partes[0]), 0, 9999999, "O número do CRM deve ser maior que 1 e só pode ter até 9 dígitos!");
            AssertionConcern.AssertArgumentLength(partes[1], 2, 2, "A UF do CRM está inválida, ela deve ter apenas 2 caracteres!");
        }

        public override string ToString()
        {
            return $"{partes[0]}-{partes[1]}";
        }
    }
}
