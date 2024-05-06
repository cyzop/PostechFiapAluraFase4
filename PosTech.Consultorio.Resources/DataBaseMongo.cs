using PosTech.Consultorio.Interfaces;

namespace PosTech.Consultorio.Resources
{
    public class DataBaseMongo : IDatabaseClient
    {
        private readonly IMongoCollection<PacienteDataModel> _database;
    }
}