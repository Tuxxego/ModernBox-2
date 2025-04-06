using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using TuxModLoader;
using UnityEngine.UI;

namespace M3
{
	public class Buttonz
	{
		public void Init()
		{
				new TabBuilder()
					.SetTabID("M3_TAB")
					.SetName("M3")
					.SetDescription("Eras, Space, Politics, and more.")
					.SetPosition(200)
					.SetIcon("icons/tab2.png")
					.Build();
					
			PowersTab tab = TabManager.FindTab("M3_TAB");

			GameObject largeImageObject = new GameObject("LargeImage");
			largeImageObject.transform.SetParent(tab.transform);
			largeImageObject.transform.localPosition = new Vector3(396, 18, 0);
			largeImageObject.transform.localScale = new Vector3(1, 1, 1);

			Image largeImage = largeImageObject.AddComponent<Image>();
			largeImage.sprite = Resources.Load<Sprite>("ui/Icons/TabText");

			RectTransform largeImageRectTransform = largeImageObject.GetComponent<RectTransform>();
			largeImageRectTransform.sizeDelta = new Vector2(200, 100);
			largeImageRectTransform.anchorMin = new Vector2(0.5f, 0.5f);
			largeImageRectTransform.anchorMax = new Vector2(0.5f, 0.5f);
	
			new ButtonBuilder("STRONGMIRV_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRV_nuke"))
				.SetName("Nuclear MIRVs")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggle Nuclear MIRVs from being developed (this won't remove existing Nuclear MIRVS)")
				.SetPosition(new Vector2(288, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("MIRV_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRV"))
				.SetName("MIRVs")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggle MIRVs from being developed (this won't remove existing MIRVS)")
				.SetPosition(new Vector2(288, 18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("MOABbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MOAB"))
				.SetName("Super-Nuke")
				.SetDescription("Also known as the 'Lag Bomb'.")
				.SetPosition(new Vector2(576, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Xeniumbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Xeno"))
				.SetName("Xenium Bomb")
				.SetDescription("You thought the ultron bomb was big? This thing is HUGE.")
				.SetPosition(new Vector2(576, -18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Cobaltbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Cobalt"))
				.SetName("Cobalt Bomb")
				.SetDescription("Small Mushroom but huge radius, watch out with this one.")
				.SetPosition(new Vector2(540, -18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Ultronbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Ultron"))
				.SetName("Ultron Bomb")
				.SetDescription("WOOOAH")
				.SetPosition(new Vector2(504, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Deathbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Death"))
				.SetName("Death Bomb")
				.SetDescription("Such an original name.")
				.SetPosition(new Vector2(612, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Randombutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/wat"))
				.SetName("Random Bomb")
				.SetDescription("You could be dropping a proton bomb, or a mini nuke, it's random!")
				.SetPosition(new Vector2(648, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("BombMenu")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Bomber"))
				.SetName("Bomb Menu")
				.SetDescription("Tux and Dank got bored and added a lot of extra bombs....")
				.SetPosition(new Vector2(684, -18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Minibutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Mini"))
				.SetName("Mini Nuke")
				.SetDescription("Small nukes, great for minor scuffles.")
				.SetPosition(new Vector2(540, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Protonbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Proton"))
				.SetName("Proton Bomb")
				.SetDescription("wtf is this?")
				.SetPosition(new Vector2(504, -18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Jupiterbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Jupiter"))
				.SetName("Jupiter Bomb")
				.SetDescription("The new monster.")
				.SetPosition(new Vector2(612, -18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Eraserbutton")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Eraser"))
				.SetName("Eraser Bomb")
				.SetDescription("also known as the overcompensating bomb.")
				.SetPosition(new Vector2(648, -18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Cyberware_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Cyberware"))
				.SetName("Cyberware")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggle Cyberware from being developed (this won't remove existing Cyberware)")
				.SetPosition(new Vector2(1224, 18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Drugs_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Drugs"))
				.SetName("Drugs")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggle Drugs from being developed (this won't remove existing Drugs already made)")
				.SetPosition(new Vector2(1224, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Drones_Toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Drone"))
				.SetName("Drones")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggle if kingdoms can create Drones.")
				.SetPosition(new Vector2(1152, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_P9000")
				.SetName("Spawn P9000")
				.SetDescription("The goat.")
				.SetIcon(Resources.Load<Sprite>("ui/icons/P9000"))
				.SetPosition(new Vector2(1044, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_Terran")
				.SetName("Spawn Terran Goliath")
				.SetDescription("Spawn a mech.")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Terran"))
				.SetPosition(new Vector2(1080, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("P9000Factory_toggle")
				.SetName("P9000 Factories")
				.SetDescription("DISABLED, COMING SOON!!!")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/P9000"))
				.SetPosition(new Vector2(1044, -18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("TerranFactory_toggle")
				.SetName("Terran Goliath Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make the Terran Goliath.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Terran"))
				.SetPosition(new Vector2(1080, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("heli_spawn")
				.SetName("Helicopter Spawn")
				.SetDescription("Spawn a Helicopter")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Heli"))
				.SetPosition(new Vector2(720, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("HelicopterFactory_toggle")
				.SetName("Helicopter Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Helicopters")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Heli"))
				.SetPosition(new Vector2(720, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_airship")
				.SetName("Spawn Zeppelin")
				.SetDescription("Spawn a Zeppelin.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Airship"))
				.SetPosition(new Vector2(756, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("AirshipFactory_toggle")
				.SetName("Airship Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Airships")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Airship"))
				.SetPosition(new Vector2(756, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_tank")
				.SetName("Spawn Tank")
				.SetDescription("Spawn a tank.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Tank"))
				.SetPosition(new Vector2(792, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("TankFactory_toggle")
				.SetName("Tank Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Tanks")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Tank"))
				.SetPosition(new Vector2(792, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_mirv_bomber")
				.SetName("Spawn MIRV Bomber")
				.SetDescription("Spawn a MIRV Bomber.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetPosition(new Vector2(828, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("AirFactory_toggle")
				.SetName("MIRV Bomber Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make MIRV Bombers")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetPosition(new Vector2(828, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_humvee")
				.SetName("Spawn Humvee")
				.SetDescription("Spawn a Humvee.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Humvee"))
				.SetPosition(new Vector2(864, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("HumveeFactory_toggle")
				.SetName("Humvee Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Humvees")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Humvee"))
				.SetPosition(new Vector2(864, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_FighterJet")
				.SetName("Spawn FighterJet")
				.SetDescription("Spawn a FighterJet.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/FighterJet"))
				.SetPosition(new Vector2(900, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_Drone")
				.SetName("Spawn Drone")
				.SetDescription("Spawn a Drone.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Drone"))
				.SetPosition(new Vector2(1260 + 36 + 36, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_Troop")
				.SetName("Spawn Soldier")
				.SetDescription("Spawn a Soldier.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Soldier"))
				.SetPosition(new Vector2(1260 + 36 + 36, -18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("FighterJetFactory_toggle")
				.SetName("FighterJet Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make FighterJets")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/FighterJet"))
				.SetPosition(new Vector2(900, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_MissileSystem")
				.SetName("Spawn Artillery")
				.SetDescription("Spawn a Missile System.")
				.SetIcon(Resources.Load<Sprite>("actors/MissileSystem/swim_1"))
				.SetPosition(new Vector2(936, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("BoiFactory_toggle")
				.SetName("Missile System Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Missile Systems")
				.SetIcon(Resources.Load<Sprite>("actors/MissileSystem/swim_1"))
				.SetPosition(new Vector2(936, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("gunship_spawn")
				.SetName("Gunship Spawn")
				.SetDescription("Spawn a Gunship")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Gunship"))
				.SetPosition(new Vector2(972, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("GunshipFactory_toggle")
				.SetName("Gunship Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Gunships")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Gunship"))
				.SetPosition(new Vector2(972, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("PipeGun_toggle")
				.SetName("Toggle Pipe Guns.")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggle Pipe Guns from being developed (this won't remove existing Pipe Guns already made). You're welcome LonelyFear.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/lowfirearm"))
				.SetPosition(new Vector2(1188, 18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Gun_toggle")
				.SetName("Toggle Guns.")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggle Guns from being developed (this won't remove existing Guns already made).")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/firearm"))
				.SetPosition(new Vector2(1188, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Devmode")
				.SetName("Toggle Developer Mode")
				.SetDescription("Secret stuff")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Dev"))
				.SetPosition(new Vector2(1200, -72))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("discord_server")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/DiscordServer"))
				.SetName("Discord Server")
				.SetDescription("Click this to join the ModernBox Discord server!")
				.SetPosition(new Vector2(180, -18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("about")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Guide"))
				.SetName("Guide")
				.SetDescription("Read the guide on how ModernBox works.")
				.SetPosition(new Vector2(180, 18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Soldier_toggle")
				.SetIcon(Resources.Load<Sprite>("actors/Soldier/walk_0"))
				.SetName("Modern Militaries")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if modern soldiers can be enlisted.")
				.SetPosition(new Vector2(1152, 18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Nuke_toggle")
				.SetIcon(Resources.Load<Sprite>("effects/projectiles/NUKER/0"))
				.SetName("Toggle Nuke Silos")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if kingdoms can nuke each other.")
				.SetPosition(new Vector2(504, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_Railgun")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Railgun"))
				.SetName("Spawn Railgun")
				.SetDescription("Spawn a Railgun")
				.SetPosition(new Vector2(1008, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("RailgunFactory_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Railgun"))
				.SetName("Railgun Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make Railguns")
				.SetPosition(new Vector2(1008, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("credits")
				.SetIcon(Resources.Load<Sprite>("ui/icons/iconabout"))
				.SetName("Credits")
				.SetDescription("All the people behind ModernBox and more!")
				.SetPosition(new Vector2(216, -18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("ResetSettings")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Reset"))
				.SetName("Reset to defaults")
				.SetDescription("Resets ALL saved settings to their default values.")
				.SetPosition(new Vector2(216, 18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("other_names_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/tabIconModernWarfare"))
				.SetName("Modern Names for Other Races.")
				.SetDescription("Enable or Disable First and Last names for other races..")
				.SetPosition(new Vector2(252, 18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("names_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/name_1"))
				.SetName("Modern Names")
				.SetDescription("Enable or Disable Modern Names.")
				.SetPosition(new Vector2(252, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("galaxy")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Galaxy"))
				.SetName("SPACE")
				.SetDescription("Download custom galaxies + enter the starmap.")
				.SetPosition(new Vector2(72, 18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("achievements")
				.SetIcon(Resources.Load<Sprite>("ui/icons/trophy"))
				.SetName("Achievements")
				.SetDescription("COMING SOON")
				.SetPosition(new Vector2(72, -18))
				.SetType("Click")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("arrowleft2")
				.SetIcon(Resources.Load<Sprite>("ui/icons/arrowleft"))
				.SetName("Choose Units")
				.SetDescription("Select the units you want to send to space.")
				.SetPosition(new Vector2(108, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("arrowleft3")
				.SetIcon(Resources.Load<Sprite>("ui/icons/arrowright"))
				.SetName("Land Units")
				.SetDescription("Land Units on your planet.")
				.SetPosition(new Vector2(108, -18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_mirv_bomber")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetName("Spawn MIRV Bomber")
				.SetDescription("Spawn a MIRV Bomber.")
				.SetPosition(new Vector2(828, 18))
				.SetType("GodPower")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("AirFactory_toggle")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetName("MIRV Bomber Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Toggles if factories make MIRV Bombers")
				.SetPosition(new Vector2(828, -18))
				.SetType("Toggle")
				.SetTab("M3_TAB")
				.Build();

			Debug.Log($"Custom trait created successfully!");
		}
	}
}