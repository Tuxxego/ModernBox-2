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
		public static int MoveDown = -50;
        private static ScrollWindow window;
        private static GameObject content;
		
		private static PowerButton AHHHH;
		private static PowerButton AHHHH2;
		private static PowerButton AHHHH3;
		private static PowerButton AHHHH4;
		private static PowerButton AHHHH5;
		private static PowerButton AHHHH6;
		private static PowerButton AHHHH7;
		private static PowerButton AHHHH8;
		private static PowerButton ASS2;
		private static GodPower AtomicGrenadePower;
		private static DropAsset AtomicGrenadeDrop;
		private static GodPower FuryOfTuxiaFuncPower;
		private static GodPower ZeusRagePower;
		private static GodPower ClusterNukePower;
		private static GodPower EXPower;
		private static GodPower NSAPower;
		private static GodPower ClusterStrikePower;
		private static GodPower ProtonPower;
		
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
			
			          string gold = "#FFD700";
					  string Dgold = "#ffae00";
					  var description =
			@"<color='" + gold + @"'>Dank and Tux got bored so here's a bunch of destructive stuff. </color>

			";
					  var name = window.transform.Find("Background").Find("Name").gameObject;
					  var nameText = name.GetComponent<Text>();
					  nameText.text = description;
					  nameText.color = new Color(0.9f, 0.6f, 0, 1);
					  nameText.fontSize = 10;
					  nameText.alignment = TextAnchor.UpperCenter;
					  nameText.supportRichText = true;
					  name.transform.SetParent(window.transform.Find("Background").Find("Scroll View").Find("Viewport").Find("Content"));
					  name.SetActive(true);
					  var nameRect = name.GetComponent<RectTransform>();
					  nameRect.anchorMin = new Vector2(0.5f, 1);
					  nameRect.anchorMax = new Vector2(0.5f, 1);
					  nameRect.offsetMin = new Vector2(-90f, nameText.preferredHeight * -1);
					  nameRect.offsetMax = new Vector2(90f, -17);
					  nameRect.sizeDelta = new Vector2(180, nameText.preferredHeight + 50);
					  window.GetComponent<RectTransform>().sizeDelta = new Vector2(0, nameText.preferredHeight + 50);
					  name.transform.localPosition = new Vector2(name.transform.localPosition.x, ((nameText.preferredHeight / 2) + 30) * -1);
		  
			   AHHHH = PowerButtons.CreateButton("AtomicGrenadebutton", Resources.Load<Sprite>("ui/Icons/AtomicGrenade"), "Atomic Grenade", "A warcrime in the palm of your hand.", new Vector2(60, MoveDown), ButtonType.Click, content.transform, AtomicGrenadeFunc);
			    AHHHH2 = PowerButtons.CreateButton("FuryOfTuxia", Resources.Load<Sprite>("ui/Icons/FuryOfTuxia"), "Fury of Tuxia", "Dank told me to stop making nukes, I instead decided to create this monstrosity (if your computer survives this, you're cool!)", new Vector2(96, MoveDown), ButtonType.Click, content.transform, FuryOfTuxiaFunc);			
			    AHHHH3 = PowerButtons.CreateButton("ZeusRagebutton", Resources.Load<Sprite>("ui/Icons/ZeusRage"), "Zeus's Rage", "Tremble in fear Kratos.", new Vector2(132, MoveDown), ButtonType.Click, content.transform, ZeusRageFunc);				
			    AHHHH4 = PowerButtons.CreateButton("ClusterNuke", Resources.Load<Sprite>("ui/Icons/MOAB"), "Cluster Nuke", "EXACTLY what the title says.", new Vector2(168, MoveDown), ButtonType.Click, content.transform, ClusterNukeFunc);	
				//AHHHH5 = PowerButtons.CreateButton("EXbutton", Resources.Load<Sprite>("ui/Icons/wat"), "Experimental Nuke", "If you see this then you are a dev or you are snooping around my bomb code. -Dank", new Vector2(132, MoveDown*2), ButtonType.Click, content.transform, EXFunc);	//this is the experimental button for nukes
                AHHHH6 = PowerButtons.CreateButton("NSAbutton", Resources.Load<Sprite>("ui/Icons/NotSoAtomic"), "the Not so atomic Bomb", "The bomb that wanted to become atomic but failed the test in 12th grade to become atomic", new Vector2(204, MoveDown), ButtonType.Click, content.transform, NSAFunc);	
                AHHHH7 = PowerButtons.CreateButton("ClusterStrikebutton", Resources.Load<Sprite>("ui/Icons/ClusterStrike"), "The Cluster Strike", "Damn is it Stormy bro, or am i just trippin?", new Vector2(60, MoveDown*2), ButtonType.Click, content.transform, ClusterStrikeFunc);	
                AHHHH8 = PowerButtons.CreateButton("Protonbutton", Resources.Load<Sprite>("ui/Icons/Proton"), "The Proton Bomb", "The bomb to be forgoten no longer", new Vector2(96, MoveDown*2), ButtonType.Click, content.transform, ProtonFunc);	

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
		private static void ZeusRageFunc()
		{
			
			window.clickHide();
			
				
			

			PowerButtonSelector.instance.setSelectedPower(AHHHH3, ZeusRagePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS);
		}
		
		private static void ClusterNukeFunc()
		{
			
			window.clickHide();
			
				
			

			PowerButtonSelector.instance.setSelectedPower(AHHHH4, ClusterNukePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS4);
		}
	    private static void EXFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(AHHHH5, EXPower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS5);
		}
		private static void NSAFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(AHHHH6, NSAPower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS6);
		}
        private static void ClusterStrikeFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(AHHHH7, ClusterStrikePower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS7);
		} 
		private static void ProtonFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(AHHHH8, ProtonPower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS8);
		}
  }
}
