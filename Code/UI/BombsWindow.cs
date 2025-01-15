//========= MODERNBOX 2.0.1.0 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using System.Collections.Generic;
using System.Collections;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionUtility;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using NCMS.Utils;
using System.Text.RegularExpressions;
using System.Reflection;


namespace M2
{
    class BombsWindow
    {
		public static int MoveDown = -40;
        private static ScrollWindow window;
        private static GameObject content;
		
		private static PowerButton AHHHH;
		private static PowerButton AHHHH2;
		private static PowerButton ASS2;
		private static GodPower AtomicGrenadePower;
		private static DropAsset AtomicGrenadeDrop;
		private static GodPower FuryOfTuxiaFuncPower;
		
	  private static PowersTab getPowersTab(string id) {
		GameObject gameObject = GameObjects.FindEvenInactive("Tab_" + id);
		return gameObject.GetComponent<PowersTab>();
	  }

        public static void init()
        {
			    PowersTab tab = getPowersTab("ModernBox");

          window = Windows.CreateNewWindow("EXTRA BOMBS", "ModernBox");
          var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View");
          scrollView.gameObject.SetActive(true);
          var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
          var viewportRect = viewport.GetComponent<RectTransform>();
          viewportRect.sizeDelta = new Vector2(0, 17);
          content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport/Content");
			
			    AHHHH = PowerButtons.CreateButton("AtomicGrenadebutton", Resources.Load<Sprite>("ui/Icons/AtomicGrenade"), "Atomic Grenade", "A warcrime in the palm of your hand.", new Vector2(60, MoveDown), ButtonType.Click, content.transform, AtomicGrenadeFunc);
			    AHHHH2 = PowerButtons.CreateButton("FuryOfTuxia", Resources.Load<Sprite>("ui/Icons/FuryOfTuxia"), "Fury of Tuxia", "Dank told me to stop making nukes, I instead decided to create this monstrosity (if your computer survives this, you're cool!)", new Vector2(96, MoveDown), ButtonType.Click, content.transform, FuryOfTuxiaFunc);			
	

        }
		private static void AtomicGrenadeFunc()
		{
			
			window.clickHide();
			
				
			

			PowerButtonSelector.instance.setSelectedPower(AHHHH, AtomicGrenadePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS2);
		}
		private static void FuryOfTuxiaFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(AHHHH2, FuryOfTuxiaFuncPower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS3);
		}
		    public static bool Stuff_Drop(WorldTile pTile, GodPower pPower) {
			AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
			return true;
		  }
  }
}
