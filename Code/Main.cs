using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using M3;
using TuxModLoader;

namespace M3
{
    public class Main : MonoBehaviour
    {
        public Buttonz Buttonz = new Buttonz();
        public PowersAndDrops PowersAndDrops = new PowersAndDrops();
        public static Main instance;

        private PowerButtonSelector powerButtonSelector;

        private void Awake()
        {
			
var Tank = AssetManager.actor_library.clone("Tank", "$mob$");
    Tank.base_stats["health"] = 1000f;
    Tank.base_stats["damage"] = 100f;
    Tank.base_stats["speed"] = 40f;
    Tank.base_stats["scale"] = 0.3f;
    Tank.base_stats["size"] = 2f;
    Tank.base_stats["mass"] = 4f;
    Tank.base_stats["mass_2"] = 2500f;
    Tank.base_stats["targets"] = 20f;
    Tank.base_stats["lifespan"] = 0.0f;
Tank.inspect_stats = true;
Tank.inspect_home = true;
//Tank.hideOnMinimap = false;
Tank.inspect_children = false;
Tank.inspect_experience = true;
Tank.inspect_kills = true;
Tank.use_items = false;
Tank.take_items = false;
//Tank.job = "attacker";
Tank.icon = "iconTank";
//Tank.animation_walk = "walk_0,walk_1,walk_2,walk_3";
//Tank.animation_idle = "idle_0,idle_1,idle_2";
//Tank.animation_swim = "swim_0,swim_1,swim_2";
//Tank.texture_path = "Tank";
//AssetManager.actor_library.addColorSet("heliColor");
Tank.color = Toolbox.makeColor("#33724D");
AssetManager.actor_library.add(Tank);
//Localization.addLocalization(Tank.nameLocale, Tank.nameLocale);

            Debug.Log("[M3] Mod Core has been called, booting mod core.");
            
            Debug.Log("===============================");
            Debug.Log("M3 1.0.0");
            Debug.Log("MADE BY TUXXEGO");
            Debug.Log("===============================");            

            Debug.Log("[M3] Initializing PowersAndDrops...");
            PowersAndDrops.Init();
            Debug.Log("[M3] PowersAndDrops loaded!");
			
            Debug.Log("[M3] Initializing Buttonz...");
            Buttonz.Init();
            Debug.Log("[M3] Buttonz loaded!");
            
            powerButtonSelector = FindPowerButtonSelector();
            if (powerButtonSelector != null)
            {
                Debug.Log("[M3] PowerButtonSelector found!");
            }
            else
            {
                Debug.LogError("[M3] PowerButtonSelector not found in the scene.");
            }
			
        }

        void Update()
        {
            if (Input.GetKeyDown(KeyCode.B))
            {
                if (powerButtonSelector != null)
                {
                    powerButtonSelector.setSelectedPower(Buttonz.balls, PowersAndDrops.ProtonPower);
                }
                else
                {
                    Debug.LogError("[M3] PowerButtonSelector is null, cannot set selected power.");
                }
            }
        }

        private PowerButtonSelector FindPowerButtonSelector()
        {
            PowerButtonSelector selector = FindObjectOfType<PowerButtonSelector>();
            return selector;
        }
    }
}
