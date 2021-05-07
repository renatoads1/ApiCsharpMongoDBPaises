using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace consomeapi
{
    class Regiao
    {
        [BsonId]
        public ObjectId id { get; set; }

        [BsonElement("region")]
        public string region { get; set; }
        
        [BsonElement("country")]
        public string country { get; set; }

        public Regiao()
        {
        }

        public Regiao(string region, string country)
        {
            this.region = region;
            this.country = country;
        }

        public override string ToString()
        {
            return string.Format($"{region} - {country}");
        }
    }
}
