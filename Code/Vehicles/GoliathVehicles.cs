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

			var P9000 = AssetManager.actor_library.clone("P9000","_mob");
			//ActorAsset heli = new ActorAsset();
           // P9000.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			P9000.race = "human";
			P9000.kingdom = "ModernKingdom";
            P9000.base_stats[S.health] = 20000f;
            P9000.base_stats[S.speed] = 70f;
            P9000.base_stats[S.armor] = 100f;
            P9000.base_stats[S.damage] = 40f;
            P9000.base_stats[S.scale] = 0.1f;
            P9000.base_stats[S.attack_speed] = 0;
			P9000.base_stats[S.range] = 150f;
			P9000.base_stats[S.knockback_reduction] = 300f;
            P9000.drawBoatMark_big = true;
            P9000.skipFightLogic = false;
            P9000.inspect_stats = true;
			P9000.landCreature = true;
			P9000.inspect_home = true;
			P9000.hideOnMinimap = false;
            P9000.drawBoatMark = true;
			P9000.can_edit_traits = false;
			P9000.canReceiveTraits = false;
			P9000.flying = false;
			//P9000.tech = "P9000s";
			P9000.very_high_flyer = false;
			P9000.defaultAttack = "bigplasmabomb";
            P9000.isBoat = false;
			P9000.dieOnBlocks = true;
			P9000.ignoreBlocks = false;
			//P9000.moveFromBlock = false;
			P9000.procreate = false;
		    P9000.inspect_children = false;
            P9000.inspect_experience = true;
			P9000.canBeCitizen = true;
            P9000.inspect_kills = true;
            P9000.use_items = false;
			P9000.oceanCreature = false;
            P9000.take_items = false;
            P9000.nameLocale = "P9000";
            P9000.nameTemplate = "Jet_Names";
			P9000.job = "attacker";
            P9000.icon = "iconP9000";
			AssetManager.actor_library.CallMethod("addTrait", "Vehicle");
			AssetManager.actor_library.CallMethod("addTrait", "P9000");
			AssetManager.actor_library.CallMethod("loadShadow", P9000);
			AssetManager.actor_library.CallMethod("addTrait", "immortal");
            P9000.animation_walk = "walk_0,walk_1,walk_2,walk_3";
			P9000.animation_idle = "walk_0,walk_1,walk_2,walk_3";
            P9000.animation_swim = "walk_0,walk_1,walk_2,walk_3";
            P9000.texture_path = "P9000";
			AssetManager.actor_library.addColorSet("heliColor");
			P9000.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(P9000);
			Localization.addLocalization(P9000.nameLocale, P9000.nameLocale);
		}
	}
}