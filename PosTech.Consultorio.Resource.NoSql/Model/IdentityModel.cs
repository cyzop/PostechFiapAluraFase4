using MongoDB.Bson.Serialization.Attributes;

namespace PosTech.Consultorio.Resource.NoSql.Model
{
    public class IdentityModel
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string Id { get; private set; }

        public IdentityModel(string id)
        {
            Id = id;
        }

        protected void SetId(string id)
        {
            this.Id = id;
        }
    }
}
