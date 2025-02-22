//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;
using Assets.SimpleZip;

namespace M2 {
class Buttonz {
	
		internal static PowerButton BOMB1;
		internal static PowerButton BOMB2;
		internal static PowerButton BOMB3;
		internal static PowerButton BOMB4;
        internal static PowerButton BOMB5;
        internal static PowerButton BOMB6;
   	    internal static PowerButton BOMB7;
        internal static PowerButton BOMB8;
        internal static PowerButton BOMB9;
        internal static PowerButton BOMB10;
	    internal static PowerButton BOMB11;
        internal static PowerButton BOMB12;
        internal static PowerButton BOMB13;
        internal static PowerButton BOMB14;

		private static GodPower AtomicGrenadePower;
		private static DropAsset AtomicGrenadeDrop;		
		private static List<string> savedTechListREAL;

		private static readonly HashSet<string> bombIds = new HashSet<string>
		{
			"Bomb1", "Bomb2", "Bomb3", "Bomb4", "Bomb5", 
			"Bomb6", "Bomb7", "Bomb8", "Bomb9", "Bomb10",
			"Bomb11", "Bomb12", "Bomb13", "Bomb14", "Bomb15",
			"Bomb16", "Bomb17", "Bomb18", "Bomb19"
		};


		private const string PlayerPrefsKey = "UnlockedBombs";
	
  public static void init() {

   // tab.createTab("Button Tab_ModernBox", "Tab_ModernBox", "M2", "Guns, Vehicles, Drugs, Casinos, MIRVs, and SPACE. Welcome to the Modern Age.", -150);
    loadButtons();
  }
  private static void loadButtons() {
    PowersTab tab = getPowersTab("ModernBox");

    ScrollWindow tab2 = ScrollWindow.get("EXTRA BOMBS");


    // DropAsset spawnBoat2 = new DropAsset();
    // spawnBoat2.id = "spawnJob";
    // spawnBoat2.path_texture = "drops/drop_fireworks";
    // spawnBoat2.random_frame = true;
    // spawnBoat2.default_scale = 0.08f;
    // spawnBoat2.action_landed = new DropsAction(action_worker);
    // AssetManager.drops.add(spawnBoat2);

    GodPower MIRVPower = AssetManager.powers.clone("spawn_mirv_bomber", "_spawnActor");
    MIRVPower.name = "spawn_mirv_bomber";
    MIRVPower.actor_asset_id = "MIRVBomber";
    MIRVPower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower AirshipPower = AssetManager.powers.clone("spawn_airship", "_spawnActor");
    AirshipPower.name = "spawn_airship";
    AirshipPower.actor_asset_id = "Zeppelin";
    AirshipPower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower HeliPower = AssetManager.powers.clone("heli_spawn", "_spawnActor");
    HeliPower.name = "heli_spawn";
    HeliPower.actor_asset_id = "Heli";
    HeliPower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower GunshipPower = AssetManager.powers.clone("gunship_spawn", "_spawnActor");
    GunshipPower.name = "gunship_spawn";
    GunshipPower.actor_asset_id = "Gunship";
    GunshipPower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower TankPower = AssetManager.powers.clone("spawn_tank", "_spawnActor");
    TankPower.name = "spawn_tank";
    TankPower.actor_asset_id = "Tank";
    TankPower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower HumveePower = AssetManager.powers.clone("spawn_humvee", "_spawnActor");
    HumveePower.name = "spawn_humvee";
    HumveePower.actor_asset_id = "Humvee";
    HumveePower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower FighterJetPower = AssetManager.powers.clone("spawn_FighterJet", "_spawnActor");
    FighterJetPower.name = "spawn_FighterJet";
    FighterJetPower.actor_asset_id = "FighterJet";
    FighterJetPower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower ALIENPower = AssetManager.powers.clone("spawn_ALIEN", "_spawnActor");
    ALIENPower.name = "spawn_ALIEN";
    ALIENPower.actor_asset_id = "Xiexel";
    ALIENPower.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower TroopPower = AssetManager.powers.clone("spawn_Troop", "_spawnActor");
    TroopPower.name = "spawn_Troop";
    TroopPower.actor_asset_id = "Soldier";
    TroopPower.click_action = new PowerActionWithID(action_spawn_jet);

 GodPower DronePower = AssetManager.powers.clone("spawn_Drone", "_spawnActor");
    DronePower.name = "spawn_Drone";
    DronePower.actor_asset_id = "Drone";
    DronePower.click_action = new PowerActionWithID(action_spawn_jet);
	
    GodPower F55Power = AssetManager.powers.clone("spawn_F55", "_spawnActor");
    F55Power.name = "spawn_F55";
    F55Power.actor_asset_id = "F55";
    F55Power.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower RailgunPower = AssetManager.powers.clone("spawn_Railgun", "_spawnActor");
    RailgunPower.name = "spawn_Railgun";
    RailgunPower.actor_asset_id = "Railgun";
    RailgunPower.click_action = new PowerActionWithID(action_spawn_jet);
	
    GodPower MissileSystemPower = AssetManager.powers.clone("spawn_MissileSystem", "_spawnActor");
    MissileSystemPower.name = "spawn_MissileSystem";
    MissileSystemPower.actor_asset_id = "MissileSystem";
    MissileSystemPower.click_action = new PowerActionWithID(action_spawn_jet);
	
	
    GodPower P9000Power = AssetManager.powers.clone("spawn_P9000", "_spawnActor");
    P9000Power.name = "spawn_P9000";
    P9000Power.actor_asset_id = "P9000";
    P9000Power.click_action = new PowerActionWithID(action_spawn_jet);

    GodPower TerranPower = AssetManager.powers.clone("spawn_Terran", "_spawnActor");
    TerranPower.name = "spawn_Terran";
    TerranPower.actor_asset_id = "Terran";
    TerranPower.click_action = new PowerActionWithID(action_spawn_jet);
	
    DropAsset Droppy = new DropAsset();
    Droppy.id = "spawnnuke";
    Droppy.path_texture = "drops/drop_czarbomba";
    Droppy.random_frame = true;
    Droppy.default_scale = 0.2f;
    Droppy.fallingHeight = (Vector3) new Vector2(60f, 70f);
    Droppy.action_landed = new DropsAction(action_MOABClick);
    AssetManager.drops.add(Droppy);

    DropAsset CobaltDrop = new DropAsset();
    CobaltDrop.id = "cobalts";
    CobaltDrop.path_texture = "drops/drop_czarbomba";
    CobaltDrop.random_frame = false;
    CobaltDrop.default_scale = 0.2f;
    CobaltDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    CobaltDrop.action_landed = new DropsAction(action_CobaltClick);
    AssetManager.drops.add(CobaltDrop);

    DropAsset UltronDrop = new DropAsset();
    UltronDrop.id = "ultrons";
    UltronDrop.path_texture = "drops/drop_czarbomba";
    UltronDrop.random_frame = false;
    UltronDrop.default_scale = 0.2f;
    UltronDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    UltronDrop.action_landed = new DropsAction(action_UltronClick);
    AssetManager.drops.add(UltronDrop);

    DropAsset XeniumDrop = new DropAsset();
    XeniumDrop.id = "xeniums";
    XeniumDrop.path_texture = "drops/drop_czarbomba";
    XeniumDrop.random_frame = false;
    XeniumDrop.default_scale = 0.2f;
    XeniumDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    XeniumDrop.action_landed = new DropsAction(action_XeniumClick);
    AssetManager.drops.add(XeniumDrop);

    DropAsset MiniDrop = new DropAsset();
    MiniDrop.id = "minis";
    MiniDrop.path_texture = "drops/drop_czarbomba";
    MiniDrop.random_frame = false;
    MiniDrop.default_scale = 0.2f;
    MiniDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    MiniDrop.action_landed = new DropsAction(action_MiniClick);
    AssetManager.drops.add(MiniDrop);

    DropAsset ProtonDrop = new DropAsset();
    ProtonDrop.id = "protons";
    ProtonDrop.path_texture = "drops/drop_czarbomba";
    ProtonDrop.random_frame = false;
    ProtonDrop.default_scale = 0.2f;
    ProtonDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    ProtonDrop.action_landed = new DropsAction(action_ProtonClick);
    AssetManager.drops.add(ProtonDrop);

    DropAsset JupiterDrop = new DropAsset();
    JupiterDrop.id = "jupiters";
    JupiterDrop.path_texture = "drops/drop_czarbomba";
    JupiterDrop.random_frame = false;
    JupiterDrop.default_scale = 0.2f;
    JupiterDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    JupiterDrop.action_landed = new DropsAction(action_JupiterClick);
    AssetManager.drops.add(JupiterDrop);

    DropAsset EraserDrop = new DropAsset();
    EraserDrop.id = "eraser";
    EraserDrop.path_texture = "drops/drop_antimatter";
    EraserDrop.random_frame = false;
    EraserDrop.default_scale = 0.2f;
    EraserDrop.fallingHeight = (Vector3)new Vector2(60f, 70f);
    EraserDrop.action_landed = new DropsAction(action_EraserClick);
    AssetManager.drops.add(EraserDrop);

    DropAsset ZeusRageDrop = new DropAsset();
    ZeusRageDrop.id = "zeusrage";
    ZeusRageDrop.path_texture = "drops/drop_czarbomba";
    ZeusRageDrop.random_frame = false;
    ZeusRageDrop.default_scale = 0.2f;
    ZeusRageDrop.fallingHeight = (Vector3)new Vector2(60f, 70f);
    ZeusRageDrop.action_landed = new DropsAction(action_ZeusRageClick);
    AssetManager.drops.add(ZeusRageDrop);

	  DropAsset EXDrop = new DropAsset();
    EXDrop.id = "experimental";
    EXDrop.path_texture = "drops/drop_czarbomba";
    EXDrop.random_frame = false;
    EXDrop.default_scale = 0.2f;
    EXDrop.fallingHeight = (Vector3)new Vector2(60f, 70f);
    EXDrop.action_landed = new DropsAction(action_EXClick);
    AssetManager.drops.add(EXDrop);

    DropAsset NSADrop = new DropAsset();
    NSADrop.id = "notsoatomic";
    NSADrop.path_texture = "drops/drop_czarbomba";
    NSADrop.random_frame = false;
    NSADrop.default_scale = 0.2f;
    NSADrop.fallingHeight = (Vector3)new Vector2(60f, 70f);
    NSADrop.action_landed = new DropsAction(action_NSAClick);
    AssetManager.drops.add(NSADrop);

    DropAsset ClusterStrikeDrop = new DropAsset();
    ClusterStrikeDrop.id = "clusterstrike";
    ClusterStrikeDrop.path_texture = "drops/drop_czarbomba";
    ClusterStrikeDrop.random_frame = false;
    ClusterStrikeDrop.default_scale = 0.2f;
    ClusterStrikeDrop.fallingHeight = (Vector3)new Vector2(60f, 70f);
    ClusterStrikeDrop.action_landed = new DropsAction(action_ClusterStrikeClick);
    AssetManager.drops.add(ClusterStrikeDrop);
	
    AtomicGrenadeDrop = new DropAsset();
    AtomicGrenadeDrop.id = "atomicgrenade";
    AtomicGrenadeDrop.path_texture = "drops/drop_czarbomba";
    AtomicGrenadeDrop.random_frame = false;
    AtomicGrenadeDrop.default_scale = 0.2f;
    AtomicGrenadeDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    AtomicGrenadeDrop.action_landed = new DropsAction(action_AtomicGClick);
    AssetManager.drops.add(AtomicGrenadeDrop);
	
    AtomicGrenadePower = new GodPower();
    AtomicGrenadePower.id = "AtomicGrenadebuttonLOSER";
    AtomicGrenadePower.name = "AtomicGrenadebuttonLOSER";
    AtomicGrenadePower.holdAction = true;
    AtomicGrenadePower.fallingChance = 0.01f;
    AtomicGrenadePower.showToolSizes = true;
    AtomicGrenadePower.unselectWhenWindow = false;
    AtomicGrenadePower.ignore_cursor_icon = true;
    AtomicGrenadePower.dropID = "atomicgrenade";
    AtomicGrenadePower.click_power_action = new PowerAction(Stuff_Drop);
    AtomicGrenadePower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(AtomicGrenadePower);

    DropAsset FuryOfTuxiaFuncDrop = new DropAsset();
    FuryOfTuxiaFuncDrop.id = "fury";
    FuryOfTuxiaFuncDrop.path_texture = "drops/drop_czarbomba";
    FuryOfTuxiaFuncDrop.random_frame = false;
    FuryOfTuxiaFuncDrop.default_scale = 0.2f;
    FuryOfTuxiaFuncDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    FuryOfTuxiaFuncDrop.action_landed = new DropsAction(action_FuryClick);
    AssetManager.drops.add(FuryOfTuxiaFuncDrop);

    DropAsset SpreaderFuncDrop = new DropAsset();
    SpreaderFuncDrop.id = "spreader";
    SpreaderFuncDrop.path_texture = "drops/drop_czarbomba";
    SpreaderFuncDrop.random_frame = false;
    SpreaderFuncDrop.default_scale = 0.2f;
    SpreaderFuncDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    SpreaderFuncDrop.action_landed = new DropsAction(action_SpreaderClick);
    AssetManager.drops.add(SpreaderFuncDrop);
	
    GodPower FuryOfTuxiaFuncPower = new GodPower();
    FuryOfTuxiaFuncPower.id = "FuryOfTuxiaButtonLOSER";
    FuryOfTuxiaFuncPower.name = "FuryOfTuxiaButtonLOSER";
    FuryOfTuxiaFuncPower.holdAction = true;
    FuryOfTuxiaFuncPower.fallingChance = 0.01f;
    FuryOfTuxiaFuncPower.showToolSizes = true;
    FuryOfTuxiaFuncPower.unselectWhenWindow = false;
    FuryOfTuxiaFuncPower.ignore_cursor_icon = true;
    FuryOfTuxiaFuncPower.dropID = "fury";
    FuryOfTuxiaFuncPower.click_power_action = new PowerAction(Stuff_Drop);
    FuryOfTuxiaFuncPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(FuryOfTuxiaFuncPower);
   
    GodPower SpreaderFuncPower = new GodPower();
    SpreaderFuncPower.id = "SpreaderButtonLOSER";
    SpreaderFuncPower.name = "SpreaderButtonLOSER";
    SpreaderFuncPower.holdAction = true;
    SpreaderFuncPower.fallingChance = 0.01f;
    SpreaderFuncPower.showToolSizes = true;
    SpreaderFuncPower.unselectWhenWindow = false;
    SpreaderFuncPower.ignore_cursor_icon = true;
    SpreaderFuncPower.dropID = "spreader";
    SpreaderFuncPower.click_power_action = new PowerAction(Stuff_Drop);
    SpreaderFuncPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(SpreaderFuncPower);
	
    DropAsset ClusterNukeFuncDrop = new DropAsset();
    ClusterNukeFuncDrop.id = "cluster";
    ClusterNukeFuncDrop.path_texture = "drops/drop_czarbomba";
    ClusterNukeFuncDrop.random_frame = false;
    ClusterNukeFuncDrop.default_scale = 0.2f;
    ClusterNukeFuncDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    ClusterNukeFuncDrop.action_landed = new DropsAction(action_ClusterClick);
    AssetManager.drops.add(ClusterNukeFuncDrop);
   
    GodPower ClusterNukeFuncPower = new GodPower();
    ClusterNukeFuncPower.id = "ClusterNukeButtonLOSER";
    ClusterNukeFuncPower.name = "ClusterNukeButtonLOSER";
    ClusterNukeFuncPower.holdAction = true;
    ClusterNukeFuncPower.fallingChance = 0.01f;
    ClusterNukeFuncPower.showToolSizes = true;
    ClusterNukeFuncPower.unselectWhenWindow = false;
    ClusterNukeFuncPower.ignore_cursor_icon = true;
    ClusterNukeFuncPower.dropID = "cluster";
    ClusterNukeFuncPower.click_power_action = new PowerAction(Stuff_Drop);
    ClusterNukeFuncPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(ClusterNukeFuncPower);		
	
    GodPower DeleterFuncPower = new GodPower();
    DeleterFuncPower.id = "DeleterButtonLOSER";
    DeleterFuncPower.name = "DeleterButtonLOSER";
    DeleterFuncPower.holdAction = true;
    DeleterFuncPower.fallingChance = 0.01f;
    DeleterFuncPower.showToolSizes = true;
    DeleterFuncPower.unselectWhenWindow = false;
    DeleterFuncPower.ignore_cursor_icon = true;
    DeleterFuncPower.dropID = "deleter";
    DeleterFuncPower.click_power_action = new PowerAction(Stuff_Drop);
    DeleterFuncPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(DeleterFuncPower);	
	
    DropAsset DeathDrop = new DropAsset();
    DeathDrop.id = "deaths";
    DeathDrop.path_texture = "drops/drop_czarbomba";
    DeathDrop.random_frame = false;
    DeathDrop.default_scale = 0.2f;
    DeathDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    DeathDrop.action_landed = new DropsAction(action_DeathClick);
    AssetManager.drops.add(DeathDrop);

    DropAsset DeleterDrop = new DropAsset();
    DeleterDrop.id = "deleter";
    DeleterDrop.path_texture = "drops/drop_czarbomba";
    DeleterDrop.random_frame = false;
    DeleterDrop.default_scale = 0.2f;
    DeleterDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    DeleterDrop.action_landed = new DropsAction(action_DeleterClick);
    AssetManager.drops.add(DeleterDrop);
	
    DropAsset RandomDrop = new DropAsset();
    RandomDrop.id = "randomdrop";
    RandomDrop.path_texture = "drops/drop_czarbomba";
    RandomDrop.random_frame = false;
    RandomDrop.default_scale = 0.2f;
    RandomDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    RandomDrop.action_landed = new DropsAction(action_RandomClick);
    AssetManager.drops.add(RandomDrop);
	 
    DropAsset DankiMatterDrop = new DropAsset();
    DankiMatterDrop.id = "Danky";
    DankiMatterDrop.path_texture = "drops/drop_czarbomba";
    DankiMatterDrop.random_frame = false;
    DankiMatterDrop.default_scale = 0.2f;
    DankiMatterDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    DankiMatterDrop.action_landed = new DropsAction(action_DankiClick);
    AssetManager.drops.add(DankiMatterDrop);

    DropAsset ColorGrenadeDrop = new DropAsset();
    ColorGrenadeDrop.id = "colors";
    ColorGrenadeDrop.path_texture = "drops/drop_czarbomba";
    ColorGrenadeDrop.random_frame = false;
    ColorGrenadeDrop.default_scale = 0.2f;
    ColorGrenadeDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    ColorGrenadeDrop.action_landed = new DropsAction(action_ColorClick);
    AssetManager.drops.add(ColorGrenadeDrop);
    
    DropAsset BloodLightningDrop = new DropAsset();
    BloodLightningDrop.id = "blood";
    BloodLightningDrop.path_texture = "drops/drop_czarbomba";
    BloodLightningDrop.random_frame = false;
    BloodLightningDrop.default_scale = 0.2f;
    BloodLightningDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    BloodLightningDrop.action_landed = new DropsAction(action_BloodLightningClick);
    AssetManager.drops.add(BloodLightningDrop);

    DropAsset NoDmgDrop = new DropAsset();
    NoDmgDrop.id = "nodmg";
    NoDmgDrop.path_texture = "drops/drop_czarbomba";
    NoDmgDrop.random_frame = false;
    NoDmgDrop.default_scale = 0.2f;
    NoDmgDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
    NoDmgDrop.action_landed = new DropsAction(action_NoDmgClick);
    AssetManager.drops.add(NoDmgDrop);

    // GodPower WorkerPower = new GodPower();
    // WorkerPower.id = "WorkerPowerbutton";
    // WorkerPower.name = "WorkerPowerbutton";
    // WorkerPower.showToolSizes = true;
    // WorkerPower.holdAction = true;
    // WorkerPower.unselectWhenWindow = true;
    // WorkerPower.fallingChance = 0.3f;
    // WorkerPower.actor_asset_id = "boat_trading";
    // WorkerPower.dropID = "spawnJob";
    // WorkerPower.click_power_action = new PowerAction(Stuff_Drop);
    // WorkerPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    // AssetManager.powers.add(WorkerPower);

    // GodPower AirplanePower = new GodPower();
    // AirplanePower.id = "AirplanePowerbutton";
    // AirplanePower.name = "AirplanePowerbutton";
    // AirplanePower.showToolSizes = true;
    // AirplanePower.holdAction = true;
    // AirplanePower.unselectWhenWindow = true;
    // AirplanePower.fallingChance = 0.3f;
    // AirplanePower.actor_asset_id = "boat_trading";
    // AirplanePower.dropID = "spawnJob";
    // AirplanePower.click_power_action = new PowerAction(Stuff_Drop);
    // AirplanePower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    // AssetManager.powers.add(AirplanePower);

    GameObject largeImageObject = new GameObject("LargeImage");
    largeImageObject.transform.SetParent(tab.transform);
    largeImageObject.transform.localPosition = new Vector3(396, 18, 0);
    largeImageObject.transform.localScale = new Vector3(1, 1, 1);

    Image largeImage = largeImageObject.AddComponent<Image>();
    largeImage.sprite = Resources.Load<Sprite>("ui/Icons/TabText");

    RectTransform largeImageRectTransform = largeImageObject.GetComponent<RectTransform>();
    largeImageRectTransform.sizeDelta = new Vector2(200, 100);
    largeImageRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
    largeImageRectTransform.anchorMax = new Vector2(0.5f, 0.5f);



    PowerButtons.CreateButton("STRONGMIRV_toggle", Resources.Load<Sprite>("ui/Icons/MIRV_nuke"), "Nuclear MIRVs", "(GREEN MEANS ON, GREY IS OFF) Toggle Nuclear MIRVs from being developed (this won't remove existing Nuclear MIRVS)", new Vector2(288, -18), ButtonType.Toggle, tab.transform, MIRV.toggleMIRVSSTRONG

    );
    if (Main.savedSettings.boolOptions["STRONGMIRVOption"]) {
      PowerButtons.ToggleButton("STRONGMIRV_toggle");
      MIRV.toggleMIRVSSTRONG();
    }

    PowerButtons.CreateButton("MIRV_toggle", Resources.Load<Sprite>("ui/Icons/MIRV"), "MIRVs", "(GREEN MEANS ON, GREY IS OFF) Toggle MIRVs from being developed (this won't remove existing MIRVS)", new Vector2(288, 18), ButtonType.Toggle, tab.transform, MIRV.toggleMIRVS

    );
    if (Main.savedSettings.boolOptions["MIRVOption"]) {
      PowerButtons.ToggleButton("MIRV_toggle");
      MIRV.toggleMIRVS();
    }


        var Cyberkaboom = new GodPower();
            Cyberkaboom.id = "spawnCyberkaboom";
            Cyberkaboom.showSpawnEffect = true;
            Cyberkaboom.multiple_spawn_tip = true;
            Cyberkaboom.actorSpawnHeight = 10f;
            Cyberkaboom.name = "spawnCyberkaboom";
            Cyberkaboom.spawnSound = "spawnelf";
            Cyberkaboom.actor_asset_id = "Assimilatus";
            Cyberkaboom.click_action = new PowerActionWithID(callSpawnUnit);
            AssetManager.powers.add(Cyberkaboom);

            var buttonCyberkaboom = NCMS.Utils.PowerButtons.CreateButton(
            "spawnCyberkaboom",
            Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.units.AssimilatusIcon.png"),
            "Cyber Boss",
            "Do not spawn in a 69km radius from the closest city, DO NOT, THIS IS NOT REVERSE PSYCHOLOGY, I SWEAR, DO NOT :3",
            new Vector2(1260+36, 18),
            ButtonType.GodPower,
            tab.transform,
            null
            );

               var IceTitan = new GodPower();
            IceTitan.id = "spawnCocytuswalker";
            IceTitan.showSpawnEffect = true;
            IceTitan.multiple_spawn_tip = true;
            IceTitan.actorSpawnHeight = 10f;
            IceTitan.name = "spawnCocytuswalker";
            IceTitan.spawnSound = "spawnelf";
            IceTitan.actor_asset_id = "Cocytuswalker";
            IceTitan.click_action = new PowerActionWithID(callSpawnUnit);
            AssetManager.powers.add(IceTitan);

            var buttonIceTitan = NCMS.Utils.PowerButtons.CreateButton(
            "spawnCocytuswalker",
            Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.units.Walker_TitanIcon.png"),
            "Ice Walker Boss",
            "He came to worldbox to get away from Shinji, he do not trust what Shinji would do to him if he falls into a coma",
            new Vector2(1260+36, -18),
            ButtonType.GodPower,
            tab.transform,
            null
            );





    GodPower MOABPower = new GodPower();
    MOABPower.id = "MOABbutton";
    MOABPower.name = "MOABbutton";
    MOABPower.holdAction = true;
    MOABPower.fallingChance = 0.01f;
    MOABPower.showToolSizes = true;
    MOABPower.unselectWhenWindow = false;
    MOABPower.ignore_cursor_icon = true;
    MOABPower.dropID = "spawnnuke";
    MOABPower.click_power_action = new PowerAction(Stuff_Drop);
    MOABPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(MOABPower);

    GodPower CobaltPower = new GodPower();
    CobaltPower.id = "Cobaltbutton";
    CobaltPower.name = "Cobaltbutton";
    CobaltPower.holdAction = true;
    CobaltPower.showToolSizes = true;
    CobaltPower.fallingChance = 0.01f;
    CobaltPower.unselectWhenWindow = false;
    CobaltPower.ignore_cursor_icon = true;
    CobaltPower.dropID = "cobalts";
    CobaltPower.click_power_action = new PowerAction(Stuff_Drop);
    CobaltPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(CobaltPower);

    GodPower UltronPower = new GodPower();
    UltronPower.id = "Ultronbutton";
    UltronPower.name = "Ultronbutton";
    UltronPower.holdAction = true;
    UltronPower.showToolSizes = true;
    UltronPower.unselectWhenWindow = false;
    UltronPower.fallingChance = 0.01f;
    UltronPower.ignore_cursor_icon = true;
    UltronPower.dropID = "ultrons";
    UltronPower.click_power_action = new PowerAction(Stuff_Drop);
    UltronPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(UltronPower);

    GodPower XeniumPower = new GodPower();
    XeniumPower.id = "Xeniumbutton";
    XeniumPower.name = "Xeniumbutton";
    XeniumPower.holdAction = true;
    XeniumPower.fallingChance = 0.01f;
    XeniumPower.showToolSizes = true;
    XeniumPower.unselectWhenWindow = false;
    XeniumPower.ignore_cursor_icon = true;
    XeniumPower.dropID = "xeniums";
    XeniumPower.click_power_action = new PowerAction(Stuff_Drop);
    XeniumPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(XeniumPower);

    GodPower MiniPower = new GodPower();
    MiniPower.id = "Minibutton";
    MiniPower.name = "Minibutton";
    MiniPower.holdAction = true;
    MiniPower.fallingChance = 0.01f;
    MiniPower.showToolSizes = true;
    MiniPower.unselectWhenWindow = false;
    MiniPower.ignore_cursor_icon = true;
    MiniPower.dropID = "minis";
    MiniPower.click_power_action = new PowerAction(Stuff_Drop);
    MiniPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(MiniPower);

    GodPower JupiterPower = new GodPower();
    JupiterPower.id = "Jupiterbutton";
    JupiterPower.name = "Jupiterbutton";
    JupiterPower.fallingChance = 0.01f;
    JupiterPower.holdAction = true;
    JupiterPower.showToolSizes = true;
    JupiterPower.unselectWhenWindow = false;
    JupiterPower.ignore_cursor_icon = true;
    JupiterPower.dropID = "jupiters";
    JupiterPower.click_power_action = new PowerAction(Stuff_Drop);
    JupiterPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(JupiterPower);

    GodPower EraserPower = new GodPower();
    EraserPower.id = "Eraserbutton";
    EraserPower.name = "Eraserbutton";
    EraserPower.fallingChance = 0.01f;
    EraserPower.holdAction = true;
    EraserPower.showToolSizes = true;
    EraserPower.ignore_cursor_icon = true;
    EraserPower.dropID = "eraser";
    EraserPower.click_power_action = new PowerAction(Stuff_Drop);
    EraserPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool)AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(EraserPower);
	
    GodPower DeathPower = new GodPower();
    DeathPower.id = "Deathbutton";
    DeathPower.name = "Deathbutton";
    DeathPower.holdAction = true;
    DeathPower.fallingChance = 0.01f;
    DeathPower.showToolSizes = true;
    DeathPower.unselectWhenWindow = false;
    DeathPower.ignore_cursor_icon = true;
    DeathPower.dropID = "deaths";
    DeathPower.click_power_action = new PowerAction(Stuff_Drop);
    DeathPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(DeathPower);


    GodPower ZeusRagePower = new GodPower();
    ZeusRagePower.id = "ZeusRagebuttonLOSER";
    ZeusRagePower.name = "ZeusRagebuttonLOSER";
    ZeusRagePower.holdAction = true;
    ZeusRagePower.fallingChance = 0.01f;
    ZeusRagePower.showToolSizes = true;
    ZeusRagePower.unselectWhenWindow = false;
    ZeusRagePower.ignore_cursor_icon = true;
    ZeusRagePower.dropID = "zeusrage";
    ZeusRagePower.click_power_action = new PowerAction(Stuff_Drop);
    ZeusRagePower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(ZeusRagePower);

    GodPower EXPower = new GodPower();
    EXPower.id = "EXbuttonLOSER";
    EXPower.name = "EXbuttonLOSER";
    EXPower.holdAction = true;
    EXPower.fallingChance = 0.01f;
    EXPower.showToolSizes = true;
    EXPower.unselectWhenWindow = false;
    EXPower.ignore_cursor_icon = true;
    EXPower.dropID = "experimental";
    EXPower.click_power_action = new PowerAction(Stuff_Drop);
    EXPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(EXPower);

    GodPower NSAPower = new GodPower();
    NSAPower.id = "NSAbuttonLOSER";
    NSAPower.name = "NSAbuttonLOSER";
    NSAPower.holdAction = true;
    NSAPower.fallingChance = 0.01f;
    NSAPower.showToolSizes = true;
    NSAPower.unselectWhenWindow = false;
    NSAPower.ignore_cursor_icon = true;
    NSAPower.dropID = "notsoatomic";
    NSAPower.click_power_action = new PowerAction(Stuff_Drop);
    NSAPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(NSAPower);

    GodPower ClusterStrikePower = new GodPower();
    ClusterStrikePower.id = "ClusterStrikebuttonLOSER";
    ClusterStrikePower.name = "ClusterStrikebuttonLOSER";
    ClusterStrikePower.holdAction = true;
    ClusterStrikePower.fallingChance = 0.01f;
    ClusterStrikePower.showToolSizes = true;
    ClusterStrikePower.unselectWhenWindow = false;
    ClusterStrikePower.ignore_cursor_icon = true;
    ClusterStrikePower.dropID = "clusterstrike";
    ClusterStrikePower.click_power_action = new PowerAction(Stuff_Drop);
    ClusterStrikePower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(ClusterStrikePower);

    GodPower ProtonPower = new GodPower();
    ProtonPower.id = "ProtonbuttonLOSER";
    ProtonPower.name = "ProtonbuttonLOSER";
    ProtonPower.fallingChance = 0.01f;
    ProtonPower.holdAction = true;
    ProtonPower.showToolSizes = true;
    ProtonPower.unselectWhenWindow = false;
    ProtonPower.ignore_cursor_icon = true;
    ProtonPower.dropID = "protons";
    ProtonPower.click_power_action = new PowerAction(Stuff_Drop);
    ProtonPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(ProtonPower);

    GodPower RandomPower = new GodPower();
    RandomPower.id = "Randombutton";
    RandomPower.name = "Randombutton";
    RandomPower.holdAction = true;
    RandomPower.fallingChance = 0.001f;
    RandomPower.showToolSizes = true;
    RandomPower.unselectWhenWindow = false;
    RandomPower.ignore_cursor_icon = true;
    RandomPower.dropID = "randomdrop";
    RandomPower.click_power_action = new PowerAction(Stuff_Drop);
    RandomPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(RandomPower);

    GodPower ColorGrenadePower = new GodPower();
    ColorGrenadePower.id = "ColorGrenadebuttonLOSER";
    ColorGrenadePower.name = "ColorGrenadebuttonLOSER";
    ColorGrenadePower.fallingChance = 0.01f;
    ColorGrenadePower.holdAction = true;
    ColorGrenadePower.showToolSizes = true;
    ColorGrenadePower.unselectWhenWindow = false;
    ColorGrenadePower.ignore_cursor_icon = true;
    ColorGrenadePower.dropID = "colors";
    ColorGrenadePower.click_power_action = new PowerAction(Stuff_Drop);
    ColorGrenadePower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(ColorGrenadePower);

    GodPower DankiMatterPower = new GodPower();
    DankiMatterPower.id = "DankiMatterbuttonLOSER";
    DankiMatterPower.name = "DankiMatterbuttonLOSER";
    DankiMatterPower.fallingChance = 0.01f;
    DankiMatterPower.holdAction = true;
    DankiMatterPower.showToolSizes = true;
    DankiMatterPower.unselectWhenWindow = false;
    DankiMatterPower.ignore_cursor_icon = true;
    DankiMatterPower.dropID = "Danky";
    DankiMatterPower.click_power_action = new PowerAction(Stuff_Drop);
    DankiMatterPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(DankiMatterPower);
    
    GodPower BloodLightningPower = new GodPower();
    BloodLightningPower.id = "BloodLightningbuttonLOSER";
    BloodLightningPower.name = "BloodLightningbuttonLOSER";
    BloodLightningPower.fallingChance = 0.01f;
    BloodLightningPower.holdAction = true;
    BloodLightningPower.showToolSizes = true;
    BloodLightningPower.unselectWhenWindow = false;
    BloodLightningPower.ignore_cursor_icon = true;
    BloodLightningPower.dropID = "blood";
    BloodLightningPower.click_power_action = new PowerAction(Stuff_Drop);
    BloodLightningPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(BloodLightningPower);

    GodPower NoDmgPower = new GodPower();
    NoDmgPower.id = "NoDmgbuttonLOSER";
    NoDmgPower.name = "NoDmgbuttonLOSER";
    NoDmgPower.fallingChance = 0.01f;
    NoDmgPower.holdAction = true;
    NoDmgPower.showToolSizes = true;
    NoDmgPower.unselectWhenWindow = false;
    NoDmgPower.ignore_cursor_icon = true;
    NoDmgPower.dropID = "nodmg";
    NoDmgPower.click_power_action = new PowerAction(Stuff_Drop);
    NoDmgPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(NoDmgPower);

    PowerButtons.CreateButton("MOABbutton", Resources.Load<Sprite>("ui/Icons/MOAB"), "Super-Nuke", "Also known as the 'Lag Bomb'.", new Vector2(576, 18),
                              // new Vector2(72, 18),
                              NCMS.Utils.ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("Xeniumbutton", Resources.Load<Sprite>("ui/Icons/Xeno"), "Xenium Bomb", "You thought the ultron bomb was big? This thing is HUGE.", new Vector2(576, -18), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
    PowerButtons.CreateButton("Cobaltbutton", Resources.Load<Sprite>("ui/Icons/Cobalt"), "Cobalt Bomb", "Small Mushroom but huge radius, watch out with this one.", new Vector2(540, -18), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
    PowerButtons.CreateButton("Ultronbutton", Resources.Load<Sprite>("ui/Icons/Ultron"), "Ultron Bomb", "WOOOAH", new Vector2(504, 18), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
    PowerButtons.CreateButton("Deathbutton", Resources.Load<Sprite>("ui/Icons/Death"), "Death Bomb", "Such an original name.", new Vector2(612, 18), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
    PowerButtons.CreateButton("Randombutton", Resources.Load<Sprite>("ui/Icons/wat"), "Random Bomb", "You could be dropping a proton bomb, or a mini nuke, it's random!", new Vector2(648, 18), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
    PowerButtons.CreateButton("BombMenu", Resources.Load<Sprite>("ui/Icons/Bomber"), "Bomb Menu", "Tux and Dank got bored and added a lot of extra bombs....", new Vector2(684, -18), NCMS.Utils.ButtonType.Click, tab.transform, BombsMenu);
    PowerButtons.CreateButton("Minibutton", Resources.Load<Sprite>("ui/Icons/Mini"), "Mini Nuke", "Small nukes, great for minor scuffles.", new Vector2(540, 18), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
    PowerButtons.CreateButton("Protonbutton", Resources.Load<Sprite>("ui/Icons/Proton"), "Proton Bomb", "wtf is this?", new Vector2(504, -18), NCMS.Utils.ButtonType.GodPower, tab2.transform, null);
    PowerButtons.CreateButton("Jupiterbutton", Resources.Load<Sprite>("ui/Icons/Jupiter"), "Jupiter Bomb", "The new monster.", new Vector2(612, -18), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
    PowerButtons.CreateButton("Eraserbutton",Resources.Load<Sprite>("ui/Icons/Eraser"),"Eraser Bomb","also known as the overcompensating bomb.",new Vector2(648, -18),NCMS.Utils.ButtonType.GodPower,tab.transform,null);
	
					// LOSER BUTTONS 

          BOMB1 = PowerButtons.CreateButton("ZeusRagebuttonLOSER", Resources.Load<Sprite>("ui/Icons/ZeusRage"), "Zeus's Rage", "Tremble in fear Kratos.", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
	
	  BOMB2 = PowerButtons.CreateButton("AtomicGrenadebuttonLOSER", Resources.Load<Sprite>("ui/Icons/AtomicGrenade"), "Atomic Grenade", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
					
	  BOMB3 = PowerButtons.CreateButton("FuryOfTuxiaButtonLOSER", Resources.Load<Sprite>("ui/Icons/FuryOfTuxia"), "Fury Of Tuxia", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
					
	  BOMB4 = PowerButtons.CreateButton("ClusterNukeButtonLOSER", Resources.Load<Sprite>("ui/Icons/MOAB"), "Cluster Nuke", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
	  
	  BOMB5 = PowerButtons.CreateButton("EXbuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "Experimental Bomb", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);

          BOMB6 = PowerButtons.CreateButton("NSAbuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "Not So Atomic Bomb", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
          
          BOMB7 = PowerButtons.CreateButton("ClusterStrikebuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "Cluster Strike", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);

          BOMB8 = PowerButtons.CreateButton("ProtonbuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "Proton Bomb", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
		  
          BOMB9 = PowerButtons.CreateButton("DeleterButtonLOSER", Resources.Load<Sprite>("ui/Icons/UniversalDestroyer"), "TUDDS", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);
		  
          BOMB10 = PowerButtons.CreateButton("SpreaderButtonLOSER", Resources.Load<Sprite>("ui/Icons/MOAB"), "Spreader Bomb", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);

	  BOMB11 = PowerButtons.CreateButton("ColorGrenadebuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "Color grenade", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);

          BOMB12 = PowerButtons.CreateButton("DankiMatterbuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "DankiMatter", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);

          BOMB13 = PowerButtons.CreateButton("BloodLightningbuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "BloodLightning", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);

          BOMB14 = PowerButtons.CreateButton("NoDmgbuttonLOSER", Resources.Load<Sprite>("ui/Icons/wat"), "NoDmg", "THIS IS A LOSER BUTTON NO DESCRIPTION IS NEEDED!!!", new Vector2(-1000, 0), NCMS.Utils.ButtonType.GodPower, tab.transform, null);

EffectAsset ColorNade = new EffectAsset();
ColorNade.id = "fx_color_grenade";
ColorNade.use_basic_prefab = true;
ColorNade.sorting_layer_id = "EffectsTop";
ColorNade.sprite_path = "Effects/Colornade";
ColorNade.show_on_mini_map = true;
ColorNade.draw_light_area = true;
ColorNade.draw_light_size = 2f;
ColorNade.draw_light_area_offset_y = 5f;
ColorNade.limit = 100;
ColorNade.sound_launch = "event:/SFX/EXPLOSIONS/ExplosionLightningStrike";
AssetManager.effects_library.add(ColorNade);

EffectAsset BloodLightning = new EffectAsset();
BloodLightning.id = "fx_blood_lightning";
BloodLightning.use_basic_prefab = true;
BloodLightning.sorting_layer_id = "EffectsTop";
BloodLightning.sprite_path = "Effects/BloodLightning";
BloodLightning.show_on_mini_map = true;
BloodLightning.draw_light_area = true;
BloodLightning.draw_light_size = 2f;
BloodLightning.draw_light_area_offset_y = 5f;
BloodLightning.limit = 100;
BloodLightning.sound_launch = "event:/SFX/EXPLOSIONS/ExplosionLightningStrike";
AssetManager.effects_library.add(BloodLightning);

EffectAsset NoNuke = new EffectAsset();
NoNuke.id = "fx_explosion_blue";
NoNuke.use_basic_prefab = true;
NoNuke.sorting_layer_id = "EffectsTop";
NoNuke.sprite_path = "Effects/NoNuke";
NoNuke.show_on_mini_map = true;
NoNuke.draw_light_area = true;
NoNuke.draw_light_size = 2f;
NoNuke.draw_light_area_offset_y = 5f;
NoNuke.limit = 100;
NoNuke.sound_launch = "event:/SFX/EXPLOSIONS/ExplosionLightningStrike";
AssetManager.effects_library.add(NoNuke);

EffectAsset DankEffect = new EffectAsset();
DankEffect.id = "fx_explosion_dank";
DankEffect.use_basic_prefab = true;
DankEffect.sorting_layer_id = "EffectsTop";
DankEffect.sprite_path = "Effects/DankEffect";
DankEffect.show_on_mini_map = true;
DankEffect.draw_light_area = true;
DankEffect.draw_light_size = 2f;
DankEffect.draw_light_area_offset_y = 5f;
DankEffect.limit = 100;
DankEffect.sound_launch = "event:/SFX/EXPLOSIONS/ExplosionLightningStrike";
AssetManager.effects_library.add(DankEffect);

	  
    PowerButtons.CreateButton("Cyberware_toggle", Resources.Load<Sprite>("ui/Icons/Cyberware"), "Cyberware", "(GREEN MEANS ON, GREY IS OFF) Toggle Cyberware from being developed (this won't remove existing Cyberware)", new Vector2(1224, 18), ButtonType.Toggle, tab.transform, cyberware.toggleCyberware);
    if (Main.savedSettings.boolOptions["CyberwareOption"]) {
      PowerButtons.ToggleButton("Cyberware_toggle");
      cyberware.toggleCyberware();
    }

    PowerButtons.CreateButton("Drugs_toggle", Resources.Load<Sprite>("ui/Icons/Drugs"), "Drugs", "(GREEN MEANS ON, GREY IS OFF) Toggle Drugs from being developed (this won't remove existing Drugs already made)", new Vector2(1224, -18), ButtonType.Toggle, tab.transform, Drugs.toggleDrugs);
    if (Main.savedSettings.boolOptions["DrugsOption"]) {
      PowerButtons.ToggleButton("Drugs_toggle");
      Drugs.toggleDrugs();
    }

    PowerButtons.CreateButton("Drones_Toggle", Resources.Load<Sprite>("ui/Icons/Drone"), "Drones", "(GREEN MEANS ON, GREY IS OFF) Toggle if kingdoms can create Drones.", new Vector2(1152, -18), ButtonType.Toggle, tab.transform, Commerce.toggleDrones);
    if (Main.savedSettings.boolOptions["DronesOption"]) {
      PowerButtons.ToggleButton("Drones_Toggle");
      Commerce.toggleDrones();
    }
	
			    PowerButtons.CreateButton("spawn_P9000", Resources.Load<Sprite>("ui/icons/P9000"), "Spawn P9000", "The goat.", new Vector2(1044, 18), ButtonType.GodPower, tab.transform, null);
			    PowerButtons.CreateButton("spawn_Terran", Resources.Load<Sprite>("ui/icons/Terran"), "Spawn Terran Goliath", "Spawn a mech.", new Vector2(1080, 18), ButtonType.GodPower, tab.transform, null);
				    PowerButtons.CreateButton("P9000Factory_toggle", Resources.Load<Sprite>("ui/Icons/P9000"), "P9000 Factories", "DISABLED, COMING SOON!!!", new Vector2(1044, -18), ButtonType.Click, tab.transform, null);
				//	if (Main.savedSettings.boolOptions["P9000Option"]) {
				//	  PowerButtons.ToggleButton("P9000Factory_toggle");
				//	  Commerce.toggleP9000Factory();
				//	}					
				    PowerButtons.CreateButton("TerranFactory_toggle", Resources.Load<Sprite>("ui/Icons/Terran"), "Terran Goliath Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make the Terran Goliath.", new Vector2(1080, -18), ButtonType.Toggle, tab.transform, Commerce.toggleTerranFactory);
					if (Main.savedSettings.boolOptions["TerranOption"]) {
					  PowerButtons.ToggleButton("TerranFactory_toggle");
					  Commerce.toggleTerranFactory();
					}
	
    PowerButtons.CreateButton("heli_spawn", Resources.Load<Sprite>("ui/Icons/Heli"), "Helicopter Spawn", "Spawn a Helicopter", new Vector2(720, 18), ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("HelicopterFactory_toggle", Resources.Load<Sprite>("ui/Icons/Heli"), "Helicopter Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Helicopters", new Vector2(720, -18), ButtonType.Toggle, tab.transform, Commerce.toggleHelicopterFactory);

    if (Main.savedSettings.boolOptions["HeliOption"]) {
      PowerButtons.ToggleButton("HelicopterFactory_toggle");
      Commerce.toggleHelicopterFactory();
    }

    PowerButtons.CreateButton("spawn_airship", Resources.Load<Sprite>("ui/Icons/Airship"), "Spawn Zeppelin", "Spawn a Zeppelin.", new Vector2(756, 18), ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("AirshipFactory_toggle", Resources.Load<Sprite>("ui/Icons/Airship"), "Airship Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Airships", new Vector2(756, -18), ButtonType.Toggle, tab.transform, Commerce.toggleAirshipFactory);

    if (Main.savedSettings.boolOptions["AirshipOption"]) {
      PowerButtons.ToggleButton("AirshipFactory_toggle");
      Commerce.toggleAirshipFactory();
    }

    PowerButtons.CreateButton("spawn_tank", Resources.Load<Sprite>("ui/Icons/Tank"), "Spawn Tank", "Spawn a tank.", new Vector2(792, 18), ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("TankFactory_toggle", Resources.Load<Sprite>("ui/Icons/Tank"), "Tank Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Tanks", new Vector2(792, -18), ButtonType.Toggle, tab.transform, Commerce.toggleTankFactory);

    if (Main.savedSettings.boolOptions["TankOption"]) {
      PowerButtons.ToggleButton("TankFactory_toggle");
      Commerce.toggleTankFactory();
    }

    PowerButtons.CreateButton("spawn_mirv_bomber", Resources.Load<Sprite>("ui/Icons/MIRVBomber"), "Spawn MIRV Bomber", "Spawn a MIRV Bomber.", new Vector2(828, 18), ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("AirFactory_toggle", Resources.Load<Sprite>("ui/Icons/MIRVBomber"), "MIRV Bomber Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make MIRV Bombers", new Vector2(828, -18), ButtonType.Toggle, tab.transform, Commerce.toggleAirFactory);

    if (Main.savedSettings.boolOptions["MIRVBomberOption"]) {
      PowerButtons.ToggleButton("AirFactory_toggle");
      Commerce.toggleAirFactory();
    }

    PowerButtons.CreateButton("spawn_humvee", Resources.Load<Sprite>("ui/Icons/Humvee"), "Spawn Humvee", "Spawn a Humvee.", new Vector2(864, 18), ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("HumveeFactory_toggle", Resources.Load<Sprite>("ui/Icons/Humvee"), "Humvee Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Humvees", new Vector2(864, -18), ButtonType.Toggle, tab.transform, Commerce.toggleHumveeFactory);

    if (Main.savedSettings.boolOptions["HumveeOption"]) {
      PowerButtons.ToggleButton("HumveeFactory_toggle");
      Commerce.toggleHumveeFactory();
    }

    PowerButtons.CreateButton("spawn_FighterJet", Resources.Load<Sprite>("ui/Icons/FighterJet"), "Spawn FighterJet", "Spawn a FighterJet.", new Vector2(900, 18), ButtonType.GodPower, tab.transform, null);
PowerButtons.CreateButton("spawn_Drone", Resources.Load<Sprite>("ui/Icons/Drone"), "Spawn Drone", "Spawn a Drone.", new Vector2(1260+36+36, 18), ButtonType.GodPower, tab.transform, null);
PowerButtons.CreateButton("spawn_Troop", Resources.Load<Sprite>("ui/Icons/Soldier"), "Spawn Soldier", "Spawn a Soldier.", new Vector2(1260+36+36, -18), ButtonType.GodPower, tab.transform, null);

        System.Random random = new System.Random();
        
        if (random.NextDouble() <= 0.2)
        {
            PowerButtons.CreateButton("spawn_ALIEN", Resources.Load<Sprite>("ui/Icons/alien"), "ALIEN EMOJI", "OH NO YOU GOT AN EASTER EGG!", new Vector2(684, 18), ButtonType.GodPower, tab.transform, null);
        }
    PowerButtons.CreateButton("FighterJetFactory_toggle", Resources.Load<Sprite>("ui/Icons/FighterJet"), "FighterJet Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make FighterJets", new Vector2(900, -18), ButtonType.Toggle, tab.transform, Commerce.toggleFighterJetFactory);

    if (Main.savedSettings.boolOptions["FighterJetOption"]) {
      PowerButtons.ToggleButton("FighterJetFactory_toggle");
      Commerce.toggleFighterJetFactory();
    }

    PowerButtons.CreateButton("spawn_MissileSystem", Resources.Load<Sprite>("actors/MissileSystem/swim_1"), "Spawn Artillery", "Spawn a Missile System.", new Vector2(936, 18), ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("BoiFactory_toggle", Resources.Load<Sprite>("actors/MissileSystem/swim_1"), "Missile System Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Missile Systems", new Vector2(936, -18), ButtonType.Toggle, tab.transform, Commerce.toggleBoiFactory);

    if (Main.savedSettings.boolOptions["BoiOption"]) {
      PowerButtons.ToggleButton("BoiFactory_toggle");
      Commerce.toggleBoiFactory();
    }

    PowerButtons.CreateButton("gunship_spawn", Resources.Load<Sprite>("ui/Icons/Gunship"), "Gunship Spawn", "Spawn a Gunship", new Vector2(972, 18), ButtonType.GodPower, tab.transform, null);

    PowerButtons.CreateButton("GunshipFactory_toggle", Resources.Load<Sprite>("ui/Icons/Gunship"), "Gunship Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Gunships", new Vector2(972, -18), ButtonType.Toggle, tab.transform, Commerce.toggleGunshipFactory);

    if (Main.savedSettings.boolOptions["GunshipOption"]) {
      PowerButtons.ToggleButton("GunshipFactory_toggle");
      Commerce.toggleGunshipFactory();
    }

    PowerButtons.CreateButton("PipeGun_toggle", Resources.Load<Sprite>("ui/Icons/lowfirearm"), "Toggle Pipe Guns.", "(GREEN MEANS ON, GREY IS OFF) Toggle Pipe Guns from being developed (this won't remove existing Pipe Guns already made). You're welcome LonelyFear.", new Vector2(1188, 18), // ok
                              ButtonType.Toggle, tab.transform, guns.togglePipeGuns);
    if (Main.savedSettings.boolOptions["PipeGunOption"]) {
      PowerButtons.ToggleButton("PipeGun_toggle");
      guns.togglePipeGuns();
    }

    PowerButtons.CreateButton("Gun_toggle", Resources.Load<Sprite>("ui/Icons/firearm"), "Toggle Guns.", "(GREEN MEANS ON, GREY IS OFF) Toggle Guns from being developed (this won't remove existing Guns already made).", new Vector2(1188, -18), ButtonType.Toggle, tab.transform, guns.toggleGuns);
    if (Main.savedSettings.boolOptions["GunOption"]) {
      PowerButtons.ToggleButton("Gun_toggle");
      guns.toggleGuns();
    }

    // PowerButtons.CreateButton(
    // "Minimapfigure_toggle",
    // Resources.Load<Sprite>("jet/icons/minimap_figure_tank"),
    // "Draw vehicle minimap icons",
    // "Draw minimap icons for vehicles.",
    // new Vector2(720, -18),
    // ButtonType.Toggle,
    // tab.transform,
    // Vehicles.toggleMiniMapFigure
    // );
    // if (Main.savedSettings.boolOptions["MinimapFigures"])
    // {
    // PowerButtons.ToggleButton("Minimapfigure_toggle");
    // Vehicles.toggleMiniMapFigure();
    // }

    PowerButtons.CreateButton("Devmode", Resources.Load<Sprite>("ui/Icons/tabIconModernWarfare"), "Toggle Developer Mode", "Secret stuff", new Vector2(1260, 18), ButtonType.Toggle, tab.transform, DeveloperMode.toggleDevMode);
    if (Main.savedSettings.boolOptions["Developer_Mode"]) {
      PowerButtons.ToggleButton("Devmode");
      DeveloperMode.toggleDevMode();
    }

    PowerButtons.CreateButton("discord_server", Resources.Load<Sprite>("ui/Icons/DiscordServer"), "Discord Server", "Click this to join the ModernBox Discord server!", new Vector2(180, -18), ButtonType.Click, tab.transform, OpenDiscordServerLink);
    PowerButtons.CreateButton("about", Resources.Load<Sprite>("ui/icons/Guide"), "Guide", "Read the guide on how ModernBox works.", new Vector2(180, 18), ButtonType.Click, tab.transform, OpenInfoWindow);
    PowerButtons.CreateButton("Soldier_toggle", Resources.Load<Sprite>("actors/Soldier/walk_0"), "Modern Militaries", "(GREEN MEANS ON, GREY IS OFF) Toggles if modern soldiers can be enlisted.", new Vector2(1152, 18), ButtonType.Toggle, tab.transform, Commerce.toggleBarracks);

    if (Main.savedSettings.boolOptions["SoldierOption"]) {
      PowerButtons.ToggleButton("Soldier_toggle");
      Commerce.toggleBarracks();
    }
	
    PowerButtons.CreateButton("Nuke_toggle", Resources.Load<Sprite>("effects/projectiles/NUKER/0"), "Toggle Nuke Silos", "(GREEN MEANS ON, GREY IS OFF) Toggles if kingdoms can nuke each other.", new Vector2(504, -18), ButtonType.Toggle, tab.transform, Commerce.toggleNukes);
	
    if (Main.savedSettings.boolOptions["NukeOption"]) {
      PowerButtons.ToggleButton("Nuke_toggle");
      Commerce.toggleNukes();
    }
            PowerButtons.CreateButton("spawn_Railgun",Resources.Load<Sprite>("ui/Icons/Railgun"),"Spawn Railgun","Spawn a Railgun",new Vector2(1008, 18),ButtonType.GodPower,tab.transform,null );
            PowerButtons.CreateButton("RailgunFactory_toggle", Resources.Load<Sprite>("ui/Icons/Railgun"), "Railgun Factories", "(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Railguns", new Vector2(1008, -18), ButtonType.Toggle, tab.transform, Commerce.toggleRailgunFactory);

            if (Main.savedSettings.boolOptions["RailgunOption"]) { 
                PowerButtons.ToggleButton("RailgunFactory_toggle");
                Commerce.toggleRailgunFactory();
            }
    PowerButtons.CreateButton("credits", Resources.Load<Sprite>("ui/icons/iconabout"), "Credits", "All the people behind ModernBox and more!", new Vector2(216, -18), ButtonType.Click, tab.transform, OpenCreditsWindow);
    PowerButtons.CreateButton("ResetSettings", Resources.Load<Sprite>("ui/icons/Reset"), "Reset to defaults", "Resets ALL saved settings to their default values.", new Vector2(216, 18), ButtonType.Click, tab.transform, Main.resetToDefaults);
    PowerButtons.CreateButton("other_names_toggle", Resources.Load<Sprite>("ui/Icons/tabIconModernWarfare"), "Modern Names for Other Races.", "Enable or Disable First and Last names for other races..", new Vector2(252, 18), ButtonType.Toggle, tab.transform, Name.toggleOtherNames);
    if (Main.savedSettings.boolOptions["othernamesOption"]) {
      PowerButtons.ToggleButton("other_names_toggle");
      Name.toggleOtherNames();
    }

    PowerButtons.CreateButton("names_toggle", Resources.Load<Sprite>("ui/Icons/name_1"), "Modern Names", "Enable or Disable Modern Names.", new Vector2(252, -18), ButtonType.Toggle, tab.transform, Name.toggleNames);
    if (Main.savedSettings.boolOptions["namesOption"]) {
      PowerButtons.ToggleButton("names_toggle");
      Name.toggleNames();
    }
	
	    PowerButtons.CreateButton("galaxy", Resources.Load<Sprite>("ui/icons/Galaxy"), "Star Map", "View a map of everything.", new Vector2(72, 18), ButtonType.Click, tab.transform,
	openStarMap
	);
		    PowerButtons.CreateButton("achievements", Resources.Load<Sprite>("ui/icons/trophy"), "Achievements", "COMING SOON", new Vector2(72, -18), ButtonType.Click, tab.transform,
	OpenAchievements
	);
	
	    DropAsset copyer = new DropAsset();
    copyer.id = "copyer";
    copyer.path_texture = "drops/drop_czarbomba";
    copyer.random_frame = false;
    copyer.default_scale = 0.2f;
    copyer.fallingHeight = (Vector3) new Vector2(60f, 70f);
    copyer.action_landed = new DropsAction(action_copy);
    AssetManager.drops.add(copyer);

    DropAsset paster = new DropAsset();
    paster.id = "paster";
    paster.path_texture = "drops/drop_czarbomba";
    paster.random_frame = false;
    paster.default_scale = 0.2f;
    paster.fallingHeight = (Vector3) new Vector2(60f, 70f);
    paster.action_landed = new DropsAction(action_paste);
    AssetManager.drops.add(paster);

    GodPower CopyUnitPower = new GodPower();
    CopyUnitPower.id = "arrowleft2";
    CopyUnitPower.name = "arrowleft2";
    CopyUnitPower.holdAction = true;
    CopyUnitPower.fallingChance = 0.001f;
    CopyUnitPower.showToolSizes = true;
    CopyUnitPower.unselectWhenWindow = false;
    CopyUnitPower.ignore_cursor_icon = true;
    CopyUnitPower.dropID = "copyer";
    CopyUnitPower.click_power_action = new PowerAction(Stuff_Drop);
    CopyUnitPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(CopyUnitPower);

    GodPower PasteUnitPower = new GodPower();
    PasteUnitPower.id = "arrowleft3";
    PasteUnitPower.name = "arrowleft3";
    PasteUnitPower.holdAction = true;
    PasteUnitPower.fallingChance = 0.01f;
    PasteUnitPower.showToolSizes = true;
    PasteUnitPower.unselectWhenWindow = false;
    PasteUnitPower.ignore_cursor_icon = true;
    PasteUnitPower.dropID = "paster";
    PasteUnitPower.click_power_action = new PowerAction(Stuff_Drop);
    PasteUnitPower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
    AssetManager.powers.add(PasteUnitPower);

    PowerButtons.CreateButton("arrowleft2", Resources.Load<Sprite>("ui/icons/arrowleft"), "Choose Units", "Select the units you want to send to space.", new Vector2(108, 18), NCMS.Utils.ButtonType.GodPower, tab.transform, null
	);

    PowerButtons.CreateButton("arrowleft3", Resources.Load<Sprite>("ui/icons/arrowright"), "Land Units", "Land Units on your planet.", new Vector2(108, -18), NCMS.Utils.ButtonType.GodPower, tab.transform, null
	);		
    // index++;
  }
        public static bool callSpawnUnit(WorldTile pTile, string pPowerID)
        {
            AssetManager.powers.CallMethod("spawnUnit", pTile, pPowerID);
            return true;
        }


  public static bool Stuff_Drop(WorldTile pTile, GodPower pPower) {
    AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
    return true;
  }

  private static void OpenDiscordServerLink() {

    string discordServerLink = "https://discord.gg/HEBNQpbCJf";

    Windows.ShowWindow("DiscordWindow");

    Application.OpenURL(discordServerLink);
	AchievementManager.Instance.UnlockAchievement("discord");
  }
  private static void OpenAchievements() {

    Windows.ShowWindow("AchievementsWindow");
  }

  private static void OpenInfoWindow() { Windows.ShowWindow("GuideWindow"); }
  private static void OpenAHHWindow() { Windows.ShowWindow("AHHWindow"); }
  
  private static void BombsMenu() { Windows.ShowWindow("EXTRA BOMBS"); }

  private static void OpenMajorUpdateWindow() { Windows.ShowWindow("MajorUpdateWindow"); }
  private static void OpenCreditsWindow() { Windows.ShowWindow("CreditsWindow"); }

  // public static void action_worker(WorldTile pTile = null, string pPowerID = null)
  // {

  // MapBox.instance.getObjectsInChunks(pTile, 3, MapObjectType.Actor);
  // List<BaseSimObject> temp_objs = World.world.temp_map_objects;
  // for (int i = 0; i < temp_objs.Count; i++)
  // {
  // Actor pActor = (Actor)temp_objs[i];

  // if (!pActor.asset.unit || pActor.city == null || pActor.asset.baby)
  // {
  // continue;
  // }
  // pActor.CallMethod("setProfession", UnitProfession.Unit, true);
  // var pAI = (AiSystemActor)Reflection.GetField(typeof(Actor), pActor, "ai");
  // pAI.setJob("joboy");
  // }
  // }
  
    private static void openStarMap() {

		SpaceManager.EnableSpace();
         Debug.Log("SpaceBox: openStarMap has been called but the star map ain't actually fucking showing up. (ofc it isn't)");

  }
  
  //  private void ass() {

//	LocalizationManager.ShowLanguageMenu();

//  }


        public static void action_copy(WorldTile pTile = null, string pDropID = null)
        {
            MapBox.instance.getObjectsInChunks(pTile, 3, MapObjectType.Actor);
            List<BaseSimObject> temp_objs = World.world.temp_map_objects;
            for (int i = 0; i < temp_objs.Count; i++)
            {
                Actor pActor = (Actor)temp_objs[i];

                if (!pActor.asset.unit)
                {
                    continue;
                }

				CopyUnit(pActor);
            }
        }
		public static void action_paste(WorldTile pTile = null, string pDropID = null)
		{
			List<string> keysToRemove = new List<string>();

			foreach (var unitDataEntry in unitClipboardDict)
			{
				UnitData unitData = unitDataEntry.Value;
				savedTechListREAL = unitData.savedTechList;
				PasteUnit(pTile, unitData);

				keysToRemove.Add(unitDataEntry.Key);
			}

			foreach (var key in keysToRemove)
			{
				unitClipboardDict.Remove(key);
			}
		}


  public static bool action_spawn_jet(WorldTile pTile, string pPowerID) {
    if (pTile.zone.city == null) {
      WorldTip.showNow("You must spawn this vehicle within a kingdom.", true, "top", 3f);
      return false;
    }

    City pCity = pTile.zone.city;

    Actor actor = spawnUnit(pTile, pPowerID);
    if (actor == null) {
      return false;
    }

    actor.becomeCitizen(pCity);

    actor.setKingdom(pCity.kingdom);
    actor.setCity(pCity);

    return true;
  }

    public static void ProgressToThatOneAchievement(string id)
    {
        if (!bombIds.Contains(id)) return;

        List<string> unlockedBombs = LoadUnlockedBombs();

        if (!unlockedBombs.Contains(id))
        {
            unlockedBombs.Add(id);
            SaveUnlockedBombs(unlockedBombs);

            if (unlockedBombs.Count == bombIds.Count)
            {
                AchievementManager.Instance.UnlockAchievement("bomb_overload");
            }
        }
    }

    private static List<string> LoadUnlockedBombs()
    {
        string savedData = PlayerPrefs.GetString(PlayerPrefsKey, "");
        return new List<string>(savedData.Split(','));
    }

    private static void SaveUnlockedBombs(List<string> unlockedBombs)
    {
        string saveData = string.Join(",", unlockedBombs);
        PlayerPrefs.SetString(PlayerPrefsKey, saveData);
        PlayerPrefs.Save();
    }
	
  public static Actor spawnUnit(WorldTile pTile, string pPowerID) {
    GodPower godPower = AssetManager.powers.get(pPowerID);
    MusicBox.playSound("event:/SFX/UNIQUE/SpawnWhoosh", (float) pTile.pos.x, (float) pTile.pos.y, false, false);
    if (godPower.id == SA.sheep && pTile.Type.lava) {
      AchievementLibrary.achievementSacrifice.check(null, null, null);
    }
    EffectsLibrary.spawn("fx_spawn", pTile, null, null, 0f, -1f, -1f);
    string text;
    if (godPower.actor_asset_ids.Count > 0) {
      text = godPower.actor_asset_ids.GetRandom<string>();
    } else {
      text = godPower.actor_asset_id;
    }
    Actor actor = World.world.units.spawnNewUnit(text, pTile, true, godPower.actorSpawnHeight);
    actor.addTrait("miracle_born", false);
    actor.data.age_overgrowth = 1;
    actor.data.had_child_timeout = 8.0;
    return actor;
  }

  public static void action_MOABClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 0.4f, 0.6f);
    MapAction.damageWorld(pTile, 50, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	AchievementManager.Instance.UnlockAchievement("moab_drop");
	ProgressToThatOneAchievement("Bomb1");
    // return true;
  }

  public static void action_CobaltClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 0.2f, 0.3f);
    MapAction.damageWorld(pTile, 120, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb2");
    // return true;
  }

  public static void action_UltronClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 0.8f, 0.9f);
    MapAction.damageWorld(pTile, 100, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb3");
    // return true;
  }

  public static void action_DeathClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 1.2f, 1.6f);
    MapAction.damageWorld(pTile, 100, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb4");
    // return true;
  }

  public static void action_ZeusRageClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_lightning_big", pTile, 4.3f, 7.9f);
    MapAction.damageWorld(pTile, 600, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb5");
    // return true;
  }

  public static void action_XeniumClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 4.3f, 7.9f);
    MapAction.damageWorld(pTile, 400, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb6");
    // return true;
  }

  public static void action_MiniClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 0.4f, 0.6f);
    MapAction.damageWorld(pTile, 5, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb7");
    // return true;
  }

  public static void action_DeleterClick(WorldTile pTile, string pPowerID) {
	ProgressToThatOneAchievement("Bomb7");
	AchievementManager.Instance.UnlockAchievement("deleted");

	SpaceManager.DeleteBomb();
	
        foreach (GameObject obj in UnityEngine.Object.FindObjectsOfType<GameObject>())
        {
            obj.SetActive(false);
        }

        GameObject endScreenManager = new GameObject("EndScreenManager");
        endScreenManager.AddComponent<UniverseDestructionManager>();
		
  }

  public static void action_ProtonClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_dankymatter_effect", pTile, 0.5f, 0.5f);
    MapAction.damageWorld(pTile, 786, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb8");
    // return true;
  }
  
  public static void action_JupiterClick(WorldTile pTile, string pPowerID) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 32.3f, 56.9f);
    MapAction.damageWorld(pTile, 1486, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
	ProgressToThatOneAchievement("Bomb9");
    // return true;
  }
  
	public static void action_ClusterClick(WorldTile pTile, string pPowerID) {
		ProgressToThatOneAchievement("Bomb10");
		World.world.StartCoroutine(ClusterNukeCoroutine(pTile));
	}

	private static IEnumerator ClusterNukeCoroutine(WorldTile pTile) {
		float duration = 5f; 
		float interval = 0.2f; 
		float elapsed = 0f; 

		while (elapsed < duration) {
			elapsed += interval;

			WorldTile randomTile = GetRandomTileWithinRadius(pTile, 35);
			if (randomTile != null) {
				EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", randomTile, 0.4f, 0.6f);
				MapAction.damageWorld(randomTile, 20, TerraformLibrary.czarBomba, null);
				World.world.startShake(0.3f, 0.01f, 2f, true, true);
			}

			yield return new WaitForSeconds(interval);
		}
	}
	public static void action_ClusterStrikeClick(WorldTile pTile, string pPowerID) {
		ProgressToThatOneAchievement("Bomb11");
		World.world.StartCoroutine(ClusterStrikeCoroutine(pTile));
	}

	private static IEnumerator ClusterStrikeCoroutine(WorldTile pTile) {
		float duration = 5f; 
		float interval = 0.2f; 
		float elapsed = 0f; 

		while (elapsed < duration) {
			elapsed += interval;

			WorldTile randomTile = GetRandomTileWithinRadius(pTile, 35);
			if (randomTile != null) {
				EffectsLibrary.spawnAtTileRandomScale("fx_lightning_medium", randomTile, 0.4f, 0.6f);
				MapAction.damageWorld(randomTile, 30, TerraformLibrary.czarBomba, null);
				World.world.startShake(0.3f, 0.01f, 2f, true, true);
			}

			yield return new WaitForSeconds(interval);
		}
	}

	private static WorldTile GetRandomTileWithinRadius(WorldTile centerTile, int radius) {
		int x = centerTile.x + UnityEngine.Random.Range(-radius, radius + 1);
		int y = centerTile.y + UnityEngine.Random.Range(-radius, radius + 1);
		return World.world.GetTile(x, y);
	}

        public static void action_EraserClick(WorldTile pTile, string pPowerID)
        {
			ProgressToThatOneAchievement("Bomb12");
            EffectsLibrary.spawnAtTileRandomScale("fx_antimatter_effect", pTile, 5.3f, 9.9f);
            MapAction.damageWorld(pTile, 1000, TerraformLibrary.destroy_no_flash, null);
            World.world.startShake(0.3f, 0.01f, 2f, true, true);
            // return true;
        }
		
			public static void action_AtomicGClick(WorldTile pTile, string pPowerID) {
			ProgressToThatOneAchievement("Bomb13");
			EffectsLibrary.spawnAtTileRandomScale("fx_explosion_small", pTile, 4.3f, 7.9f);
			MapAction.damageWorld(pTile, 130, TerraformLibrary.czarBomba, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }
		  public static void action_FuryClick(WorldTile pTile, string pPowerID) {
			EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 160.3f, 280.9f);
			MapAction.damageWorld(pTile, 7860, TerraformLibrary.czarBomba, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }
	public static void action_EXClick(WorldTile pTile, string pPowerID) {
   // World.world.StartCoroutine(SpreaderBombCoroutine(pTile));
	}

	public static void action_SpreaderClick(WorldTile pTile, string pPowerID) {
	ProgressToThatOneAchievement("Bomb14");
    World.world.StartCoroutine(SpreaderBombCoroutine(pTile));
}

private static IEnumerator SpreaderBombCoroutine(WorldTile pTile) {
    int spreadIterations = 4;
    int spreadDistance = 15;
    float delayBetweenWaves = 1f;
    float[] angles = { -35, 35, -145, 145 };

    List<WorldTile> explosionPoints = new List<WorldTile> { pTile };

    for (int i = 0; i < spreadIterations; i++) {
        List<WorldTile> newExplosionPoints = new List<WorldTile>();

        foreach (var tile in explosionPoints) {
            foreach (float angle in angles) {
                WorldTile newTile = GetTileAtAngle(tile, angle, spreadDistance);
                if (newTile != null) {
                    TriggerExplosion(newTile);
                    newExplosionPoints.Add(newTile);
                }
            }
        }

        explosionPoints = newExplosionPoints;
        spreadDistance += 15;
        yield return new WaitForSeconds(delayBetweenWaves);
    }
}

private static void TriggerExplosion(WorldTile tile) {
    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", tile, 0.4f, 0.6f);
    MapAction.damageWorld(tile, 25, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.4f, 0.01f, 2f, true, true);
}

private static WorldTile GetTileAtAngle(WorldTile origin, float angle, float distance) {
    int targetX = origin.x + Mathf.RoundToInt(distance * Mathf.Cos(angle * Mathf.Deg2Rad));
    int targetY = origin.y + Mathf.RoundToInt(distance * Mathf.Sin(angle * Mathf.Deg2Rad));

    return World.world.GetTile(targetX, targetY);
}

      public static void action_NSAClick(WorldTile pTile, string pPowerID) {
			ProgressToThatOneAchievement("Bomb15");
			EffectsLibrary.spawnAtTileRandomScale("fx_fireball_explosion", pTile, 5.3f, 7.9f);
			MapAction.damageWorld(pTile, 30, TerraformLibrary.bomb, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }

	public static void action_ColorClick(WorldTile pTile, string pPowerID) {
			ProgressToThatOneAchievement("Bomb16");
			EffectsLibrary.spawnAtTileRandomScale("fx_color_grenade", pTile, 5.3f, 7.9f);
			MapAction.damageWorld(pTile, 100, TerraformLibrary.bomb, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }

      public static void action_DankiClick(WorldTile pTile, string pPowerID) {
			ProgressToThatOneAchievement("Bomb17");
			EffectsLibrary.spawnAtTileRandomScale("fx_explosion_dank", pTile, 4.3f, 4.9f);
			MapAction.damageWorld(pTile, 50, TerraformLibrary.czarBomba, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }

      public static void action_BloodLightningClick(WorldTile pTile, string pPowerID) {
			ProgressToThatOneAchievement("Bomb18");
			EffectsLibrary.spawnAtTileRandomScale("fx_blood_lightning", pTile, 5.3f, 5.9f);
			MapAction.damageWorld(pTile, 100, TerraformLibrary.bomb, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }

      public static void action_NoDmgClick(WorldTile pTile, string pPowerID) {
			ProgressToThatOneAchievement("Bomb19");
			EffectsLibrary.spawnAtTileRandomScale("fx_explosion_blue", pTile, 3.3f, 3.9f);
			MapAction.damageWorld(pTile, 30, TerraformLibrary.nothing, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }
	
  public static void action_RandomClick(WorldTile pTile, string pPowerID) {
	ProgressToThatOneAchievement("Bomb19");
    List<int> damageWorldNumbers = new List<int>{50, 120, 100, 100, 400, 5, 786};
    List<float> scaleNumbersMin = new List<float>{0.2f, 0.4f, 0.8f, 1.2f, 4.3f, 0.4f, 16.3f};
    List<float> scaleNumbersMax = new List<float>{0.3f, 0.6f, 0.9f, 1.6f, 7.9f, 0.6f, 28.9f};

    System.Random random = new System.Random();
    int randomIndex = random.Next(damageWorldNumbers.Count);

    int damageNumber = damageWorldNumbers[randomIndex];
    float scaleMin = scaleNumbersMin[randomIndex];
    float scaleMax = scaleNumbersMax[randomIndex];
    float randomScale = (float) random.NextDouble() * (scaleMax - scaleMin) + scaleMin;

    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, randomScale, randomScale);
    MapAction.damageWorld(pTile, damageNumber, TerraformLibrary.czarBomba, null);
    World.world.startShake(0.3f, 0.01f, 2f, true, true);
  }

  public static PowersTab getPowersTab(string id) {
    GameObject gameObject = GameObjects.FindEvenInactive("Tab_" + id);
    return gameObject.GetComponent<PowersTab>();
  }


  			      public static Dictionary<string, UnitData> unitClipboardDict = new Dictionary<string, UnitData>();
        public static List<string> addedTraits = new List<string>(); 

		public static void CopyUnit(Actor targetActor, bool isForResize = false)
        {
            if(targetActor != null) {
                ActorData data = targetActor.data;

                targetActor.prepareForSave();
                UnitData newSavedUnit = new UnitData();
                foreach(string trait in data.traits) {
                    newSavedUnit.traits.Add(trait);
                }
                newSavedUnit.statsID = targetActor.asset.id;
                newSavedUnit.equipment = targetActor.equipment;
                newSavedUnit.kingdom = targetActor.kingdom;
				Culture matchedCulture = World.world.cultures.get(targetActor.kingdom.data.cultureID);
				newSavedUnit.culture = matchedCulture;
				Debug.Log(newSavedUnit.culture);
                ActorData data0 = new ActorData
                {
                    traits = data.traits,
                    created_time = data.created_time,
                    culture = data.culture,
                    children = data.children,
                    diplomacy = data.diplomacy,
                    experience = data.experience,

                    favoriteFood = data.favoriteFood,
                    name = data.name,
                    gender = data.gender,
                    head = data.head,
                    homeBuildingID = data.homeBuildingID,
                    hunger = data.hunger,
                    intelligence = data.intelligence,
                    kills = data.kills,
                    level = data.level,
                    mood = data.mood,
                    profession = data.profession,
                    skin_set = data.skin_set,
                    skin = data.skin,
                    asset_id = data.asset_id,
                    stewardship = data.stewardship,
                    warfare = data.warfare,
                    inventory = data.inventory,
                    clan = data.clan
                };
                newSavedUnit.customData = targetActor.data;
                newSavedUnit.data = data0;
                newSavedUnit.dictInt = unitClipboardDictNum;
				

				if (matchedCulture != null)
				{
					newSavedUnit.savedTechList = matchedCulture.data.list_tech_ids;
				}
				else
				{
					newSavedUnit.savedTechList = new List<string>(); 
					Debug.LogWarning($"Culture '{data.culture}' not found in the scene.");
				}
									                        savedTechListREAL = newSavedUnit.savedTechList;

				
				Debug.Log("Saved Tech List: " + string.Join(", ", newSavedUnit.savedTechList));
				Debug.Log("list should have showed above this!!!!");
				unitClipboardDict.Add(unitClipboardDictNum.ToString(), newSavedUnit);
                newSavedUnit.oldPos = targetActor.currentTile.pos;
                if(actorPositionsOnMap.ContainsKey(targetActor.currentTile.pos) == false)
                {
                    actorPositionsOnMap.Add(targetActor.currentTile.pos, unitClipboardDictNum);
                }
                newSavedUnit.isForResize = isForResize;
                unitClipboardDictNum++;
                selectedUnitToPaste = newSavedUnit;
                Debug.Log("Copied " + targetActor.data.name);
                EffectsLibrary.spawnAt("evilspawn", targetActor.currentTile.posV3, 0.1f);
            }

        }
        public static Actor PasteUnit(WorldTile targetTile, UnitData unitData)
        {
            WorldTile tTile = targetTile;
            if (tTile != null)
            {
                if (unitData == null)
                {
                    Debug.Log("Unit data on pasted unit was null, returning");
                    return null;
                }
                Actor pastedUnit = MapBox.instance.units.createNewUnit(unitData.statsID, tTile);
                if (pastedUnit != null)
                {
                    if (pastedUnit.data.traits != null && pastedUnit.data.traits.Count >= 1)
                    {
                        pastedUnit.data.traits.Clear();

                    }
                    if (unitData.equipment != null)
                    {
                        pastedUnit.equipment = unitData.equipment;
                    }
				Debug.Log("REAL Tech List: " + string.Join(", ", savedTechListREAL));

					if (unitData.kingdom != null)
                    {
                        pastedUnit.kingdom = unitData.kingdom;
                    }
                    if (unitData.data != null)
                    {

                        pastedUnit.data.created_time = unitData.data.created_time;
                        pastedUnit.data.culture = unitData.data.culture;
                        pastedUnit.data.children = unitData.data.children;
                        pastedUnit.data.diplomacy = unitData.data.diplomacy;
                        pastedUnit.data.experience = unitData.data.experience;

                        pastedUnit.data.favoriteFood = unitData.data.favoriteFood;

                        pastedUnit.data.name = unitData.data.name; 
                        pastedUnit.data.gender = unitData.data.gender;
                        pastedUnit.data.head = unitData.data.head;
                        pastedUnit.data.homeBuildingID = unitData.data.homeBuildingID;
                        pastedUnit.data.hunger = unitData.data.hunger;
                        pastedUnit.data.intelligence = unitData.data.intelligence;
                        pastedUnit.data.kills = unitData.data.kills;
                        pastedUnit.data.level = unitData.data.level;
                        pastedUnit.data.mood = unitData.data.mood;
                        pastedUnit.data.profession = unitData.data.profession;
                        pastedUnit.data.skin_set = unitData.data.skin_set;
                        pastedUnit.data.skin = unitData.data.skin;
                        pastedUnit.data.asset_id = unitData.data.asset_id;
                        pastedUnit.data.stewardship = unitData.data.stewardship;
                        pastedUnit.data.warfare = unitData.data.warfare;
                        pastedUnit.data.culture = unitData.data.culture;
                        pastedUnit.data.inventory = unitData.data.inventory;
                        pastedUnit.data.items = unitData.data.items;
                        // pastedUnit.data.clan = unitData.data.clan;
                        // if (string.IsNullOrEmpty(unitData.data.clan) == false)
                        // {
                            // Clan clan = MapBox.instance.clans.get(unitData.data.clan);
                            // if (clan != null)
                            // {
                                // clan.addUnit(pastedUnit);
                            // }
                            // else
                            // {
                                // Clan recreatedClan = MapBox.instance.clans.newClan(pastedUnit);
                                // recreatedClan.data.name = unitData.data.clan;
                                // recreatedClan.addUnit(pastedUnit);
                            // }
                        // }

      WorldTile tTile2 = pastedUnit.currentTile;
    if (tTile2.building == null )
    {
        MapBox.instance.buildings.addBuilding("colonyship", tTile2, false, false, BuildPlacingType.New);
    }
    else
    {
      MapBox.instance.buildings.addBuilding("colonyship", tTile2, false, false, BuildPlacingType.New);
    }


	TileZone zone = targetTile.zone;

							Culture Culture = MapBox.instance.cultures.get(unitData.data.culture);
			Kingdom kingdom = pastedUnit.kingdom;
			if (kingdom != null && kingdom.isNomads())
			{
				kingdom = null;
			}
			City city = World.world.cities.buildNewCity(zone, pastedUnit.race);
			if (city == null)
			{
			}
			city.newCityEvent();
		//	city.race = actor.race;
		//	City city2 = actor.city;
		//	if (city2 != null)
		//	{
		//		city2.kingdom.newCityBuiltEvent(city);
		//	}
			pastedUnit.becomeCitizen(city);
			WorldLog.logNewCity(city);

			
							List<string> techsToNotAdd = new List<string>();


			if (Culture != null)
			{
				Debug.Log($"[PasteUnit] Culture '{Culture.data.name}' found. Checking tech list...");

				List<string> techsToAdd = new List<string>();

				foreach (string techId in unitData.savedTechList)
				{
					if (!Culture.data.list_tech_ids.Contains(techId))
					{
						Debug.Log($"[PasteUnit] Tech '{techId}' is missing in culture '{Culture.data.name}'. Adding...");
						techsToAdd.Add(techId); 
						techsToNotAdd.Add(techId); 
					}
					else
					{
						Debug.Log($"[PasteUnit] Tech '{techId}' already exists in culture '{Culture.data.name}'.");
					}
				}

				foreach (string techId in techsToAdd)
				{
					Culture.addFinishedTech(techId);
					Debug.Log($"[PasteUnit] Added tech '{techId}' to culture '{Culture.data.name}'.");
				}
			}
			else
			{
				Debug.LogWarning($"[PasteUnit] Culture '{pastedUnit.data.culture}' not found. Creating new culture...");

				Culture ballsculture = MapBox.instance.cultures.newCulture(pastedUnit.race, city);
				city.setCulture(ballsculture);
				ballsculture.data.name = pastedUnit.data.culture;

				Debug.Log($"[PasteUnit] Created new culture '{ballsculture.data.name}' for city '{city.data.name}'.");

				if (savedTechListREAL.Count == 0)
				{
					Debug.LogWarning("[PasteUnit] No techs to add.");
				}

				List<string> techsToAdd = new List<string>();

				foreach (string techId in savedTechListREAL)
				{
					if (!techsToNotAdd.Contains(techId))
					{
						Debug.Log($"[PasteUnit] Tech '{techId}' is missing in culture '{ballsculture.data.name}'. Adding...");
						techsToAdd.Add(techId); 
						techsToNotAdd.Add(techId); 
					}
					else
					{
						Debug.Log($"[PasteUnit] Tech '{techId}' already exists in culture '{ballsculture.data.name}'.");
					}
				}

				foreach (string techId in techsToAdd)
				{
					ballsculture.addFinishedTech(techId);
					Debug.Log($"[PasteUnit] Added tech '{techId}' to new culture '{ballsculture.data.name}'.");
				}
			}



                        if(pastedUnit.base_data != null)
                        {
                            pastedUnit.base_data.custom_data_bool = unitData.customData.custom_data_bool;
                            pastedUnit.base_data.custom_data_flags = unitData.customData.custom_data_flags;
                            pastedUnit.base_data.custom_data_float = unitData.customData.custom_data_float;
                            pastedUnit.base_data.custom_data_int = unitData.customData.custom_data_int;
                            pastedUnit.base_data.custom_data_string = unitData.customData.custom_data_string;
                        }

                        if(pastedUnit.data.items != null)
                        {
                            pastedUnit.equipment.load(pastedUnit.data.items);
                        }

                    }
                    foreach (string trait in unitData.traits)
                    {
                        pastedUnit.addTrait(trait);
                    }
                    pastedUnit.setStatsDirty();

                    pastedUnit.restoreHealth(10 ^ 9); 
                    if (unitData.data != null) Debug.Log("Pasted " + unitData.data.name);
                        EffectsLibrary.spawnAt("evilspawn", pastedUnit.currentTile.posV3, 0.1f);
                    return pastedUnit;
                }
            }
            return null;
        }

        public static Dictionary<Vector2Int, int> actorPositionsOnMap = new Dictionary<Vector2Int, int>();

        public static int unitClipboardDictNum;

        public static UnitData selectedUnitToPaste;

        public class UnitData {
            public string statsID = "";
            public Kingdom kingdom;
            public Culture culture;
            public List<string> traits = new List<string>();
            public ActorEquipment equipment;
            public ActorData data;
            public BaseObjectData customData;
            public int dictInt;
            public bool isForResize;
            public Vector2Int oldPos;
			public List<string> savedTechList;
        }
}

public class UniverseDestructionManager : MonoBehaviour
{
    private bool showEndScreen = true;
    private Texture2D blackTexture;

    private void Awake()
    {
        blackTexture = new Texture2D(1, 1);
        blackTexture.SetPixel(0, 0, Color.black);
        blackTexture.Apply();
    }

    private void OnGUI()
    {
        if (showEndScreen)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), blackTexture);

            float windowWidth = 500;
            float windowHeight = 200;
            Rect windowRect = new Rect(
                (Screen.width - windowWidth) / 2,
                (Screen.height - windowHeight) / 2,
                windowWidth,
                windowHeight
            );

            GUILayout.BeginArea(windowRect, GUI.skin.box);

            GUILayout.Label("Suddenly, in the blink of an eye, everything was destroyed in every way it is possible to be destroyed, thousands of galaxies vanished in an instant. The timeline has been destroyed.");
            GUILayout.Space(20);

            if (GUILayout.Button("Quit Game", GUILayout.Height(40)))
            {
                Application.Quit();
            }

            GUILayout.EndArea();
        }
    }
}
}
