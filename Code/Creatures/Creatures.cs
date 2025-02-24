//========= MODERNBOX 2.2.0.0 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
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
using ai;
using UnityEngine.Tilemaps;

namespace M2
{
    class Creatures : MonoBehaviour
    {
		
  public static readonly string Terlanius;
	//private static BiomeAsset Glitch;


        public static void init()
        {
            loadAssets();

        }
		
		


        private static void loadAssets()
        {


            BuildingAsset Chess_tree = AssetManager.buildings.clone("Chess_tree", "tree");
            Chess_tree.affected_by_drought = false;
		    Chess_tree.burnable = false;
		    Chess_tree.draw_light_area = false;
		    Chess_tree.draw_light_size = 0.1f;
            Chess_tree.limit_per_zone = 1;
            Chess_tree.canBePlacedOnlyOn = List.Of<string>(new string[]{"Chess_low","Chess_high"});
            Chess_tree.spread_ids = List.Of<string>(new string[]{"Chess_tree"});
            Chess_tree.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("wood", 6, false);
            AssetManager.buildings.addResource("evil_beets", 5, false);
            AssetManager.buildings.add(Chess_tree);
            AssetManager.buildings.loadSprites(Chess_tree);

            BuildingAsset Chess_tree_2 = AssetManager.buildings.clone("Chess_tree_2", "tree");
            Chess_tree_2.affected_by_drought = false;
		    Chess_tree_2.burnable = false;
		    Chess_tree_2.draw_light_area = false;
		    Chess_tree_2.draw_light_size = 0.1f;
            Chess_tree_2.limit_per_zone = 1;
            Chess_tree_2.canBePlacedOnlyOn = List.Of<string>(new string[]{"Chess_low","Chess_high"});
            Chess_tree_2.spread_ids = List.Of<string>(new string[]{"Chess_tree_2"});
            Chess_tree_2.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("wood", 6, false);
            AssetManager.buildings.addResource("evil_beets", 5, false);
            AssetManager.buildings.add(Chess_tree_2);
            AssetManager.buildings.loadSprites(Chess_tree_2);

            BuildingAsset Chess_tree_3 = AssetManager.buildings.clone("Chess_tree_3", "tree");
            Chess_tree_3.affected_by_drought = false;
		    Chess_tree_3.burnable = false;
		    Chess_tree_3.draw_light_area = false;
		    Chess_tree_3.draw_light_size = 0.1f;
            Chess_tree_3.limit_per_zone = 1;
            Chess_tree_3.canBePlacedOnlyOn = List.Of<string>(new string[]{"Chess_low","Chess_high"});
            Chess_tree_3.spread_ids = List.Of<string>(new string[]{"Chess_tree_3"});
            Chess_tree_3.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("wood", 6, false);
            AssetManager.buildings.addResource("evil_beets", 5, false);
            AssetManager.buildings.add(Chess_tree_3);
            AssetManager.buildings.loadSprites(Chess_tree_3);

            BuildingAsset Glitch_tree = AssetManager.buildings.clone("Glitch_tree", "tree");
            Glitch_tree.affected_by_drought = false;
		    Glitch_tree.burnable = false;
		    Glitch_tree.draw_light_area = false;
		    Glitch_tree.draw_light_size = 0.1f;
            Glitch_tree.limit_per_zone = 1;
            Glitch_tree.canBePlacedOnlyOn = List.Of<string>(new string[]{"Glitch_low","Glitch_high"});
            Glitch_tree.spread_ids = List.Of<string>(new string[]{"Glitch_tree"});
            Glitch_tree.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("wood", 6, false);
            AssetManager.buildings.addResource("evil_beets", 5, false);
            AssetManager.buildings.add(Glitch_tree);
            AssetManager.buildings.loadSprites(Glitch_tree);

            BuildingAsset Glitch_tree_big = AssetManager.buildings.clone("Glitch_tree_big", "tree");
            Glitch_tree_big.affected_by_drought = false;
		    Glitch_tree_big.burnable = true;
		    Glitch_tree_big.draw_light_area = false;
		    Glitch_tree_big.draw_light_size = 0.2f;
            Glitch_tree_big.limit_per_zone = 1;
            Glitch_tree_big.canBePlacedOnlyOn = List.Of<string>(new string[]{"Glitch_low","Glitch_high"});
            Glitch_tree_big.spread_ids = List.Of<string>(new string[]{"Glitch_tree_big"});
            Glitch_tree_big.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("wood", 30, false);
            AssetManager.buildings.addResource("evil_beets", 15, false);
            AssetManager.buildings.add(Glitch_tree_big);
            AssetManager.buildings.loadSprites(Glitch_tree_big);

            BuildingAsset Glitch_plant = AssetManager.buildings.clone("Glitch_plant", "swamp_plant");
            Glitch_plant.affected_by_drought = false;
		    Glitch_plant.burnable = false;
            Glitch_plant.material = "building";
		    Glitch_plant.draw_light_area = false;
		    Glitch_plant.draw_light_size = 0.1f;
            Glitch_plant.wheat = true;
            Glitch_plant.limit_per_zone = 1;
            Glitch_plant.canBeHarvested = true;
            Glitch_plant.setShadow(0.5f, 0.03f, 0.12f);
            Glitch_plant.canBePlacedOnlyOn = List.Of<string>(new string[]{"Glitch_low","Glitch_high"});
            Glitch_plant.spread_ids = List.Of<string>(new string[]{"Glitch_plant"});
            AssetManager.buildings.addResource("evil_beets", 2, false);
            AssetManager.buildings.addResource("bones", 2, false);
            AssetManager.buildings.add(Glitch_plant);
            AssetManager.buildings.loadSprites(Glitch_plant);


            BuildingAsset Glitch_tomb = AssetManager.buildings.clone("Glitch_tomb", "swamp_plant");
            Glitch_tomb.affected_by_drought = false;
		    Glitch_tomb.burnable = false;
            Glitch_tomb.material = "building";
		    Glitch_tomb.draw_light_area = false;
		    Glitch_tomb.draw_light_size = 0.1f;
            Glitch_tomb.wheat = true;
            Glitch_tomb.limit_per_zone = 1;
            Glitch_tomb.canBeHarvested = true;
            Glitch_tomb.setShadow(0.5f, 0.03f, 0.12f);
            Glitch_tomb.canBePlacedOnlyOn = List.Of<string>(new string[]{"Glitch_low","Glitch_high"});
            Glitch_tomb.spread_ids = List.Of<string>(new string[]{"Glitch_tomb"});
            AssetManager.buildings.addResource("evil_beets", 2, false);
            AssetManager.buildings.addResource("stone", 2, false);
            AssetManager.buildings.add(Glitch_tomb);
            AssetManager.buildings.loadSprites(Glitch_tomb);


            BuildingAsset Glitch_candle = AssetManager.buildings.clone("Glitch_candle", "swamp_plant");
            Glitch_candle.affected_by_drought = false;
		    Glitch_candle.burnable = false;
            Glitch_candle.material = "building";
		    Glitch_candle.draw_light_area = true;
		    Glitch_candle.draw_light_size = 0.1f;
            Glitch_candle.wheat = true;
            Glitch_candle.limit_per_zone = 1;
            Glitch_candle.canBeHarvested = true;
            Glitch_candle.setShadow(0.5f, 0.03f, 0.12f);
            Glitch_candle.canBePlacedOnlyOn = List.Of<string>(new string[]{"Glitch_low","Glitch_high"});
            Glitch_candle.spread_ids = List.Of<string>(new string[]{"Glitch_candle"});
            AssetManager.buildings.addResource("evil_beets", 1, false);
            AssetManager.buildings.add(Glitch_candle);
            AssetManager.buildings.loadSprites(Glitch_candle);

                   BuildingAsset tartarus_desert_bones_big = AssetManager.buildings.clone("tartarus_desert_bones_big", "tree");
            tartarus_desert_bones_big.affected_by_drought = false;
                        tartarus_desert_bones_big.material = "building";
		    tartarus_desert_bones_big.burnable = false;
		    tartarus_desert_bones_big.draw_light_area = false;
		    tartarus_desert_bones_big.draw_light_size = 0.1f;
            tartarus_desert_bones_big.limit_per_zone = 1;
            tartarus_desert_bones_big.canBePlacedOnlyOn = List.Of<string>(new string[]{"tartarus_high"});
            tartarus_desert_bones_big.spread_ids = List.Of<string>(new string[]{"tartarus_desert_bones_big"});
            tartarus_desert_bones_big.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("bones", 10, false);
            AssetManager.buildings.addResource("wood", 5, false);
            AssetManager.buildings.addResource("stone", 5, false);
            AssetManager.buildings.add(tartarus_desert_bones_big);
            AssetManager.buildings.loadSprites(tartarus_desert_bones_big);

            BuildingAsset tartarus_tar_bones_big = AssetManager.buildings.clone("tartarus_tar_bones_big", "tree");
            tartarus_tar_bones_big.affected_by_drought = false;
             tartarus_tar_bones_big.material = "building";
             tartarus_tar_bones_big.destroyOnLiquid = false;
		    tartarus_tar_bones_big.burnable = false;
		    tartarus_tar_bones_big.draw_light_area = false;
		    tartarus_tar_bones_big.draw_light_size = 0.1f;
            tartarus_tar_bones_big.limit_per_zone = 1;
            tartarus_tar_bones_big.canBePlacedOnlyOn = List.Of<string>(new string[]{"tartarus_low"});
            tartarus_tar_bones_big.spread_ids = List.Of<string>(new string[]{"tartarus_tar_bones_big"});
            tartarus_tar_bones_big.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("bones", 10, false);
            AssetManager.buildings.addResource("wood", 5, false);
            AssetManager.buildings.addResource("stone", 5, false);
            AssetManager.buildings.add(tartarus_tar_bones_big);
            AssetManager.buildings.loadSprites(tartarus_tar_bones_big);

            BuildingAsset tartarus_vent = AssetManager.buildings.clone("tartarus_vent", "tree");
            tartarus_vent.affected_by_drought = false;
              tartarus_vent.material = "building";
		    tartarus_vent.burnable = false;
		    tartarus_vent.draw_light_area = false;
		    tartarus_vent.draw_light_size = 0.1f;
            tartarus_vent.limit_per_zone = 1;
            tartarus_vent.canBePlacedOnlyOn = List.Of<string>(new string[]{"tartarus_low","tartarus_high"});
            tartarus_vent.spread_ids = List.Of<string>(new string[]{"tartarus_vent"});
            tartarus_vent.setShadow(0.5f, 0.03f, 0.12f);
            AssetManager.buildings.addResource("mythril", 1, false);
            AssetManager.buildings.addResource("wood", 5, false);
            AssetManager.buildings.addResource("stone", 20, false);
            AssetManager.buildings.add(tartarus_vent);
            AssetManager.buildings.loadSprites(tartarus_vent);



            BuildingAsset tartarus_desert_bones = AssetManager.buildings.clone("tartarus_desert_bones", "swamp_plant");
            tartarus_desert_bones.affected_by_drought = false;
		    tartarus_desert_bones.burnable = false;
                 tartarus_desert_bones.material = "building";
            tartarus_desert_bones.material = "building";
		    tartarus_desert_bones.draw_light_area = false;
		    tartarus_desert_bones.draw_light_size = 0.1f;
            tartarus_desert_bones.wheat = true;
            tartarus_desert_bones.limit_per_zone = 3;
            tartarus_desert_bones.canBeHarvested = true;
            tartarus_desert_bones.setShadow(0.5f, 0.03f, 0.12f);
            tartarus_desert_bones.canBePlacedOnlyOn = List.Of<string>(new string[]{"tartarus_high"});
            tartarus_desert_bones.spread_ids = List.Of<string>(new string[]{"tartarus_desert_bones"});
            AssetManager.buildings.addResource("bones", 1, false);
            AssetManager.buildings.addResource("wood", 1, false);
            AssetManager.buildings.addResource("stone", 1, false);
            AssetManager.buildings.add(tartarus_desert_bones);
            AssetManager.buildings.loadSprites(tartarus_desert_bones);

            BuildingAsset tartarus_tar_bones = AssetManager.buildings.clone("tartarus_tar_bones", "swamp_plant");
            tartarus_tar_bones.affected_by_drought = false;
              tartarus_tar_bones.material = "building";
		    tartarus_tar_bones.burnable = false;
            tartarus_tar_bones.material = "building";
		    tartarus_tar_bones.draw_light_area = false;
		    tartarus_tar_bones.draw_light_size = 0.1f;
            tartarus_tar_bones.wheat = true;
            tartarus_tar_bones.limit_per_zone = 3;
            tartarus_tar_bones.canBeHarvested = true;
            tartarus_tar_bones.setShadow(0.5f, 0.03f, 0.12f);
            tartarus_tar_bones.canBePlacedOnlyOn = List.Of<string>(new string[]{"tartarus_low"});
            tartarus_tar_bones.spread_ids = List.Of<string>(new string[]{"tartarus_tar_bones"});
            AssetManager.buildings.addResource("bones", 1, false);
            AssetManager.buildings.addResource("wood", 1, false);
            AssetManager.buildings.addResource("stone", 1, false);
            AssetManager.buildings.add(tartarus_tar_bones);
            AssetManager.buildings.loadSprites(tartarus_tar_bones);

            BuildingAsset tartarus_ruins = AssetManager.buildings.clone("tartarus_ruins", "swamp_plant");
            tartarus_ruins.affected_by_drought = false;
		    tartarus_ruins.burnable = false;
              tartarus_ruins.material = "building";
            tartarus_ruins.material = "building";
		    tartarus_ruins.draw_light_area = false;
		    tartarus_ruins.draw_light_size = 0.1f;
            tartarus_ruins.wheat = true;
            tartarus_ruins.limit_per_zone = 3;
            tartarus_ruins.canBeHarvested = true;
            tartarus_ruins.setShadow(0.5f, 0.03f, 0.12f);
            tartarus_ruins.canBePlacedOnlyOn = List.Of<string>(new string[]{"tartarus_high"});
            tartarus_ruins.spread_ids = List.Of<string>(new string[]{"tartarus_ruins"});
            AssetManager.buildings.addResource("common_metals", 2, false);
            AssetManager.buildings.addResource("wood", 1, false);
            AssetManager.buildings.addResource("stone", 1, false);
            AssetManager.buildings.add(tartarus_ruins);
            AssetManager.buildings.loadSprites(tartarus_ruins);

  BuildingAsset missilecybercore = AssetManager.buildings.clone("missilecybercore", "tumor");
            missilecybercore.spawnUnits = true;
            missilecybercore.spawnUnits_asset = "assimilarptor";
		    missilecybercore.race = "assimilators";
            missilecybercore.kingdom = "assimilators";
            missilecybercore.tower_projectile = "cybermissileprojectile";
            missilecybercore.tower = true;
            missilecybercore.base_stats[S.health] = 200f;
		    missilecybercore.tower_projectile_offset = 2f;
            missilecybercore.tower_projectile_amount = 10;
            missilecybercore.base_stats[S.damage] = 3f;
		    missilecybercore.base_stats[S.knockback] = 0.2f;
        missilecybercore.draw_light_area = true;
		missilecybercore.draw_light_size = 0.2f;
		missilecybercore.draw_light_area_offset_y = 2f;
		missilecybercore.transformTilesToTopTiles = ST.cybertile_low;
		missilecybercore.grow_creep_steps_before_new_direction = 7;
		missilecybercore.grow_creep_direction_random_position = false;
		missilecybercore.grow_creep_random_new_direction = true;
		missilecybercore.damagedByRain = true;
		missilecybercore.burnable = false;
		missilecybercore.material = "building";
		missilecybercore.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleCybercore";
		missilecybercore.sound_hit = "event:/SFX/HIT/HitMetal";
		missilecybercore.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingRobotic";
		missilecybercore.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingRobotic";
		   AssetManager.buildings.setGrowBiomeAround(ST.biome_cybertile, 20, 6, 2f, CreepWorkerMovementType.Direction);
            AssetManager.buildings.add(missilecybercore);
            AssetManager.buildings.loadSprites(missilecybercore);


  BuildingAsset icewatchtower = AssetManager.buildings.clone("icewatchtower", "!building");
            icewatchtower.affected_by_drought = false;
		    icewatchtower.burnable = false;
            icewatchtower.base_stats[S.health] = 200f;
            icewatchtower.base_stats[S.damage] = 10f;
		    icewatchtower.base_stats[S.knockback] = 0.5f;
		    icewatchtower.fundament = new BuildingFundament(1, 0, 1, 0);
            icewatchtower.spawnUnits = false;
		    icewatchtower.race = "walkers";
            icewatchtower.kingdom = "walkers";
            icewatchtower.draw_light_area = true;
            icewatchtower.draw_light_size = 0.5f;
		    icewatchtower.draw_light_area_offset_y = 8f;
		    icewatchtower.tower_projectile = "frostbolt";
		    icewatchtower.tower_projectile_offset = 10f;
            icewatchtower.checkForCloseBuilding = false;
		    icewatchtower.canBeLivingHouse = false;
            icewatchtower.canBePlacedOnLiquid = false;
            icewatchtower.ignoreBuildings = true;
            icewatchtower.canBeHarvested = true;
            icewatchtower.setShadow(0.5f, 0.03f, 0.12f);
		    icewatchtower.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.add(icewatchtower);
            AssetManager.buildings.loadSprites(icewatchtower);

            BuildingAsset walkercorpse = AssetManager.buildings.clone("walkercorpse", "!building");
            walkercorpse.affected_by_drought = false;
		    walkercorpse.burnable = false;
            walkercorpse.base_stats[S.health] = 10000f;
		    walkercorpse.fundament = new BuildingFundament(1, 0, 1, 0);
            walkercorpse.spawnUnits = true;
		    walkercorpse.spawnUnits_asset = "fly";
		    walkercorpse.race = "nature";
            walkercorpse.kingdom = "nature";
            walkercorpse.checkForCloseBuilding = false;
		    walkercorpse.canBeLivingHouse = false;
            walkercorpse.canBePlacedOnLiquid = true;
            walkercorpse.ignoreBuildings = true;
            walkercorpse.canBeHarvested = false;
            walkercorpse.setShadow(0.5f, 0.03f, 0.12f);
            walkercorpse.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleBeehive";
            walkercorpse.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    walkercorpse.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.add(walkercorpse);
            AssetManager.buildings.loadSprites(walkercorpse);

            BuildingAsset colonyship = AssetManager.buildings.clone("colonyship", "!building");
            colonyship.affected_by_drought = false;
		    colonyship.burnable = false;
            colonyship.base_stats[S.health] = 1000f;
		    colonyship.fundament = new BuildingFundament(1, 0, 1, 0);
		    colonyship.race = "nature";
            colonyship.kingdom = "nature";
            colonyship.checkForCloseBuilding = false;
		    colonyship.canBeLivingHouse = false;
            colonyship.canBePlacedOnLiquid = true;
            colonyship.ignoreBuildings = true;
            colonyship.canBeHarvested = true;
            colonyship.setShadow(0.5f, 0.03f, 0.12f);
            colonyship.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleBeehive";
            colonyship.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    colonyship.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.add(colonyship);
            AssetManager.buildings.addResource("wood", 200, false);
            AssetManager.buildings.addResource("stone", 200, false);
            AssetManager.buildings.addResource("common_metals", 200, false);
            AssetManager.buildings.loadSprites(colonyship);

                         TopTileType cybertilelow = AssetManager.topTiles.get("cybertile_low");
            AssetManager.topTiles.add(cybertilelow);
            AssetManager.topTiles.loadSpritesForTile(cybertilelow);
            MapBox.instance.tilemap.layers[cybertilelow.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

               TopTileType cybertilehigh = AssetManager.topTiles.get("cybertile_high");
            AssetManager.topTiles.add(cybertilehigh);
            AssetManager.topTiles.loadSpritesForTile(cybertilehigh);
            MapBox.instance.tilemap.layers[cybertilehigh.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

var icewalker = AssetManager.actor_library.get("walker");
 icewalker.traits.Add("Potential");
   var assimilatorin = AssetManager.actor_library.get("assimilator");
 assimilatorin.traits.Add("Potential");
 assimilatorin.traits.Add("SolarPoweredCyberBody");

                       var glitchtarantula = AssetManager.actor_library.clone("glitchtarantula", "skeleton");
		glitchtarantula.texture_path = "glitchtarantula";
        glitchtarantula.defaultAttack = "jaws";
       glitchtarantula.base_stats[S.max_age] = 130;
       glitchtarantula.base_stats[S.health] = 80;
       glitchtarantula.base_stats[S.damage] = 20;
       glitchtarantula.base_stats[S.armor] = 0;
       glitchtarantula.base_stats[S.speed] = 30f;
       glitchtarantula.base_stats[S.area_of_effect] = 1;
       glitchtarantula.base_stats[S.knockback] = 0;
       glitchtarantula.base_stats[S.knockback_reduction] = 1f;
       glitchtarantula.actorSize = ActorSize.S16_Buffalo;
		glitchtarantula.defaultWeapons.Clear();
		glitchtarantula.defaultWeaponsMaterial.Clear();
        glitchtarantula.body_separate_part_head = false;
        glitchtarantula.take_items = false;
        glitchtarantula.use_items = false;
        glitchtarantula.take_items_ignore_range_weapons = false;
        glitchtarantula.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
        glitchtarantula.animation_idle = "walk_0";
        AssetManager.actor_library.add(glitchtarantula);
        AssetManager.actor_library.CallMethod("loadShadow",glitchtarantula);
        Localization.addLocalization(glitchtarantula.nameLocale,glitchtarantula.nameLocale);

         var glitchdrake = AssetManager.actor_library.clone("glitchdrake", "crocodile");
       glitchdrake.nameLocale = "glitchdrake";
       glitchdrake.nameTemplate = "evil_mage_name";
       glitchdrake.race = "undead";
       glitchdrake.kingdom = "undead";
       glitchdrake.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
       glitchdrake.animation_idle = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
       glitchdrake.texture_path = "glitchdrake";
       //glitchdrake.icon = "";
       glitchdrake.job = "move_mob";
       glitchdrake.actorSize = ActorSize.S17_Dragon;
       glitchdrake.defaultAttack = "base";
       glitchdrake.disablePunchAttackAnimation = false;
       glitchdrake.base_stats[S.max_age] = 1000;
       glitchdrake.base_stats[S.health] = 400;
       glitchdrake.base_stats[S.speed] = 50f;
       glitchdrake.base_stats[S.damage] = 30;
       glitchdrake.base_stats[S.armor] = 0;
       glitchdrake.base_stats[S.area_of_effect] = 1;
       glitchdrake.base_stats[S.knockback] = 0;
       glitchdrake.base_stats[S.knockback_reduction] = 4f;
       glitchdrake.animal = true;
       glitchdrake.baby = false;
       glitchdrake.egg = false;
       glitchdrake.layEggs = false;
       glitchdrake.eggStatsID = "";
       glitchdrake.years_to_grow_to_adult = 18;
       glitchdrake.growIntoID = "";
       glitchdrake.inspect_children = false;
       glitchdrake.procreate_age = 18;
       glitchdrake.procreate = false;
       glitchdrake.animal_baby_making_around_limit = 3;
       glitchdrake.base_stats[S.max_children] = 5f;
       glitchdrake.canBeKilledByDivineLight = true;
       glitchdrake.canBeKilledByLifeEraser = true;
       glitchdrake.ignoredByInfinityCoin = false;
       glitchdrake.disableJumpAnimation = true;
       glitchdrake.canBeMovedByPowers = true;
       glitchdrake.canTurnIntoZombie = false;
       glitchdrake.canTurnIntoMush = false;
       glitchdrake.canTurnIntoTumorMonster = false;
       glitchdrake.canAttackBuildings = true;
       glitchdrake.hideFavoriteIcon = false;
       glitchdrake.can_edit_traits = true;
       glitchdrake.damagedByOcean = false;
       glitchdrake.swampCreature = false;
       glitchdrake.damagedByRain = false;
       glitchdrake.oceanCreature = false;
       glitchdrake.action_liquid = new WorldAction(ActionLibrary.swimToIsland);
       glitchdrake.landCreature = true;
       glitchdrake.dieOnGround = false;
       glitchdrake.take_items = false;
       glitchdrake.use_items = false;
       glitchdrake.body_separate_part_hands = false;
       glitchdrake.take_items_ignore_range_weapons = false;
       glitchdrake.has_skin = false;
       glitchdrake.immune_to_injuries = false;
       glitchdrake.maxHunger = 100;
       glitchdrake.needFood = false;
       glitchdrake.diet_meat = true;
       glitchdrake.diet_berries = false;
       glitchdrake.diet_crops = false;
       glitchdrake.diet_flowers = false;
       glitchdrake.diet_grass = false;
       glitchdrake.diet_vegetation = false;
       glitchdrake.diet_meat = true;
       glitchdrake.diet_meat_insect = false;
       glitchdrake.diet_meat_same_race = true;
       glitchdrake.source_meat = true;
       glitchdrake.source_meat_insect = false;
       glitchdrake.has_soul = false;
       glitchdrake.dieInLava = false;
       glitchdrake.hovering = true;
       glitchdrake.flying = false;
       glitchdrake.very_high_flyer = false;
       glitchdrake.hovering_min = 0f;
       glitchdrake.hovering_max = 0f;
        glitchdrake.specialAnimation = false;
       glitchdrake.specialDeadAnimation = false;
        glitchdrake.moveFromBlock = true;
		    glitchdrake.dieOnBlocks = false;
        AssetManager.actor_library.add(glitchdrake);
        AssetManager.actor_library.CallMethod("loadShadow",glitchdrake);
        AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
        AssetManager.actor_library.CallMethod("addTrait", "giant");
        AssetManager.actor_library.CallMethod("addTrait", "tough");
        ActorAsset dragonded = glitchdrake;
		dragonded.action_death = (WorldAction)Delegate.Combine(dragonded.action_death, new WorldAction(ActionLibrary.dragonSlayer));
        Localization.addLocalization(glitchdrake.nameLocale,glitchdrake.nameLocale);

               var glitchspectre = AssetManager.actor_library.clone("glitchspectre", "ghost");
       glitchspectre.nameLocale = "glitchspectre";
       glitchspectre.nameTemplate = "fire_skull_name";
       glitchspectre.race = "undead";
       glitchspectre.kingdom = "undead";
       glitchspectre.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
       glitchspectre.animation_idle = "walk_0";
       glitchspectre.texture_path = "glitchspectre";
       //glitchspectre.icon = "";
       glitchspectre.defaultAttack = "base";
       glitchspectre.canAttackBuildings = false;
       glitchspectre.damagedByOcean = false;
       glitchspectre.damagedByRain = false;
       glitchspectre.oceanCreature = false;
       glitchspectre.action_liquid = new WorldAction(ActionLibrary.swimToIsland);
       glitchspectre.landCreature = true;
       glitchspectre.dieOnGround = false;
       glitchspectre.body_separate_part_head = false;
       glitchspectre.take_items_ignore_range_weapons = false;
       glitchspectre.dieInLava = false;
        AssetManager.actor_library.add(glitchspectre);
        AssetManager.actor_library.CallMethod("loadShadow",glitchspectre);
        AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
        Localization.addLocalization(glitchspectre.nameLocale,glitchspectre.nameLocale);



          KingdomAsset TerlaniusKingdom = new KingdomAsset();
          TerlaniusKingdom.id = "TerlaniusKingdom";
          TerlaniusKingdom.mobs = true;
          TerlaniusKingdom.addTag("Terlanius");
          TerlaniusKingdom.addFriendlyTag("Terlanius");
          TerlaniusKingdom.addFriendlyTag("NoneFriendlyTag");
          TerlaniusKingdom.addEnemyTag("SK.neutral");
          TerlaniusKingdom.addEnemyTag("SK.good");
          AssetManager.kingdoms.add(TerlaniusKingdom);
          MapBox.instance.kingdoms.CallMethod("newHiddenKingdom", TerlaniusKingdom);
			

			  DisasterAsset CyberDisaster = new DisasterAsset
        {
            id = "CyberDisaster",
            rate = 1,
            chance = 0.2f,
            min_world_population = 1000,
            min_world_cities = 4,
            world_log = "worldlog_disaster_alien_invasion",
            world_log_icon = "SolarPoweredCyberBody",
            spawn_asset_unit = "Assimilatus",
            max_existing_units = 1,
            units_min = 1,
            units_max = 1,
            type = DisasterType.Other,
            premium_only = false
        };
        CyberDisaster.ages_allow.Add(S.age_hope);
        CyberDisaster.ages_allow.Add(S.age_sun);
        CyberDisaster.ages_allow.Add(S.age_wonders);
 		CyberDisaster.action = simpleUnitAssetSpawnUsingIslands;
        AssetManager.disasters.add(CyberDisaster);


           DisasterAsset IceWalkerDisaster = new DisasterAsset
        {
            id = "IceWalkerDisaster",
            rate = 1,
            chance = 0.2f,
            min_world_population = 1000,
            min_world_cities = 4,
            world_log = "worldlog_disaster_ice_ones",
            world_log_icon = "Walker_TitanIcon",
            spawn_asset_unit = "Cocytuswalker",
            max_existing_units = 1,
            units_min = 1,
            units_max = 1,
            type = DisasterType.Other,
            premium_only = false
        };
        IceWalkerDisaster.ages_allow.Add(S.age_ice);
        IceWalkerDisaster.ages_allow.Add(S.age_despair);
 		IceWalkerDisaster.action = simpleUnitAssetSpawnUsingIslands;
        AssetManager.disasters.add(IceWalkerDisaster);


           Spell spawnassimilatorzeppelin = new Spell
		{
			id = "spawnassimilatorzeppelin",
			chance = 3f,
			min_distance = 0f,
			castTarget = CastTarget.Himself, };
		spawnassimilatorzeppelin.action = castspawnassimilatorzeppelin;
		 AssetManager.spells.add(spawnassimilatorzeppelin);

  var Assimilatus = AssetManager.actor_library.clone("Assimilatus", "_mob");
       Assimilatus.nameLocale = "Assimilatus";
       Assimilatus.nameTemplate = "assimilator_name";
       Assimilatus.race = "assimilators";
       Assimilatus.kingdom = "assimilators";
       Assimilatus.animation_walk = "walk_0,walk_1,walk_2,walk_3";
       Assimilatus.animation_idle = "walk_0";
       Assimilatus.texture_path = "Assimilatus";
	   Assimilatus.sound_hit = "event:/SFX/HIT/HitMetal";
		Assimilatus.fmod_spawn = "event:/SFX/UNITS/Assimilator/AssimilatorSpawn";
		Assimilatus.fmod_attack = "event:/SFX/UNITS/Assimilator/AssimilatorAttack";
		Assimilatus.fmod_idle = "event:/SFX/UNITS/Assimilator/AssimilatorIdle";
		Assimilatus.fmod_death = "event:/SFX/UNITS/Assimilator/AssimilatorDeath";
       Assimilatus.immune_to_slowness = true;
       Assimilatus.attack_spells = List.Of<string>("cybercopter", "cybercopter" , "cybercopter");
       Assimilatus.hideOnMinimap = false;
       //Assimilatus.icon = "";
       Assimilatus.job = "attacker";
       Assimilatus.actorSize = ActorSize.S17_Dragon;
       Assimilatus.defaultAttack = "destroyerbot";
       Assimilatus.run_to_water_when_on_fire = true;
       Assimilatus.disablePunchAttackAnimation = true;
       Assimilatus.base_stats[S.max_age] = 100;
       Assimilatus.base_stats[S.health] = 2000;
       Assimilatus.base_stats[S.speed] = 34f;
       Assimilatus.base_stats[S.damage] = 0f;
       Assimilatus.base_stats[S.armor] = 40f;
       Assimilatus.base_stats[S.area_of_effect] = 1;
       Assimilatus.base_stats[S.knockback] = 1;
       Assimilatus.base_stats[S.knockback_reduction] = 20f;
       Assimilatus.animal = true;
       Assimilatus.baby = false;
       Assimilatus.egg = false;
       Assimilatus.procreate = false;
       Assimilatus.layEggs = false;
       Assimilatus.eggStatsID = "";
       Assimilatus.years_to_grow_to_adult = 18;
       Assimilatus.growIntoID = "";
       Assimilatus.inspect_children = false;
       Assimilatus.procreate_age = 18;
       Assimilatus.animal_baby_making_around_limit = 3;
       Assimilatus.base_stats[S.max_children] = 5f;
       Assimilatus.canBeKilledByDivineLight = false;
       Assimilatus.canBeKilledByLifeEraser = true;
       Assimilatus.ignoredByInfinityCoin = false;
       Assimilatus.disableJumpAnimation = false;
       Assimilatus.canBeMovedByPowers = true;
       Assimilatus.canTurnIntoZombie = false;
       Assimilatus.canTurnIntoMush = false;
       Assimilatus.canTurnIntoTumorMonster = false;
       Assimilatus.canAttackBuildings = true;
       Assimilatus.hideFavoriteIcon = false;
       Assimilatus.can_edit_traits = true;
       Assimilatus.damagedByOcean = true;
       Assimilatus.water_damage_value = 60f;
       Assimilatus.swampCreature = false;
       Assimilatus.damagedByRain = true;
       Assimilatus.oceanCreature = false;
       Assimilatus.action_liquid = new WorldAction(ActionLibrary.swimToIsland);
       Assimilatus.landCreature = true;
       Assimilatus.dieOnGround = false;
       Assimilatus.take_items = false;
       Assimilatus.use_items = false;
       Assimilatus.body_separate_part_hands = false;
       Assimilatus.take_items_ignore_range_weapons = false;
       Assimilatus.has_skin = false;
       Assimilatus.immune_to_injuries = false;
       Assimilatus.maxHunger = 100;
       Assimilatus.needFood = false;
       Assimilatus.diet_meat = false;
       Assimilatus.diet_berries = false;
       Assimilatus.diet_crops = false;
       Assimilatus.diet_flowers = false;
       Assimilatus.diet_grass = false;
       Assimilatus.diet_vegetation = false;
       Assimilatus.diet_meat_insect = false;
       Assimilatus.diet_meat_same_race = false;
       Assimilatus.source_meat = false;
       Assimilatus.source_meat_insect = false;
       Assimilatus.has_soul = false;
       Assimilatus.dieInLava = true;
       Assimilatus.hovering = false;
       Assimilatus.flying = false;
       Assimilatus.very_high_flyer = false;
       Assimilatus.hovering_min = 5f;
       Assimilatus.hovering_max = 10f;
       Assimilatus.maxRandomAmount = 1;
        AssetManager.actor_library.add(Assimilatus);
        AssetManager.actor_library.CallMethod("loadShadow",Assimilatus);
      //  AssetManager.actor_library.CallMethod("addTrait", "AssimilatusBossTrait");
        AssetManager.actor_library.CallMethod("addTrait", "AssimilatorSpawner");
        AssetManager.actor_library.CallMethod("removeTrait", "weightless");
        AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
        AssetManager.actor_library.CallMethod("addTrait", "bubble_defense");
        AssetManager.actor_library.CallMethod("removeTrait", "ugly");
             AssetManager.actor_library.CallMethod("addTrait", "SolarPoweredCyberBody");
        Localization.addLocalization(Assimilatus.nameLocale,Assimilatus.nameLocale);

         Spell spawnicewalker = new Spell
		{
			id = "spawnicewalker",
			chance = 3f,
			min_distance = 0f,
			castTarget = CastTarget.Himself, };
		spawnicewalker.action = castspawnicewalker;
		 AssetManager.spells.add(spawnicewalker);

  var Cocytuswalker = AssetManager.actor_library.clone("Cocytuswalker", "_mob");
       Cocytuswalker.nameLocale = "Cocytuswalker";
       Cocytuswalker.nameTemplate = "cold_one_name";
       Cocytuswalker.race = "walkers";
       Cocytuswalker.kingdom = "walkers";
       Cocytuswalker.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
       Cocytuswalker.animation_idle = "walk_0";
       Cocytuswalker.texture_path = "Cocytuswalker";
		Cocytuswalker.fmod_spawn = "event:/SFX/UNITS/ColdOne/ColdOneSpawn";
		Cocytuswalker.fmod_attack = "event:/SFX/UNITS/ColdOne/ColdOneAttack";
		Cocytuswalker.fmod_idle = "event:/SFX/UNITS/ColdOne/ColdOneIdle";
		Cocytuswalker.fmod_death = "event:/SFX/UNITS/ColdOne/ColdOneDeath";
		Cocytuswalker.fmod_theme = "Units_ColdOne";
		Cocytuswalker.sound_hit = "event:/SFX/HIT/HitGeneric";
       Cocytuswalker.immune_to_slowness = true;
       Cocytuswalker.attack_spells = List.Of<string>("spawnicewalker", "spawnicewalker" , "spawnicewalker");
       Cocytuswalker.hideOnMinimap = false;
       //Cocytuswalker.icon = "";
       Cocytuswalker.job = "attacker";
       Cocytuswalker.actorSize = ActorSize.S17_Dragon;
       Cocytuswalker.defaultAttack = "snowthrow";
       Cocytuswalker.run_to_water_when_on_fire = true;
       Cocytuswalker.disablePunchAttackAnimation = true;
       Cocytuswalker.base_stats[S.max_age] = 100;
       Cocytuswalker.base_stats[S.health] = 2000;
       Cocytuswalker.base_stats[S.speed] = 34f;
       Cocytuswalker.base_stats[S.attack_speed] = 200f;
       Cocytuswalker.base_stats[S.damage] = 50;
       Cocytuswalker.base_stats[S.armor] = 10f;
       Cocytuswalker.base_stats[S.area_of_effect] = 1;
       Cocytuswalker.base_stats[S.knockback] = 1;
       Cocytuswalker.base_stats[S.knockback_reduction] = 20f;
       Cocytuswalker.base_stats[S.targets] = 10f;
       Cocytuswalker.animal = true;
       Cocytuswalker.baby = false;
       Cocytuswalker.egg = false;
       Cocytuswalker.procreate = false;
       Cocytuswalker.layEggs = false;
       Cocytuswalker.eggStatsID = "";
       Cocytuswalker.years_to_grow_to_adult = 18;
       Cocytuswalker.growIntoID = "";
       Cocytuswalker.inspect_children = false;
       Cocytuswalker.procreate_age = 18;
       Cocytuswalker.animal_baby_making_around_limit = 3;
       Cocytuswalker.base_stats[S.max_children] = 5f;
       Cocytuswalker.canBeKilledByDivineLight = false;
       Cocytuswalker.canBeKilledByLifeEraser = true;
       Cocytuswalker.ignoredByInfinityCoin = false;
       Cocytuswalker.disableJumpAnimation = true;
       Cocytuswalker.canBeMovedByPowers = true;
       Cocytuswalker.canTurnIntoZombie = false;
       Cocytuswalker.canTurnIntoMush = false;
       Cocytuswalker.canTurnIntoTumorMonster = false;
       Cocytuswalker.canAttackBuildings = true;
       Cocytuswalker.hideFavoriteIcon = false;
       Cocytuswalker.can_edit_traits = true;
       Cocytuswalker.damagedByOcean = false;
       Cocytuswalker.swampCreature = false;
       Cocytuswalker.damagedByRain = false;
       Cocytuswalker.oceanCreature = false;
       Cocytuswalker.action_liquid = new WorldAction(ActionLibrary.swimToIsland);
       Cocytuswalker.landCreature = true;
       Cocytuswalker.dieOnGround = false;
       Cocytuswalker.take_items = false;
       Cocytuswalker.use_items = false;
       Cocytuswalker.body_separate_part_hands = false;
       Cocytuswalker.take_items_ignore_range_weapons = false;
       Cocytuswalker.has_skin = true;
       Cocytuswalker.immune_to_injuries = false;
       Cocytuswalker.maxHunger = 100;
       Cocytuswalker.needFood = false;
       Cocytuswalker.diet_meat = false;
       Cocytuswalker.diet_berries = false;
       Cocytuswalker.diet_crops = false;
       Cocytuswalker.diet_flowers = false;
       Cocytuswalker.diet_grass = false;
       Cocytuswalker.diet_vegetation = false;
       Cocytuswalker.diet_meat_insect = false;
       Cocytuswalker.diet_meat_same_race = false;
       Cocytuswalker.source_meat = false;
       Cocytuswalker.source_meat_insect = false;
       Cocytuswalker.has_soul = false;
       Cocytuswalker.dieInLava = true;
       Cocytuswalker.hovering = false;
       Cocytuswalker.flying = false;
       Cocytuswalker.very_high_flyer = false;
       Cocytuswalker.hovering_min = 5f;
       Cocytuswalker.hovering_max = 10f;
       Cocytuswalker.maxRandomAmount = 1;
        AssetManager.actor_library.add(Cocytuswalker);
        AssetManager.actor_library.CallMethod("loadShadow",Cocytuswalker);
        AssetManager.actor_library.CallMethod("addTrait", "Walker_Titan");
        AssetManager.actor_library.CallMethod("addTrait", "IceTowerSpawner");
        AssetManager.actor_library.CallMethod("addTrait", "regeneration");
        AssetManager.actor_library.CallMethod("addTrait", "weightless");
        AssetManager.actor_library.CallMethod("addTrait", "freeze_proof");
        AssetManager.actor_library.CallMethod("addTrait", "cold_aura");
        AssetManager.actor_library.CallMethod("addTrait", "Freezer");
        Localization.addLocalization(Cocytuswalker.nameLocale,Cocytuswalker.nameLocale);

         var icedracoid = AssetManager.actor_library.clone("icedracoid", "walker");
                  icedracoid.id = "icedracoid";
                  icedracoid.texture_path = "icedracoid";
                  icedracoid.body_separate_part_head = false;
                  icedracoid.animation_idle = "walk_0,walk_1,walk_2,walk_3";
                  icedracoid.actorSize = ActorSize.S16_Buffalo;
                  icedracoid.defaultAttack = "icebolt";
        icedracoid.base_stats[S.health] = 30;
        icedracoid.base_stats[S.armor] = 0;
        icedracoid.base_stats[S.speed] = 50f;
		icedracoid.base_stats[S.attack_speed] = 80f;
		icedracoid.base_stats[S.damage] = 10f;
		icedracoid.base_stats[S.knockback] = 0f;
		icedracoid.base_stats[S.targets] = 1f;
		icedracoid.fmod_spawn = "event:/SFX/UNITS/ColdOne/ColdOneSpawn";
		icedracoid.fmod_attack = "event:/SFX/UNITS/ColdOne/ColdOneAttack";
		icedracoid.fmod_idle = "event:/SFX/UNITS/ColdOne/ColdOneIdle";
		icedracoid.fmod_death = "event:/SFX/UNITS/ColdOne/ColdOneDeath";
		icedracoid.fmod_theme = "Units_ColdOne";
		icedracoid.sound_hit = "event:/SFX/HIT/HitGeneric";
        icedracoid.flying = true;
       icedracoid.very_high_flyer = true;
       icedracoid.hovering_min = 10f;
       icedracoid.hovering_max = 10f;
         icedracoid.moveFromBlock = true;
		    icedracoid.dieOnBlocks = false;
                  AssetManager.actor_library.add(icedracoid);
                  AssetManager.actor_library.CallMethod("addTrait", "IceTowerSpawner");
                  AssetManager.actor_library.CallMethod("loadShadow", icedracoid);
                  Localization.addLocalization(icedracoid.nameLocale,icedracoid.nameLocale);

                      var buffrost = AssetManager.actor_library.clone("buffrost", "walker");
                  buffrost.id = "buffrost";
                  buffrost.texture_path = "buffrost";
                  buffrost.body_separate_part_head = false;
                  buffrost.actorSize = ActorSize.S16_Buffalo;
        buffrost.base_stats[S.health] = 100;
        buffrost.base_stats[S.armor] = 15;
        buffrost.base_stats[S.speed] = 20f;
		buffrost.base_stats[S.attack_speed] = 5f;
		buffrost.base_stats[S.damage] = 20f;
		buffrost.base_stats[S.knockback] = 2f;
		buffrost.base_stats[S.targets] = 4f;
		buffrost.fmod_spawn = "event:/SFX/UNITS/ColdOne/ColdOneSpawn";
		buffrost.fmod_attack = "event:/SFX/UNITS/ColdOne/ColdOneAttack";
		buffrost.fmod_idle = "event:/SFX/UNITS/ColdOne/ColdOneIdle";
		buffrost.fmod_death = "event:/SFX/UNITS/ColdOne/ColdOneDeath";
		buffrost.fmod_theme = "Units_ColdOne";
		buffrost.sound_hit = "event:/SFX/HIT/HitGeneric";
                  AssetManager.actor_library.add(buffrost);
                  AssetManager.actor_library.CallMethod("addTrait", "Freezer");
                  AssetManager.actor_library.CallMethod("loadShadow", buffrost);
                  Localization.addLocalization(buffrost.nameLocale,buffrost.nameLocale);

              var normalwalker = AssetManager.actor_library.clone("normalwalker", "walker");
                  normalwalker.id = "normalwalker";
        normalwalker.texture_path = "t_walker";
		normalwalker.texture_heads = "t_walker_heads";
        normalwalker.base_stats[S.damage] = 15f;
		normalwalker.animation_walk = "walk_0,walk_1,walk_2,walk_3";
		normalwalker.animation_swim = "swim_0,swim_1,swim_2,swim_3";
		normalwalker.fmod_spawn = "event:/SFX/UNITS/ColdOne/ColdOneSpawn";
		normalwalker.fmod_attack = "event:/SFX/UNITS/ColdOne/ColdOneAttack";
		normalwalker.fmod_idle = "event:/SFX/UNITS/ColdOne/ColdOneIdle";
		normalwalker.fmod_death = "event:/SFX/UNITS/ColdOne/ColdOneDeath";
		normalwalker.fmod_theme = "Units_ColdOne";
		normalwalker.sound_hit = "event:/SFX/HIT/HitGeneric";
                  AssetManager.actor_library.add(normalwalker);
                  AssetManager.actor_library.CallMethod("loadShadow", normalwalker);
                  Localization.addLocalization(normalwalker.nameLocale,normalwalker.nameLocale);


    var helilator = AssetManager.actor_library.clone("helilator", "tumor_monster_animal");
        helilator.id = "helilator";
        helilator.texture_path = "helilator";
         helilator.nameTemplate = "assimilator_name";
                  helilator.canTurnIntoMush = false;
                  helilator.inspectAvatarScale = 2.1f;
                  helilator.race = SK.assimilators;
		          helilator.kingdom = SK.assimilators;
        helilator.body_separate_part_head = false;
        helilator.disablePunchAttackAnimation = true;
        helilator.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
        helilator.animation_idle = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
        helilator.actorSize = ActorSize.S16_Buffalo;
        helilator.defaultAttack = "machinegunery";
        helilator.base_stats[S.health] = 30;
        helilator.base_stats[S.armor] = 0;
        helilator.base_stats[S.damage] = 0f;
        helilator.base_stats[S.attack_speed] = 0f;
        helilator.base_stats[S.speed] = 10f;
		helilator.damagedByOcean = true;
		helilator.water_damage_value = 60f;
		helilator.damagedByRain = true;
		helilator.sound_hit = "event:/SFX/HIT/HitMetal";
		helilator.fmod_spawn = "event:/SFX/UNITS/Assimilator/AssimilatorSpawn";
		helilator.fmod_attack = "event:/SFX/UNITS/Assimilator/AssimilatorAttack";
		helilator.fmod_idle = "event:/SFX/UNITS/Assimilator/AssimilatorIdle";
		helilator.fmod_death = "event:/SFX/UNITS/Assimilator/AssimilatorDeath";
        helilator.flying = true;
       helilator.very_high_flyer = true;
       helilator.hovering_min = 2f;
       helilator.hovering_max = 2f;
       helilator.take_items = false;
       helilator.use_items = false;
         helilator.moveFromBlock = true;
		    helilator.dieOnBlocks = false;
                  AssetManager.actor_library.add(helilator);
                  AssetManager.actor_library.CallMethod("addTrait", "AssimilatorSpawner");
                  AssetManager.actor_library.CallMethod("addTrait", "Potential");
                  AssetManager.actor_library.CallMethod("addTrait", "SolarPoweredCyberBody");
                  AssetManager.actor_library.CallMethod("loadShadow", helilator);
                  Localization.addLocalization(helilator.nameLocale,helilator.nameLocale);


              var assimilarptor = AssetManager.actor_library.clone("assimilarptor", "tumor_monster_animal");
                  assimilarptor.id = "assimilarptor";
        assimilarptor.texture_path = "assimilarptor";
         assimilarptor.nameTemplate = "assimilator_name";
                  assimilarptor.canTurnIntoMush = false;
                  assimilarptor.inspectAvatarScale = 2.1f;
                  assimilarptor.race = SK.assimilators;
		          assimilarptor.kingdom = SK.assimilators;
		assimilarptor.animation_walk = "walk_0,walk_1,walk_2";
		assimilarptor.animation_swim = "swim_0,swim_1,swim_2";
        assimilarptor.disableJumpAnimation = false;
        assimilarptor.disablePunchAttackAnimation = false;
        assimilarptor.base_stats[S.speed] = 80f;
		assimilarptor.base_stats[S.attack_speed] = 200f;
        assimilarptor.base_stats[S.damage] = 13f;
        assimilarptor.defaultAttack = "claws";
        assimilarptor.damagedByOcean = true;
		assimilarptor.water_damage_value = 60f;
		assimilarptor.damagedByRain = true;
		 assimilarptor.take_items = false;
       assimilarptor.use_items = false;
		assimilarptor.sound_hit = "event:/SFX/HIT/HitMetal";
		assimilarptor.fmod_spawn = "event:/SFX/UNITS/Assimilator/AssimilatorSpawn";
		assimilarptor.fmod_attack = "event:/SFX/UNITS/Assimilator/AssimilatorAttack";
		assimilarptor.fmod_idle = "event:/SFX/UNITS/Assimilator/AssimilatorIdle";
		assimilarptor.fmod_death = "event:/SFX/UNITS/Assimilator/AssimilatorDeath";
                  AssetManager.actor_library.add(assimilarptor);
                  AssetManager.actor_library.CallMethod("loadShadow", assimilarptor);
                    AssetManager.actor_library.CallMethod("addTrait", "Potential");
                         AssetManager.actor_library.CallMethod("addTrait", "SolarPoweredCyberBody");
                  Localization.addLocalization(assimilarptor.nameLocale,assimilarptor.nameLocale);

                     var assimilatrax = AssetManager.actor_library.clone("assimilatrax", "tumor_monster_animal");
                  assimilatrax.id = "assimilatrax";
                  assimilatrax.texture_path = "assimilatrax";
                    assimilatrax.nameTemplate = "assimilator_name";
                  assimilatrax.canTurnIntoMush = false;
                  assimilatrax.inspectAvatarScale = 2.1f;
                  assimilatrax.race = SK.assimilators;
		          assimilatrax.kingdom = SK.assimilators;
                  assimilatrax.defaultAttack = "artillerystriker";
                 assimilatrax.animation_walk = "walk_0,walk_1,walk_2,walk_3";
		          assimilatrax.animation_swim = "swim_0,swim_1,swim_2";
                  assimilatrax.animation_idle = "idle_0";
                  assimilatrax.body_separate_part_head = false;
                  assimilatrax.actorSize = ActorSize.S16_Buffalo;
                     assimilatrax.disablePunchAttackAnimation = true;
        assimilatrax.base_stats[S.health] = 130;
        assimilatrax.base_stats[S.armor] = 50;
        assimilatrax.base_stats[S.speed] = 30f;
        assimilatrax.base_stats[S.damage] = 0f;
		assimilatrax.base_stats[S.attack_speed] = 0f;
		assimilatrax.base_stats[S.knockback] = 2f;
		assimilatrax.base_stats[S.targets] = 4f;
        assimilatrax.damagedByOcean = true;
		assimilatrax.water_damage_value = 60f;
		assimilatrax.damagedByRain = true;
        assimilatrax.take_items = false;
        assimilatrax.use_items = false;
		assimilatrax.sound_hit = "event:/SFX/HIT/HitMetal";
		assimilatrax.fmod_spawn = "event:/SFX/UNITS/Assimilator/AssimilatorSpawn";
	    assimilatrax.fmod_attack = "event:/SFX/UNITS/Assimilator/AssimilatorAttack";
		assimilatrax.fmod_idle = "event:/SFX/UNITS/Assimilator/AssimilatorIdle";
		assimilatrax.fmod_death = "event:/SFX/UNITS/Assimilator/AssimilatorDeath";
                  AssetManager.actor_library.add(assimilatrax);
                  AssetManager.actor_library.CallMethod("addTrait", "AssimilatorSpawner");
                       AssetManager.actor_library.CallMethod("addTrait", "SolarPoweredCyberBody");
                  AssetManager.actor_library.CallMethod("loadShadow", assimilatrax);
                  Localization.addLocalization(assimilatrax.nameLocale,assimilatrax.nameLocale);

                          Spell cybercopter = new Spell
		{
			id = "cybercopter",
			chance = 3f,
			min_distance = 0f,
			castTarget = CastTarget.Himself, };
		cybercopter.action = castcybercopter;
		 AssetManager.spells.add(cybercopter);


                      var assizeppelin = AssetManager.actor_library.clone("assizeppelin", "tumor_monster_animal");
        assizeppelin.id = "assizeppelin";
        assizeppelin.texture_path = "assizeppelin";
        assizeppelin.body_separate_part_head = false;
        assizeppelin.disablePunchAttackAnimation = true;
         assizeppelin.nameTemplate = "assimilator_name";
                  assizeppelin.canTurnIntoMush = false;
                  assizeppelin.inspectAvatarScale = 2.1f;
                  assizeppelin.race = SK.assimilators;
		          assizeppelin.kingdom = SK.assimilators;
        assizeppelin.animation_idle = "idle_0,idle_1,idle_2";
        assizeppelin.actorSize = ActorSize.S16_Buffalo;
        assizeppelin.defaultAttack = "bomberino";
        assizeppelin.base_stats[S.scale] = 0.15f;
        assizeppelin.base_stats[S.size] = 2f;
        assizeppelin.base_stats[S.health] = 300;
        assizeppelin.base_stats[S.damage] = 0f;
        assizeppelin.base_stats[S.attack_speed] = 0.0001f;
        assizeppelin.base_stats[S.speed] = 10f;
		assizeppelin.damagedByOcean = true;
		assizeppelin.water_damage_value = 60f;
		assizeppelin.damagedByRain = true;
		assizeppelin.sound_hit = "event:/SFX/HIT/HitMetal";
		assizeppelin.fmod_spawn = "event:/SFX/UNITS/Assimilator/AssimilatorSpawn";
		assizeppelin.fmod_attack = "event:/SFX/UNITS/Assimilator/AssimilatorAttack";
		assizeppelin.fmod_idle = "event:/SFX/UNITS/Assimilator/AssimilatorIdle";
		assizeppelin.fmod_death = "event:/SFX/UNITS/Assimilator/AssimilatorDeath";
        assizeppelin.flying = true;
       assizeppelin.very_high_flyer = true;
       assizeppelin.hovering_min = 5f;
       assizeppelin.hovering_max = 5f;
              assizeppelin.take_items = false;
       assizeppelin.use_items = false;
         assizeppelin.moveFromBlock = true;
             assizeppelin.immune_to_slowness = true;
		    assizeppelin.dieOnBlocks = false;
           // assizeppelin.effect_cast_top = "fx_cast_top_blue";
		    // assizeppelin.effect_cast_ground = "fx_cast_ground_blue";
		        assizeppelin.action_liquid = new WorldAction(ActionLibrary.swimToIsland);
                  AssetManager.actor_library.add(assizeppelin);
                  AssetManager.actor_library.CallMethod("addTrait", "AssimilatorSpawner");
                  AssetManager.actor_library.CallMethod("addTrait", "fire_blood");
                     AssetManager.actor_library.CallMethod("addTrait", "bubble_defense");
                     AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
                        AssetManager.actor_library.CallMethod("addTrait", "weightless");
                       AssetManager.actor_library.CallMethod("addTrait", "SolarPoweredCyberBody");
                  AssetManager.actor_library.CallMethod("loadShadow", assizeppelin);
                  Localization.addLocalization(assizeppelin.nameLocale,assizeppelin.nameLocale);

                 	 ActorTrait Freezer = new ActorTrait();
		    Freezer.action_attack_target = new AttackAction(ActionLibrary.addFrozenEffectOnTarget);
			Freezer.id = "Freezer";
			Freezer.path_icon = "ui/Icons/FreezerIcon";
			Freezer.can_be_given = true;
			Freezer.unlocked_with_achievement = false;
			Freezer.group_id = TraitGroup.body;
			Freezer.inherit = 10f;
            AssetManager.traits.add(Freezer);
             addTraitToLocalizedLibrary(Freezer.id, "Let it gooo! Let it gooooo!");
          PlayerConfig.unlockTrait("Freezer");

  ActorTrait AssimilatorSpawner = new ActorTrait();
			AssimilatorSpawner.id = "AssimilatorSpawner";
			AssimilatorSpawner.path_icon = "ui/Icons/AssimilatorSpawner";
			AssimilatorSpawner.unlocked_with_achievement = true;
			AssimilatorSpawner.achievement_id = "achievementLetsNot";
			AssimilatorSpawner.group_id = TraitGroup.body;
			AssimilatorSpawner.inherit = 10f;
            AssimilatorSpawner.action_special_effect = (WorldAction)Delegate.Combine(AssimilatorSpawner.action_special_effect, new WorldAction(activeAssimilatorSpawnerEffect));
            AssetManager.traits.add(AssimilatorSpawner);
            addTraitToLocalizedLibrary(AssimilatorSpawner.id, "Spawns one of many Assimilator-related buildings");
            PlayerConfig.unlockTrait("AssimilatorSpawner");


			ActorTrait SolarPoweredCyberBody = new ActorTrait();
			SolarPoweredCyberBody.id = "SolarPoweredCyberBody";
			SolarPoweredCyberBody.path_icon = "ui/Icons/SolarPoweredCyberBody";
			SolarPoweredCyberBody.group_id = TraitGroup.body;
			SolarPoweredCyberBody.inherit = 10f;
         SolarPoweredCyberBody.action_special_effect = (WorldAction)Delegate.Combine(SolarPoweredCyberBody.action_special_effect, new WorldAction(SolarPoweredCyberBodyEffect));
         AssetManager.traits.add(SolarPoweredCyberBody);
            addTraitToLocalizedLibrary(SolarPoweredCyberBody.id, "Needs Sun for power, which makes it succeptible to changes on weather, told him to go nuclear but didn't want to listen, dumb terminators xD");
            PlayerConfig.unlockTrait("SolarPoweredCyberBody");


			ActorTrait frozenmachinary = new ActorTrait();
			frozenmachinary.id = "frozenmachinary";
			frozenmachinary.path_icon = "ui/Icons/frozenmachinary";
			frozenmachinary.group_id = TraitGroup.body;
			frozenmachinary.inherit = 10f;
			frozenmachinary.base_stats[S.speed] = -10f;
            frozenmachinary.action_special_effect = (WorldAction)Delegate.Combine(frozenmachinary.action_special_effect, new WorldAction(constantFrozenEffect));
            AssetManager.traits.add(frozenmachinary);
            addTraitToLocalizedLibrary(frozenmachinary.id, "Letting Go");
            PlayerConfig.unlockTrait("frozenmachinary");

			ActorTrait unpoweredmachinery = new ActorTrait();
			unpoweredmachinery.id = "unpoweredmachinery";
			unpoweredmachinery.path_icon = "ui/Icons/unpoweredmachinery";
			unpoweredmachinery.group_id = TraitGroup.body;
			unpoweredmachinery.inherit = 10f;
			unpoweredmachinery.base_stats[S.speed] = -100f;
			unpoweredmachinery.base_stats[S.range] = -20f;
		     unpoweredmachinery.base_stats[S.accuracy] = -100f;
            unpoweredmachinery.action_special_effect = (WorldAction)Delegate.Combine(unpoweredmachinery.action_special_effect, new WorldAction(randomWaitEffect));
            AssetManager.traits.add(unpoweredmachinery);
            addTraitToLocalizedLibrary(unpoweredmachinery.id, "Needs to recharge");
            PlayerConfig.unlockTrait("unpoweredmachinery");

	 ActorTrait Walker_Titan = new ActorTrait();
            Walker_Titan.id = "Walker_Titan";
            Walker_Titan.action_death = (WorldAction)Delegate.Combine(Walker_Titan.action_death, new WorldAction(walkercorpseEffect));
            Walker_Titan.path_icon = "ui/Icons/Walker_TitanIcon";
            AssetManager.traits.add(Walker_Titan);
			addTraitToLocalizedLibrary(Walker_Titan.id, "Great Embassador of the Ice Walker kind");
            PlayerConfig.unlockTrait("Walker_Titan");



                   ActorTrait IceTowerSpawner = new ActorTrait();
			IceTowerSpawner.id = "IceTowerSpawner";
			IceTowerSpawner.path_icon = "ui/Icons/IceTowerSpawner";
			IceTowerSpawner.unlocked_with_achievement = true;
			IceTowerSpawner.achievement_id = "achievementLetsNot";
			IceTowerSpawner.group_id = TraitGroup.body;
			IceTowerSpawner.inherit = 10f;
            IceTowerSpawner.action_special_effect = (WorldAction)Delegate.Combine(IceTowerSpawner.action_special_effect, new WorldAction(activeIceTowerSpawnerEffect));
            AssetManager.traits.add(IceTowerSpawner);
            addTraitToLocalizedLibrary(IceTowerSpawner.id, "Spawns one of many Walker-related buildings");
            PlayerConfig.unlockTrait("IceTowerSpawner");

			
          ActorTrait Potential = new ActorTrait();
            Potential.action_special_effect = (WorldAction)Delegate.Combine(Potential.action_special_effect, new WorldAction(PotentialEffect));
			Potential.id = "Potential";
			Potential.path_icon = "ui/Icons/PotentialIcon";
			Potential.unlocked_with_achievement = false;
			Potential.achievement_id = "achievementLetsNot";
            Potential.can_be_given = true;
			Potential.group_id = TraitGroup.body;
			Potential.inherit = 100f;
            AssetManager.traits.add(Potential);
           addTraitToLocalizedLibrary(Potential.id, "Potential to evolve into different things. Based on traits, level, kill count and other factors. Example, if your mother is very fat she will need to go to the ocean so gravity do not crushes her body, creating a whale. Also, if a human earns veteran trait while killing the starwars desert civ, it will evolve into a drone");
         PlayerConfig.unlockTrait("Potential");


			// var Terlanius = AssetManager.actor_library.clone("Terlanius","_mob");
           // // Terlanius.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			// Terlanius.race = "SK.nature";
			// Terlanius.kingdom = "SK.nature";
            // Terlanius.base_stats[S.health] = 200f;
            // Terlanius.base_stats[S.speed] = 100f;
            // Terlanius.base_stats[S.armor] = 100f;
            // Terlanius.base_stats[S.damage] = 40f;
          // //  Terlanius.base_stats[S.scale] = 0.25f;
            // Terlanius.base_stats[S.attack_speed] = 0;
			// Terlanius.base_stats[S.range] = 150f;
			// Terlanius.base_stats[S.knockback_reduction] = 300f;
            // Terlanius.drawBoatMark_big = true;
            // Terlanius.skipFightLogic = false;
            // Terlanius.inspect_stats = true;
			// Terlanius.landCreature = true;
			// Terlanius.inspect_home = true;
			// Terlanius.hideOnMinimap = false;
            // Terlanius.drawBoatMark = true;
			// Terlanius.can_edit_traits = false;
			// Terlanius.canReceiveTraits = false;
			// Terlanius.flying = false;
			// //Terlanius.tech = "Terlaniuss";
			// Terlanius.very_high_flyer = false;
		// //	Terlanius.defaultAttack = "RocketLauncher";
            // Terlanius.isBoat = false;
			// Terlanius.dieOnBlocks = true;
			// Terlanius.ignoreBlocks = false;
			// //Terlanius.moveFromBlock = false;
			// Terlanius.procreate = false;
		    // Terlanius.inspect_children = false;
            // Terlanius.inspect_experience = true;
			// Terlanius.canBeCitizen = true;
            // Terlanius.inspect_kills = true;
            // Terlanius.use_items = false;
			// Terlanius.oceanCreature = false;
            // Terlanius.take_items = false;
            // Terlanius.nameLocale = "Terlanius";
            // //Terlanius.nameTemplate = "Jet_Names";
			// Terlanius.job = "attacker";
            // Terlanius.icon = "iconTerlanius";
		// //	AssetManager.actor_library.CallMethod("addTrait", "Vehicle");
		// //	AssetManager.actor_library.CallMethod("addTrait", "Terlanius");
			// AssetManager.actor_library.CallMethod("loadShadow", Terlanius);
          // //  Terlanius.animation_walk = "walk_0,walk_1,walk_2,walk_3";
       // //     Terlanius.animation_swim = "walk_0,walk_1,walk_2,walk_3";
            // Terlanius.animation_idle = "idle_0";
            // Terlanius.animation_walk = "walk_0";
            // Terlanius.animation_swim = "walk_0";
            // Terlanius.texture_path = "Terlanius";
            // AssetManager.actor_library.add(Terlanius);
			// Localization.addLocalization(Terlanius.nameLocale, Terlanius.nameLocale);

		  
            var Terlanius = AssetManager.actor_library.clone("Creatures.Terlanius", "_mob");
            Terlanius.nameLocale = "Terlanius";
            Terlanius.nameTemplate = "Terlanius";
            Terlanius.job = "skeleton_job";
            Terlanius.race = "TerlaniusKingdom";
            Terlanius.kingdom = "TerlaniusKingdom";
            //Terlanius.icon = "Screenshot 2024-08-09 194001";
            Terlanius.animation_swim = "swim_0";
            Terlanius.animation_walk = "walk_0";
            Terlanius.texture_path = "Terlanius";
            Terlanius.run_to_water_when_on_fire = true;
            Terlanius.canBeKilledByStuff = true;
            Terlanius.canBeKilledByLifeEraser = true;
            Terlanius.canAttackBuildings = true;
            Terlanius.canBeMovedByPowers = true;
            Terlanius.canBeHurtByPowers = true;
            Terlanius.canTurnIntoZombie = false;
            Terlanius.canBeInspected = true;
            Terlanius.hideOnMinimap = false;
            Terlanius.use_items = false;
            Terlanius.take_items = false;
            Terlanius.needFood = false;
            Terlanius.diet_meat = false;
            Terlanius.inspect_home = false;
            Terlanius.disableJumpAnimation = true;
            Terlanius.has_soul = true;
            Terlanius.swampCreature = false;
            Terlanius.oceanCreature = false;
            Terlanius.landCreature = false;
            Terlanius.can_turn_into_demon_in_age_of_chaos = true;
            Terlanius.canTurnIntoIceOne = true;
            Terlanius.canTurnIntoTumorMonster = true;
            Terlanius.canTurnIntoMush = false;
            Terlanius.dieInLava = true;
            Terlanius.dieOnBlocks = false;
            Terlanius.dieOnGround = false;
            Terlanius.dieByLightning = true;
            Terlanius.damagedByOcean = true;
            Terlanius.damagedByRain = true;
            Terlanius.flying = true;
            Terlanius.very_high_flyer = false;
            Terlanius.hideFavoriteIcon = false;
            Terlanius.can_edit_traits = true;
            Terlanius.canBeKilledByDivineLight = true;
            Terlanius.ignoredByInfinityCoin = false;
            Terlanius.actorSize = ActorSize.S15_Bear;
            Terlanius.action_liquid = new WorldAction(ActionLibrary.swimToIsland);
            Terlanius.base_stats[S.max_age] = 1000f;
            Terlanius.base_stats[S.health] = 750;
            Terlanius.base_stats[S.damage] = 1000;
            Terlanius.base_stats[S.speed] = 15f;
            Terlanius.base_stats[S.armor] = 150;
            Terlanius.base_stats[S.attack_speed] = 1;
            Terlanius.base_stats[S.critical_chance] = 0.1f;
            Terlanius.base_stats[S.knockback] = 0.1f;
            Terlanius.base_stats[S.knockback_reduction] = 0.1f;
            Terlanius.base_stats[S.accuracy] = 1f;
            Terlanius.base_stats[S.range] = 15;
            Terlanius.base_stats[S.targets] = 1f;
            Terlanius.base_stats[S.dodge] = 1f;
            AssetManager.actor_library.add(Terlanius);
            AssetManager.actor_library.CallMethod("loadShadow", Terlanius);
            AssetManager.actor_library.CallMethod("addTrait", "immortal");
            Localization.addLocalization(Terlanius.nameLocale, Terlanius.nameLocale);




            BiomeAsset tartarus = new BiomeAsset();
            tartarus.id = "biome_tartarus";
			tartarus.tile_low = "tartarus_low";
			tartarus.tile_high = "tartarus_high";
			tartarus.force_unit_skin_set = "desert";
			tartarus.grow_strength = 20;
			tartarus.spread_biome = true;
			tartarus.generator_pool_amount = 0;
            tartarus.grow_vegetation_auto = true;
			tartarus.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			tartarus.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			tartarus.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
			tartarus.addTree("tartarus_desert_bones_big", 1);
			tartarus.addTree("tartarus_tar_bones_big", 1);
			tartarus.addTree("tartarus_vent", 1);
            tartarus.addPlant("tartarus_desert_bones", 2);
            tartarus.addPlant("tartarus_tar_bones", 1);
			tartarus.addPlant("tartarus_ruins", 1);
            tartarus.addUnit("scandid", 4);
            tartarus.addUnit("Duneworm", 1);
			tartarus.addMineral(SB.mineral_bones, 20);
			tartarus.addMineral(SB.mineral_stone, 20);
			tartarus.addMineral(SB.mineral_metals, 5);
            AssetManager.biome_library.add(tartarus);
            AssetManager.biome_library.addBiomeToPool(tartarus);

            TopTileType tartarus_low = AssetManager.topTiles.clone("tartarus_low", ST.infernal_low);
            tartarus_low.color = Toolbox.makeColor("#272727", -1f);
            tartarus_low.setBiome("biome_tartarus");
			tartarus_low.rank_type = TileRank.Low;
            tartarus_low.setDrawLayer(TileZIndexes.infernal_low, null);
            tartarus_low.food_resource = SR.desert_berries;
            tartarus_low.liquid = true;
            tartarus_low.ground = false;
            tartarus_low.ocean = true;
		    tartarus_low.stepActionChance = 1f;
            tartarus_low.hold_lava = false;
            tartarus_low.can_be_frozen = true;
            tartarus_low.burnable = false;
            tartarus_low.walkMod = 1f;
            tartarus_low.layerType = TileLayerType.Ground;
			tartarus_low.biome_asset = tartarus;
            AssetManager.topTiles.add(tartarus_low);
            AssetManager.topTiles.loadSpritesForTile(tartarus_low);
            AssetManager.topTiles.add(AssetManager.topTiles.get("tartarus_low"));
            MapBox.instance.tilemap.layers[tartarus_low.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

            TopTileType tartarus_high = AssetManager.topTiles.clone("tartarus_high", ST.infernal_high);
            tartarus_high.color = Toolbox.makeColor("#d57d4f", -1f);
            tartarus_high.setBiome("biome_tartarus");
			tartarus_high.rank_type = TileRank.High;
            tartarus_high.setDrawLayer(TileZIndexes.infernal_high);
            tartarus_high.stepActionChance = 1f;
            tartarus_high.food_resource = SR.desert_berries;
            tartarus_high.liquid = false;
            tartarus_high.hold_lava = false;
            tartarus_high.can_be_frozen = true;
            tartarus_high.burnable = false;
            tartarus_high.layerType = TileLayerType.Ground;
			tartarus_high.biome_asset = tartarus;
            AssetManager.topTiles.add(tartarus_high);
            AssetManager.topTiles.loadSpritesForTile(tartarus_high);
            AssetManager.topTiles.add(AssetManager.topTiles.get("tartarus_high"));
            MapBox.instance.tilemap.layers[tartarus_high.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;


        AssetManager.job_actor.add(new ActorJob{id = "dune_critter"});
         AssetManager.job_actor.t.addTask("random_swim");
         AssetManager.job_actor.t.addTask("crab_danger_check");
		 AssetManager.job_actor.t.addTask("follow_same_race");
		 AssetManager.job_actor.t.addTask("swim_to_island");
         AssetManager.job_actor.t.addTask("crab_danger_check");
		 AssetManager.job_actor.t.addTask("random_move");
         AssetManager.job_actor.t.addTask("check_hunger_animal");
         AssetManager.job_actor.t.addTask("water_feeding");
         AssetManager.job_actor.t.addTask("crab_danger_check");
         AssetManager.job_actor.t.addTask("wait10");

         var dunemonster = new KingdomAsset();
            dunemonster.id = "dunemonster";
            dunemonster.count_as_danger = true;
            dunemonster.mobs = true;
            dunemonster.attack_each_other = false;
            dunemonster.enemies_check_full = true;
            dunemonster.addTag("dunemonster");
            dunemonster.addFriendlyTag("dunemonster");
		    dunemonster.addEnemyTag(SK.civ);
            dunemonster.default_kingdom_color = new ColorAsset("#BACADD", "#BACADD", "#BACADD");
            AssetManager.kingdoms.add(dunemonster);
            World.world.kingdoms.CallMethod("newHiddenKingdom", dunemonster);

               var scandid = AssetManager.actor_library.clone("scandid", "crocodile");
                  scandid.id = "scandid";
                  scandid.texture_path = "scandid";
                  scandid.maxRandomAmount = 4;
                  scandid.base_stats[S.health] = 200f;
		              	scandid.base_stats[S.speed] = 30f;
                          scandid.base_stats[S.damage] = 15f;
                      scandid.animation_idle = "idle_0,idle_1,idle_2";
                  scandid.animation_swim = "swim_0,swim_1,swim_2";
                  scandid.animation_walk = "walk_0,walk_1,walk_2";
                  scandid.job = "dune_critter";
   scandid.fmod_spawn = "event:/SFX/UNITS/Crab/CrabSpawn";
		scandid.fmod_attack = "event:/SFX/UNITS/Crab/CrabAttack";
		scandid.fmod_idle = "event:/SFX/UNITS/Crab/CrabIdle";
		scandid.fmod_death = "event:/SFX/UNITS/Crab/CrabDeath";
		       scandid.has_skin = true;
		           scandid.useSkinColors = false;
                  AssetManager.actor_library.CallMethod("addTrait", "venomous");
                  AssetManager.actor_library.add(scandid);
                  AssetManager.actor_library.CallMethod("loadShadow", scandid);

                     var Duneworm = AssetManager.actor_library.clone("Duneworm", "crocodile");
                  Duneworm.id = "Duneworm";
                  Duneworm.texture_path = "Duneworm";
                    Duneworm.race = "dunemonster";
                    Duneworm.disablePunchAttackAnimation = true;
                  Duneworm.kingdom = "dunemonster";
                  Duneworm.base_stats[S.health] = 600f;
                      Duneworm.maxRandomAmount = 2;
		              	Duneworm.base_stats[S.speed] = 65f;
                          Duneworm.base_stats[S.damage] = 43f;
                      Duneworm.animation_idle = "idle_0,idle_1,idle_2,idle_3,idle_4,idle_5,idle_6,idle_7,idle_8,idle_9";
             Duneworm.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7,swim_8,swim_9";
                  Duneworm.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5,walk_6,walk_7,walk_8,walk_9";
                  Duneworm.job = "dune_critter";
   Duneworm.fmod_spawn = "event:/SFX/UNITS/Crab/CrabSpawn";
		Duneworm.fmod_attack = "event:/SFX/UNITS/Crab/CrabAttack";
		Duneworm.fmod_idle = "event:/SFX/UNITS/Crab/CrabIdle";
		Duneworm.fmod_death = "event:/SFX/UNITS/Crab/CrabDeath";
		                  Duneworm.useSkinColors = false;
		       Duneworm.has_skin = true;
                  AssetManager.actor_library.CallMethod("addTrait", "giant");
                  AssetManager.actor_library.add(Duneworm);
                  AssetManager.actor_library.CallMethod("loadShadow", Duneworm);

            BiomeAsset Glitch = new BiomeAsset();
            Glitch.id = "biome_Glitch";
			Glitch.tile_low = "Glitch_low";
			Glitch.tile_high = "Glitch_high";
			Glitch.force_unit_skin_set = "infernal";
			Glitch.grow_strength = 20;
			Glitch.spread_biome = true;
			Glitch.generator_pool_amount = 0;
            Glitch.grow_vegetation_auto = true;
			Glitch.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			Glitch.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			Glitch.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
			Glitch.addTree("Glitch_tree", 2);
			Glitch.addPlant("Glitch_plant", 4);
			Glitch.addTree("Glitch_tree_big", 1);
            Glitch.addTree("Glitch_candle", 2);
			Glitch.addPlant("Glitch_tomb", 4);
            Glitch.addUnit("glitchspectre", 2);
            Glitch.addUnit("glitchdrake", 1);
            Glitch.addUnit("glitchtarantula", 2);
			Glitch.addMineral(SB.mineral_bones, 20);
			Glitch.addMineral(SB.mineral_adamantine, 20);
            AssetManager.biome_library.add(Glitch);
            AssetManager.biome_library.addBiomeToPool(Glitch);

            TopTileType Glitch_low = AssetManager.topTiles.clone("Glitch_low", ST.infernal_low);
            Glitch_low.color = Toolbox.makeColor("#898672", -1f);
            Glitch_low.setBiome("biome_Glitch");
			Glitch_low.rank_type = TileRank.Low;
            Glitch_low.setDrawLayer(TileZIndexes.infernal_low, null);
            Glitch_low.food_resource = SR.evil_beets;
            Glitch_low.liquid = false;
            Glitch_low.ground = true;
            Glitch_low.unitDeathAction = new WorldAction(spawnGlitchCreature);
		    Glitch_low.stepActionChance = 1f;
            Glitch_low.hold_lava = false;
            Glitch_low.can_be_frozen = true;
            Glitch_low.burnable = false;
            Glitch_low.walkMod = 1f;
            Glitch_low.layerType = TileLayerType.Ground;
			Glitch_low.biome_asset = Glitch;
            AssetManager.topTiles.add(Glitch_low);
            AssetManager.topTiles.loadSpritesForTile(Glitch_low);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Glitch_low"));
            MapBox.instance.tilemap.layers[Glitch_low.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

            TopTileType Glitch_high = AssetManager.topTiles.clone("Glitch_high", ST.infernal_high);
            Glitch_high.color = Toolbox.makeColor("#343434", -1f);
            Glitch_high.setBiome("biome_Glitch");
			Glitch_high.rank_type = TileRank.High;
            Glitch_high.setDrawLayer(TileZIndexes.infernal_high);
            Glitch_high.unitDeathAction = new WorldAction(spawnGlitchCreature);
            Glitch_high.stepActionChance = 1f;
            Glitch_high.food_resource = SR.evil_beets;
            Glitch_high.liquid = false;
            Glitch_high.hold_lava = false;
            Glitch_high.can_be_frozen = true;
            Glitch_high.burnable = false;
            Glitch_high.layerType = TileLayerType.Ground;
			Glitch_high.biome_asset = Glitch;
            AssetManager.topTiles.add(Glitch_high);
            AssetManager.topTiles.loadSpritesForTile(Glitch_high);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Glitch_high"));
            MapBox.instance.tilemap.layers[Glitch_high.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;
			










            BiomeAsset IcePlanet = new BiomeAsset();
            IcePlanet.id = "biome_IcePlanet";
			      IcePlanet.tile_low = "permafrost_low";
			      IcePlanet.tile_high = "permafrost_high";
			      IcePlanet.grow_strength = 10;
			      IcePlanet.spread_biome = true;
			      IcePlanet.generator_pool_amount = 0;
            IcePlanet.grow_vegetation_auto = true;
			      IcePlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      IcePlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        IcePlanet.addUnit(SA.frog, 1);
		        IcePlanet.addUnit(SA.sheep, 1);
				  IcePlanet.addTree("Ruins1", 30);
		        IcePlanet.addMineral(SB.mineral_stone, 5);
		        IcePlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(IcePlanet);
            AssetManager.biome_library.addBiomeToPool(IcePlanet);

            BiomeAsset IcePlanet1 = new BiomeAsset();
            IcePlanet1.id = "biome_IcePlanet1";
			      IcePlanet1.tile_low = "frozen_low";
			      IcePlanet1.tile_high = "frozen_high";
			      IcePlanet1.grow_strength = 10;
			      IcePlanet1.spread_biome = true;
			      IcePlanet1.generator_pool_amount = 0;
            IcePlanet1.grow_vegetation_auto = true;
			      IcePlanet1.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      IcePlanet1.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        IcePlanet1.addUnit(SA.frog, 1);
		        IcePlanet1.addUnit(SA.sheep, 1);
		        IcePlanet1.addMineral(SB.mineral_stone, 5);
				  IcePlanet1.addTree("Ruins1", 30);
		        IcePlanet1.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(IcePlanet1);
            AssetManager.biome_library.addBiomeToPool(IcePlanet1);

                  BiomeAsset RobotPlanet = new BiomeAsset();
            RobotPlanet.id = "biome_RobotPlanet";
			      RobotPlanet.tile_low = "cybertile_low";
			      RobotPlanet.tile_high = "cybertile_high";
			      RobotPlanet.grow_strength = 10;
			      RobotPlanet.spread_biome = true;
			      RobotPlanet.generator_pool_amount = 0;
            RobotPlanet.grow_vegetation_auto = true;
			      RobotPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      RobotPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      RobotPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        RobotPlanet.addUnit(SA.frog, 1);
		        RobotPlanet.addUnit(SA.sheep, 1);
		        RobotPlanet.addMineral(SB.mineral_stone, 5);
		        RobotPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(RobotPlanet);
            AssetManager.biome_library.addBiomeToPool(RobotPlanet);



                BiomeAsset LavaPlanet = new BiomeAsset();
            LavaPlanet.id = "biome_LavaPlanet";
			      LavaPlanet.tile_low = "infernal_low";
			      LavaPlanet.tile_high = "infernal_high";
			      LavaPlanet.grow_strength = 10;
			      LavaPlanet.spread_biome = true;
			      LavaPlanet.generator_pool_amount = 0;
            LavaPlanet.grow_vegetation_auto = true;
			      LavaPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      LavaPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      LavaPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        LavaPlanet.addUnit(Creatures.Terlanius, 8);
		        LavaPlanet.addMineral(SB.mineral_stone, 5);
				  LavaPlanet.addTree("Ruins1", 30);
		        LavaPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(LavaPlanet);
            AssetManager.biome_library.addBiomeToPool(LavaPlanet);

               BiomeAsset CorruptedPlanet = new BiomeAsset();
            CorruptedPlanet.id = "biome_CorruptedPlanet";
			      CorruptedPlanet.tile_low = "corruption_low";
			      CorruptedPlanet.tile_high = "corruption_high";
			      CorruptedPlanet.grow_strength = 10;
			      CorruptedPlanet.spread_biome = true;
			      CorruptedPlanet.generator_pool_amount = 0;
            CorruptedPlanet.grow_vegetation_auto = true;
			      CorruptedPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      CorruptedPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      CorruptedPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        CorruptedPlanet.addMineral(SB.mineral_stone, 5);
		        CorruptedPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(CorruptedPlanet);
           // AssetManager.biome_library.addBiomeToPool(CorruptedPlanet);




			BiomeAsset Chess = new BiomeAsset();
            Chess.id = "biome_Chess";
			Chess.tile_low = "Chess_low";
			Chess.tile_high = "Chess_high";
			Chess.force_unit_skin_set = "infernal";
			Chess.grow_strength = 20;
			Chess.spread_biome = true;
			Chess.generator_pool_amount = 0;
            Chess.grow_vegetation_auto = true;
			Chess.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			Chess.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			Chess.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
			Chess.addTree("Chess_tree", 20);
			Chess.addTree("Chess_tree_2", 20);
			Chess.addTree("Chess_tree_3", 20);
			/*
			Chess.addTree("Chess_tree", 2);
			Chess.addPlant("Chess_plant", 4);
			Chess.addTree("Chess_tree_big", 1);
            Chess.addTree("Chess_candle", 2);
			Chess.addPlant("Chess_tomb", 4);
            Chess.addUnit("glitchspectre", 2);
            Chess.addUnit("glitchdrake", 1);
            Chess.addUnit("glitchtarantula", 2);
			Chess.addMineral(SB.mineral_bones, 20);
			Chess.addMineral(SB.mineral_adamantine, 20);
            AssetManager.biome_library.add(Chess);
			*/
            AssetManager.biome_library.addBiomeToPool(Chess);

            TopTileType Chess_low = AssetManager.topTiles.clone("Chess_low", ST.infernal_low);
            Chess_low.color = Toolbox.makeColor("#898672", -1f);
            Chess_low.setBiome("biome_Chess");
			Chess_low.rank_type = TileRank.Low;
            Chess_low.setDrawLayer(TileZIndexes.infernal_low, null);
            Chess_low.food_resource = SR.evil_beets;
            Chess_low.liquid = false;
            Chess_low.ground = true;
          //  Chess_low.unitDeathAction = new WorldAction(spawnChessCreature);
		    Chess_low.stepActionChance = 1f;
            Chess_low.hold_lava = false;
            Chess_low.can_be_frozen = true;
            Chess_low.burnable = false;
            Chess_low.walkMod = 1f;
            Chess_low.layerType = TileLayerType.Ground;
			Chess_low.biome_asset = Chess;
            AssetManager.topTiles.add(Chess_low);
            AssetManager.topTiles.loadSpritesForTile(Chess_low);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Chess_low"));
            MapBox.instance.tilemap.layers[Chess_low.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

            TopTileType Chess_high = AssetManager.topTiles.clone("Chess_high", ST.infernal_high);
            Chess_high.color = Toolbox.makeColor("#808080", -1f);
            Chess_high.setBiome("biome_Chess");
			Chess_high.rank_type = TileRank.High;
            Chess_high.setDrawLayer(TileZIndexes.infernal_high);
           // Chess_high.unitDeathAction = new WorldAction(spawnChessCreature);
            Chess_high.stepActionChance = 1f;
            Chess_high.food_resource = SR.evil_beets;
            Chess_high.liquid = false;
            Chess_high.hold_lava = false;
            Chess_high.can_be_frozen = true;
            Chess_high.burnable = false;
            Chess_high.layerType = TileLayerType.Ground;
			Chess_high.biome_asset = Chess;
            AssetManager.topTiles.add(Chess_high);
            AssetManager.topTiles.loadSpritesForTile(Chess_high);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Chess_high"));
            MapBox.instance.tilemap.layers[Chess_high.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;


            BiomeAsset LemonPlanet = new BiomeAsset();
            LemonPlanet.id = "biome_LemonPlanet";
			      LemonPlanet.tile_low = "lemon_low";
			      LemonPlanet.tile_high = "lemon_high";
			      LemonPlanet.grow_strength = 10;
			      LemonPlanet.spread_biome = true;
			      LemonPlanet.generator_pool_amount = 0;
            LemonPlanet.grow_vegetation_auto = true;
			      LemonPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      LemonPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      LemonPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        LemonPlanet.addUnit(Creatures.Terlanius, 1);
		        LemonPlanet.addMineral(SB.mineral_stone, 5);
		        LemonPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(LemonPlanet);
            AssetManager.biome_library.addBiomeToPool(LemonPlanet);

             BiomeAsset MushroomPlanet = new BiomeAsset();
            MushroomPlanet.id = "biome_MushroomPlanet";
			      MushroomPlanet.tile_low = "mushroom_low";
			      MushroomPlanet.tile_high = "mushroom_high";
			      MushroomPlanet.grow_strength = 10;
			      MushroomPlanet.spread_biome = true;
			      MushroomPlanet.generator_pool_amount = 0;
            MushroomPlanet.grow_vegetation_auto = true;
			      MushroomPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      MushroomPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      MushroomPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        MushroomPlanet.addUnit(Creatures.Terlanius, 1);
		        MushroomPlanet.addMineral(SB.mineral_stone, 5);
		        MushroomPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(MushroomPlanet);
            AssetManager.biome_library.addBiomeToPool(MushroomPlanet);


            BiomeAsset WastelandPlanet = new BiomeAsset();
            WastelandPlanet.id = "biome_WastelandPlanet";
			      WastelandPlanet.tile_low = "wasteland_low";
			      WastelandPlanet.tile_high = "wasteland_high";
			      WastelandPlanet.grow_strength = 10;
			      WastelandPlanet.spread_biome = true;
			      WastelandPlanet.generator_pool_amount = 0;
            WastelandPlanet.grow_vegetation_auto = true;
			      WastelandPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      WastelandPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      WastelandPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        WastelandPlanet.addUnit(Creatures.Terlanius, 1);
		        WastelandPlanet.addMineral(SB.mineral_stone, 5);
		        WastelandPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(WastelandPlanet);
            AssetManager.biome_library.addBiomeToPool(WastelandPlanet);

              BiomeAsset CrystalPlanet = new BiomeAsset();
            CrystalPlanet.id = "biome_CrystalPlanet";
			      CrystalPlanet.tile_low = "crystal_low";
			      CrystalPlanet.tile_high = "crystal_high";
			      CrystalPlanet.grow_strength = 10;
			      CrystalPlanet.spread_biome = true;
			      CrystalPlanet.generator_pool_amount = 0;
            CrystalPlanet.grow_vegetation_auto = true;
			      CrystalPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      CrystalPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      CrystalPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        CrystalPlanet.addUnit(SA.frog, 1);
		        CrystalPlanet.addUnit(SA.sheep, 1);
		        CrystalPlanet.addMineral(SB.mineral_stone, 5);
		        CrystalPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(CrystalPlanet);
            AssetManager.biome_library.addBiomeToPool(CrystalPlanet);


            BiomeAsset SwampPlanet = new BiomeAsset();
            SwampPlanet.id = "biome_SwampPlanet";
			      SwampPlanet.tile_low = "swamp_low";
			      SwampPlanet.tile_high = "swamp_high";
			      SwampPlanet.grow_strength = 10;
			      SwampPlanet.spread_biome = true;
			      SwampPlanet.generator_pool_amount = 0;
            SwampPlanet.grow_vegetation_auto = true;
			      SwampPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      SwampPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      SwampPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        SwampPlanet.addUnit(SA.frog, 1);
		        SwampPlanet.addUnit(SA.sheep, 1);
		        SwampPlanet.addMineral(SB.mineral_stone, 5);
		        SwampPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(SwampPlanet);
            AssetManager.biome_library.addBiomeToPool(SwampPlanet);

               BiomeAsset Jungle1Planet = new BiomeAsset();
            Jungle1Planet.id = "biome_Jungle1Planet";
			      Jungle1Planet.tile_low = "jungle_low";
			      Jungle1Planet.tile_high = "jungle_high";
			      Jungle1Planet.grow_strength = 10;
			      Jungle1Planet.spread_biome = true;
			      Jungle1Planet.generator_pool_amount = 20;
            Jungle1Planet.grow_vegetation_auto = true;
			      Jungle1Planet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Jungle1Planet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Jungle1Planet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Jungle1Planet.addUnit(SA.frog, 1);
		        Jungle1Planet.addUnit(SA.sheep, 1);
		        Jungle1Planet.addUnit(Creatures.Terlanius, 1);
		        Jungle1Planet.addMineral(SB.mineral_stone, 5);
		        Jungle1Planet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(Jungle1Planet);
            AssetManager.biome_library.addBiomeToPool(Jungle1Planet);

                  BiomeAsset Jungle2Planet = new BiomeAsset();
            Jungle2Planet.id = "biome_Jungle2Planet";
			      Jungle2Planet.tile_low = "enchanted_low";
			      Jungle2Planet.tile_high = "enchanted_high";
			      Jungle2Planet.grow_strength = 10;
			      Jungle2Planet.spread_biome = true;
			      Jungle2Planet.generator_pool_amount = 0;
            Jungle2Planet.grow_vegetation_auto = true;
			      Jungle2Planet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Jungle2Planet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Jungle2Planet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Jungle2Planet.addUnit(SA.frog, 1);
		        Jungle2Planet.addUnit(SA.sheep, 1);
		        Jungle2Planet.addUnit(Creatures.Terlanius, 1);
		        Jungle2Planet.addMineral(SB.mineral_stone, 5);
		        Jungle2Planet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(Jungle2Planet);
            AssetManager.biome_library.addBiomeToPool(Jungle2Planet);

            BiomeAsset Jungle3Planet = new BiomeAsset();
            Jungle3Planet.id = "biome_Jungle3Planet";
			      Jungle3Planet.tile_low = "swamp_low";
			      Jungle3Planet.tile_high = "swamp_high";
			      Jungle3Planet.grow_strength = 10;
			      Jungle3Planet.spread_biome = true;
			      Jungle3Planet.generator_pool_amount = 0;
            Jungle3Planet.grow_vegetation_auto = true;
			      Jungle3Planet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Jungle3Planet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Jungle3Planet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Jungle3Planet.addUnit(SA.frog, 1);
		        Jungle3Planet.addUnit(SA.sheep, 1);
		        Jungle3Planet.addUnit(Creatures.Terlanius, 1);
		        Jungle3Planet.addMineral(SB.mineral_stone, 5);
		        Jungle3Planet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(Jungle3Planet);
            AssetManager.biome_library.addBiomeToPool(Jungle3Planet);


            BiomeAsset GasGiant = new BiomeAsset();
            GasGiant.id = "biome_GasGiant";
			      GasGiant.tile_low = "GasGiant_low";
			      GasGiant.tile_high = "GasGiant_high";
			      GasGiant.grow_strength = 10;
			      GasGiant.spread_biome = true;
			      GasGiant.generator_pool_amount = 0;
            GasGiant.grow_vegetation_auto = true;
			      GasGiant.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      GasGiant.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      GasGiant.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        GasGiant.addUnit(SA.frog, 1);
		        GasGiant.addUnit(SA.sheep, 1);
		        GasGiant.addMineral(SB.mineral_stone, 5);
		        GasGiant.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(GasGiant);
            AssetManager.biome_library.addBiomeToPool(GasGiant);

            TopTileType GasGiant_low = AssetManager.topTiles.clone("GasGiant_low", ST.mushroom_low);
            GasGiant_low.color = Toolbox.makeColor("#3b3aad", -1f);
            GasGiant_low.setBiome("biome_GasGiant");
		        GasGiant_low.force_unit_skin_set = "enchanted";
			      GasGiant_low.rank_type = TileRank.Low;
            GasGiant_low.setDrawLayer(TileZIndexes.mushroom_low, null);

            GasGiant_low.stepActionChance = 1437f;
            GasGiant_low.fireChance = 0.02f;
            GasGiant_low.food_resource = SR.mushrooms;
				    GasGiant_low.biome_asset = GasGiant;
            AssetManager.topTiles.add(GasGiant_low);
            AssetManager.topTiles.loadSpritesForTile(GasGiant_low);
            TopTileType GasGiant_high = AssetManager.topTiles.clone("GasGiant_high", ST.mushroom_high);
            GasGiant_high.color = Toolbox.makeColor("#000c8d", -1f);
            GasGiant_high.setBiome("biome_GasGiant");
			      GasGiant_high.rank_type = TileRank.High;
		        GasGiant_high.force_unit_skin_set = "enchanted";
            GasGiant_high.setDrawLayer(TileZIndexes.mushroom_high, null);

            GasGiant_high.stepActionChance = 1437f;
            GasGiant_high.fireChance = 0.02f;
            GasGiant_high.food_resource = SR.mushrooms;
				    GasGiant_high.biome_asset = GasGiant;
            AssetManager.topTiles.add(GasGiant_high);
            AssetManager.topTiles.loadSpritesForTile(GasGiant_high);

                BiomeAsset Space = new BiomeAsset();
            Space.id = "biome_Space";
			      Space.tile_low = "Space_low";
			      Space.tile_high = "Space_high";
			      Space.grow_strength = 10;
			      Space.spread_biome = true;
			      Space.generator_pool_amount = 0;
			      Space.force_unit_skin_set = "mushroom";
            Space.grow_vegetation_auto = true;
			      Space.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Space.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Space.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Space.addUnit(SA.frog, 1);
		        Space.addUnit(SA.sheep, 1);
		        Space.addMineral(SB.mineral_stone, 5);
		        Space.addMineral(SB.mineral_metals, 3);
		        Space.addTree("Space_tree", 1);
		        Space.addPlant("Space", 1);
            AssetManager.biome_library.add(Space);
            AssetManager.biome_library.addBiomeToPool(Space);

            TopTileType Space_low = AssetManager.topTiles.clone("Space_low", ST.mushroom_low);
            Space_low.color = Toolbox.makeColor("#3b3aad", -1f);
            Space_low.setBiome("biome_Space");
		        Space_low.force_unit_skin_set = "enchanted";
			      Space_low.rank_type = TileRank.Low;
            Space_low.setDrawLayer(TileZIndexes.mushroom_low, null);

            Space_low.stepActionChance = 1437f;
            Space_low.fireChance = 0.02f;
            Space_low.food_resource = SR.mushrooms;
				    Space_low.biome_asset = Space;
            AssetManager.topTiles.add(Space_low);
            AssetManager.topTiles.loadSpritesForTile(Space_low);
            TopTileType Space_high = AssetManager.topTiles.clone("Space_high", ST.mushroom_high);
            Space_high.color = Toolbox.makeColor("#000c8d", -1f);
            Space_high.setBiome("biome_Space");
			      Space_high.rank_type = TileRank.High;
		        Space_high.force_unit_skin_set = "enchanted";
            Space_high.setDrawLayer(TileZIndexes.mushroom_high, null);

            Space_high.stepActionChance = 1437f;
            Space_high.fireChance = 0.02f;
            Space_high.food_resource = SR.mushrooms;
				    Space_high.biome_asset = Space;
            AssetManager.topTiles.add(Space_high);
            AssetManager.topTiles.loadSpritesForTile(Space_high);


  BuildingAsset pileofcorpses = AssetManager.buildings.clone("pileofcorpses", "!building");
            pileofcorpses.affected_by_drought = true;
		    pileofcorpses.burnable = true;
            pileofcorpses.base_stats[S.health] = 1000f;
		    pileofcorpses.fundament = new BuildingFundament(1, 0, 1, 0);
            pileofcorpses.spawnUnits = true;
		    pileofcorpses.spawnUnits_asset = "zombie";
            pileofcorpses.has_ruins_graphics = false;
		    pileofcorpses.race = "undead";
            pileofcorpses.kingdom = "undead";
            pileofcorpses.checkForCloseBuilding = false;
		    pileofcorpses.canBeLivingHouse = false;
            pileofcorpses.canBePlacedOnLiquid = false;
            pileofcorpses.ignoreBuildings = true;
            pileofcorpses.canBeHarvested = false;
            pileofcorpses.setShadow(0.5f, 0.03f, 0.12f);
            pileofcorpses.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    pileofcorpses.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.add(pileofcorpses);
            AssetManager.buildings.loadSprites(pileofcorpses);

             ActorTrait zombie_spawner = new ActorTrait();
            zombie_spawner.id = "zombie_spawner";
            zombie_spawner.action_death = (WorldAction)Delegate.Combine(zombie_spawner.action_death, new WorldAction(pileofcorpsesEffect));
             zombie_spawner.action_special_effect = (WorldAction)Delegate.Combine(zombie_spawner.action_special_effect, new WorldAction(activeCorpseSpawnerEffect));
            zombie_spawner.path_icon = "ui/Icons/iconInfected";
            AssetManager.traits.add(zombie_spawner);
			addTraitToLocalizedLibrary(zombie_spawner.id, "[REDACTED]");
            PlayerConfig.unlockTrait("zombie_spawner");


        AssetManager.job_actor.add(new ActorJob{id = "ZombieWorse"});
		 AssetManager.job_actor.t.addTask("follow_same_race");
		 AssetManager.job_actor.t.addTask("swim_to_island");
		 AssetManager.job_actor.t.addTask("random_move");
         AssetManager.job_actor.t.addTask("wait10");

           var zombie = AssetManager.actor_library.get("zombie");
zombie.take_items = true;
        zombie.use_items = true;
          zombie.base_stats[S.health] = 200;
       zombie.base_stats[S.damage] = 30;
       zombie.job = "ZombieWorse";

            var zombiespeed = AssetManager.actor_library.clone("zombiespeed", "zombie");
		zombiespeed.nameLocale = "Zombie";
		zombiespeed.race = SK.undead;
		zombiespeed.kingdom = SK.undead;
		zombiespeed.texture_path = "zombiespeed";
        zombiespeed.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiespeed.animation_idle = "walk_0";
        zombiespeed.color = Toolbox.makeColor("#24803E");
        zombiespeed.base_stats[S.max_age] = 130;
       zombiespeed.base_stats[S.health] = 200;
       zombiespeed.base_stats[S.damage] = 30;
       zombiespeed.base_stats[S.armor] = 0f;
       zombiespeed.base_stats[S.speed] = 100f;
       	zombiespeed.base_stats[S.attack_speed] = 310f;
       zombiespeed.base_stats[S.area_of_effect] = 1;
       zombiespeed.base_stats[S.knockback] = 1;
       zombiespeed.base_stats[S.knockback_reduction] = 1f;
       zombiespeed.actorSize = ActorSize.S13_Human;
       zombiespeed.canBeKilledByDivineLight = true;
        zombiespeed.take_items = true;
        zombiespeed.use_items = true;
        zombiespeed.body_separate_part_head = false;
        zombiespeed.take_items_ignore_range_weapons = false;
		zombiespeed.defaultWeapons.Clear();
		zombiespeed.defaultWeaponsMaterial.Clear();
        zombiespeed.canAttackBuildings = true;
        zombiespeed.canAttackBrains = true;
        zombiespeed.diet_meat = false;
        zombiespeed.oceanCreature = false;
        zombiespeed.landCreature = true;
        zombiespeed.canTurnIntoMush = false;
        zombiespeed.canTurnIntoZombie = false;
        zombiespeed.needFood = false;
        zombiespeed.zombieID = "";
        zombiespeed.job = "ZombieWorse";
        zombiespeed.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiespeed.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiespeed.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiespeed.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiespeed.fmod_theme = "Units_Zombie";
        zombiespeed.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiespeed);
        AssetManager.actor_library.CallMethod("loadShadow",zombiespeed);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "fast");
        Localization.addLocalization(zombiespeed.nameLocale,zombiespeed.nameLocale);


var zombiespikes = AssetManager.actor_library.clone("zombiespikes", "zombie");
		zombiespikes.nameLocale = "Zombie";
		zombiespikes.race = SK.undead;
		zombiespikes.kingdom = SK.undead;
		zombiespikes.texture_path = "zombiespikes";
        zombiespikes.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiespikes.animation_idle = "walk_0";
        zombiespikes.color = Toolbox.makeColor("#24803E");
        zombiespikes.base_stats[S.max_age] = 130;
       zombiespikes.base_stats[S.health] = 350;
       zombiespikes.base_stats[S.damage] = 50;
       zombiespikes.base_stats[S.armor] = 15f;
       zombiespikes.base_stats[S.speed] = 50f;
       	zombiespikes.base_stats[S.attack_speed] = 110f;
       zombiespikes.base_stats[S.area_of_effect] = 1;
       zombiespikes.base_stats[S.knockback] = 0;
       zombiespikes.base_stats[S.knockback_reduction] = 1f;
       zombiespikes.actorSize = ActorSize.S13_Human;
       zombiespikes.canBeKilledByDivineLight = true;
        zombiespikes.take_items = true;
        zombiespikes.use_items = true;
        zombiespikes.body_separate_part_head = false;
        zombiespikes.take_items_ignore_range_weapons = false;
		zombiespikes.defaultWeapons.Clear();
		zombiespikes.defaultWeaponsMaterial.Clear();
        zombiespikes.canAttackBuildings = true;
        zombiespikes.canAttackBrains = true;
        zombiespikes.diet_meat = false;
        zombiespikes.oceanCreature = false;
        zombiespikes.landCreature = true;
        zombiespikes.canTurnIntoMush = false;
        zombiespikes.canTurnIntoZombie = false;
        zombiespikes.needFood = false;
        zombiespikes.zombieID = "";
        zombiespikes.job = "ZombieWorse";
        zombiespikes.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiespikes.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiespikes.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiespikes.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiespikes.fmod_theme = "Units_Zombie";
        zombiespikes.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiespikes);
        AssetManager.actor_library.CallMethod("loadShadow",zombiespikes);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "thorns");
        Localization.addLocalization(zombiespikes.nameLocale,zombiespikes.nameLocale);

        var zombiepoison = AssetManager.actor_library.clone("zombiepoison", "zombie");
		zombiepoison.nameLocale = "Zombie";
		zombiepoison.race = SK.undead;
		zombiepoison.kingdom = SK.undead;
		zombiepoison.texture_path = "zombiepoison";
        zombiepoison.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiepoison.animation_idle = "walk_0";
        zombiepoison.color = Toolbox.makeColor("#24803E");
        zombiepoison.base_stats[S.max_age] = 130;
       zombiepoison.base_stats[S.health] = 350;
       zombiepoison.base_stats[S.damage] = 54;
       zombiepoison.base_stats[S.armor] = 0f;
       zombiepoison.base_stats[S.speed] = 50f;
       	zombiepoison.base_stats[S.attack_speed] = 510f;
       zombiepoison.base_stats[S.area_of_effect] = 1;
       zombiepoison.base_stats[S.knockback] = 0;
       zombiepoison.base_stats[S.knockback_reduction] = 1f;
       zombiepoison.actorSize = ActorSize.S13_Human;
       zombiepoison.canBeKilledByDivineLight = true;
        zombiepoison.take_items = true;
        zombiepoison.use_items = true;
        zombiepoison.body_separate_part_head = false;
        zombiepoison.take_items_ignore_range_weapons = false;
		zombiepoison.defaultWeapons.Clear();
		zombiepoison.defaultWeaponsMaterial.Clear();
        zombiepoison.canAttackBuildings = true;
        zombiepoison.canAttackBrains = true;
        zombiepoison.diet_meat = false;
        zombiepoison.oceanCreature = false;
        zombiepoison.landCreature = true;
        zombiepoison.canTurnIntoMush = false;
        zombiepoison.canTurnIntoZombie = false;
        zombiepoison.needFood = false;
        zombiepoison.zombieID = "";
        zombiepoison.job = "ZombieWorse";
        zombiepoison.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiepoison.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiepoison.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiepoison.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiepoison.fmod_theme = "Units_Zombie";
        zombiepoison.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiepoison);
        AssetManager.actor_library.CallMethod("loadShadow",zombiepoison);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "venomous");
        AssetManager.actor_library.CallMethod("addTrait", "poisonous");
        AssetManager.actor_library.CallMethod("addTrait", "poison_immune");
        Localization.addLocalization(zombiepoison.nameLocale,zombiepoison.nameLocale);

        var zombieacid = AssetManager.actor_library.clone("zombieacid", "zombie");
		zombieacid.nameLocale = "Zombie";
		zombieacid.race = SK.undead;
		zombieacid.kingdom = SK.undead;
		zombieacid.texture_path = "zombieacid";
        zombieacid.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombieacid.animation_idle = "walk_0";
        zombieacid.color = Toolbox.makeColor("#24803E");
        zombieacid.base_stats[S.max_age] = 130;
       zombieacid.base_stats[S.health] = 350;
       zombieacid.base_stats[S.damage] = 64;
       zombieacid.base_stats[S.armor] = 0f;
       zombieacid.base_stats[S.speed] = 60f;
       	zombieacid.base_stats[S.attack_speed] = 210f;
       zombieacid.base_stats[S.area_of_effect] = 1;
       zombieacid.base_stats[S.knockback] = 1;
       zombieacid.base_stats[S.knockback_reduction] = 1f;
       zombieacid.actorSize = ActorSize.S16_Buffalo;
       zombieacid.canBeKilledByDivineLight = true;
        zombieacid.take_items = true;
        zombieacid.use_items = true;
        zombieacid.body_separate_part_head = false;
        zombieacid.take_items_ignore_range_weapons = false;
		zombieacid.defaultWeapons.Clear();
		zombieacid.defaultWeaponsMaterial.Clear();
        zombieacid.canAttackBuildings = true;
        zombieacid.canAttackBrains = true;
        zombieacid.diet_meat = false;
        zombieacid.oceanCreature = false;
        zombieacid.landCreature = true;
        zombieacid.canTurnIntoMush = false;
        zombieacid.canTurnIntoZombie = false;
        zombieacid.needFood = false;
        zombieacid.zombieID = "";
        zombieacid.job = "ZombieWorse";
        zombieacid.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombieacid.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombieacid.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombieacid.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombieacid.fmod_theme = "Units_Zombie";
        zombieacid.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombieacid);
        AssetManager.actor_library.CallMethod("loadShadow",zombieacid);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "acid_touch");
        AssetManager.actor_library.CallMethod("addTrait", "acid_blood");
        AssetManager.actor_library.CallMethod("addTrait", "acid_proof");
        Localization.addLocalization(zombieacid.nameLocale,zombieacid.nameLocale);

        var zombietentacle = AssetManager.actor_library.clone("zombietentacle", "zombie");
		zombietentacle.nameLocale = "Zombie";
		zombietentacle.race = SK.undead;
		zombietentacle.kingdom = SK.undead;
		zombietentacle.texture_path = "zombietentacle";
        zombietentacle.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombietentacle.animation_idle = "walk_0";
        zombietentacle.color = Toolbox.makeColor("#24803E");
        zombietentacle.base_stats[S.max_age] = 130;
       zombietentacle.base_stats[S.health] = 400;
       zombietentacle.base_stats[S.damage] = 33;
       zombietentacle.base_stats[S.armor] = 0f;
      zombietentacle.base_stats[S.dodge] = 6f;
       zombietentacle.base_stats[S.speed] = 70f;
       	zombietentacle.base_stats[S.attack_speed] = 2110f;
       zombietentacle.base_stats[S.area_of_effect] = 1;
       zombietentacle.base_stats[S.knockback] = 1;
       zombietentacle.base_stats[S.knockback_reduction] = 1f;
       zombietentacle.actorSize = ActorSize.S13_Human;
       zombietentacle.canBeKilledByDivineLight = true;
        zombietentacle.take_items = true;
        zombietentacle.use_items = true;
        zombietentacle.body_separate_part_head = false;
        zombietentacle.take_items_ignore_range_weapons = false;
		zombietentacle.defaultWeapons.Clear();
		zombietentacle.defaultWeaponsMaterial.Clear();
        zombietentacle.canAttackBuildings = true;
        zombietentacle.canAttackBrains = true;
        zombietentacle.diet_meat = false;
        zombietentacle.oceanCreature = false;
        zombietentacle.landCreature = true;
        zombietentacle.canTurnIntoMush = false;
        zombietentacle.canTurnIntoZombie = false;
        zombietentacle.needFood = false;
        zombietentacle.zombieID = "";
        zombietentacle.job = "ZombieWorse";
        zombietentacle.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombietentacle.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombietentacle.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombietentacle.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombietentacle.fmod_theme = "Units_Zombie";
        zombietentacle.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombietentacle);
        AssetManager.actor_library.CallMethod("loadShadow",zombietentacle);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "agile");
        Localization.addLocalization(zombietentacle.nameLocale,zombietentacle.nameLocale);

        var zombiestalker = AssetManager.actor_library.clone("zombiestalker", "zombie");
		zombiestalker.nameLocale = "Zombie";
		zombiestalker.race = SK.undead;
		zombiestalker.kingdom = SK.undead;
		zombiestalker.texture_path = "zombiestalker";
        zombiestalker.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiestalker.animation_idle = "walk_0";
        zombiestalker.color = Toolbox.makeColor("#24803E");
        zombiestalker.base_stats[S.max_age] = 130;
       zombiestalker.base_stats[S.health] = 1050;
       zombiestalker.base_stats[S.damage] = 104;
       zombiestalker.base_stats[S.armor] = 10f;
       zombiestalker.base_stats[S.speed] = 60f;
       	zombiestalker.base_stats[S.attack_speed] = 210f;
       zombiestalker.base_stats[S.area_of_effect] = 1;
       zombiestalker.base_stats[S.knockback] = 2;
       zombiestalker.base_stats[S.knockback_reduction] = 3f;
       zombiestalker.actorSize = ActorSize.S13_Human;
       zombiestalker.canBeKilledByDivineLight = true;
        zombiestalker.take_items = true;
        zombiestalker.use_items = true;
        zombiestalker.body_separate_part_head = false;
        zombiestalker.take_items_ignore_range_weapons = false;
		zombiestalker.defaultWeapons.Clear();
		zombiestalker.defaultWeaponsMaterial.Clear();
        zombiestalker.canAttackBuildings = true;
        zombiestalker.canAttackBrains = true;
        zombiestalker.diet_meat = false;
        zombiestalker.oceanCreature = false;
        zombiestalker.landCreature = true;
        zombiestalker.canTurnIntoMush = false;
        zombiestalker.canTurnIntoZombie = false;
        zombiestalker.needFood = false;
        zombiestalker.zombieID = "";
        zombiestalker.job = "ZombieWorse";
        zombiestalker.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiestalker.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiestalker.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiestalker.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiestalker.fmod_theme = "Units_Zombie";
        zombiestalker.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiestalker);
        AssetManager.actor_library.CallMethod("loadShadow",zombiestalker);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "giant");
                AssetManager.actor_library.CallMethod("addTrait", "zombie_spawner");
        Localization.addLocalization(zombiestalker.nameLocale,zombiestalker.nameLocale);

        	var zombiemother = AssetManager.actor_library.clone("zombiemother", "zombie");
		zombiemother.nameLocale = "Zombie";
		zombiemother.race = SK.undead;
		zombiemother.kingdom = SK.undead;
		zombiemother.texture_path = "zombiemother";
        zombiemother.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiemother.animation_idle = "walk_0";
        zombiemother.color = Toolbox.makeColor("#24803E");
        zombiemother.base_stats[S.max_age] = 130;
       zombiemother.base_stats[S.health] = 2000;
       zombiemother.base_stats[S.damage] = 204;
       zombiemother.base_stats[S.armor] = 0f;
       zombiemother.base_stats[S.speed] = 30f;
       	zombiemother.base_stats[S.attack_speed] = 150f;
       zombiemother.base_stats[S.area_of_effect] = 1;
       zombiemother.base_stats[S.knockback] = 8;
       zombiemother.base_stats[S.knockback_reduction] = 10f;
       zombiemother.actorSize = ActorSize.S17_Dragon;
       zombiemother.canBeKilledByDivineLight = true;
        zombiemother.take_items = true;
        zombiemother.use_items = true;
        zombiemother.body_separate_part_head = false;
        zombiemother.take_items_ignore_range_weapons = false;
		zombiemother.defaultWeapons.Clear();
		zombiemother.defaultWeaponsMaterial.Clear();
        zombiemother.canAttackBuildings = true;
        zombiemother.canAttackBrains = true;
        zombiemother.diet_meat = false;
        zombiemother.oceanCreature = false;
        zombiemother.landCreature = true;
        zombiemother.canTurnIntoMush = false;
        zombiemother.canTurnIntoZombie = false;
        zombiemother.needFood = false;
        zombiemother.zombieID = "";
        zombiemother.job = "ZombieWorse";
        zombiemother.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiemother.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiemother.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiemother.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiemother.fmod_theme = "Units_Zombie";
        zombiemother.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiemother);
        AssetManager.actor_library.CallMethod("loadShadow",zombiemother);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "fat");
        AssetManager.actor_library.CallMethod("addTrait", "giant");
        AssetManager.actor_library.CallMethod("addTrait", "acid_blood");
        AssetManager.actor_library.CallMethod("addTrait", "zombie_spawner");
        Localization.addLocalization(zombiemother.nameLocale,zombiemother.nameLocale);



var zombiefiremaniac = AssetManager.actor_library.clone("zombiefiremaniac", "zombie");
		zombiefiremaniac.nameLocale = "Zombie";
		zombiefiremaniac.race = SK.undead;
		zombiefiremaniac.kingdom = SK.undead;
		zombiefiremaniac.texture_path = "zombiefiremaniac";
        zombiefiremaniac.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiefiremaniac.animation_idle = "walk_0";
        zombiefiremaniac.color = Toolbox.makeColor("#24803E");
        zombiefiremaniac.base_stats[S.max_age] = 130;
       zombiefiremaniac.base_stats[S.health] = 450;
       zombiefiremaniac.base_stats[S.damage] = 70;
       zombiefiremaniac.base_stats[S.armor] = 0f;
       zombiefiremaniac.base_stats[S.speed] = 70f;
       	zombiefiremaniac.base_stats[S.attack_speed] = 110f;
       zombiefiremaniac.base_stats[S.area_of_effect] = 1;
       zombiefiremaniac.base_stats[S.knockback] = 1;
       zombiefiremaniac.base_stats[S.knockback_reduction] = 1f;
       zombiefiremaniac.defaultAttack = "fire_hands";
       zombiefiremaniac.actorSize = ActorSize.S13_Human;
       zombiefiremaniac.canBeKilledByDivineLight = true;
        zombiefiremaniac.take_items = true;
        zombiefiremaniac.use_items = true;
        zombiefiremaniac.body_separate_part_head = false;
        zombiefiremaniac.take_items_ignore_range_weapons = false;
		zombiefiremaniac.defaultWeapons.Clear();
		zombiefiremaniac.defaultWeaponsMaterial.Clear();
        zombiefiremaniac.canAttackBuildings = true;
        zombiefiremaniac.canAttackBrains = true;
        zombiefiremaniac.diet_meat = false;
        zombiefiremaniac.oceanCreature = false;
        zombiefiremaniac.landCreature = true;
        zombiefiremaniac.canTurnIntoMush = false;
        zombiefiremaniac.canTurnIntoZombie = false;
        zombiefiremaniac.needFood = false;
        zombiefiremaniac.zombieID = "";
        zombiefiremaniac.job = "ZombieWorse";
        zombiefiremaniac.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiefiremaniac.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiefiremaniac.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiefiremaniac.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiefiremaniac.fmod_theme = "Units_Zombie";
        zombiefiremaniac.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiefiremaniac);
        AssetManager.actor_library.CallMethod("loadShadow",zombiefiremaniac);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
        AssetManager.actor_library.CallMethod("addTrait", "pyromaniac");
        Localization.addLocalization(zombiefiremaniac.nameLocale,zombiefiremaniac.nameLocale);


var zombiehulk = AssetManager.actor_library.clone("zombiehulk", "zombie");
		zombiehulk.nameLocale = "Zombie";
		zombiehulk.race = SK.undead;
		zombiehulk.kingdom = SK.undead;
		zombiehulk.texture_path = "zombiehulk";
        zombiehulk.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiehulk.animation_idle = "walk_0";
        zombiehulk.defaultAttack = "base";
        zombiehulk.color = Toolbox.makeColor("#24803E");
        zombiehulk.base_stats[S.max_age] = 130;
       zombiehulk.base_stats[S.health] = 1000;
       zombiehulk.base_stats[S.damage] = 240;
       zombiehulk.base_stats[S.armor] = 20f;
       zombiehulk.base_stats[S.speed] = 40f;
       	zombiehulk.base_stats[S.attack_speed] = 300f;
       zombiehulk.base_stats[S.area_of_effect] = 1;
       zombiehulk.base_stats[S.knockback] = 3;
       zombiehulk.base_stats[S.knockback_reduction] = 5f;
       zombiehulk.actorSize = ActorSize.S13_Human;
       zombiehulk.canBeKilledByDivineLight = true;
        zombiehulk.take_items = true;
        zombiehulk.use_items = true;
        zombiehulk.body_separate_part_head = false;
        zombiehulk.take_items_ignore_range_weapons = false;
		zombiehulk.defaultWeapons.Clear();
		zombiehulk.defaultWeaponsMaterial.Clear();
        zombiehulk.canAttackBuildings = true;
        zombiehulk.canAttackBrains = true;
        zombiehulk.diet_meat = false;
        zombiehulk.oceanCreature = false;
        zombiehulk.landCreature = true;
        zombiehulk.canTurnIntoMush = false;
        zombiehulk.canTurnIntoZombie = false;
        zombiehulk.needFood = false;
        zombiehulk.zombieID = "";
        zombiehulk.job = "ZombieWorse";
        zombiehulk.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiehulk.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiehulk.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiehulk.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiehulk.fmod_theme = "Units_Zombie";
        zombiehulk.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiehulk);
        AssetManager.actor_library.CallMethod("loadShadow",zombiehulk);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "giant");
        AssetManager.actor_library.CallMethod("addTrait", "fat");
                AssetManager.actor_library.CallMethod("addTrait", "zombie_spawner");
        Localization.addLocalization(zombiehulk.nameLocale,zombiehulk.nameLocale);


var zombieabomination = AssetManager.actor_library.clone("zombieabomination", "zombie");
		zombieabomination.nameLocale = "Zombie";
		zombieabomination.race = SK.undead;
		zombieabomination.kingdom = SK.undead;
		zombieabomination.texture_path = "zombieabomination";
        zombieabomination.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombieabomination.animation_idle = "walk_0";
        zombieabomination.defaultAttack = "jaws";
        zombieabomination.color = Toolbox.makeColor("#24803E");
        zombieabomination.base_stats[S.max_age] = 130;
       zombieabomination.base_stats[S.health] = 1300;
       zombieabomination.base_stats[S.damage] = 240;
       zombieabomination.base_stats[S.armor] = 30f;
       zombieabomination.base_stats[S.speed] = 40f;
       	zombieabomination.base_stats[S.attack_speed] = 300f;
       zombieabomination.base_stats[S.area_of_effect] = 1;
       zombieabomination.base_stats[S.knockback] = 3;
       zombieabomination.base_stats[S.knockback_reduction] = 5f;
       zombieabomination.actorSize = ActorSize.S13_Human;
       zombieabomination.canBeKilledByDivineLight = true;
        zombieabomination.take_items = true;
        zombieabomination.use_items = true;
        zombieabomination.body_separate_part_head = false;
        zombieabomination.take_items_ignore_range_weapons = false;
		zombieabomination.defaultWeapons.Clear();
		zombieabomination.defaultWeaponsMaterial.Clear();
        zombieabomination.canAttackBuildings = true;
        zombieabomination.canAttackBrains = true;
        zombieabomination.diet_meat = false;
        zombieabomination.oceanCreature = false;
        zombieabomination.landCreature = true;
        zombieabomination.canTurnIntoMush = false;
        zombieabomination.canTurnIntoZombie = false;
        zombieabomination.needFood = false;
        zombieabomination.zombieID = "";
        zombieabomination.job = "ZombieWorse";
        zombieabomination.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombieabomination.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombieabomination.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombieabomination.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombieabomination.fmod_theme = "Units_Zombie";
        zombieabomination.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombieabomination);
        AssetManager.actor_library.CallMethod("loadShadow",zombieabomination);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "giant");
        AssetManager.actor_library.CallMethod("addTrait", "fat");
        AssetManager.actor_library.CallMethod("addTrait", "zombie_spawner");
        Localization.addLocalization(zombieabomination.nameLocale,zombieabomination.nameLocale);


var zombieclawed = AssetManager.actor_library.clone("zombieclawed", "zombie");
		zombieclawed.nameLocale = "Zombie";
		zombieclawed.race = SK.undead;
		zombieclawed.kingdom = SK.undead;
		zombieclawed.texture_path = "zombieclawed";
        zombieclawed.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombieclawed.animation_idle = "walk_0";
        zombieclawed.defaultAttack = "claws";
        zombieclawed.color = Toolbox.makeColor("#24803E");
        zombieclawed.base_stats[S.max_age] = 130;
       zombieclawed.base_stats[S.health] = 1300;
       zombieclawed.base_stats[S.damage] = 240;
       zombieclawed.base_stats[S.armor] = 35f;
       zombieclawed.base_stats[S.speed] = 40f;
       	zombieclawed.base_stats[S.attack_speed] = 300f;
       zombieclawed.base_stats[S.area_of_effect] = 1;
       zombieclawed.base_stats[S.knockback] = 6;
       zombieclawed.base_stats[S.knockback_reduction] = 5f;
       zombieclawed.actorSize = ActorSize.S13_Human;
       zombieclawed.canBeKilledByDivineLight = true;
        zombieclawed.take_items = true;
        zombieclawed.use_items = true;
        zombieclawed.body_separate_part_head = false;
        zombieclawed.take_items_ignore_range_weapons = false;
		zombieclawed.defaultWeapons.Clear();
		zombieclawed.defaultWeaponsMaterial.Clear();
        zombieclawed.canAttackBuildings = true;
        zombieclawed.canAttackBrains = true;
        zombieclawed.diet_meat = false;
        zombieclawed.oceanCreature = false;
        zombieclawed.landCreature = true;
        zombieclawed.canTurnIntoMush = false;
        zombieclawed.canTurnIntoZombie = false;
        zombieclawed.needFood = false;
        zombieclawed.zombieID = "";
        zombieclawed.job = "ZombieWorse";
        zombieclawed.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombieclawed.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombieclawed.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombieclawed.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombieclawed.fmod_theme = "Units_Zombie";
        zombieclawed.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombieclawed);
        AssetManager.actor_library.CallMethod("loadShadow",zombieclawed);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "giant");
        AssetManager.actor_library.CallMethod("addTrait", "strong");
                AssetManager.actor_library.CallMethod("addTrait", "zombie_spawner");
        Localization.addLocalization(zombieclawed.nameLocale,zombieclawed.nameLocale);


var zombieballoon = AssetManager.actor_library.clone("zombieballoon", "zombie");
		zombieballoon.nameLocale = "Zombie";
		zombieballoon.race = SK.undead;
		zombieballoon.kingdom = SK.undead;
		zombieballoon.texture_path = "zombieballoon";
        zombieballoon.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombieballoon.animation_idle = "walk_0,walk_1,walk_2,walk_3";
        zombieballoon.defaultAttack = "base";
        zombieballoon.color = Toolbox.makeColor("#24803E");
        zombieballoon.base_stats[S.max_age] = 130;
       zombieballoon.base_stats[S.health] = 100;
       zombieballoon.base_stats[S.damage] = 10;
       zombieballoon.base_stats[S.armor] = 0f;
       zombieballoon.base_stats[S.speed] = 40f;
       	zombieballoon.base_stats[S.attack_speed] = 300f;
       zombieballoon.base_stats[S.area_of_effect] = 1;
       zombieballoon.base_stats[S.knockback] = 6;
       zombieballoon.base_stats[S.knockback_reduction] = 5f;
       zombieballoon.actorSize = ActorSize.S17_Dragon;
       zombieballoon.canBeKilledByDivineLight = true;
        zombieballoon.take_items = false;
        zombieballoon.use_items = false;
        zombieballoon.body_separate_part_head = false;
        zombieballoon.take_items_ignore_range_weapons = false;
		zombieballoon.defaultWeapons.Clear();
		zombieballoon.defaultWeaponsMaterial.Clear();
        zombieballoon.canAttackBuildings = true;
        zombieballoon.canAttackBrains = true;
        zombieballoon.diet_meat = false;
        zombieballoon.oceanCreature = false;
        zombieballoon.landCreature = true;
        zombieballoon.canTurnIntoMush = false;
        zombieballoon.canTurnIntoZombie = false;
        zombieballoon.needFood = false;
        zombieballoon.zombieID = "";
        zombieballoon.job = "ZombieWorse";
        zombieballoon.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombieballoon.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombieballoon.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombieballoon.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombieballoon.fmod_theme = "Units_Zombie";
        zombieballoon.sound_hit = "event:/SFX/HIT/HitFlesh";
        zombieballoon.flying = true;
        zombieballoon.canFlip = false;
        zombieballoon.very_high_flyer = true;
        AssetManager.actor_library.add(zombieballoon);
        AssetManager.actor_library.CallMethod("loadShadow",zombieballoon);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        AssetManager.actor_library.CallMethod("addTrait", "peaceful");
        AssetManager.actor_library.CallMethod("addTrait", "acid_blood");
        AssetManager.actor_library.CallMethod("addTrait", "acid_touch");
                AssetManager.actor_library.CallMethod("addTrait", "zombie_spawner");
        Localization.addLocalization(zombieballoon.nameLocale,zombieballoon.nameLocale);


           var snowman = AssetManager.actor_library.get("snowman");
snowman.zombieID = "zombieacidman";
snowman.canTurnIntoZombie = true;

var zombieacidman = AssetManager.actor_library.clone("zombieacidman", "zombie");
		zombieacidman.nameLocale = "Zombie";
		zombieacidman.race = SK.undead;
		zombieacidman.kingdom = SK.undead;
		zombieacidman.texture_path = "zombieacidman";
        zombieacidman.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombieacidman.animation_idle = "walk_0";
        zombieacidman.defaultAttack = "base";
        zombieacidman.color = Toolbox.makeColor("#24803E");
        zombieacidman.base_stats[S.max_age] = 130;
       zombieacidman.base_stats[S.health] = 300;
       zombieacidman.base_stats[S.damage] = 204;
       zombieacidman.base_stats[S.armor] = 0f;
       zombieacidman.base_stats[S.speed] = 40f;
       	zombieacidman.base_stats[S.attack_speed] = 70f;
       zombieacidman.base_stats[S.area_of_effect] = 1;
       zombieacidman.base_stats[S.knockback] = 1;
       zombieacidman.base_stats[S.knockback_reduction] = 1f;
       zombieacidman.actorSize = ActorSize.S13_Human;
       zombieacidman.canBeKilledByDivineLight = true;
        zombieacidman.take_items = false;
        zombieacidman.use_items = false;
        zombieacidman.body_separate_part_head = false;
        zombieacidman.take_items_ignore_range_weapons = false;
		zombieacidman.defaultWeapons.Clear();
		zombieacidman.defaultWeaponsMaterial.Clear();
        zombieacidman.canAttackBuildings = true;
        zombieacidman.canAttackBrains = true;
        zombieacidman.diet_meat = false;
        zombieacidman.oceanCreature = false;
        zombieacidman.landCreature = true;
        zombieacidman.canTurnIntoMush = false;
        zombieacidman.canTurnIntoZombie = false;
        zombieacidman.needFood = false;
        zombieacidman.zombieID = "";
        zombieacidman.job = "ZombieWorse";
        zombieacidman.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombieacidman.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombieacidman.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombieacidman.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombieacidman.fmod_theme = "Units_Zombie";
        zombieacidman.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombieacidman);
        AssetManager.actor_library.CallMethod("loadShadow",zombieacidman);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
         AssetManager.actor_library.CallMethod("addTrait", "acid_blood");
        AssetManager.actor_library.CallMethod("addTrait", "acid_proof");
        AssetManager.actor_library.CallMethod("addTrait", "acid_touch");
        Localization.addLocalization(zombieacidman.nameLocale,zombieacidman.nameLocale);

var demon = AssetManager.actor_library.get("demon");
demon.zombieID = "zombiedemon";


var zombiedemon = AssetManager.actor_library.clone("zombiedemon", "zombie");
		zombiedemon.nameLocale = "Zombie";
		zombiedemon.race = SK.undead;
		zombiedemon.kingdom = SK.undead;
		zombiedemon.texture_path = "zombiedemon";
        zombiedemon.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiedemon.animation_idle = "walk_0";
        zombiedemon.defaultAttack = "base";
        zombiedemon.color = Toolbox.makeColor("#24803E");
        zombiedemon.base_stats[S.max_age] = 130;
       zombiedemon.base_stats[S.health] = 717;
       zombiedemon.base_stats[S.damage] = 10;
       zombiedemon.base_stats[S.armor] = 0f;
       zombiedemon.base_stats[S.speed] = 50f;
       	zombiedemon.base_stats[S.attack_speed] = 110f;
       zombiedemon.base_stats[S.area_of_effect] = 1;
       zombiedemon.base_stats[S.knockback] = 1;
       zombiedemon.base_stats[S.knockback_reduction] = 1f;
       zombiedemon.actorSize = ActorSize.S13_Human;
       zombiedemon.canBeKilledByDivineLight = true;
        zombiedemon.take_items = true;
        zombiedemon.use_items = true;
        zombiedemon.body_separate_part_head = false;
        zombiedemon.take_items_ignore_range_weapons = false;
		zombiedemon.defaultWeapons.Clear();
		zombiedemon.defaultWeaponsMaterial.Clear();
        zombiedemon.canAttackBuildings = true;
        zombiedemon.canAttackBrains = true;
        zombiedemon.diet_meat = false;
        zombiedemon.oceanCreature = false;
        zombiedemon.landCreature = true;
        zombiedemon.canTurnIntoMush = false;
        zombiedemon.canTurnIntoZombie = false;
        zombiedemon.needFood = false;
        zombiedemon.zombieID = "";
        zombiedemon.job = "ZombieWorse";
        zombiedemon.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiedemon.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiedemon.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiedemon.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiedemon.fmod_theme = "Units_Zombie";
        zombiedemon.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiedemon);
        AssetManager.actor_library.CallMethod("loadShadow",zombiedemon);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        Localization.addLocalization(zombiedemon.nameLocale,zombiedemon.nameLocale);

        var plagueDoctor = AssetManager.actor_library.get("plagueDoctor");
plagueDoctor.zombieID = "zombiedoctor";


var zombiedoctor = AssetManager.actor_library.clone("zombiedoctor", "zombie");
		zombiedoctor.nameLocale = "Zombie";
		zombiedoctor.race = SK.undead;
		zombiedoctor.kingdom = SK.undead;
		zombiedoctor.texture_path = "zombiedoctor";
        zombiedoctor.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiedoctor.animation_idle = "walk_0";
        zombiedoctor.defaultAttack = "base";
        zombiedoctor.color = Toolbox.makeColor("#24803E");
        zombiedoctor.base_stats[S.max_age] = 130;
       zombiedoctor.base_stats[S.health] = 600;
       zombiedoctor.base_stats[S.damage] = 1;
       zombiedoctor.base_stats[S.armor] = 0f;
       zombiedoctor.base_stats[S.speed] = 40f;
       zombiedoctor.base_stats[S.targets] = 1f;
       	zombiedoctor.base_stats[S.attack_speed] = 110f;
       zombiedoctor.base_stats[S.area_of_effect] = 1;
       zombiedoctor.base_stats[S.knockback] = 1;
       zombiedoctor.base_stats[S.knockback_reduction] = 1f;
       zombiedoctor.actorSize = ActorSize.S13_Human;
       zombiedoctor.canBeKilledByDivineLight = true;
        zombiedoctor.take_items = true;
        zombiedoctor.use_items = true;
        zombiedoctor.body_separate_part_head = false;
        zombiedoctor.take_items_ignore_range_weapons = false;
		zombiedoctor.defaultWeapons.Clear();
		zombiedoctor.defaultWeaponsMaterial.Clear();
        zombiedoctor.canAttackBuildings = true;
        zombiedoctor.canAttackBrains = true;
        zombiedoctor.diet_meat = false;
        zombiedoctor.oceanCreature = false;
        zombiedoctor.landCreature = true;
        zombiedoctor.canTurnIntoMush = false;
        zombiedoctor.canTurnIntoZombie = false;
        zombiedoctor.needFood = false;
        zombiedoctor.zombieID = "";
         ActorAsset actorAssetdoctorhelp = zombiedemon;
		actorAssetdoctorhelp.action_death = (WorldAction)Delegate.Combine(actorAssetdoctorhelp.action_death, new WorldAction(ActionLibrary.mageSlayer));
        zombiedemon.attack_spells = List.Of<string>("bloodRain");
        zombiedoctor.job = "ZombieWorse";
        zombiedoctor.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiedoctor.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiedoctor.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiedoctor.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiedoctor.fmod_theme = "Units_Zombie";
        zombiedoctor.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiedoctor);
        AssetManager.actor_library.CallMethod("loadShadow",zombiedoctor);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        Localization.addLocalization(zombiedoctor.nameLocale,zombiedoctor.nameLocale);

        var druid = AssetManager.actor_library.get("druid");
druid.zombieID = "zombiedruid";


var zombiedruid = AssetManager.actor_library.clone("zombiedruid", "zombie");
		zombiedruid.nameLocale = "Zombie";
		zombiedruid.race = SK.undead;
		zombiedruid.kingdom = SK.undead;
		zombiedruid.texture_path = "zombiedruid";
        zombiedruid.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiedruid.animation_idle = "idle_0";
        zombiedruid.defaultAttack = "base";
        zombiedruid.color = Toolbox.makeColor("#24803E");
        zombiedruid.base_stats[S.max_age] = 130;
       zombiedruid.base_stats[S.health] = 600;
       zombiedruid.base_stats[S.damage] = 1;
       zombiedruid.base_stats[S.armor] = 0f;
       zombiedruid.base_stats[S.speed] = 50f;
       	zombiedruid.base_stats[S.attack_speed] = 110f;
       zombiedruid.base_stats[S.area_of_effect] = 1;
       zombiedruid.base_stats[S.knockback] = 1;
       zombiedruid.base_stats[S.knockback_reduction] = 1f;
       zombiedruid.actorSize = ActorSize.S13_Human;
       zombiedruid.canBeKilledByDivineLight = true;
        zombiedruid.take_items = true;
        zombiedruid.use_items = true;
        zombiedruid.body_separate_part_head = false;
        zombiedruid.take_items_ignore_range_weapons = false;
		zombiedruid.defaultWeapons.Clear();
		zombiedruid.defaultWeaponsMaterial.Clear();
        zombiedruid.canAttackBuildings = true;
        zombiedruid.canAttackBrains = true;
        zombiedruid.diet_meat = false;
        zombiedruid.oceanCreature = false;
        zombiedruid.landCreature = true;
        zombiedruid.canTurnIntoMush = false;
        zombiedruid.canTurnIntoZombie = false;
        zombiedruid.needFood = false;
        zombiedruid.zombieID = "";
        zombiedruid.job = "ZombieWorse";
			zombiedruid.fmod_spawn = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalSpawn";
			zombiedruid.fmod_attack = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalAttack";
			zombiedruid.fmod_idle = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalIdle";
			zombiedruid.fmod_death = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalDeath";
        zombiedruid.fmod_theme = "Units_Zombie";
        zombiedruid.attack_spells = List.Of<string>("bloodRain");
        zombiedruid.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombiedruid);
        AssetManager.actor_library.CallMethod("loadShadow",zombiedruid);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        Localization.addLocalization(zombiedruid.nameLocale,zombiedruid.nameLocale);



        var evilMage = AssetManager.actor_library.get("evilMage");
evilMage.zombieID = "zombieevilhorseman";


var zombieevilhorseman = AssetManager.actor_library.clone("zombieevilhorseman", "zombie");
		zombieevilhorseman.nameLocale = "Zombie";
		zombieevilhorseman.race = SK.undead;
		zombieevilhorseman.kingdom = SK.undead;
		zombieevilhorseman.texture_path = "zombieevilhorseman";
        zombieevilhorseman.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombieevilhorseman.animation_idle = "walk_0";
        zombieevilhorseman.defaultAttack = "base";
        zombieevilhorseman.color = Toolbox.makeColor("#24803E");
        zombieevilhorseman.base_stats[S.max_age] = 130;
       zombieevilhorseman.base_stats[S.health] = 600;
       zombieevilhorseman.base_stats[S.damage] = 1;
       zombieevilhorseman.base_stats[S.armor] = 0f;
       zombieevilhorseman.base_stats[S.speed] = 80f;
       	zombieevilhorseman.base_stats[S.attack_speed] = 110f;
       zombieevilhorseman.base_stats[S.area_of_effect] = 1;
       zombieevilhorseman.base_stats[S.knockback] = 1;
      zombieevilhorseman.base_stats[S.targets] = 1f;
       zombieevilhorseman.base_stats[S.knockback_reduction] = 1f;
       zombieevilhorseman.actorSize = ActorSize.S13_Human;
       zombieevilhorseman.canBeKilledByDivineLight = true;
        zombieevilhorseman.take_items = true;
        zombieevilhorseman.use_items = true;
        zombieevilhorseman.body_separate_part_head = false;
        zombieevilhorseman.take_items_ignore_range_weapons = false;
		zombieevilhorseman.defaultWeapons.Clear();
		zombieevilhorseman.defaultWeaponsMaterial.Clear();
        zombieevilhorseman.canAttackBuildings = true;
        zombieevilhorseman.canAttackBrains = true;
        zombieevilhorseman.diet_meat = false;
        zombieevilhorseman.oceanCreature = false;
        zombieevilhorseman.landCreature = true;
        zombieevilhorseman.canTurnIntoMush = false;
        zombieevilhorseman.canTurnIntoZombie = false;
        zombieevilhorseman.needFood = false;
        zombieevilhorseman.zombieID = "";
        zombieevilhorseman.job = "ZombieWorse";
        	zombieevilhorseman.effect_teleport = "fx_teleport_red";
		zombieevilhorseman.effect_cast_top = "fx_cast_top_red";
		zombieevilhorseman.effect_cast_ground = "fx_cast_ground_red";
        zombieevilhorseman.attack_spells = List.Of<string>("teleportRandom", "lightning", "tornado", "bloodRain", "bloodRain", "fire");
        zombieevilhorseman.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombieevilhorseman.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombieevilhorseman.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombieevilhorseman.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombieevilhorseman.fmod_theme = "Units_Zombie";
        zombieevilhorseman.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombieevilhorseman);
        AssetManager.actor_library.CallMethod("loadShadow",zombieevilhorseman);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        Localization.addLocalization(zombieevilhorseman.nameLocale,zombieevilhorseman.nameLocale);



        var whiteMage = AssetManager.actor_library.get("whiteMage");
whiteMage.zombieID = "zombieicelich";

        var walker = AssetManager.actor_library.get("walker");
walker.zombieID = "zombieicelich";


var zombieicelich = AssetManager.actor_library.clone("zombieicelich", "zombie");
		zombieicelich.nameLocale = "Zombie";
		zombieicelich.race = SK.undead;
		zombieicelich.kingdom = SK.undead;
		zombieicelich.texture_path = "zombieicelich";
        zombieicelich.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombieicelich.animation_idle = "walk_0";
        zombieicelich.defaultAttack = "icebolt";
        zombieicelich.color = Toolbox.makeColor("#24803E");
        zombieicelich.base_stats[S.max_age] = 130;
       zombieicelich.base_stats[S.health] = 400;
       zombieicelich.base_stats[S.damage] = 1;
       zombieicelich.base_stats[S.armor] = 0f;
       zombieicelich.base_stats[S.speed] = 40f;
       	zombieicelich.base_stats[S.attack_speed] = 110f;
       zombieicelich.base_stats[S.area_of_effect] = 1;
       zombieicelich.base_stats[S.knockback] = 1;
      zombieicelich.base_stats[S.targets] = 1f;
       zombieicelich.base_stats[S.knockback_reduction] = 1f;
       zombieicelich.actorSize = ActorSize.S13_Human;
       zombieicelich.canBeKilledByDivineLight = true;
        zombieicelich.take_items = true;
        zombieicelich.use_items = true;
        zombieicelich.body_separate_part_head = false;
        zombieicelich.take_items_ignore_range_weapons = false;
		zombieicelich.defaultWeapons.Clear();
		zombieicelich.defaultWeaponsMaterial.Clear();
        zombieicelich.canAttackBuildings = true;
        zombieicelich.canAttackBrains = true;
        zombieicelich.diet_meat = false;
        zombieicelich.oceanCreature = false;
        zombieicelich.landCreature = true;
        zombieicelich.canTurnIntoMush = false;
        zombieicelich.canTurnIntoZombie = false;
        zombieicelich.needFood = false;
        zombieicelich.zombieID = "";
        zombieicelich.job = "ZombieWorse";
	zombieicelich.effect_teleport = "fx_teleport_blue";
		zombieicelich.effect_cast_top = "fx_cast_top_blue";
		zombieicelich.effect_cast_ground = "fx_cast_ground_blue";
        		zombieicelich.attack_spells = List.Of<string>("teleportRandom", "bloodRain", "shield");
        zombieicelich.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombieicelich.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombieicelich.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombieicelich.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        		zombieicelich.disableJumpAnimation = true;
        zombieicelich.fmod_theme = "Units_Zombie";
        zombieicelich.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombieicelich);
        AssetManager.actor_library.CallMethod("loadShadow",zombieicelich);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        Localization.addLocalization(zombieicelich.nameLocale,zombieicelich.nameLocale);

                var fairy = AssetManager.actor_library.get("fairy");
fairy.zombieID = "zombiefairy";
fairy.canTurnIntoZombie = true;

        var zombiefairy = AssetManager.actor_library.clone("zombiefairy", "zombie");
		zombiefairy.nameLocale = "Zombie";
		zombiefairy.race = SK.undead;
		zombiefairy.kingdom = SK.undead;
		zombiefairy.texture_path = "zombiefairy";
        zombiefairy.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombiefairy.animation_idle = "walk_0,walk_1,walk_2,walk_3";
        zombiefairy.defaultAttack = "base";
        zombiefairy.color = Toolbox.makeColor("#24803E");
        zombiefairy.base_stats[S.max_age] = 130;
       zombiefairy.base_stats[S.health] = 150;
       zombiefairy.base_stats[S.damage] = 24;
       zombiefairy.base_stats[S.armor] = 0f;
       zombiefairy.base_stats[S.speed] = 50f;
       	zombiefairy.base_stats[S.attack_speed] = 110f;
       zombiefairy.base_stats[S.area_of_effect] = 1;
       zombiefairy.base_stats[S.knockback] = 1;
       zombiefairy.base_stats[S.knockback_reduction] = 1f;
       zombiefairy.actorSize = ActorSize.S13_Human;
       zombiefairy.canBeKilledByDivineLight = true;
        zombiefairy.take_items = true;
        zombiefairy.use_items = true;
        zombiefairy.body_separate_part_head = false;
        zombiefairy.take_items_ignore_range_weapons = false;
		zombiefairy.defaultWeapons.Clear();
		zombiefairy.defaultWeaponsMaterial.Clear();
        zombiefairy.canAttackBuildings = true;
        zombiefairy.canAttackBrains = true;
        zombiefairy.diet_meat = false;
        zombiefairy.oceanCreature = false;
        zombiefairy.landCreature = true;
        zombiefairy.canTurnIntoMush = false;
        zombiefairy.canTurnIntoZombie = false;
        zombiefairy.needFood = false;
        zombiefairy.zombieID = "";
        zombiefairy.job = "ZombieWorse";
        zombiefairy.fmod_spawn = "event:/SFX/UNITS/Zombie/ZombieSpawn";
        zombiefairy.fmod_attack = "event:/SFX/UNITS/Zombie/ZombieAttack";
        zombiefairy.fmod_idle = "event:/SFX/UNITS/Zombie/ZombieIdle";
        zombiefairy.fmod_death = "event:/SFX/UNITS/Zombie/ZombieDeath";
        zombiefairy.fmod_theme = "Units_Zombie";
        zombiefairy.sound_hit = "event:/SFX/HIT/HitFlesh";
        		zombiefairy.hovering = true;
        		zombiefairy.disableJumpAnimation = true;
        		zombiefairy.moveFromBlock = true;
		zombiefairy.dieOnBlocks = false;
        AssetManager.actor_library.add(zombiefairy);
        AssetManager.actor_library.CallMethod("loadShadow",zombiefairy);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "stupid");
        Localization.addLocalization(zombiefairy.nameLocale,zombiefairy.nameLocale);

        var fly = AssetManager.actor_library.get("fly");
fly.zombieID = "zombietarantula";
fly.canTurnIntoZombie = true;

        var butterfly = AssetManager.actor_library.get("butterfly");
butterfly.zombieID = "zombietarantula";
butterfly.canTurnIntoZombie = true;

        var grasshopper = AssetManager.actor_library.get("grasshopper");
grasshopper.zombieID = "zombietarantula";
grasshopper.canTurnIntoZombie = true;

        var beetle = AssetManager.actor_library.get("beetle");
beetle.zombieID = "zombietarantula";
beetle.canTurnIntoZombie = true;

var zombietarantula = AssetManager.actor_library.clone("zombietarantula", "zombie");
		zombietarantula.nameLocale = "Zombie";
		zombietarantula.race = SK.undead;
		zombietarantula.kingdom = SK.undead;
		zombietarantula.texture_path = "zombietarantula";
        zombietarantula.animation_walk = "walk_0,walk_1,walk_2,walk_3";
        zombietarantula.animation_idle = "walk_0";
        zombietarantula.defaultAttack = "base";
        zombietarantula.color = Toolbox.makeColor("#24803E");
        zombietarantula.base_stats[S.max_age] = 130;
       zombietarantula.base_stats[S.health] = 150;
       zombietarantula.base_stats[S.damage] = 24;
       zombietarantula.base_stats[S.armor] = 0f;
       zombietarantula.base_stats[S.speed] = 40f;
       	zombietarantula.base_stats[S.attack_speed] = 110f;
       zombietarantula.base_stats[S.area_of_effect] = 1;
       zombietarantula.base_stats[S.knockback] = 1;
       zombietarantula.base_stats[S.knockback_reduction] = 1f;
       zombietarantula.actorSize = ActorSize.S13_Human;
       zombietarantula.canBeKilledByDivineLight = true;
        zombietarantula.take_items = false;
        zombietarantula.use_items = false;
        zombietarantula.body_separate_part_head = false;
        zombietarantula.take_items_ignore_range_weapons = false;
		zombietarantula.defaultWeapons.Clear();
		zombietarantula.defaultWeaponsMaterial.Clear();
        zombietarantula.canAttackBuildings = true;
        zombietarantula.canAttackBrains = true;
        zombietarantula.diet_meat = false;
        zombietarantula.oceanCreature = false;
        zombietarantula.landCreature = true;
        zombietarantula.canTurnIntoMush = false;
        zombietarantula.canTurnIntoZombie = false;
        zombietarantula.needFood = false;
        zombietarantula.zombieID = "";
        zombietarantula.job = "ZombieWorse";
			zombietarantula.fmod_spawn = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalSpawn";
			zombietarantula.fmod_attack = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalAttack";
			zombietarantula.fmod_idle = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalIdle";
			zombietarantula.fmod_death = "event:/SFX/UNITS/ZombieAnimal/ZombieAnimalDeath";
        zombietarantula.fmod_theme = "Units_Zombie";
        zombietarantula.sound_hit = "event:/SFX/HIT/HitFlesh";
        AssetManager.actor_library.add(zombietarantula);
        AssetManager.actor_library.CallMethod("loadShadow",zombietarantula);
        AssetManager.actor_library.CallMethod("addTrait", "zombie");
        AssetManager.actor_library.CallMethod("addTrait", "immortal");
        AssetManager.actor_library.CallMethod("addTrait", "small");
        AssetManager.actor_library.CallMethod("addTrait", "venomous");
        Localization.addLocalization(zombietarantula.nameLocale,zombietarantula.nameLocale);

           var zombietrait = AssetManager.traits.get("zombie");
        zombietrait.action_special_effect = (WorldAction)Delegate.Combine(zombietrait.action_special_effect, new WorldAction(M2zombieEffect));

        			ActorTrait NightInfusedZombie = new ActorTrait();
			NightInfusedZombie.id = "NightInfusedZombie";
			NightInfusedZombie.path_icon = "ui/Icons/NightInfusedZombie";
			NightInfusedZombie.group_id = TraitGroup.body;
			NightInfusedZombie.inherit = 0f;
            NightInfusedZombie.can_be_given = false;
            NightInfusedZombie.base_stats[S.speed] = 40f;
            NightInfusedZombie.base_stats[S.attack_speed] = 50f;
         AssetManager.traits.add(NightInfusedZombie);
            addTraitToLocalizedLibrary(NightInfusedZombie.id, "The darkness powers up the disease");
            PlayerConfig.unlockTrait("NightInfusedZombie");

            ActorTrait ChaosZombie = new ActorTrait();
			ChaosZombie.id = "ChaosZombie";
			ChaosZombie.path_icon = "ui/Icons/ChaosZombie";
			ChaosZombie.group_id = TraitGroup.body;
			ChaosZombie.inherit = 0f;
            ChaosZombie.can_be_given = false;
            ChaosZombie.action_attack_target = ActionLibrary.restoreHealthOnHit;
            ChaosZombie.base_stats[S.speed] = 20f;
            ChaosZombie.base_stats[S.scale] = 0.05f;
		    ChaosZombie.base_stats[S.mod_health] = 0.3f;
            ChaosZombie.base_stats[S.attack_speed] = 30f;
         AssetManager.traits.add(ChaosZombie);
            addTraitToLocalizedLibrary(ChaosZombie.id, "The chaos energy powers up the disease");
            PlayerConfig.unlockTrait("ChaosZombie");

			ActorTrait FrostedZombie = new ActorTrait();
			FrostedZombie.id = "FrostedZombie";
			FrostedZombie.path_icon = "ui/Icons/FrostedZombie";
			FrostedZombie.group_id = TraitGroup.body;
			FrostedZombie.inherit = 0f;
			FrostedZombie.can_be_given = false;
			FrostedZombie.base_stats[S.speed] = -30f;
            FrostedZombie.base_stats[S.attack_speed] = -50f;
            FrostedZombie.action_special_effect = (WorldAction)Delegate.Combine(FrostedZombie.action_special_effect, new WorldAction(constantFrozenEffect));
            AssetManager.traits.add(FrostedZombie);
            addTraitToLocalizedLibrary(FrostedZombie.id, "Letting Go");
            PlayerConfig.unlockTrait("FrostedZombie");

			ActorTrait ScorchedZombie = new ActorTrait();
			ScorchedZombie.id = "ScorchedZombie";
			ScorchedZombie.path_icon = "ui/Icons/ScorchedZombie";
			ScorchedZombie.group_id = TraitGroup.body;
			ScorchedZombie.inherit = 0f;
			ScorchedZombie.can_be_given = false;
			ScorchedZombie.base_stats[S.speed] = -100f;
			ScorchedZombie.base_stats[S.range] = -20f;
		     ScorchedZombie.base_stats[S.accuracy] = -100f;
            ScorchedZombie.action_special_effect = (WorldAction)Delegate.Combine(ScorchedZombie.action_special_effect, new WorldAction(randomWaitEffect));
            AssetManager.traits.add(ScorchedZombie);
            addTraitToLocalizedLibrary(ScorchedZombie.id, "The Sun is weakening the rotting body of the zombie");
            PlayerConfig.unlockTrait("ScorchedZombie");

		}






public static bool pileofcorpsesEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;

    if (selfActor == null)
        return false;

    WorldTile targetTile = selfActor.currentTile;
    if (targetTile.building == null)
    {
        MapBox.instance.buildings.addBuilding("pileofcorpses", targetTile, false, false, BuildPlacingType.New);
    }

    return true;
}




public static bool activeCorpseSpawnerEffect(BaseSimObject pTarget, WorldTile pTile = null)
{

    if (pTarget == null || pTile == null) return false;

    Actor actor = pTarget.a;
    if (actor == null) return false;


    bool shouldSpawn = false;
    actor.data.get("exhaustedSpawner", out bool exhaustedSpawner);


    List<string> buildingIds = new List<string> { "pileofcorpses", "pileofcorpses" };
    int perChunkLimit = 3;


    MapChunk currentChunk = pTile.chunk;
    if (currentChunk == null) return false;


    int buildingCountInChunk = CountBuildingsInChunk(currentChunk, buildingIds);
    if (buildingCountInChunk >= perChunkLimit)
    {

        return false;
    }


    if (IsLiquidTile(pTile))
    {
        return false;
    }


    if (!exhaustedSpawner)
    {
        shouldSpawn = true;
    }

    if (shouldSpawn)
    {
        WorldTile targetTile = actor.currentTile;
        if (targetTile != null && targetTile.building == null)
        {

            List<string> buildingsToSpawn = new List<string>();


            if (Toolbox.randomChance(0.4f)) buildingsToSpawn.Add("pileofcorpses");
            if (Toolbox.randomChance(0.6f)) buildingsToSpawn.Add("pileofcorpses");


            foreach (string buildingToSpawn in buildingsToSpawn)
            {
                Building spawnedBuilding = MapBox.instance.buildings.addBuilding(buildingToSpawn, targetTile, false, false, BuildPlacingType.New);
                if (spawnedBuilding != null)
                {

                    actor.data.set("exhaustedSpawner", true);
                }
            }
        }
    }

    return true;
}



		  public static bool randomWaitEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTarget == null || !pTarget.isActor())
        return false;

    Actor actor = pTarget.a;


    if (Toolbox.randomChance(0.2f))
    {
        actor.makeWait(10f);
    }

    return true;
}

	public static bool constantFrozenEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (!pTarget.isActor())
        return false;

    Actor actor = pTarget.a;

    if (!actor.hasStatus("frozen"))
    {
        if (!actor.currentTile.Type.lava && !actor.currentTile.isOnFire())
        {
            actor.addStatusEffect("frozen");
        }
    }

    return true;
}


         public static bool M2zombieEffect(BaseSimObject pTarget, WorldTile pTile = null)
	{
          if (pTarget == null || !pTarget.isActor())
        return false;

    Actor actor = pTarget.a;

		pTarget.a.spawnParticle(Toolbox.color_infected);
		if (Toolbox.randomChance(0.25f))
		{
			pTarget.a.startShake(0.2f, 0.05f, pHorizontal: true, pVertical: false);
		}

    if (World.world_era.overlay_sun)
    {
        if (!actor.hasTrait("ScorchedZombie"))
        {
            actor.addTrait("ScorchedZombie");
        }
    }
    else
    {
        actor.removeTrait("ScorchedZombie");
    }

    if (World.world_era.overlay_winter)
    {
        if (!actor.hasTrait("FrostedZombie"))
        {
            actor.addTrait("FrostedZombie");
        }
    }
    else
    {
        actor.removeTrait("FrostedZombie");
    }

    if (World.world_era.overlay_chaos)
    {
        if (!actor.hasTrait("ChaosZombie"))
        {
            actor.addTrait("ChaosZombie");
        }
    }
    else
    {
        actor.removeTrait("ChaosZombie");
    }

    if (World.world_era.overlay_night || World.world_era.overlay_moon)
    {
        if (!actor.hasTrait("NightInfusedZombie"))
        {
            actor.addTrait("NightInfusedZombie");
        }
    }
    else
    {
        actor.removeTrait("NightInfusedZombie");
    }

    float age = actor.getAge();
    int kills = actor.data.kills;
    if (CheckZombieTransform(actor, age, kills, pTile))
    {
        return true;
    }

		return false;
	}
 //  updateLayer(World.world_era.overlay_chaos, "chaos", pElapsed);
	//	updateLayer(World.world_era.overlay_moon, "moon", pElapsed);
	//	updateLayer(World.world_era.overlay_magic, "magic", pElapsed);
	//	updateLayer(World.world_era.overlay_sun, "sun", pElapsed);
	//	updateLayer(World.world_era.overlay_rain_darkness, "rain_darkness", pElapsed);
	//	updateLayer(World.world_era.overlay_winter, "winter", pElapsed);
	//	updateLayer(World.world_era.overlay_ash, "ash", pElapsed);
	//	updateLayer(World.world_era.overlay_night, "night", pElapsed);
	//	updateLayer(World.world_era.overlay_rain, "rain", pElapsed);


//zombiespeed, zombiespikes, zombiepoison, zombieacid, zombietentacle, zombiestalker, zombiemother, zombiefiremaniac, zombiehulk, zombieabomination, zombieclawed, zombieballoon

private static bool CheckZombieTransform(Actor actor, float age, int kills, WorldTile pTile)
{
    switch (actor.asset.id)
    {
        case "zombie":
            if (actor.hasTrait("veteran"))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (Toolbox.randomChance(0.01f))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("fat"))
            {
        string[] transformationOptions = { "zombieballoon" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
           else if (actor.hasTrait("giant"))
            {
        string[] transformationOptions = { "zombiestalker" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("strong"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
             else if (actor.hasTrait("bloodlust"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            break;

              case "zombie_orc":
            if (actor.hasTrait("veteran"))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (Toolbox.randomChance(0.01f))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("fat"))
            {
        string[] transformationOptions = { "zombieballoon" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
           else if (actor.hasTrait("giant"))
            {
        string[] transformationOptions = { "zombiestalker" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("strong"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
             else if (actor.hasTrait("bloodlust"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            break;

              case "zombie_elf":
            if (actor.hasTrait("veteran"))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (Toolbox.randomChance(0.01f))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("fat"))
            {
        string[] transformationOptions = { "zombieballoon" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
           else if (actor.hasTrait("giant"))
            {
        string[] transformationOptions = { "zombiestalker" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("strong"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
             else if (actor.hasTrait("bloodlust"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            break;

              case "zombie_dwarf":
            if (actor.hasTrait("veteran"))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (Toolbox.randomChance(0.01f))
            {
        string[] transformationOptions = { "zombiespeed", "zombieacid", "zombiestalker", "zombietentacle", "zombiefiremaniac", "zombieballoon" , "zombiespikes", "zombiepoison", "zombiemother", "zombieabomination", "zombieclawed", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("fat"))
            {
        string[] transformationOptions = { "zombieballoon" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
           else if (actor.hasTrait("giant"))
            {
        string[] transformationOptions = { "zombiestalker" , "zombiemother", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            else if (actor.hasTrait("strong"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle", "zombieabomination", "zombiehulk" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
             else if (actor.hasTrait("bloodlust"))
            {
        string[] transformationOptions = { "zombieclawed" , "zombietentacle" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];
        TransformActor(actor, chosenTransformation, pTile);
        return true;
            }
            break;

    }

    return false;
}


   public static bool spawnGlitchCreature(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (!pTarget.isActor())
            {
                return false;
            }

            if (!a.asset.canTurnIntoTumorMonster)
            {
                return false;
            }

            string newUnitID;
            if (a.asset.has_soul)
            {
                newUnitID = "glitchspectre";
            }
            else if (a.asset.animal)
            {
                newUnitID = "glitchtarantula";
            }
            else
            {
                newUnitID = "glitchspectre";
            }

            Actor actor = World.world.units.createNewUnit(newUnitID, pTile);
            actor.removeTrait("blessed");
            ActorTool.copyUnitToOtherUnit(pTarget.a, actor);
            EffectsLibrary.spawnAt("evilspawn", actor.currentTile.posV3, 0.1f);
            ActionLibrary.removeUnit(a);

            return true;
        }



   public static void simpleUnitAssetSpawnUsingIslands(DisasterAsset pAsset)
{
    if (checkUnitSpawnLimits(pAsset))
    {
        TileIsland randomIslandGround = World.world.islandsCalculator.getRandomIslandGround();
        if (randomIslandGround != null)
        {
            WorldTile randomTile = randomIslandGround.getRandomTile();
            spawnDisasterUnit(pAsset, randomTile);
            WorldLog.logDisaster(pAsset, randomTile);
        }
    }
}

	private static bool checkUnitSpawnLimits(DisasterAsset pAsset)
	{
		if (string.IsNullOrEmpty(pAsset.spawn_asset_unit))
		{
			return false;
		}
		ActorAsset actorAsset = AssetManager.actor_library.get(pAsset.spawn_asset_unit);
		if (AssetManager.raceLibrary.get(actorAsset.race).units.Count >= pAsset.max_existing_units)
		{
			return false;
		}
		return true;
	}

	private static Actor spawnDisasterUnit(DisasterAsset pAsset, WorldTile pTile)
	{
		EffectsLibrary.spawn("fx_spawn", pTile);
		Actor result = null;
		int num = Toolbox.randomInt(pAsset.units_min, pAsset.units_max);
		for (int i = 0; i < num; i++)
		{
			result = World.world.units.createNewUnit(pAsset.spawn_asset_unit, pTile);
		}
		return result;
	}




 //  updateLayer(World.world_era.overlay_chaos, "chaos", pElapsed);
	//	updateLayer(World.world_era.overlay_moon, "moon", pElapsed);
	//	updateLayer(World.world_era.overlay_magic, "magic", pElapsed);
	//	updateLayer(World.world_era.overlay_sun, "sun", pElapsed);
	//	updateLayer(World.world_era.overlay_rain_darkness, "rain_darkness", pElapsed);
	//	updateLayer(World.world_era.overlay_winter, "winter", pElapsed);
	//	updateLayer(World.world_era.overlay_ash, "ash", pElapsed);
	//	updateLayer(World.world_era.overlay_night, "night", pElapsed);
	//	updateLayer(World.world_era.overlay_rain, "rain", pElapsed);

    public static bool SolarPoweredCyberBodyEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTarget == null || !pTarget.isActor()) return false;

    Actor actor = pTarget.a;
    if (actor == null || !actor.isAlive()) return false;


    if (World.world_era.overlay_sun)
    {
        if (!actor.hasTrait("fast"))
        {
            actor.addTrait("fast");
        }
    }
    else
    {
        actor.removeTrait("fast");
    }

    if (World.world_era.overlay_winter)
    {
        if (!actor.hasTrait("frozenmachinary"))
        {
            actor.addTrait("frozenmachinary");
        }
    }
    else
    {
        actor.removeTrait("frozenmachinary");
    }

    if (World.world_era.overlay_chaos)
    {
        if (!actor.hasTrait("madness"))
        {
            actor.addTrait("madness");
        }
    }
    else
    {
        actor.removeTrait("madness");
    }

    if (World.world_era.overlay_night || World.world_era.overlay_moon)
    {
        if (!actor.hasTrait("unpoweredmachinery"))
        {
            actor.addTrait("unpoweredmachinery");
        }
    }
    else
    {
        actor.removeTrait("unpoweredmachinery");
    }

    return true;
}



public static bool walkercorpseEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;

    if (selfActor == null)
        return false;

    WorldTile targetTile = selfActor.currentTile;
    if (targetTile.building == null)
    {
        MapBox.instance.buildings.addBuilding("walkercorpse", targetTile, false, false, BuildPlacingType.New);
    }

    return true;
}

public static bool activeAssimilatorSpawnerEffect(BaseSimObject pTarget, WorldTile pTile = null)
{

    if (pTarget == null || pTile == null) return false;

    Actor actor = pTarget.a;
    if (actor == null) return false;


    bool shouldSpawn = false;
    actor.data.get("exhaustedSpawner", out bool exhaustedSpawner);


    List<string> buildingIds = new List<string> { "missilecybercore", "cybercore" };
    int perChunkLimit = 3;


    MapChunk currentChunk = pTile.chunk;
    if (currentChunk == null) return false;


    int buildingCountInChunk = CountBuildingsInChunk(currentChunk, buildingIds);
    if (buildingCountInChunk >= perChunkLimit)
    {

        return false;
    }


    if (IsLiquidTile(pTile))
    {
        return false;
    }


    if (!exhaustedSpawner)
    {
        shouldSpawn = true;
    }

    if (shouldSpawn)
    {
        WorldTile targetTile = actor.currentTile;
        if (targetTile != null && targetTile.building == null)
        {

            List<string> buildingsToSpawn = new List<string>();


            if (Toolbox.randomChance(0.4f)) buildingsToSpawn.Add("missilecybercore");
            if (Toolbox.randomChance(0.6f)) buildingsToSpawn.Add("cybercore");


            foreach (string buildingToSpawn in buildingsToSpawn)
            {
                Building spawnedBuilding = MapBox.instance.buildings.addBuilding(buildingToSpawn, targetTile, false, false, BuildPlacingType.New);
                if (spawnedBuilding != null)
                {

                    actor.data.set("exhaustedSpawner", true);
                }
            }
        }
    }

    return true;
}


public static bool activeIceTowerSpawnerEffect(BaseSimObject pTarget, WorldTile pTile = null)
{

    if (pTarget == null || pTile == null) return false;

    Actor actor = pTarget.a;
    if (actor == null) return false;


    if (!World.world_era.overlay_winter)
    {
        return false;
    }


    bool shouldSpawn = false;
    actor.data.get("exhaustedSpawner", out bool exhaustedSpawner);


    List<string> buildingIds = new List<string> { "icewatchtower", "ice_tower" };
    int perChunkLimit = 1;


    MapChunk currentChunk = pTile.chunk;
    if (currentChunk == null) return false;

    int buildingCountInChunk = CountBuildingsInChunk(currentChunk, buildingIds);
    if (buildingCountInChunk >= perChunkLimit)
    {
        return false;
    }


    if (IsLiquidTile(pTile))
    {
        return false;
    }


    if (!exhaustedSpawner)
    {
        shouldSpawn = true;
    }


    if (shouldSpawn)
    {
        WorldTile targetTile = actor.currentTile;
        if (targetTile != null && targetTile.building == null)
        {

            string buildingToSpawn = Toolbox.randomChance(0.05f) ? "icewatchtower" : "ice_tower";


            Building spawnedBuilding = MapBox.instance.buildings.addBuilding(buildingToSpawn, targetTile, false, false, BuildPlacingType.New);
            if (spawnedBuilding != null)
            {

                actor.data.set("exhaustedSpawner", true);
            }
        }
    }

    return true;
}






private static int CountBuildingsInChunk(MapChunk chunk, List<string> buildingIds)
{
    if (chunk == null || buildingIds == null || buildingIds.Count == 0)
    {
        return 0;
    }

    int buildingCount = 0;

    foreach (MapRegion region in chunk.regions)
    {
        foreach (WorldTile tile in region.tiles)
        {
            Building building = tile.building;
            if (building != null && buildingIds.Contains(building.asset.id) && !building.isRuin())
            {
                buildingCount++;
            }
        }
    }
    return buildingCount;
}

private static bool IsLiquidTile(WorldTile tile)
{
    if (tile == null) return false;

    return tile.Type == TileLibrary.deep_ocean
        || tile.Type == TileLibrary.close_ocean
        || tile.Type == TileLibrary.shallow_waters
        || tile.Type.IsType("water")
        || tile.Type.IsType("lava");
}





public static bool PotentialEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    Actor actor = pTarget.a;
    if (actor == null)
    {
        return false;
    }

    float age = actor.getAge();
    int kills = actor.data.kills;

	    if (CheckAndTransformByEraAndMob(actor, pTile))
    {
        return true;
    }
    if (CheckAndTransformByTraitsAgeKills(actor, age, kills, pTile))
    {
        return true;
    }
    return false;
}



private static bool CheckAndTransformByTraitsAgeKills(Actor actor, float age, int kills, WorldTile pTile)
{
    switch (actor.asset.id)
    {
			case "walker":

             if (Toolbox.randomChance(0.3f))
            {
                TransformActor(actor, "icedracoid", pTile);
                return true;
            }
            else if (Toolbox.randomChance(0.3f))
            {
                TransformActor(actor, "buffrost", pTile);
                return true;
            }
           else if (Toolbox.randomChance(0.3f))
            {
                TransformActor(actor, "normalwalker", pTile);
                return true;
            }
            break;

           case "assimilator":
    if (kills > 5)
    {
        string[] transformationOptions = { "assimilarptor", "assimilatrax", "helilator", "assizeppelin" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];

        TransformActor(actor, chosenTransformation, pTile);
        return true;
    }
    break;

      case "assimilarptor":
    if (kills > 5)
    {
        string[] transformationOptions = { "assimilatrax", "helilator", "assizeppelin" };
        string chosenTransformation = transformationOptions[Toolbox.randomInt(0, transformationOptions.Length)];

        TransformActor(actor, chosenTransformation, pTile);
        return true;
    }
    break;

    }

    return false;
}

private static bool CheckAndTransformByEraAndMob(Actor actor, WorldTile pTile)
{

    bool isColdAge = World.world_era.overlay_winter;


    HashSet<string> walkerRelatedMobs = new HashSet<string> { "walker", "icedracoid", "buffrost", "normalwalker" };


    if (walkerRelatedMobs.Contains(actor.asset.id))
    {
        if (!isColdAge)
        {

            if (Toolbox.randomChance(0.1f))
            {
                TransformActorToUFO(actor, "snowman", pTile);
                return true;
            }
        }
    }

    return false;
}



private static void TransformActor(Actor originalActor, string newActorId, WorldTile pTile)
{

    if (originalActor.asset.id == newActorId)
    {
        return;
    }
    Actor newActor = World.world.units.createNewUnit(newActorId, pTile);
    newActor.removeTrait("Mimicry");
    ActorTool.copyUnitToOtherUnit(originalActor, newActor);
    EffectsLibrary.spawn("fx_spawn", newActor.currentTile);
    ActionLibrary.removeUnit(originalActor);
}

private static void TransformActornoskin(Actor originalActor, string newActorId, WorldTile pTile)
{

    if (originalActor.asset.id == newActorId)
    {
        return;
    }

    Actor newActor = World.world.units.createNewUnit(newActorId, pTile);
    newActor.removeTrait("Mimicry");
    ActorTool.copyUnitToOtherUnit(originalActor, newActor);
    EffectsLibrary.spawn("fx_spawn", newActor.currentTile);
    ActionLibrary.removeUnit(originalActor);
}


private static void TransformActorToUFO(Actor originalActor, string newActorId, WorldTile pTile)
{

    if (originalActor.asset.id == newActorId)
    {
        return;
    }

    Actor newActor = World.world.units.createNewUnit(newActorId, pTile);
    newActor.removeTrait("Mimicry");
    EffectsLibrary.spawn("fx_spawn", newActor.currentTile);
    ActionLibrary.removeUnit(originalActor);
}


         public static bool castspawnicewalker(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
	{
		if (pTarget != null)
		{
			pTile = pTarget.currentTile;
		}
		Toolbox.findSameUnitInChunkAround(pTile.chunk, "walker");
		if (Toolbox.temp_list_units.Count > 6)
		{
			return false;
		}
		WorldTile worldTile = pTile?.region?.tiles.GetRandom();
		if (worldTile == null)
		{
			return false;
		}
		spawnicewalker(null, worldTile);
		return true;
	}

public static bool spawnicewalker(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTile == null)
    {
        return false;
    }
    World.world.units.createNewUnit("walker", pTile).makeWait(1f);
    return true;
}


         public static bool castspawnassimilatorzeppelin(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
	{
		if (pTarget != null)
		{
			pTile = pTarget.currentTile;
		}
		Toolbox.findSameUnitInChunkAround(pTile.chunk, "assizeppelin");
		if (Toolbox.temp_list_units.Count > 6)
		{
			return false;
		}
		WorldTile worldTile = pTile?.region?.tiles.GetRandom();
		if (worldTile == null)
		{
			return false;
		}
		zeppelinino(null, worldTile);
		return true;
	}

public static bool zeppelinino(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTile == null)
    {
        return false;
    }
    World.world.units.createNewUnit("assizeppelin", pTile).makeWait(1f);
    return true;
}

         public static bool castcybercopter(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
	{
		if (pTarget != null)
		{
			pTile = pTarget.currentTile;
		}
		Toolbox.findSameUnitInChunkAround(pTile.chunk, "helilator");
		if (Toolbox.temp_list_units.Count > 6)
		{
			return false;
		}
		WorldTile worldTile = pTile?.region?.tiles.GetRandom();
		if (worldTile == null)
		{
			return false;
		}
		cybercopter(null, worldTile);
		return true;
	}

public static bool cybercopter(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTile == null)
    {
        return false;
    }
    World.world.units.createNewUnit("helilator", pTile).makeWait(1f);
    return true;
}







	                     //boring
	public static void addTraitToLocalizedLibrary(string id, string description)
      	{
      		string language = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "language") as string;
      		Dictionary<string, string> localizedText = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "localizedText") as Dictionary<string, string>;
      		localizedText.Add("trait_" + id, id);
      		localizedText.Add("trait_" + id + "_info", description);
        }




		
		public static void addGlitchToPool()
		{	
	//	AssetManager.biome_library.addBiomeToPool(Glitch);
		}

		}
		
}
