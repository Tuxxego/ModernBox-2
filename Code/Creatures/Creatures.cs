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
    class Creatures : MonoBehaviour
    {
		
  public static readonly string Terlanius;



        public static void init()
        {
            loadAssets();

        }
		
		


        private static void loadAssets()
        {
			

			
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
		}
		
}