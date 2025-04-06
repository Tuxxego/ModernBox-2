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
			 Debug.Log("[M2] Mod Core has been called, booting mod core.");
			
			 Debug.Log("===============================");
			 Debug.Log("ModernBox 2.2.0.0");
			 Debug.Log("MADE BY TUXXEGO");
			 Debug.Log("===============================");			

			 Debug.Log("[M2] Initializing Buttonz...");
			 Buttonz.Init();
			 Debug.Log("[M2] Buttonz loaded!");
 
		}
	}
}