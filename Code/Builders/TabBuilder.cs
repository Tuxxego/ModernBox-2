using System;
using UnityEngine;
using UnityEngine.UI;
using NCMS;
using NCMS.Utils;
// A portion of this file is derived from NCMS (made by Nikon)
namespace ModernBox
{
    public class TabBuilder
    {
        private string buttonID;
        private string tabID;
        private string name;
        private string description;
        private int xPos;
        private Sprite icon;

        public TabBuilder SetTabID(string id)
        {
            tabID = id;
            buttonID = id;
            return this;
        }
        public TabBuilder SetName(string tabName)
        {
            name = tabName;
            return this;
        }
        public TabBuilder SetDescription(string tabDescription)
        {
            description = tabDescription;
            return this;
        }
        public TabBuilder SetPosition(int positionX)
        {
            xPos = positionX;
            return this;
        }
        public TabBuilder SetIcon(string resourcePath)
        {
           // icon = ResourceLoader.LoadSprite(resourcePath);
            icon = Resources.Load<Sprite>(resourcePath);
            return this;
        }
        public void Build()
        {
            GameObject otherTabButton = FindAllGameObjectsCreditToNikonForThisFunctionBTW("button_other");
            if (otherTabButton == null)
            {
                ModernBoxLogger.Error("Error: Could not find 'Button_Other' to clone for tab creation.");
                return;
            }
                Localization.AddOrSet(buttonID, name);
                Localization.AddOrSet($"{buttonID} Description", description);
                Localization.AddOrSet("Tuxxego_mod_creator",  "Fixed by the Castro Family.");
                Localization.AddOrSet(tabID, name);
            GameObject newTabButton = GameObject.Instantiate(otherTabButton);
            newTabButton.transform.SetParent(otherTabButton.transform.parent);
            newTabButton.name = buttonID;
            Button buttonComponent = newTabButton.GetComponent<Button>();
            TipButton tipButton = newTabButton.GetComponent<TipButton>();
            tipButton.textOnClick = buttonID;
            tipButton.textOnClickDescription = $"{buttonID} Description";
            tipButton.text_description_2 = "Tuxxego_mod_creator";
            newTabButton.transform.localPosition = new Vector3(xPos, 49.57f);
            newTabButton.transform.localScale = Vector3.one;
            if (icon != null)
            {
                newTabButton.transform.Find("Icon").GetComponent<Image>().sprite = icon;
            }
            GameObject otherTab = FindAllGameObjectsCreditToNikonForThisFunctionBTW("other");
            if (otherTab == null)
            {
                ModernBoxLogger.Error("Error: Could not find 'Tab_Other' to clone for tab creation.");
                return;
            }
            foreach (Transform child in otherTab.transform)
            {
                child.gameObject.SetActive(false);
            }
            GameObject newTab = GameObject.Instantiate(otherTab);
            foreach (Transform child in newTab.transform)
            {
                if (child.gameObject.name == "tabBackButton" || child.gameObject.name == "-space")
                {
                    child.gameObject.SetActive(true);
                    continue;
                }
                GameObject.Destroy(child.gameObject);
            }
            foreach (Transform child in otherTab.transform)
            {
                child.gameObject.SetActive(true);
            }
            newTab.transform.SetParent(otherTab.transform.parent);
            newTab.name = tabID;
            PowersTab powersTabComponent = newTab.GetComponent<PowersTab>();
            powersTabComponent.powerButton = buttonComponent;
            powersTabComponent._power_buttons.Clear();
            powersTabComponent.powerButton.onClick = new Button.ButtonClickedEvent();
            powersTabComponent.powerButton.onClick.AddListener(() => ShowTab(tabID));
            newTab.SetActive(true);
            powersTabComponent.powerButton.gameObject.SetActive(true);

            var asset = new PowerTabAsset
            {
                id = tabID,
                locale_key = "tab_modernbox",
                tab_type_main = true,
                get_power_tab = () => powersTabComponent
            };
            AssetManager.power_tab_library.add(asset);
            powersTabComponent._asset = asset;

        }
        private static void ShowTab(string tabID)
        {
            GameObject additionalTab = FindAllGameObjectsCreditToNikonForThisFunctionBTW(tabID);
            if (additionalTab != null)
            {
                PowersTab powersTabComponent = additionalTab.GetComponent<PowersTab>();
                powersTabComponent.showTab(powersTabComponent.powerButton);
            }
        }
        // FindAllGameObjectsCreditToNikonForThisFunctionBTW is from NCMS (made by Nikon)
        public static GameObject FindAllGameObjectsCreditToNikonForThisFunctionBTW(string Name)
        {
            GameObject[] objectsOfTypeAll = Resources.FindObjectsOfTypeAll<GameObject>();
            for (int index = 0; index < objectsOfTypeAll.Length; ++index)
            {
                if (objectsOfTypeAll[index].gameObject.gameObject.name == Name)
                    return objectsOfTypeAll[index];
            }
            return (GameObject)null;
        }
    }
}
