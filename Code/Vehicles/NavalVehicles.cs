 //========= MODERNBOX 2.2.0.0 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;
using HarmonyLib;

namespace M2
{
    class NavalVehicles : MonoBehaviour
    {
        public static void init()
        {
            loadAssets();
        }

        private static void loadAssets()
        {

   var boatnormal = AssetManager.actor_library.get("boat_transport");
         boatnormal.traits.Add("Unitpotential");
         boatnormal.can_edit_traits = true;

         var boatsubnormal = AssetManager.actor_library.get("boat_trading");
         boatsubnormal.traits.Add("Unitpotential");
         boatsubnormal.can_edit_traits = true;


		}
		}
}




