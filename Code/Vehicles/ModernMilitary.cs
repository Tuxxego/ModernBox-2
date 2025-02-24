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

namespace M2
{
    class ModernMilitary : MonoBehaviour
    {
		



        public static void init()
        {
            loadAssets();

        }
		
		


        private static void loadAssets()
        {
			

	ColorSetAsset eva01 = new ColorSetAsset();
    eva01.id = "eva01";
    eva01.shades_from = "#8620ca";
    eva01.shades_to = "#8620ca";
    eva01.is_default = true;
    AssetManager.skin_color_set_library.add(eva01);

	ColorSetAsset eva02 = new ColorSetAsset();
    eva02.id = "eva02";
    eva02.shades_from = "#f2321b";
    eva02.shades_to = "#f2321b";
    eva02.is_default = true;
    AssetManager.skin_color_set_library.add(eva02);

	ColorSetAsset eva00 = new ColorSetAsset();
    eva00.id = "eva00";
    eva00.shades_from = "#f8e348";
    eva00.shades_to = "#f8e348";
    eva00.is_default = true;
    AssetManager.skin_color_set_library.add(eva00);

	ColorSetAsset eva03 = new ColorSetAsset();
    eva03.id = "eva03";
    eva03.shades_from = "#413b69";
    eva03.shades_to = "#413b69";
    eva03.is_default = true;
    AssetManager.skin_color_set_library.add(eva03);

		var Soldier = AssetManager.actor_library.clone("Soldier","_mob");
			//ActorAsset heli = new ActorAsset();
           // Soldier.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			Soldier.race = "human";
			Soldier.kingdom = "ModernKingdom";
            Soldier.base_stats[S.health] = 100f;
            Soldier.base_stats[S.speed] = 40f;
            Soldier.base_stats[S.armor] = 20f;
            Soldier.base_stats[S.damage] = 0f;
            Soldier.base_stats[S.scale] = 0.1f;
            Soldier.base_stats[S.attack_speed] = 80;
			Soldier.base_stats[S.range] = 25f;
			Soldier.base_stats[S.warfare] = 20f;
            Soldier.drawBoatMark_big = true;
            Soldier.skipFightLogic = false;
            Soldier.inspect_stats = true;
			Soldier.landCreature = true;
			Soldier.inspect_home = true;
			Soldier.hideOnMinimap = false;
            Soldier.drawBoatMark = true;
			Soldier.can_edit_traits = true;
			Soldier.canReceiveTraits = true;
			Soldier.flying = false;
			//Soldier.tech = "Soldiers";
			Soldier.very_high_flyer = false;
            Soldier.isBoat = false;
			Soldier.dieOnBlocks = false;
			Soldier.ignoreBlocks = false;
			Soldier.moveFromBlock = true;
			Soldier.procreate = false;
		    Soldier.inspect_children = false;
            Soldier.inspect_experience = true;
			Soldier.defaultWeapons = List.Of<string>(new string[]
				{
			 "XM8",
			 "Mp5"
				});
			Soldier.defaultWeaponsMaterial = List.Of<string>(new string[]
				{
				 "iron"
				});
			Soldier.canBeCitizen = true;
            Soldier.inspect_kills = true;
            Soldier.use_items = true;
			Soldier.oceanCreature = false;
            Soldier.take_items = true;
            Soldier.nameLocale = "Soldier";
            Soldier.nameTemplate = "Modern_Names";
			Soldier.job = "attacker";
            Soldier.icon = "iconSoldier";
			//AssetManager.actor_library.CallMethod("addTrait", "Soldier");
			AssetManager.actor_library.CallMethod("loadShadow", Soldier);
            Soldier.animation_walk = "walk_0,walk_1,walk_2,walk_3";
			Soldier.animation_idle = "walk_0";
            Soldier.animation_swim = "swim_0,swim_1,swim_0,swim_1";
            Soldier.texture_path = "Soldier";
			AssetManager.actor_library.addColorSet("heliColor");
			AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			Soldier.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(Soldier);
			Localization.addLocalization(Soldier.nameLocale, Soldier.nameLocale);

var EVA01 = AssetManager.actor_library.clone("EVA01","_mob");
			//ActorAsset heli = new ActorAsset();
           // EVA01.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			EVA01.race = "human";
			EVA01.kingdom = "ModernKingdom";
            EVA01.base_stats[S.health] = 100000f;
            EVA01.base_stats[S.speed] = 70f;
            EVA01.base_stats[S.armor] = 50f;
            EVA01.base_stats[S.damage] = 1000f;
            EVA01.base_stats[S.scale] = 0.2f;
            EVA01.base_stats[S.attack_speed] = 200;
			EVA01.base_stats[S.range] = 25f;
            EVA01.drawBoatMark_big = true;
            EVA01.skipFightLogic = false;
            EVA01.inspect_stats = true;
			EVA01.landCreature = true;
			EVA01.inspect_home = true;
			EVA01.hideOnMinimap = false;
            EVA01.drawBoatMark = true;
			EVA01.can_edit_traits = true;
			EVA01.canReceiveTraits = true;
			EVA01.flying = false;
			//EVA01.tech = "EVA01s";
			EVA01.very_high_flyer = false;
            EVA01.isBoat = false;
			EVA01.dieOnBlocks = false;
			EVA01.ignoreBlocks = false;
			EVA01.moveFromBlock = true;
			EVA01.procreate = false;
		    EVA01.inspect_children = false;
            EVA01.inspect_experience = true;
			EVA01.canBeCitizen = true;
            EVA01.inspect_kills = true;
            EVA01.use_items = true;
			EVA01.oceanCreature = false;
            EVA01.take_items = true;
            EVA01.nameLocale = "EVA01";
            EVA01.nameTemplate = "Modern_Names";
			EVA01.shadow = false;
			EVA01.job = "attacker";
            EVA01.icon = "iconEVA01";
			//AssetManager.actor_library.CallMethod("addTrait", "EVA01");
			AssetManager.actor_library.CallMethod("loadShadow", EVA01);
            EVA01.animation_walk = "walk_0,walk_1,walk_2,walk_3";
			EVA01.animation_idle = "walk_0";
			EVA01.body_separate_part_head = true;
            EVA01.texture_path = "EVA01";
            EVA01.texture_heads = "EVA01head";
   AssetManager.actor_library.addColorSet("eva00");
      AssetManager.actor_library.addColorSet("eva01");
	     AssetManager.actor_library.addColorSet("eva02");
		    AssetManager.actor_library.addColorSet("eva03");
			AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			EVA01.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(EVA01);
			Localization.addLocalization(EVA01.nameLocale, EVA01.nameLocale);

						var SpaceMarine = AssetManager.actor_library.clone("SpaceMarine","_mob");
			//ActorAsset heli = new ActorAsset();
           // SpaceMarine.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			SpaceMarine.race = "human";
			SpaceMarine.kingdom = "ModernKingdom";
            SpaceMarine.base_stats[S.health] = 500f;
            SpaceMarine.base_stats[S.speed] = 70f;
            SpaceMarine.base_stats[S.armor] = 100f;
            SpaceMarine.base_stats[S.damage] = 40f;
            SpaceMarine.base_stats[S.scale] = 0.1f;
            SpaceMarine.base_stats[S.attack_speed] = 20;
			SpaceMarine.base_stats[S.range] = 10f;
			SpaceMarine.defaultAttack = "tankshellattack";
            SpaceMarine.drawBoatMark_big = true;
            SpaceMarine.skipFightLogic = false;
            SpaceMarine.inspect_stats = true;
			SpaceMarine.landCreature = true;
			SpaceMarine.inspect_home = true;
			SpaceMarine.hideOnMinimap = false;
            SpaceMarine.drawBoatMark = true;
			SpaceMarine.can_edit_traits = true;
			SpaceMarine.canReceiveTraits = true;
			SpaceMarine.flying = false;
			//SpaceMarine.tech = "Soldiers";
			SpaceMarine.very_high_flyer = false;
            SpaceMarine.isBoat = false;
			SpaceMarine.dieOnBlocks = false;
			SpaceMarine.ignoreBlocks = false;
			SpaceMarine.moveFromBlock = true;
			SpaceMarine.procreate = false;
		    SpaceMarine.inspect_children = false;
            SpaceMarine.inspect_experience = true;
			SpaceMarine.canBeCitizen = true;
            SpaceMarine.inspect_kills = true;
            SpaceMarine.use_items = false;
			SpaceMarine.oceanCreature = false;
            SpaceMarine.take_items = false;
            SpaceMarine.nameLocale = "SpaceMarine";
            SpaceMarine.nameTemplate = "Modern_Names";
			SpaceMarine.job = "attacker";
            SpaceMarine.icon = "iconSoldier";
			//AssetManager.actor_library.CallMethod("addTrait", "SpaceMarine");
			AssetManager.actor_library.CallMethod("loadShadow", SpaceMarine);
            SpaceMarine.animation_walk = "walk_0,walk_1,walk_2,walk_3";
			SpaceMarine.animation_idle = "idle_0";
            SpaceMarine.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            SpaceMarine.texture_path = "SpaceMarine";
			AssetManager.actor_library.addColorSet("heliColor");
			AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			SpaceMarine.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(SpaceMarine);
			Localization.addLocalization(SpaceMarine.nameLocale, SpaceMarine.nameLocale);
		  
			var Xiexel = AssetManager.actor_library.clone("Xiexel","_mob");
			//ActorAsset heli = new ActorAsset();
           // Xiexel.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			Xiexel.race = "human";
			Xiexel.kingdom = "ModernKingdom";
            Xiexel.base_stats[S.health] = 9999999f;
            Xiexel.base_stats[S.speed] = 9999999f;
            Xiexel.base_stats[S.armor] = 9999999f;
            Xiexel.base_stats[S.damage] = 9999999f;
            Xiexel.base_stats[S.scale] = 0.3f;
            Xiexel.base_stats[S.attack_speed] = 9999999f;
			Xiexel.base_stats[S.range] = 9999999f;
			Xiexel.base_stats[S.warfare] = 9999999f;
            Xiexel.drawBoatMark_big = true;
            Xiexel.skipFightLogic = false;
            Xiexel.inspect_stats = true;
			Xiexel.landCreature = true;
			Xiexel.inspect_home = true;
			Xiexel.hideOnMinimap = false;
            Xiexel.drawBoatMark = true;
			Xiexel.can_edit_traits = true;
			Xiexel.canReceiveTraits = true;
			Xiexel.flying = false;
			//Xiexel.tech = "Xiexels";
			Xiexel.very_high_flyer = false;
            Xiexel.isBoat = false;
			Xiexel.dieOnBlocks = false;
			Xiexel.ignoreBlocks = false;
			Xiexel.moveFromBlock = true;
			Xiexel.procreate = false;
		    Xiexel.inspect_children = false;
            Xiexel.inspect_experience = true;
			Xiexel.defaultWeapons = List.Of<string>(new string[]
				{
			 "XM8",
			 "Mp5"
				});
			Xiexel.defaultWeaponsMaterial = List.Of<string>(new string[]
				{
				 "iron"
				});
			Xiexel.canBeCitizen = true;
            Xiexel.inspect_kills = true;
            Xiexel.use_items = true;
			Xiexel.oceanCreature = false;
            Xiexel.take_items = true;
            Xiexel.nameLocale = "Xiexel";
			Xiexel.job = "attacker";
            Xiexel.icon = "iconXiexel";
			//AssetManager.actor_library.CallMethod("addTrait", "Xiexel");
			AssetManager.actor_library.CallMethod("loadShadow", Xiexel);
            Xiexel.animation_walk = "walk_0";
			Xiexel.animation_idle = "walk_0";
            Xiexel.animation_swim = "walk_0";
            Xiexel.texture_path = "Xiexel";
			AssetManager.actor_library.addColorSet("heliColor");
			Xiexel.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(Xiexel);
			Localization.addLocalization(Xiexel.nameLocale, Xiexel.nameLocale);
		  		  


		}
		}
}
