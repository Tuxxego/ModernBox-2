using UnityEngine;
//using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
//using TuxModLoader;
using UnityEngine.UI;
using System.Collections;
using NCMS.Utils;
using NCMS;
using ReflectionUtility;
using TuxModLoader.Reflection;
using System.Reflection;

namespace ModernBox
{
	public class Bombs
	{

		public static void Init()
		{

        new BombBuilder("moab")
            .SetTexturePath("ui/icons/MOAB")
            .SetDropLandAction(new DropsAction(BombUtilities.Instance.action_MOABClick))
            .SetClickPowerAction(new PowerAction(Buttonz.Stuff_Drop))
            .SetBombEffectAction(new WorldAction(BombUtilities.Instance.action_MOABClickOTHER))
            .Build();

        new BombBuilder("clusternuke")
            .SetTexturePath("ui/icons/ClusterNuke")
            .SetDropLandAction(new DropsAction(BombUtilities.Instance.action_ClusterClick))
            .SetClickPowerAction(new PowerAction(Buttonz.Stuff_Drop))
            .Build();

        new BombBuilder("icebomb")
            .SetTexturePath("ui/icons/I hate this stupid bomb it messed me up")
            .SetDropLandAction(new DropsAction(BombUtilities.Instance.action_IceClick))
            .SetClickPowerAction(new PowerAction(Buttonz.Stuff_Drop))
            .SetBombEffectAction(new WorldAction(BombUtilities.Instance.action_IceClickOTHER))
            .Build();

        new BombBuilder("firebomb")
            .SetTexturePath("ui/icons/FIRE!")
            .SetDropLandAction(new DropsAction(BombUtilities.Instance.action_FireBombClick))
            .SetClickPowerAction(new PowerAction(Buttonz.Stuff_Drop))
            .Build();     
        new BombBuilder("tuxium")
            .SetTexturePath("drops/drop_czarbomba")
            .SetDropLandAction(new DropsAction(BombUtilities.Instance.action_TuxiumClick))
            .SetClickPowerAction(new PowerAction(Buttonz.Stuff_Drop))
            .SetBombEffectAction(new WorldAction(BombUtilities.Instance.action_TuxiumClickOTHER))
            .Build();        
        }
    }
}