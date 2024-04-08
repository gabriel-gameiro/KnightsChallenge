using KnightsChallenge.Core.Models;
using KnightsChallenge.Core.Services;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public required string Name { get; set; }

        public required string Nickname { get; set; }

        public required DateTime Birthday { get; set; }

        public List<Weapon>? Weapons { get; set; }

        public required Attributes Attributes { get; set; }

        public required string KeyAttribute { get; set; }

        public virtual int Experience { 
            get 
            {
                int age = (DateTime.Now.Year - Birthday.Year);
                if (age < 7)
                    return 0; 
                else
                {
                    return (int)Math.Floor((age - 7) * Math.Pow(22, 1.45));
                }
            } 
        }

        public virtual int Attack
        {
            get
            {
                int attackValue = 10;
                
                // Soma o dano das armas equipadas. (Imagino que um ladino possa ter 2 adagas equipadas)
                int? weaponsDamage = Weapons?.Where(e => e.Equipped).Sum(e => e.Mod);
                if (weaponsDamage.HasValue)
                    attackValue += weaponsDamage.Value;

                // Aplica o modificador do atributo chave
                int attributeValue = this.Attributes.GetByName(KeyAttribute);
                attackValue += Utils.ModValue(attributeValue);

                return attackValue;
            }
        }

        public KnightDTO ToDTO()
        {
            return new KnightDTO()
            {
                Id = Id,
                Nome = Name,
                Idade = (DateTime.Now.Year - Birthday.Year),
                Armas = (Weapons != null ? Weapons.Count() : 0),
                Ataque = Attack,
                Atributo = KeyAttribute,
                Exp = Experience
            };
        }

    }
}
