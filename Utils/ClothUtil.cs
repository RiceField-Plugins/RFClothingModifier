using HarmonyLib;
using RFClothingModifier.Models;
using Rocket.Core.Logging;
using SDG.Unturned;

namespace RFClothingModifier.Utils
{
    internal static class ClothUtil
    {
        internal static void Modify(Clothing clothing, bool isRevert = false)
        {
            var asset = Assets.find(EAssetType.ITEM, clothing.ItemId);
            if (asset is not ItemClothingAsset clothingAsset)
                return;

            var cloth = Traverse.Create(clothingAsset);
            Clothing oClothing = null;
            if (!isRevert)
            {
                oClothing = new Clothing
                {
                    ItemId = asset.id,
                    Armor = cloth.Field<float>("_armor").Value,
                    ExplosionArmor = cloth.Field<float>("_explosionArmor").Value,
                    Fireproof = cloth.Field<bool>("_proofFire").Value,
                    Radiationproof = cloth.Field<bool>("_proofRadiation").Value,
                };
            }

            cloth.Field("_armor").SetValue(clothing.Armor);
            cloth.Field("_explosionArmor").SetValue(clothing.ExplosionArmor);
            cloth.Field("_proofFire").SetValue(clothing.Fireproof);
            cloth.Field("_proofRadiation").SetValue(clothing.Radiationproof);
            if (asset is ItemBagAsset bagAsset)
            {
                var bag = Traverse.Create(bagAsset);
                if (!isRevert)
                {
                    oClothing.Width = bag.Field<byte>("_width").Value;
                    oClothing.Height = bag.Field<byte>("_height").Value;
                }
                
                bag.Field("_width").SetValue(clothing.Width);
                bag.Field("_height").SetValue(clothing.Height);
            }

            if (!isRevert)
                Plugin.OriginalClothing.Add(oClothing);
        }
    }
}