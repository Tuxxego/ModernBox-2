using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using TuxModLoader;
using UnityEngine.UI;
using TuxModLoader.Reflection;

namespace M3
{
	public class Guns
	{
		
		public void Init()
		{
			ItemAsset shotgun = new ItemBuilder("Shitgun", "$range")
            .SetSubtype("shitgun")
            .SetCost(100, "adamantine", 10, "mythril", 5)
            .SetRigidity(6)
            .SetPoolWeapon(true, 1)
            .SetIcon("ui/icons/Shitgun")
            .SetProjectile("shotgun_bullet")
            .SetSlashAnimation("effects/slashes/slash_punch")
            .SetStat("projectiles", 12f)
            .SetStat("range", 10f)
            .SetStat("targets", 1f)
            .SetStat("damage", 10f)
            .SetStat("damage_range", 0.9f)
            .SetStat("mana", 5f)
            .SetStat("stamina", 10f)
            .SetValue(600)
         //   .SetNameTemplates(AssetLibrary<ItemAsset>.l<string>("shotgun_name"))
            .SetGroup("firearm")
            .Build();
            			addgunSprite(shotgun.id, "iron");

        }
        static void addgunSprite(string id, string material)
        {
            var dictItems = ReflectionHelper.GetStaticFieldValue<Dictionary<string, List<Sprite>>>(typeof(ActorAnimationLoader), "_dict_items");
            var sprite = Resources.Load<Sprite>("ItemTextures/w_" + id);

            if (!dictItems.ContainsKey(sprite.name))
            {
                dictItems[sprite.name] = new List<Sprite>();
            }

            dictItems[sprite.name].Add(sprite);
        }
	}
}