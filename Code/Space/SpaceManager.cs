using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq; 
using System; 

namespace M2
{
    public class SpaceManager : MonoBehaviour
    {
        private static GameObject spaceGameObject;
        private static List<GameObject> existingGameObjects = new List<GameObject>();
        private static bool isSpaceEnabled = false;
        public static SpaceManager instance;
		public static string otherfilePath;
		private static MusicBox musicBox;
		private static bool isPopupOpen = false;
		private static int popupStage = 0;
        private void Awake()
        {

                instance = this;
                DontDestroyOnLoad(gameObject); 
				InitializeMusicBox();
        }

		private void InitializeMusicBox()
		{
			musicBox = FindObjectOfType<MusicBox>();
			
			if (musicBox != null)
			{
				Debug.Log($"MusicBox found: {musicBox.gameObject.name}");
			}
			else
			{
				Debug.LogWarning("No MusicBox found in the scene.");
			}
		}

        private void Start()
        {
			ListObjectsWithDiscordTracker();
        ModifyDiscordSetting(true);
            CleanUpModernBoxData(); 


	}

        public static void CleanUpModernBoxData()
        {
            string persistentDataPath = Application.persistentDataPath;
            string spaceBoxPath = Path.Combine(persistentDataPath, "ModernBox");
			otherfilePath = Path.Combine(Application.persistentDataPath, "vals.txt");

        
        if (!File.Exists(otherfilePath))
        {


            
            File.WriteAllText(otherfilePath, "The user had old data from an old modernbox version and it was cleaned. (if your a user reading this, i'm sorry i just didn't want to add a popup saying 'your old modernbox data was deleted because it was invalid now'");
        }
        else
        {
            Debug.Log("Function has already run; skipping.");
			return;
        }
		
            
            if (Directory.Exists(spaceBoxPath))
            {
                try
                {
                    
                    DirectoryInfo dir = new DirectoryInfo(spaceBoxPath);
                    foreach (FileInfo file in dir.GetFiles()) file.Delete();
                    foreach (DirectoryInfo subDir in dir.GetDirectories()) subDir.Delete(true);

                    Debug.Log("Successfully deleted all contents in the 'ModernBox' folder.");
                }
                catch (IOException e)
                {
                    Debug.LogError($"Error while deleting contents of 'ModernBox': {e.Message}");
                }
            }
            else
            {
                Debug.LogWarning("'ModernBox' folder does not exist.");
            
            File.WriteAllText(otherfilePath, "The user had no old data from an old modernbox version. (if your a user reading this, i'm sorry i just didn't want to add a popup saying 'your old modernbox data was deleted because it was invalid now'");
            }

            
            string[] filesToDelete = new string[]
            {
                Path.Combine(persistentDataPath, "activeGalaxy.txt"),
                Path.Combine(persistentDataPath, "JourneyTracker.txt"),
                Path.Combine(persistentDataPath, "visited_planets.txt")
            };

            
            foreach (string filePath in filesToDelete)
            {
                if (File.Exists(filePath))
                {
                    try
                    {
                        File.Delete(filePath);
                        Debug.Log($"Successfully deleted {Path.GetFileName(filePath)}.");
                    }
                    catch (IOException e)
                    {
                        Debug.LogError($"Error while deleting {Path.GetFileName(filePath)}: {e.Message}");
                    }
                }
                else
                {
                    Debug.LogWarning($"{Path.GetFileName(filePath)} does not exist.");
                }
            }
        }
		
    public void ModifyDiscordSetting(bool disable)
    {

        if (typeof(Config).GetField("disableDiscord") != null)
        {

            Config.disableDiscord = disable;
            Debug.Log($"Config.disableDiscord has been set to {disable}");
        }
        else
        {
            Debug.LogError("Config.disableDiscord property not found.");
        }
    }
	
				static void OnGUI()
				{
					if (!isPopupOpen) return;

					GUIStyle popupStyle = new GUIStyle(GUI.skin.window)
					{
						fontSize = 18,
						fontStyle = FontStyle.Bold,
						alignment = TextAnchor.MiddleCenter,
						wordWrap = true
					};

					GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
					{
						fontSize = 14,
						fontStyle = FontStyle.Bold
					};

					Rect popupRect = new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200);
					GUILayout.BeginArea(popupRect, "Incoming Transmission", popupStyle);
					GUILayout.Space(20);

					if (popupStage == 0)
					{
						GUILayout.Label("HELP 1-9-5-7-0", popupStyle);
						if (GUILayout.Button("Continue", buttonStyle))
						{
							popupStage++;
						}
					}
					else if (popupStage == 1)
					{
						GUILayout.Label("The direction it came from wasn't tracked.", popupStyle);
						if (GUILayout.Button("Continue", buttonStyle))
						{
							popupStage++;
						}
					}
					else if (popupStage == 2)
					{
						GUILayout.Label("Looks like we've got work to do.", popupStyle);
						if (GUILayout.Button("OK", buttonStyle))
						{
							popupStage++;
							isPopupOpen = false;
							PlayerPrefs.SetInt("SpaceEnabled", 1);
							PlayerPrefs.Save();
							instance.StartCoroutine(instance.EnableSpaceCoroutine());
						}
					}

					GUILayout.EndArea();
				}

        public static void EnableSpace()
        {
            if (instance == null || isSpaceEnabled) return;
			
			ScanExistingGameObjects();
            foreach (var obj in existingGameObjects)
            {
                if (obj != instance.gameObject && obj != null) 
                    obj.SetActive(false);
            }
			
			
			if (!PlayerPrefs.HasKey("SpaceEnabled"))
			{
				isPopupOpen = true;
			}
			else {
            instance.StartCoroutine(instance.EnableSpaceCoroutine());
			}
        }

        private IEnumerator EnableSpaceCoroutine()
        {

			musicBox.bus_master.setVolume(0.0f);

            if (instance == null)
            {
                Debug.LogError("SpaceManager instance is not initialized.");
                yield break;
            }





            if (spaceGameObject == null)
            {
                spaceGameObject = new GameObject("SpaceGameObject");
                LocalizationManager LocalizationManager = spaceGameObject.AddComponent<LocalizationManager>();

                Camera spaceCamera = spaceGameObject.AddComponent<Camera>();
                spaceCamera.orthographic = true;
                spaceCamera.orthographicSize = 5;
                spaceCamera.clearFlags = CameraClearFlags.SolidColor;
                spaceCamera.backgroundColor = Color.black;

            spaceGameObject.SetActive(true);

                StarManager starManager = spaceGameObject.AddComponent<StarManager>();

                GameObject planetManagerObject = new GameObject("PlanetManager");
                planetManagerObject.AddComponent<PlanetManager>();

            }

            isSpaceEnabled = true;
        }

public static void DisableSpace()
{
    if (instance == null || !isSpaceEnabled)
    {
        Debug.LogWarning("SpaceManager is either not initialized or space is already disabled.");
        return;
    }

    try
    {
        if (spaceGameObject != null)
        {
            Debug.Log($"Destroying spaceGameObject: {spaceGameObject.name}");
            Destroy(spaceGameObject);
            spaceGameObject = null;
        }

        if (existingGameObjects.Count > 0)
        {
            foreach (var obj in existingGameObjects)
            {
                if (obj != instance.gameObject && obj != null) 
                    obj.SetActive(true);
            }
		}

        musicBox.bus_master.setVolume(1.0f);

		GameObject[] allGameObjects = GameObject.FindObjectsOfType<GameObject>();
		foreach (GameObject obj in allGameObjects)
		{
			if (obj.name == "Star" || obj.name == "Nebula")
			{
				Destroy(obj);
			}
		}

        isSpaceEnabled = false;
    }
    catch (Exception ex)
    {
        Debug.LogError($"Exception in DisableSpace: {ex.Message}");
    }
}

public static void GeneratePlanet(string planetName, string planetType, string planetSize)
{
    Debug.Log($"Generating planet: {planetName}");

    SaveManager SaveManager = FindObjectOfType<SaveManager>();
    if (SaveManager == null)
    {
        GameObject[] allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            if (!obj.activeInHierarchy)
            {
                SaveManager = obj.GetComponent<SaveManager>();
                if (SaveManager != null)
                {
                    obj.SetActive(true);
                    break;
                }
            }
        }
    }

    if (SaveManager == null)
    {
        Debug.LogError("SaveManager instance not found.");
        return;
    }

	          string planetCountFilePath = Path.Combine(Application.persistentDataPath, "ModernBox", "PlanetCount.txt");

            int planetCount = 1;
            if (File.Exists(planetCountFilePath))
            {
                string countText = File.ReadAllText(planetCountFilePath);
                if (int.TryParse(countText, out int count))
                {
                    planetCount = count + 1;
                }
            }

            File.WriteAllText(planetCountFilePath, planetCount.ToString());

            Debug.Log($"Planet Count: {planetCount}");

    string currentGalaxyName = "Crabby Way"; 
    string currentPlanetName = PlanetManager.instance.GetCurrentPlanet();

    string spaceBoxPath = Path.Combine(Application.persistentDataPath, "modernbox");
    Debug.Log($"ModernBox Path: {spaceBoxPath}");
    string[] starJsonFiles = Directory.GetFiles(spaceBoxPath, "star.json", SearchOption.AllDirectories);
    Debug.Log($"Found {starJsonFiles.Length} star.json files");

    string saveDirectory = null;
    foreach (string starFile in starJsonFiles)
    {

        if (IsPlanetInStarFile(starFile, currentPlanetName))
        {
            saveDirectory = Path.GetDirectoryName(starFile);
            Debug.Log($"Save directory found: {saveDirectory}");
            break;
        }
    }

    if (saveDirectory == null)
    {
        Debug.LogError($"Planet {currentPlanetName} not found in any star file.");
        return;
    }

    string newSaveDirectory = Path.Combine(saveDirectory, currentPlanetName); 
    SaveManager.saveWorldToDirectory(newSaveDirectory);

string nextPlanetLoadDirectory = null;
string[] allDirectories = Directory.GetDirectories(spaceBoxPath, "*", SearchOption.AllDirectories);

foreach (string directory in allDirectories)
{
    if (Path.GetFileName(directory).Equals(planetName, StringComparison.OrdinalIgnoreCase))
    {
        nextPlanetLoadDirectory = directory;
        Debug.Log($"Found directory for planet {planetName}: {nextPlanetLoadDirectory}");
        PlanetManager.instance.SetCurrentPlanet(planetName);
        DisableSpace();
        SaveManager.loadWorld(nextPlanetLoadDirectory, false);
		PlanetManager.instance.ShowTouchdownGUI(planetType);
        return;
    }
}

if (nextPlanetLoadDirectory == null)
{
    Debug.LogError($"No subfolder named {planetName} found in any directory.");
}

            PlanetManager.instance.SetCurrentPlanet(planetName);

            DisableSpace();
			PlanetGenerator.ChoosePlanetBiomes(planetType);
    
    string[] sizeParts = planetSize.Split('x');
    if (sizeParts.Length == 2 && int.TryParse(sizeParts[0].Trim(), out int sizeX) && int.TryParse(sizeParts[1].Trim(), out int sizeY))
    {
        PlanetGenerator.mapSizeX = sizeX;
        PlanetGenerator.mapSizeY = sizeY;
    }
    else
    {
        Debug.LogError($"Invalid planet size: {planetSize}");
        return;
    }

            MapBox.instance.generateNewMap();
			MapBox.instance.mapStats.name = "test";
			PlanetManager.instance.ShowTouchdownGUI(planetType);
}

        public static bool IsPlanetInStarFile(string starFile, string planetName)
        {
            if (!File.Exists(starFile))
            {
                Debug.LogError($"Star file does not exist: {starFile}");
                return false;
            }

            string starData = File.ReadAllText(starFile);

            try
            {

                Star star = JsonConvert.DeserializeObject<Star>(starData, new StarConverter());

                return star.planetInfo.Any(p => p.name.Equals(planetName, StringComparison.OrdinalIgnoreCase));
            }
            catch (JsonException ex)
            {
                Debug.LogError($"Failed to deserialize star file: {starFile}. Exception: {ex.Message}");
                return false;
            }
        }

private static void ScanExistingGameObjects()
{
    existingGameObjects.Clear();
    UnityEngine.GameObject[] allObjects = UnityEngine.Object.FindObjectsOfType<UnityEngine.GameObject>();

    foreach (var obj in allObjects)
    {
        if (obj != spaceGameObject && obj.activeInHierarchy && obj.GetComponent<DiscordTracker>() == null)
        {
            existingGameObjects.Add(obj);
        }
    }
}

public static void ListObjectsWithDiscordTracker()
{

    DiscordTracker[] discordTrackers = UnityEngine.Object.FindObjectsOfType<DiscordTracker>();

    Debug.Log($"Found {discordTrackers.Length} GameObjects with DiscordTracker:");

    foreach (var tracker in discordTrackers)
    {
        Debug.Log(tracker.gameObject.name);
    }
}

        private void Update()
        {
            if (isSpaceEnabled)
            {
                MoveCamera();
            }
        }

        private void MoveCamera()
        {
            float moveSpeed = 5f;
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");

            if (Camera.main != null)
            {
                Camera.main.transform.Translate(new Vector3(h, v, 0) * moveSpeed * Time.deltaTime);
            }
        }
    }
}