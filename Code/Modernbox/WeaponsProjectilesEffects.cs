//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using tools;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;
using HarmonyLib;
using System.Text.RegularExpressions;
using Beebyte.Obfuscator;
using ai;
using ai.behaviours;

namespace ModernBox
{
    public static class CustomItemsList
    {
        public static List<EquipmentAsset> CustomWeapons = new List<EquipmentAsset>();
        public static List<EquipmentAsset> CustomArmors = new List<EquipmentAsset>();
        public static List<EquipmentAsset> CustomHelmets = new List<EquipmentAsset>();
        public static List<EquipmentAsset> CustomBoots = new List<EquipmentAsset>();
        public static List<EquipmentAsset> CustomEquipment = new List<EquipmentAsset>();

        public static bool GunsAllowed;

        public static void InitCustomItems()
        {
            if (!AssetManager.items.dict.ContainsKey("Glock17"))
                return;

            CustomWeapons.Add(AssetManager.items.get("Glock17"));
            CustomWeapons.Add(AssetManager.items.get("AK"));
            CustomWeapons.Add(AssetManager.items.get("RPG"));
            CustomWeapons.Add(AssetManager.items.get("Minigun"));
            CustomWeapons.Add(AssetManager.items.get("Sniper"));
            CustomWeapons.Add(AssetManager.items.get("FAMAS"));
            CustomWeapons.Add(AssetManager.items.get("M4A1"));
            CustomWeapons.Add(AssetManager.items.get("ThompsonM1A1"));
            CustomWeapons.Add(AssetManager.items.get("SGT44"));
            CustomWeapons.Add(AssetManager.items.get("XM8"));
            CustomWeapons.Add(AssetManager.items.get("AK103"));
            CustomWeapons.Add(AssetManager.items.get("Uzi"));
            CustomWeapons.Add(AssetManager.items.get("Malorian"));
            CustomWeapons.Add(AssetManager.items.get("DesertEagle"));
            CustomWeapons.Add(AssetManager.items.get("M16"));
            CustomWeapons.Add(AssetManager.items.get("HK416"));
            CustomWeapons.Add(AssetManager.items.get("MP7"));
            CustomWeapons.Add(AssetManager.items.get("M32"));
            CustomWeapons.Add(AssetManager.items.get("Sluggershotgun"));
            CustomWeapons.Add(AssetManager.items.get("Americanshotgun"));
            CustomWeapons.Add(AssetManager.items.get("Flamethrower"));
            CustomWeapons.Add(AssetManager.items.get("vrifle"));
            CustomWeapons.Add(AssetManager.items.get("bigboy"));
            CustomWeapons.Add(AssetManager.items.get("grifle"));
            CustomWeapons.Add(AssetManager.items.get("MGL"));

            CustomArmors.Add(AssetManager.items.get("modernarmor"));

            CustomHelmets.Add(AssetManager.items.get("modernhelmet"));

            CustomBoots.Add(AssetManager.items.get("modernboots"));

            CustomEquipment.Add(AssetManager.items.get("grenadebelt"));
            CustomEquipment.Add(AssetManager.items.get("medicpack"));
        }

        public static void toggleGuns()
        {
            Main.modifyBoolOption("GunOption", PowerButtons.GetToggleValue("gun_toggle"));
            if (PowerButtons.GetToggleValue("gun_toggle"))
            {
                turnOnGuns();
                return;
            }
            turnOffGuns();
        }

        public static void turnOnGuns()
        {
            GunsAllowed = true;
        }

        public static void turnOffGuns()
        {
            GunsAllowed = false;
        }

        public static List<EquipmentAsset> GetCustomItemsForType(EquipmentType pType)
        {
            switch (pType)
            {
                case EquipmentType.Weapon:
                    return CustomWeapons;
                case EquipmentType.Armor:
                    return CustomArmors;
                case EquipmentType.Helmet:
                    return CustomHelmets;
                case EquipmentType.Boots:
                    return CustomBoots;
                default:
                    return CustomEquipment;
            }
        }
    }

    [HarmonyPatch(typeof(ItemCrafting), "craftItem")]
    public class Patch_ItemCrafting_PrioritizeCustomItems
    {
        static bool Prefix(ref bool __result, Actor pActor, string pCreatorName, EquipmentType pType, int pTries, City pCity)
        {
                if(!CustomItemsList.GunsAllowed)
                return false;

            if (CustomItemsList.CustomWeapons.Count == 0)
                CustomItemsList.InitCustomItems();

            List<EquipmentAsset> customItems = CustomItemsList.GetCustomItemsForType(pType);

            if (customItems.Count == 0)
                return true;

            ActorEquipmentSlot tActorSlot = pActor.equipment.getSlot(pType);
            int tCurrentItemValue = tActorSlot.getItem()?.asset.equipment_value ?? 0;

            EquipmentAsset tItemAssetToCraft = null;
            foreach (EquipmentAsset item in customItems)
            {
                if (item != null && item.equipment_value > tCurrentItemValue && hasEnoughResourcesToCraft(pActor, item, pCity))
                {
                    tItemAssetToCraft = item;
                    break;
                }
            }

            if (tItemAssetToCraft == null)
                return true;

            Item tItem = World.world.items.generateItem(tItemAssetToCraft, pActor.kingdom, pCreatorName, pTries, pActor);

            if (tActorSlot.isEmpty())
            {
                tActorSlot.setItem(tItem, pActor);
            }
            else
            {
                Item tOldItem = tActorSlot.getItem();
                tActorSlot.takeAwayItem();
                pCity.tryToPutItem(tOldItem);
                tActorSlot.setItem(tItem, pActor);
            }

            pActor.spendMoney(tItemAssetToCraft.get_total_cost);
            if (tItemAssetToCraft.cost_resource_id_1 != "none")
            {
                pCity.takeResource(tItemAssetToCraft.cost_resource_id_1, tItemAssetToCraft.cost_resource_1);
            }
            if (tItemAssetToCraft.cost_resource_id_2 != "none")
            {
                pCity.takeResource(tItemAssetToCraft.cost_resource_id_2, tItemAssetToCraft.cost_resource_2);
            }

            __result = true;
            return false;
        }

        private static bool hasEnoughResourcesToCraft(Actor pActor, EquipmentAsset pAsset, City pCity)
        {
            int tTotalCost = pAsset.get_total_cost;
            if (!pActor.hasEnoughMoney(tTotalCost))
            {
                return false;
            }
            if (pAsset.cost_resource_id_1 != "none" && pAsset.cost_resource_1 > pCity.getResourcesAmount(pAsset.cost_resource_id_1))
            {
                return false;
            }
            if (pAsset.cost_resource_id_2 != "none" && pAsset.cost_resource_2 > pCity.getResourcesAmount(pAsset.cost_resource_id_2))
            {
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Culture), "getPreferredWeaponSubtypeIDs")]
    public class Patch_Culture_PreferredWeaponSubtypes
    {
        static bool Prefix(ref string __result)
        {
            if (CustomItemsList.CustomWeapons.Count > 0)
            {
                __result = "stick";
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Culture), "getPreferredWeaponAssets")]
    public class Patch_Culture_PreferredWeaponAssets
    {
        static bool Prefix(ref List<EquipmentAsset> __result)
        {
            if (CustomItemsList.CustomWeapons.Count > 0)
            {
                __result = CustomItemsList.CustomWeapons;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(Culture), "hasPreferredWeaponsToCraft")]
    public class Patch_Culture_HasPreferredWeaponsToCraft
    {
        static bool Prefix(ref bool __result)
        {
            if (CustomItemsList.CustomWeapons.Count > 0)
            {
                __result = true;
                return false;
            }
            return true;
        }
    }

    [HarmonyPatch(typeof(ItemLibrary), "fillSubtypesAndGroups")]
    public class Patch_ItemLibrary_FillSubtypesAndGroups
    {
        static void Postfix(ItemLibrary __instance)
        {

            if (!__instance.equipment_by_subtypes.ContainsKey("firearm"))
            {
                __instance.equipment_by_subtypes.Add("firearm", new List<EquipmentAsset>());
            }

            if (__instance.dict.ContainsKey("Glock17"))
            {
                EquipmentAsset glock = __instance.get("Glock17");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(glock))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(glock);
                }
            }

            if (__instance.dict.ContainsKey("AK"))
            {
                EquipmentAsset ak = __instance.get("AK");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(ak))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(ak);
                }
            }


            if (__instance.dict.ContainsKey("vrifle"))
            {
                EquipmentAsset vrifle = __instance.get("vrifle");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(vrifle))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(vrifle);
                }
            }


            if (__instance.dict.ContainsKey("MGL"))
            {
                EquipmentAsset MGL = __instance.get("MGL");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(MGL))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(MGL);
                }
            }


            if (__instance.dict.ContainsKey("Flamethrower"))
            {
                EquipmentAsset Flamethrower = __instance.get("Flamethrower");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(Flamethrower))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(Flamethrower);
                }
            }


            if (__instance.dict.ContainsKey("RPG"))
            {
                EquipmentAsset rpg = __instance.get("RPG");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(rpg))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(rpg);
                }
            }



            if (__instance.dict.ContainsKey("bigboy"))
            {
                EquipmentAsset bigboy = __instance.get("bigboy");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(bigboy))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(bigboy);
                }
            }


            if (__instance.dict.ContainsKey("grifle"))
            {
                EquipmentAsset grifle = __instance.get("grifle");
                if (!__instance.equipment_by_subtypes["firearm"].Contains(grifle))
                {
                    __instance.equipment_by_subtypes["firearm"].Add(grifle);
                }
            }




            if (!__instance.equipment_by_subtypes.ContainsKey("stick"))
            {
                __instance.equipment_by_subtypes.Add("stick", new List<EquipmentAsset>());
            }

            if (__instance.dict.ContainsKey("Glock17"))
            {
                EquipmentAsset glock = __instance.get("Glock17");
                if (!__instance.equipment_by_subtypes["stick"].Contains(glock))
                {
                    __instance.equipment_by_subtypes["stick"].Add(glock);
                }
            }
        }
    }

    class WeaponsProjectilesEffects : MonoBehaviour
    {

        public static void init()
        {
            WeaponsAndStuff();
        }

        private static void WeaponsAndStuff()
        {

        }




public static void FixAllWeapons()
{
    ModernBoxLogger.Log("[FixAllWeapons] Starting weapon sprite fix pass...");

    int totalChecked = 0;
    int totalFixed = 0;
    int totalSkipped = 0;

    foreach (var kvp in AssetManager.items.list)
    {
        string id = kvp.id;
        EquipmentAsset asset = kvp;

        if (asset == null)
        {
            ModernBoxLogger.Warning($"[FixAllWeapons] Skipping item with id '{id}': Not an EquipmentAsset.");
            totalSkipped++;
            continue;
        }

        totalChecked++;

        if (asset.gameplay_sprites == null || asset.gameplay_sprites.Length == 0)
        {
            ModernBoxLogger.Log($"[FixAllWeapons] Missing sprites for '{id}', attempting to fix...");
            var sprites = FetchSprites(id);
            asset.gameplay_sprites = sprites;

            if (asset.gameplay_sprites != null && asset.gameplay_sprites.Length > 0)
            {
                ModernBoxLogger.Log($"[FixAllWeapons] Successfully fixed '{id}' with {asset.gameplay_sprites.Length} sprites.");
                totalFixed++;
            }
            else
            {
                ModernBoxLogger.Error($"[FixAllWeapons] Failed to fix '{id}', sprites still missing.");
            }
        }
        else
        {
            ModernBoxLogger.Log($"[FixAllWeapons] '{id}' already has {asset.gameplay_sprites.Length} sprites, skipping.");
        }
    }

    ModernBoxLogger.Log($"[FixAllWeapons] Done. Checked: {totalChecked}, Fixed: {totalFixed}, Skipped (non-weapon): {totalSkipped}");
}


public static void addWeaponsSprite(string id)
{
    ModernBoxLogger.Log("[addWeaponsSprite] Attempting to load sprite for weapon: " + id);

    EquipmentAsset item = AssetManager.items.get(id);

    if (item == null)
    {
        ModernBoxLogger.Error("[addWeaponsSprite] Item not found in AssetManager: " + id);
        return;
    }

    item.gameplay_sprites = FetchSprites(id);
    ModernBoxLogger.Log("[addWeaponsSprite] Sprite assignment complete for: " + id);
}

public static Sprite[] FetchSprites(string id)
{
    ModernBoxLogger.Log("[FetchSprites] Fetching sprites for weapon: " + id);

    EquipmentAsset item = AssetManager.items.get(id);
    if (item == null)
    {
        ModernBoxLogger.Error("[FetchSprites] Item not found in AssetManager: " + id);
        return Array.Empty<Sprite>();
    }

    if (item.animated)
    {
        List<Sprite> spriteList = new List<Sprite>();
        int frameIndex = 0;
        bool framesFound = false;

        while (true)
        {
            string path1 = "weapons/" + id + "_" + frameIndex;
            Sprite frameSprite = Resources.Load<Sprite>(path1);

            if (frameSprite != null)
            {
                ModernBoxLogger.Log("[FetchSprites] Loaded sprite: " + path1);
                spriteList.Add(frameSprite);
                framesFound = true;
                frameIndex++;
                continue;
            }

            string path2 = "weapons/" + id + frameIndex;
            frameSprite = Resources.Load<Sprite>(path2);

            if (frameSprite != null)
            {
                ModernBoxLogger.Log("[FetchSprites] Loaded sprite: " + path2);
                spriteList.Add(frameSprite);
                framesFound = true;
                frameIndex++;
                continue;
            }

            if (framesFound)
            {
                ModernBoxLogger.Log("[FetchSprites] Finished loading sequence frames after index " + frameIndex);
                break;
            }

            string path3 = "weapons/" + id + "/main_0_" + frameIndex;
            frameSprite = Resources.Load<Sprite>(path3);

            if (frameSprite != null)
            {
                ModernBoxLogger.Log("[FetchSprites] Loaded sprite: " + path3);
                spriteList.Add(frameSprite);
                framesFound = true;
                frameIndex++;
                continue;
            }

            if (frameIndex > 0)
            {
                ModernBoxLogger.Log("[FetchSprites] No more frames found beyond index: " + frameIndex);
                break;
            }

            string bulkPath = "weapons/" + id;
            Sprite[] sprites = Resources.LoadAll<Sprite>(bulkPath);
            if (sprites != null && sprites.Length > 0)
            {
                ModernBoxLogger.Log("[FetchSprites] Loaded " + sprites.Length + " sprites from: " + bulkPath);
                spriteList.AddRange(sprites);
                framesFound = true;
            }
            else
            {
                ModernBoxLogger.Warning("[FetchSprites] No sprites found with LoadAll at: " + bulkPath);
            }

            break;

            if (frameIndex > 20)
            {
                ModernBoxLogger.Warning("[FetchSprites] Exceeded frame index limit (20). Aborting load.");
                break;
            }
        }

        if (framesFound && spriteList.Count > 0)
        {
            ModernBoxLogger.Log("[FetchSprites] Returning " + spriteList.Count + " animated sprites for: " + id);
            return spriteList.ToArray();
        }
        else
        {
            ModernBoxLogger.Error("[FetchSprites] No animations found for: " + id);
            var fallbackSprite = Resources.Load<Sprite>("weapons/" + id);
            if (fallbackSprite != null)
            {
                ModernBoxLogger.Log("[FetchSprites] Fallback sprite loaded for: " + id);
                return new Sprite[] { fallbackSprite };
            }
            else
            {
                ModernBoxLogger.Error("[FetchSprites] No fallback sprite found for: " + id);
                return Array.Empty<Sprite>();
            }
        }
    }
    else
    {
        var sprite = Resources.Load<Sprite>("weapons/" + id);
        if (sprite != null)
        {
            ModernBoxLogger.Log("[FetchSprites] Loaded non-animated sprite for: " + id);
            return new Sprite[] { sprite };
        }
        else
        {
            ModernBoxLogger.Error("[FetchSprites] No sprite found for non-animated weapon: " + id);
            return Array.Empty<Sprite>();
        }
    }
}

}
}
