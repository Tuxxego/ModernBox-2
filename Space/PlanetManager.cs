using System;
using UnityEngine;
using System.Collections;
using System.IO;

namespace M2
{
    public class PlanetManager : MonoBehaviour
    {
        public static PlanetManager instance;
        private string currentPlanetName;
        private const string planetFileName = "currentPlanet.txt";
        private string planetFilePath;

        private bool showTouchdownWindow = false;
        private bool showNextWindow = false;
        private bool showFinalWindow = false;

        private string currentWindowTitle;
        private string currentWindowDescription;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
                planetFilePath = Path.Combine(Application.persistentDataPath, "modernbox", planetFileName);
                LoadPlanetName();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            if (string.IsNullOrEmpty(currentPlanetName))
            {
                StartCoroutine(WaitForPlanetName());
            }
        }
		
		public string FindParentStar()
        {
            string galaxyPath = Path.Combine(Application.persistentDataPath, "modernbox");
            string foundStar = null;

            if (!Directory.Exists(galaxyPath))
            {
                Debug.LogError("Galaxy path not found.");
                return null;
            }

            foreach (var galaxyDir in Directory.GetDirectories(galaxyPath))
            {
                string galaxiesFolderPath = Path.Combine(galaxyDir, "Galaxies");

                if (!Directory.Exists(galaxiesFolderPath))
                    continue;

                foreach (var galaxyFolder in Directory.GetDirectories(galaxiesFolderPath))
                {
                    foreach (var starFolder in Directory.GetDirectories(galaxyFolder))
                    {
                        string starJsonPath = Path.Combine(starFolder, "star.json");

                        if (File.Exists(starJsonPath))
                        {
                            string starJsonContent = File.ReadAllText(starJsonPath);

                            if (starJsonContent.Contains(currentPlanetName))
                            {
                                foundStar = Path.GetFileName(starFolder);
                                Debug.Log("Found parent star: " + foundStar);
                                return foundStar;
                            }
                        }
                    }
                }
            }

            if (foundStar == null)
            {
                Debug.LogError("Parent star not found for planet: " + currentPlanetName);
            }

            return foundStar;
        }

		private void OnGUI()
		{
			GUI.color = Color.cyan;
			GUI.backgroundColor = new Color(0.1f, 0.1f, 0.3f);
			GUI.contentColor = Color.green;

			if (showTouchdownWindow)
			{
				Rect windowRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 350, 200);
				GUI.Window(0, windowRect, TouchdownWindow, currentWindowTitle);
			}
			else if (showNextWindow)
			{
				Rect windowRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 350, 200);
				GUI.Window(1, windowRect, NextWindow, "Directive Alpha");
			}
			else if (showFinalWindow)
			{
				Rect windowRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 350, 200);
				GUI.Window(2, windowRect, FinalWindow, "Log Update");
			}
		}

		private void TouchdownWindow(int windowID)
		{
			GUILayout.Label(currentWindowDescription, GetSciFiLabelStyle());
			if (GUILayout.Button("Acknowledge", GetSciFiButtonStyle()))
			{
				showTouchdownWindow = false;
				showNextWindow = true;
			}
		}

		private void NextWindow(int windowID)
		{
			GUILayout.Label("Alert: Ensure planetary safety protocols. Scan for hostile alien organisms and hazardous conditions.", GetSciFiLabelStyle());
			if (GUILayout.Button("Proceed", GetSciFiButtonStyle()))
			{
				showNextWindow = false;
				showFinalWindow = true;
			}
		}

		private void FinalWindow(int windowID)
		{
			GUILayout.Label("System Update: The coordinates and data for your previous location have been archived securely.", GetSciFiLabelStyle());
			if (GUILayout.Button("Close", GetSciFiButtonStyle()))
			{
				showFinalWindow = false;
			}
		}

		public void ShowTouchdownGUI(string planetType)
		{
			AchievementManager.Instance.UnlockAchievement("planetlander");
			currentWindowTitle = "Landing Sequence Complete";
			currentWindowDescription = $"Mission Success: Your vessel has safely touched down on a {planetType}.";
			showTouchdownWindow = true;
		}

		private GUIStyle GetSciFiLabelStyle()
		{
			GUIStyle style = new GUIStyle(GUI.skin.label);
			style.normal.textColor = Color.green;
			style.fontStyle = FontStyle.Bold;
			style.fontSize = 14;
			return style;
		}

		private GUIStyle GetSciFiButtonStyle()
		{
			GUIStyle style = new GUIStyle(GUI.skin.button);
			style.normal.textColor = Color.cyan;
			style.fontStyle = FontStyle.Bold;
			style.fontSize = 12;
			style.hover.textColor = Color.white;
			style.hover.background = Texture2D.grayTexture;
			return style;
		}



        private void LoadPlanetName()
        {
            if (File.Exists(planetFilePath))
            {
                currentPlanetName = File.ReadAllText(planetFilePath);
                Debug.Log("Loaded current planet: " + currentPlanetName);
            }
        }

        private void SavePlanetName(string planetName)
        {
            File.WriteAllText(planetFilePath, planetName);
            currentPlanetName = planetName;
            Debug.Log("Saved current planet: " + currentPlanetName);
        }

        private IEnumerator WaitForPlanetName()
        {
            while (string.IsNullOrEmpty(currentPlanetName))
            {
                yield return new WaitForSeconds(1f);
            }
        }

        public void SetCurrentPlanet(string planetName)
        {
            SavePlanetName(planetName);
        }

        public string GetCurrentPlanet()
        {
            return currentPlanetName;
        }
    }
}
