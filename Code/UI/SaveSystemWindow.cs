//========= MODERNBOX 2.1.0.0 ============//
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
    class SaveSystemWindow
    {
        public static void init()
        {
            var window = Windows.CreateNewWindow("SaveSystemWindow", "ModernBox 2");
            var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View");
            scrollView.gameObject.SetActive(true);
            var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
            var viewportRect = viewport.GetComponent<RectTransform>();
            viewportRect.sizeDelta = new Vector2(0, 17);
            var content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport/Content");
            string gold = "#FFD700";

            var description =
@"<color='" + gold + @"'>[ModernBox 2]</color>

Thank you for playing the mod! If you have any problems or you want news on future updates (and vote on features), join the discord server! It's also a great place to socialize. Click the button below to join! This menu showes up either when you first get the mod or whenever it updates, remember, every update will reset your settings for ModernBox 2.";
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

            Sprite imageSprite2 = Resources.Load<Sprite>("ui/Icons/buttonSprite");

            GameObject imageGO2 = new GameObject("ImageGO2");
            imageGO2.transform.SetParent(content.transform);

            Image imageComponent2 = imageGO2.AddComponent<Image>();
            imageComponent2.sprite = imageSprite2;

            RectTransform imageRect2 = imageGO2.GetComponent<RectTransform>();
            imageRect2.anchoredPosition = new Vector2(0, -100);
            imageRect2.sizeDelta = new Vector2(200, 100);

            Button imageButton2 = imageGO2.AddComponent<Button>();
            imageButton2.onClick.AddListener(() =>
            {
                Application.OpenURL("https://discord.gg/HEBNQpbCJf");
            });

            var colors = imageButton2.colors;
            colors.highlightedColor = Color.yellow;
            colors.pressedColor = Color.gray;
            imageButton2.colors = colors;
        }
    }
}
