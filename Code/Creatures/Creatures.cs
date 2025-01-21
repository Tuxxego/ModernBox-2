//========= MODERNBOX 2.1.0.1 ============//
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
			



         EffectAsset evilspawn = new EffectAsset
            {
                id = "evilspawn",
                use_basic_prefab = true,
                sprite_path = "effects/fx_teleport_red_t",
                draw_light_area = true,
                show_on_mini_map = false,
                limit = 80,
                sorting_layer_id = "EffectsTop"
            };
            evilspawn.spawn_action = (effect, tile, param1, param2, floatParam) =>
            {
                if (effect != null)
                {
                    SpriteRenderer renderer = effect.GetComponent<SpriteRenderer>();
                    if (renderer != null)
                    {
                        renderer.sortingLayerName = evilspawn.sorting_layer_id;
                    }
                }
                return effect;
            };
            AssetManager.effects_library.add(evilspawn);








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
                newUnitID = "Terlanius"; // TEMPORARY AS A TEST
            }

            Actor actor = World.world.units.createNewUnit(newUnitID, pTile);
            actor.removeTrait("blessed");
            ActorTool.copyUnitToOtherUnit(pTarget.a, actor);
            EffectsLibrary.spawnAt("evilspawn", actor.currentTile.posV3, 0.1f);
            ActionLibrary.removeUnit(a);

            return true;
        }
		
		public static void addGlitchToPool()
		{	
	//	AssetManager.biome_library.addBiomeToPool(Glitch);
		}

		}
		
}
