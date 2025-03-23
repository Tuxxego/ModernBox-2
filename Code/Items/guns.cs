//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using NCMS.Utils;

namespace M2
{
    class guns
    {
        public static void init()
        {

            makecraftable();

             TerraformOptions nonannoyingbomb = AssetManager.terraform.clone("nonannoyingbomb", "grenade");
          nonannoyingbomb.id = "nonannoyingbomb";
		nonannoyingbomb.shake = false;
		nonannoyingbomb.explode_tile = false;
		nonannoyingbomb.damageBuildings = true;
		nonannoyingbomb.damage = 0;
        nonannoyingbomb.explode_strength = 2;
		nonannoyingbomb.applies_to_high_flyers = false;
		nonannoyingbomb.setFire = true;
        nonannoyingbomb.removeRuins = false;
          AssetManager.terraform.add(nonannoyingbomb);

        TerraformOptions nonannoyingbullet = AssetManager.terraform.clone("nonannoyingbullet", "grenade");
          nonannoyingbullet.id = "nonannoyingbullet";
		nonannoyingbullet.shake = false;
		nonannoyingbullet.explode_tile = false;
		nonannoyingbullet.damageBuildings = true;
		nonannoyingbullet.damage = 0;
        nonannoyingbullet.explode_strength = 0;
		nonannoyingbullet.applies_to_high_flyers = false;
		nonannoyingbullet.setFire = false;
        nonannoyingbullet.removeRuins = false;
          AssetManager.terraform.add(nonannoyingbullet);

            TerraformOptions antiairbomb = AssetManager.terraform.clone("antiairbomb", "grenade");
          antiairbomb.id = "antiairbomb";
		antiairbomb.shake = false;
		antiairbomb.explode_tile = false;
		antiairbomb.damageBuildings = true;
		antiairbomb.damage = 0;
        antiairbomb.explode_strength = 2;
		antiairbomb.applies_to_high_flyers = true;
		antiairbomb.setFire = false;
        antiairbomb.removeRuins = false;
          AssetManager.terraform.add(antiairbomb);

             TerraformOptions deathexplosion = AssetManager.terraform.clone("deathexplosion", "grenade");
          deathexplosion.id = "deathexplosion";
		deathexplosion.shake = false;
		deathexplosion.explode_tile = true;
		deathexplosion.damageBuildings = true;
		deathexplosion.damage = 0;
        deathexplosion.explode_strength = 1;
		deathexplosion.applies_to_high_flyers = false;
		deathexplosion.setFire = false;
          AssetManager.terraform.add(deathexplosion);

EffectAsset groundshake = new EffectAsset();
groundshake.id = "groundshake";
groundshake.use_basic_prefab = true;
groundshake.sorting_layer_id = "EffectsTop";
groundshake.sprite_path = "effects/groundshake";
groundshake.show_on_mini_map = true;
groundshake.draw_light_area = true;
groundshake.draw_light_size = 2f;
groundshake.draw_light_area_offset_y = 5f;
groundshake.limit = 100;
AssetManager.effects_library.add(groundshake);

          EffectAsset DankyMatter = new EffectAsset();
DankyMatter.id = "fx_dankymatter_effect";
DankyMatter.use_basic_prefab = true;
DankyMatter.sorting_layer_id = "EffectsTop";
DankyMatter.sprite_path = "effects/kameboomtesttest";
DankyMatter.show_on_mini_map = true;
DankyMatter.draw_light_area = true;
DankyMatter.draw_light_size = 2f;
DankyMatter.draw_light_area_offset_y = 5f;
DankyMatter.limit = 100;
AssetManager.effects_library.add(DankyMatter);

            EffectAsset Shermanboom = new EffectAsset();
		    Shermanboom.id = "Shermanboom";
		    Shermanboom.use_basic_prefab = true;
		    Shermanboom.sorting_layer_id = "EffectsTop";
		    Shermanboom.sprite_path = $"effects/Shermanboom";
            Shermanboom.show_on_mini_map = true;
		    Shermanboom.draw_light_area = true;
		    Shermanboom.draw_light_size = 1f;
		    Shermanboom.limit = 80;
		    AssetManager.effects_library.add(Shermanboom);

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
           cybermissileprojectile.endEffect = "fx_boat_explosion";
	      cybermissileprojectile.draw_light_size = 1f;
          cybermissileprojectile.terraformOption = "antiairbomb";
          cybermissileprojectile.terraformRange = 1;
          cybermissileprojectile.startScale = 0.2f;
          cybermissileprojectile.targetScale = 0.2f;
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
          artilleryshell.endEffect = "fx_explosion_middle";
          artilleryshell.terraformOption = "nonannoyingbomb";
          artilleryshell.terraformRange = 3;
          artilleryshell.startScale = 0.2f;
          artilleryshell.targetScale = 0.2f;
          artilleryshell.parabolic = true;
          artilleryshell.speed = 19f;
          ProjectileAsset shellboomboomeffect = artilleryshell;
          shellboomboomeffect.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(artilleryshell);

         ProjectileAsset cannonballprojectile = new ProjectileAsset();
          cannonballprojectile.id = "cannonballprojectile";
          cannonballprojectile.texture = "cannonballprojectile";
          cannonballprojectile.trailEffect_enabled = false;
	      cannonballprojectile.look_at_target = true;
          cannonballprojectile.draw_light_area = true;
	      cannonballprojectile.draw_light_size = 1f;
          cannonballprojectile.endEffect = "groundshake";
          cannonballprojectile.terraformOption = "nonannoyingbomb";
          cannonballprojectile.terraformRange = 3;
          cannonballprojectile.startScale = 0.2f;
          cannonballprojectile.targetScale = 0.2f;
          cannonballprojectile.parabolic = true;
          cannonballprojectile.speed = 10f;
          ProjectileAsset cannonballprojectile1 = cannonballprojectile;
          cannonballprojectile1.world_actions = (AttackAction)Delegate.Combine(cannonballprojectile1.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(cannonballprojectile);

           ProjectileAsset tankshell = new ProjectileAsset();
          tankshell.id = "tankshell";
          tankshell.texture = "artilleryshell";
          tankshell.trailEffect_enabled = false;
	      tankshell.look_at_target = true;
          tankshell.draw_light_area = true;
	      tankshell.draw_light_size = 1f;
          tankshell.endEffect = "fx_boat_explosion";
          tankshell.terraformOption = "nonannoyingbomb";
          tankshell.terraformRange = 3;
          tankshell.startScale = 0.2f;
          tankshell.targetScale = 0.2f;
          tankshell.parabolic = false;
          tankshell.speed = 45f;
          ProjectileAsset shellboomboomeffect1 = tankshell;
          shellboomboomeffect1.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect1.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(tankshell);

        ProjectileAsset bigbullet = new ProjectileAsset();
          bigbullet.id = "bigbullet";
          bigbullet.texture = "shotgun_bullet";
          bigbullet.trailEffect_enabled = false;
	      bigbullet.look_at_target = true;
          bigbullet.draw_light_area = true;
          bigbullet.looped = false;
	      bigbullet.draw_light_size = 1f;
          bigbullet.animation_speed = 0.1f;
          bigbullet.terraformOption = "nonannoyingbullet";
          bigbullet.sound_launch = "event:/SFX/WEAPONS/WeaponShotgunStart";
          bigbullet.sound_impact = "event:/SFX/WEAPONS/WeaponShotgunLand";
          bigbullet.terraformRange = 1;
          bigbullet.startScale = 0.1f;
          bigbullet.targetScale = 0.1f;
          bigbullet.parabolic = false;
          bigbullet.speed = 45f;
          AssetManager.projectiles.add(bigbullet);

        ProjectileAsset crabartilleryshell = new ProjectileAsset();
          crabartilleryshell.id = "crabartilleryshell";
          crabartilleryshell.texture = "shotgun_bullet";
          crabartilleryshell.trailEffect_enabled = false;
	      crabartilleryshell.look_at_target = true;
          crabartilleryshell.draw_light_area = true;
	      crabartilleryshell.draw_light_size = 1f;
          crabartilleryshell.terraformOption = "crab_bomb";
          crabartilleryshell.terraformRange = 5;
          crabartilleryshell.endEffect = "fx_explosion_middle";
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
	      bigbomb.look_at_target = true;
          bigbomb.draw_light_area = true;
          bigbomb.endEffect = "Shermanboom";
          bigbomb.trailEffect_id = "smoketrail";
          bigbomb.trailEffect_scale = 0.1f;
          bigbomb.trailEffect_timer = 0.1f;
	      bigbomb.draw_light_size = 1f;
          bigbomb.terraformOption = "nonannoyingbomb";
          bigbomb.terraformRange = 3;
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
           seismicrod.trailEffect_id = "smoketrail";
          seismicrod.trailEffect_scale = 0.1f;
          seismicrod.trailEffect_timer = 0.1f;
	      seismicrod.look_at_target = true;
          seismicrod.draw_light_area = true;
          seismicrod.endEffect = "fx_explosion_middle";
	      seismicrod.draw_light_size = 1f;
          seismicrod.terraformOption = "antiairbomb";
          seismicrod.terraformRange = 20;
          seismicrod.startScale = 0.3f;
          seismicrod.targetScale = 0.3f;
          seismicrod.parabolic = false;
          seismicrod.speed = 10f;
           ProjectileAsset bombasticlolxd1 = seismicrod;
          bombasticlolxd1.world_actions = (AttackAction)Delegate.Combine(bombasticlolxd1.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(seismicrod);

                ItemAsset incendiarybombing = AssetManager.items.clone("incendiarybombing", "_range");
            incendiarybombing.id = "incendiarybombing";
            incendiarybombing.projectile = "torch";
            incendiarybombing.materials = List.Of<string>(new string[] { "base" });
            incendiarybombing.base_stats[S.targets] = 2;
            incendiarybombing.base_stats[S.range] = 0f;
            incendiarybombing.base_stats[S.projectiles] = 1;
            incendiarybombing.path_slash_animation = "effects/fire_charger";

             ItemAsset icebolt = AssetManager.items.clone("icebolt", "_range");
            icebolt.id = "icebolt";
            icebolt.projectile = "frostbolt";
            icebolt.materials = List.Of<string>(new string[] { "base" });
            icebolt.base_stats[S.targets] = 1;
            icebolt.base_stats[S.range] = 0f;
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
            snowthrow.base_stats[S.range] = 0f;
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
		singleshot.base_stats[S.range] = 0f;
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
		machinegunery.base_stats[S.range] = 0f;
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
		artillerystriker.base_stats[S.range] = 0f;
		artillerystriker.base_stats[S.targets] = 1f;
		artillerystriker.base_stats[S.damage] = 60f;
		artillerystriker.base_stats[S.damage_range] = 0.7f;
            artillerystriker.path_slash_animation = "effects/slashes/slash_punch";

            ItemAsset missilelauncherlong = AssetManager.items.clone("missilelauncherlong", "_range");
            missilelauncherlong.id = "missilelauncherlong";
            missilelauncherlong.projectile = "MIRVartillery";
            missilelauncherlong.materials = List.Of<string>(new string[] { "base" });
        missilelauncherlong.base_stats[S.projectiles] = 1f;
		missilelauncherlong.base_stats[S.attack_speed] = 0.1f;
		missilelauncherlong.base_stats[S.range] = 0f;
		missilelauncherlong.base_stats[S.targets] = 1f;
		missilelauncherlong.base_stats[S.damage] = 0f;
		missilelauncherlong.base_stats[S.damage_range] = 0.7f;
            missilelauncherlong.path_slash_animation = "effects/slashes/slash_punch";

            ItemAsset missilelaunchershort = AssetManager.items.clone("missilelaunchershort", "_range");
            missilelaunchershort.id = "missilelaunchershort";
            missilelaunchershort.projectile = "RPGload";
            missilelaunchershort.materials = List.Of<string>(new string[] { "base" });
        missilelaunchershort.base_stats[S.projectiles] = 1f;
		missilelaunchershort.base_stats[S.attack_speed] = 0.1f;
		missilelaunchershort.base_stats[S.range] = 0f;
		missilelaunchershort.base_stats[S.targets] = 1f;
		missilelaunchershort.base_stats[S.damage] = 60f;
		missilelaunchershort.base_stats[S.damage_range] = 0.7f;
            missilelaunchershort.path_slash_animation = "effects/slashes/slash_punch";



                  ItemAsset arrowstriker = AssetManager.items.clone("arrowstriker", "_range");
            arrowstriker.id = "arrowstriker";
            arrowstriker.projectile = "arrow";
            arrowstriker.materials = List.Of<string>(new string[] { "base" });
        arrowstriker.base_stats[S.projectiles] = 1f;
		arrowstriker.base_stats[S.attack_speed] = 0.1f;
		arrowstriker.base_stats[S.range] = 0f;
		arrowstriker.base_stats[S.targets] = 1f;
		arrowstriker.base_stats[S.damage] = 0f;
		arrowstriker.base_stats[S.damage_range] = 0.7f;
            arrowstriker.path_slash_animation = "effects/slashes/slash_punch";

            ItemAsset cannonstriker = AssetManager.items.clone("cannonstriker", "_range");
            cannonstriker.id = "cannonstriker";
            cannonstriker.projectile = "cannonballprojectile";
            cannonstriker.materials = List.Of<string>(new string[] { "base" });
        cannonstriker.base_stats[S.projectiles] = 1f;
		cannonstriker.base_stats[S.attack_speed] = 0.1f;
		cannonstriker.base_stats[S.range] = 0f;
		cannonstriker.base_stats[S.targets] = 4f;
		cannonstriker.base_stats[S.damage] = 0f;
		cannonstriker.base_stats[S.damage_range] = 0.7f;
            cannonstriker.path_slash_animation = "effects/slashes/slash_punch";

            ItemAsset bigbulletattack = AssetManager.items.clone("bigbulletattack", "_range");
            bigbulletattack.id = "bigbulletattack";
            bigbulletattack.projectile = "bigbullet";
            bigbulletattack.materials = List.Of<string>(new string[] { "base" });
        bigbulletattack.base_stats[S.projectiles] = 1f;
		bigbulletattack.base_stats[S.attack_speed] = 0.1f;
		bigbulletattack.base_stats[S.range] = 0f;
		bigbulletattack.base_stats[S.targets] = 3f;
		bigbulletattack.base_stats[S.damage] = 30f;
		bigbulletattack.base_stats[S.damage_range] = 0.7f;
            bigbulletattack.path_slash_animation = "effects/slashes/slash_punch";

            ItemAsset tankshellattack = AssetManager.items.clone("tankshellattack", "_range");
            tankshellattack.id = "tankshellattack";
            tankshellattack.projectile = "tankshell";
            tankshellattack.materials = List.Of<string>(new string[] { "base" });
        tankshellattack.base_stats[S.projectiles] = 1f;
		tankshellattack.base_stats[S.attack_speed] = 0.1f;
		tankshellattack.base_stats[S.range] = 0f;
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
		crabartillery.base_stats[S.range] = 0f;
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
		bomberino.base_stats[S.range] = 0f;
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
		destroyerbot.base_stats[S.range] = 0f;
		destroyerbot.base_stats[S.targets] = 10f;
		destroyerbot.base_stats[S.damage] = 20f;
		destroyerbot.base_stats[S.damage_range] = 0.5f;
            destroyerbot.path_slash_animation = "effects/slashes/slash_punch";
			
       ProjectileAsset RPGload = new ProjectileAsset();
          RPGload.id = "RPGload";
          RPGload.texture = "RPG";
          RPGload.trailEffect_enabled = false;
	      RPGload.look_at_target = true;
          RPGload.draw_light_area = true;
	      RPGload.draw_light_size = 1f;
          RPGload.endEffect = "fx_fireball_explosion";
          RPGload.terraformOption = "nonannoyingbomb";
          RPGload.terraformRange = 3;
          RPGload.startScale = 0.3f;
          RPGload.targetScale = 0.3f;
          RPGload.parabolic = false;
          RPGload.speed = 40f;
          AssetManager.projectiles.add(RPGload);


          ProjectileAsset jetrocketprojectile = new ProjectileAsset();
          jetrocketprojectile.id = "jetrocketprojectile";
          jetrocketprojectile.texture = "jetrocketprojectile";
          jetrocketprojectile.trailEffect_enabled = false;
	      jetrocketprojectile.look_at_target = true;
          jetrocketprojectile.draw_light_area = true;
	      jetrocketprojectile.draw_light_size = 1f;
          jetrocketprojectile.trailEffect_id = "smoketrail";
          jetrocketprojectile.trailEffect_scale = 0.1f;
          jetrocketprojectile.trailEffect_timer = 0.1f;
          jetrocketprojectile.endEffect = "fx_fireball_explosion";
          jetrocketprojectile.terraformOption = "antiairbomb";
          jetrocketprojectile.terraformRange = 3;
          jetrocketprojectile.startScale = 0.3f;
          jetrocketprojectile.targetScale = 0.3f;
          jetrocketprojectile.parabolic = false;
          jetrocketprojectile.speed = 40f;
          AssetManager.projectiles.add(jetrocketprojectile);

            ItemAsset JetRocket = AssetManager.items.clone("JetRocket", "_range");
            JetRocket.id = "JetRocket";
            JetRocket.projectile = "jetrocketprojectile";
            JetRocket.materials = List.Of<string>(new string[] { "base" });
        JetRocket.base_stats[S.projectiles] = 2f;
        JetRocket.base_stats[S.attack_speed] = -101f;
		JetRocket.base_stats[S.range] = 0f;
		JetRocket.base_stats[S.targets] = 2f;
		JetRocket.base_stats[S.damage] = 60f;
		JetRocket.base_stats[S.damage_range] = 0.5f;
            JetRocket.base_stats[S.accuracy] = 400;
            JetRocket.path_slash_animation = "effects/slashes/slash_punch";

 ProjectileAsset helirocketprojectile = new ProjectileAsset();
          helirocketprojectile.id = "helirocketprojectile";
          helirocketprojectile.texture = "jetrocketprojectile";
          helirocketprojectile.trailEffect_enabled = false;
	      helirocketprojectile.look_at_target = true;
          helirocketprojectile.draw_light_area = true;
	      helirocketprojectile.draw_light_size = 1f;
          helirocketprojectile.trailEffect_id = "smoketrail";
          helirocketprojectile.trailEffect_scale = 0.1f;
          helirocketprojectile.trailEffect_timer = 0.1f;
          helirocketprojectile.terraformOption = "antiairbomb";
         helirocketprojectile.endEffect = "fx_fireball_explosion";
          helirocketprojectile.terraformRange = 3;
          helirocketprojectile.startScale = 0.1f;
          helirocketprojectile.targetScale = 0.1f;
          helirocketprojectile.parabolic = false;
          helirocketprojectile.speed = 30f;
          AssetManager.projectiles.add(helirocketprojectile);

            ItemAsset heliRocket = AssetManager.items.clone("heliRocket", "_range");
            heliRocket.id = "heliRocket";
            heliRocket.projectile = "helirocketprojectile";
            heliRocket.materials = List.Of<string>(new string[] { "base" });
        heliRocket.base_stats[S.projectiles] = 2f;
        heliRocket.base_stats[S.attack_speed] = 1000f;
		heliRocket.base_stats[S.range] = 0f;
		heliRocket.base_stats[S.targets] = 1f;
		heliRocket.base_stats[S.damage] = 16f;
		heliRocket.base_stats[S.damage_range] = 0.5f;
            heliRocket.base_stats[S.accuracy] = 400;
            heliRocket.path_slash_animation = "effects/slashes/slash_punch";
			

			ItemAsset GunshipCannon = AssetManager.items.clone("GunshipCannon", "_range");
            GunshipCannon.id = "GunshipCannon";
            GunshipCannon.projectile = "shotgun_bullet";
            GunshipCannon.base_stats[S.range] = 0f;
            GunshipCannon.base_stats[S.accuracy] = 400;
            GunshipCannon.base_stats[S.attack_speed] = 200f;
            GunshipCannon.base_stats[S.damage] = 13;
            GunshipCannon.equipment_value = 300;
            GunshipCannon.path_slash_animation = "effects/slashes/slash_punch";
		  
		  ItemAsset PipeRifle = AssetManager.items.clone("PipeRifle", "_range");
          PipeRifle.id = "PipeRifle";
         PipeRifle.name_class = "item_class_weapon";
          PipeRifle.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          PipeRifle.materials = List.Of<string>(new string[]{"iron"});
          PipeRifle.projectile = "shotgun_bullet";
          PipeRifle.base_stats[S.fertility] = 0.0f;
          PipeRifle.base_stats[S.max_children] = 0f;
          PipeRifle.base_stats[S.max_age] = 0f;
          PipeRifle.base_stats[S.attack_speed] = 180;
          PipeRifle.base_stats[S.damage] = 13;
          PipeRifle.base_stats[S.speed] = 0f;
          PipeRifle.base_stats[S.health] = 0;
          PipeRifle.base_stats[S.accuracy] = 70f;
          PipeRifle.base_stats[S.range] = 6f;
          PipeRifle.base_stats[S.armor] = 0;	
          PipeRifle.base_stats[S.scale] = 0.0f;
          PipeRifle.base_stats[S.dodge] = 0f;
          PipeRifle.base_stats[S.targets] = 0f;
          PipeRifle.base_stats[S.critical_chance] = 0.0f;
          PipeRifle.base_stats[S.knockback] = 0f;
          PipeRifle.base_stats[S.knockback_reduction] = 0f;
          PipeRifle.base_stats[S.intelligence] = 0;
          PipeRifle.base_stats[S.warfare] = 0;
          PipeRifle.base_stats[S.diplomacy] = 0;
          PipeRifle.base_stats[S.stewardship] = 0;
          PipeRifle.base_stats[S.opinion] = 0f;
          PipeRifle.base_stats[S.loyalty_traits] = 0f;
          PipeRifle.base_stats[S.cities] = 0;
          PipeRifle.base_stats[S.zone_range] = 0;
          PipeRifle.equipment_value = 100;
          PipeRifle.path_slash_animation = "effects/slashes/slash_punch";
          PipeRifle.tech_needed = "Renaissance";
          PipeRifle.equipmentType = EquipmentType.Weapon;
          PipeRifle.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(PipeRifle);
          Localization.addLocalization("item_PipeRifle", "Pipe Rifle");
          addgunSprite(PipeRifle.id, PipeRifle.materials[0]);
		  
		  ItemAsset PipePistol = AssetManager.items.clone("PipePistol", "_range");
          PipePistol.id = "PipePistol";
              PipePistol.name_class = "item_class_weapon";
          PipePistol.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          PipePistol.materials = List.Of<string>(new string[]{"iron"});
          PipePistol.projectile = "shotgun_bullet";
          PipePistol.base_stats[S.fertility] = 0.0f;
          PipePistol.base_stats[S.max_children] = 0f;
          PipePistol.base_stats[S.max_age] = 0f;
          PipePistol.base_stats[S.attack_speed] = 20;
          PipePistol.base_stats[S.damage] = 13;
          PipePistol.base_stats[S.speed] = 0f;
          PipePistol.base_stats[S.health] = 0;
          PipePistol.base_stats[S.accuracy] = 70f;
          PipePistol.base_stats[S.range] = 6f;
          PipePistol.base_stats[S.armor] = 0;	
          PipePistol.base_stats[S.scale] = 0.0f;
          PipePistol.base_stats[S.dodge] = 0f;
          PipePistol.base_stats[S.targets] = 0f;
          PipePistol.base_stats[S.critical_chance] = 0.0f;
          PipePistol.base_stats[S.knockback] = 0f;
          PipePistol.base_stats[S.knockback_reduction] = 0f;
          PipePistol.base_stats[S.intelligence] = 0;
          PipePistol.base_stats[S.warfare] = 0;
          PipePistol.base_stats[S.diplomacy] = 0;
          PipePistol.base_stats[S.stewardship] = 0;
          PipePistol.base_stats[S.opinion] = 0f;
          PipePistol.base_stats[S.loyalty_traits] = 0f;
          PipePistol.base_stats[S.cities] = 0;
          PipePistol.base_stats[S.zone_range] = 0;
          PipePistol.equipment_value = 100;
          PipePistol.path_slash_animation = "effects/slashes/slash_punch";
          PipePistol.tech_needed = "Renaissance";
          PipePistol.equipmentType = EquipmentType.Weapon;
          PipePistol.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(PipePistol);
          Localization.addLocalization("item_PipePistol", "Pipe Pistol");
          addgunSprite(PipePistol.id, PipePistol.materials[0]);
		  
		  ItemAsset PipeShotgun = AssetManager.items.clone("PipeShotgun", "_range");
          PipeShotgun.id = "PipeShotgun";
         PipeShotgun.name_class = "item_class_weapon";
          PipeShotgun.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          PipeShotgun.materials = List.Of<string>(new string[]{"iron"});
          PipeShotgun.projectile = "shotgun_bullet";
          PipeShotgun.base_stats[S.fertility] = 0.0f;
          PipeShotgun.base_stats[S.max_children] = 0f;
          PipeShotgun.base_stats[S.max_age] = 0f;
          PipeShotgun.base_stats[S.attack_speed] = 20;
          PipeShotgun.base_stats[S.damage] = 130;
          PipeShotgun.base_stats[S.speed] = 0f;
          PipeShotgun.base_stats[S.health] = 0;
          PipeShotgun.base_stats[S.accuracy] = 70f;
          PipeShotgun.base_stats[S.range] = 6f;
          PipeShotgun.base_stats[S.armor] = 0;
          PipeShotgun.base_stats[S.scale] = 0.0f;
          PipeShotgun.base_stats[S.dodge] = 0f;
          PipeShotgun.base_stats[S.targets] = 0f;
          PipeShotgun.base_stats[S.critical_chance] = 0.0f;
          PipeShotgun.base_stats[S.knockback] = 0f;
          PipeShotgun.base_stats[S.knockback_reduction] = 0f;
          PipeShotgun.base_stats[S.intelligence] = 0;
          PipeShotgun.base_stats[S.warfare] = 0;
          PipeShotgun.base_stats[S.diplomacy] = 0;
          PipeShotgun.base_stats[S.stewardship] = 0;
          PipeShotgun.base_stats[S.opinion] = 0f;
          PipeShotgun.base_stats[S.loyalty_traits] = 0f;
          PipeShotgun.base_stats[S.cities] = 0;
          PipeShotgun.base_stats[S.zone_range] = 0;
          PipeShotgun.equipment_value = 100;
          PipeShotgun.path_slash_animation = "effects/slashes/slash_punch";
          PipeShotgun.tech_needed = "Renaissance";
          PipeShotgun.equipmentType = EquipmentType.Weapon;
          PipeShotgun.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(PipeShotgun);
          Localization.addLocalization("item_PipeShotgun", "Pipe Shotgun");
          addgunSprite(PipeShotgun.id, PipeShotgun.materials[0]);


//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////RENAISSANCE/////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

                ///////////HUMAN///////////
            ItemAsset shieldedsword = AssetManager.items.clone("shieldedsword", "_melee");
			shieldedsword.id = "shieldedsword";
            shieldedsword.name_class = "item_class_weapon";
            shieldedsword.name_templates = Toolbox.splitStringIntoList("sword_name#30");
			shieldedsword.materials = List.Of<string>(new string[]{"copper"});
			shieldedsword.tech_needed = "Renaissance";
	     	shieldedsword.base_stats[S.damage] = 5f;
		    shieldedsword.base_stats[S.attack_speed] = 20f;
            shieldedsword.base_stats[S.damage_range] = 0.9f;
			shieldedsword.base_stats[S.health] = 20;
            shieldedsword.base_stats[S.armor] = 10;
			shieldedsword.equipment_value = 50;
			shieldedsword.path_slash_animation = "effects/slashes/slash_sword";
			shieldedsword.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(shieldedsword);
			Localization.addLocalization("item_shieldedsword", "shielded sword");
			addgunSprite(shieldedsword.id, shieldedsword.materials[0]);

            AddPreferredWeaponToCivRaces("shieldedsword", 5);

             ///////////ORC///////////
              ItemAsset shieldedaxe = AssetManager.items.clone("shieldedaxe", "_melee");
			shieldedaxe.id = "shieldedaxe";
            shieldedaxe.name_class = "item_class_weapon";
            shieldedaxe.name_templates = Toolbox.splitStringIntoList("axe_name#30");
			shieldedaxe.materials = List.Of<string>(new string[]{"copper"});
			shieldedaxe.tech_needed = "Renaissance";
	     	shieldedaxe.base_stats[S.damage] = 5f;
	    	shieldedaxe.base_stats[S.attack_speed] = 20f;
		    shieldedaxe.base_stats[S.damage_range] = 0.7f;
			shieldedaxe.base_stats[S.health] = 20;
            shieldedaxe.base_stats[S.armor] = 10;
			shieldedaxe.equipment_value = 50;
			shieldedaxe.path_slash_animation = "effects/slashes/slash_axe";
			shieldedaxe.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(shieldedaxe);
			Localization.addLocalization("item_shieldedaxe", "shielded axe");
			addgunSprite(shieldedaxe.id, shieldedaxe.materials[0]);

          AddPreferredWeaponToCivRaces("shieldedaxe", 5);

             ///////////DWARF///////////
              ItemAsset shieldedhammer = AssetManager.items.clone("shieldedhammer", "_melee");
			shieldedhammer.id = "shieldedhammer";
            shieldedhammer.name_class = "item_class_weapon";
            shieldedhammer.name_templates = Toolbox.splitStringIntoList("hammer_name#30");
			shieldedhammer.materials = List.Of<string>(new string[]{"copper"});
			shieldedhammer.tech_needed = "Renaissance";
	     	shieldedhammer.base_stats[S.damage] = 5f;
		    shieldedhammer.base_stats[S.attack_speed] = -10f;
		    shieldedhammer.base_stats[S.targets] = 4f;
		    shieldedhammer.base_stats[S.damage_range] = 0.2f;
			shieldedhammer.base_stats[S.health] = 20;
            shieldedhammer.base_stats[S.armor] = 10;
			shieldedhammer.equipment_value = 50;
			shieldedhammer.path_slash_animation = "effects/slashes/slash_hammer";
			shieldedhammer.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(shieldedhammer);
			Localization.addLocalization("item_shieldedhammer", "shielded hammer");
			addgunSprite(shieldedhammer.id, shieldedhammer.materials[0]);

                AddPreferredWeaponToCivRaces("shieldedhammer", 5);

             ///////////ELF///////////
            ItemAsset shieldedspear = AssetManager.items.clone("shieldedspear", "_melee");
			shieldedspear.id = "shieldedspear";
            shieldedspear.name_class = "item_class_weapon";
            shieldedspear.name_templates = Toolbox.splitStringIntoList("spear_name#30");
			shieldedspear.materials = List.Of<string>(new string[]{"copper"});
			shieldedspear.tech_needed = "Renaissance";
	     	shieldedspear.base_stats[S.damage] = 5f;
		    shieldedspear.base_stats[S.range] = 2f;
            shieldedspear.base_stats[S.attack_speed] = 15f;
		    shieldedspear.base_stats[S.damage_range] = 0.8f;
			shieldedspear.base_stats[S.health] = 20;
            shieldedspear.base_stats[S.armor] = 10;
			shieldedspear.equipment_value = 50;
			shieldedspear.path_slash_animation = "effects/slashes/slash_spear";
			shieldedspear.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(shieldedspear);
			Localization.addLocalization("item_shieldedspear", "shielded spear");
			addgunSprite(shieldedspear.id, shieldedspear.materials[0]);

           AddPreferredWeaponToCivRaces("shieldedspear", 5);

          ItemAsset piratpistol = AssetManager.items.clone("piratpistol", "_range");
          piratpistol.id = "piratpistol";
          piratpistol.name_class = "item_class_weapon";
          piratpistol.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          piratpistol.materials = List.Of<string>(new string[]{"iron"});
          piratpistol.projectile = "shotgun_bullet";
          piratpistol.base_stats[S.fertility] = 0.0f;
          piratpistol.base_stats[S.max_children] = 0f;
          piratpistol.base_stats[S.max_age] = 0f;
          piratpistol.base_stats[S.attack_speed] = -100;
          piratpistol.base_stats[S.damage] = 30;
          piratpistol.base_stats[S.speed] = 0f;
          piratpistol.base_stats[S.health] = 0;
          piratpistol.base_stats[S.accuracy] = -20f;
          piratpistol.base_stats[S.range] = 10;
          piratpistol.base_stats[S.armor] = 0;
          piratpistol.base_stats[S.scale] = 0.0f;
          piratpistol.base_stats[S.dodge] = 0f;
          piratpistol.base_stats[S.targets] = 0f;
          piratpistol.base_stats[S.critical_chance] = 0.2f;
          piratpistol.base_stats[S.critical_damage_multiplier] = 0.5f;
          piratpistol.base_stats[S.knockback] = 0f;
          piratpistol.base_stats[S.knockback_reduction] = 0f;
          piratpistol.base_stats[S.intelligence] = 0;
          piratpistol.base_stats[S.warfare] = 0;
          piratpistol.base_stats[S.diplomacy] = 0;
          piratpistol.base_stats[S.stewardship] = 0;
          piratpistol.base_stats[S.opinion] = 0f;
          piratpistol.base_stats[S.loyalty_traits] = 0f;
          piratpistol.base_stats[S.cities] = 0;
          piratpistol.base_stats[S.zone_range] = 0;
          piratpistol.equipment_value = 45;
          piratpistol.path_slash_animation = "effects/slashes/slash_punch";
          piratpistol.tech_needed = "Renaissance";
          piratpistol.equipmentType = EquipmentType.Weapon;
          piratpistol.name_class = "item_class_weapon";

          AssetManager.items.list.AddItem(piratpistol);
          Localization.addLocalization("item_piratpistol", "piratpistol");
          addgunSprite(piratpistol.id, piratpistol.materials[0]);

          AddPreferredWeaponToCivRaces("piratpistol", 5);

          ItemAsset Musket = AssetManager.items.clone("Musket", "_range");
          Musket.id = "Musket";
          Musket.name_class = "item_class_weapon";
          Musket.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          Musket.materials = List.Of<string>(new string[]{"steel"});
          Musket.projectile = "shotgun_bullet";
          Musket.base_stats[S.fertility] = 0.0f;
          Musket.base_stats[S.max_children] = 0f;
          Musket.base_stats[S.max_age] = 0f;
          Musket.base_stats[S.attack_speed] = -200;
          Musket.base_stats[S.damage] = 40;
          Musket.base_stats[S.speed] = 0f;
          Musket.base_stats[S.health] = 0;
          Musket.base_stats[S.accuracy] = -20f;
          Musket.base_stats[S.range] = 20;
          Musket.base_stats[S.armor] = 0;
          Musket.base_stats[S.scale] = 0.0f;
          Musket.base_stats[S.dodge] = 0f;
          Musket.base_stats[S.targets] = 0f;
          Musket.base_stats[S.critical_chance] = 0.2f;
          Musket.base_stats[S.critical_damage_multiplier] = 0.5f;
          Musket.base_stats[S.knockback] = 0f;
          Musket.base_stats[S.knockback_reduction] = 0f;
          Musket.base_stats[S.intelligence] = 0;
          Musket.base_stats[S.warfare] = 0;
          Musket.base_stats[S.diplomacy] = 0;
          Musket.base_stats[S.stewardship] = 0;
          Musket.base_stats[S.opinion] = 0f;
          Musket.base_stats[S.loyalty_traits] = 0f;
          Musket.base_stats[S.cities] = 0;
          Musket.base_stats[S.zone_range] = 0;
          Musket.equipment_value = 70;
          Musket.path_slash_animation = "effects/slashes/slash_punch";
          Musket.tech_needed = "Renaissance_knowledge";
          Musket.equipmentType = EquipmentType.Weapon;
          Musket.name_class = "item_class_weapon";

          AssetManager.items.list.AddItem(Musket);
          Localization.addLocalization("item_Musket", "Musket");
          addgunSprite(Musket.id, Musket.materials[0]);

          AddPreferredWeaponToCivRaces("Musket", 5);


                ///////////ARMOR///////////
           ItemAsset pristinearmor = AssetManager.items.clone("pristinearmor", "_equipment");
          pristinearmor.id = "pristinearmor";
          pristinearmor.name_class = "item_class_armor";
          pristinearmor.name_templates = Toolbox.splitStringIntoList("armor_name");
          pristinearmor.materials = List.Of<string>(new string[]{"steel", "mythril", "adamantine"});
          pristinearmor.base_stats[S.knockback_reduction] = 1f;
          pristinearmor.base_stats[S.armor] = 5f;
          pristinearmor.base_stats[S.speed] = -5f;
          pristinearmor.equipment_value = 70;
          pristinearmor.tech_needed = "Renaissance";
          pristinearmor.equipmentType = EquipmentType.Armor;
          pristinearmor.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(pristinearmor);
          Localization.addLocalization("item_pristinearmor", "pristine armor");

          ItemAsset pristineboots = AssetManager.items.clone("pristineboots", "_equipment");
          pristineboots.id = "pristineboots";
          pristineboots.name_class = "item_class_armor";
          pristineboots.name_templates = Toolbox.splitStringIntoList("boots_name");
          pristineboots.materials = List.Of<string>(new string[]{"steel", "mythril", "adamantine"});
          pristineboots.base_stats[S.knockback_reduction] = 1f;
          pristineboots.base_stats[S.armor] = 5f;
          pristineboots.base_stats[S.speed] = -5f;
          pristineboots.equipment_value = 70;
          pristineboots.tech_needed = "Renaissance";
          pristineboots.equipmentType = EquipmentType.Boots;
          pristineboots.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(pristineboots);
          Localization.addLocalization("item_pristineboots", "pristine boots");

          ItemAsset pristinehelmet = AssetManager.items.clone("pristinehelmet", "_equipment");
          pristinehelmet.id = "pristinehelmet";
          pristinehelmet.name_class = "item_class_armor";
          pristinehelmet.name_templates = Toolbox.splitStringIntoList("helmet_name");
          pristinehelmet.materials = List.Of<string>(new string[]{"steel", "mythril", "adamantine"});
          pristinehelmet.base_stats[S.knockback_reduction] = 1f;
          pristinehelmet.base_stats[S.armor] = 5f;
          pristinehelmet.base_stats[S.speed] = -5f;
          pristinehelmet.equipment_value = 70;
          pristinehelmet.tech_needed = "Renaissance";
          pristinehelmet.equipmentType = EquipmentType.Helmet;
          pristinehelmet.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(pristinehelmet);
          Localization.addLocalization("item_pristinehelmet", "pristine helmet");



//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////INDUSTRIAL/////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

                ///////////ARMOR///////////
           ItemAsset wwarmor = AssetManager.items.clone("wwarmor", "_equipment");
          wwarmor.id = "wwarmor";
          wwarmor.name_class = "item_class_armor";
          wwarmor.name_templates = Toolbox.splitStringIntoList("armor_name");
          wwarmor.materials = List.Of<string>(new string[]{"copper"});
          wwarmor.base_stats[S.armor] = 0f;
          wwarmor.base_stats[S.speed] = 10f;
          wwarmor.base_stats[S.dodge] = 15f;
          wwarmor.base_stats[S.attack_speed] = 50;
          wwarmor.equipment_value = 200;
          wwarmor.tech_needed = "Firearms";
          wwarmor.equipmentType = EquipmentType.Armor;
          wwarmor.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(wwarmor);
          Localization.addLocalization("item_wwarmor", "ww armor");

          ItemAsset wwboots = AssetManager.items.clone("wwboots", "_equipment");
          wwboots.id = "wwboots";
          wwboots.name_class = "item_class_armor";
          wwboots.name_templates = Toolbox.splitStringIntoList("boots_name");
          wwboots.materials = List.Of<string>(new string[]{"copper"});
          wwboots.base_stats[S.armor] = 0f;
          wwboots.base_stats[S.speed] = 10f;
          wwboots.base_stats[S.dodge] = 15f;
          wwboots.base_stats[S.attack_speed] = 50;
          wwboots.equipment_value = 200;
          wwboots.tech_needed = "Firearms";
          wwboots.equipmentType = EquipmentType.Boots;
          wwboots.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(wwboots);
          Localization.addLocalization("item_wwboots", "ww boots");

          ItemAsset wwhelmet = AssetManager.items.clone("wwhelmet", "_equipment");
          wwhelmet.id = "wwhelmet";
          wwhelmet.name_class = "item_class_armor";
          wwhelmet.name_templates = Toolbox.splitStringIntoList("helmet_name");
          wwhelmet.materials = List.Of<string>(new string[]{"copper"});
          wwhelmet.base_stats[S.armor] = 0f;
          wwhelmet.base_stats[S.speed] = 10f;
          wwhelmet.base_stats[S.dodge] = 15f;
          wwhelmet.base_stats[S.attack_speed] = 50;
          wwhelmet.equipment_value = 200;
          wwhelmet.tech_needed = "Firearms";
          wwhelmet.equipmentType = EquipmentType.Helmet;
          wwhelmet.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(wwhelmet);
          Localization.addLocalization("item_wwhelmet", "ww helmet");




          ItemAsset m1garand = AssetManager.items.clone("m1garand", "_range");
          m1garand.id = "m1garand";
          m1garand.name_class = "item_class_weapon";
          m1garand.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          m1garand.materials = List.Of<string>(new string[]{"copper"});
          m1garand.projectile = "shotgun_bullet";
          m1garand.base_stats[S.fertility] = 0.0f;
          m1garand.base_stats[S.max_children] = 0f;
          m1garand.base_stats[S.max_age] = 0f;
          m1garand.base_stats[S.attack_speed] = -200;
          m1garand.base_stats[S.damage] = 100;
          m1garand.base_stats[S.speed] = 0f;
          m1garand.base_stats[S.health] = 0;
          m1garand.base_stats[S.accuracy] = -20f;
          m1garand.base_stats[S.range] = 23;
          m1garand.base_stats[S.armor] = 0;
          m1garand.base_stats[S.scale] = 0.0f;
          m1garand.base_stats[S.dodge] = 0f;
          m1garand.base_stats[S.targets] = 0f;
          m1garand.base_stats[S.critical_chance] = 0.3f;
          m1garand.base_stats[S.critical_damage_multiplier] = 0.4f;
          m1garand.base_stats[S.knockback] = 1f;
          m1garand.base_stats[S.knockback_reduction] = 0f;
          m1garand.base_stats[S.intelligence] = 0;
          m1garand.base_stats[S.warfare] = 0;
          m1garand.base_stats[S.diplomacy] = 0;
          m1garand.base_stats[S.stewardship] = 0;
          m1garand.base_stats[S.opinion] = 0f;
          m1garand.base_stats[S.loyalty_traits] = 0f;
          m1garand.base_stats[S.cities] = 0;
          m1garand.base_stats[S.zone_range] = 0;
          m1garand.equipment_value = 200;
          m1garand.path_slash_animation = "effects/slashes/slash_punch";
          m1garand.tech_needed = "Firearms";
          m1garand.equipmentType = EquipmentType.Weapon;
          m1garand.name_class = "item_class_weapon";

          AssetManager.items.list.AddItem(m1garand);
          Localization.addLocalization("item_m1garand", "m1garand");
          addgunSprite(m1garand.id, m1garand.materials[0]);

          AddPreferredWeaponToCivRaces("m1garand", 5);


                    ItemAsset Americanshotgun = AssetManager.items.clone("Americanshotgun", "_range");
          Americanshotgun.id = "Americanshotgun";
          Americanshotgun.name_class = "item_class_weapon";
          Americanshotgun.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          Americanshotgun.materials = List.Of<string>(new string[]{"copper"});
          Americanshotgun.projectile = "shotgun_bullet";
          Americanshotgun.base_stats[S.projectiles] = 10;
          Americanshotgun.base_stats[S.fertility] = 0.0f;
          Americanshotgun.base_stats[S.max_children] = 0f;
          Americanshotgun.base_stats[S.max_age] = 0f;
          Americanshotgun.base_stats[S.attack_speed] = -200;
          Americanshotgun.base_stats[S.damage] = 6;
          Americanshotgun.base_stats[S.speed] = 0f;
          Americanshotgun.base_stats[S.health] = 0;
          Americanshotgun.base_stats[S.accuracy] = -20f;
          Americanshotgun.base_stats[S.range] = 6;
          Americanshotgun.base_stats[S.armor] = 0;
          Americanshotgun.base_stats[S.scale] = 0.0f;
          Americanshotgun.base_stats[S.dodge] = 0f;
          Americanshotgun.base_stats[S.targets] = 0f;
          Americanshotgun.base_stats[S.critical_chance] = 0.1f;
          Americanshotgun.base_stats[S.critical_damage_multiplier] = 0.6f;
          Americanshotgun.base_stats[S.knockback] = 3f;
          Americanshotgun.base_stats[S.knockback_reduction] = 0f;
          Americanshotgun.base_stats[S.intelligence] = 0;
          Americanshotgun.base_stats[S.warfare] = 0;
          Americanshotgun.base_stats[S.diplomacy] = 0;
          Americanshotgun.base_stats[S.stewardship] = 0;
          Americanshotgun.base_stats[S.opinion] = 0f;
          Americanshotgun.base_stats[S.loyalty_traits] = 0f;
          Americanshotgun.base_stats[S.cities] = 0;
          Americanshotgun.base_stats[S.zone_range] = 0;
          Americanshotgun.equipment_value = 200;
          Americanshotgun.path_slash_animation = "effects/slashes/slash_punch";
          Americanshotgun.tech_needed = "Firearms";
          Americanshotgun.equipmentType = EquipmentType.Weapon;
          Americanshotgun.name_class = "item_class_weapon";

          AssetManager.items.list.AddItem(Americanshotgun);
          Localization.addLocalization("item_Americanshotgun", "Americanshotgun");
          addgunSprite(Americanshotgun.id, Americanshotgun.materials[0]);

          AddPreferredWeaponToCivRaces("Americanshotgun", 5);




//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////MODERN/////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

                ///////////ARMOR///////////
           ItemAsset modernarmor = AssetManager.items.clone("modernarmor", "_equipment");
          modernarmor.id = "modernarmor";
          modernarmor.name_class = "item_class_armor";
          modernarmor.name_templates = Toolbox.splitStringIntoList("armor_name");
          modernarmor.materials = List.Of<string>(new string[]{"copper"});
          modernarmor.base_stats[S.armor] = 0f;
          modernarmor.base_stats[S.speed] = 13f;
          modernarmor.base_stats[S.dodge] = 20f;
          modernarmor.base_stats[S.attack_speed] = 60;
          modernarmor.equipment_value = 300;
          modernarmor.tech_needed = "MilitaryModern";
          modernarmor.equipmentType = EquipmentType.Armor;
          modernarmor.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(modernarmor);
          Localization.addLocalization("item_modernarmor", "modern armor");

          ItemAsset modernboots = AssetManager.items.clone("modernboots", "_equipment");
          modernboots.id = "modernboots";
          modernboots.name_class = "item_class_armor";
          modernboots.name_templates = Toolbox.splitStringIntoList("boots_name");
          modernboots.materials = List.Of<string>(new string[]{"copper"});
          modernboots.base_stats[S.armor] = 0f;
          modernboots.base_stats[S.speed] = 13f;
          modernboots.base_stats[S.dodge] = 20f;
          modernboots.base_stats[S.attack_speed] = 60;
          modernboots.equipment_value = 300;
          modernboots.tech_needed = "MilitaryModern";
          modernboots.equipmentType = EquipmentType.Boots;
          modernboots.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(modernboots);
          Localization.addLocalization("item_modernboots", "modern boots");

          ItemAsset modernhelmet = AssetManager.items.clone("modernhelmet", "_equipment");
          modernhelmet.id = "modernhelmet";
          modernhelmet.name_class = "item_class_armor";
          modernhelmet.name_templates = Toolbox.splitStringIntoList("helmet_name");
          modernhelmet.materials = List.Of<string>(new string[]{"copper"});
          modernhelmet.base_stats[S.armor] = 0f;
          modernhelmet.base_stats[S.speed] = 13f;
          modernhelmet.base_stats[S.dodge] = 20f;
          modernhelmet.base_stats[S.attack_speed] = 60;
          modernhelmet.equipment_value = 300;
          modernhelmet.tech_needed = "MilitaryModern";
          modernhelmet.equipmentType = EquipmentType.Helmet;
          modernhelmet.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(modernhelmet);
          Localization.addLocalization("item_modernhelmet", "modern helmet");


          ////////////////WEAPONS//////////////////
			ItemAsset Glock17 = AssetManager.items.clone("Glock17", "_range");
			Glock17.id = "Glock17";
            Glock17.name_class = "item_class_weapon";
            Glock17.name_templates = Toolbox.splitStringIntoList("bow_name#30");
			Glock17.materials = List.Of<string>(new string[]{"copper"});
			Glock17.projectile = "shotgun_bullet";
			Glock17.tech_needed = "MilitaryModern";
			Glock17.base_stats[S.range] = 12f;
			Glock17.base_stats[S.accuracy] = -25;
			Glock17.base_stats[S.attack_speed] = 1f;
			Glock17.base_stats[S.damage] = 35;
			Glock17.equipment_value = 300;
			Glock17.path_slash_animation = "effects/slashes/slash_punch";
			Glock17.quality = ItemQuality.Legendary;
			Glock17.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(Glock17);
			Localization.addLocalization("item_Glock17", "Glock 17");
			addgunSprite(Glock17.id, Glock17.materials[0]);

            AddPreferredWeaponToCivRaces("Glock17", 5);

            ItemAsset MP7 = AssetManager.items.clone("MP7", "_range");
            MP7.id = "MP7";
            MP7.name_class = "item_class_weapon";
            MP7.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            MP7.materials = List.Of<string>(new string[]{"copper"});
            MP7.projectile = "shotgun_bullet";
			MP7.tech_needed = "MilitaryModern";
            MP7.base_stats[S.range] = 14f;
			MP7.base_stats[S.accuracy] = -30;
            MP7.base_stats[S.attack_speed] = 12000f;
            MP7.base_stats[S.damage] = 7;
            MP7.equipment_value = 300;
            MP7.path_slash_animation = "effects/slashes/slash_punch";
            MP7.quality = ItemQuality.Legendary;
            MP7.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(MP7);
            Localization.addLocalization("item_MP7", "MP7");
            addgunSprite(MP7.id, MP7.materials[0]);

             AddPreferredWeaponToCivRaces("MP7", 5);

			ItemAsset HK416 = AssetManager.items.clone("HK416", "_range");
            HK416.id = "HK416";
            HK416.name_class = "item_class_weapon";
            HK416.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            HK416.materials = List.Of<string>(new string[]{"copper"});
            HK416.projectile = "shotgun_bullet";
			HK416.tech_needed = "MilitaryModern";
            HK416.base_stats[S.range] = 20f;
            HK416.base_stats[S.accuracy] = 5;
            HK416.base_stats[S.attack_speed] = 300f;
            HK416.base_stats[S.damage] = 60;
            HK416.equipment_value = 300;
            HK416.path_slash_animation = "effects/slashes/slash_punch";
            HK416.quality = ItemQuality.Legendary;
            HK416.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(HK416);
            Localization.addLocalization("item_HK416", "HK416");
            addgunSprite(HK416.id, HK416.materials[0]);

              AddPreferredWeaponToCivRaces("HK416", 5);

			ItemAsset M16 = AssetManager.items.clone("M16", "_range");
            M16.id = "M16";
            M16.name_class = "item_class_weapon";
            M16.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            M16.materials = List.Of<string>(new string[]{"copper"});
            M16.projectile = "shotgun_bullet";
			M16.tech_needed = "MilitaryModern";
            M16.base_stats[S.range] = 0f;
            M16.base_stats[S.accuracy] = 5;
            M16.base_stats[S.attack_speed] = 12f;
            M16.base_stats[S.damage] = 60;
            M16.equipment_value = 300;
            M16.path_slash_animation = "effects/slashes/slash_punch";
            M16.quality = ItemQuality.Legendary;
            M16.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(M16);
            Localization.addLocalization("item_M16", "M16");
            addgunSprite(M16.id, M16.materials[0]);

             AddPreferredWeaponToCivRaces("M16", 5);

			ItemAsset DesertEagle = AssetManager.items.clone("DesertEagle", "_range");
			DesertEagle.id = "DesertEagle";
			   DesertEagle.name_class = "item_class_weapon";
          DesertEagle.name_templates = Toolbox.splitStringIntoList("bow_name#30");
			DesertEagle.materials = List.Of<string>(new string[]{"copper"});
			DesertEagle.projectile = "shotgun_bullet";
			DesertEagle.tech_needed = "MilitaryModern";
			DesertEagle.base_stats[S.range] = 20f;
			DesertEagle.base_stats[S.accuracy] = 90;
			DesertEagle.base_stats[S.attack_speed] = 1f;
			DesertEagle.base_stats[S.damage] = 40;
			DesertEagle.equipment_value = 300;
			DesertEagle.path_slash_animation = "effects/slashes/slash_punch";
			DesertEagle.quality = ItemQuality.Legendary;
			DesertEagle.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(DesertEagle);
			Localization.addLocalization("item_DesertEagle", "Desert Eagle");
			addgunSprite(DesertEagle.id, DesertEagle.materials[0]);

     AddPreferredWeaponToCivRaces("DesertEagle", 5);

		  	ItemAsset malorian = AssetManager.items.clone("malorian", "_range");
            malorian.id = "malorian";
            malorian.name_class = "item_class_weapon";
          malorian.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            malorian.materials = List.Of<string>(new string[]{"copper"});
            malorian.projectile = "shotgun_bullet";
			malorian.tech_needed = "MilitaryModern";
            malorian.base_stats[S.range] = 6f;
            malorian.base_stats[S.accuracy] = 400;
            malorian.base_stats[S.attack_speed] = 70;
            malorian.base_stats[S.damage] = 3;
            malorian.equipment_value = 300;
            malorian.path_slash_animation = "effects/slashes/slash_punch";
            malorian.quality = ItemQuality.Legendary;
            malorian.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(malorian);
            Localization.addLocalization("item_malorian", "Malorian Arms 3516");
            addgunSprite(malorian.id, malorian.materials[0]);

            AddPreferredWeaponToCivRaces("malorian", 5);

			ItemAsset Uzi = AssetManager.items.clone("Uzi", "_range");
            Uzi.id = "Uzi";
          Uzi.name_class = "item_class_weapon";
          Uzi.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            Uzi.materials = List.Of<string>(new string[]{"copper"});
            Uzi.projectile = "shotgun_bullet";
            Uzi.base_stats[S.range] = 6f;
            Uzi.base_stats[S.accuracy] = -10;
            Uzi.base_stats[S.attack_speed] = 7000;
            Uzi.base_stats[S.damage] = 5;
			Uzi.tech_needed = "MilitaryModern";
            Uzi.equipment_value = 300;
            Uzi.path_slash_animation = "effects/slashes/slash_punch";
            Uzi.quality = ItemQuality.Legendary;
            Uzi.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(Uzi);
            Localization.addLocalization("item_Uzi", "Uzi");
            addgunSprite(Uzi.id, Uzi.materials[0]);

             AddPreferredWeaponToCivRaces("Uzi", 5);

			ItemAsset Minigun = AssetManager.items.clone("Minigun", "_range");
            Minigun.id = "Minigun";
Minigun.name_class = "item_class_weapon";
          Minigun.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            Minigun.materials = List.Of<string>(new string[]{"copper"});
            Minigun.projectile = "shotgun_bullet";
			Minigun.tech_needed = "MilitaryModern";
            Minigun.base_stats[S.range] = 10f;
            Minigun.base_stats[S.accuracy] = -40;
            Minigun.base_stats[S.attack_speed] = 20000f;
            Minigun.base_stats[S.projectiles] = 3;
            Minigun.base_stats[S.damage] = 13;
            Minigun.equipment_value = 300;
            Minigun.path_slash_animation = "effects/slashes/slash_punch";
            Minigun.quality = ItemQuality.Legendary;
            Minigun.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(Minigun);
            Localization.addLocalization("item_Minigun", "Minigun");
            addgunSprite(Minigun.id, Minigun.materials[0]);

             AddPreferredWeaponToCivRaces("Minigun", 5);

			ItemAsset AK47 = AssetManager.items.clone("AK47", "_range");
            AK47.id = "AK47";
           AK47.name_class = "item_class_weapon";
          AK47.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            AK47.materials = List.Of<string>(new string[]{"copper"});
            AK47.projectile = "shotgun_bullet";
			AK47.tech_needed = "MilitaryModern";
            AK47.base_stats[S.range] = 14f;
            AK47.base_stats[S.accuracy] = 3;
            AK47.base_stats[S.attack_speed] = 170f;
            AK47.base_stats[S.damage] = 13;
            AK47.equipment_value = 300;
            AK47.path_slash_animation = "effects/slashes/slash_punch";
            AK47.quality = ItemQuality.Legendary;
            AK47.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(AK47);
			Localization.addLocalization("item_AK47", "AK47");
			addgunSprite(AK47.id, AK47.materials[0]);

              AddPreferredWeaponToCivRaces("AK47", 5);

			ItemAsset AK103 = AssetManager.items.clone("AK103", "_range");
            AK103.id = "AK103";
             AK103.name_class = "item_class_weapon";
          AK103.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            AK103.materials = List.Of<string>(new string[]{"copper"});
            AK103.projectile = "shotgun_bullet";
			AK103.tech_needed = "MilitaryModern";
            AK103.base_stats[S.range] = 14f;
            AK103.base_stats[S.accuracy] = 400;
            AK103.base_stats[S.attack_speed] = 170f;
            AK103.base_stats[S.damage] = 36;
            AK103.equipment_value = 300;
            AK103.path_slash_animation = "effects/slashes/slash_punch";
            AK103.quality = ItemQuality.Legendary;
            AK103.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(AK103);
			Localization.addLocalization("item_AK103", "AK-103");
			addgunSprite(AK103.id, AK103.materials[0]);

              AddPreferredWeaponToCivRaces("AK103", 5);

          ItemAsset XM8 = AssetManager.items.clone("XM8", "_range");
          XM8.id = "XM8";
        XM8.name_class = "item_class_weapon";
          XM8.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          XM8.materials = List.Of<string>(new string[]{"copper"});
          XM8.projectile = "shotgun_bullet";
          XM8.base_stats[S.fertility] = 0.0f;
          XM8.base_stats[S.max_children] = 0f;
          XM8.base_stats[S.max_age] = 0f;
          XM8.base_stats[S.attack_speed] = 1800;
          XM8.base_stats[S.damage] = 13;
          XM8.base_stats[S.speed] = 0f;
          XM8.base_stats[S.health] = 0;
          XM8.base_stats[S.accuracy] = 400f;
          XM8.base_stats[S.range] = 14;
          XM8.base_stats[S.armor] = 0;
		  XM8.tech_needed = "MilitaryModern";
          XM8.base_stats[S.scale] = 0.0f;
          XM8.base_stats[S.dodge] = 0f;
          XM8.base_stats[S.targets] = 0f;
          XM8.base_stats[S.critical_chance] = 0.0f;
          XM8.base_stats[S.knockback] = 0f;
          XM8.base_stats[S.knockback_reduction] = 0f;
          XM8.base_stats[S.intelligence] = 0;
          XM8.base_stats[S.warfare] = 0;
          XM8.base_stats[S.diplomacy] = 0;
          XM8.base_stats[S.stewardship] = 0;
          XM8.base_stats[S.opinion] = 0f;
          XM8.base_stats[S.loyalty_traits] = 0f;
          XM8.base_stats[S.cities] = 0;
          XM8.base_stats[S.zone_range] = 0;
          XM8.equipment_value = 300;
          XM8.path_slash_animation = "effects/slashes/slash_punch";
          XM8.equipmentType = EquipmentType.Weapon;
          XM8.name_class = "item_class_weapon";

          AssetManager.items.list.AddItem(XM8);
          Localization.addLocalization("item_XM8", "XM8");
          addgunSprite(XM8.id, XM8.materials[0]);

            AddPreferredWeaponToCivRaces("XM8", 5);

			ItemAsset SGT44 = AssetManager.items.clone("SGT44", "_range");
            SGT44.id = "SGT44";
            SGT44.name_class = "item_class_weapon";
          SGT44.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            SGT44.materials = List.Of<string>(new string[]{"copper"});
            SGT44.projectile = "shotgun_bullet";
			SGT44.tech_needed = "MilitaryModern";
            SGT44.base_stats[S.range] = 14f;
            SGT44.base_stats[S.accuracy] = 40;
            SGT44.base_stats[S.attack_speed] = 70f;
            SGT44.base_stats[S.damage] = 11;
            SGT44.equipment_value = 300;
            SGT44.path_slash_animation = "effects/slashes/slash_punch";
            SGT44.quality = ItemQuality.Legendary;
            SGT44.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(SGT44);
            Localization.addLocalization("item_SGT44", "SGT44");
            addgunSprite(SGT44.id, SGT44.materials[0]);


            AddPreferredWeaponToCivRaces("SGT44", 5);

			ItemAsset ThompsonM1A1 = AssetManager.items.clone("ThompsonM1A1", "_range");
            ThompsonM1A1.id = "ThompsonM1A1";
            ThompsonM1A1.name_class = "item_class_weapon";
          ThompsonM1A1.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            ThompsonM1A1.materials = List.Of<string>(new string[]{"copper"});
            ThompsonM1A1.projectile = "shotgun_bullet";
			ThompsonM1A1.tech_needed = "MilitaryModern";
            ThompsonM1A1.base_stats[S.range] = 14f;
            ThompsonM1A1.base_stats[S.accuracy] = -30;
            ThompsonM1A1.base_stats[S.attack_speed] = 17000f;
            ThompsonM1A1.base_stats[S.damage] = 13;
            ThompsonM1A1.equipment_value = 300;
            ThompsonM1A1.path_slash_animation = "effects/slashes/slash_punch";
            ThompsonM1A1.quality = ItemQuality.Legendary;
            ThompsonM1A1.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(ThompsonM1A1);
            Localization.addLocalization("item_ThompsonM1A1", "ThompsonM1A1");
            addgunSprite(ThompsonM1A1.id, ThompsonM1A1.materials[0]);

            AddPreferredWeaponToCivRaces("ThompsonM1A1", 5);

			ItemAsset M4A1 = AssetManager.items.clone("M4A1", "_range");
			M4A1.id = "M4A1";
			 M4A1.name_class = "item_class_weapon";
          M4A1.name_templates = Toolbox.splitStringIntoList("bow_name#30");
			M4A1.materials = List.Of<string>(new string[]{"copper"});
			M4A1.projectile = "shotgun_bullet";
			M4A1.tech_needed = "MilitaryModern";
			M4A1.base_stats[S.range] = 14f;
			M4A1.base_stats[S.accuracy] = 400;
			M4A1.base_stats[S.attack_speed] = 100f;
			M4A1.base_stats[S.damage] = 40;
			M4A1.equipment_value = 300;
			M4A1.path_slash_animation = "effects/slashes/slash_punch";
			M4A1.quality = ItemQuality.Legendary;
			M4A1.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(M4A1);
			Localization.addLocalization("item_M4A1", "M4A1");
			addgunSprite(M4A1.id, M4A1.materials[0]);

              AddPreferredWeaponToCivRaces("M4A1", 5);

		  ItemAsset FAMAS = AssetManager.items.clone("FAMAS", "_range");
          FAMAS.id = "FAMAS";
          FAMAS.name_class = "item_class_weapon";
          FAMAS.name_templates = Toolbox.splitStringIntoList("bow_name#30");
          FAMAS.materials = List.Of<string>(new string[]{"copper"});
          FAMAS.projectile = "shotgun_bullet";
          FAMAS.base_stats[S.fertility] = 0.0f;
          FAMAS.base_stats[S.max_children] = 0f;
          FAMAS.base_stats[S.max_age] = 0f;
          FAMAS.base_stats[S.attack_speed] = 1800;
          FAMAS.base_stats[S.damage] = 13;
          FAMAS.base_stats[S.speed] = 0f;
          FAMAS.base_stats[S.health] = 0;
          FAMAS.base_stats[S.accuracy] = 40f;
          FAMAS.base_stats[S.range] = 14;
          FAMAS.base_stats[S.armor] = 0;
		  FAMAS.tech_needed = "MilitaryModern";
          FAMAS.base_stats[S.scale] = 0.0f;
          FAMAS.base_stats[S.dodge] = 0f;
          FAMAS.base_stats[S.targets] = 0f;
          FAMAS.base_stats[S.critical_chance] = 0.0f;
          FAMAS.base_stats[S.knockback] = 0f;
          FAMAS.base_stats[S.knockback_reduction] = 0f;
          FAMAS.base_stats[S.intelligence] = 0;
          FAMAS.base_stats[S.warfare] = 0;
          FAMAS.base_stats[S.diplomacy] = 0;
          FAMAS.base_stats[S.stewardship] = 0;
          FAMAS.base_stats[S.opinion] = 0f;
          FAMAS.base_stats[S.loyalty_traits] = 0f;
          FAMAS.base_stats[S.cities] = 0;
          FAMAS.base_stats[S.zone_range] = 0;
          FAMAS.equipment_value = 300;
          FAMAS.path_slash_animation = "effects/slashes/slash_punch";
          FAMAS.equipmentType = EquipmentType.Weapon;
          FAMAS.name_class = "item_class_weapon";

          AssetManager.items.list.AddItem(FAMAS);
          Localization.addLocalization("item_FAMAS", "FAMAS");
          addgunSprite(FAMAS.id, FAMAS.materials[0]);


              AddPreferredWeaponToCivRaces("FAMAS", 5);

			ItemAsset Sniper = AssetManager.items.clone("Sniper", "_range");
            Sniper.id = "Sniper";
           Sniper.name_class = "item_class_weapon";
          Sniper.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            Sniper.materials = List.Of<string>(new string[]{"copper"});
            Sniper.projectile = "shotgun_bullet";
			Sniper.tech_needed = "MilitaryModern";
            Sniper.base_stats[S.range] = 40f;
            Sniper.base_stats[S.accuracy] = 5;
            Sniper.base_stats[S.attack_speed] = -200f;
            Sniper.base_stats[S.damage] = 200;
            Sniper.equipment_value = 300;
            Sniper.path_slash_animation = "effects/slashes/slash_punch";
            Sniper.quality = ItemQuality.Legendary;
            Sniper.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(Sniper);
            Localization.addLocalization("item_Sniper", "Sniper");
            addgunSprite(Sniper.id, Sniper.materials[0]);

                AddPreferredWeaponToCivRaces("Sniper", 5);

			ItemAsset RocketLauncher = AssetManager.items.clone("RocketLauncher", "_range");
            RocketLauncher.id = "RocketLauncher";
            RocketLauncher.name_class = "item_class_weapon";
            RocketLauncher.name_templates = Toolbox.splitStringIntoList("bow_name#30");
            RocketLauncher.materials = List.Of<string>(new string[]{"copper"});
            RocketLauncher.projectile = "RPGload";
            RocketLauncher.base_stats[S.range] = 14f;
			RocketLauncher.tech_needed = "MilitaryModern";
            RocketLauncher.base_stats[S.accuracy] = 400;
            RocketLauncher.base_stats[S.attack_speed] = -5000f;
            RocketLauncher.base_stats[S.damage] = 400;
            RocketLauncher.equipment_value = 300;
            RocketLauncher.path_slash_animation = "effects/slashes/slash_punch";
            RocketLauncher.quality = ItemQuality.Legendary;
            RocketLauncher.equipmentType = EquipmentType.Weapon;

            AssetManager.items.list.AddItem(RocketLauncher);
            Localization.addLocalization("item_RocketLauncher", "Rocket Propelled Grenade (RPG)");
            addgunSprite(RocketLauncher.id, RocketLauncher.materials[0]);

    AddPreferredWeaponToCivRaces("RocketLauncher", 5);


//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////MODERN/////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////
//////////////////////////////////////////////////////////////////////////////

                ///////////ARMOR///////////

           ItemAsset futurearmor = AssetManager.items.clone("futurearmor", "_equipment");
          futurearmor.id = "futurearmor";
          futurearmor.name_class = "item_class_armor";
          futurearmor.name_templates = Toolbox.splitStringIntoList("armor_name");
          futurearmor.materials = List.Of<string>(new string[]{"copper"});
          futurearmor.base_stats[S.armor] = 15f;
          futurearmor.base_stats[S.speed] = 4f;
          futurearmor.base_stats[S.dodge] = 10f;
          futurearmor.equipment_value = 500;
          futurearmor.tech_needed = "Future";
          futurearmor.equipmentType = EquipmentType.Armor;
          futurearmor.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(futurearmor);
          Localization.addLocalization("item_futurearmor", "future armor");

          ItemAsset futureboots = AssetManager.items.clone("futureboots", "_equipment");
          futureboots.id = "futureboots";
          futureboots.name_class = "item_class_armor";
          futureboots.name_templates = Toolbox.splitStringIntoList("boots_name");
          futureboots.materials = List.Of<string>(new string[]{"copper"});
          futureboots.base_stats[S.armor] = 15f;
          futureboots.base_stats[S.speed] = 4f;
          futureboots.base_stats[S.dodge] = 10f;
          futureboots.equipment_value = 500;
          futureboots.tech_needed = "Future";
          futureboots.equipmentType = EquipmentType.Boots;
          futureboots.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(futureboots);
          Localization.addLocalization("item_futureboots", "future boots");

          ItemAsset futurehelmet = AssetManager.items.clone("futurehelmet", "_equipment");
          futurehelmet.id = "futurehelmet";
          futurehelmet.name_class = "item_class_armor";
          futurehelmet.name_templates = Toolbox.splitStringIntoList("helmet_name");
          futurehelmet.materials = List.Of<string>(new string[]{"copper"});
          futurehelmet.base_stats[S.armor] = 15f;
          futurehelmet.base_stats[S.speed] = 4f;
          futurehelmet.base_stats[S.dodge] = 10f;
          futurehelmet.equipment_value = 500;
          futurehelmet.tech_needed = "Future";
          futurehelmet.equipmentType = EquipmentType.Helmet;
          futurehelmet.name_class = "item_class_armor";

          AssetManager.items.list.AddItem(futurehelmet);
          Localization.addLocalization("item_futurehelmet", "future helmet");

			static void makecraftable()
			{
			}



		}

public enum ArmorTechTier {
    None,
    Renaissance,
    Industrial,
    Modern,
    Future
}

public static class ArmorTechOverride {
    public static ArmorTechTier OverrideTier = ArmorTechTier.None;
}

[HarmonyPatch(typeof(City), "tryProduceItem")]
public static class City_TryProduceItem_ArmorPatch {
    static void Prefix(Actor pActor, ItemProductionOrder pOrder) {
        if (pOrder == ItemProductionOrder.RandomArmor) {
            Culture culture = pActor.getCulture();
            if (culture != null) {
                if (culture.hasTech("Future")) {
                    ArmorTechOverride.OverrideTier = ArmorTechTier.Future;
                }
                else if (culture.hasTech("MilitaryModern")) {
                    ArmorTechOverride.OverrideTier = ArmorTechTier.Modern;
                }
                else if (culture.hasTech("Firearms")) {
                    ArmorTechOverride.OverrideTier = ArmorTechTier.Industrial;
                }
                else if (culture.hasTech("Renaissance")) {
                    ArmorTechOverride.OverrideTier = ArmorTechTier.Renaissance;
                }
                else {
                    ArmorTechOverride.OverrideTier = ArmorTechTier.None;
                }
            }
        }
    }
    }

    static void Postfix(Actor pActor, ItemProductionOrder pOrder) {
        if (pOrder == ItemProductionOrder.RandomArmor) {
            ArmorTechOverride.OverrideTier = ArmorTechTier.None;
        }
    }

[HarmonyPatch(typeof(ItemLibrary), "getEquipmentID")]
public static class CustomArmorEquipmentIDPatch {
    static void Postfix(EquipmentType pType, ref string __result) {
        if (pType == EquipmentType.Helmet || pType == EquipmentType.Armor || pType == EquipmentType.Boots) {
            if (ArmorTechOverride.OverrideTier != ArmorTechTier.None) {
                switch (pType) {
                    case EquipmentType.Helmet:
                        switch (ArmorTechOverride.OverrideTier) {
                            case ArmorTechTier.Future:
                                __result = "futurehelmet";
                                break;
                            case ArmorTechTier.Modern:
                                __result = "modernhelmet";
                                break;
                            case ArmorTechTier.Industrial:
                                __result = "wwhelmet";
                                break;
                            case ArmorTechTier.Renaissance:
                                __result = "pristinehelmet";
                                break;
                        }
                        break;
                    case EquipmentType.Armor:
                        switch (ArmorTechOverride.OverrideTier) {
                            case ArmorTechTier.Future:
                                __result = "futurearmor";
                                break;
                            case ArmorTechTier.Modern:
                                __result = "modernarmor";
                                break;
                            case ArmorTechTier.Industrial:
                                __result = "wwarmor";
                                break;
                            case ArmorTechTier.Renaissance:
                                __result = "pristinearmor";
                                break;
                        }
                        break;
                    case EquipmentType.Boots:
                        switch (ArmorTechOverride.OverrideTier) {
                            case ArmorTechTier.Future:
                                __result = "futureboots";
                                break;
                            case ArmorTechTier.Modern:
                                __result = "modernboots";
                                break;
                            case ArmorTechTier.Industrial:
                                __result = "wwboots";
                                break;
                            case ArmorTechTier.Renaissance:
                                __result = "pristineboots";
                                break;
                        }
                        break;
                }
            }
        }
    }
    }










			private static void AddPreferredWeaponToCivRaces(string weaponId, int amount)
{
    foreach (Race race in AssetManager.raceLibrary.list)
    {
        if (race.civilization)
        {
            for (int i = 0; i < amount; i++)
            {
                race.preferred_weapons.Add(weaponId);
            }
        }
    }
}

/*
		
		public static void toggleGuns()
        {
            Main.modifyBoolOption("GunOption", PowerButtons.GetToggleValue("Gun_toggle"));
            if (PowerButtons.GetToggleValue("Gun_toggle"))
            {
                turnOnGuns();
                return;
            }
            turnOffGuns();
        }
		

			public static void turnOnGuns()
			{
				
								Race human = AssetManager.raceLibrary.get("human");
				Race orc = AssetManager.raceLibrary.get("orc");
				Race dwarf = AssetManager.raceLibrary.get("dwarf");
				Race elf = AssetManager.raceLibrary.get("elf");
				
				human.preferred_weapons.Add("Mp5");
				human.preferred_weapons.Add("Uzi");
				human.preferred_weapons.Add("Sniper");
				human.preferred_weapons.Add("RocketLauncher");
				human.preferred_weapons.Add("mm9");
				human.preferred_weapons.Add("Minigun");
				human.preferred_weapons.Add("AK47");
				human.preferred_weapons.Add("ThompsonM1A1");
				human.preferred_weapons.Add("XM8");
				human.preferred_weapons.Add("SGT44");
				human.preferred_weapons.Add("M4A1"); 
				human.preferred_weapons.Add("FAMAS");
				human.preferred_weapons.Add("malorian");
				human.preferred_weapons.Add("AK103");	
				human.preferred_weapons.Add("MP7");	
				human.preferred_weapons.Add("Musket");	
				human.preferred_weapons.Add("HK416");	
				human.preferred_weapons.Add("M16");	
				human.preferred_weapons.Add("DesertEagle");	
				human.preferred_weapons.Add("Glock17");	
				
				orc.preferred_weapons.Add("Mp5");
				orc.preferred_weapons.Add("Uzi");
				orc.preferred_weapons.Add("Sniper");
				orc.preferred_weapons.Add("RocketLauncher");
				orc.preferred_weapons.Add("mm9");
				orc.preferred_weapons.Add("Minigun");
				orc.preferred_weapons.Add("AK47");
				orc.preferred_weapons.Add("ThompsonM1A1");
				orc.preferred_weapons.Add("XM8");
				orc.preferred_weapons.Add("SGT44");
				orc.preferred_weapons.Add("M4A1"); 
				orc.preferred_weapons.Add("FAMAS");
				orc.preferred_weapons.Add("malorian");			
				orc.preferred_weapons.Add("AK103");	
				orc.preferred_weapons.Add("MP7");	
				orc.preferred_weapons.Add("Musket");	
				orc.preferred_weapons.Add("HK416");					
				orc.preferred_weapons.Add("M16");	
				orc.preferred_weapons.Add("DesertEagle");	
				orc.preferred_weapons.Add("Glock17");	
				
				dwarf.preferred_weapons.Add("Mp5");
				dwarf.preferred_weapons.Add("Uzi");
				dwarf.preferred_weapons.Add("Sniper");
				dwarf.preferred_weapons.Add("RocketLauncher");
				dwarf.preferred_weapons.Add("mm9");
				dwarf.preferred_weapons.Add("Minigun");
				dwarf.preferred_weapons.Add("AK47");
				dwarf.preferred_weapons.Add("ThompsonM1A1");
				dwarf.preferred_weapons.Add("XM8");
				dwarf.preferred_weapons.Add("SGT44");
				dwarf.preferred_weapons.Add("M4A1"); 
				dwarf.preferred_weapons.Add("FAMAS");
				dwarf.preferred_weapons.Add("malorian");
				dwarf.preferred_weapons.Add("AK103");	
				dwarf.preferred_weapons.Add("MP7");	
				dwarf.preferred_weapons.Add("Musket");	
				dwarf.preferred_weapons.Add("HK416");	
				dwarf.preferred_weapons.Add("M16");	
				dwarf.preferred_weapons.Add("DesertEagle");	
				dwarf.preferred_weapons.Add("Glock17");			
				
				elf.preferred_weapons.Add("Mp5");
				elf.preferred_weapons.Add("Uzi");
				elf.preferred_weapons.Add("Sniper");
				elf.preferred_weapons.Add("RocketLauncher");
				elf.preferred_weapons.Add("mm9");
				elf.preferred_weapons.Add("Minigun");
				elf.preferred_weapons.Add("AK47");
				elf.preferred_weapons.Add("ThompsonM1A1");
				elf.preferred_weapons.Add("XM8");
				elf.preferred_weapons.Add("SGT44");
				elf.preferred_weapons.Add("M4A1"); 
				elf.preferred_weapons.Add("FAMAS");
				elf.preferred_weapons.Add("malorian");				
				elf.preferred_weapons.Add("AK103");	
				elf.preferred_weapons.Add("MP7");	
				elf.preferred_weapons.Add("HK416");		
				elf.preferred_weapons.Add("M16");	
				elf.preferred_weapons.Add("DesertEagle");	
				elf.preferred_weapons.Add("Glock17");			


            }
			public static void turnOffGuns()
			{
				
				Race human = AssetManager.raceLibrary.get("human");
				Race orc = AssetManager.raceLibrary.get("orc");
				Race dwarf = AssetManager.raceLibrary.get("dwarf");
				Race elf = AssetManager.raceLibrary.get("elf");
				
				human.preferred_weapons.Remove("Mp5");
				human.preferred_weapons.Remove("Uzi");
				human.preferred_weapons.Remove("Sniper");
				human.preferred_weapons.Remove("RocketLauncher");
				human.preferred_weapons.Remove("mm9");
				human.preferred_weapons.Remove("Minigun");
				human.preferred_weapons.Remove("AK47");
				human.preferred_weapons.Remove("ThompsonM1A1");
				human.preferred_weapons.Remove("XM8");
				human.preferred_weapons.Remove("SGT44");
				human.preferred_weapons.Remove("M4A1"); 
				human.preferred_weapons.Remove("FAMAS");
				human.preferred_weapons.Remove("malorian");
				human.preferred_weapons.Remove("PipePistol");				
				human.preferred_weapons.Remove("PipeRifle");	
				human.preferred_weapons.Remove("PipeShotgun");	
				human.preferred_weapons.Remove("AK103");	
				human.preferred_weapons.Remove("MP7");	
				human.preferred_weapons.Remove("Musket");	
				human.preferred_weapons.Remove("HK416");	
				human.preferred_weapons.Remove("M16");	
				human.preferred_weapons.Remove("DesertEagle");	
				human.preferred_weapons.Remove("Glock17");	
				
				orc.preferred_weapons.Remove("Mp5");
				orc.preferred_weapons.Remove("Uzi");
				orc.preferred_weapons.Remove("Sniper");
				orc.preferred_weapons.Remove("RocketLauncher");
				orc.preferred_weapons.Remove("mm9");
				orc.preferred_weapons.Remove("Minigun");
				orc.preferred_weapons.Remove("AK47");
				orc.preferred_weapons.Remove("ThompsonM1A1");
				orc.preferred_weapons.Remove("XM8");
				orc.preferred_weapons.Remove("SGT44");
				orc.preferred_weapons.Remove("M4A1"); 
				orc.preferred_weapons.Remove("FAMAS");
				orc.preferred_weapons.Remove("malorian");	
				orc.preferred_weapons.Remove("PipePistol");				
				orc.preferred_weapons.Remove("PipeRifle");	
				orc.preferred_weapons.Remove("PipeShotgun");		
				orc.preferred_weapons.Remove("AK103");	
				orc.preferred_weapons.Remove("MP7");	
				orc.preferred_weapons.Remove("Musket");	
				orc.preferred_weapons.Remove("HK416");					
				orc.preferred_weapons.Remove("M16");	
				orc.preferred_weapons.Remove("DesertEagle");	
				orc.preferred_weapons.Remove("Glock17");	
				
				dwarf.preferred_weapons.Remove("Mp5");
				dwarf.preferred_weapons.Remove("Uzi");
				dwarf.preferred_weapons.Remove("Sniper");
				dwarf.preferred_weapons.Remove("RocketLauncher");
				dwarf.preferred_weapons.Remove("mm9");
				dwarf.preferred_weapons.Remove("Minigun");
				dwarf.preferred_weapons.Remove("AK47");
				dwarf.preferred_weapons.Remove("ThompsonM1A1");
				dwarf.preferred_weapons.Remove("XM8");
				dwarf.preferred_weapons.Remove("SGT44");
				dwarf.preferred_weapons.Remove("M4A1"); 
				dwarf.preferred_weapons.Remove("FAMAS");
				dwarf.preferred_weapons.Remove("malorian");
				dwarf.preferred_weapons.Remove("PipePistol");				
				dwarf.preferred_weapons.Remove("PipeRifle");	
				dwarf.preferred_weapons.Remove("PipeShotgun");		
				dwarf.preferred_weapons.Remove("AK103");	
				dwarf.preferred_weapons.Remove("MP7");	
				dwarf.preferred_weapons.Remove("Musket");	
				dwarf.preferred_weapons.Remove("HK416");	
				dwarf.preferred_weapons.Remove("M16");	
				dwarf.preferred_weapons.Remove("DesertEagle");	
				dwarf.preferred_weapons.Remove("Glock17");			
				
				elf.preferred_weapons.Remove("Mp5");
				elf.preferred_weapons.Remove("Uzi");
				elf.preferred_weapons.Remove("Sniper");
				elf.preferred_weapons.Remove("RocketLauncher");
				elf.preferred_weapons.Remove("mm9");
				elf.preferred_weapons.Remove("Minigun");
				elf.preferred_weapons.Remove("AK47");
				elf.preferred_weapons.Remove("ThompsonM1A1");
				elf.preferred_weapons.Remove("XM8");
				elf.preferred_weapons.Remove("SGT44");
				elf.preferred_weapons.Remove("M4A1"); 
				elf.preferred_weapons.Remove("FAMAS");
				elf.preferred_weapons.Remove("malorian");				
				elf.preferred_weapons.Remove("AK103");	
				elf.preferred_weapons.Remove("MP7");	
				elf.preferred_weapons.Remove("HK416");		
				elf.preferred_weapons.Remove("M16");	
				elf.preferred_weapons.Remove("DesertEagle");	
				elf.preferred_weapons.Remove("Glock17");			
				


            }
			
		public static void togglePipeGuns()
        {
            Main.modifyBoolOption("PipeGunOption", PowerButtons.GetToggleValue("PipeGun_toggle"));
            if (PowerButtons.GetToggleValue("PipeGun_toggle"))
            {
                turnOnPipeGuns();
                return;
            }
            turnOffPipeGuns();
        }
		

			public static void turnOnPipeGuns()
			{
                Race human = AssetManager.raceLibrary.get("human");
                Race orc = AssetManager.raceLibrary.get("orc");
                Race dwarf = AssetManager.raceLibrary.get("dwarf");
                Race elf = AssetManager.raceLibrary.get("elf");
				

				human.preferred_weapons.Add("PipePistol");				
				human.preferred_weapons.Add("PipeRifle");	
				human.preferred_weapons.Add("PipeShotgun");	


				orc.preferred_weapons.Add("PipePistol");				
				orc.preferred_weapons.Add("PipeRifle");	
				orc.preferred_weapons.Add("PipeShotgun");


				dwarf.preferred_weapons.Add("PipePistol");				
				dwarf.preferred_weapons.Add("PipeRifle");	
				dwarf.preferred_weapons.Add("PipeShotgun");	

				
				elf.preferred_weapons.Add("PipePistol");				
				elf.preferred_weapons.Add("PipeRifle");	
				elf.preferred_weapons.Add("PipeShotgun");	


            }
			public static void turnOffPipeGuns()
			{
                Race human = AssetManager.raceLibrary.get("human");
                Race orc = AssetManager.raceLibrary.get("orc");
                Race dwarf = AssetManager.raceLibrary.get("dwarf");
                Race elf = AssetManager.raceLibrary.get("elf");

 				human.preferred_weapons.Remove("PipePistol");				
				human.preferred_weapons.Remove("PipeRifle");	
				human.preferred_weapons.Remove("PipeShotgun");


				orc.preferred_weapons.Remove("PipePistol");				
				orc.preferred_weapons.Remove("PipeRifle");	
				orc.preferred_weapons.Remove("PipeShotgun");


				dwarf.preferred_weapons.Remove("PipePistol");				
				dwarf.preferred_weapons.Remove("PipeRifle");	
				dwarf.preferred_weapons.Remove("PipeShotgun");	

				
				elf.preferred_weapons.Remove("PipePistol");				
				elf.preferred_weapons.Remove("PipeRifle");	
				elf.preferred_weapons.Remove("PipeShotgun");	


            }
		*/


			static void addgunSprite(string id, string material)
			{
				var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
				var sprite = Resources.Load<Sprite>("ItemTextures/w_" + id + "_" + material);
				dictItems.Add(sprite.name, sprite);
			}
        }     	
    }
