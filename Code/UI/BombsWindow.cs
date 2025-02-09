//========= MODERNBOX 2.1.0.1 ============//
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
		
		private static PowerButton BOMBButton;
		private static PowerButton BOMBButton2;
		private static PowerButton BOMBButton3;
		private static PowerButton BOMBButton4;
		private static PowerButton BOMBButton5;
		private static PowerButton BOMBButton6;
		private static PowerButton BOMBButton7;
		private static PowerButton BOMBButton8;
		private static PowerButton BOMBButton9;
		private static PowerButton BOMBButton10;
	    private static PowerButton BOMBButton11;
		private static PowerButton BOMBButton12;
		private static PowerButton BOMBButton13;
		private static PowerButton BOMBButton14;
		private static PowerButton BOMB2;
		private static GodPower AtomicGrenadePower;
		private static DropAsset AtomicGrenadeDrop;
		private static GodPower FuryOfTuxiaFuncPower;
		private static GodPower ZeusRagePower;
		private static GodPower ClusterNukePower;
		private static GodPower EXPower;
		private static GodPower NSAPower;
		private static GodPower ClusterStrikePower;
		private static GodPower ProtonPower;
		private static GodPower DeleterFuncPower;
		private static GodPower SpreaderFuncPower;
		private static GodPower ColorGrenadePower;
		private static GodPower DankiMatterPower;
		private static GodPower BloodLightningPower;
		private static GodPower NoDmgPower;
		
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
		  
			        BOMBButton = PowerButtons.CreateButton("AtomicGrenadebutton", Resources.Load<Sprite>("ui/Icons/AtomicGrenade"), "Atomic Grenade", "A warcrime in the palm of your hand.", new Vector2(60, MoveDown), ButtonType.Click, content.transform, AtomicGrenadeFunc);
			        BOMBButton2 = PowerButtons.CreateButton("FuryOfTuxia", Resources.Load<Sprite>("ui/Icons/FuryOfTuxia"), "Fury of Tuxia", "Dank told me to stop making nukes, I instead decided to create this monstrosity (if your computer survives this, you're cool!)", new Vector2(96, MoveDown), ButtonType.Click, content.transform, FuryOfTuxiaFunc);			
			        BOMBButton3 = PowerButtons.CreateButton("ZeusRagebutton", Resources.Load<Sprite>("ui/Icons/ZeusRage"), "Zeus's Rage", "Tremble in fear Kratos.", new Vector2(132, MoveDown), ButtonType.Click, content.transform, ZeusRageFunc);				
			        BOMBButton4 = PowerButtons.CreateButton("ClusterNuke", Resources.Load<Sprite>("ui/Icons/ClusterNuke"), "Cluster Nuke", "EXACTLY what the title says.", new Vector2(168, MoveDown), ButtonType.Click, content.transform, ClusterNukeFunc);	
				//BOMBButton5 = PowerButtons.CreateButton("EXbutton", Resources.Load<Sprite>("ui/Icons/wat"), "Experimental Nuke", "If you see this then you are a dev or you are snooping around my bomb code. -Dank", new Vector2(204, MoveDown*3), ButtonType.Click, content.transform, EXFunc);	//this is the experimental button for nukes
                                BOMBButton6 = PowerButtons.CreateButton("NSAbutton", Resources.Load<Sprite>("ui/Icons/NotSoAtomic"), "the Not so atomic Bomb", "The bomb that wanted to become atomic but failed the test in 12th grade to become atomic", new Vector2(204, MoveDown), ButtonType.Click, content.transform, NSAFunc);	
                                BOMBButton7 = PowerButtons.CreateButton("ClusterStrikebutton", Resources.Load<Sprite>("ui/Icons/ClusterStrike"), "The Cluster Strike", "Damn is it Stormy bro, or am i just trippin?", new Vector2(60, MoveDown*2), ButtonType.Click, content.transform, DeleterFunc);	
                                BOMBButton8 = PowerButtons.CreateButton("Protonbutton", Resources.Load<Sprite>("ui/Icons/Proton"), "The Proton Bomb", "The bomb to be forgoten no longer", new Vector2(96, MoveDown*2), ButtonType.Click, content.transform, ProtonFunc);	
                                BOMBButton9 = PowerButtons.CreateButton("DeleterButton", Resources.Load<Sprite>("ui/Icons/UniversalDestroyer"), "The Unholy Universal Destruction System", "Destroys the entire universe (literally it deletes EVERYTHING, watch out with this bad boy.", new Vector2(132, MoveDown*3), ButtonType.Click, content.transform, DeleterFunc);
								BOMBButton10 = PowerButtons.CreateButton("SpreaderButton", Resources.Load<Sprite>("ui/Icons/MOAB"), "The Spreader Bomb", "Quickly spreads to engulf your whole world in fire.", new Vector2(132, MoveDown*2), ButtonType.Click, content.transform, SpreaderFunc);	
                                BOMBButton11 = PowerButtons.CreateButton("Colorbutton", Resources.Load<Sprite>("ui/Icons/ColorGrenade"), "Color Bomb", "Its a bomb with a colorfull effect", new Vector2(168, MoveDown*2), ButtonType.Click, content.transform, ColorFunc);	
								BOMBButton12 = PowerButtons.CreateButton("Dankbutton", Resources.Load<Sprite>("ui/Icons/Danky"), "Danky Bomb", "There's really no hard limit to how long these achievement names can be and to be quite honest I'm rather curious to see how far we can go. Adolphus W. Green (1844 to 1917) started as the Principal of the Groton School in 1864. By 1865, he became second assistant librarian at the New York Mercantile Library; from 1867 to 1869, he was promoted to full librarian. From 1869 to 1873, he worked for Evarts, Southmayd & Choate, a law firm co-founded by William M. Evarts, Charles Ferdinand Southmayd and Joseph Hodges Choate. He was admitted to the New York State Bar Association in 1873. Anyway, how's your day been?", new Vector2(204, MoveDown*2), ButtonType.Click, content.transform, DankFunc);	
								BOMBButton13 = PowerButtons.CreateButton("Bloodbutton", Resources.Load<Sprite>("ui/Icons/BloodLightning"), "Blood Lightning", "Forgive me for i have gone mad -Zeus", new Vector2(60, MoveDown*3), ButtonType.Click, content.transform, BloodFunc);	
								BOMBButton14 = PowerButtons.CreateButton("NoDmbbutton", Resources.Load<Sprite>("ui/Icons/BlueOne"), "The BLue One", "idk wtf this does", new Vector2(96, MoveDown*3), ButtonType.Click, content.transform, NoDmgFunc);	

        }
		private static void AtomicGrenadeFunc()
		{
			
			window.clickHide();
			
				
			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton, AtomicGrenadePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB2);
		}
		private static void FuryOfTuxiaFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton2, FuryOfTuxiaFuncPower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB3);
		}
		
		
		
		private static void ZeusRageFunc()
		{
			
			window.clickHide();
			
				
			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton3, ZeusRagePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB);
		}
		
		private static void ClusterNukeFunc()
		{
			
			window.clickHide();
			
				
			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton4, ClusterNukePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB4);
		}
	    private static void EXFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(BOMBButton5, EXPower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB5);
		}
		private static void NSAFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(BOMBButton6, NSAPower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB6);
		}
        private static void ClusterStrikeFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(BOMBButton7, ClusterStrikePower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB7);
		} 
		private static void ProtonFunc()
		{
			
			window.clickHide();
			
				
			
            
			PowerButtonSelector.instance.setSelectedPower(BOMBButton8, ProtonPower);
			
			//		PowerTracker.setPower((GodPower), null);
			
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB8);
		}
	private static void DeleterFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton9, DeleterFuncPower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB9);
		}

		private static void SpreaderFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton10, SpreaderFuncPower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB10);
		}
	    private static void ColorFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton11, ColorGrenadePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB11);
		}

		private static void DankFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton12, DankiMatterPower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB12);
		}

		private static void BloodFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton13, BloodLightningPower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB13);
		}

		private static void NoDmgFunc()
		{
			
			window.clickHide();
			

			

			PowerButtonSelector.instance.setSelectedPower(BOMBButton14, NoDmgPower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.BOMB14);
		}
  }
}
