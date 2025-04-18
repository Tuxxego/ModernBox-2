using UnityEngine;
using TuxModLoader.Builders;
using System.Collections.Generic;
using UnityEngine.Events;
using TuxModLoader;
using UnityEngine.UI;
using System.Collections;

namespace M3
{
	public class Buttonz : MonoBehaviour
	{
		public static PowerButton balls;
        public static Buttonz instance;
        private static GameObject content;

		public string labelText = "THIS DONT WORK";
		private Text labelTextComponent;

		private void Update()
		{
			if (labelTextComponent != null && labelTextComponent.text != labelText)
			{
				labelTextComponent.text = labelText;
			}
		}

		public void Init()
		{
			instance = this;

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
			largeImageObject.transform.localScale = Vector3.one;

			Image largeImage = largeImageObject.AddComponent<Image>();
			largeImage.sprite = Resources.Load<Sprite>("ui/Icons/TabText");

			RectTransform imageRect = largeImageObject.GetComponent<RectTransform>();
			imageRect.sizeDelta = new Vector2(200, 100);
			imageRect.anchorMin = new Vector2(0.5f, 0.5f);
			imageRect.anchorMax = new Vector2(0.5f, 0.5f);

			StartCoroutine(AnimateImage(largeImageObject));

			GameObject textObject = new GameObject("LabelText");
			textObject.transform.SetParent(tab.transform);
			textObject.transform.localPosition = new Vector3(396, -18, 0);
			textObject.transform.localScale = Vector3.one;

			labelTextComponent = textObject.AddComponent<Text>();
			labelTextComponent.text = labelText;

			Font CoolAssFont = Resources.Load<Font>("pistoleerhalf");
			labelTextComponent.font = CoolAssFont != null ? CoolAssFont : Resources.GetBuiltinResource<Font>("Arial.ttf");

			labelTextComponent.fontSize = 18;
			labelTextComponent.alignment = TextAnchor.MiddleCenter;
			labelTextComponent.color = new Color(0.8f, 0.7f, 1f);

			Outline outline = textObject.AddComponent<Outline>();
			outline.effectColor = new Color(0.2f, 0f, 0.5f, 0.8f);
			outline.effectDistance = new Vector2(2, -2);

			Shadow shadow = textObject.AddComponent<Shadow>();
			shadow.effectColor = new Color(0f, 0f, 0f, 0.5f);
			shadow.effectDistance = new Vector2(1, -1);

			RectTransform textRect = textObject.GetComponent<RectTransform>();
			textRect.sizeDelta = new Vector2(200, 100);
			textRect.anchorMin = new Vector2(0.5f, 0.5f);
			textRect.anchorMax = new Vector2(0.5f, 0.5f);
	
			new ButtonBuilder("STRONGMIRV_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRV_nuke"))
				.SetName("Nuclear MIRVs")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Options Nuclear MIRVs from being developed (this won't remove existing Nuclear MIRVS)")
				.SetPosition(new Vector2(288, -18))
				.SetType("Options")
				 .SetComingSoon()
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("MIRV_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRV"))
				.SetName("MIRVs")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Options MIRVs from being developed (this won't remove existing MIRVS)")
				.SetPosition(new Vector2(288, 18))
				.SetType("Options")
				.SetTab("M3_TAB")

				.Build();

			new ButtonBuilder("MOAB")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MOAB"))
				.SetName("Super-Nuke")
				.SetDescription("Also known as the 'Lag Bomb'.")
				.SetPosition(new Vector2(576, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("GayBomb")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/HOMO!"))
				.SetName("Gay Bomb")
				.SetDescription("Turns everyone in the vicinity gay!")
				.SetPosition(new Vector2(576, -18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("IceBomb")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/I hate this stupid bomb it messed me up"))
				.SetName("Ice Bomb")
				.SetDescription("Give everyone in the vicinity a 'nuclear winter'.")
				.SetPosition(new Vector2(540, -18))
				.SetType("Active")
				.SetTab("M3_TAB")

				.Build();

			new ButtonBuilder("TuxiumBomb")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/tuxxego rocks"))
				.SetName("Tuxium Bomb")
				.SetDescription("The most efficient bomb if you only want life to die.")
				.SetPosition(new Vector2(504, 18))
				.SetType("Active")
				.SetTab("M3_TAB")

				.Build();

			new ButtonBuilder("ZombieBomb")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Chicken Jockey"))
				.SetName("Zombie Bomb")
				.SetDescription("Zombifies any idiot around.")
				.SetPosition(new Vector2(612, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("FireBomb")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/FIRE!"))
				.SetName("Sun Glazing Bomb")
				.SetDescription("Drop the sun on people!")
				.SetPosition(new Vector2(612, -18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Cyberware_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Cyberware"))
				.SetName("Cyberware")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Options Cyberware from being developed (this won't remove existing Cyberware)")
				.SetPosition(new Vector2(1224, 18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Drugs_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Drugs"))
				.SetName("Drugs")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Options Drugs from being developed (this won't remove existing Drugs already made)")
				.SetPosition(new Vector2(1224, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Drones_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Drone"))
				.SetName("Drones")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Options if kingdoms can create Drones.")
				.SetPosition(new Vector2(1152, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_P9000")
				.SetName("Spawn P9000")
				.SetDescription("The goat.")
				.SetIcon(Resources.Load<Sprite>("ui/icons/P9000"))
				.SetPosition(new Vector2(1044, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_Terran")
				.SetName("Spawn Terran Goliath")
				.SetDescription("Spawn a mech.")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Terran"))
				.SetPosition(new Vector2(1080, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("P9000Factory_Options")
				.SetName("P9000 Factories")
				.SetDescription("DISABLED, COMING SOON!!!")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/P9000"))
				.SetPosition(new Vector2(1044, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("TerranFactory_Options")
				.SetName("Terran Goliath Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make the Terran Goliath.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Terran"))
				.SetPosition(new Vector2(1080, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("heli_spawn")
				.SetName("Helicopter Spawn")
				.SetDescription("Spawn a Helicopter")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Heli"))
				.SetPosition(new Vector2(720, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("HelicopterFactory_Options")
				.SetName("Helicopter Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make Helicopters")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Heli"))
				.SetPosition(new Vector2(720, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_airship")
				.SetName("Spawn Zeppelin")
				.SetDescription("Spawn a Zeppelin.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Airship"))
				.SetPosition(new Vector2(756, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("AirshipFactory_Options")
				.SetName("Airship Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make Airships")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Airship"))
				.SetPosition(new Vector2(756, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_tank")
				.SetName("Spawn Tank")
				.SetDescription("Spawn a tank.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Tank"))
				.SetPosition(new Vector2(792, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("TankFactory_Options")
				.SetName("Tank Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make Tanks")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Tank"))
				.SetPosition(new Vector2(792, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_mirv_bomber")
				.SetName("Spawn MIRV Bomber")
				.SetDescription("Spawn a MIRV Bomber.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetPosition(new Vector2(828, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("AirFactory_Options")
				.SetName("MIRV Bomber Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make MIRV Bombers")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetPosition(new Vector2(828, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_humvee")
				.SetName("Spawn Humvee")
				.SetDescription("Spawn a Humvee.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Humvee"))
				.SetPosition(new Vector2(864, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("HumveeFactory_Options")
				.SetName("Humvee Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make Humvees")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Humvee"))
				.SetPosition(new Vector2(864, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_FighterJet")
				.SetName("Spawn FighterJet")
				.SetDescription("Spawn a FighterJet.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/FighterJet"))
				.SetPosition(new Vector2(900, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_Drone")
				.SetName("Spawn Drone")
				.SetDescription("Spawn a Drone.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Drone"))
				.SetPosition(new Vector2(1260 + 36 + 36, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_Troop")
				.SetName("Spawn Soldier")
				.SetDescription("Spawn a Soldier.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Soldier"))
				.SetPosition(new Vector2(1260 + 36 + 36, -18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("FighterJetFactory_Options")
				.SetName("FighterJet Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make FighterJets")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/FighterJet"))
				.SetPosition(new Vector2(900, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("spawn_MissileSystem")
				.SetName("Spawn Artillery")
				.SetDescription("Spawn a Missile System.")
				.SetIcon(Resources.Load<Sprite>("actors/MissileSystem/swim_1"))
				.SetPosition(new Vector2(936, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("BoiFactory_Options")
				.SetName("Missile System Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make Missile Systems")
				.SetIcon(Resources.Load<Sprite>("actors/MissileSystem/swim_1"))
				.SetPosition(new Vector2(936, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("gunship_spawn")
				.SetName("Gunship Spawn")
				.SetDescription("Spawn a Gunship")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Gunship"))
				.SetPosition(new Vector2(972, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("GunshipFactory_Options")
				.SetName("Gunship Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make Gunships")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Gunship"))
				.SetPosition(new Vector2(972, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("PipeGun_Options")
				.SetName("Options Pipe Guns.")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Options Pipe Guns from being developed (this won't remove existing Pipe Guns already made). You're welcome LonelyFear.")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/lowfirearm"))
				.SetPosition(new Vector2(1188, 18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Gun_Options")
				.SetName("Options Guns.")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Options Guns from being developed (this won't remove existing Guns already made).")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/firearm"))
				.SetPosition(new Vector2(1188, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Devmode")
				.SetName("Options Developer Mode")
				.SetDescription("Secret stuff")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Dev"))
				.SetPosition(new Vector2(1200, -72))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("discord_server")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Discowd"))
				.SetName("Discord Server")
				.SetDescription("Options this to join the ModernBox Discord server!")
				.SetPosition(new Vector2(180, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("about")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Guide"))
				.SetName("Guide")
				.SetDescription("Read the guide on how ModernBox works.")
				.SetPosition(new Vector2(180, 18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("Soldier_Options")
				.SetIcon(Resources.Load<Sprite>("actors/Soldier/walk_0"))
				.SetName("Modern Militaries")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if modern soldiers can be enlisted.")
				.SetPosition(new Vector2(1152, 18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			// new ButtonBuilder("Nuke_Options")
				// .SetIcon(Resources.Load<Sprite>("effects/projectiles/NUKER/0"))
				// .SetName("Options Nuke Silos")
				// .SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if kingdoms can nuke each other.")
				// .SetPosition(new Vector2(504, -18))
				// .SetType("Options")
				// .SetTab("M3_TAB")
				// .Build();

			new ButtonBuilder("spawn_Railgun")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Railgun"))
				.SetName("Spawn Railgun")
				.SetDescription("Spawn a Railgun")
				.SetPosition(new Vector2(1008, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("RailgunFactory_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/Railgun"))
				.SetName("Railgun Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make Railguns")
				.SetPosition(new Vector2(1008, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("credits")
				.SetIcon(Resources.Load<Sprite>("ui/icons/iconTech"))
				.SetName("Credits")
				.SetDescription("All the people behind ModernBox and more!")
				.SetPosition(new Vector2(216, -18))
				.SetType("Options")
				.SetOnClick(OpenCreditsWindow)
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("ResetSettings")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Reset"))
				.SetName("Reset to defaults")
				.SetDescription("Resets ALL saved settings to their default values.")
				.SetPosition(new Vector2(216, 18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("other_names_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/tabIconModernWarfare"))
				.SetName("Modern Names for Other Races.")
				.SetDescription("Enable or Disable First and Last names for other races..")
				.SetPosition(new Vector2(252, 18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("names_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/name_1"))
				.SetName("Modern Names")
				.SetDescription("Enable or Disable Modern Names.")
				.SetPosition(new Vector2(252, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("galaxy")
				.SetIcon(Resources.Load<Sprite>("ui/icons/Galaxy"))
				.SetName("SPACE")
				.SetDescription("Download custom galaxies + enter the starmap.")
				.SetPosition(new Vector2(72, 18))
				.SetType("Options")
				.SetComingSoon()
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("achievements")
				.SetIcon(Resources.Load<Sprite>("ui/icons/trophy"))
				.SetName("Achievements")
				.SetDescription("COMING SOON")
				.SetPosition(new Vector2(72, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.SetComingSoon()
				.Build();

			new ButtonBuilder("arrowleft2")
				.SetIcon(Resources.Load<Sprite>("ui/icons/arrowleft"))
				.SetName("Choose Units")
				.SetDescription("Select the units you want to send to space.")
				.SetPosition(new Vector2(108, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.SetComingSoon()
				.Build();

			new ButtonBuilder("arrowleft3")
				.SetIcon(Resources.Load<Sprite>("ui/icons/arrowright"))
				.SetName("Land Units")
				.SetDescription("Land Units on your planet.")
				.SetPosition(new Vector2(108, -18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.SetComingSoon()
				.Build();

			new ButtonBuilder("spawn_mirv_bomber")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetName("Spawn MIRV Bomber")
				.SetDescription("Spawn a MIRV Bomber.")
				.SetPosition(new Vector2(828, 18))
				.SetType("Active")
				.SetTab("M3_TAB")
				.Build();

			new ButtonBuilder("AirFactory_Options")
				.SetIcon(Resources.Load<Sprite>("ui/Icons/MIRVBomber"))
				.SetName("MIRV Bomber Factories")
				.SetDescription("(GREEN MEANS ON, GREY IS OFF) Optionss if factories make MIRV Bombers")
				.SetPosition(new Vector2(828, -18))
				.SetType("Options")
				.SetTab("M3_TAB")
				.Build();

			Debug.Log($"Custom trait created successfully!");
		}

		public void OpenCreditsWindow()
		{
			WindowManager.ShowWindow("M3_credits");
		}

		private IEnumerator AnimateImage(GameObject target)
		{
			Vector3 originalScale = Vector3.one;
			Vector3 targetScale = originalScale * 1.1f;

			float duration = 0.5f;
			float time = 0f;

			while (time < duration)
			{
				time += Time.deltaTime;
				float t = time / duration;
				target.transform.localScale = Vector3.Lerp(originalScale, targetScale, t);
				yield return null;
			}

			time = 0f;
			while (time < duration)
			{
				time += Time.deltaTime;
				float t = time / duration;
				target.transform.localScale = Vector3.Lerp(targetScale, originalScale, t);
				yield return null;
			}

			target.transform.localScale = originalScale;
		}
	}
}