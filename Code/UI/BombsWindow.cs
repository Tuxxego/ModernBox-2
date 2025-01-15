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


        public static void init()
        {
          window = Windows.CreateNewWindow("EXTRA BOMBS", "ModernBox");
          var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View");
          scrollView.gameObject.SetActive(true);
          var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
          var viewportRect = viewport.GetComponent<RectTransform>();
          viewportRect.sizeDelta = new Vector2(0, 17);
          content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport/Content");
			
			    AHHHH = PowerButtons.CreateButton("AtomicGrenadebutton", Resources.Load<Sprite>("ui/Icons/AtomicGrenade"), "Atomic Grenade", "A warcrime in the palm of your hand.", new Vector2(60, MoveDown), ButtonType.Click, content.transform, tileButtonClick);
			
	
        }
		private static void tileButtonClick()
		{
			
			window.clickHide();
			
				DropAsset AtomicGrenadeDrop = new DropAsset();
				AtomicGrenadeDrop.id = "atomicgrenade";
				AtomicGrenadeDrop.path_texture = "drops/drop_czarbomba";
				AtomicGrenadeDrop.random_frame = false;
				AtomicGrenadeDrop.default_scale = 0.2f;
				AtomicGrenadeDrop.fallingHeight = (Vector3) new Vector2(60f, 70f);
				AtomicGrenadeDrop.action_landed = new DropsAction(action_AtomicGClick);
				AssetManager.drops.add(AtomicGrenadeDrop);
	
				GodPower AtomicGrenadePower = new GodPower();
				AtomicGrenadePower.id = "AtomicGrenadebutton";
				AtomicGrenadePower.name = "AtomicGrenadebutton";
				AtomicGrenadePower.holdAction = true;
				AtomicGrenadePower.fallingChance = 0.01f;
				AtomicGrenadePower.showToolSizes = true;
				AtomicGrenadePower.unselectWhenWindow = false;
				AtomicGrenadePower.ignore_cursor_icon = true;
				AtomicGrenadePower.dropID = "atomicgrenade";
				AtomicGrenadePower.click_power_action = new PowerAction(Stuff_Drop);
				AtomicGrenadePower.click_power_brush_action = new PowerAction((WorldTile pTile, GodPower pPower) => { return (bool) AssetManager.powers.CallMethod("loopWithCurrentBrushPower", pTile, pPower); });
				AssetManager.powers.add(AtomicGrenadePower);
				
			

			PowerButtonSelector.instance.setSelectedPower(AHHHH, AtomicGrenadePower);


	//		PowerTracker.setPower((GodPower), null);
			PowerButtonSelector.instance.clickPowerButton(Buttonz.ASS);
			Debug.Log("tileButtonClick execution completed.");
		}
		  public static void action_AtomicGClick(WorldTile pTile, string pPowerID) {
			EffectsLibrary.spawnAtTileRandomScale("fx_explosion_small", pTile, 4.3f, 7.9f);
			MapAction.damageWorld(pTile, 130, TerraformLibrary.czarBomba, null);
			World.world.startShake(0.3f, 0.01f, 2f, true, true);
			// return true;
		  }
		    public static bool Stuff_Drop(WorldTile pTile, GodPower pPower) {
			AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
			return true;
		  }
  }
}
