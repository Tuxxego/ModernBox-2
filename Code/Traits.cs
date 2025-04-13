using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using TuxModLoader;
using UnityEngine.UI;
using TuxModLoader.Reflection;

namespace M3
{
	public class Traits
	{
		
		public void Init()
		{
            ActorTraitGroupAsset M3Group = new TraitGroupBuilder("M3")
                .SetName("M3")
                .SetColor("#FF0000")
                .Build();

            ActorTrait Balls = new TraitBuilder("Dumbass")
                .SetIcon("ui/icons/Tank")
                .SetRateBirth(2)
                .SetRateInherit(5)
                .SetLikeability(0.1f)
                .SetGroupID("M3")
                .SetType(TraitType.Positive)
                .AddOpposite("unlucky")
                .Build();
        }
	}
}