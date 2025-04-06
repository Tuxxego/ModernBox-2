using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using M3;

namespace M3
{
	public class Main : MonoBehaviour
	{
		public Buttonz Buttonz = new Buttonz();
		public static Main instance;
		
		private void Awake()
		{
			 Debug.Log("[M3] Mod Core has been called, booting mod core.");
			
			 Debug.Log("===============================");
			 Debug.Log("M3 1.0.0");
			 Debug.Log("MADE BY TUXXEGO");
			 Debug.Log("===============================");			

			 Debug.Log("[M3] Initializing Buttonz...");
			 Buttonz.Init();
			 Debug.Log("[M3] Buttonz loaded!");
 
		}
	}
}