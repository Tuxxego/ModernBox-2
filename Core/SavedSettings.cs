//========= MODERNBOX 2.2.0.0 ============//
//
// Made by Tuxxego
//
//=============================================================================//

using System;
using System.Collections;
using System.Collections.Generic;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.UI;
using ReflectionUtility;

namespace M2
{
    [Serializable]
    public class SavedSettings
    {
        public string settingVersion = "2.2.0.0";

        public Dictionary<string, bool> boolOptions = new Dictionary<string, bool>
        {
            {"namesOption", true},
			{"othernamesOption", true},
			{"MIRVOption", false},
			{"CyberwareOption", true},
			{"NukeOption", false}, // also unused now.
			{"DrugsOption", true},
			{"Update_Checker", true},
			{"HeliOption", false}, // Goes unused. Not anymore
			{"AirshipOption", false}, // Goes unused.
			{"TankOption", false}, // Goes unused.
			{"MIRVBomberOption", false}, // Goes unused.
			{"HumveeOption", false}, // Goes unused.
			{"FighterJetOption", false}, // Goes unused.
			{"BoiOption", false}, // Goes unused.
			{"GunshipOption", false}, // Goes unused.
			{"RailgunOption", false}, // Goes unused
			{"SoldierOption", false}, // Goes unused
            {"STRONGMIRVOption", false},
			{"Debug_Log", true},
			{"PipeGunOption", true},
			{"MinimapFigures",  true},
			{"newversion",  true},			
			{"Developer_Mode",  false},			
			{"IdeologiesOption",  true},		
			{"FactoriesOption",  true},		
			{"GunOption",  true},
			{"DronesOption",  true},
			{"ShakeOption",  true},
			{"P9000Option",  false},
			{"TerranOption",  true}
        };
	}
	



    [Serializable]
    public class InputOption
    {
        public bool active = true;
        public string value;
    }

}