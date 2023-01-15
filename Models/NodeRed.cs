using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace BLCoreWebAPI.Models
{
    [BsonIgnoreExtraElements]
    public partial class NodeRedNode
    {
        //[BsonElement("_id")]
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        //public string _Id { get; set; }

        //[BsonElement("id")]
        //public string Id { get; set; }

        [BsonElement("_id")]
        public string _Id { get; set; }

        [BsonElement("type")]
        public string Type { get; set; }

        [BsonElement("z")]
        public string Z { get; set; }

        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("method")]
        public string Method { get; set; }

        [BsonElement("ret")]
        public string Ret { get; set; }

        [BsonElement("paytoqs")]
        public string Paytoqs { get; set; }

        [BsonElement("url")]
        public string Url { get; set; }

        [BsonElement("tls")]
        public string Tls { get; set; }

        [BsonElement("persist")]
        public bool Persist { get; set; }

        [BsonElement("proxy")]
        public string Proxy { get; set; }

        [BsonElement("insecureHTTPParser")]
        public bool InsecureHTTPParser { get; set; }

        [BsonElement("authType")]
        public string AuthType { get; set; }

        [BsonElement("senderr")]
        public bool Senderr { get; set; }

        [BsonElement("headers")]
        public dynamic Headers { get; set; }

        [BsonElement("x")]
        public int X { get; set; }

        [BsonElement("y")]
        public int Y { get; set; }

        [BsonElement("wires")]
        public dynamic Wires { get; set; }

        [BsonElement("info")]
        public string Info { get; set; }
    }
}
