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
    class MIRV
    {
        public static void init()
        {

            //makecraftable();

          ProjectileAsset MIRVartillery = new ProjectileAsset();
          MIRVartillery.id = "MIRVartillery";
          MIRVartillery.texture = "MIRVartillery";
          MIRVartillery.trailEffect_enabled = false;
	      MIRVartillery.look_at_target = true;
          MIRVartillery.draw_light_area = true;
	      MIRVartillery.draw_light_size = 1f;
		  MIRVartillery.trailEffect_id = "smoketrail";
          MIRVartillery.trailEffect_scale = 0.1f;
          MIRVartillery.trailEffect_timer = 0.1f;
          MIRVartillery.endEffect = "fx_explosion_meteorite";
          MIRVartillery.terraformOption = "nonannoyingbomb";
          MIRVartillery.terraformRange = 4;
          MIRVartillery.startScale = 0.2f;
          MIRVartillery.targetScale = 0.2f;
          MIRVartillery.parabolic = true;
          MIRVartillery.speed = 3f;
          ProjectileAsset shellboomboomeffect = MIRVartillery;
          shellboomboomeffect.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(MIRVartillery);

			ItemAsset MIRV = AssetManager.items.clone("MIRV", "bow");
            MIRV.id = "MIRV";
            MIRV.projectile = "MIRVartillery";
			MIRV.materials = List.Of<string>(new string[] { "base" });
            MIRV.base_stats[S.range] = 0f;
            MIRV.base_stats[S.accuracy] = 0;
            MIRV.base_stats[S.attack_speed] = 1f;
            MIRV.base_stats[S.damage] = 0;
            MIRV.path_slash_animation = "effects/slashes/slash_punch";

			
			ItemAsset MIRVBomb = AssetManager.items.clone("MIRVBomb", "bow");
            MIRVBomb.id = "MIRVBomb";
            MIRVBomb.projectile = "bigbomb";
			MIRVBomb.materials = List.Of<string>(new string[] { "base" });
            MIRVBomb.base_stats[S.range] = 0f;
            MIRVBomb.base_stats[S.accuracy] = 0f;
            MIRVBomb.base_stats[S.attack_speed] = 1f;
            MIRVBomb.base_stats[S.damage] = 0f;
            MIRVBomb.path_slash_animation = "effects/slashes/slash_punch";






		}
		/*
		public static void toggleMIRVS()
        {
            Main.modifyBoolOption("MIRVOption", PowerButtons.GetToggleValue("MIRV_toggle"));
            if (PowerButtons.GetToggleValue("MIRV_toggle"))
            {
                turnOnMIRV();
                return;
            }
            turnOffMIRV();
        }
		
		public static void toggleMIRVSSTRONG()
        {
            Main.modifyBoolOption("STRONGMIRVOption", PowerButtons.GetToggleValue("STRONGMIRV_toggle"));
            if (PowerButtons.GetToggleValue("STRONGMIRV_toggle"))
            {
                turnOnMIRVSTRONG();
                return;
            }
            turnOffMIRVSTRONG();
        }
		


			public static void turnOnMIRVSTRONG()
			{
				Race human = AssetManager.raceLibrary.get("human");
				Race orc = AssetManager.raceLibrary.get("orc");
				Race dwarf = AssetManager.raceLibrary.get("dwarf");
				Race elf = AssetManager.raceLibrary.get("elf");

				human.preferred_weapons.Add("");
				orc.preferred_weapons.Add("");
				dwarf.preferred_weapons.Add("");
				elf.preferred_weapons.Add("");

			}
			
			public static void turnOffMIRVSTRONG()
			{
				Race human = AssetManager.raceLibrary.get("human");
				Race orc = AssetManager.raceLibrary.get("orc");
				Race dwarf = AssetManager.raceLibrary.get("dwarf");
				Race elf = AssetManager.raceLibrary.get("elf");

				human.preferred_weapons.Remove("");
				orc.preferred_weapons.Remove("");
				dwarf.preferred_weapons.Remove("");
				elf.preferred_weapons.Remove("");

			}

			public static void turnOnMIRV()
			{
				Race human = AssetManager.raceLibrary.get("human");
				Race orc = AssetManager.raceLibrary.get("orc");
				Race dwarf = AssetManager.raceLibrary.get("dwarf");
				Race elf = AssetManager.raceLibrary.get("elf");

				human.preferred_weapons.Add("");
				human.preferred_weapons.Add("");
				human.preferred_weapons.Add("");


				orc.preferred_weapons.Add("");
				orc.preferred_weapons.Add("");
				orc.preferred_weapons.Add("");



				dwarf.preferred_weapons.Add("");
				dwarf.preferred_weapons.Add("");
				dwarf.preferred_weapons.Add("");


				elf.preferred_weapons.Add("");
				elf.preferred_weapons.Add("");
				elf.preferred_weapons.Add("");

			}
			
			public static void turnOffMIRV()
			{
				Race human = AssetManager.raceLibrary.get("human");
				Race orc = AssetManager.raceLibrary.get("orc");
				Race dwarf = AssetManager.raceLibrary.get("dwarf");
				Race elf = AssetManager.raceLibrary.get("elf");

				human.preferred_weapons.Remove("");
				human.preferred_weapons.Remove("");
				human.preferred_weapons.Remove("");


				orc.preferred_weapons.Remove("");
				orc.preferred_weapons.Remove("");
				orc.preferred_weapons.Remove("");



				dwarf.preferred_weapons.Remove("");
				dwarf.preferred_weapons.Remove("");
				dwarf.preferred_weapons.Remove("");


				elf.preferred_weapons.Remove("");
				elf.preferred_weapons.Remove("");
				elf.preferred_weapons.Remove("");

			}

		
			static void addMIRVSprite(string id, string material)
			{
				var dictItems = Reflection.GetField(typeof(ActorAnimationLoader), null, "dictItems") as Dictionary<string, Sprite>;
				var sprite = Resources.Load<Sprite>("ItemTextures/w_" + id + "_iron");

				if (sprite != null)
				{
					dictItems.Add(sprite.name, sprite);
				}
				else
				{
					Debug.LogError("Failed to load sprite for MIRV with ID: " + id);
				}
			}
			*/
        }     	
    }




	
