//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using NCMS.Utils;
using NCMS;
using System.IO;
using UnityEngine;
using ReflectionUtility;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using System.Net.Http;
using System.Threading.Tasks;
namespace M2
{
 [ModEntry]
 class Main : MonoBehaviour
 {
 public Buttonz Buttonz = new Buttonz();
 public static Main instance;
 public Commerce Commerce = new Commerce();
 public Resourcez Resourcez = new Resourcez();
 public static SavedSettings savedSettings = new SavedSettings();
 private static string correctSettingsVersion = "2.1.0.1"; 
 public ModernKingdoms ModernKingdoms = new ModernKingdoms();
 public const string settingsKey = "MBoxSettings"; 
 public SpaceManager SpaceManager = new SpaceManager();
 public PlanetGenerator PlanetGenerator = new PlanetGenerator();
 public PlanetManager PlanetManager = new PlanetManager();
 public LocalizationManager LocalizationManager = new LocalizationManager ();
 private AudioSource audioSource;
 public DeveloperMode DeveloperMode = new DeveloperMode();
 public static bool isNewVersion;
 void PlayMP3(string fileName)
 {
 AudioClip clip = Resources.Load<AudioClip>(fileName);
 if (clip != null)
 {
 audioSource.clip = clip;
 audioSource.Play();
 }
 else
 {
 string filePath = System.IO.Path.Combine(Application.dataPath, "Resources", fileName + ".mp3");
 Debug.LogError("Audio file not found: " + filePath);
 }
 }
 static void PatchStuff()
 {
// Harmony.CreateAndPatchAll(typeof(Docks));
 //Harmony.CreateAndPatchAll(typeof(BuildingRenderer));
 //Harmony.CreateAndPatchAll(typeof(City));
 //Harmony.CreateAndPatchAll(typeof(ProduceItemPatch)); 
 //Harmony.CreateAndPatchAll(typeof(TryProduceItemPatch)); 
 //Harmony.CreateAndPatchAll(typeof(setLanguage)); 
 var harmony = new Harmony("com.tuxxego.m2");
	harmony.PatchAll();
 Debug.Log("Loading ModernBox shit");
 }
public void Awake()
{
	 loadSettings();

 Debug.Log("[M2] Mod Core has been called, booting mod core.");
     tab.createTab("Button Tab_ModernBox", "Tab_ModernBox", "M2", "Guns, Vehicles, Drugs, Casinos, MIRVs, and SPACE. Welcome to the Modern Age.", -150);

 Debug.Log("[M2] Loading SaveSystemWindow...");
 SaveSystemWindow.init();
 Debug.Log("[M2] SaveSystemWindow loaded!");
 Debug.Log("[M2] Loading InfoWindow...");
 InfoWindow.init();
 Debug.Log("[M2] InfoWindow loaded!");
 Debug.Log("[M2] Loading DiscordWindow...");
 DiscordWindow.init();
 Debug.Log("[M2] DiscordWindow loaded!");
 Debug.Log("[M2] Loading GuideWindow...");
 GuideWindow.init();
 Debug.Log("[M2] GuideWindow loaded!");
 Debug.Log("[M2] Loading NukeWindow...");
 NukeWindow.init();
 Debug.Log("[M2] NukeWindow loaded!");
 Debug.Log("[M2] Loading DeveloperWindow...");
 DeveloperWindow.init();
 Debug.Log("[M2] DeveloperWindow loaded!");
 Debug.Log("[M2] Patching stuff...");
 PatchStuff();
 Debug.Log("===============================");
 Debug.Log("ModernBox 2.1.0.1");
 Debug.Log("MADE BY TUXXEGO");
 Debug.Log("===============================");
 Debug.Log("[M2] Initializing Name...");
 Name.init();
 Debug.Log("[M2] Name loaded!");
 Debug.Log("[M2] Initializing guns...");
 guns.init();
 Debug.Log("[M2] guns loaded!");
 Debug.Log("[M2] Initializing MIRV...");
 MIRV.init();
 Debug.Log("[M2] MIRV loaded!");
 Debug.Log("[M2] Initializing ModernKingdoms...");
 ModernKingdoms.init();
 Debug.Log("[M2] ModernKingdoms loaded!");
 Debug.Log("[M2] Initializing cyberware...");
 cyberware.init();
 Debug.Log("[M2] cyberware loaded!");
   Debug.Log("[M2] Loading BombsWindow...");
 BombsWindow.init();
 Debug.Log("[M2] BombsWindow loaded!");
 Debug.Log("[M2] Initializing Buttonz...");
 Buttonz.init();
 Debug.Log("[M2] Buttonz loaded!");
 Debug.Log("[M2] Initializing tab...");
 tab.init();
 Debug.Log("[M2] tab loaded!");
 Debug.Log("[M2] Initializing MBTraitGroup...");
 MBTraitGroup.init();
 Debug.Log("[M2] MBTraitGroup loaded!");
 Debug.Log("[M2] Initializing Traits...");
 Traits.init();
 Debug.Log("[M2] Traits loaded!");
 Debug.Log("[M2] Initializing Resourcez...");
 Resourcez.init();
 Debug.Log("[M2] Resourcez loaded!");
 Debug.Log("[M2] Initializing Tech...");
 Tech.init();
 Debug.Log("[M2] Tech loaded!");
 Debug.Log("[M2] Initializing Commerce...");
 Commerce.init();
 Debug.Log("[M2] Commerce loaded!");
 Debug.Log("[M2] Initializing DefaultSettingsWindow...");
 DefaultSettingsWindow.init();
 Debug.Log("[M2] DefaultSettingsWindow loaded!");
 Debug.Log("[M2] Initializing CreditsWindow...");
 CreditsWindow.init();
 Debug.Log("[M2] CreditsWindow loaded!");
 Debug.Log("[M2] Initializing NewJobs...");
 NewJobs.init();
 Debug.Log("[M2] NewJobs loaded!");
 Debug.Log("[M2] Initializing Aircraft...");
 Aircraft.init();
 Debug.Log("[M2] Aircraft loaded!");
 Debug.Log("[M2] Initializing LandVehicles...");
 LandVehicles.init();
 Debug.Log("[M2] LandVehicles loaded!");
 Debug.Log("[M2] Initializing ModernMilitary...");
 ModernMilitary.init();
 Debug.Log("[M2] ModernMilitary loaded!");
 Debug.Log("[M2] Initializing Drugs...");
 Drugs.init();
 Debug.Log("[M2] Drugs loaded!");

 Debug.Log("[M2] Initializing GoliathCannon...");
 GoliathCannon.init();
 Debug.Log("[M2] GoliathCannon loaded!");
 

  Debug.Log("[M2] Initializing GoliathVehicles...");
 GoliathVehicles.init();
 Debug.Log("[M2] GoliathVehicles loaded!");
 
  Debug.Log("[M2] Initializing Creatures...");
  Creatures.init();
  Debug.Log("[M2] Creatures loaded!");

  Debug.Log("[M2] Space Manager starting...");
  SpaceManager = gameObject.AddComponent<SpaceManager>();
  Debug.Log("[M2] That big manager has started.");
  
         Debug.Log("SpaceBoxModernBox: Pls no lag!");
         //PatchStuff();

	


			MapGenTemplate ballsTemplate = new MapGenTemplate();

   ballsTemplate.id = "ballsass";
    ballsTemplate.values.add_center_gradient_land = true;
    ballsTemplate.values.main_perlin_noise_stage = true;
    ballsTemplate.values.perlin_noise_stage_2 = true;
    ballsTemplate.values.perlin_noise_stage_3 = true;
    ballsTemplate.values.add_mountain_edges = true;
    ballsTemplate.values.remove_mountains = false;
    ballsTemplate.allow_edit_low_ground = false;
    ballsTemplate.allow_edit_high_ground = false;
	AssetManager.map_gen_templates.newReplaceContainer(15);
    AssetManager.map_gen_templates.addReplaceOption(170, TileLibrary.soil_high, TileLibrary.soil_low);
    AssetManager.map_gen_templates.addReplaceOption(0, TileLibrary.shallow_waters, TileLibrary.soil_low);
    AssetManager.map_gen_templates.addReplaceOption(0, TileLibrary.close_ocean, TileLibrary.soil_low);
    AssetManager.map_gen_templates.addReplaceOption(0, TileLibrary.deep_ocean, TileLibrary.soil_high);
	AssetManager.map_gen_templates.add(ballsTemplate);

 audioSource = GetComponent<AudioSource>();
 PlayMP3("file");
 Debug.Log("ModernBox 2.1.0.1: Loaded.");
 if (isNewVersion)
 {
 Debug.Log("[M2] Showing SaveSystemWindow...");
 Windows.ShowWindow("SaveSystemWindow");
 }
}
 public static Building findNewBuildingTarget(City pCity, string pType)
 {
 return (Building)pCity.CallMethod("getBuildingType", pType, true, true);
 }
 public const string mainPath = "Mods/ModernBox";
 public static void resetToDefaults()
 {
 SavedSettings defaultSettings = new SavedSettings(); 
 Windows.ShowWindow("DefaultSettingsWindow");
 foreach (var option in defaultSettings.boolOptions)
 {
 savedSettings.boolOptions[option.Key] = option.Value;
 }
 saveSettings();
 }
 public static void saveSettings(SavedSettings previousSettings = null)
 {
 if (previousSettings != null && savedSettings.Equals(previousSettings))
 {
 Debug.Log("ModernBox: No changes to settings, skipping saving!");
 return; 
 }
 Debug.Log("===============================");
 Debug.Log("ModernBox 2.1.0.1");
 Debug.Log("Changes were made, saving!");
 Debug.Log("===============================");
 foreach (var option in savedSettings.boolOptions)
 {
 PlayerPrefs.SetInt(option.Key, option.Value ? 1 : 0);
 }
 PlayerPrefs.SetString("SettingVersion", correctSettingsVersion);
 PlayerPrefs.Save();
 }
 public static bool loadSettings()
 {
 isNewVersion = false;
 if (!PlayerPrefs.HasKey("SettingVersion"))
 {
 isNewVersion = true;
 saveSettings();
 return false;
 }
 string loadedVersion = PlayerPrefs.GetString("SettingVersion");
 if (loadedVersion != correctSettingsVersion)
 {
 isNewVersion = true;
 saveSettings();
 return false;
 }
 var keys = savedSettings.boolOptions.Keys.ToList();
 foreach (var key in keys)
 {
 savedSettings.boolOptions[key] = PlayerPrefs.GetInt(key) == 1;
 }
 return true;
 }
 public static void modifyBoolOption(string key, bool value, UnityAction call = null)
 {
 if (savedSettings.boolOptions.TryGetValue(key, out bool oldValue) && oldValue == value)
 {
 return; 
 }
 Main.savedSettings.boolOptions[key] = value;
 saveSettings();
 if (call != null)
 {
 call.Invoke();
 }
 }
 public static void getLocalization(string id, ref string name, ref string desc, string descAddOn){
 if (LocalizedTextManager.stringExists($"{id}"))
 {
 name = LocalizedTextManager.getText($"{id}");
 }
 if (LocalizedTextManager.stringExists($"{id}{descAddOn}"))
 {
 desc = LocalizedTextManager.getText($"{id}{descAddOn}");
 }
 }
 public static void updateDirtyStats()
 {
 foreach(Actor unit in World.world.units)
 {
 unit.setStatsDirty();
 }
 }
 }
[HarmonyPatch(typeof(City), "produceItem")]
public class ProduceItemPatch
{
 private static HashSet<string> invalidItemIDs = new HashSet<string>();
 static bool Prefix(ref bool __result, City __instance, Actor pActor, string pCreatorName, EquipmentType pType, int pTries)
 {
 if (!DeveloperMode.isDeveloperEnabled)
 return true; 
 Debug.Log($"[produceItem] Called with pActor: {pActor}, pCreatorName: {pCreatorName}, pType: {pType}, pTries: {pTries}");
 try
 {
 if (pActor == null)
 {
 Debug.LogError("[produceItem] Error: pActor is null");
 __result = false;
 return false;
 }
 List<ItemData> equipmentList = __instance.data?.storage?.getEquipmentList(pType); 
 if (equipmentList == null || equipmentList.Count >= __instance.status.maximumItems)
 {
 __result = false;
 return false;
 }
 Culture culture = pActor.getCulture();
 if (culture == null)
 {
 Debug.LogError("[produceItem] Error: pActor.getCulture() returned null");
 __result = false;
 return false;
 }
 ItemAssetLibrary<ItemAsset> pLib = null;
 switch (pType)
 {
 case EquipmentType.Weapon:
 pLib = (ItemAssetLibrary<ItemAsset>)AssetManager.items_material_weapon;
 break;
 case EquipmentType.Helmet:
 case EquipmentType.Armor:
 case EquipmentType.Boots:
 pLib = (ItemAssetLibrary<ItemAsset>)AssetManager.items_material_armor;
 break;
 case EquipmentType.Ring:
 case EquipmentType.Amulet:
 pLib = (ItemAssetLibrary<ItemAsset>)AssetManager.items_material_accessory;
 break;
 }
 string pID = AssetManager.items.getEquipmentID(pType);
 if (pID == "weapon")
 pID = __instance.race?.preferred_weapons?.GetRandom<string>(); 
 if (pID == null)
 {
 Debug.LogError("[produceItem] Error: pID is null");
 __result = false;
 return false;
 }
 Debug.Log($"[produceItem] Intermediate pID: {pID}");
 ItemAsset pItemAsset = AssetManager.items.get(pID);
 if (pItemAsset == null)
 {
 Debug.LogError($"[produceItem] Error: pItemAsset is null for pID: {pID}");
 if (!invalidItemIDs.Contains(pID))
 {
 invalidItemIDs.Add(pID);
 LogInvalidItem(pID);
 }
 __result = false;
 return false;
 }
 if (!string.IsNullOrEmpty(pItemAsset.tech_needed) && !culture.hasTech(pItemAsset.tech_needed))
 {
 Debug.LogError($"[produceItem] Error: Culture does not have required tech: {pItemAsset.tech_needed}");
 __result = false;
 return false;
 }
 ItemAsset materialForItem = __instance.data?.storage?.getMaterialForItem(pItemAsset, pLib, __instance); 
 if (materialForItem == null)
 {
 Debug.LogError($"[produceItem] Error: materialForItem is null for pItemAsset: {pItemAsset}, pLib: {pLib}");
 __result = false;
 return false;
 }
 __instance.data.storage.addItem(ItemGenerator.generateItem(pItemAsset, materialForItem.id, World.world.mapStats.year, __instance.kingdom, pCreatorName, pTries, (ActorBase)pActor), equipmentList);
 __instance.data.storage.change("gold", -materialForItem.cost_gold);
 if (materialForItem.cost_resource_id_1 != "none")
 __instance.data.storage.change(materialForItem.cost_resource_id_1, -materialForItem.cost_resource_1);
 if (materialForItem.cost_resource_id_2 != "none")
 __instance.data.storage.change(materialForItem.cost_resource_id_2, -materialForItem.cost_resource_2);
 Debug.Log($"[produceItem] Final pID: {pID}");
 __result = true;
 return false;
 }
 catch (Exception ex)
 {
 Debug.LogError($"[produceItem] Exception: {ex.Message}");
 Debug.LogError(ex.StackTrace);
 __result = false;
 return false;
 }
 }
 private static void LogInvalidItem(string pID)
 {
 string filePath = Path.Combine(Application.persistentDataPath, "invaliditems.txt");
 try
 {
 using (StreamWriter writer = File.AppendText(filePath))
 {
 writer.WriteLine(pID);
 }
 }
 catch (Exception ex)
 {
 Debug.LogError($"[produceItem] Failed to write invalid item ID to file: {ex.Message}");
 Debug.LogError(ex.StackTrace);
 }
 }
}
[HarmonyPatch(typeof(City), "tryProduceItem")]
public class TryProduceItemPatch
{
 static bool Prefix(ref bool __result, City __instance, Actor pActor, ItemProductionOrder pOrder)
 {
 if (!DeveloperMode.isDeveloperEnabled)
 return true; 
 Debug.Log($"[tryProduceItem] Called with pActor: {pActor}, pOrder: {pOrder}");
 try
 {
 if (pActor == null)
 {
 Debug.LogError("[tryProduceItem] Error: pActor is null");
 __result = false;
 return false;
 }
 Culture culture = pActor.getCulture();
 if (culture == null)
 {
 Debug.LogError("[tryProduceItem] Error: pActor.getCulture() returned null");
 __result = false;
 return false;
 }
 int num = 1;
 switch (pOrder)
 {
 case ItemProductionOrder.RandomArmor:
 if (!culture.hasTech("armor_production"))
 {
 Debug.LogError("[tryProduceItem] Error: Culture does not have armor production tech");
 __result = false;
 return false;
 }
 EquipmentType random = City.list_equipments.GetRandom<EquipmentType>();
 int pTries1 = num + (int)culture.stats.item_production_tries_armor.value;
 __result = __instance.produceItem(pActor, pActor.getName(), random, pTries1);
 return false;
 case ItemProductionOrder.Weapon:
 if (!culture.hasTech("weapon_production"))
 {
 Debug.LogError("[tryProduceItem] Error: Culture does not have weapon production tech");
 __result = false;
 return false;
 }
 int pTries2 = num + (int)culture.stats.item_production_tries_weapons.value;
 __result = __instance.produceItem(pActor, pActor.getName(), EquipmentType.Weapon, pTries2);
 return false;
 case ItemProductionOrder.Both:
 __result = __instance.tryProduceItem(pActor, ItemProductionOrder.RandomArmor) | __instance.tryProduceItem(pActor, ItemProductionOrder.Weapon);
 return false;
 default:
 __result = false;
 return false;
 }
 }
 catch (Exception ex)
 {
 Debug.LogError($"[tryProduceItem] Exception: {ex.Message}, pActor: {pActor}, pOrder: {pOrder}");
 Debug.LogError(ex.StackTrace);
 __result = false;
 return false;
 }
 }
}


}