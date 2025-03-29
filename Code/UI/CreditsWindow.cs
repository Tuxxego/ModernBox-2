//========= MODERNBOX 2.2.0.0 ============//
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
    class CreditsWindow
    {
        public static void init()
        {
          var window = Windows.CreateNewWindow("CreditsWindow", "ModernBox");
          var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View");
          scrollView.gameObject.SetActive(true);
          var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
          var viewportRect = viewport.GetComponent<RectTransform>();
          viewportRect.sizeDelta = new Vector2(0, 17);
          var content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport/Content");
          string gold = "#FFD700";
          string Dgold = "#ffae00";
var description =
@"<color='" + gold + @"'>CREDITS</color>
Lead Developer:
Tuxxego

<color='" + gold + @"'>Developer Team:</color>

Dankmrgreen6444
Goosefang
MORFOS
Full Auto Sherman
Gecko
PlayerCro7
LonelyFear
Fakher
Ariel
Mr. P
Melvin Shwuaner



Other Mod Developers to Credit:
alexnitaly (Gunsmith Book)
haydar_kara (Hivemind)
3m1rh4n (RifleActions/WestActions)

Contributors:
arielp2
immortalglitch5500
thedesertroad
luck
Nico_the_Nine

<color='" + gold + @"'>DISCORD SERVER:</color>
Admins:
slowatplaye
keymasterer

Moderators:
matthewn0008 the_state_of_florida cakewashere
.xiexel _harrier
<color='" + gold + @"'>SERVER BOOSTERS:</color>
keymasterer
sog1029 icee9924 wolfenmicky
";


          var name = window.transform.Find("Background").Find("Name").gameObject;
          var nameText = name.GetComponent<Text>();
          nameText.text = description;
          nameText.color = new Color(0.9f, 0.6f, 0, 1);
          nameText.fontSize = 4;
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

			
			
			
			
        }
  }
}
