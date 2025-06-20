using UnityEngine;

using System.Collections.Generic;
using UnityEngine.Events;

using UnityEngine.UI;
using System.Collections;
using NCMS.Utils;
using NCMS;
using ReflectionUtility;
using TuxModLoader.Reflection;
using System.Reflection;
using System;

namespace ModernBox
{
	public class Buttonz
	{

		public void Init()
		{
			PowersTab tab = getPowersTab("ModernBox");

			GameObject largeImageObject = new GameObject("LargeImage");
			largeImageObject.transform.SetParent(tab.transform);
			largeImageObject.transform.localPosition = new Vector3(396, 18, 0);
			largeImageObject.transform.localScale = Vector3.one;

			Image largeImage = largeImageObject.AddComponent<Image>();
			largeImage.sprite = Resources.Load<Sprite>("ui/icons/TabText");

			RectTransform imageRect = largeImageObject.GetComponent<RectTransform>();
			imageRect.sizeDelta = new Vector2(200, 100);
			imageRect.anchorMin = new Vector2(0.5f, 0.5f);
			imageRect.anchorMax = new Vector2(0.5f, 0.5f);

            StatManager.Instance.RegisterImage(largeImage);

            GameObject statLabelObject = new GameObject("StatLabel");
            statLabelObject.transform.SetParent(tab.transform);
            statLabelObject.transform.localPosition = new Vector3(356, -18, 0);
            statLabelObject.transform.localScale = Vector3.one;

            Text statText = statLabelObject.AddComponent<Text>();
            statText.font = Resources.GetBuiltinResource<Font>("Arial.ttf");
            statText.fontSize = 9;
            statText.color = new Color(1f, 0.95f, 0.8f);
            statText.supportRichText = true;
            statText.text = "Loading stats...";

            RectTransform textRect = statLabelObject.GetComponent<RectTransform>();
            textRect.sizeDelta = new Vector2(200, 100);
            textRect.anchorMin = new Vector2(0.5f, 0.5f);
            textRect.anchorMax = new Vector2(0.5f, 0.5f);

            StatManager.Instance.RegisterStatLabel(statText);

            GameObject discordAdObject = new GameObject("DiscordAd");
            discordAdObject.transform.SetParent(tab.transform);
            discordAdObject.transform.localPosition = new Vector3(136, -20, 0);
            discordAdObject.transform.localScale = Vector3.one;

            Image discordAdImage = discordAdObject.AddComponent<Image>();
            discordAdImage.sprite = Resources.Load<Sprite>("ui/icons/buttonSprite");

            RectTransform adRect = discordAdObject.GetComponent<RectTransform>();
            adRect.sizeDelta = new Vector2(65, 25);
            adRect.anchorMin = new Vector2(0.5f, 0.5f);
            adRect.anchorMax = new Vector2(0.5f, 0.5f);

            discordAdObject.AddComponent<DiscordAdHover>();

            Button adButton = discordAdObject.AddComponent<Button>();
            adButton.onClick.AddListener(() =>
            {
                Application.OpenURL("https://discord.gg/c2fSfqvcdV");

            });

            StatManager.Instance.RegisterFlashingImage(discordAdImage);

            new ButtonBuilder("credits")
            .SetSprite(Resources.Load<Sprite>("ui/icons/iconabout"))
            .SetTitle("About ModernBox")
            .SetDescription("All the people behind ModernBox and more!")
            .SetPosition(0, 0)
            .SetType(ButtonType.Click)
            .SetFunction(openAboutWindow)
            .SetTransform(tab.transform)

            .Build();

        new ButtonBuilder("resettodefaults")
            .SetSprite(Resources.Load<Sprite>("ui/icons/Reset"))
            .SetTitle("Reset to defaults")
            .SetDescription("Resets ALL saved settings to their default values.")
            .SetPosition(1, 0)
            .SetType(ButtonType.Click)
            .SetFunction(Main.resetToDefaults)
            .SetTransform(tab.transform)
            .Build();

        new ButtonBuilder("balls1")
            .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
            .SetTitle("Coming soon")
            .SetDescription("Be patient.")
            .SetPosition(2, 0)
            .SetType(ButtonType.Click)
            .SetTransform(tab.transform)
            .SetFunction(openNothing)
            .Build();

        new ButtonBuilder("balls2")
            .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
            .SetTitle("Coming soon")
            .SetDescription("Be patient.")
            .SetPosition(4, 0)
            .SetType(ButtonType.Click)
            .SetTransform(tab.transform)
            .SetFunction(openNothing)
            .Build();

        new ButtonBuilder("balls3")
            .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
            .SetTitle("Coming soon")
            .SetDescription("Be patient.")
            .SetPosition(4, 1)
            .SetType(ButtonType.Click)
            .SetTransform(tab.transform)
            .SetFunction(openNothing)
            .Build();

       /* new ButtonBuilder("galaxy")
            .SetSprite(Resources.Load<Sprite>("ui/icons/Galaxy"))
            .SetTitle("SPACE")
            .SetDescription("Download custom galaxies + enter the starmap.")
            .SetPosition(4, 0)
            .SetType(ButtonType.Click)
            .SetTransform(tab.transform)
            .SetFunction(openStarMap)
            .Build(); */

        new ButtonBuilder("m3achievements")
            .SetSprite(Resources.Load<Sprite>("ui/icons/trophy"))
            .SetTitle("Achievements")
            .SetDescription("COMING SOON")
            .SetPosition(0, 1)
            .SetType(ButtonType.Click)
            .SetFunction(openAchievmentsWindow)
            .SetTransform(tab.transform)
            .SetFunction(openAchievmentsWindow)
            .Build();

             new ButtonBuilder("unitbuttonspawner")
            .SetSprite(Resources.Load<Sprite>("ui/icons/Tank"))
            .SetTitle("Open Unit Spawning")
            .SetDescription("Spawn any vehicle.")
            .SetPosition(18, 0)
            .SetType(ButtonType.Click)
            .SetTransform(tab.transform)
            .SetFunction(OpenUnitSpawner)
            .Build();

            new ButtonBuilder("nukes_toggle")
                .SetSprite(Resources.Load<Sprite>("ui/icons/Nuke"))
                .SetTitle("Toggle Nuclear Warfare")
                .SetDescription("Kingdoms can nuke each other.")
                .SetPosition(11, 0)
                .SetType(ButtonType.Toggle)
                .SetTransform(tab.transform)
                .SetFunction(Vehicles.toggleNukes)
                .Build();

            if (Main.savedSettings.boolOptions["NukeOption"]) {
                PowerButtons.ToggleButton("nukes_toggle");
                Vehicles.toggleNukes();
            }



            new ButtonBuilder("vehicle_toggle")
                .SetSprite(Resources.Load<Sprite>("actors/Heli_Human/new_helicopter1"))
                .SetTitle("Toggle Vehicles")
                .SetDescription("Toggles the ability for kingdoms to produce vehicles.")
                .SetPosition(18, 1)
                .SetType(ButtonType.Toggle)
                .SetTransform(tab.transform)
                .SetFunction(Traits.toggleVehicles)
                .Build();

            if (Main.savedSettings.boolOptions["FactoriesOption"]) {
                PowerButtons.ToggleButton("vehicle_toggle");
                Traits.toggleVehicles();
            }

            new ButtonBuilder("balls4")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(12, 0)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls5")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(12, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls6")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(19, 0)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls7")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(19, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls8")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(20, 0)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls9")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(20, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls10")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(21, 0)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls10")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(21, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls10")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(25, 0)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls11")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(25, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls12")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(23, 0)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls13")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(23, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls14")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(24, 0)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls15")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(24, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            new ButtonBuilder("balls16")
                .SetSprite(Resources.Load<Sprite>("ui/icons/wat"))
                .SetTitle("Coming soon")
                .SetDescription("Be patient.")
                .SetPosition(14, 1)
                .SetType(ButtonType.Click)
                .SetTransform(tab.transform)
                .SetFunction(openNothing)
                .Build();

            SetupBombs();
            SetupLines();
		}
        private void SetupLines()
        {
          PowersTab tab = getPowersTab("ModernBox");
          InsertLine.At(6, tab.transform);
          InsertLine.At(10, tab.transform);
          InsertLine.At(21, tab.transform);
          InsertLine.At(26, tab.transform);
          InsertLine.At(34, tab.transform);
          InsertLine.At(44, tab.transform);
        }

        private void SetupBombs()
        {
            PowersTab tab = getPowersTab("ModernBox");

            new ButtonBuilder("moab_button")
            .SetSprite(Resources.Load<Sprite>("ui/icons/MOAB"))
            .SetTitle("Super-Nuke")
            .SetDescription("Keeping this because it's the OG bomb, but in reality it's basically the same size as the Tsar Bomba.")
            .SetPosition(14, 0)
            .SetType(ButtonType.GodPower)
            .SetTransform(tab.transform)
            .Build();

          /*   new ButtonBuilder("GayBomb")
            .SetSprite(Resources.Load<Sprite>("ui/icons/HOMO!"))
            .SetTitle("Gay Bomb")
            .SetDescription("Turns everyone in the vicinity gay!")
            .SetPosition(14, 1)
            .SetType(ButtonType.GodPower)
            .SetTransform(tab.transform)
            .Build(); */

             new ButtonBuilder("icebomb_button")
            .SetSprite(Resources.Load<Sprite>("ui/icons/I hate this stupid bomb it messed me up"))
            .SetTitle("Ice Bomb")
            .SetDescription("Give everyone in the vicinity a 'nuclear winter'.")
            .SetPosition(15, 0)
            .SetType(ButtonType.GodPower)
            .SetTransform(tab.transform)
            .Build();

             new ButtonBuilder("tuxium_button")
            .SetSprite(Resources.Load<Sprite>("ui/icons/tuxxego rocks"))
            .SetTitle("Tuxium Bomb")
            .SetDescription("In ModernBox fashion, we need at least one ungodly huge bomb that serves no use.")
            .SetPosition(15, 1)
            .SetType(ButtonType.GodPower)
            .SetTransform(tab.transform)
            .Build();

             new ButtonBuilder("firebomb_button")
            .SetSprite(Resources.Load<Sprite>("ui/icons/FIRE!"))
            .SetTitle("Sun Glazing Bomb")
            .SetDescription("Drop the sun on people!")
            .SetPosition(16, 0)
            .SetType(ButtonType.GodPower)
            .SetTransform(tab.transform)
            .Build();

            new ButtonBuilder("clusternuke_button")
            .SetSprite(Resources.Load<Sprite>("ui/icons/ClusterNuke"))
            .SetTitle("Cluster Nuke")
            .SetDescription("Lord have mercy, have 5 bombs!")
            .SetPosition(16, 1)
            .SetType(ButtonType.GodPower)
            .SetTransform(tab.transform)
            .Build();

        }
        private static void openStarMap() {

			 Windows.ShowWindow("SpaceWindow");
		  }

        private static void openAboutWindow() {

			 Windows.ShowWindow("AboutWindow");
             }

        private static void openNothing() {

                Debug.Log("There's nothing here!");
             }

        private static void openAchievmentsWindow() {

			 Windows.ShowWindow("AchievementsWindow");
		  }

        private static void OpenUnitSpawner()
        {
            if (UnitSpawnWindow.Instance == null)
                UnitSpawnWindow.Create();

            UnitSpawnWindow.Instance.Init();
            Windows.ShowWindow("AllUnits");
        }

          public static PowersTab getPowersTab(string id) {
            GameObject gameObject = GameObjects.FindEvenInactive(id);
            return gameObject.GetComponent<PowersTab>();
        }

        public static bool Stuff_Drop(WorldTile pTile, GodPower pPower)
		{
            AssetManager.powers.CallMethod("spawnDrops", pTile, pPower);
			return true;
		}
    }
    public static class InsertLine
    {

        public static void At(int gridX, Transform parent)
        {
            float x = 72 + (18 * gridX);

            GameObject line = new GameObject("DALine", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            RectTransform lineRTF = line.GetComponent<RectTransform>();
            Image lineImage = line.GetComponent<Image>();

            lineImage.sprite = Resources.Load<Sprite>("ui/DAline.png");
            lineRTF.sizeDelta = new Vector2(16, 86);
            lineRTF.anchoredPosition = new Vector2(x, 0);
            lineRTF.localScale = Vector3.one;
            lineRTF.anchorMin = new Vector2(0, 0.5f);
            lineRTF.anchorMax = new Vector2(0, 0.5f);
            lineRTF.pivot = new Vector2(0.5f, 0.5f);

            UnityEngine.Object.Instantiate(line, parent);
        }
    }
}
