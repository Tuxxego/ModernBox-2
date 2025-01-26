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



     TerraformOptions nonannoyingbomb = AssetManager.terraform.clone("nonannoyingbomb", "grenade");
          nonannoyingbomb.id = "nonannoyingbomb";
		nonannoyingbomb.shake = false;
		nonannoyingbomb.explode_tile = true;
		nonannoyingbomb.damageBuildings = true;
		nonannoyingbomb.damage = 0;
		nonannoyingbomb.setFire = true;
          AssetManager.terraform.add(nonannoyingbomb);

            EffectAsset frosttrail = new EffectAsset();
		    frosttrail.id = "frosttrail";
		    frosttrail.use_basic_prefab = true;
		    frosttrail.sorting_layer_id = "EffectsTop";
		    frosttrail.sprite_path = $"effects/frosttrail";
		    frosttrail.draw_light_area = true;
		    frosttrail.show_on_mini_map = true;
		    frosttrail.limit = 80;
		    AssetManager.effects_library.add(frosttrail);

              EffectAsset frostspell = new EffectAsset();
		    frostspell.id = "frostspell";
		    frostspell.use_basic_prefab = true;
		    frostspell.sorting_layer_id = "EffectsTop";
		    frostspell.sprite_path = $"effects/frostspell";
            frostspell.draw_light_area = true;
            frostspell.draw_light_size = 0.2f;
		    frostspell.limit = 80;
		    AssetManager.effects_library.add(frostspell);

              EffectAsset icespikes = new EffectAsset();
		    icespikes.id = "icespikes";
		    icespikes.use_basic_prefab = true;
		    icespikes.sorting_layer_id = "EffectsTop";
		    icespikes.sprite_path = $"effects/fx_basic/icespikes";
		    icespikes.draw_light_area = true;
		    icespikes.draw_light_size = 1f;
		    icespikes.limit = 80;
		    AssetManager.effects_library.add(icespikes);

                ProjectileAsset frostbolt = new ProjectileAsset();
          frostbolt.id = "frostbolt";
          frostbolt.texture = "frostbolt";
          frostbolt.trailEffect_enabled = true;
          frostbolt.trailEffect_id = "frosttrail";
          frostbolt.trailEffect_scale = 0.1f;
          frostbolt.trailEffect_timer = 0.1f;
	      frostbolt.look_at_target = true;
	      frostbolt.endEffect = "icespikes";
	      frostbolt.terraformRange = 2;
          frostbolt.draw_light_area = true;
	      frostbolt.draw_light_size = 0.1f;
	      frostbolt.sound_launch = "event:/SFX/WEAPONS/WeaponRedOrbStart";
	      frostbolt.sound_impact = "event:/SFX/WEAPONS/WeaponRedOrbLand";
          frostbolt.startScale = 0.075f;
          frostbolt.targetScale = 0.2f;
          frostbolt.parabolic = true;
          frostbolt.speed = 15f;
          AssetManager.projectiles.add(frostbolt);


          ProjectileAsset bigsnowball = new ProjectileAsset();
          bigsnowball.id = "bigsnowball";
          bigsnowball.texture = "bigsnowball";
          bigsnowball.trailEffect_enabled = false;
	      bigsnowball.look_at_target = true;
          bigsnowball.draw_light_area = false;
	      bigsnowball.draw_light_size = 0.1f;
          bigsnowball.hitFreeze = true;
	      bigsnowball.sound_launch = "event:/SFX/WEAPONS/WeaponStartThrow";
          bigsnowball.sound_impact = "event:/SFX/WEAPONS/WeaponSnowballLand";
          bigsnowball.startScale = 0.075f;
          bigsnowball.targetScale = 0.4f;
          bigsnowball.parabolic = true;
          bigsnowball.rotate = true;
          bigsnowball.speed = 4f;
          AssetManager.projectiles.add(bigsnowball);

             ProjectileAsset cybermissileprojectile = new ProjectileAsset();
          cybermissileprojectile.id = "cybermissileprojectile";
          cybermissileprojectile.texture = "cybermissileprojectile";
          cybermissileprojectile.trailEffect_enabled = false;
	      cybermissileprojectile.look_at_target = true;
          cybermissileprojectile.draw_light_area = true;
	      cybermissileprojectile.draw_light_size = 1f;
          cybermissileprojectile.terraformOption = "nonannoyingbomb";
          cybermissileprojectile.terraformRange = 1;
	      cybermissileprojectile.sound_launch = "event:/SFX/POWERS/NapalmBomb";
          cybermissileprojectile.sound_impact = "event:/SFX/POWERS/Bomb";
          cybermissileprojectile.startScale = 0.1f;
          cybermissileprojectile.targetScale = 0.1f;
          cybermissileprojectile.parabolic = true;
          cybermissileprojectile.speed = 30f;
          ProjectileAsset cybermissileprojectileeffect = cybermissileprojectile;
          cybermissileprojectileeffect.world_actions = (AttackAction)Delegate.Combine(cybermissileprojectileeffect.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(cybermissileprojectile);

          ProjectileAsset artilleryshell = new ProjectileAsset();
          artilleryshell.id = "artilleryshell";
          artilleryshell.texture = "artilleryshell";
          artilleryshell.trailEffect_enabled = false;
	      artilleryshell.look_at_target = true;
          artilleryshell.draw_light_area = true;
	      artilleryshell.draw_light_size = 1f;
          artilleryshell.terraformOption = "nonannoyingbomb";
          artilleryshell.terraformRange = 3;
	      artilleryshell.sound_launch = "event:/SFX/POWERS/NapalmBomb";
          artilleryshell.sound_impact = "event:/SFX/POWERS/Bomb";
          artilleryshell.startScale = 0.2f;
          artilleryshell.targetScale = 0.2f;
          artilleryshell.parabolic = true;
          artilleryshell.speed = 19f;
          ProjectileAsset shellboomboomeffect = artilleryshell;
          shellboomboomeffect.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(artilleryshell);

           ProjectileAsset tankshell = new ProjectileAsset();
          tankshell.id = "tankshell";
          tankshell.texture = "artilleryshell";
          tankshell.trailEffect_enabled = false;
	      tankshell.look_at_target = true;
          tankshell.draw_light_area = true;
	      tankshell.draw_light_size = 1f;
          tankshell.terraformOption = "nonannoyingbomb";
          tankshell.terraformRange = 3;
	      tankshell.sound_launch = "event:/SFX/POWERS/NapalmBomb";
          tankshell.sound_impact = "event:/SFX/POWERS/Bomb";
          tankshell.startScale = 0.2f;
          tankshell.targetScale = 0.2f;
          tankshell.parabolic = false;
          tankshell.speed = 45f;
          ProjectileAsset shellboomboomeffect1 = tankshell;
          shellboomboomeffect1.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect1.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(tankshell);

        ProjectileAsset crabartilleryshell = new ProjectileAsset();
          crabartilleryshell.id = "crabartilleryshell";
          crabartilleryshell.texture = "artilleryshell";
          crabartilleryshell.trailEffect_enabled = false;
	      crabartilleryshell.look_at_target = true;
          crabartilleryshell.draw_light_area = true;
	      crabartilleryshell.draw_light_size = 1f;
          crabartilleryshell.terraformOption = "crab_bomb";
          crabartilleryshell.terraformRange = 5;
          crabartilleryshell.endEffect = "fx_explosion_huge";
	      crabartilleryshell.sound_launch = "event:/SFX/POWERS/NapalmBomb";
          crabartilleryshell.sound_impact = "event:/SFX/POWERS/Bomb";
          crabartilleryshell.startScale = 1f;
          crabartilleryshell.targetScale = 1f;
          crabartilleryshell.parabolic = true;
          crabartilleryshell.speed = 20f;
          ProjectileAsset shellboomboomeffecto = crabartilleryshell;
          shellboomboomeffecto.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffecto.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(crabartilleryshell);


             ProjectileAsset bigbomb = new ProjectileAsset();
          bigbomb.id = "bigbomb";
          bigbomb.texture = "bigbomb";
          bigbomb.trailEffect_enabled = false;
	      bigbomb.look_at_target = true;
          bigbomb.draw_light_area = true;
	      bigbomb.draw_light_size = 1f;
          bigbomb.terraformOption = "nonannoyingbomb";
          bigbomb.terraformRange = 6;
	      bigbomb.sound_launch = "event:/SFX/POWERS/NapalmBomb";
          bigbomb.sound_impact = "event:/SFX/POWERS/Bomb";
          bigbomb.startScale = 0.2f;
          bigbomb.targetScale = 0.2f;
          bigbomb.parabolic = true;
          bigbomb.speed = 20f;
          ProjectileAsset bombasticlolxd = bigbomb;
          bombasticlolxd.world_actions = (AttackAction)Delegate.Combine(bombasticlolxd.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(bigbomb);

          ProjectileAsset seismicrod = new ProjectileAsset();
          seismicrod.id = "seismicrod";
          seismicrod.texture = "seismicrod";
          seismicrod.trailEffect_enabled = false;
	      seismicrod.look_at_target = true;
          seismicrod.draw_light_area = true;
	      seismicrod.draw_light_size = 1f;
          seismicrod.terraformOption = "nonannoyingbomb";
          seismicrod.terraformRange = 20;
	      seismicrod.sound_launch = "event:/SFX/POWERS/NapalmBomb";
          seismicrod.sound_impact = "event:/SFX/NATURE/EarthQuake";
          seismicrod.startScale = 0.3f;
          seismicrod.targetScale = 0.3f;
          seismicrod.parabolic = false;
          seismicrod.speed = 10f;
           ProjectileAsset bombasticlolxd1 = seismicrod;
          bombasticlolxd1.world_actions = (AttackAction)Delegate.Combine(bombasticlolxd1.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(seismicrod);


             ItemAsset icebolt = AssetManager.items.clone("icebolt", "_range");
            icebolt.id = "icebolt";
            icebolt.projectile = "frostbolt";
            icebolt.materials = List.Of<string>(new string[] { "base" });
            icebolt.base_stats[S.targets] = 1;
            icebolt.base_stats[S.range] = 10f;
            icebolt.base_stats[S.projectiles] = 1;
            icebolt.base_stats[S.critical_chance] = 0.3f;
		    icebolt.base_stats[S.critical_damage_multiplier] = 0.4f;
            icebolt.item_modifiers = List.Of<string>("ice");
            icebolt.path_slash_animation = "effects/slashes/slash_punch";

            ItemAsset snowthrow = AssetManager.items.clone("snowthrow", "_range");
            snowthrow.id = "snowthrow";
            snowthrow.projectile = "bigsnowball";
            snowthrow.materials = List.Of<string>(new string[] { "base" });
            snowthrow.base_stats[S.targets] = 10;
            snowthrow.base_stats[S.range] = 16f;
            snowthrow.base_stats[S.projectiles] = 1;
            snowthrow.base_stats[S.critical_chance] = 0.3f;
		    snowthrow.base_stats[S.critical_damage_multiplier] = 0.8f;
            snowthrow.item_modifiers = List.Of<string>("ice");
            snowthrow.path_slash_animation = "effects/slashes/slash_punch";

  ItemAsset singleshot = AssetManager.items.clone("singleshot", "_range");
            singleshot.id = "singleshot";
            singleshot.projectile = "shotgun_bullet";
            singleshot.materials = List.Of<string>(new string[] { "base" });
        singleshot.base_stats[S.projectiles] = 1f;
		singleshot.base_stats[S.attack_speed] = 50f;
		singleshot.base_stats[S.range] = 6f;
		singleshot.base_stats[S.targets] = 1f;
		singleshot.base_stats[S.damage] = 10f;
		singleshot.base_stats[S.damage_range] = 0.5f;
            singleshot.path_slash_animation = "effects/slashes/slash_punch";

             ItemAsset machinegunery = AssetManager.items.clone("machinegunery", "_range");
            machinegunery.id = "machinegunery";
            machinegunery.projectile = "shotgun_bullet";
            machinegunery.materials = List.Of<string>(new string[] { "base" });
        machinegunery.base_stats[S.projectiles] = 1f;
		machinegunery.base_stats[S.attack_speed] = 10000f;
		machinegunery.base_stats[S.range] = 12f;
		machinegunery.base_stats[S.targets] = 1f;
		machinegunery.base_stats[S.damage] = 3f;
		machinegunery.base_stats[S.damage_range] = 0.1f;
            machinegunery.path_slash_animation = "effects/slashes/slash_punch";

      ItemAsset artillerystriker = AssetManager.items.clone("artillerystriker", "_range");
            artillerystriker.id = "artillerystriker";
            artillerystriker.projectile = "artilleryshell";
            artillerystriker.materials = List.Of<string>(new string[] { "base" });
        artillerystriker.base_stats[S.projectiles] = 1f;
		artillerystriker.base_stats[S.attack_speed] = 0.1f;
		artillerystriker.base_stats[S.range] = 30f;
		artillerystriker.base_stats[S.targets] = 1f;
		artillerystriker.base_stats[S.damage] = 60f;
		artillerystriker.base_stats[S.damage_range] = 0.7f;
            artillerystriker.path_slash_animation = "effects/slashes/slash_punch";


            ItemAsset tankshellattack = AssetManager.items.clone("tankshellattack", "_range");
            tankshellattack.id = "tankshellattack";
            tankshellattack.projectile = "tankshell";
            tankshellattack.materials = List.Of<string>(new string[] { "base" });
        tankshellattack.base_stats[S.projectiles] = 1f;
		tankshellattack.base_stats[S.attack_speed] = 0.1f;
		tankshellattack.base_stats[S.range] = 30f;
		tankshellattack.base_stats[S.targets] = 3f;
		tankshellattack.base_stats[S.damage] = 60f;
		tankshellattack.base_stats[S.damage_range] = 0.7f;
            tankshellattack.path_slash_animation = "effects/slashes/slash_punch";

                 ItemAsset crabartillery = AssetManager.items.clone("crabartillery", "_range");
            crabartillery.id = "crabartillery";
            crabartillery.projectile = "crabartilleryshell";
            crabartillery.materials = List.Of<string>(new string[] { "base" });
        crabartillery.base_stats[S.projectiles] = 4f;
		crabartillery.base_stats[S.attack_speed] = 0.1f;
		crabartillery.base_stats[S.range] = 30f;
		crabartillery.base_stats[S.targets] = 1f;
		crabartillery.base_stats[S.damage] = 100f;
		crabartillery.base_stats[S.damage_range] = 0.7f;
            crabartillery.path_slash_animation = "effects/slashes/slash_punch";

      ItemAsset bomberino = AssetManager.items.clone("bomberino", "_range");
            bomberino.id = "bomberino";
            bomberino.projectile = "bigbomb";
            bomberino.materials = List.Of<string>(new string[] { "base" });
        bomberino.base_stats[S.projectiles] = 1f;
		bomberino.base_stats[S.attack_speed] = 0.01f;
		bomberino.base_stats[S.range] = 3f;
		bomberino.base_stats[S.targets] = 7f;
		bomberino.base_stats[S.damage] = 30f;
		bomberino.base_stats[S.damage_range] = 0.5f;
            bomberino.path_slash_animation = "effects/slashes/slash_punch";

      ItemAsset destroyerbot = AssetManager.items.clone("destroyerbot", "_range");
            destroyerbot.id = "destroyerbot";
            destroyerbot.projectile = "seismicrod";
            destroyerbot.materials = List.Of<string>(new string[] { "base" });
        destroyerbot.base_stats[S.projectiles] = 1f;
		destroyerbot.base_stats[S.attack_speed] = 0.1f;
		destroyerbot.base_stats[S.range] = 10f;
		destroyerbot.base_stats[S.targets] = 10f;
		destroyerbot.base_stats[S.damage] = 20f;
		destroyerbot.base_stats[S.damage_range] = 0.5f;
            destroyerbot.path_slash_animation = "effects/slashes/slash_punch";






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
            min_world_population = 500,
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
    newActor.data.skin = originalActor.data.skin;
    newActor.data.skin_set = originalActor.data.skin_set;

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
