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
    class GoliathCannon
    {
        public static void init()
        {

            //makecraftable();
            

			
			            
		ItemAsset bigplasmabomb = AssetManager.items.clone("bigplasmabomb", "_range");
					bigplasmabomb.id = "bigplasmabomb";
					bigplasmabomb.projectile = "big_plasma_bomb";
					bigplasmabomb.materials = List.Of<string>(new string[] { "base" });
				bigplasmabomb.base_stats[S.projectiles] = 1f;
				bigplasmabomb.base_stats[S.attack_speed] = 90f;
				bigplasmabomb.base_stats[S.range] = 0f;
				bigplasmabomb.base_stats[S.targets] = 4f;
				bigplasmabomb.base_stats[S.damage] = 6f;
				bigplasmabomb.base_stats[S.damage_range] = 0.7f;
					bigplasmabomb.path_slash_animation = "effects/slashes/slash_punch";

					ItemAsset thunderartillery = AssetManager.items.clone("thunderartillery", "_range");
					thunderartillery.id = "thunderartillery";
					thunderartillery.projectile = "thunderplasma";
					thunderartillery.materials = List.Of<string>(new string[] { "base" });
				thunderartillery.base_stats[S.projectiles] = 1f;
				thunderartillery.base_stats[S.attack_speed] = 90f;
				thunderartillery.base_stats[S.range] = 0f;
				thunderartillery.base_stats[S.targets] = 10f;
				thunderartillery.base_stats[S.damage] = 6f;
				thunderartillery.base_stats[S.damage_range] = 0.7f;
					thunderartillery.path_slash_animation = "effects/slashes/slash_punch";

				ItemAsset hyperartillery = AssetManager.items.clone("hyperartillery", "_range");
					hyperartillery.id = "hyperartillery";
					hyperartillery.projectile = "hyperkame";
					hyperartillery.materials = List.Of<string>(new string[] { "base" });
				hyperartillery.base_stats[S.projectiles] = 1f;
				hyperartillery.base_stats[S.attack_speed] = -20000f;
				hyperartillery.base_stats[S.range] = 0f;
				hyperartillery.base_stats[S.targets] = 20f;
				hyperartillery.base_stats[S.damage] = 6f;
				hyperartillery.base_stats[S.damage_range] = 0.7f;
					hyperartillery.path_slash_animation = "effects/slashes/slash_punch";

					ProjectileAsset thunderplasma = new ProjectileAsset();
				  thunderplasma.id = "thunderplasma";
				  thunderplasma.texture = "thunderplasma";
				  thunderplasma.endEffect = "kameboom";
				  thunderplasma.trailEffect_enabled = false;
				  thunderplasma.look_at_target = true;
				  thunderplasma.draw_light_area = true;
				  thunderplasma.draw_light_size = 1f;
				  thunderplasma.terraformOption = "nonannoyingbomb";
				  thunderplasma.terraformRange = 4;
				  thunderplasma.startScale = 0.3f;
				  thunderplasma.targetScale = 0.3f;
				  thunderplasma.parabolic = true;
				  thunderplasma.speed = 20f;
				  ProjectileAsset shellboomboomeffect6 = thunderplasma;
				  shellboomboomeffect6.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect6.world_actions, new AttackAction(ActionLibrary.burnTile));
				  AssetManager.projectiles.add(thunderplasma);
					
		ProjectileAsset big_plasma_bomb = new ProjectileAsset();
				  big_plasma_bomb.id = "big_plasma_bomb";
				  big_plasma_bomb.texture = "kame";
				  big_plasma_bomb.endEffect = "kameboom";
				  big_plasma_bomb.trailEffect_enabled = false;
				  big_plasma_bomb.look_at_target = true;
				  big_plasma_bomb.draw_light_area = true;
				  big_plasma_bomb.draw_light_size = 1f;
				  big_plasma_bomb.terraformOption = "nonannoyingbomb";
				  big_plasma_bomb.terraformRange = 4;
				  big_plasma_bomb.startScale = 0.2f;
				  big_plasma_bomb.targetScale = 1f;
				  big_plasma_bomb.parabolic = false;
				  big_plasma_bomb.speed = 20f;
				  ProjectileAsset shellboomboomeffect = big_plasma_bomb;
				  shellboomboomeffect.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect.world_actions, new AttackAction(ActionLibrary.burnTile));
				  AssetManager.projectiles.add(big_plasma_bomb);

				  		ProjectileAsset hyperkame = new ProjectileAsset();
				  hyperkame.id = "hyperkame";
				  hyperkame.texture = "hyperkame";
				  hyperkame.endEffect = "hyperboom";
				  hyperkame.trailEffect_enabled = false;
				  hyperkame.look_at_target = true;
				  hyperkame.draw_light_area = true;
				  hyperkame.draw_light_size = 1f;
				  hyperkame.terraformOption = "nonannoyingbomb";
				  hyperkame.terraformRange = 5;
				  hyperkame.startScale = 0.1f;
				  hyperkame.targetScale = 1f;
				  hyperkame.parabolic = true;
				  hyperkame.speed = 5f;
				  ProjectileAsset shellboomboomeffect2 = hyperkame;
				  shellboomboomeffect2.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect2.world_actions, new AttackAction(ActionLibrary.burnTile));
				  AssetManager.projectiles.add(hyperkame);
		  


		}

		




		
			static void addsdaMIRVSprite(string id, string material)
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
        }     	
    }




	
