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