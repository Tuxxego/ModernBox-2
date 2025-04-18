using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using M3;
using TuxModLoader;
using TuxModLoader.Reflection;

namespace M3
{
    public class Main : MonoBehaviour
    {
        public Buttonz Buttonz;
        public PowersAndDrops PowersAndDrops = new PowersAndDrops();
        public Guns Guns = new Guns();
        public Traits Traits = new Traits();
        public LabelCycler LabelCycler = new LabelCycler();
        public static Main instance;

        private PowerButtonSelector powerButtonSelector;

        private void Awake()
        {

            Debug.Log("[M3] Mod Core has been called, booting mod core.");
            
            Debug.Log("===============================");
            Debug.Log("M3 1.0.0");
            Debug.Log("MADE BY TUXXEGO");
            Debug.Log("===============================");            

            Debug.Log("[M3] Initializing PowersAndDrops...");
            PowersAndDrops.Init();
            Debug.Log("[M3] PowersAndDrops loaded!");
			
            Debug.Log("[M3] Initializing Buttonz...");
            GameObject buttonzObj = new GameObject("Buttonz");
            Buttonz = buttonzObj.AddComponent<Buttonz>();
            Buttonz.Init();
            Debug.Log("[M3] Buttonz loaded!");

            Debug.Log("[M3] Initializing Guns...");
            Guns.Init();
            Debug.Log("[M3] Guns loaded!");

            Debug.Log("[M3] Initializing CreditsWindow...");
            CreditsWindow.Init();
            Debug.Log("[M3] CreditsWindow loaded!");

            Debug.Log("[M3] Initializing Traits...");
            Traits.Init();
            Debug.Log("[M3] Traits loaded!");

            Debug.Log("[M3] Initializing LabelCycler...");
            GameObject panelObject = new GameObject("BALLS");
            LabelCycler = panelObject.AddComponent<LabelCycler>();
            Debug.Log("[M3] LabelCycler loaded!");

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
                    powerButtonSelector.setSelectedPower(Buttonz.balls, PowersAndDrops.FirePower);
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
