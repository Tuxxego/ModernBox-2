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
	public class KaijuUI
	{

		public void init()
		{
			PowersTab tab = KaijugetPowersTab("Tab_kaiju");

			GameObject largeImageObject = new GameObject("LargeImage");
			largeImageObject.transform.SetParent(tab.transform);
			largeImageObject.transform.localPosition = new Vector3(396, 18, 0);
			largeImageObject.transform.localScale = Vector3.one;

			Image largeImage = largeImageObject.AddComponent<Image>();
			largeImage.sprite = Resources.Load<Sprite>("ui/icons/TabTextKaiju");

			RectTransform imageRect = largeImageObject.GetComponent<RectTransform>();
			imageRect.sizeDelta = new Vector2(200, 100);
			imageRect.anchorMin = new Vector2(0.5f, 0.5f);
			imageRect.anchorMax = new Vector2(0.5f, 0.5f);

            StatManager.Instance.RegisterImage(largeImage);




             ////////////////////////BOSSES///////////////////////////////////////


new ButtonBuilder("spawnGodzilla")
    .AsUnitSpawner("Godzilla")
      .SetTitle("Godzilla")
      .SetDescription("The King of Monsters")
    .SetGodPowerIconPath("ui/icons/Godzilla")
    .SetPosition(0, 0)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnKingKong")
    .AsUnitSpawner("KingKong")
    .SetGodPowerName("King Kong")
    .SetDescription("King of the Beasts")
    .SetGodPowerIconPath("ui/icons/iconKingKong")
    .SetPosition(0, 1)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnGhidorah")
    .AsUnitSpawner("Ghidorah")
    .SetGodPowerName("Ghidorah")
    .SetDescription("The devilish World Ender")
    .SetGodPowerIconPath("ui/icons/Ghidorah")
    .SetPosition(1, 0)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnRodan")
    .AsUnitSpawner("Rodan")
    .SetGodPowerName("Rodan")
    .SetDescription("King of the skies")
    .SetGodPowerIconPath("ui/icons/Rodan")
    .SetPosition(1, 1)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnMechagodzilla")
    .AsUnitSpawner("Mechagodzilla")
    .SetGodPowerName("Mechagodzilla")
    .SetDescription("Created with the remains of Ghidorah, it cannot be controlled")
    .SetGodPowerIconPath("ui/icons/Mechagodzilla")
    .SetPosition(2, 0)
    .SetTransform(tab.transform)
    .Build();

            ///////////////////////////WILD SPECIES////////////////////////


new ButtonBuilder("spawnIguanazilla")
    .AsUnitSpawner("Iguanazilla")
    .SetGodPowerName("Iguanazilla")
    .SetDescription("Natural kind of Gojira")
    .SetGodPowerIconPath("ui/icons/Godzilla")
    .SetPosition(14, 0)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnKong")
    .AsUnitSpawner("Kong")
    .SetGodPowerName("Kong")
    .SetDescription("Wild population of Kong")
    .SetGodPowerIconPath("ui/icons/iconKingKong")
    .SetPosition(14, 1)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnHydraflians")
    .AsUnitSpawner("Hydraflians")
    .SetGodPowerName("Hydraflians")
    .SetDescription("Wild population of Ghidorah")
    .SetGodPowerIconPath("ui/icons/Ghidorah")
    .SetPosition(15, 0)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnRadon")
    .AsUnitSpawner("Radon")
    .SetGodPowerName("Radon")
    .SetDescription("Wild population of Rodan")
    .SetGodPowerIconPath("ui/icons/Rodan")
    .SetPosition(15, 1)
    .SetTransform(tab.transform)
    .Build();

    new ButtonBuilder("spawnGuidorahhead")
    .AsUnitSpawner("Guidorahhead")
    .SetGodPowerName("Guidorahhead")
    .SetDescription("Wild population of Guidorah heads used to create mechagodzilla")
    .SetGodPowerIconPath("ui/icons/Guidorahhead")
    .SetPosition(16, 0)
    .SetTransform(tab.transform)
    .Build();



           SetupKaijuLines();
		}





        private void SetupKaijuLines()
        {

          PowersTab tab = KaijugetPowersTab("Tab_kaiju");
          InsertKaijuLine.KaijuAt(10, tab.transform);
          InsertKaijuLine.KaijuAt(25, tab.transform);
        }




          public static PowersTab KaijugetPowersTab(string id) {
            GameObject gameObject = GameObjects.FindEvenInactive(id);
            return gameObject.GetComponent<PowersTab>();
        }

    }
    public static class InsertKaijuLine
    {

        public static void KaijuAt(int gridX, Transform parent)
        {
            float x = 72 + (18 * gridX);

            GameObject line = new GameObject("DALine", typeof(RectTransform), typeof(CanvasRenderer), typeof(Image));
            RectTransform lineRTF = line.GetComponent<RectTransform>();
            Image lineImage = line.GetComponent<Image>();

            lineImage.sprite = Resources.Load<Sprite>("ui/Kaijuline.png");
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
