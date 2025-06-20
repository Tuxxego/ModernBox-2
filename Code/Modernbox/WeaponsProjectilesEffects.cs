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
            // Culture Trait
            //
            //=============================================================================//

            // Guns
            //
            //=============================================================================//

            EquipmentAsset Glock17 = AssetManager.items.clone("Glock17", "$range");
            Glock17.equipment_type = EquipmentType.Weapon;
            Glock17.equipment_subtype = "stick";
            Glock17.translation_key = "Glock17, the bestest gun";
            Glock17.material = "basic";
            Glock17.group_id = "firearm";
            Glock17.metallic = true;
            Glock17.setCost(0, "wood", 1);
            Glock17.minimum_city_storage_resource_1 = 1;
            Glock17.rigidity_rating = 4;
            Glock17.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            Glock17.is_pool_weapon = true;
            Glock17.pool_rate = 15;
            Glock17.path_icon = "ui/icons/items/icon_Glock17";
            Glock17.path_gameplay_sprite = "weapons/Glock17";
            Glock17.projectile = "shotgun_bullet";
            Glock17.path_slash_animation = "effects/slashes/slash_punch";
            Glock17.base_stats["projectiles"] = 1f;
            Glock17.base_stats["attack_speed"] = 0f;
            Glock17.base_stats["accuracy"] = 0.5f;
            Glock17.base_stats["damage"] = 30f;
            Glock17.base_stats["critical_chance"] = 0.3f;
            Glock17.base_stats["critical_damage_multiplier"] = 0.5f;
            Glock17.base_stats["recoil"] = 1f;
            Glock17.base_stats["range"] = 8f;
            Glock17.base_stats["targets"] = 1f;
            Glock17.base_stats["damage_range"] = 0.9f;
            Glock17.base_stats["mana"] = 10f;
            Glock17.base_stats["stamina"] = 10f;
            Glock17.equipment_value = 700;
Glock17.gameplay_sprites = FetchSprites("Glock17");
            AssetManager.items.add(Glock17);
            AssetManager.items.pot_weapon_assets_all.Add(Glock17);
            AssetManager.items.pot_weapon_assets_unlocked.Add(Glock17);
            addWeaponsSprite(Glock17.id);


            EquipmentAsset Uzi = AssetManager.items.clone("Uzi", "$range");
Uzi.equipment_type = EquipmentType.Weapon;
Uzi.translation_key = "Uzi SMG";
Uzi.equipment_subtype = "stick";
Uzi.material = "basic";
Uzi.group_id = "firearm";
Uzi.metallic = true;
Uzi.setCost(0, "wood", 2);
Uzi.minimum_city_storage_resource_1 = 1;
Uzi.rigidity_rating = 4;
Uzi.is_pool_weapon = true;
Uzi.pool_rate = 15;
Uzi.path_icon = "ui/icons/items/icon_Uzi";
Uzi.path_gameplay_sprite = "weapons/Uzi";
Uzi.projectile = "shotgun_bullet";
Uzi.path_slash_animation = "effects/slashes/slash_punch";
Uzi.base_stats["projectiles"] = 1f;
Uzi.base_stats["attack_speed"] = 10f;
Uzi.base_stats["accuracy"] = 0.45f;
Uzi.base_stats["damage"] = 25f;
Uzi.base_stats["critical_chance"] = 0.15f;
Uzi.base_stats["critical_damage_multiplier"] = 0.25f;
Uzi.base_stats["recoil"] = 0.9f;
Uzi.base_stats["range"] = 8f;
Uzi.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
Uzi.base_stats["targets"] = 1f;
Uzi.base_stats["damage_range"] = 0.7f;
Uzi.base_stats["mana"] = 8f;
Uzi.base_stats["stamina"] = 10f;
Uzi.equipment_value = 725;
Uzi.gameplay_sprites = FetchSprites("Uzi");
AssetManager.items.add(Uzi);
AssetManager.items.pot_weapon_assets_all.Add(Uzi);
AssetManager.items.pot_weapon_assets_unlocked.Add(Uzi);
addWeaponsSprite(Uzi.id);


EquipmentAsset Malorian = AssetManager.items.clone("Malorian", "$range");
Malorian.equipment_type = EquipmentType.Weapon;
Malorian.translation_key = "Malorian Arms 3516";
Malorian.equipment_subtype = "stick";
Malorian.material = "basic";
Malorian.group_id = "firearm";
Malorian.metallic = true;
Malorian.setCost(0, "wood", 1, "gems", 1);
Malorian.minimum_city_storage_resource_1 = 1;
Malorian.rigidity_rating = 5;
Malorian.is_pool_weapon = true;
Malorian.pool_rate = 15;
Malorian.path_icon = "ui/icons/items/icon_Malorian";
Malorian.path_gameplay_sprite = "weapons/Glock17";
Malorian.projectile = "shotgun_bullet";
Malorian.path_slash_animation = "effects/slashes/slash_punch";
Malorian.base_stats["projectiles"] = 1f;
Malorian.base_stats["attack_speed"] = 2f;
Malorian.base_stats["accuracy"] = 0.75f;
Malorian.base_stats["damage"] = 75f;
Malorian.base_stats["critical_chance"] = 0.4f;
Malorian.base_stats["critical_damage_multiplier"] = 0.6f;
Malorian.base_stats["recoil"] = 0.5f;
Malorian.base_stats["range"] = 12f;
Malorian.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
Malorian.base_stats["targets"] = 1f;
Malorian.base_stats["damage_range"] = 0.9f;
Malorian.base_stats["mana"] = 25f;
Malorian.base_stats["stamina"] = 15f;
Malorian.equipment_value = 750;
Malorian.gameplay_sprites = FetchSprites("Malorian");
AssetManager.items.add(Malorian);
AssetManager.items.pot_weapon_assets_all.Add(Malorian);
AssetManager.items.pot_weapon_assets_unlocked.Add(Malorian);
addWeaponsSprite(Malorian.id);

EquipmentAsset DesertEagle = AssetManager.items.clone("DesertEagle", "$range");
DesertEagle.equipment_type = EquipmentType.Weapon;
DesertEagle.translation_key = "Desert Eagle Mark XIX";
DesertEagle.equipment_subtype = "stick";
DesertEagle.material = "basic";
DesertEagle.group_id = "firearm";
DesertEagle.metallic = true;
DesertEagle.setCost(0, "common_metals", 1);
DesertEagle.minimum_city_storage_resource_1 = 1;
DesertEagle.rigidity_rating = 5;
DesertEagle.is_pool_weapon = true;
DesertEagle.pool_rate = 15;
DesertEagle.path_icon = "ui/icons/items/icon_DesertEagle";
DesertEagle.path_gameplay_sprite = "weapons/Glock17";
DesertEagle.projectile = "shotgun_bullet";
DesertEagle.path_slash_animation = "effects/slashes/slash_punch";
DesertEagle.base_stats["projectiles"] = 1f;
DesertEagle.base_stats["attack_speed"] = -2f;
DesertEagle.base_stats["accuracy"] = 0.7f;
DesertEagle.base_stats["damage"] = 50f;
DesertEagle.base_stats["critical_chance"] = 0.35f;
DesertEagle.base_stats["critical_damage_multiplier"] = 0.5f;
DesertEagle.base_stats["recoil"] = 1f;
DesertEagle.base_stats["range"] = 10f;
DesertEagle.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
DesertEagle.base_stats["targets"] = 1f;
DesertEagle.base_stats["damage_range"] = 0.8f;
DesertEagle.base_stats["mana"] = 12f;
DesertEagle.base_stats["stamina"] = 12f;
DesertEagle.equipment_value = 775;
DesertEagle.gameplay_sprites = FetchSprites("DesertEagle");
AssetManager.items.add(DesertEagle);
AssetManager.items.pot_weapon_assets_all.Add(DesertEagle);
AssetManager.items.pot_weapon_assets_unlocked.Add(DesertEagle);
addWeaponsSprite(DesertEagle.id);


 EquipmentAsset Americanshotgun = AssetManager.items.clone("Americanshotgun", "$range");
            Americanshotgun.equipment_type = EquipmentType.Weapon;
            Americanshotgun.translation_key = "Bestest Shotgun";
            Americanshotgun.equipment_subtype = "stick";
            Americanshotgun.material = "basic";
            Americanshotgun.group_id = "firearm";
            Americanshotgun.metallic = true;
            Americanshotgun.setCost(0, "common_metals", 2);
            Americanshotgun.minimum_city_storage_resource_1 = 1;
            Americanshotgun.rigidity_rating = 3;
            Americanshotgun.is_pool_weapon = true;
            Americanshotgun.pool_rate = 15;
            Americanshotgun.path_icon = "ui/Icons/items/icon_shotgun";
            Americanshotgun.path_gameplay_sprite = "weapons/PipeShotgun";
            Americanshotgun.projectile = "shotgun_bullet";
            Americanshotgun.path_slash_animation = "effects/slashes/slash_punch";
            Americanshotgun.base_stats["projectiles"] = 6f;
            Americanshotgun.base_stats["attack_speed"] = -3f;
            Americanshotgun.base_stats["accuracy"] = 0.2f;
            Americanshotgun.base_stats["damage"] = 10f;
            Americanshotgun.base_stats["critical_chance"] = 0.2f;
            Americanshotgun.base_stats["critical_damage_multiplier"] = 0.3f;
            Americanshotgun.base_stats["recoil"] = 1f;
            Americanshotgun.base_stats["range"] = 10f;
            Americanshotgun.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            Americanshotgun.base_stats["targets"] = 1f;
            Americanshotgun.base_stats["damage_range"] = 0.7f;
            Americanshotgun.base_stats["mana"] = 10f;
            Americanshotgun.base_stats["stamina"] = 15f;
            Americanshotgun.equipment_value = 800;
Americanshotgun.gameplay_sprites = FetchSprites("Americanshotgun");
            AssetManager.items.add(Americanshotgun);
            AssetManager.items.pot_weapon_assets_all.Add(Americanshotgun);
            AssetManager.items.pot_weapon_assets_unlocked.Add(Americanshotgun);
            addWeaponsSprite(Americanshotgun.id);

            EquipmentAsset Sluggershotgun = AssetManager.items.clone("Sluggershotgun", "$range");
            Sluggershotgun.equipment_type = EquipmentType.Weapon;
            Sluggershotgun.translation_key = "Greatest SHotgun";
            Sluggershotgun.equipment_subtype = "stick";
            Sluggershotgun.material = "basic";
            Sluggershotgun.group_id = "firearm";
            Sluggershotgun.metallic = true;
            Sluggershotgun.setCost(0, "common_metals", 3);
            Sluggershotgun.minimum_city_storage_resource_1 = 1;
            Sluggershotgun.rigidity_rating = 1;
            Sluggershotgun.is_pool_weapon = true;
            Sluggershotgun.pool_rate = 15;
            Sluggershotgun.path_icon = "ui/Icons/items/icon_shotgun";
            Sluggershotgun.path_gameplay_sprite = "weapons/PipeShotgun";
            Sluggershotgun.projectile = "shotgun_bullet";
            Sluggershotgun.path_slash_animation = "effects/slashes/slash_punch";
            Sluggershotgun.base_stats["projectiles"] = 1f;
            Sluggershotgun.base_stats["attack_speed"] = -3f;
            Sluggershotgun.base_stats["accuracy"] = 0.7f;
            Sluggershotgun.base_stats["damage"] = 80f;
            Sluggershotgun.base_stats["critical_chance"] = 0.2f;
            Sluggershotgun.base_stats["critical_damage_multiplier"] = 4f;
            Sluggershotgun.base_stats["recoil"] = 2f;
            Sluggershotgun.base_stats["range"] = 10f;
            Sluggershotgun.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            Sluggershotgun.base_stats["targets"] = 1f;
            Sluggershotgun.base_stats["damage_range"] = 0.7f;
            Sluggershotgun.base_stats["mana"] = 10f;
            Sluggershotgun.base_stats["stamina"] = 15f;
            Sluggershotgun.equipment_value = 825;
Sluggershotgun.gameplay_sprites = FetchSprites("Sluggershotgun");
            AssetManager.items.add(Sluggershotgun);
            AssetManager.items.pot_weapon_assets_all.Add(Sluggershotgun);
            AssetManager.items.pot_weapon_assets_unlocked.Add(Sluggershotgun);
            addWeaponsSprite(Sluggershotgun.id);

EquipmentAsset MP7 = AssetManager.items.clone("MP7", "$range");
MP7.equipment_type = EquipmentType.Weapon;
MP7.translation_key = "HK MP7";
MP7.equipment_subtype = "stick";
MP7.material = "basic";
MP7.group_id = "firearm";
MP7.metallic = true;
MP7.setCost(0, "common_metals", 4);
MP7.minimum_city_storage_resource_1 = 1;
MP7.rigidity_rating = 5;
MP7.is_pool_weapon = true;
MP7.pool_rate = 15;
MP7.path_icon = "ui/icons/items/icon_MP7";
MP7.path_gameplay_sprite = "weapons/MP7";
MP7.projectile = "shotgun_bullet";
MP7.path_slash_animation = "effects/slashes/slash_punch";
MP7.base_stats["projectiles"] = 1f;
MP7.base_stats["attack_speed"] = 9f;
MP7.base_stats["accuracy"] = 0.6f;
MP7.base_stats["damage"] = 28f;
MP7.base_stats["critical_chance"] = 0.2f;
MP7.base_stats["critical_damage_multiplier"] = 0.3f;
MP7.base_stats["recoil"] = 0.4f;
MP7.base_stats["range"] = 9f;
MP7.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
MP7.base_stats["targets"] = 1f;
MP7.base_stats["damage_range"] = 0.75f;
MP7.base_stats["mana"] = 8f;
MP7.base_stats["stamina"] = 10f;
MP7.equipment_value = 850;
MP7.gameplay_sprites = FetchSprites("MP7");
AssetManager.items.add(MP7);
AssetManager.items.pot_weapon_assets_all.Add(MP7);
AssetManager.items.pot_weapon_assets_unlocked.Add(MP7);
addWeaponsSprite(MP7.id);

EquipmentAsset ThompsonM1A1 = AssetManager.items.clone("ThompsonM1A1", "$range");
ThompsonM1A1.equipment_type = EquipmentType.Weapon;
ThompsonM1A1.translation_key = "Thompson M1A1";
ThompsonM1A1.equipment_subtype = "stick";
ThompsonM1A1.material = "basic";
ThompsonM1A1.group_id = "firearm";
ThompsonM1A1.metallic = true;
ThompsonM1A1.setCost(0, "wood", 7);
ThompsonM1A1.minimum_city_storage_resource_1 = 1;
ThompsonM1A1.rigidity_rating = 4;
ThompsonM1A1.is_pool_weapon = true;
ThompsonM1A1.pool_rate = 15;
ThompsonM1A1.path_icon = "ui/icons/items/icon_ThompsonM1A1";
ThompsonM1A1.path_gameplay_sprite = "weapons/ThompsonM1A1";
ThompsonM1A1.projectile = "shotgun_bullet";
ThompsonM1A1.path_slash_animation = "effects/slashes/slash_punch";
ThompsonM1A1.base_stats["projectiles"] = 1f;
ThompsonM1A1.base_stats["attack_speed"] = 7f;
ThompsonM1A1.base_stats["accuracy"] = 0.55f;
ThompsonM1A1.base_stats["damage"] = 32f;
ThompsonM1A1.base_stats["critical_chance"] = 0.2f;
ThompsonM1A1.base_stats["critical_damage_multiplier"] = 0.4f;
ThompsonM1A1.base_stats["recoil"] = 0.8f;
ThompsonM1A1.base_stats["range"] = 10f;
ThompsonM1A1.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
ThompsonM1A1.base_stats["targets"] = 1f;
ThompsonM1A1.base_stats["damage_range"] = 0.7f;
ThompsonM1A1.base_stats["mana"] = 10f;
ThompsonM1A1.base_stats["stamina"] = 12f;
ThompsonM1A1.equipment_value = 875;
ThompsonM1A1.gameplay_sprites = FetchSprites("ThompsonM1A1");
AssetManager.items.add(ThompsonM1A1);
AssetManager.items.pot_weapon_assets_all.Add(ThompsonM1A1);
AssetManager.items.pot_weapon_assets_unlocked.Add(ThompsonM1A1);
addWeaponsSprite(ThompsonM1A1.id);


EquipmentAsset SGT44 = AssetManager.items.clone("SGT44", "$range");
SGT44.equipment_type = EquipmentType.Weapon;
SGT44.translation_key = "Sturmgewehr 44";
SGT44.equipment_subtype = "stick";
SGT44.material = "basic";
SGT44.group_id = "firearm";
SGT44.metallic = true;
SGT44.setCost(0, "common_metals", 1, "stone", 1);
SGT44.minimum_city_storage_resource_1 = 1;
SGT44.rigidity_rating = 4;
SGT44.is_pool_weapon = true;
SGT44.pool_rate = 15;
SGT44.path_icon = "ui/icons/items/icon_SGT44";
SGT44.path_gameplay_sprite = "weapons/SGT44";
SGT44.projectile = "shotgun_bullet";
SGT44.path_slash_animation = "effects/slashes/slash_punch";
SGT44.base_stats["projectiles"] = 1f;
SGT44.base_stats["attack_speed"] = 4f;
SGT44.base_stats["accuracy"] = 0.65f;
SGT44.base_stats["damage"] = 45f;
SGT44.base_stats["critical_chance"] = 0.25f;
SGT44.base_stats["critical_damage_multiplier"] = 0.35f;
SGT44.base_stats["recoil"] = 0.6f;
SGT44.base_stats["range"] = 13f;
SGT44.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
SGT44.base_stats["targets"] = 1f;
SGT44.base_stats["damage_range"] = 0.75f;
SGT44.base_stats["mana"] = 15f;
SGT44.base_stats["stamina"] = 18f;
SGT44.equipment_value = 900;
SGT44.gameplay_sprites = FetchSprites("SGT44");
AssetManager.items.add(SGT44);
AssetManager.items.pot_weapon_assets_all.Add(SGT44);
AssetManager.items.pot_weapon_assets_unlocked.Add(SGT44);
addWeaponsSprite(SGT44.id);

            EquipmentAsset AK = AssetManager.items.clone("AK", "$range");
            AK.equipment_type = EquipmentType.Weapon;
            AK.translation_key = "Avtomat Kalashnikov 47";
            AK.equipment_subtype = "stick";
            AK.material = "basic";
            AK.group_id = "firearm";
            AK.metallic = true;
            AK.setCost(0, "common_metals", 1, "wood", 2);
            AK.minimum_city_storage_resource_1 = 1;
            AK.rigidity_rating = 7;
            AK.is_pool_weapon = true;
            AK.pool_rate = 15;
            AK.path_icon = "ui/icons/items/icon_AK47";
            AK.path_gameplay_sprite = "weapons/ak";
            AK.projectile = "shotgun_bullet";
            AK.path_slash_animation = "effects/slashes/slash_punch";
            AK.base_stats["projectiles"] = 1f;
            AK.base_stats["attack_speed"] = 5f;
            AK.base_stats["accuracy"] = 0.6f;
            AK.base_stats["damage"] = 40f;
            AK.base_stats["critical_chance"] = 0.2f;
            AK.base_stats["critical_damage_multiplier"] = 0.3f;
            AK.base_stats["recoil"] = 0.5f;
            AK.base_stats["range"] = 15f;
             AK.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            AK.base_stats["targets"] = 1f;
            AK.base_stats["damage_range"] = 0.8f;
            AK.base_stats["mana"] = 10f;
            AK.base_stats["stamina"] = 15f;
            AK.equipment_value = 925;
AK.gameplay_sprites = FetchSprites("AK");
            AssetManager.items.add(AK);
            AssetManager.items.pot_weapon_assets_all.Add(AK);
            AssetManager.items.pot_weapon_assets_unlocked.Add(AK);
            addWeaponsSprite(AK.id);

EquipmentAsset AK103 = AssetManager.items.clone("AK103", "$range");
AK103.equipment_type = EquipmentType.Weapon;
AK103.translation_key = "AK-103";
AK103.equipment_subtype = "stick";
AK103.material = "basic";
AK103.group_id = "firearm";
AK103.metallic = true;
AK103.setCost(0, "common_metals", 5);
AK103.minimum_city_storage_resource_1 = 1;
AK103.rigidity_rating = 4;
AK103.is_pool_weapon = true;
AK103.gameplay_sprites = FetchSprites("AK103");
AK103.pool_rate = 15;
AK103.path_icon = "ui/icons/items/icon_AK103";
AK103.path_gameplay_sprite = "weapons/AK103";
AK103.projectile = "shotgun_bullet";
AK103.path_slash_animation = "effects/slashes/slash_punch";
AK103.base_stats["projectiles"] = 1f;
AK103.base_stats["attack_speed"] = 5f;
AK103.base_stats["accuracy"] = 0.65f;
AK103.base_stats["damage"] = 62f;
AK103.base_stats["critical_chance"] = 0.25f;
AK103.base_stats["critical_damage_multiplier"] = 0.35f;
AK103.base_stats["recoil"] = 0.6f;
AK103.base_stats["range"] = 15f;
AK103.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
AK103.base_stats["targets"] = 1f;
AK103.base_stats["damage_range"] = 0.8f;
AK103.base_stats["mana"] = 10f;
AK103.base_stats["stamina"] = 15f;
AK103.equipment_value = 950;
AK103.gameplay_sprites = FetchSprites("AK103");
AssetManager.items.add(AK103);
AssetManager.items.pot_weapon_assets_all.Add(AK103);
AssetManager.items.pot_weapon_assets_unlocked.Add(AK103);
addWeaponsSprite(AK103.id);

EquipmentAsset M16 = AssetManager.items.clone("M16", "$range");
M16.equipment_type = EquipmentType.Weapon;
M16.translation_key = "M16A1";
M16.equipment_subtype = "stick";
M16.material = "basic";
M16.group_id = "firearm";
M16.metallic = true;
M16.setCost(0, "common_metals", 2);
M16.minimum_city_storage_resource_1 = 1;
M16.rigidity_rating = 4;
M16.is_pool_weapon = true;
M16.pool_rate = 15;
M16.path_icon = "ui/icons/items/icon_M16";
M16.path_gameplay_sprite = "weapons/M16";
M16.projectile = "shotgun_bullet";
M16.path_slash_animation = "effects/slashes/slash_punch";
M16.base_stats["projectiles"] = 1f;
M16.base_stats["attack_speed"] = 4f;
M16.base_stats["accuracy"] = 0.7f;
M16.base_stats["damage"] = 36f;
M16.base_stats["critical_chance"] = 0.2f;
M16.base_stats["critical_damage_multiplier"] = 0.3f;
M16.base_stats["recoil"] = 0.5f;
M16.base_stats["range"] = 18f;
M16.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
M16.base_stats["targets"] = 1f;
M16.base_stats["damage_range"] = 0.85f;
M16.base_stats["mana"] = 10f;
M16.base_stats["stamina"] = 15f;
M16.equipment_value = 975;
M16.gameplay_sprites = FetchSprites("M16");
AssetManager.items.add(M16);
AssetManager.items.pot_weapon_assets_all.Add(M16);
AssetManager.items.pot_weapon_assets_unlocked.Add(M16);
addWeaponsSprite(M16.id);





EquipmentAsset FAMAS = AssetManager.items.clone("FAMAS", "$range");
FAMAS.equipment_type = EquipmentType.Weapon;
FAMAS.translation_key = "FAMAS F1";
FAMAS.equipment_subtype = "stick";
FAMAS.material = "basic";
FAMAS.group_id = "firearm";
FAMAS.metallic = true;
FAMAS.setCost(0, "wood", 1, "stone", 1);
FAMAS.minimum_city_storage_resource_1 = 1;
FAMAS.rigidity_rating = 4;
FAMAS.is_pool_weapon = true;
FAMAS.pool_rate = 15;
FAMAS.path_icon = "ui/icons/items/icon_FAMAS";
FAMAS.path_gameplay_sprite = "weapons/FAMAS";
FAMAS.projectile = "shotgun_bullet";
FAMAS.path_slash_animation = "effects/slashes/slash_punch";
FAMAS.base_stats["projectiles"] = 1f;
FAMAS.base_stats["attack_speed"] = 8f;
FAMAS.base_stats["accuracy"] = 0.65f;
FAMAS.base_stats["damage"] = 35f;
FAMAS.base_stats["critical_chance"] = 0.2f;
FAMAS.base_stats["critical_damage_multiplier"] = 0.3f;
FAMAS.base_stats["recoil"] = 0.7f;
FAMAS.base_stats["range"] = 14f;
FAMAS.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
FAMAS.base_stats["targets"] = 1f;
FAMAS.base_stats["damage_range"] = 0.75f;
FAMAS.base_stats["mana"] = 10f;
FAMAS.base_stats["stamina"] = 15f;
FAMAS.equipment_value = 1000;
FAMAS.gameplay_sprites = FetchSprites("FAMAS");
AssetManager.items.add(FAMAS);
AssetManager.items.pot_weapon_assets_all.Add(FAMAS);
AssetManager.items.pot_weapon_assets_unlocked.Add(FAMAS);
addWeaponsSprite(FAMAS.id);

EquipmentAsset M4A1 = AssetManager.items.clone("M4A1", "$range");
M4A1.equipment_type = EquipmentType.Weapon;
M4A1.translation_key = "M4A1 Carbine";
M4A1.equipment_subtype = "stick";
M4A1.material = "basic";
M4A1.group_id = "firearm";
M4A1.metallic = true;
M4A1.setCost(0, "common_metals", 2, "stone", 1);
M4A1.minimum_city_storage_resource_1 = 1;
M4A1.rigidity_rating = 4;
M4A1.is_pool_weapon = true;
M4A1.pool_rate = 15;
M4A1.path_icon = "ui/icons/items/icon_M4A1";
M4A1.path_gameplay_sprite = "weapons/M4A1";
M4A1.projectile = "shotgun_bullet";
M4A1.path_slash_animation = "effects/slashes/slash_punch";
M4A1.base_stats["projectiles"] = 1f;
M4A1.base_stats["attack_speed"] = 6f;
M4A1.base_stats["accuracy"] = 0.7f;
M4A1.base_stats["damage"] = 38f;
M4A1.base_stats["critical_chance"] = 0.2f;
M4A1.base_stats["critical_damage_multiplier"] = 0.3f;
M4A1.base_stats["recoil"] = 0.4f;
M4A1.base_stats["range"] = 14f;
M4A1.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
M4A1.base_stats["targets"] = 1f;
M4A1.base_stats["damage_range"] = 0.8f;
M4A1.base_stats["mana"] = 10f;
M4A1.base_stats["stamina"] = 12f;
M4A1.equipment_value = 1025;
M4A1.gameplay_sprites = FetchSprites("M4A1");
AssetManager.items.add(M4A1);
AssetManager.items.pot_weapon_assets_all.Add(M4A1);
AssetManager.items.pot_weapon_assets_unlocked.Add(M4A1);
addWeaponsSprite(M4A1.id);

EquipmentAsset XM8 = AssetManager.items.clone("XM8", "$range");
XM8.equipment_type = EquipmentType.Weapon;
XM8.translation_key = "XM8 Prototype";
XM8.equipment_subtype = "stick";
XM8.material = "basic";
XM8.group_id = "firearm";
XM8.metallic = true;
XM8.setCost(0, "common_metals", 3, "stone", 2);
XM8.minimum_city_storage_resource_1 = 1;
XM8.rigidity_rating = 4;
XM8.is_pool_weapon = true;
XM8.pool_rate = 15;
XM8.path_icon = "ui/icons/items/icon_XM8";
XM8.path_gameplay_sprite = "weapons/XM8";
XM8.projectile = "shotgun_bullet";
XM8.path_slash_animation = "effects/slashes/slash_punch";
XM8.base_stats["projectiles"] = 1f;
XM8.base_stats["attack_speed"] = 5f;
XM8.base_stats["accuracy"] = 0.8f;
XM8.base_stats["damage"] = 37f;
XM8.base_stats["critical_chance"] = 0.3f;
XM8.base_stats["critical_damage_multiplier"] = 0.4f;
XM8.base_stats["recoil"] = 0.3f;
XM8.base_stats["range"] = 16f;
XM8.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
XM8.base_stats["targets"] = 1f;
XM8.base_stats["damage_range"] = 0.85f;
XM8.base_stats["mana"] = 10f;
XM8.base_stats["stamina"] = 14f;
XM8.equipment_value = 1050;
XM8.gameplay_sprites = FetchSprites("XM8");
AssetManager.items.add(XM8);
AssetManager.items.pot_weapon_assets_all.Add(XM8);
AssetManager.items.pot_weapon_assets_unlocked.Add(XM8);
addWeaponsSprite(XM8.id);



EquipmentAsset HK416 = AssetManager.items.clone("HK416", "$range");
HK416.equipment_type = EquipmentType.Weapon;
HK416.translation_key = "HK416";
HK416.equipment_subtype = "stick";
HK416.material = "basic";
HK416.group_id = "firearm";
HK416.metallic = true;
HK416.setCost(0, "common_metals", 1, "wood", 5);
HK416.minimum_city_storage_resource_1 = 1;
HK416.rigidity_rating = 4;
HK416.is_pool_weapon = true;
HK416.pool_rate = 15;
HK416.path_icon = "ui/icons/items/icon_HK416";
HK416.path_gameplay_sprite = "weapons/HK416";
HK416.projectile = "shotgun_bullet";
HK416.path_slash_animation = "effects/slashes/slash_punch";
HK416.base_stats["projectiles"] = 1f;
HK416.base_stats["attack_speed"] = 6f;
HK416.base_stats["accuracy"] = 0.75f;
HK416.base_stats["damage"] = 39f;
HK416.base_stats["critical_chance"] = 0.25f;
HK416.base_stats["critical_damage_multiplier"] = 0.4f;
HK416.base_stats["recoil"] = 0.35f;
HK416.base_stats["range"] = 16f;
HK416.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
HK416.base_stats["targets"] = 1f;
HK416.base_stats["damage_range"] = 0.8f;
HK416.base_stats["mana"] = 10f;
HK416.base_stats["stamina"] = 15f;
HK416.equipment_value = 1075;
HK416.gameplay_sprites = FetchSprites("HK416");
AssetManager.items.add(HK416);
AssetManager.items.pot_weapon_assets_all.Add(HK416);
AssetManager.items.pot_weapon_assets_unlocked.Add(HK416);
AssetManager.items.loadSprites();
addWeaponsSprite(HK416.id);

EquipmentAsset vrifle = AssetManager.items.clone("vrifle", "$range");
vrifle.equipment_type = EquipmentType.Weapon;
vrifle.translation_key = "FNV varmit rifle";
vrifle.equipment_subtype = "stick";
vrifle.material = "basic";
vrifle.group_id = "firearm";
vrifle.metallic = true;
vrifle.setCost(0, "common_metals", 4, "wood", 5);
vrifle.minimum_city_storage_resource_1 = 1;
vrifle.rigidity_rating = 7;
vrifle.is_pool_weapon = true;
vrifle.pool_rate = 15;
vrifle.path_icon = "ui/icons/items/icon_vrifle";
vrifle.path_gameplay_sprite = "weapons/vrifle_copper";
vrifle.projectile = "shotgun_bullet";
vrifle.path_slash_animation = "effects/slashes/slash_punch";
vrifle.base_stats["projectiles"] = 1f;
vrifle.base_stats["attack_speed"] = 0.5f;
vrifle.base_stats["accuracy"] = 0.9f;
vrifle.base_stats["damage"] = 20f;
vrifle.base_stats["critical_chance"] = 0.2f;
vrifle.base_stats["critical_damage_multiplier"] = 0.3f;
vrifle.base_stats["recoil"] = 0.1f;
vrifle.base_stats["range"] = 15f;
vrifle.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
vrifle.base_stats["targets"] = 1f;
vrifle.base_stats["damage_range"] = 0.8f;
vrifle.base_stats["mana"] = 00f;
vrifle.base_stats["stamina"] = 15f;
vrifle.equipment_value = 1100;
vrifle.gameplay_sprites = FetchSprites("vrifle");
AssetManager.items.add(vrifle);
AssetManager.items.pot_weapon_assets_all.Add(vrifle);
AssetManager.items.pot_weapon_assets_unlocked.Add(vrifle);
addWeaponsSprite(vrifle.id);

ProjectileAsset gauss = new ProjectileAsset();
            gauss.id = "gauss";
            gauss.texture = "blueplasma";
            gauss.trail_effect_enabled = false;
            gauss.trigger_on_collision = true;
            gauss.look_at_target = true;
            gauss.draw_light_area = true;
            gauss.draw_light_size = 0.1f;
            gauss.end_effect = "kameboomtest";
            gauss.terraform_option = "demon_fireball";
            gauss.terraform_range = 3;
            gauss.scale_start = 0.1f;
            gauss.scale_target = 0.1f;
            gauss.speed = 20f;
            gauss.can_be_left_on_ground = true;
            gauss.can_be_blocked = true;
            AssetManager.projectiles.add(gauss);

            EquipmentAsset grifle = AssetManager.items.clone("grifle", "$range");
            grifle.equipment_type = EquipmentType.Weapon;
            grifle.translation_key = "Gauss_cannon";
            grifle.equipment_subtype = "stick";
            grifle.material = "basic";
            grifle.group_id = "firearm";
            grifle.metallic = true;
            grifle.setCost(0, "common_metals", 4, "adamantine", 1);
            grifle.minimum_city_storage_resource_1 = 1;
            grifle.rigidity_rating = 1;
            grifle.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            grifle.is_pool_weapon = true;
            grifle.pool_rate = 15;
            grifle.path_icon = "ui/icons/items/icon_grifle";
            grifle.path_gameplay_sprite = "weapons/grifle";
            grifle.projectile = "gauss";
            grifle.path_slash_animation = "effects/slashes/slash_punch";
            grifle.base_stats["projectiles"] = 1f;
            grifle.base_stats["accuracy"] = 0.7f;
            grifle.base_stats["attack_speed"] = -5f;
            grifle.base_stats["damage"] = 1000f;
            grifle.base_stats["critical_chance"] = 0.5f;
            grifle.base_stats["critical_damage_multiplier"] = 0.5f;
            grifle.base_stats["recoil"] = 2f;
            grifle.base_stats["range"] = 20f;
            grifle.base_stats["targets"] = 3f;
            grifle.base_stats["damage_range"] = 0.7f;
            grifle.base_stats["mana"] = 10f;
            grifle.base_stats["stamina"] = 20f;
            grifle.equipment_value = 1125;
            grifle.gameplay_sprites = FetchSprites("grifle");
            AssetManager.items.add(grifle);
            AssetManager.items.pot_weapon_assets_all.Add(grifle);
            AssetManager.items.pot_weapon_assets_unlocked.Add(grifle);
            addWeaponsSprite(grifle.id);

            EquipmentAsset Minigun = AssetManager.items.clone("Minigun", "$range");
            Minigun.equipment_type = EquipmentType.Weapon;
            Minigun.translation_key = "Minigun";
            Minigun.animated = true;
            Minigun.equipment_subtype = "stick";
            Minigun.material = "basic";
            Minigun.group_id = "firearm";
            Minigun.metallic = true;
            Minigun.setCost(0, "adamantine", 1, "stone", 10);
            Minigun.minimum_city_storage_resource_1 = 1;
            Minigun.rigidity_rating = 3;
            Minigun.is_pool_weapon = true;
            Minigun.pool_rate = 15;
            Minigun.path_icon = "ui/icons/items/icon_Minigun";
            Minigun.path_gameplay_sprite = "weapons/Minibase";
            Minigun.projectile = "shotgun_bullet";
            Minigun.path_slash_animation = "effects/slashes/slash_punch";
            Minigun.base_stats["projectiles"] = 1f;
            Minigun.base_stats["attack_speed"] = 20000f;
            Minigun.base_stats["accuracy"] = 0.3f;
            Minigun.base_stats["damage"] = 20f;
            Minigun.base_stats["critical_chance"] = 0.2f;
            Minigun.base_stats["critical_damage_multiplier"] = 0.3f;
            Minigun.base_stats["recoil"] = 0f;
            Minigun.base_stats["range"] = 15f;
             Minigun.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            Minigun.base_stats["targets"] = 1f;
            Minigun.base_stats["damage_range"] = 0.8f;
            Minigun.base_stats["mana"] = 10f;
            Minigun.base_stats["stamina"] = 15f;
            Minigun.equipment_value = 1150;
Minigun.gameplay_sprites = FetchSprites("Minigun");
            AssetManager.items.add(Minigun);
            AssetManager.items.pot_weapon_assets_all.Add(Minigun);
            AssetManager.items.pot_weapon_assets_unlocked.Add(Minigun);
            addWeaponsSprite(Minigun.id);

            EquipmentAsset Sniper = AssetManager.items.clone("Sniper", "$range");
            Sniper.equipment_type = EquipmentType.Weapon;
            Sniper.translation_key = "Sniper";
            Sniper.animated = false;
            Sniper.equipment_subtype = "stick";
            Sniper.material = "basic";
            Sniper.group_id = "firearm";
            Sniper.metallic = true;
            Sniper.setCost(0, "wood", 5, "adamantine", 2);
            Sniper.minimum_city_storage_resource_1 = 1;
            Sniper.rigidity_rating = 1;
            Sniper.is_pool_weapon = true;
            Sniper.pool_rate = 15;
            Sniper.path_icon = "ui/icons/items/icon_Sniper";
            Sniper.path_gameplay_sprite = "weapons/Sniper";
            Sniper.projectile = "shotgun_bullet";
            Sniper.path_slash_animation = "effects/slashes/slash_punch";
            Sniper.base_stats["projectiles"] = 1f;
            Sniper.base_stats["attack_speed"] = -10f;
            Sniper.base_stats["accuracy"] = 4f;
            Sniper.base_stats["damage"] = 300f;
            Sniper.base_stats["critical_chance"] = 0.5f;
            Sniper.base_stats["critical_damage_multiplier"] = 0.8f;
            Sniper.base_stats["recoil"] = 2f;
            Sniper.base_stats["range"] = 30f;
             Sniper.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            Sniper.base_stats["targets"] = 1f;
            Sniper.base_stats["damage_range"] = 0.1f;
            Sniper.base_stats["mana"] = 10f;
            Sniper.base_stats["stamina"] = 15f;
            Sniper.equipment_value = 1175;
Sniper.gameplay_sprites = FetchSprites("Sniper");
            AssetManager.items.add(Sniper);
            AssetManager.items.pot_weapon_assets_all.Add(Sniper);
            AssetManager.items.pot_weapon_assets_unlocked.Add(Sniper);
            addWeaponsSprite(Sniper.id);


                        EffectAsset firepower_boom = new EffectAsset();
firepower_boom.id = "firepower_boom";
firepower_boom.use_basic_prefab = true;
firepower_boom.sorting_layer_id = "EffectsTop";
firepower_boom.sprite_path = "effects/firepower_boom";
firepower_boom.draw_light_area = true;
AssetManager.effects_library.add(firepower_boom);

            ProjectileAsset firepower = new ProjectileAsset();
            firepower.id = "firepower";
            firepower.texture = "firepower";
            firepower.trail_effect_enabled = false;
            firepower.trigger_on_collision = true;
            firepower.look_at_target = true;
            firepower.draw_light_area = true;
            firepower.draw_light_size = 1f;
            firepower.end_effect = "firepower_boom";
            firepower.terraform_option = "demon_fireball";
            firepower.terraform_range = 1;
            firepower.scale_start = 0.1f;
            firepower.scale_target = 1.0f;
            firepower.speed = 20f;
            firepower.can_be_left_on_ground = true;
            firepower.can_be_blocked = false;
            AssetManager.projectiles.add(firepower);

            EquipmentAsset Flamethrower = AssetManager.items.clone("Flamethrower", "$range");
            Flamethrower.equipment_type = EquipmentType.Weapon;
            Flamethrower.translation_key = "flamethrower";
            Flamethrower.equipment_subtype = "stick";
            Flamethrower.material = "basic";
            Flamethrower.group_id = "firearm";
            Flamethrower.metallic = true;
            Flamethrower.setCost(0, "adamantine", 3);
            Flamethrower.minimum_city_storage_resource_1 = 1;
            Flamethrower.rigidity_rating = 1;
            Flamethrower.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            Flamethrower.is_pool_weapon = true;
            Flamethrower.pool_rate = 15;
            Flamethrower.path_icon = "ui/icons/items/icon_Flamethrower";
            Flamethrower.path_gameplay_sprite = "weapons/RPG";
            Flamethrower.projectile = "firepower";
            Flamethrower.path_slash_animation = "effects/slashes/slash_punch";
            Flamethrower.base_stats["projectiles"] = 5f;
            Flamethrower.base_stats["accuracy"] = -1f;
            Flamethrower.base_stats["attack_speed"] = 100f;
            Flamethrower.base_stats["damage"] = 0f;
            Flamethrower.base_stats["critical_chance"] = 0f;
            Flamethrower.base_stats["critical_damage_multiplier"] = 0f;
            Flamethrower.base_stats["recoil"] = 0f;
            Flamethrower.base_stats["range"] = 10f;
            Flamethrower.base_stats["targets"] = 30f;
            Flamethrower.base_stats["damage_range"] = 0f;
            Flamethrower.base_stats["mana"] = 0f;
            Flamethrower.base_stats["stamina"] = 20f;
            Flamethrower.equipment_value = 1200;
Flamethrower.gameplay_sprites = FetchSprites("Flamethrower");
Flamethrower.item_modifier_ids = AssetLibrary<EquipmentAsset>.a<string>("flame");
            AssetManager.items.add(Flamethrower);
            AssetManager.items.pot_weapon_assets_all.Add(Flamethrower);
            AssetManager.items.pot_weapon_assets_unlocked.Add(Flamethrower);
            addWeaponsSprite(Flamethrower.id);



          ProjectileAsset RPGload = new ProjectileAsset();
          RPGload.id = "RPGload";
          RPGload.texture = "RPGload";
          RPGload.trail_effect_enabled = false;
          RPGload.trigger_on_collision = true;
	      RPGload.look_at_target = true;
          RPGload.draw_light_area = true;
	      RPGload.draw_light_size = 0.1f;
          RPGload.end_effect = "fx_fireball_explosion";
          RPGload.terraform_option = "demon_fireball";
          RPGload.terraform_range = 3;
          RPGload.scale_start = 0.1f;
          RPGload.scale_target = 0.1f;
          RPGload.speed = 20f;
          RPGload.can_be_left_on_ground = true;
          RPGload.can_be_blocked = true;
          AssetManager.projectiles.add(RPGload);

            EquipmentAsset RPG = AssetManager.items.clone("RPG", "$range");
            RPG.equipment_type = EquipmentType.Weapon;
            RPG.translation_key = "Rocket-propelled grenade";
            RPG.equipment_subtype = "stick";
            RPG.material = "basic";
            RPG.group_id = "firearm";
            RPG.metallic = true;
            RPG.setCost(0, "adamantine", 5);
            RPG.minimum_city_storage_resource_1 = 1;
            RPG.rigidity_rating = 1;
            RPG.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            RPG.is_pool_weapon = true;
            RPG.pool_rate = 15;
            RPG.path_icon = "ui/icons/items/icon_RocketLauncher";
            RPG.path_gameplay_sprite = "weapons/RPG";
            RPG.projectile = "RPGload";
            RPG.path_slash_animation = "effects/slashes/slash_punch";
            RPG.base_stats["projectiles"] = 1f;
            RPG.base_stats["accuracy"] = 0.7f;
            RPG.base_stats["attack_speed"] = -5f;
            RPG.base_stats["damage"] = 100f;
            RPG.base_stats["critical_chance"] = 0.5f;
            RPG.base_stats["critical_damage_multiplier"] = 0.5f;
            RPG.base_stats["recoil"] = 2f;
            RPG.base_stats["range"] = 20f;
            RPG.base_stats["targets"] = 3f;
            RPG.base_stats["damage_range"] = 0.7f;
            RPG.base_stats["mana"] = 10f;
            RPG.base_stats["stamina"] = 20f;
            RPG.equipment_value = 1225;
RPG.gameplay_sprites = FetchSprites("RPG");
            AssetManager.items.add(RPG);
            AssetManager.items.pot_weapon_assets_all.Add(RPG);
            AssetManager.items.pot_weapon_assets_unlocked.Add(RPG);
            addWeaponsSprite(RPG.id);

                        EquipmentAsset M32 = AssetManager.items.clone("M32", "$range");
            M32.equipment_type = EquipmentType.Weapon;
            M32.translation_key = "M32, the friendly grenade launcher!";
            M32.equipment_subtype = "stick";
            M32.material = "basic";
            M32.group_id = "firearm";
            M32.metallic = true;
            M32.setCost(0, "adamantine", 3, "stone", 5);
            M32.minimum_city_storage_resource_1 = 1;
            M32.rigidity_rating = 1;
            M32.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            M32.is_pool_weapon = true;
            M32.pool_rate = 15;
            M32.path_icon = "ui/icons/items/icon_M32";
            M32.path_gameplay_sprite = "weapons/Sniper";
            M32.projectile = "cannonball";
            M32.path_slash_animation = "effects/slashes/slash_punch";
            M32.base_stats["projectiles"] = 1f;
            M32.base_stats["accuracy"] = 0.2f;
            M32.base_stats["attack_speed"] = 1f;
            M32.base_stats["damage"] = 70f;
            M32.base_stats["critical_chance"] = 0.5f;
            M32.base_stats["critical_damage_multiplier"] = 0.5f;
            M32.base_stats["recoil"] = 0.5f;
            M32.base_stats["range"] = 8f;
            M32.base_stats["targets"] = 3f;
            M32.base_stats["damage_range"] = 0.7f;
            M32.base_stats["mana"] = 10f;
            M32.base_stats["stamina"] = 20f;
            M32.equipment_value = 1250;
M32.gameplay_sprites = FetchSprites("M32");
            AssetManager.items.add(M32);
            AssetManager.items.pot_weapon_assets_all.Add(M32);
            AssetManager.items.pot_weapon_assets_unlocked.Add(M32);
            addWeaponsSprite(M32.id);

            EffectAsset fx_MGLexplosion_t = new EffectAsset();
fx_MGLexplosion_t.id = "fx_MGLexplosion_t";
fx_MGLexplosion_t.use_basic_prefab = true;
fx_MGLexplosion_t.sorting_layer_id = "EffectsTop";
fx_MGLexplosion_t.sprite_path = "effects/fx_MGLexplosion_t";
fx_MGLexplosion_t.draw_light_area = true;
AssetManager.effects_library.add(fx_MGLexplosion_t);

 ProjectileAsset MGLload = new ProjectileAsset();
          MGLload.id = "MGLload";
          MGLload.texture = "MGLload";
          MGLload.trail_effect_enabled = false;
          MGLload.trigger_on_collision = true;
	      MGLload.look_at_target = true;
          MGLload.draw_light_area = true;
	      MGLload.draw_light_size = 0.1f;
          MGLload.end_effect = "fx_MGLexplosion_t";
          MGLload.terraform_option = "acid_ball";
          MGLload.terraform_range = 3;
          MGLload.scale_start = 0.1f;
          MGLload.scale_target = 1.0f;
          MGLload.speed = 20f;
          MGLload.can_be_left_on_ground = true;
          MGLload.can_be_blocked = false;
          AssetManager.projectiles.add(MGLload);

            EquipmentAsset MGL = AssetManager.items.clone("MGL", "$range");
            MGL.equipment_type = EquipmentType.Weapon;
            MGL.translation_key = "madness_gas_launcher";
            MGL.equipment_subtype = "stick";
            MGL.material = "basic";
            MGL.group_id = "firearm";
            MGL.metallic = true;
            MGL.setCost(0, "common_metals", 10, "adamantine", 5);
            MGL.minimum_city_storage_resource_1 = 1;
            MGL.rigidity_rating = 1;
            MGL.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            MGL.is_pool_weapon = true;
            MGL.pool_rate = 15;
            MGL.path_icon = "ui/icons/items/icon_MGL";
            MGL.path_gameplay_sprite = "weapons/RPG";
            MGL.projectile = "MGLload";
            MGL.path_slash_animation = "effects/slashes/slash_punch";
            MGL.base_stats["projectiles"] = 10f;
            MGL.base_stats["accuracy"] = -1f;
            MGL.base_stats["attack_speed"] = 1f;
            MGL.base_stats["damage"] = 0f;
            MGL.base_stats["critical_chance"] = 0f;
            MGL.base_stats["critical_damage_multiplier"] = 0f;
            MGL.base_stats["recoil"] = 0f;
            MGL.base_stats["range"] = 10f;
            MGL.base_stats["targets"] = 1f;
            MGL.base_stats["damage_range"] = 0f;
            MGL.base_stats["mana"] = 10f;
            MGL.base_stats["stamina"] = 20f;
            MGL.equipment_value = 1275;
MGL.gameplay_sprites = FetchSprites("MGL");
MGL.item_modifier_ids = AssetLibrary<EquipmentAsset>.a<string>("poison");
            AssetManager.items.add(MGL);
            addWeaponsSprite(MGL.id);


            ProjectileAsset mininuke = new ProjectileAsset();
            mininuke.id = "mininuke";
            mininuke.texture = "mininuke";
            mininuke.trail_effect_enabled = false;
            mininuke.trigger_on_collision = true;
            mininuke.look_at_target = true;
            mininuke.draw_light_area = true;
            mininuke.draw_light_size = 0.1f;
            mininuke.end_effect = "fx_explosion_nuke_atomic";
            mininuke.terraform_option = "atomic_bomb";
            mininuke.terraform_range = 2;
            mininuke.scale_start = 0.1f;
            mininuke.scale_target = 0.1f;
            mininuke.speed = 20f;
            mininuke.can_be_left_on_ground = true;
            mininuke.can_be_blocked = true;
            AssetManager.projectiles.add(mininuke);

            EquipmentAsset bigboy = AssetManager.items.clone("bigboy", "$range");
            bigboy.equipment_type = EquipmentType.Weapon;
            bigboy.translation_key = "Fatman";
            bigboy.equipment_subtype = "stick";
            bigboy.material = "basic";
            bigboy.group_id = "firearm";
            bigboy.metallic = true;
            bigboy.setCost(0, "adamantine", 20);
            bigboy.minimum_city_storage_resource_1 = 1;
            bigboy.rigidity_rating = 1;
            bigboy.name_templates = AssetLibrary<ItemAsset>.l<string>("shotgun_name");
            bigboy.is_pool_weapon = true;
            bigboy.pool_rate = 15;
            bigboy.path_icon = "ui/icons/items/icon_bigboy";
            bigboy.path_gameplay_sprite = "weapons/bigboy";
            bigboy.projectile = "mininuke";
            bigboy.path_slash_animation = "effects/slashes/slash_punch";
            bigboy.base_stats["projectiles"] = 1f;
            bigboy.base_stats["accuracy"] = 0.7f;
            bigboy.base_stats["attack_speed"] = -10f;
            bigboy.base_stats["damage"] = 100f;
            bigboy.base_stats["critical_chance"] = 0.5f;
            bigboy.base_stats["critical_damage_multiplier"] = 0.5f;
            bigboy.base_stats["recoil"] = 2f;
            bigboy.base_stats["range"] = 20f;
            bigboy.base_stats["targets"] = 1f;
            bigboy.base_stats["damage_range"] = 0.7f;
            bigboy.base_stats["mana"] = 10f;
            bigboy.base_stats["stamina"] = 20f;
            bigboy.equipment_value = 1300;
            bigboy.gameplay_sprites = FetchSprites("bigboy");
            AssetManager.items.add(bigboy);
            AssetManager.items.pot_weapon_assets_all.Add(bigboy);
            AssetManager.items.pot_weapon_assets_unlocked.Add(bigboy);
            addWeaponsSprite(bigboy.id);



            ///////////////ARMOR///////////////////////////////////////////////////////////////

            EquipmentAsset ModernArmor = AssetManager.items.clone("modernarmor", "$armor");
            ModernArmor.equipment_type = EquipmentType.Armor;
            ModernArmor.material = "basic";
            ModernArmor.metallic = true;
            ModernArmor.path_icon = "ui/icons/items/icon_modernarmor";
            ModernArmor.name_templates = AssetLibrary<ItemAsset>.l<string>("armor_name");
            ModernArmor.setCost(0, "wood", 1);
            ModernArmor.minimum_city_storage_resource_1 = 1;
            ModernArmor.rigidity_rating = 4;
            ModernArmor.base_stats["armor"] = 20f;
            ModernArmor.base_stats["stamina"] = 20f;
            ModernArmor.equipment_value = 700;
            AssetManager.items.add(ModernArmor);


            EquipmentAsset ModernHelmet = AssetManager.items.clone("modernhelmet", "$helmet");
            ModernHelmet.equipment_type = EquipmentType.Helmet;
            ModernHelmet.material = "basic";
            ModernHelmet.metallic = true;
            ModernHelmet.path_icon = "ui/icons/items/icon_modernhelmet";
            ModernHelmet.setCost(0, "wood", 1);
            ModernHelmet.name_templates = AssetLibrary<ItemAsset>.l<string>("helmet_name");
            ModernHelmet.minimum_city_storage_resource_1 = 1;
            ModernHelmet.rigidity_rating = 4;
            ModernHelmet.base_stats["armor"] = 5f;
            ModernHelmet.base_stats["mana"] = 10f;
            ModernHelmet.base_stats["accuracy"] = 0.6f;
            ModernHelmet.equipment_value = 700;
            AssetManager.items.add(ModernHelmet);

            EquipmentAsset ModernBoots = AssetManager.items.clone("modernboots", "$boots");
            ModernBoots.equipment_type = EquipmentType.Boots;
            ModernBoots.metallic = true;
            ModernBoots.material = "basic";
            ModernBoots.setCost(0, "wood", 1);
            ModernBoots.path_icon = "ui/icons/items/icon_modernboots";
            ModernBoots.name_templates = AssetLibrary<ItemAsset>.l<string>("boots_name");
            ModernBoots.minimum_city_storage_resource_1 = 1;
            ModernBoots.rigidity_rating = 4;
            ModernBoots.base_stats["armor"] = 5f;
            ModernBoots.base_stats["speed"] = 15f;
            ModernBoots.base_stats["stamina"] = 3f;
            ModernBoots.equipment_value = 700;
            AssetManager.items.add(ModernBoots);

            //////////////////////////Equipments/////////////////////////////////////////////////

            EquipmentAsset GrenadeBelt = AssetManager.items.clone("grenadebelt", "$amulet");
            GrenadeBelt.equipment_type = EquipmentType.Ring;
            GrenadeBelt.group_id = "ring";
            GrenadeBelt.equipment_subtype = "ring";
            GrenadeBelt.material = "basic";
            GrenadeBelt.metallic = true;
            GrenadeBelt.name_templates = AssetLibrary<ItemAsset>.l<string>("ring_name");
            GrenadeBelt.setCost(0, "common_metals", 1);
            GrenadeBelt.path_icon = "ui/icons/items/MK2Ariel";
            GrenadeBelt.minimum_city_storage_resource_1 = 1;
            GrenadeBelt.rigidity_rating = 2;
            GrenadeBelt.base_stats["damage"] = 10f;
            GrenadeBelt.base_stats["critical_chance"] = 0.3f;
            GrenadeBelt.base_stats["stamina"] = 10f;
            GrenadeBelt.equipment_value = 700;
            AssetManager.items.add(GrenadeBelt);

            EquipmentAsset MedicPack = AssetManager.items.clone("medicpack", "$ring");
            MedicPack.equipment_type = EquipmentType.Amulet;
            MedicPack.metallic = true;
            MedicPack.equipment_subtype = "amulet";
            MedicPack.group_id = "amulet";
            MedicPack.path_icon = "ui/icons/items/MEDIC";
            MedicPack.name_templates = AssetLibrary<ItemAsset>.l<string>("amulet_name");
            MedicPack.material = "basic";
            MedicPack.setCost(0, "herbs", 1);
            MedicPack.minimum_city_storage_resource_1 = 1;
            MedicPack.rigidity_rating = 2;
            MedicPack.base_stats["health"] = 30f;
            MedicPack.base_stats["stamina"] = 20f;
            MedicPack.equipment_value = 700;
            AssetManager.items.add(MedicPack);

            /////////////////////////////////////////////////////////////////////////////
            CustomItemsList.InitCustomItems();

            if (!AssetManager.items.equipment_by_subtypes.ContainsKey("firearm"))
            {
                AssetManager.items.equipment_by_subtypes.Add("firearm", new List<EquipmentAsset>());
            }

            if (!AssetManager.items.equipment_by_subtypes.ContainsKey("stick"))
            {
                AssetManager.items.equipment_by_subtypes.Add("stick", new List<EquipmentAsset>());
            }

            AssetManager.items.equipment_by_subtypes["stick"].Add(Glock17);
            AssetManager.items.equipment_by_subtypes["stick"].Add(AK);
            AssetManager.items.equipment_by_subtypes["stick"].Add(RPG);
            AssetManager.items.equipment_by_subtypes["stick"].Add(Minigun);
            AssetManager.items.equipment_by_subtypes["stick"].Add(Sniper);
            AssetManager.items.equipment_by_subtypes["stick"].Add(FAMAS);
            AssetManager.items.equipment_by_subtypes["stick"].Add(M4A1);
            AssetManager.items.equipment_by_subtypes["stick"].Add(ThompsonM1A1);
            AssetManager.items.equipment_by_subtypes["stick"].Add(SGT44);
            AssetManager.items.equipment_by_subtypes["stick"].Add(XM8);
            AssetManager.items.equipment_by_subtypes["stick"].Add(AK103);
            AssetManager.items.equipment_by_subtypes["stick"].Add(Uzi);
            AssetManager.items.equipment_by_subtypes["stick"].Add(Malorian);
            AssetManager.items.equipment_by_subtypes["stick"].Add(DesertEagle);
            AssetManager.items.equipment_by_subtypes["stick"].Add(M16);
            AssetManager.items.equipment_by_subtypes["stick"].Add(HK416);
            AssetManager.items.equipment_by_subtypes["stick"].Add(MP7);
            AssetManager.items.equipment_by_subtypes["stick"].Add(M32);
            AssetManager.items.equipment_by_subtypes["stick"].Add(Americanshotgun);
            AssetManager.items.equipment_by_subtypes["stick"].Add(Sluggershotgun);
            AssetManager.items.equipment_by_subtypes["stick"].Add(Flamethrower);
            AssetManager.items.equipment_by_subtypes["stick"].Add(vrifle);
            AssetManager.items.equipment_by_subtypes["stick"].Add(bigboy);
            AssetManager.items.equipment_by_subtypes["stick"].Add(grifle);
            AssetManager.items.equipment_by_subtypes["stick"].Add(MGL);

            if (!AssetManager.items.pot_equipment_by_groups_all.ContainsKey("firearm"))
            {
                AssetManager.items.pot_equipment_by_groups_all.Add("firearm", new List<EquipmentAsset>());
            }
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Glock17);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(AK);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(RPG);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Minigun);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Sniper);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(FAMAS);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(M4A1);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(ThompsonM1A1);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(SGT44);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(XM8);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(AK103);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Uzi);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Malorian);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(DesertEagle);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(M16);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(HK416);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(MP7);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(M32);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Americanshotgun);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Sluggershotgun);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(Flamethrower);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(vrifle);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(bigboy);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(grifle);
            AssetManager.items.pot_equipment_by_groups_all["firearm"].Add(MGL);

            if (!AssetManager.items.pot_equipment_by_groups_unlocked.ContainsKey("firearm"))
            {
                AssetManager.items.pot_equipment_by_groups_unlocked.Add("firearm", new List<EquipmentAsset>());
            }
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Glock17);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(AK);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(RPG);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Minigun);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Sniper);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(FAMAS);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(M4A1);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(ThompsonM1A1);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(SGT44);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(XM8);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(AK103);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Uzi);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Malorian);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(DesertEagle);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(M16);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(HK416);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(MP7);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(M32);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Americanshotgun);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Sluggershotgun);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(Flamethrower);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(vrifle);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(bigboy);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(grifle);
            AssetManager.items.pot_equipment_by_groups_unlocked["firearm"].Add(MGL);


            /////////////////////////////////////////////////////////////////////////////


             if (!AssetManager.items.pot_equipment_by_groups_all.ContainsKey("boots"))
            {
                AssetManager.items.pot_equipment_by_groups_all.Add("boots", new List<EquipmentAsset>());
            }
            AssetManager.items.pot_equipment_by_groups_all["boots"].Add(ModernBoots);


            if (!AssetManager.items.pot_equipment_by_groups_all.ContainsKey("helmet"))
            {
                AssetManager.items.pot_equipment_by_groups_all.Add("helmet", new List<EquipmentAsset>());
            }
            AssetManager.items.pot_equipment_by_groups_all["helmet"].Add(ModernHelmet);


              if (!AssetManager.items.pot_equipment_by_groups_all.ContainsKey("armor"))
            {
                AssetManager.items.pot_equipment_by_groups_all.Add("armor", new List<EquipmentAsset>());
            }
            AssetManager.items.pot_equipment_by_groups_all["armor"].Add(ModernArmor);





            /////////////////////////////////////////////////////////////////////////////
            if (!AssetManager.items.pot_equipment_by_groups_all.ContainsKey("ring"))
            {
                AssetManager.items.pot_equipment_by_groups_all.Add("ring", new List<EquipmentAsset>());
            }
            AssetManager.items.pot_equipment_by_groups_all["ring"].Add(GrenadeBelt);


            if (!AssetManager.items.pot_equipment_by_groups_all.ContainsKey("amulet"))
            {
                AssetManager.items.pot_equipment_by_groups_all.Add("amulet", new List<EquipmentAsset>());
            }
            AssetManager.items.pot_equipment_by_groups_all["amulet"].Add(MedicPack);


                if (!AssetManager.items.pot_equipment_by_groups_unlocked.ContainsKey("amulet"))
            {
                AssetManager.items.pot_equipment_by_groups_unlocked.Add("amulet", new List<EquipmentAsset>());
            }
              AssetManager.items.pot_equipment_by_groups_unlocked["amulet"].Add(MedicPack);


                if (!AssetManager.items.pot_equipment_by_groups_unlocked.ContainsKey("ring"))
            {
                AssetManager.items.pot_equipment_by_groups_unlocked.Add("ring", new List<EquipmentAsset>());
            }
           AssetManager.items.pot_equipment_by_groups_unlocked["ring"].Add(GrenadeBelt);


         if (!AssetManager.items.equipment_by_subtypes.ContainsKey("amulet"))
            {
                AssetManager.items.equipment_by_subtypes.Add("amulet", new List<EquipmentAsset>());
            }
         AssetManager.items.equipment_by_subtypes["amulet"].Add(MedicPack);


         if (!AssetManager.items.equipment_by_subtypes.ContainsKey("ring"))
            {
                AssetManager.items.equipment_by_subtypes.Add("ring", new List<EquipmentAsset>());
            }
         AssetManager.items.equipment_by_subtypes["ring"].Add(GrenadeBelt);


        }




public static void FixAllWeapons()
{
    Debug.Log("[FixAllWeapons] Starting weapon sprite fix pass...");

    int totalChecked = 0;
    int totalFixed = 0;
    int totalSkipped = 0;

    foreach (var kvp in AssetManager.items.list)
    {
        string id = kvp.id;
        EquipmentAsset asset = kvp;

        if (asset == null)
        {
            Debug.LogWarning($"[FixAllWeapons] Skipping item with id '{id}': Not an EquipmentAsset.");
            totalSkipped++;
            continue;
        }

        totalChecked++;

        if (asset.gameplay_sprites == null || asset.gameplay_sprites.Length == 0)
        {
            Debug.Log($"[FixAllWeapons] Missing sprites for '{id}', attempting to fix...");
            var sprites = FetchSprites(id);
            asset.gameplay_sprites = sprites;

            if (asset.gameplay_sprites != null && asset.gameplay_sprites.Length > 0)
            {
                Debug.Log($"[FixAllWeapons] Successfully fixed '{id}' with {asset.gameplay_sprites.Length} sprites.");
                totalFixed++;
            }
            else
            {
                Debug.LogError($"[FixAllWeapons] Failed to fix '{id}', sprites still missing.");
            }
        }
        else
        {
            Debug.Log($"[FixAllWeapons] '{id}' already has {asset.gameplay_sprites.Length} sprites, skipping.");
        }
    }

    Debug.Log($"[FixAllWeapons] Done. Checked: {totalChecked}, Fixed: {totalFixed}, Skipped (non-weapon): {totalSkipped}");
}


public static void addWeaponsSprite(string id)
{
    Debug.Log("[addWeaponsSprite] Attempting to load sprite for weapon: " + id);

    EquipmentAsset item = AssetManager.items.get(id);

    if (item == null)
    {
        Debug.LogError("[addWeaponsSprite] Item not found in AssetManager: " + id);
        return;
    }

    item.gameplay_sprites = FetchSprites(id);
    Debug.Log("[addWeaponsSprite] Sprite assignment complete for: " + id);
}

public static Sprite[] FetchSprites(string id)
{
    Debug.Log("[FetchSprites] Fetching sprites for weapon: " + id);

    EquipmentAsset item = AssetManager.items.get(id);
    if (item == null)
    {
        Debug.LogError("[FetchSprites] Item not found in AssetManager: " + id);
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
                Debug.Log("[FetchSprites] Loaded sprite: " + path1);
                spriteList.Add(frameSprite);
                framesFound = true;
                frameIndex++;
                continue;
            }

            string path2 = "weapons/" + id + frameIndex;
            frameSprite = Resources.Load<Sprite>(path2);

            if (frameSprite != null)
            {
                Debug.Log("[FetchSprites] Loaded sprite: " + path2);
                spriteList.Add(frameSprite);
                framesFound = true;
                frameIndex++;
                continue;
            }

            if (framesFound)
            {
                Debug.Log("[FetchSprites] Finished loading sequence frames after index " + frameIndex);
                break;
            }

            string path3 = "weapons/" + id + "/main_0_" + frameIndex;
            frameSprite = Resources.Load<Sprite>(path3);

            if (frameSprite != null)
            {
                Debug.Log("[FetchSprites] Loaded sprite: " + path3);
                spriteList.Add(frameSprite);
                framesFound = true;
                frameIndex++;
                continue;
            }

            if (frameIndex > 0)
            {
                Debug.Log("[FetchSprites] No more frames found beyond index: " + frameIndex);
                break;
            }

            string bulkPath = "weapons/" + id;
            Sprite[] sprites = Resources.LoadAll<Sprite>(bulkPath);
            if (sprites != null && sprites.Length > 0)
            {
                Debug.Log("[FetchSprites] Loaded " + sprites.Length + " sprites from: " + bulkPath);
                spriteList.AddRange(sprites);
                framesFound = true;
            }
            else
            {
                Debug.LogWarning("[FetchSprites] No sprites found with LoadAll at: " + bulkPath);
            }

            break;

            if (frameIndex > 20)
            {
                Debug.LogWarning("[FetchSprites] Exceeded frame index limit (20). Aborting load.");
                break;
            }
        }

        if (framesFound && spriteList.Count > 0)
        {
            Debug.Log("[FetchSprites] Returning " + spriteList.Count + " animated sprites for: " + id);
            return spriteList.ToArray();
        }
        else
        {
            Debug.LogError("[FetchSprites] No animations found for: " + id);
            var fallbackSprite = Resources.Load<Sprite>("weapons/" + id);
            if (fallbackSprite != null)
            {
                Debug.Log("[FetchSprites] Fallback sprite loaded for: " + id);
                return new Sprite[] { fallbackSprite };
            }
            else
            {
                Debug.LogError("[FetchSprites] No fallback sprite found for: " + id);
                return Array.Empty<Sprite>();
            }
        }
    }
    else
    {
        var sprite = Resources.Load<Sprite>("weapons/" + id);
        if (sprite != null)
        {
            Debug.Log("[FetchSprites] Loaded non-animated sprite for: " + id);
            return new Sprite[] { sprite };
        }
        else
        {
            Debug.LogError("[FetchSprites] No sprite found for non-animated weapon: " + id);
            return Array.Empty<Sprite>();
        }
    }
}

}
}
