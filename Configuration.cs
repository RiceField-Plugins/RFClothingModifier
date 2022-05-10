using System.Collections.Generic;
using RFClothingModifier.Models;
using Rocket.API;

namespace RFClothingModifier
{
    public class Configuration : IRocketPluginConfiguration
    {
        public bool Enabled;
        public HashSet<Clothing> Clothings;
        public void LoadDefaults()
        {
            Enabled = true;
            Clothings = new HashSet<Clothing>
            {
                new() {ItemId = 253, Height = 10, Width = 10},
                new() {ItemId = 1182, Height = 10, Width = 10},
            };
        }
    }
}