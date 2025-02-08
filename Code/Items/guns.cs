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
		nonannoyingbomb.explode_tile = true;
		nonannoyingbomb.damageBuildings = true;
		nonannoyingbomb.damage = 0;
		nonannoyingbomb.setFire = true;
          AssetManager.terraform.add(nonannoyingbomb);

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
DankyMatter.sound_launch = "event:/SFX/EXPLOSIONS/ExplosionAntimatterBomb";
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
           cybermissileprojectile.endEffect = "fx_boat_explosion";
	      cybermissileprojectile.draw_light_size = 1f;
          cybermissileprojectile.terraformOption = "nonannoyingbomb";
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
          artilleryshell.endEffect = "fx_boat_explosion";
          artilleryshell.terraformOption = "nonannoyingbomb";
          artilleryshell.terraformRange = 3;
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

        ProjectileAsset crabartilleryshell = new ProjectileAsset();
          crabartilleryshell.id = "crabartilleryshell";
          crabartilleryshell.texture = "artilleryshell";
          crabartilleryshell.trailEffect_enabled = false;
	      crabartilleryshell.look_at_target = true;
          crabartilleryshell.draw_light_area = true;
	      crabartilleryshell.draw_light_size = 1f;
          crabartilleryshell.terraformOption = "crab_bomb";
          crabartilleryshell.terraformRange = 5;
          crabartilleryshell.endEffect = "fx_explosion_meteorite";
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
	      seismicrod.look_at_target = true;
          seismicrod.draw_light_area = true;
          seismicrod.endEffect = "fx_explosion_meteorite";
	      seismicrod.draw_light_size = 1f;
          seismicrod.terraformOption = "nonannoyingbomb";
          seismicrod.terraformRange = 20;
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
			
			//if(Main.settings.Mp5){			            
			ItemAsset Mp5 = AssetManager.items.clone("Mp5", "_range");
            Mp5.id = "Mp5";
            Mp5.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            Mp5.materials = List.Of<string>(new string[] { "iron" });
            Mp5.projectile = "shotgun_bullet";
			Mp5.tech_needed = "Firearms";			
            Mp5.base_stats[S.range] = 14f;
            Mp5.base_stats[S.accuracy] = 5;
            Mp5.base_stats[S.attack_speed] = 9000f;
            Mp5.base_stats[S.damage] = 3;
            Mp5.base_stats[S.health] = 10;
            Mp5.equipment_value = 500;
            Mp5.path_slash_animation = "effects/slashes/slash_punch";
            Mp5.quality = ItemQuality.Legendary;
            Mp5.equipmentType = EquipmentType.Weapon;
			
            AssetManager.items.list.AddItem(Mp5);
            Localization.addLocalization("item_Mp5", "Mp5"); 
            addgunSprite(Mp5.id, Mp5.materials[0]);
			//}
			//if(Main.settings.NorincoCQ){			            

			
			//if(Main.settings.Sniper){			            
			ItemAsset Sniper = AssetManager.items.clone("Sniper", "_range");
            Sniper.id = "Sniper";
            Sniper.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            Sniper.materials = List.Of<string>(new string[] { "iron" });
            Sniper.projectile = "shotgun_bullet";
			Sniper.tech_needed = "Firearms";
            Sniper.base_stats[S.range] = 20f;
            Sniper.base_stats[S.accuracy] = 5;
            Sniper.base_stats[S.attack_speed] = 12f;
            Sniper.base_stats[S.damage] = 193;
            Sniper.base_stats[S.health] = 10;
            Sniper.equipment_value = 500;
            Sniper.path_slash_animation = "effects/slashes/slash_punch";
            Sniper.quality = ItemQuality.Legendary;
            Sniper.equipmentType = EquipmentType.Weapon;
            AssetManager.items.list.AddItem(Sniper);
            Localization.addLocalization("item_Sniper", "Sniper");
            addgunSprite(Sniper.id, Sniper.materials[0]);
			//}
			
			//if(Main.settings.mm9){			            
			ItemAsset mm9 = AssetManager.items.clone("mm9", "_range");
            mm9.id = "mm9";
            mm9.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            mm9.materials = List.Of<string>(new string[] { "iron" });
            mm9.projectile = "shotgun_bullet";
			mm9.tech_needed = "Firearms";
            mm9.base_stats[S.range] = 6f;
            mm9.base_stats[S.accuracy] = 400;
            mm9.base_stats[S.attack_speed] = 70;
            mm9.base_stats[S.damage] = 3;
            mm9.base_stats[S.health] = 10;
            mm9.equipment_value = 500;
            mm9.path_slash_animation = "effects/slashes/slash_punch";
            mm9.quality = ItemQuality.Legendary;
            mm9.equipmentType = EquipmentType.Weapon;
            AssetManager.items.list.AddItem(mm9);
            Localization.addLocalization("item_mm9", "9mm");
            addgunSprite(mm9.id, mm9.materials[0]);
			//}
			////if(Main.settings.RocketLauncher){			            
			ItemAsset RocketLauncher = AssetManager.items.clone("RocketLauncher", "_range");
            RocketLauncher.id = "RocketLauncher";
            RocketLauncher.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            RocketLauncher.materials = List.Of<string>(new string[] { "iron" });
            RocketLauncher.projectile = "jetrocketprojectile";
            RocketLauncher.base_stats[S.range] = 14f;
			RocketLauncher.tech_needed = "Firearms";
            RocketLauncher.base_stats[S.accuracy] = 400;
            RocketLauncher.base_stats[S.attack_speed] = -101f;
            RocketLauncher.base_stats[S.damage] = 100;
            RocketLauncher.base_stats[S.health] = 10;
            RocketLauncher.equipment_value = 1000;
            RocketLauncher.path_slash_animation = "effects/slashes/slash_punch";
            RocketLauncher.quality = ItemQuality.Legendary;
            RocketLauncher.equipmentType = EquipmentType.Weapon;
            AssetManager.items.list.AddItem(RocketLauncher);
            Localization.addLocalization("item_RocketLauncher", "Rocket Propelled Grenade (RPG)");
            addgunSprite(RocketLauncher.id, RocketLauncher.materials[0]);

          ProjectileAsset jetrocketprojectile = new ProjectileAsset();
          jetrocketprojectile.id = "jetrocketprojectile";
          jetrocketprojectile.texture = "jetrocketprojectile";
          jetrocketprojectile.trailEffect_enabled = false;
	      jetrocketprojectile.look_at_target = true;
          jetrocketprojectile.draw_light_area = true;
	      jetrocketprojectile.draw_light_size = 1f;
          jetrocketprojectile.endEffect = "fx_fireball_explosion";
          jetrocketprojectile.terraformOption = "nonannoyingbomb";
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
		JetRocket.base_stats[S.range] = 14f;
		JetRocket.base_stats[S.targets] = 2f;
		JetRocket.base_stats[S.damage] = 60f;
		JetRocket.base_stats[S.damage_range] = 0.5f;
            JetRocket.base_stats[S.accuracy] = 400;
            JetRocket.base_stats[S.health] = 10;
            JetRocket.path_slash_animation = "effects/slashes/slash_punch";

 ProjectileAsset helirocketprojectile = new ProjectileAsset();
          helirocketprojectile.id = "helirocketprojectile";
          helirocketprojectile.texture = "jetrocketprojectile";
          helirocketprojectile.trailEffect_enabled = false;
	      helirocketprojectile.look_at_target = true;
          helirocketprojectile.draw_light_area = true;
	      helirocketprojectile.draw_light_size = 1f;
          helirocketprojectile.terraformOption = "nonannoyingbomb";
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
		heliRocket.base_stats[S.range] = 14f;
		heliRocket.base_stats[S.targets] = 1f;
		heliRocket.base_stats[S.damage] = 16f;
		heliRocket.base_stats[S.damage_range] = 0.5f;
            heliRocket.base_stats[S.accuracy] = 400;
            heliRocket.base_stats[S.health] = 10;
            heliRocket.path_slash_animation = "effects/slashes/slash_punch";
			
			//}
	

			
			ItemAsset Uzi = AssetManager.items.clone("Uzi", "_range");
            Uzi.id = "Uzi";
            Uzi.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            Uzi.materials = List.Of<string>(new string[] { "iron" });
            Uzi.projectile = "shotgun_bullet";
            Uzi.base_stats[S.range] = 6f;
            Uzi.base_stats[S.accuracy] = 400;
            Uzi.base_stats[S.attack_speed] = 70;
            Uzi.base_stats[S.damage] = 3;
            Uzi.base_stats[S.health] = 10;
			Uzi.tech_needed = "Firearms";
            Uzi.equipment_value = 500;
            Uzi.path_slash_animation = "effects/slashes/slash_punch";
            Uzi.quality = ItemQuality.Legendary;
            Uzi.equipmentType = EquipmentType.Weapon;
            AssetManager.items.list.AddItem(Uzi);
            Localization.addLocalization("item_Uzi", "Uzi");
            addgunSprite(Uzi.id, Uzi.materials[0]);
			
			ItemAsset Minigun = AssetManager.items.clone("Minigun", "_range");
            Minigun.id = "Minigun";
            Minigun.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            Minigun.materials = List.Of<string>(new string[] { "iron" });
            Minigun.projectile = "shotgun_bullet";
			Minigun.tech_needed = "Firearms";			
            Minigun.base_stats[S.range] = 14f;
            Minigun.base_stats[S.accuracy] = 3;
            Minigun.base_stats[S.attack_speed] = 200f;
            Minigun.base_stats[S.damage] = 13;
            Minigun.base_stats[S.health] = 10;
            Minigun.equipment_value = 500;
            Minigun.path_slash_animation = "effects/slashes/slash_punch";
            Minigun.quality = ItemQuality.Legendary;
            Minigun.equipmentType = EquipmentType.Weapon;
			
            AssetManager.items.list.AddItem(Minigun);
            Localization.addLocalization("item_Minigun", "Minigun"); 
            addgunSprite(Minigun.id, Minigun.materials[0]);
			
			ItemAsset GunshipCannon = AssetManager.items.clone("GunshipCannon", "_range");
            GunshipCannon.id = "GunshipCannon";
            GunshipCannon.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            GunshipCannon.materials = List.Of<string>(new string[] { "iron" });
            GunshipCannon.projectile = "GunshipBullet";
			GunshipCannon.tech_needed = "Firearms";			
            GunshipCannon.base_stats[S.range] = 14f;
            GunshipCannon.base_stats[S.accuracy] = 400;
            GunshipCannon.base_stats[S.attack_speed] = 200f;
            GunshipCannon.base_stats[S.damage] = 13;
            GunshipCannon.base_stats[S.health] = 10;
            GunshipCannon.equipment_value = 500;
            GunshipCannon.path_slash_animation = "effects/slashes/slash_punch";
            GunshipCannon.quality = ItemQuality.Legendary;
            GunshipCannon.equipmentType = EquipmentType.Weapon;
			
            AssetManager.items.list.AddItem(GunshipCannon);
            Localization.addLocalization("item_GunshipCannon", "GunshipCannon"); 
            addgunSprite(GunshipCannon.id, GunshipCannon.materials[0]);
			
			ItemAsset AK47 = AssetManager.items.clone("AK47", "_range");
            AK47.id = "AK47";
            AK47.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            AK47.materials = List.Of<string>(new string[] { "iron" });
            AK47.projectile = "shotgun_bullet";
			AK47.tech_needed = "Firearms";			
            AK47.base_stats[S.range] = 14f;
            AK47.base_stats[S.accuracy] = 3;
            AK47.base_stats[S.attack_speed] = 170f;
            AK47.base_stats[S.damage] = 13;
            AK47.base_stats[S.health] = 10;
            AK47.equipment_value = 500;
            AK47.path_slash_animation = "effects/slashes/slash_punch";
            AK47.quality = ItemQuality.Legendary;
            AK47.equipmentType = EquipmentType.Weapon;
			AssetManager.items.list.AddItem(AK47);
			Localization.addLocalization("item_AK47", "AK47");
			addgunSprite(AK47.id, AK47.materials[0]);
			
			
			ItemAsset AK103 = AssetManager.items.clone("AK103", "_range");
            AK103.id = "AK103";
            AK103.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            AK103.materials = List.Of<string>(new string[] { "iron" });
            AK103.projectile = "shotgun_bullet";
			AK103.tech_needed = "Firearms";			
            AK103.base_stats[S.range] = 14f;
            AK103.base_stats[S.accuracy] = 400;
            AK103.base_stats[S.attack_speed] = 170f;
            AK103.base_stats[S.damage] = 13;
            AK103.base_stats[S.health] = 10;
            AK103.equipment_value = 500;
            AK103.path_slash_animation = "effects/slashes/slash_punch";
            AK103.quality = ItemQuality.Legendary;
            AK103.equipmentType = EquipmentType.Weapon;
			AssetManager.items.list.AddItem(AK103);
			Localization.addLocalization("item_AK103", "AK-103");
			addgunSprite(AK103.id, AK103.materials[0]);
			


			
          ItemAsset XM8 = AssetManager.items.clone("XM8", "_range");
          XM8.id = "XM8";
          XM8.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "bow_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
          XM8.materials = List.Of<string>(new string[]{"iron"});
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
		  XM8.tech_needed = "Firearms";		
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
          XM8.equipment_value = 500;
          XM8.path_slash_animation = "effects/slashes/slash_punch";
          XM8.equipmentType = EquipmentType.Weapon;
          XM8.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(XM8);
          Localization.addLocalization("item_XM8", "XM8");
          addgunSprite(XM8.id, XM8.materials[0]);
		  
			ItemAsset SGT44 = AssetManager.items.clone("SGT44", "_range");
            SGT44.id = "SGT44";
            SGT44.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            SGT44.materials = List.Of<string>(new string[] { "iron" });
            SGT44.projectile = "shotgun_bullet";
			SGT44.path_icon = "ui/Icons/items/icon_SGT44_Gun";
			SGT44.tech_needed = "Firearms";			
            SGT44.base_stats[S.range] = 14f;
            SGT44.base_stats[S.accuracy] = 400;
            SGT44.base_stats[S.attack_speed] = 70f;
            SGT44.base_stats[S.damage] = 11;
            SGT44.base_stats[S.health] = 10;
            SGT44.equipment_value = 500;
            SGT44.path_slash_animation = "effects/slashes/slash_punch";
            SGT44.quality = ItemQuality.Legendary;
            SGT44.equipmentType = EquipmentType.Weapon;
			
					

            AssetManager.items.list.AddItem(SGT44);
            Localization.addLocalization("item_SGT44", "SGT44"); 
            addgunSprite(SGT44.id, SGT44.materials[0]);
			
			ItemAsset ThompsonM1A1 = AssetManager.items.clone("ThompsonM1A1", "_range");
            ThompsonM1A1.id = "ThompsonM1A1";
            ThompsonM1A1.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            ThompsonM1A1.materials = List.Of<string>(new string[] { "iron" });
            ThompsonM1A1.projectile = "shotgun_bullet";
			ThompsonM1A1.tech_needed = "Firearms";			
            ThompsonM1A1.base_stats[S.range] = 14f;
            ThompsonM1A1.base_stats[S.accuracy] = 400;
            ThompsonM1A1.base_stats[S.attack_speed] = 170f;
            ThompsonM1A1.base_stats[S.damage] = 13;
            ThompsonM1A1.base_stats[S.health] = 10;
            ThompsonM1A1.equipment_value = 500;
            ThompsonM1A1.path_slash_animation = "effects/slashes/slash_punch";
            ThompsonM1A1.quality = ItemQuality.Legendary;
            ThompsonM1A1.equipmentType = EquipmentType.Weapon;
			
            AssetManager.items.list.AddItem(ThompsonM1A1);
            Localization.addLocalization("item_ThompsonM1A1", "ThompsonM1A1"); 
            addgunSprite(ThompsonM1A1.id, ThompsonM1A1.materials[0]);
			
			ItemAsset M4A1 = AssetManager.items.clone("M4A1", "_range");
			M4A1.id = "M4A1";
			M4A1.name_templates = Toolbox.splitStringIntoList(new string[]
			{
				"sword_name#30",
				"sword_name_king#3",
				"weapon_name_city",
				"weapon_name_kingdom",
				"weapon_name_culture",
				"weapon_name_enemy_king",
				"weapon_name_enemy_kingdom"
			});
			M4A1.materials = List.Of<string>(new string[] { "iron" });
			M4A1.projectile = "shotgun_bullet";
			M4A1.tech_needed = "Firearms";
			M4A1.base_stats[S.range] = 14f;
			M4A1.base_stats[S.accuracy] = 400;
			M4A1.base_stats[S.attack_speed] = 170f;
			M4A1.base_stats[S.damage] = 15;
			M4A1.base_stats[S.health] = 10;
			M4A1.equipment_value = 500;
			M4A1.path_slash_animation = "effects/slashes/slash_punch";
			M4A1.quality = ItemQuality.Legendary;
			M4A1.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(M4A1);
			Localization.addLocalization("item_M4A1", "M4A1");
			addgunSprite(M4A1.id, M4A1.materials[0]);
			
		  ItemAsset FAMAS = AssetManager.items.clone("FAMAS", "_range");
          FAMAS.id = "FAMAS";
          FAMAS.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "bow_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
          FAMAS.materials = List.Of<string>(new string[]{"iron"});
          FAMAS.projectile = "shotgun_bullet";
          FAMAS.base_stats[S.fertility] = 0.0f;
          FAMAS.base_stats[S.max_children] = 0f;
          FAMAS.base_stats[S.max_age] = 0f;
          FAMAS.base_stats[S.attack_speed] = 180;
          FAMAS.base_stats[S.damage] = 13;
          FAMAS.base_stats[S.speed] = 0f;
          FAMAS.base_stats[S.health] = 0;
          FAMAS.base_stats[S.accuracy] = 400f;
          FAMAS.base_stats[S.range] = 14;
          FAMAS.base_stats[S.armor] = 0;
		  FAMAS.tech_needed = "Firearms";		
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
          FAMAS.equipment_value = 500;
          FAMAS.path_slash_animation = "effects/slashes/slash_punch";
          FAMAS.equipmentType = EquipmentType.Weapon;
          FAMAS.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(FAMAS);
          Localization.addLocalization("item_FAMAS", "FAMAS");
          addgunSprite(FAMAS.id, FAMAS.materials[0]);
		  
		  	ItemAsset malorian = AssetManager.items.clone("malorian", "_range");
            malorian.id = "malorian";
            malorian.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            malorian.materials = List.Of<string>(new string[] { "iron" });
            malorian.projectile = "shotgun_bullet";
			malorian.tech_needed = "Firearms";
            malorian.base_stats[S.range] = 6f;
            malorian.base_stats[S.accuracy] = 400;
            malorian.base_stats[S.attack_speed] = 70;
            malorian.base_stats[S.damage] = 3;
            malorian.base_stats[S.health] = 10;
            malorian.equipment_value = 500;
            malorian.path_slash_animation = "effects/slashes/slash_punch";
            malorian.quality = ItemQuality.Legendary;
            malorian.equipmentType = EquipmentType.Weapon;
            AssetManager.items.list.AddItem(malorian);
            Localization.addLocalization("item_malorian", "Malorian Arms 3516");
            addgunSprite(malorian.id, malorian.materials[0]);
			


		  
		  ItemAsset PipeRifle = AssetManager.items.clone("PipeRifle", "_range");
          PipeRifle.id = "PipeRifle";
          PipeRifle.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "bow_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
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
          PipeRifle.tech_needed = "LowFirearms";
          PipeRifle.equipmentType = EquipmentType.Weapon;
          PipeRifle.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(PipeRifle);
          Localization.addLocalization("item_PipeRifle", "Pipe Rifle");
          addgunSprite(PipeRifle.id, PipeRifle.materials[0]);
		  
		  ItemAsset PipePistol = AssetManager.items.clone("PipePistol", "_range");
          PipePistol.id = "PipePistol";
          PipePistol.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "bow_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
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
          PipePistol.tech_needed = "LowFirearms";
          PipePistol.equipmentType = EquipmentType.Weapon;
          PipePistol.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(PipePistol);
          Localization.addLocalization("item_PipePistol", "Pipe Pistol");
          addgunSprite(PipePistol.id, PipePistol.materials[0]);
		  
		  ItemAsset PipeShotgun = AssetManager.items.clone("PipeShotgun", "_range");
          PipeShotgun.id = "PipeShotgun";
          PipeShotgun.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "bow_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
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
          PipeShotgun.tech_needed = "LowFirearms";
          PipeShotgun.equipmentType = EquipmentType.Weapon;
          PipeShotgun.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(PipeShotgun);
          Localization.addLocalization("item_PipeShotgun", "Pipe Shotgun");
          addgunSprite(PipeShotgun.id, PipeShotgun.materials[0]);
		  
		  ItemAsset Musket = AssetManager.items.clone("Musket", "_range");
          Musket.id = "Musket";
          Musket.name_templates = Toolbox.splitStringIntoList(new string[]
          {
          "bow_name#30",
          "sword_name_king#3",
          "weapon_name_city",
          "weapon_name_kingdom",
          "weapon_name_culture",
          "weapon_name_enemy_king",
          "weapon_name_enemy_kingdom"
          });
          Musket.materials = List.Of<string>(new string[]{"iron"});
          Musket.projectile = "shotgun_bullet";
          Musket.base_stats[S.fertility] = 0.0f;
          Musket.base_stats[S.max_children] = 0f;
          Musket.base_stats[S.max_age] = 0f;
          Musket.base_stats[S.attack_speed] = 20;
          Musket.base_stats[S.damage] = 130;
          Musket.base_stats[S.speed] = 0f;
          Musket.base_stats[S.health] = 0;
          Musket.base_stats[S.accuracy] = 70f;
          Musket.base_stats[S.range] = 0;
          Musket.base_stats[S.armor] = 0;
          Musket.base_stats[S.scale] = 0.0f;
          Musket.base_stats[S.dodge] = 0f;
          Musket.base_stats[S.targets] = 0f;
          Musket.base_stats[S.critical_chance] = 0.0f;
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
          Musket.equipment_value = 100;
          Musket.path_slash_animation = "effects/slashes/slash_punch";
          Musket.tech_needed = "LowFirearms";
          Musket.equipmentType = EquipmentType.Weapon;
          Musket.name_class = "item_class_weapon";
          AssetManager.items.list.AddItem(Musket);
          Localization.addLocalization("item_Musket", "Musket");
          addgunSprite(Musket.id, Musket.materials[0]);
		  
		  	ItemAsset MP7 = AssetManager.items.clone("MP7", "_range");
            MP7.id = "MP7";
            MP7.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            MP7.materials = List.Of<string>(new string[] { "iron" });
            MP7.projectile = "shotgun_bullet";
			MP7.tech_needed = "Firearms";			
            MP7.base_stats[S.range] = 0f;
            MP7.base_stats[S.accuracy] = 5;
            MP7.base_stats[S.attack_speed] = 12f;
            MP7.base_stats[S.damage] = 60;
            MP7.base_stats[S.health] = 10;
            MP7.equipment_value = 500;
            MP7.path_slash_animation = "effects/slashes/slash_punch";
            MP7.quality = ItemQuality.Legendary;
            MP7.equipmentType = EquipmentType.Weapon;
			
            AssetManager.items.list.AddItem(MP7);
            Localization.addLocalization("item_MP7", "MP7"); 
            addgunSprite(MP7.id, MP7.materials[0]);
			
			ItemAsset HK416 = AssetManager.items.clone("HK416", "_range");
            HK416.id = "HK416";
            HK416.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            HK416.materials = List.Of<string>(new string[] { "iron" });
            HK416.projectile = "shotgun_bullet";
			HK416.tech_needed = "Firearms";			
            HK416.base_stats[S.range] = 0f;
            HK416.base_stats[S.accuracy] = 5;
            HK416.base_stats[S.attack_speed] = 12f;
            HK416.base_stats[S.damage] = 60;
            HK416.base_stats[S.health] = 10;
            HK416.equipment_value = 500;
            HK416.path_slash_animation = "effects/slashes/slash_punch";
            HK416.quality = ItemQuality.Legendary;
            HK416.equipmentType = EquipmentType.Weapon;
			
			AssetManager.items.list.AddItem(HK416);
            Localization.addLocalization("item_HK416", "HK416"); 
            addgunSprite(HK416.id, HK416.materials[0]);


			ItemAsset M16 = AssetManager.items.clone("M16", "_range");
            M16.id = "M16";
            M16.name_templates = Toolbox.splitStringIntoList(new string[]
            {
                        "sword_name#30",
                        "sword_name_king#3",
                        "weapon_name_city",
                        "weapon_name_kingdom",
                        "weapon_name_culture",
                        "weapon_name_enemy_king",
                        "weapon_name_enemy_kingdom"
            });
            M16.materials = List.Of<string>(new string[] { "iron" });
            M16.projectile = "shotgun_bullet";
			M16.tech_needed = "Firearms";			
            M16.base_stats[S.range] = 0f;
            M16.base_stats[S.accuracy] = 5;
            M16.base_stats[S.attack_speed] = 12f;
            M16.base_stats[S.damage] = 60;
            M16.base_stats[S.health] = 10;
            M16.equipment_value = 500;
            M16.path_slash_animation = "effects/slashes/slash_punch";
            M16.quality = ItemQuality.Legendary;
            M16.equipmentType = EquipmentType.Weapon;
			
            AssetManager.items.list.AddItem(M16);
            Localization.addLocalization("item_M16", "M16"); 
            addgunSprite(M16.id, M16.materials[0]);




			// Add new gun 1
			ItemAsset DesertEagle = AssetManager.items.clone("DesertEagle", "_range");
			DesertEagle.id = "DesertEagle";
			DesertEagle.name_templates = Toolbox.splitStringIntoList(new string[]
			{
				"sword_name#30",
				"sword_name_king#3",
				"weapon_name_city",
				"weapon_name_kingdom",
				"weapon_name_culture",
				"weapon_name_enemy_king",
				"weapon_name_enemy_kingdom"
			});
			DesertEagle.materials = List.Of<string>(new string[] { "iron" });
			DesertEagle.projectile = "shotgun_bullet";
			DesertEagle.tech_needed = "Firearms";
			DesertEagle.base_stats[S.range] = 20f;
			DesertEagle.base_stats[S.accuracy] = 90;
			DesertEagle.base_stats[S.attack_speed] = 1f;
			DesertEagle.base_stats[S.damage] = 40;
			DesertEagle.base_stats[S.health] = 10;
			DesertEagle.equipment_value = 500;
			DesertEagle.path_slash_animation = "effects/slashes/slash_punch";
			DesertEagle.quality = ItemQuality.Legendary;
			DesertEagle.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(DesertEagle);
			Localization.addLocalization("item_DesertEagle", "Desert Eagle");
			addgunSprite(DesertEagle.id, DesertEagle.materials[0]);

			// Add new gun 2
			ItemAsset Glock17 = AssetManager.items.clone("Glock17", "_range");
			Glock17.id = "Glock17";
			Glock17.name_templates = Toolbox.splitStringIntoList(new string[]
			{
				"sword_name#30",
				"sword_name_king#3",
				"weapon_name_city",
				"weapon_name_kingdom",
				"weapon_name_culture",
				"weapon_name_enemy_king",
				"weapon_name_enemy_kingdom"
			});
			Glock17.materials = List.Of<string>(new string[] { "iron" });
			Glock17.projectile = "shotgun_bullet";
			Glock17.tech_needed = "Firearms";
			Glock17.base_stats[S.range] = 15f;
			Glock17.base_stats[S.accuracy] = 95;
			Glock17.base_stats[S.attack_speed] = 1f;
			Glock17.base_stats[S.damage] = 35;
			Glock17.base_stats[S.health] = 10;
			Glock17.equipment_value = 500;
			Glock17.path_slash_animation = "effects/slashes/slash_punch";
			Glock17.quality = ItemQuality.Legendary;
			Glock17.equipmentType = EquipmentType.Weapon;

			AssetManager.items.list.AddItem(Glock17);
			Localization.addLocalization("item_Glock17", "Glock 17");
			addgunSprite(Glock17.id, Glock17.materials[0]);










			static void makecraftable()
			{


		
			}
		}
		
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
				human.preferred_weapons.Add("Musket");		


				orc.preferred_weapons.Add("PipePistol");				
				orc.preferred_weapons.Add("PipeRifle");	
				orc.preferred_weapons.Add("PipeShotgun");	
				orc.preferred_weapons.Add("Musket");					


				dwarf.preferred_weapons.Add("PipePistol");				
				dwarf.preferred_weapons.Add("PipeRifle");	
				dwarf.preferred_weapons.Add("PipeShotgun");	
				dwarf.preferred_weapons.Add("Musket");	

				
				elf.preferred_weapons.Add("PipePistol");				
				elf.preferred_weapons.Add("PipeRifle");	
				elf.preferred_weapons.Add("PipeShotgun");	
				elf.preferred_weapons.Add("Musket");	


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
				human.preferred_weapons.Remove("Musket");		


				orc.preferred_weapons.Remove("PipePistol");				
				orc.preferred_weapons.Remove("PipeRifle");	
				orc.preferred_weapons.Remove("PipeShotgun");	
				orc.preferred_weapons.Remove("Musket");					


				dwarf.preferred_weapons.Remove("PipePistol");				
				dwarf.preferred_weapons.Remove("PipeRifle");	
				dwarf.preferred_weapons.Remove("PipeShotgun");	
				dwarf.preferred_weapons.Remove("Musket");	

				
				elf.preferred_weapons.Remove("PipePistol");				
				elf.preferred_weapons.Remove("PipeRifle");	
				elf.preferred_weapons.Remove("PipeShotgun");	
				elf.preferred_weapons.Remove("Musket");	
				


            }
		
			static void addgunSprite(string id, string material)
			{
				var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
				var sprite = Resources.Load<Sprite>("ItemTextures/w_" + id + "_" + material);
				dictItems.Add(sprite.name, sprite);
			}
        }     	
    }
