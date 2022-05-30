using System.Xml.Serialization;

namespace RFClothingModifier.Models
{
    public class Clothing
    {
        [XmlAttribute]
        public ushort ItemId { get; set; }

        public float Armor { get; set; } = 1f;
        public float ExplosionArmor { get; set; } = 1f;
        public bool Fireproof { get; set; }
        public bool Radiationproof { get; set; }
        public byte Width { get; set; }
        public byte Height { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is not Clothing other)
                return false;
            
            return ItemId == other.ItemId;
        }

        public override int GetHashCode()
        {
            return ItemId.GetHashCode();
        }
    }
}