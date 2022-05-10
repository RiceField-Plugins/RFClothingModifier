using System.Xml.Serialization;

namespace RFClothingModifier.Models
{
    public class Clothing
    {
        [XmlAttribute]
        public ushort ItemId { get; set; }
        [XmlAttribute]
        public byte Width { get; set; }
        [XmlAttribute]
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