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
using System.IO;
using Newtonsoft.Json;
using UnityEngine.Networking;
using System.Net.Http;

namespace M2
{
    class GalaxyHubWindow
    {
        public static int MoveDown = -50;
        private static ScrollWindow window;
        private static GameObject content;
		public static bool isConnected;

        public class CustomGalaxy
        {
            public string name;
            public string description;
            public string author;
            public int requirement;
            public int starCount;
            public int dangerRating;
            public List<float> starWeights;
            public List<float> nebulaColor1;
            public List<float> nebulaColor2;
            public bool GlassStructure;
        }

		  public static void openGalaxyHub() {		  
			if (!isConnected)
			{

				ShowConnectionErrorWindow();
				return;  
			}
			Windows.ShowWindow("GalaxyHub");
		  }

		private static List<CustomGalaxy> GetCustomGalaxies()
		{
			string url = "https://galaxy.tuxxego.us/galaxies";  
			List<CustomGalaxy> galaxies = new List<CustomGalaxy>();
			isConnected = true;

			Debug.Log($"Starting request to fetch custom galaxies from {url}.");

			using (HttpClient client = new HttpClient())
			{
				try
				{

					Debug.Log("Sending HTTP GET request...");
					var response = client.GetStringAsync(url).Result;  

					Debug.Log("Request successful, parsing galaxy data.");

					galaxies = JsonConvert.DeserializeObject<List<CustomGalaxy>>(response);

					Debug.Log($"Successfully fetched {galaxies.Count} galaxies.");
				}
				catch (Exception ex)
				{
					Debug.LogError($"Failed to load custom galaxies: {ex.Message}");
					isConnected = false;  
				}
			}

			return galaxies;
		}

		private static void ShowConnectionErrorWindow()
		{
			string errorWindowName = "connection_error";
			var existingWindow = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{errorWindowName}");

			if (existingWindow != null)
			{

				return;
			}

			var errorWindow = Windows.CreateNewWindow(errorWindowName, "ModernBox");
			var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{errorWindow.name}/Background/Scroll View");
			scrollView.gameObject.SetActive(true);
			var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{errorWindow.name}/Background/Scroll View/Viewport");
			var viewportRect = viewport.GetComponent<RectTransform>();
			viewportRect.sizeDelta = new Vector2(0, 17);
			content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{errorWindow.name}/Background/Scroll View/Viewport/Content");

			var name = errorWindow.transform.Find("Background").Find("Name").gameObject;
			var nameText = name.GetComponent<Text>();
			nameText.text = "Could not connect. Try again later.";
			nameText.color = new Color(1f, 1f, 1f, 0.8f); 
			nameText.fontSize = 10;
			nameText.alignment = TextAnchor.UpperCenter;
			nameText.supportRichText = true;
			name.transform.SetParent(errorWindow.transform.Find("Background").Find("Scroll View").Find("Viewport").Find("Content"));
			name.SetActive(true);

			var nameRect = name.GetComponent<RectTransform>();
			nameRect.anchorMin = new Vector2(0.5f, 1);
			nameRect.anchorMax = new Vector2(0.5f, 1);
			nameRect.offsetMin = new Vector2(-90f, nameText.preferredHeight * -1);
			nameRect.offsetMax = new Vector2(90f, -17);
			nameRect.sizeDelta = new Vector2(180, nameText.preferredHeight + 50);
			errorWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(0, nameText.preferredHeight + 50);
			name.transform.localPosition = new Vector2(name.transform.localPosition.x, ((nameText.preferredHeight / 2) + 30) * -1);

			Windows.ShowWindow(errorWindowName);
		}

		private static void OpenGalaxyStatsWindow(CustomGalaxy galaxy)
		{

			string statsWindowName = $"stats_{galaxy.name}";
			var existingWindow = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{statsWindowName}");

			if (existingWindow != null)
			{

				Windows.ShowWindow(statsWindowName);
				Debug.Log($"Window for {galaxy.name} already exists.");
				return;
			}

			var statsWindow = Windows.CreateNewWindow(statsWindowName, "ModernBox");
			var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{statsWindow.name}/Background/Scroll View");
			scrollView.gameObject.SetActive(true);
			var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{statsWindow.name}/Background/Scroll View/Viewport");
			var viewportRect = viewport.GetComponent<RectTransform>();
			viewportRect.sizeDelta = new Vector2(0, 17);
			content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{statsWindow.name}/Background/Scroll View/Viewport/Content");

			string stats = $"<b>Name:</b> {galaxy.name}\n" +
						   $"<b>Stars:</b> {galaxy.starCount}\n" +
						   $"<b>Danger Rating:</b> {galaxy.dangerRating}\n" +
						   $"<b>Glass Structure:</b> {(galaxy.GlassStructure ? "Yes" : "No")}\n" +
						   $"<b>Author:</b> <color=#FFFFFF>{galaxy.author}</color>\n" +  
						   $"<b>Description:</b> {galaxy.description}"; 

			string[] starTypes = {
				"Red Dwarf", "Yellow Dwarf", "Blue Giant", "White Dwarf", "Neutron Star", 
				"Brown Dwarf", "Supergiant", "Pulsar", "White Supergiant", "Red Supergiant", 
				"Black Hole", "Rainbow Star", "Void Star", "Crystal Star", "Quantum Star", 
				"Echo Star", "Chrono Star", "Phantom Star", "Prism Star", "Nebula Star", 
				"Graviton Star", "Aurora Star", "Corrupted Star"
			};

			string starWeightsText = "<b>Star Weights:</b>\n";
			for (int i = 0; i < Math.Min(galaxy.starWeights.Count, starTypes.Length); i++)
			{
				starWeightsText += $"{starTypes[i]}: {galaxy.starWeights[i] * 100:F1}%\n"; 
			}

			string fullDescription = $"{stats}";

			var description = fullDescription;
			var name = statsWindow.transform.Find("Background").Find("Name").gameObject;
			var nameText = name.GetComponent<Text>();
			nameText.text = description;
			nameText.color = new Color(0.9f, 0.6f, 0, 1); 
			nameText.fontSize = 10;
			nameText.alignment = TextAnchor.UpperCenter;
			nameText.supportRichText = true;
			name.transform.SetParent(statsWindow.transform.Find("Background").Find("Scroll View").Find("Viewport").Find("Content"));
			name.SetActive(true);

			var nameRect = name.GetComponent<RectTransform>();
			nameRect.anchorMin = new Vector2(0.5f, 1);
			nameRect.anchorMax = new Vector2(0.5f, 1);
			nameRect.offsetMin = new Vector2(-90f, nameText.preferredHeight * -1);
			nameRect.offsetMax = new Vector2(90f, -17);
			nameRect.sizeDelta = new Vector2(180, nameText.preferredHeight + 50);
			statsWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(0, nameText.preferredHeight + 50);
			name.transform.localPosition = new Vector2(name.transform.localPosition.x, ((nameText.preferredHeight / 2) + 30) * -1);

			Vector2 buttonPosition = new Vector2(100, MoveDown*4);
			PowerButton downloadButton = PowerButtons.CreateButton("Download", 
				Resources.Load<Sprite>("ui/Icons/EnvironmentalSteward"),
				"Download Galaxy",
				"Click to download and install this galaxy.",
				buttonPosition,
				ButtonType.Click,
				content.transform,
				new UnityAction(() =>
				{

					DownloadAndInstallGalaxy(galaxy);
				})
			);

			Vector2 starWeightsButtonPosition = new Vector2(136, MoveDown*4);
			PowerButton viewStarWeightsButton = PowerButtons.CreateButton("View Star Weights",
				Resources.Load<Sprite>("Stars/Supergiant"),
				"Star Weights",
				"Click to view the star type distribution.",
				starWeightsButtonPosition,
				ButtonType.Click,
				content.transform,
				new UnityAction(() =>
				{
					OpenStarWeightsWindow(galaxy);
				})
			);
			Windows.ShowWindow(statsWindowName);
		}

		private static void OpenStarWeightsWindow(CustomGalaxy galaxy)
		{
			string starWeightsWindowName = $"star_weights_{galaxy.name}";
			var existingWindow = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{starWeightsWindowName}");

			if (existingWindow != null)
			{
				Windows.ShowWindow(starWeightsWindowName);
				Debug.Log($"Star Weights Window for {galaxy.name} already exists.");
				return;
			}

			var starWeightsWindow = Windows.CreateNewWindow(starWeightsWindowName, "ModernBox");
			var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{starWeightsWindow.name}/Background/Scroll View");
			scrollView.gameObject.SetActive(true);
			var content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{starWeightsWindow.name}/Background/Scroll View/Viewport/Content");

			string[] starTypes = {
				"Red Dwarf", "Yellow Dwarf", "Blue Giant", "White Dwarf", "Neutron Star", 
				"Brown Dwarf", "Supergiant", "Pulsar", "White Supergiant", "Red Supergiant", 
				"Black Hole", "Rainbow Star", "Void Star", "Crystal Star", "Quantum Star", 
				"Echo Star", "Chrono Star", "Phantom Star", "Prism Star", "Nebula Star", 
				"Graviton Star", "Aurora Star", "Corrupted Star"
			};

			string starWeightsText = "<b>Star Weights:</b>\n";
			for (int i = 0; i < Math.Min(galaxy.starWeights.Count, starTypes.Length); i++)
			{
				starWeightsText += $"{starTypes[i]}: {galaxy.starWeights[i] * 100:F1}%\n"; 
			}

			var name = starWeightsWindow.transform.Find("Background").Find("Name").gameObject;
			var nameText = name.GetComponent<Text>();
			nameText.text = starWeightsText;
			nameText.color = new Color(1f, 1f, 1f, 0.8f); 
			nameText.fontSize = 6;
			nameText.alignment = TextAnchor.UpperCenter;
			nameText.supportRichText = true;
			name.transform.SetParent(starWeightsWindow.transform.Find("Background").Find("Scroll View").Find("Viewport").Find("Content"));
			name.SetActive(true);

			var nameRect = name.GetComponent<RectTransform>();
			nameRect.anchorMin = new Vector2(0.5f, 1);
			nameRect.anchorMax = new Vector2(0.5f, 1);
			nameRect.offsetMin = new Vector2(-90f, nameText.preferredHeight * -1);
			nameRect.offsetMax = new Vector2(90f, -17);
			nameRect.sizeDelta = new Vector2(180, nameText.preferredHeight + 50);
			starWeightsWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(0, nameText.preferredHeight + 50);
			name.transform.localPosition = new Vector2(name.transform.localPosition.x, ((nameText.preferredHeight / 2) + 30) * -1);

			Windows.ShowWindow(starWeightsWindowName);
		}

		private static void ShowDownloadSuccessWindow(string galaxyName)
		{

			string successWindowName = $"download_success_{galaxyName}";
			var existingWindow = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{successWindowName}");

			if (existingWindow != null)
			{

				Debug.Log($"Download success window for {galaxyName} already exists.");
				return;
			}

			var successWindow = Windows.CreateNewWindow(successWindowName, "ModernBox");
            var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{successWindow.name}/Background/Scroll View");
            scrollView.gameObject.SetActive(true);
            var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{successWindow.name}/Background/Scroll View/Viewport");
            var viewportRect = viewport.GetComponent<RectTransform>();
            viewportRect.sizeDelta = new Vector2(0, 17);
            content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{successWindow.name}/Background/Scroll View/Viewport/Content");

			var name = successWindow.transform.Find("Background").Find("Name").gameObject;
			var nameText = name.GetComponent<Text>();
			nameText.text = $"Galaxy '{galaxyName}' Successfully Downloaded!";
			nameText.color = new Color(1f, 1f, 1f, 0.8f); 
			nameText.fontSize = 10;
			nameText.alignment = TextAnchor.UpperCenter;
			nameText.supportRichText = true;
			name.transform.SetParent(successWindow.transform.Find("Background").Find("Scroll View").Find("Viewport").Find("Content"));
			name.SetActive(true);

			var nameRect = name.GetComponent<RectTransform>();
			nameRect.anchorMin = new Vector2(0.5f, 1);
			nameRect.anchorMax = new Vector2(0.5f, 1);
			nameRect.offsetMin = new Vector2(-90f, nameText.preferredHeight * -1);
			nameRect.offsetMax = new Vector2(90f, -17);
			nameRect.sizeDelta = new Vector2(180, nameText.preferredHeight + 50);
			successWindow.GetComponent<RectTransform>().sizeDelta = new Vector2(0, nameText.preferredHeight + 50);
			name.transform.localPosition = new Vector2(name.transform.localPosition.x, ((nameText.preferredHeight / 2) + 30) * -1);

			Windows.ShowWindow(successWindowName);
		}

		private static void DownloadAndInstallGalaxy(CustomGalaxy galaxy)
		{
			string galaxiesDirectory = Path.Combine(Application.dataPath, "../galaxies/");
			if (!Directory.Exists(galaxiesDirectory))
			{
				Directory.CreateDirectory(galaxiesDirectory);
			}

			string galaxyFilePath = Path.Combine(galaxiesDirectory, $"{galaxy.name}.gal");
			string galaxyJson = JsonConvert.SerializeObject(galaxy, Formatting.Indented);
			File.WriteAllText(galaxyFilePath, galaxyJson);

			Debug.Log($"Galaxy '{galaxy.name}' downloaded and installed!");

			ShowDownloadSuccessWindow(galaxy.name);
		}

        public static void init()
        {

			List<CustomGalaxy> galaxies = GetCustomGalaxies();

            window = Windows.CreateNewWindow("GalaxyHub", "ModernBox");
            var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View");
            scrollView.gameObject.SetActive(true);
            var viewport = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport");
            var viewportRect = viewport.GetComponent<RectTransform>();
            viewportRect.sizeDelta = new Vector2(0, 17);
            content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport/Content");

            string gold = "#FFD700";
            string Dgold = "#ffae00";
            var description = "Browse and install Custom Galaxies. Join the discord to upload galaxies.";
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

			Debug.Log("Creating buttons for each custom galaxy...");

			int count = 0;
			int xOffset = 0;
			int yOffset = -36;

			foreach (var galaxy in galaxies)
			{
				string galaxyName = galaxy.name;
				string galaxyDescription = galaxy.description;
				string galaxyAuthor = galaxy.author;
				Debug.Log($"Creating button for galaxy: {galaxy.name}");

				Vector2 position = new Vector2(60 + xOffset, MoveDown + yOffset);
				PowerButton galaxyButton = PowerButtons.CreateButton(galaxyName,
					Resources.Load<Sprite>("ui/Icons/Galaxy"),
					galaxyName,
					$"{galaxyDescription}\n<color=gray>By {galaxyAuthor}</color>",
					position,
					ButtonType.Click,
					content.transform,
					new UnityAction(() =>
					{

						OpenGalaxyStatsWindow(galaxy);
					})
				);

				count++;
				xOffset += 36;
				if (count % 5 == 0)
				{
					yOffset -= 36;
					xOffset = 0;
				}

				Debug.Log("Finished creating galaxy button.");
			}
        }
    }
}