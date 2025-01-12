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
    class GuideWindow
    {
        public static GameObject contentComponent;
        public static Text GuideTab;
        public static GameObject contentComponent2;
        public static Text GuideTab2;
        public static GameObject contentComponent3;
        public static Text GuideTab3;
        public static GameObject contentComponent4;
        public static Text GuideTab4;
        public static GameObject contentComponent5;
        public static Text GuideTab5;
        public static void init()
        {
            ScrollWindow GuideWindow = Windows.CreateNewWindow("GuideWindow", null);
            GuideWindow.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
            
            contentComponent = GuideWindow.transform
            .Find("Background")
            .Find("Name").gameObject;
            GuideTab = contentComponent.GetComponent<Text>();
            GuideTab.text = LocalizedTextManager.getText("TECH: This page covers tech and when they should be unlocked. The modern era should begin around 500-1000 years into a cultures existence, with them first unlocking guns and later on MIRVs, vehicles, and buildings. MIRVs are one of the last things they will develop. The next page is on Cyberware and Drugs.", null);
            GuideTab.supportRichText = true;
            GuideTab.transform.SetParent(GuideWindow.transform
            .Find("Background")
            .Find("Scroll View")
            .Find("Viewport")
            .Find("Content"));
            contentComponent.SetActive(true);

            var buttonUpdatelog2 = NCMS.Utils.PowerButtons.CreateButton("Updatelog2", Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.other.nextpage.png"),
            null, null, new Vector2(120, 52), ButtonType.Click, GuideWindow.transform, () => Windows.ShowWindow("GuideWindow2"));
            RTF1();

            ScrollWindow GuideWindow2 = Windows.CreateNewWindow("GuideWindow2", null);
            GuideWindow2.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
            
            contentComponent2 = GuideWindow2.transform
            .Find("Background")
            .Find("Name").gameObject;
            GuideTab2 = contentComponent2.GetComponent<Text>();
            GuideTab2.text = LocalizedTextManager.getText("DRUGS AND CYBERWARE: Drugs and Cyberware are one of the oldest things to be added into ModernBox, and one of the least changed things in it. All these do is increase or decrease unit stats and not much else, and they are rare to find. The next page is on nukes.", null);
            GuideTab2.supportRichText = true;
            GuideTab2.transform.SetParent(GuideWindow2.transform
            .Find("Background")
            .Find("Scroll View")
            .Find("Viewport")
            .Find("Content"));
            contentComponent2.SetActive(true);

            var buttonUpdatelog3 = NCMS.Utils.PowerButtons.CreateButton("Updatelog3", Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.other.nextpage.png"),
            null, null, new Vector2(120, 52), ButtonType.Click, GuideWindow2.transform, () => Windows.ShowWindow("GuideWindow3"));
            RTF2();

            ScrollWindow GuideWindow3 = Windows.CreateNewWindow("GuideWindow3", null);
            GuideWindow3.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
            
            contentComponent3 = GuideWindow3.transform
            .Find("Background")
            .Find("Name").gameObject;
            GuideTab3 = contentComponent3.GetComponent<Text>();
            GuideTab3.text = LocalizedTextManager.getText("NUKES: This covers ONLY the kingdoms nuking eachother, not the nukes you can drop on them such as the proton bomb. Nukes are an unpredictable feature and kingdoms sometimes nuke literally anything that attacks them, even bears. They sure are deadly and be mindful that if you turn them on, there's no way to turn them back off for that world aside from restarting the game. Nukes are far from a perfect future but at least they work. The next page covers vehicles and MIRVS.", null);
            GuideTab3.supportRichText = true;
            GuideTab3.transform.SetParent(GuideWindow3.transform
            .Find("Background")
            .Find("Scroll View")
            .Find("Viewport")
            .Find("Content"));
            contentComponent3.SetActive(true);

            var buttonUpdatelog4 = NCMS.Utils.PowerButtons.CreateButton("Updatelog4", Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.other.nextpage.png"),
            null, null, new Vector2(120, 52), ButtonType.Click, GuideWindow3.transform, () => Windows.ShowWindow("GuideWindow4"));
            RTF3();

            ScrollWindow GuideWindow4 = Windows.CreateNewWindow("GuideWindow4", null);
            GuideWindow4.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
            
            contentComponent4 = GuideWindow4.transform
            .Find("Background")
            .Find("Name").gameObject;
            GuideTab4 = contentComponent4.GetComponent<Text>();
            GuideTab4.text = LocalizedTextManager.getText("VEHICLES AND MIRVS: Vehicles are a staple point of ModernBox, ranging from Tanks to Fighter jets. They can be produced either by you or by kingdoms as long as that specific vehicle is enabled for factory production. You can only place vehicles in kingdoms, not in the wilderness (duh). Modern Soldiers are considered vehicles in code so they will be covered here, they spawn through the barracks building and have better stats than normal soldiers. If you enable vehicles late game, factories that were built before it was enabled will NOT produce vehicles. MIRVs are in fact not M.I.R.VS as they are in real life, instead they are really fast rocket launchers that can mow down entire countries. The next page is on misc stuff. ", null);
            GuideTab4.supportRichText = true;
            GuideTab4.transform.SetParent(GuideWindow4.transform
            .Find("Background")
            .Find("Scroll View")
            .Find("Viewport")
            .Find("Content"));
            contentComponent4.SetActive(true);

            var buttonUpdatelog5 = NCMS.Utils.PowerButtons.CreateButton("Updatelog5", Mod.EmbededResources.LoadSprite($"{Mod.Info.Name}.Resources.other.nextpage.png"),
            null, null, new Vector2(120, 52), ButtonType.Click, GuideWindow4.transform, () => Windows.ShowWindow("GuideWindow5"));
            RTF4();

            ScrollWindow GuideWindow5 = Windows.CreateNewWindow("GuideWindow5", null);
            GuideWindow5.transform.Find("Background").Find("Scroll View").gameObject.SetActive(true);
            
            contentComponent5 = GuideWindow5.transform
            .Find("Background")
            .Find("Name").gameObject;
            GuideTab5 = contentComponent5.GetComponent<Text>();
            GuideTab5.text = LocalizedTextManager.getText("MISC STUFF: Stuff like Ideologies will be covered here. Ideologies are a set of traits that can influence that units actions (especially if they are a king) and yeah that's basically all they are. Modern Names are pretty self explainatory, it just adds first and last names for all units. ", null);
            GuideTab5.supportRichText = true;
            GuideTab5.transform.SetParent(GuideWindow5.transform
            .Find("Background")
            .Find("Scroll View")
            .Find("Viewport")
            .Find("Content"));
            contentComponent5.SetActive(true);
            RTF5();
        }
        public static void RTF1()
        {
          GameObject UpdatelogContent = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/GuideWindow/Background/Scroll View/Viewport/Content");
          RectTransform rect = contentComponent.GetComponent<RectTransform>();
          rect.anchorMin = new Vector2(0.5f, 1);
          rect.anchorMax = new Vector2(0.5f, 1);
          rect.offsetMin = new Vector2(-90f, GuideTab.preferredHeight * -1);
          rect.offsetMax = new Vector2(90f, -17);
          rect.sizeDelta = new Vector2(180, GuideTab.preferredHeight + 50);
          UpdatelogContent.GetComponent<RectTransform>().sizeDelta = new Vector2(0, GuideTab.preferredHeight + 50);
          contentComponent.transform.localPosition = new Vector2(contentComponent.transform.localPosition.x, ((GuideTab.preferredHeight / 2) + 30) * -1);
        }
        public static void RTF2()
        {
          GameObject Updatelog2Content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/GuideWindow2/Background/Scroll View/Viewport/Content");
          RectTransform rect2 = contentComponent2.GetComponent<RectTransform>();
          rect2.anchorMin = new Vector2(0.5f, 1);
          rect2.anchorMax = new Vector2(0.5f, 1);
          rect2.offsetMin = new Vector2(-90f, GuideTab2.preferredHeight * -1);
          rect2.offsetMax = new Vector2(90f, -17);
          rect2.sizeDelta = new Vector2(180, GuideTab2.preferredHeight + 50);
          Updatelog2Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, GuideTab2.preferredHeight + 50);
          contentComponent2.transform.localPosition = new Vector2(contentComponent2.transform.localPosition.x, ((GuideTab2.preferredHeight / 2) + 30) * -1);
        }
        public static void RTF3()
        {
          GameObject Updatelog3Content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/GuideWindow3/Background/Scroll View/Viewport/Content");
          RectTransform rect3 = contentComponent3.GetComponent<RectTransform>();
          rect3.anchorMin = new Vector2(0.5f, 1);
          rect3.anchorMax = new Vector2(0.5f, 1);
          rect3.offsetMin = new Vector2(-90f, GuideTab3.preferredHeight * -1);
          rect3.offsetMax = new Vector2(90f, -17);
          rect3.sizeDelta = new Vector2(180, GuideTab3.preferredHeight + 50);
          Updatelog3Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, GuideTab3.preferredHeight + 50);
          contentComponent3.transform.localPosition = new Vector2(contentComponent3.transform.localPosition.x, ((GuideTab3.preferredHeight / 2) + 30) * -1);
        }
        public static void RTF4()
        {
          GameObject Updatelog4Content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/GuideWindow4/Background/Scroll View/Viewport/Content");
          RectTransform rect4 = contentComponent4.GetComponent<RectTransform>();
          rect4.anchorMin = new Vector2(0.5f, 1);
          rect4.anchorMax = new Vector2(0.5f, 1);
          rect4.offsetMin = new Vector2(-90f, GuideTab4.preferredHeight * -1);
          rect4.offsetMax = new Vector2(90f, -17);
          rect4.sizeDelta = new Vector2(180, GuideTab4.preferredHeight + 50);
          Updatelog4Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, GuideTab4.preferredHeight + 50);
          contentComponent4.transform.localPosition = new Vector2(contentComponent4.transform.localPosition.x, ((GuideTab4.preferredHeight / 2) + 30) * -1);
        }
        public static void RTF5()
        {
          GameObject Updatelog5Content = GameObject.Find("/Canvas Container Main/Canvas - Windows/windows/GuideWindow5/Background/Scroll View/Viewport/Content");
          RectTransform rect5 = contentComponent5.GetComponent<RectTransform>();
          rect5.anchorMin = new Vector2(0.5f, 1);
          rect5.anchorMax = new Vector2(0.5f, 1);
          rect5.offsetMin = new Vector2(-90f, GuideTab5.preferredHeight * -1);
          rect5.offsetMax = new Vector2(90f, -17);
          rect5.sizeDelta = new Vector2(180, GuideTab5.preferredHeight + 50);
          Updatelog5Content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, GuideTab5.preferredHeight + 50);
          contentComponent5.transform.localPosition = new Vector2(contentComponent5.transform.localPosition.x, ((GuideTab5.preferredHeight / 2) + 30) * -1);
        }
    }
}
