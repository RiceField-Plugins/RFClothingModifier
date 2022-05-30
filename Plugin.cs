using System.Collections.Generic;
using RFClothingModifier.Models;
using RFClothingModifier.Utils;
using Rocket.Core.Plugins;
using SDG.Unturned;
using Logger = Rocket.Core.Logging.Logger;

namespace RFClothingModifier
{
    public class Plugin : RocketPlugin<Configuration>
    {
        private static int Major = 1;
        private static int Minor = 0;
        private static int Patch = 1;
        
        public static Plugin Inst;
        public static Configuration Conf;
        internal static HashSet<Clothing> OriginalClothing;

        protected override void Load()
        {
            Inst = this;
            Conf = Configuration.Instance;
            if (Conf.Enabled)
            {
                OriginalClothing = new HashSet<Clothing>();
                
                Level.onPostLevelLoaded += OnPostLevelLoaded;
                
                if (Level.isLoaded)
                    OnPostLevelLoaded(0);
            }
            else
                Logger.LogWarning($"[{Name}] Plugin: DISABLED");

            Logger.LogWarning($"[{Name}] Plugin loaded successfully!");
            Logger.LogWarning($"[{Name}] {Name} v{Major}.{Minor}.{Patch}");
            Logger.LogWarning($"[{Name}] Made with 'rice' by RiceField Plugins!");
        }

        protected override void Unload()
        {
            if (Conf.Enabled)
            {
                Level.onPostLevelLoaded -= OnPostLevelLoaded;
                
                if (Level.isLoaded && Conf.RevertOnUnload)
                    foreach (var clothing in OriginalClothing)
                        ClothUtil.Modify(clothing, true);
                
                OriginalClothing.Clear();
                OriginalClothing.TrimExcess();
            }
            
            Conf = null;
            Inst = null;

            Logger.LogWarning($"[{Name}] Plugin unloaded successfully!");
        }
        
        private static void OnPostLevelLoaded(int level)
        {
            foreach (var clothing in Conf.Clothings)
                ClothUtil.Modify(clothing);
        }
    }
}