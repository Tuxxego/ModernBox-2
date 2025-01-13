//========= MODERNBOX 2.0.1.0 ============//
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
    class GoliathVehicles : MonoBehaviour
    {
		

        public static void init()
        {
            loadAssets();

        }

        private static void loadAssets()
        {

			var P-9000 = AssetManager.actor_library.clone("P-9000","_mob");
			//ActorAsset heli = new ActorAsset();
           // P-9000.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			P-9000.race = "human";
			P-9000.kingdom = "ModernKingdom";
            P-9000.base_stats[S.health] = 20000f;
            P-9000.base_stats[S.speed] = 70f;
            P-9000.base_stats[S.armor] = 100f;
            P-9000.base_stats[S.damage] = 40f;
            P-9000.base_stats[S.scale] = 0.1f;
            P-9000.base_stats[S.attack_speed] = 0;
			P-9000.base_stats[S.range] = 150f;
			P-9000.base_stats[S.knockback_reduction] = 300f;
            P-9000.drawBoatMark_big = true;
            P-9000.skipFightLogic = false;
            P-9000.inspect_stats = true;
			P-9000.landCreature = true;
			P-9000.inspect_home = true;
			P-9000.hideOnMinimap = false;
            P-9000.drawBoatMark = true;
			P-9000.can_edit_traits = false;
			P-9000.canReceiveTraits = false;
			P-9000.flying = false;
			//P-9000.tech = "P-9000s";
			P-9000.very_high_flyer = false;
			P-9000.defaultAttack = "RocketLauncher";
            P-9000.isBoat = false;
			P-9000.dieOnBlocks = true;
			P-9000.ignoreBlocks = false;
			//P-9000.moveFromBlock = false;
			P-9000.procreate = false;
		    P-9000.inspect_children = false;
            P-9000.inspect_experience = true;
			P-9000.canBeCitizen = true;
            P-9000.inspect_kills = true;
            P-9000.use_items = false;
			P-9000.oceanCreature = false;
            P-9000.take_items = false;
            P-9000.nameLocale = "P-9000";
            P-9000.nameTemplate = "Jet_Names";
			P-9000.job = "attacker";
            P-9000.icon = "iconP-9000";
			AssetManager.actor_library.CallMethod("addTrait", "Vehicle");
			AssetManager.actor_library.CallMethod("addTrait", "P-9000");
			AssetManager.actor_library.CallMethod("loadShadow", P-9000);
			AssetManager.actor_library.CallMethod("addTrait", "immortal");
            P-9000.animation_walk = "walk_0,walk_1,walk_2,walk_3";
            P-9000.animation_swim = "swim_0,swim_1";
            P-9000.texture_path = "P-9000";
			AssetManager.actor_library.addColorSet("heliColor");
			P-9000.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(P-9000);
			Localization.addLocalization(P-9000.nameLocale, P-9000.nameLocale);
		}
	}
}