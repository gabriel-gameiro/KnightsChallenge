using KnightsChallenge.Core.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace KnightsChallenge.Core.Entitys
{
    public class Knight
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        //[BsonElement("Name")]
        public string? Name { get; set; }

        public string? Nickname { get; set; }

        public string? Birthday { get; set; }

        public List<Weapon>? Weapons { get; set; }

        public Attributes? Attributes { get; set; }

        public string? KeyAttribute { get; set; }
    }
}
