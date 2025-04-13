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
		public static GodPower ProtonPower;

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
			
            DropAsset ProtonSHit = new DropBuilder()
                .SetId("protons")
                .SetTexturePath("drops/drop_bomb")
                .SetDefaultScale(0.2f)
                .SetFallingHeight(new Vector3(60f, 70f, 0f))
                .SetSoundLaunch("event:/SFX/DROPS/DropLaunchBombSmall")
                .SetActionLanded(action_ProtonClick)
                .SetDropType(DropType.DropBomb)
                .Build();
				
            ProtonPower = new PowerBuilder()
                .SetID("Protonbutton")
                .SetName("Protonbutton")
                .SetDropId("protons")
                .SetAction(Stuff_Drop)
                .SetSurprisesUnits(true)
				.SetShowToolSizes(true)
                .Build();
				
				GodPower ALIENPower = AssetManager.powers.clone("spawn_tank", "$template_spawn_actor$");
				ALIENPower.name = "spawn_tank";
				ALIENPower.actor_asset_id = "Tank";
				ALIENPower.click_action = new PowerActionWithID(action_spawn_jet);
		
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
			MapAction.damageWorld(pTile, 786, TerraformLibrary.czar_bomba, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }
	}
}