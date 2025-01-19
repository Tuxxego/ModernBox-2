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
				bigplasmabomb.base_stats[S.range] = 300f;
				bigplasmabomb.base_stats[S.targets] = 1f;
				bigplasmabomb.base_stats[S.damage] = 600f;
				bigplasmabomb.base_stats[S.damage_range] = 0.7f;
					bigplasmabomb.path_slash_animation = "effects/slashes/slash_punch";
					
		ProjectileAsset big_plasma_bomb = new ProjectileAsset();
				  big_plasma_bomb.id = "big_plasma_bomb";
				  big_plasma_bomb.texture = "big_plasma_bomb";
				  big_plasma_bomb.trailEffect_enabled = false;
				  big_plasma_bomb.look_at_target = true;
				  big_plasma_bomb.draw_light_area = true;
				  big_plasma_bomb.draw_light_size = 1f;
				  big_plasma_bomb.terraformOption = "nonannoyingbomb";
				  big_plasma_bomb.terraformRange = 3;
				  big_plasma_bomb.sound_launch = "event:/SFX/POWERS/NapalmBomb";
				  big_plasma_bomb.sound_impact = "event:/SFX/POWERS/Bomb";
				  big_plasma_bomb.startScale = 0.2f;
				  big_plasma_bomb.targetScale = 0.2f;
				  big_plasma_bomb.parabolic = true;
				  big_plasma_bomb.speed = 7f;
				  ProjectileAsset shellboomboomeffect = big_plasma_bomb;
				  shellboomboomeffect.world_actions = (AttackAction)Delegate.Combine(shellboomboomeffect.world_actions, new AttackAction(ActionLibrary.burnTile));
				  AssetManager.projectiles.add(big_plasma_bomb);
		TerraformOptions nonannoyingbomb = AssetManager.terraform.clone("nonannoyingbomb", "grenade");
				  nonannoyingbomb.id = "nonannoyingbomb";
				nonannoyingbomb.shake = false;
				nonannoyingbomb.explode_tile = false;
				nonannoyingbomb.damageBuildings = true;
				nonannoyingbomb.damage = 100;
				nonannoyingbomb.setFire = false;
				  AssetManager.terraform.add(nonannoyingbomb);
		  
			









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




	