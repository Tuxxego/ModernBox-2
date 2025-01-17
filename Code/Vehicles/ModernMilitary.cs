//========= MODERNBOX 2.1.0.0 ============//
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
			
			var Soldier = AssetManager.actor_library.clone("Soldier","_mob");
			//ActorAsset heli = new ActorAsset();
           // Soldier.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			Soldier.race = "human";
			Soldier.kingdom = "ModernKingdom";
            Soldier.base_stats[S.health] = 100f;
            Soldier.base_stats[S.speed] = 40f;
            Soldier.base_stats[S.armor] = 100f;
            Soldier.base_stats[S.damage] = 40f;
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
            Soldier.animation_swim = "walk_0,walk_1,walk_2,walk_3";
            Soldier.texture_path = "Soldier";
			AssetManager.actor_library.addColorSet("heliColor");
			Soldier.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(Soldier);
			Localization.addLocalization(Soldier.nameLocale, Soldier.nameLocale);
		  
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