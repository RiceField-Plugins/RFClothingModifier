using HarmonyLib;
using RFClothingModifier.Models;
using SDG.Unturned;

namespace RFClothingModifier.Utils
{
    internal static class ClothUtil
    {
        internal static void Modify(Clothing clothing)
        {
            var asset = Assets.find(EAssetType.ITEM, clothing.ItemId);
            if (asset is not ItemBagAsset bagAsset)
                return;

            var bag = Traverse.Create(bagAsset);
            bag.Field("_width").SetValue(clothing.Width);
            bag.Field("_height").SetValue(clothing.Height);
        }
    }
}