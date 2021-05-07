using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace consomeapi
{
    class Pais
    {
        [BsonElement("name")]
        public string  name { get; set; }
        [BsonElement("code")]
        public string code { get; set; }

        public Pais()
        {
        }

        public Pais(string name, string code)
        {
            this.name = name;
            this.code = code;
        }

        public override string ToString()
        {
            return string.Format($"{name} - {code}");
        }



    }
}
