using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using TuxModLoader;
using UnityEngine.UI;
using TuxModLoader.Reflection;

namespace M3
{
	public class PowersAndDrops
	{
		public static GodPower FirePower;

	        public static bool action_spawn_jet(WorldTile pTile, string pPowerID)
        {
        //    if (pTile.zone.city == null)
        //    {
         //       WorldTip.showNow("You must spawn this vehicle within a kingdom.", true, "top", 3f);
          //      return false;
          //  }

        //    City pCity = pTile.zone.city;

            Actor actor = spawnUnit(pTile, pPowerID);
            if (actor == null)
            {
                return false;
            }

            // Get the internal 'kingdom' field using reflection
        //    object pKingdom = TuxModLoader.Reflection.ReflectionHelper.GetFieldValue<object>(pCity, "kingdom");

            // Use reflection to call setKingdom and setCity
       //     TuxModLoader.Reflection.ReflectionHelper.InvokeMethod(actor, "setKingdom", pKingdom);
        //    TuxModLoader.Reflection.ReflectionHelper.InvokeMethod(actor, "setCity", pCity);

            return true;
        }

        public static bool callSpawnUnit(WorldTile pTile, string pPowerID)
        {
            TuxModLoader.Reflection.ReflectionHelper.InvokeMethod(AssetManager.powers, "spawnUnit", pTile, pPowerID);
            return true;
        }

		public static Actor spawnUnit(WorldTile pTile, string pPowerID)
		{
			Debug.Log($"[spawnUnit] Called with pTile: {pTile}, pPowerID: {pPowerID}");

			if (AssetManager.powers == null)
			{
				Debug.LogError("[spawnUnit] AssetManager.powers is null!");
				return null;
			}

			GodPower godPower = AssetManager.powers.get(pPowerID);
			if (godPower == null)
			{
				Debug.LogError($"[spawnUnit] GodPower with ID '{pPowerID}' not found!");
				return null;
			}

			Debug.Log($"[spawnUnit] Got GodPower: {godPower.id}");

			MusicBox.playSound("event:/SFX/UNIQUE/SpawnWhoosh", (float)pTile.pos.x, (float)pTile.pos.y, false, false);
			Debug.Log($"[spawnUnit] Played sound at ({pTile.pos.x}, {pTile.pos.y})");

			if (godPower.id == SA.sheep && pTile.Type.lava)
			{
				Debug.Log("[spawnUnit] Triggering achievementSacrifice for sheep in lava.");
				AchievementLibrary.achievementSacrifice.check(null, null, null);
			}

			EffectsLibrary.spawn("fx_spawn", pTile, null, null, 0f, -1f, -1f);
			Debug.Log("[spawnUnit] Spawned 'fx_spawn' effect.");

			string text;
			if (godPower.actor_asset_ids != null && godPower.actor_asset_ids.Length > 0)
			{
				text = godPower.actor_asset_ids.GetRandom<string>();
				Debug.Log($"[spawnUnit] Selected random actor from actor_asset_ids: {text}");
			}
			else
			{
				text = godPower.actor_asset_id;
				Debug.Log($"[spawnUnit] Using fallback actor_asset_id: {text}");
			}

			if (World.world == null || World.world.units == null)
			{
				Debug.LogError("[spawnUnit] World or World.units is null!");
				return null;
			}

			Actor actor = World.world.units.spawnNewUnit(text, pTile, true);
			if (actor == null)
			{
				Debug.LogError("[spawnUnit] spawnNewUnit returned null!");
				return null;
			}

			actor.addTrait("miracle_born", false);
			Debug.Log($"[spawnUnit] Spawned actor '{text}' at tile {pTile.pos}. Added trait 'miracle_born'.");

			return actor;
		}
		
		public void Init()
		{
			
            DropAsset FireStuff = new DropBuilder()
                .SetId("firebombs")
                .SetTexturePath("drops/drop_bomb")
                .SetDefaultScale(0.2f)
                .SetFallingHeight(new Vector3(60f, 70f, 0f))
                .SetSoundLaunch("event:/SFX/DROPS/DropLaunchBombSmall")
                .SetActionLanded(action_FireClick)
                .SetDropType(DropType.DropBomb)
                .Build();
				
            FirePower = new PowerBuilder()
                .SetID("FireBomb")
                .SetName("FireBomb")
                .SetDropId("firebombs")
                .SetAction(Stuff_Drop)
                .SetSurprisesUnits(true)
				.SetShowToolSizes(true)
				.SetCachedDropAsset(FireStuff)
                .Build();
				
				GodPower ALIENPower = AssetManager.powers.clone("spawn_tank", "$template_spawn_actor$");
				ALIENPower.name = "spawn_tank";
				ALIENPower.actor_asset_id = "Tank";
				ALIENPower.click_action = new PowerActionWithID(action_spawn_jet);
		
		            var sprite = Resources.Load<Sprite>("ui/Icons/name_1");

        //     string pBasePath = "actors/species/";
        //     var Tank = AssetManager.actor_library.clone("Tank", "$mob$");
        //     Tank.base_stats["health"] = 1000f;
        //     Tank.base_stats["damage"] = 100f;
        //     Tank.base_stats["speed"] = 40f;
        //     Tank.base_stats["scale"] = 0.3f;
        //     Tank.base_stats["size"] = 2f;
        //     Tank.base_stats["mass"] = 4f;
        //     Tank.base_stats["mass_2"] = 2500f;
        //     Tank.base_stats["targets"] = 20f;
        //     Tank.base_stats["lifespan"] = 0.0f;
        //     Tank.inspect_stats = true;
        //     Tank.inspect_home = true;
        //     //Tank.hideOnMinimap = false;
        //     Tank.inspect_children = false;
        //     Tank.inspect_experience = true;
        //     Tank.texture_asset = new ActorTextureSubAsset("actors/Tank/");
        //     Tank.special = true;
        //     Tank.has_advanced_textures = false;
        //     Tank.inspect_kills = true;
        //     Tank.use_items = false;
        //     ReflectionHelper.SetFieldValue(Tank, "_cached_sprite", sprite);
        //   //  Tank.texture_id = "t_Tank";
        //     Tank.can_have_subspecies = false;
        //     Tank.take_items = false;
		// 	Tank.animation_walk = ActorAnimationSequences.walk_0_3;
		// 	Tank.animation_idle = ActorAnimationSequences.walk_0;
		// 	Tank.animation_swim = ActorAnimationSequences.swim_0_3;
        //     //Tank.job = "attacker";
        //     Tank.icon = "iconTank";
        //     //Tank.texture_path = "Tank";
        //     //AssetManager.actor_library.addColorSet("heliColor");
        //     Tank.color = Toolbox.makeColor("#33724D");
        //     AssetManager.actor_library.add(Tank);
        //     //Localization.addLocalization(Tank.nameLocale, Tank.nameLocale);


        //     ReflectionHelper.InvokeMethod(AssetManager.actor_library, "loadTexturesAndSprites", Tank);

	var Tank = AssetManager.actor_library.clone("Tank","$basic_unit$");
			Tank.base_stats["mass_2"] = 200f;
			Tank.base_stats["stamina"] = 500f;
            Tank.base_stats["scale"] = 0.2f;
            Tank.base_stats["size"] = 2f;
		Tank.base_stats["mass"] = 1000f;
        Tank.base_stats["health"] = 300f;
		Tank.base_stats["speed"] = 10f;
		Tank.base_stats["armor"] = 20f;
		Tank.base_stats["attack_speed"] = 1f;
		Tank.base_stats["damage"] = 30f;
		Tank.base_stats["knockback"] = 2f;
		Tank.base_stats["accuracy"] = 1f;
		Tank.base_stats["targets"] = 1f;
		Tank.base_stats["area_of_effect"] = 0.5f;
		Tank.base_stats["range"] = 1f;
		Tank.base_stats["critical_damage_multiplier"] = 2f;
		Tank.base_stats["scale"] = 0.1f;
		Tank.base_stats["multiplier_supply_timer"] = 1f;
			Tank.sound_hit = "event:/SFX/HIT/HitWood";
        Tank.base_throwing_range = 7f;
		Tank.affected_by_dust = false;
			Tank.inspect_children = false;
		    Tank.default_attack = "base_attack";
		    Tank.icon = "iconBoat";
		    Tank.shadow_texture = "unitShadow_6";
		    Tank.texture_asset = new ActorTextureSubAsset("actors/Tank/");
            Tank.special = true;
        Tank.has_advanced_textures = false;
        Tank.cost = new ConstructionCost(1, 0, 0, 1);
        Tank.animation_walk = ActorAnimationSequences.walk_0_3;
        Tank.animation_idle = ActorAnimationSequences.walk_0;
		Tank.animation_swim = ActorAnimationSequences.swim_0_3;
	//	Tank.name_template_sets = AssetLibrary<ActorAsset>.a<string>("assimilator_set");
		Tank.kingdom_id_civilization = string.Empty;
		Tank.build_order_template_id = string.Empty;
		Tank.disable_jump_animation = true;
		Tank.can_have_subspecies = false;
		Tank.inspect_sex = false;
		Tank.inspect_show_species = false;
		Tank.inspect_generation = false;
		Tank.immune_to_injuries = true;
		Tank.show_on_meta_layer = false;
		Tank.show_in_knowledge_window = false;
		Tank.show_in_taxonomy_tooltip = false;
		Tank.needs_to_be_explored = false;
		Tank.need_colored_sprite = true;
        Tank.allowed_status_tiers = StatusTier.Basic;
		Tank.render_status_effects = false;
        Tank.inspect_avatar_scale = 3f;
		Tank.color_hex = "#000000";
			Tank.force_land_creature = true;
			Tank.inspect_home = true;
			Tank.visible_on_minimap = true;
			Tank.can_edit_traits = true;
             Tank.disable_jump_animation = true;
			Tank.can_receive_traits = true;
			Tank.flying = false;
			//baseoffensiveunit.tech = "baseoffensiveunits";
			Tank.very_high_flyer = false;
			Tank.die_on_blocks = true;
			Tank.ignore_blocks = false;
		    Tank.inspect_children = false;
            Tank.inspect_experience = true;
            Tank.inspect_kills = true;
            Tank.use_items = false;
			Tank.has_baby_form = false;
            Tank.take_items = false;
            Tank.name_locale = "Tank";
        //    Tank.job = AssetLibrary<ActorAsset>.a<string>("decision");
            //Tank.job_attacker = Toolbox.a<string>("attacker");
            Tank.addDecision("check_swearing");
	Tank.addDecision("warrior_try_join_army_group");
	Tank.addDecision("city_walking_to_danger_zone");
	Tank.addDecision("warrior_army_captain_idle_walking_city");
	Tank.addDecision("warrior_army_captain_waiting");
	Tank.addDecision("warrior_army_leader_move_random");
	Tank.addDecision("warrior_army_leader_move_to_attack_target");
	Tank.addDecision("warrior_army_follow_leader");
	Tank.addDecision("warrior_random_move");
	Tank.addDecision("check_warrior_transport");
			Tank.collective_term = "group_gang";
            Tank.prevent_unconscious_rotation = true;
			Tank.use_phenotypes = false;
		Tank.unit_other = true;
		Tank.can_be_surprised = false;
				Tank.has_skin = false;
						Tank.disable_jump_animation = true;
		Tank.can_turn_into_mush = false;
		Tank.can_turn_into_tumor = false;
		Tank.can_turn_into_zombie = false;
		Tank.use_tool_items = false;
				Tank.kingdom_id_wild = "neutral_animals";
				Tank.can_flip = true;
                Tank.check_flip = (BaseSimObject _, WorldTile _) => true;
            Tank.can_talk_with = true;
			Tank.control_can_backstep = true;
			Tank.control_can_jump = true;
			Tank.control_can_kick = true;
			Tank.control_can_dash = true;
			Tank.control_can_talk = true;
			Tank.control_can_swear = true;
			Tank.control_can_steal = true;
			Tank.needs_to_be_explored = false;
			Tank.show_controllable_tip = false;
        Tank.update_z = true;
		Tank.can_be_killed_by_stuff = true;
		Tank.can_be_killed_by_life_eraser = true;
		Tank.can_attack_buildings = true;
		Tank.can_be_moved_by_powers = true;
		Tank.can_be_hurt_by_powers = true;
		Tank.effect_damage = true;
		//Tank.can_flip = true;
		Tank.death_animation_angle = true;
		Tank.can_be_inspected = true;
			//AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
			//AssetManager.actor_library.CallMethod("loadShadow", Tank);
            AssetManager.actor_library.add(Tank);

			Debug.Log($"Custom trait created successfully!");
			 DropAsset pAsset = AssetManager.drops.get("protons");
			 
                    if (pAsset == null)
                    {
                        Debug.LogError("Asset for drop ID 'protons' could not be found.");
                    }
					else {
						Debug.Log("IT WAS FOUND WHAT THE FUCK????");
					}
		}
		
		public static bool Stuff_Drop(WorldTile pTile, GodPower pPower)
		{
			ReflectionHelper.InvokeMethod(AssetManager.powers, "spawnDrops", pTile, pPower);
			return true;
		}

		  public static void action_ProtonClick(WorldTile pTile, string pPowerID) {
			EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 16.3f, 28.9f);
			MapAction.damageWorld(pTile, 2, TerraformLibrary.czar_bomba, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }
		  public static void action_FireClick(WorldTile pTile, string pPowerID) {
				World.world.startShake(pIntensity: 0.5f, pShakeX: true);
				EffectsLibrary.spawn("fx_napalm_flash", pTile);
				EffectsLibrary.spawnAtTileRandomScale("fx_napalm_flash", pTile, 16.3f, 28.9f);
				EffectsLibrary.spawnAtTileRandomScale("fx_explosion_tiny", pTile, 0.15f, 0.3f);
		  }
		  
	}
}