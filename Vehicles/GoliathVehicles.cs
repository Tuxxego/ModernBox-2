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
            P9000.base_stats[S.damage] = 100f;
            P9000.base_stats[S.scale] = 0.1f;
            P9000.base_stats[S.attack_speed] = 0;
			P9000.disablePunchAttackAnimation = true;
			P9000.base_stats[S.range] = 70f;
			P9000.base_stats[S.knockback_reduction] = 300f;
            P9000.drawBoatMark_big = true;
            P9000.skipFightLogic = false;
            P9000.inspect_stats = true;
			P9000.landCreature = true;
			P9000.inspect_home = true;
			P9000.hideOnMinimap = false;
            P9000.drawBoatMark = true;
			P9000.can_edit_traits = true;
			P9000.canReceiveTraits = true;
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
			AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			AssetManager.actor_library.CallMethod("addTrait", "P9000");
			 AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
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

						var EliteP9000 = AssetManager.actor_library.clone("EliteP9000","_mob");
			//ActorAsset heli = new ActorAsset();
           // EliteP9000.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			EliteP9000.race = "human";
			EliteP9000.kingdom = "ModernKingdom";
            EliteP9000.base_stats[S.health] = 35000f;
            EliteP9000.base_stats[S.speed] = 70f;
            EliteP9000.base_stats[S.armor] = 100f;
            EliteP9000.base_stats[S.damage] = 500f;
            EliteP9000.base_stats[S.scale] = 0.1f;
            EliteP9000.base_stats[S.attack_speed] = 0;
            EliteP9000.disablePunchAttackAnimation = true;
			EliteP9000.base_stats[S.range] = 80f;
			EliteP9000.base_stats[S.knockback_reduction] = 300f;
            EliteP9000.drawBoatMark_big = true;
            EliteP9000.skipFightLogic = false;
            EliteP9000.inspect_stats = true;
			EliteP9000.landCreature = true;
			EliteP9000.inspect_home = true;
			EliteP9000.hideOnMinimap = false;
            EliteP9000.drawBoatMark = true;
			EliteP9000.can_edit_traits = true;
			EliteP9000.canReceiveTraits = true;
			EliteP9000.flying = false;
			//EliteP9000.tech = "P9000s";
			EliteP9000.very_high_flyer = false;
			EliteP9000.defaultAttack = "bigplasmabomb";
            EliteP9000.isBoat = false;
			EliteP9000.dieOnBlocks = true;
			EliteP9000.ignoreBlocks = false;
			//EliteP9000.moveFromBlock = false;
			EliteP9000.procreate = false;
		    EliteP9000.inspect_children = false;
            EliteP9000.inspect_experience = true;
			EliteP9000.canBeCitizen = true;
            EliteP9000.inspect_kills = true;
            EliteP9000.use_items = false;
			EliteP9000.oceanCreature = false;
            EliteP9000.take_items = false;
            EliteP9000.nameLocale = "P9000";
            EliteP9000.nameTemplate = "Jet_Names";
			EliteP9000.job = "attacker";
            EliteP9000.icon = "iconP9000";
			AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			AssetManager.actor_library.CallMethod("addTrait", "P9000");
			AssetManager.actor_library.CallMethod("loadShadow", EliteP9000);
			AssetManager.actor_library.CallMethod("addTrait", "immortal");
			 AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
            EliteP9000.animation_walk = "walk_0,walk_1,walk_2,walk_3";
			EliteP9000.animation_idle = "walk_0,walk_1,walk_2,walk_3";
            EliteP9000.animation_swim = "walk_0,walk_1,walk_2,walk_3";
            EliteP9000.texture_path = "EliteP9000";
			AssetManager.actor_library.addColorSet("heliColor");
			EliteP9000.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(EliteP9000);
			Localization.addLocalization(EliteP9000.nameLocale, EliteP9000.nameLocale);
			
			var Terran = AssetManager.actor_library.clone("Terran","_mob");
			//ActorAsset heli = new ActorAsset();
           // Terran.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			Terran.race = "human";
			Terran.kingdom = "ModernKingdom";
            Terran.base_stats[S.health] = 200f;
            Terran.base_stats[S.speed] = 70f;
            Terran.base_stats[S.armor] = 15f;
            Terran.base_stats[S.damage] = 10f;
            Terran.base_stats[S.scale] = 0.1f;
            Terran.base_stats[S.attack_speed] = 3005;
			Terran.base_stats[S.range] = 30f;
			Terran.base_stats[S.knockback_reduction] = 300f;
            Terran.drawBoatMark_big = true;
            Terran.skipFightLogic = false;
            Terran.inspect_stats = true;
			Terran.landCreature = true;
			Terran.inspect_home = true;
			Terran.hideOnMinimap = false;
            Terran.drawBoatMark = true;
			 Terran.disablePunchAttackAnimation = true;
			Terran.can_edit_traits = true;
			Terran.canReceiveTraits = true;
			Terran.flying = false;
			//Terran.tech = "Terrans";
			Terran.very_high_flyer = false;
			Terran.defaultAttack = "Minigun";
            Terran.isBoat = false;
			Terran.dieOnBlocks = true;
			Terran.ignoreBlocks = false;
			//Terran.moveFromBlock = false;
			Terran.procreate = false;
		    Terran.inspect_children = false;
            Terran.inspect_experience = true;
			Terran.canBeCitizen = true;
            Terran.inspect_kills = true;
            Terran.use_items = false;
			Terran.oceanCreature = false;
            Terran.take_items = false;
            Terran.nameLocale = "Terran";
            Terran.nameTemplate = "Jet_Names";
			Terran.job = "attacker";
            Terran.icon = "iconTerran";
			AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			AssetManager.actor_library.CallMethod("addTrait", "Terran");
			 AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
			AssetManager.actor_library.CallMethod("loadShadow", Terran);
			AssetManager.actor_library.CallMethod("addTrait", "immortal");
            Terran.animation_walk = "walk_0,walk_1,walk_2,walk_3,walk_4,walk_5";
			Terran.animation_idle = "walk_0";
            Terran.animation_swim = "swim_0,swim_1,swim_2";
            Terran.texture_path = "Terran";
			AssetManager.actor_library.addColorSet("heliColor");
			Terran.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(Terran);
			Localization.addLocalization(Terran.nameLocale, Terran.nameLocale);

			var dreadnaught = AssetManager.actor_library.clone("dreadnaught","_mob");
			//ActorAsset heli = new ActorAsset();
           // dreadnaught.get_override_sprite = AssetManager.actor_library.get("_boat").get_override_sprite;
			dreadnaught.race = "human";
			dreadnaught.kingdom = "ModernKingdom";
            dreadnaught.base_stats[S.health] = 2000f;
            dreadnaught.base_stats[S.speed] = 30f;
            dreadnaught.base_stats[S.armor] = 55f;
            dreadnaught.base_stats[S.damage] = 20f;
            dreadnaught.base_stats[S.scale] = 0.1f;
            dreadnaught.base_stats[S.attack_speed] = 305;
			dreadnaught.base_stats[S.range] = 20f;
			dreadnaught.base_stats[S.knockback_reduction] = 300f;
            dreadnaught.drawBoatMark_big = true;
            dreadnaught.skipFightLogic = false;
            dreadnaught.inspect_stats = true;
			dreadnaught.landCreature = true;
			dreadnaught.inspect_home = true;
			dreadnaught.hideOnMinimap = false;
            dreadnaught.drawBoatMark = true;
			 dreadnaught.disablePunchAttackAnimation = true;
			dreadnaught.can_edit_traits = true;
			dreadnaught.canReceiveTraits = true;
			dreadnaught.flying = false;
			//dreadnaught.tech = "Terrans";
			dreadnaught.very_high_flyer = false;
			dreadnaught.defaultAttack = "Minigun";
            dreadnaught.isBoat = false;
			dreadnaught.dieOnBlocks = true;
			dreadnaught.ignoreBlocks = false;
			//dreadnaught.moveFromBlock = false;
			dreadnaught.procreate = false;
		    dreadnaught.inspect_children = false;
            dreadnaught.inspect_experience = true;
			dreadnaught.canBeCitizen = true;
            dreadnaught.inspect_kills = true;
            dreadnaught.use_items = false;
			dreadnaught.oceanCreature = false;
            dreadnaught.take_items = false;
            dreadnaught.nameLocale = "dreadnaught";
            dreadnaught.nameTemplate = "Jet_Names";
			dreadnaught.job = "attacker";
            dreadnaught.icon = "iconTerran";
			AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			AssetManager.actor_library.CallMethod("addTrait", "dreadnaught");
			 AssetManager.actor_library.CallMethod("addTrait", "fire_proof");
			AssetManager.actor_library.CallMethod("loadShadow", dreadnaught);
			AssetManager.actor_library.CallMethod("addTrait", "immortal");
            dreadnaught.animation_walk = "walk_0,walk_1,walk_2,walk_3";
			dreadnaught.animation_idle = "walk_0";
            dreadnaught.animation_swim = "swim_0,swim_1,swim_2";
            dreadnaught.texture_path = "dreadnaught";
			AssetManager.actor_library.addColorSet("heliColor");
			dreadnaught.color = Toolbox.makeColor("#33724D");
            AssetManager.actor_library.add(dreadnaught);
			Localization.addLocalization(dreadnaught.nameLocale, dreadnaught.nameLocale);
			
		}
	}
}
