//=============================BY TUXXEGO====================================
// 
// NOTE FROM TUX: this file is a complete mess i'd avoid changing stuff in here if i were you.
//
//===========================================================================
using System;
using UnityEngine;
using System.Collections.Generic;
using M2;
using System.IO;
using Newtonsoft.Json; 
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections;
using UnityEngine.Networking;

public class StarManager : MonoBehaviour
{
    private List<Star> stars = new List<Star>(); 
    private List<string> favoritesList = new List<string>();
    private string favoritesFilePath;
    private Star hoveredStar;
    private Star selectedStar;
    private Camera mainCamera;
    public float moveSpeed = 15f; 
    public float zoomSpeed = 20f; 
    public float minZoom = 1f; 
    public float maxZoom = 50f; 
    public float starDensity = 0.7f; 
    public float nebulaDensity = 0.05f; 
    public float nebulaSize = 6f; 
    private bool showPlanetWindow = false;
	private bool showParametersWindow = false; 
    private bool showGalaxySelectionWindow = false;
    private bool showFavoritesWindow = false; 
	private bool showCompendiumWindow = false;
    private List<CompendiumEntry> compendiumEntries = new List<CompendiumEntry>
    {
        new CompendiumEntry("Star Types", "There are several types of stars such as Red Dwarfs, Yellow Dwarfs, and Blue Giants."),
        new CompendiumEntry("What will be here", "Stuff on creatures, planets, etc will be here."),
    };
    private Vector2 compendiumScrollPosition;
	private Vector2 sidebarScrollPosition;
    private Vector2 contentScrollPosition;
    private string currentTitle = "Welcome";
    private string currentContent = "Welcome to the Compendium! Here you will find information on various aspects of the universe.";
	private List<string> journeyTracker = new List<string>();
	private bool showJourneyTrackerWindow = false;
	private LocalizationManager localizationManager;
    private string regionName = "Unknown Region";
    private string galaxyName = "Crabby Way";
    private string[] predefinedGalaxies = { "Crabby Way", "Tuxxus", "Krummple", "BlueNight", "Glass", "Centuga", "Dank" };
	private Dictionary<string, int> galaxyRequirements = new Dictionary<string, int>
	{
		{ "Crabby Way", 0 }, 
		{ "Tuxxus", 10 }, 
		{ "Krummple", 20 }, 
		{ "BlueNight", 30 }, 
		{ "Glass", 45 }, 
		{ "Centuga", 55 }, 
		{ "Dank", 85 } 
	};
        private Dictionary<string, int> galaxyStarCounts = new Dictionary<string, int>
        {
            { "Crabby Way", 600 },
            { "Tuxxus", 1200 },
            { "Krummple", 800 },
            { "BlueNight", 2300 },
            { "Glass", 1800 },
			{ "Centuga", 1700 }, 
            { "Dank", 300 }
        };
        private Dictionary<string, int> galaxyDangerRatings = new Dictionary<string, int>
        {
            { "Crabby Way", 1 },
            { "Tuxxus", 3 },
            { "Krummple", 2 },
            { "BlueNight", 4 },
            { "Glass", 4 },
			{ "Centuga", 4 }, 
            { "Dank", 5 }
        };
		public string activeGalaxy
		{
			get
			{
				if (string.IsNullOrEmpty(galaxyName))
				{
					LoadActiveGalaxy(); 
				}
				return galaxyName;
			}
			set
			{
				galaxyName = value;
				SaveActiveGalaxy(galaxyName);
			}
		}
    private string activeGalaxyFilePath;
    private string galaxyDescription = "";
    private AudioSource audioSource;
    private AudioClip backgroundMusic;
    private bool showTutorialPrompt = false;
    private bool showTutorialStep1 = false;
    private bool showTutorialStep2 = false;
    private bool tutorialShown = false;
    private string appDataLocation = Path.Combine(Application.persistentDataPath, "ModernBox");
    private bool isGeneratingStars = false;
    private bool starsGenerationComplete = false;
	private bool showSearchWindow = false;
	private string searchQuery = "";
	private Vector2 scrollPosition;
	private bool showFilterWindow = false;
	private bool applyFilters = false;
	private string selectedStarType = "Any";
	private int minPlanets = 0;
	private int maxPlanets = int.MaxValue;
	private bool useFiltering = false; 
    private static System.Random rand = new System.Random();
    private static string pattern = "psx";
    private static string completedStarName = "";
    private static string[] prefixes = { "Al", "Betel", "Proxi", "Vega", "Anta", "Capel", "Siri", "Tauri", "Poll", "Cen", "Alpha", "Beta", "Delta", "Epsilon", "Gamma", "Cenu" };
    private static string[] syllables = { "al", "bel", "den", "mar", "nus", "zar", "pho", "cos", "tera", "van", "ly", "pe", "xor", "sta", "pro", "lux", "tor", "el", "ris", "zir", "quar", "vix" };
    private static string[] suffixes = { "on", "or", "a", "us", "ae", "um", "is", "us", "i", "an", "es", "ia", "ar", "il", "or", "an", "is" };

    private List<string> randomFacts = new List<string>
    {
        "Krummple and Tuxxus will collide in 6 Billion years.",
        "BlueNight was one of the first Galaxies in the universe?",
        "Space Serpants are real, one was observed in HD-843 in Crabby Way.",
        "I hate the ModernBox save system.",
        "Dank is a relativly new galaxy, odd considering it's apparent abundence of alien intellegence, somethings going on here...",
        "Tuxxus is not gay."
    };

    private void Start()
    {
		    localizationManager = FindObjectOfType<LocalizationManager>();
        activeGalaxyFilePath = Path.Combine(Application.persistentDataPath, "activeGalaxy.txt");
        LoadActiveGalaxy();
        StartCoroutine(InitializeAndGenerateStars());
		LoadJourneyTracker();
    }

    private void LoadActiveGalaxy()
    {
        if (File.Exists(activeGalaxyFilePath))
        {
            galaxyName = File.ReadAllText(activeGalaxyFilePath).Trim();
            Debug.Log($"Loaded active galaxy: {galaxyName}");
        }
        else
        {
            galaxyName = "Crabby Way";
            activeGalaxy = "Crabby Way";
            Debug.LogWarning($"activeGalaxy.txt not found. Defaulting to {galaxyName}");
        }
    }

    private void SaveActiveGalaxy(string galaxy)
    {
        File.WriteAllText(activeGalaxyFilePath, galaxy);
        Debug.Log($"Saved active galaxy: {galaxy}");
    }

    private IEnumerator InitializeAndGenerateStars()
    {
        CreateMainCamera();

        if (mainCamera == null)
        {
            Debug.LogError("Failed to create the main camera.");
            yield break;
        }

        if (File.Exists(activeGalaxyFilePath))
        {
            galaxyName = File.ReadAllText(activeGalaxyFilePath).Trim();
            Debug.Log($"Loaded active galaxy: {galaxyName}");
        }
        else
        {
            galaxyName = "Crabby Way";
            activeGalaxy = "Crabby Way";
            Debug.LogWarning($"activeGalaxy.txt not found. Defaulting to {galaxyName}");
        }

        yield return null;

        string galaxyPath = Path.Combine(appDataLocation, activeGalaxy, "Galaxies", galaxyName);

        if (Directory.Exists(galaxyPath))
        {
            isGeneratingStars = true;
        yield return null;
            GenerateLoadedStars(galaxyPath);
        }
        else
        {
            isGeneratingStars = true;
        yield return null;
            GenerateStars();
        }

        favoritesFilePath = Path.Combine(Application.persistentDataPath, "favorites.txt");
        Debug.Log($"Favorites file path: {favoritesFilePath}");
        LoadFavorites();

            showTutorialPrompt = true;

        SetRandomPlanetIfNeeded();

    }

    private void CreateMainCamera()
    {

        Camera existingCamera = Camera.main;
        if (existingCamera != null)
        {
            mainCamera = existingCamera;
            Debug.Log("Using existing main camera.");
            return;
        }

        GameObject cameraObject = new GameObject("Main Camera");
        mainCamera = cameraObject.AddComponent<Camera>();
        mainCamera.tag = "MainCamera"; 
        mainCamera.orthographic = true;
        mainCamera.orthographicSize = 20; 
        mainCamera.clearFlags = CameraClearFlags.SolidColor;
        mainCamera.backgroundColor = Color.black;
        mainCamera.transform.position = new Vector3(0, 0, -10); 
        Debug.Log("Created a new main camera.");
    }

private void GenerateStars()
{
    ClearStars();
    ClearAllActiveSprites();
    GenerateNebulas();

    if (mainCamera == null)
    {
        Debug.LogError("Main camera is not available for generating stars.");
        return;
    }

    if (!galaxyStarCounts.ContainsKey(activeGalaxy))
    {
        Debug.LogError($"Galaxy '{activeGalaxy}' is not found in the star counts dictionary.");
        return;
    }

    float extraWidth = 100;
    float extraHeight = 100;

    int starCount = galaxyStarCounts[activeGalaxy];
    float cameraWidth = (mainCamera.orthographicSize * mainCamera.aspect * 2) + extraWidth;
    float cameraHeight = (mainCamera.orthographicSize * 2) + extraHeight;

    for (int i = 0; i < starCount; i++)
    {
        GameObject starObject = new GameObject("Star");
        Star star = starObject.AddComponent<Star>();

        SpriteRenderer spriteRenderer = starObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = CreateStarSprite(star);

        if (spriteRenderer.sprite == null)
        {
            Debug.LogError("Failed to create star sprite.");
            continue;
        }

        star.transform.localScale = new Vector3(0.3f, 0.3f, 1);

        Vector3 starPosition;

            if (activeGalaxy == "Glass")
            {

                starPosition = GeneratePositionInSpiralArms(cameraWidth, cameraHeight);
				IsPositionInShatteredArea(starPosition);
            }
            else
            {

                float posX = UnityEngine.Random.Range(-cameraWidth / 2, cameraWidth / 2);
                float posY = UnityEngine.Random.Range(-cameraHeight / 2, cameraHeight / 2);
                starPosition = new Vector3(posX, posY, 0);
            }

        star.transform.position = starPosition;

        star.name = GenerateStarName();
        star.starType = GenerateStarType();
        star.planetCount = UnityEngine.Random.Range(1, 10);

        spriteRenderer.color = GetStarColor(star.starType);

        GeneratePlanetsForStar(star);

        stars.Add(star);
    }

    SaveStarsAndPlanets();
    starsGenerationComplete = true;
    isGeneratingStars = false;
}

private Vector3 GeneratePositionInSpiralArms(float cameraWidth, float cameraHeight)
{
    float radius = UnityEngine.Random.Range(0.5f, cameraWidth / 2);
    float angle = UnityEngine.Random.Range(0, 2 * Mathf.PI);
    float spiralOffset = radius * 0.2f * Mathf.Sin(7 * angle); 

    float posX = radius * Mathf.Cos(angle) + spiralOffset;
    float posY = radius * Mathf.Sin(angle) + spiralOffset;

    return new Vector3(posX, posY, 0);
}

private bool IsPositionInShatteredArea(Vector3 position)
{

    float waveFrequency = 0.1f;
    float waveAmplitude = 50f;

    float wave = waveAmplitude * Mathf.Sin(position.x * waveFrequency);

    bool inExclusionZone = Mathf.Abs(position.y - wave) < 10f; 

    if (inExclusionZone)
    {

    }

    return inExclusionZone;
}

private void GenerateNebulas()
{
    float extraWidth = 100;
    float extraHeight = 100;

    int nebulaCount = Mathf.RoundToInt(nebulaDensity * Mathf.Pow((mainCamera.orthographicSize * 2) + extraWidth, 2));
    float cameraWidth = (mainCamera.orthographicSize * mainCamera.aspect * 2) + extraWidth;
    float cameraHeight = (mainCamera.orthographicSize * 2) + extraHeight;

    for (int i = 0; i < nebulaCount; i++)
    {
        GameObject nebulaObject = new GameObject("Nebula");
        SpriteRenderer spriteRenderer = nebulaObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = CreateNebulaSprite(activeGalaxy);

        if (spriteRenderer.sprite == null)
        {
            Debug.LogError("Failed to create nebula sprite.");
            continue;
        }

        Vector3 nebulaPosition;

        do
        {
            if (activeGalaxy == "Glass")
            {

                nebulaPosition = GeneratePositionInSpiralArms(cameraWidth, cameraHeight);
            }
            else
            {

                float posX = UnityEngine.Random.Range(-cameraWidth / 2, cameraWidth / 2);
                float posY = UnityEngine.Random.Range(-cameraHeight / 2, cameraHeight / 2);
                nebulaPosition = new Vector3(posX, posY, -1);
            }
        }
        while (IsPositionInShatteredArea(nebulaPosition)); 

        nebulaObject.transform.position = nebulaPosition;
        nebulaObject.transform.localScale = new Vector3(nebulaSize, nebulaSize, 1);
    }
}

private Sprite CreateNebulaSprite(string galaxyName)
{
    int width = 256;
    int height = 256;
    Texture2D texture = new Texture2D(width, height, TextureFormat.ARGB32, false);

    Vector2 center = new Vector2(width / 2, height / 2);
    float maxDistance = Vector2.Distance(Vector2.zero, center);

    Color nebulaColor1;
    Color nebulaColor2;

    switch (galaxyName)
    {
        case "Crabby Way":
            nebulaColor1 = new Color(1f, 1f, 1f, 0.4f);
            nebulaColor2 = new Color(1f, 1f, 1f, 0.2f);
            break;
        case "Tuxxus":
            nebulaColor1 = new Color(1f, 0.843f, 0f, 0.5f);
            nebulaColor2 = new Color(1f, 0.843f, 0f, 0.3f);
            break;
        case "Krummple":
            nebulaColor1 = RandomColor(new Color[] { Color.red, Color.green, Color.blue, Color.magenta });
            nebulaColor2 = RandomColor(new Color[] { Color.red, Color.green, Color.blue, Color.magenta });
            nebulaColor1.a = 0.5f;
            nebulaColor2.a = 0.3f;
            break;
        case "BlueNight":
            nebulaColor1 = new Color(0f, 0f, 1f, 0.5f);
            nebulaColor2 = new Color(0f, 0f, 1f, 0.3f);
            break;
        case "Glass":
			nebulaColor1 = new Color(0.5f, 0f, 0.5f, 0.5f); 
			nebulaColor2 = new Color(0.7f, 0f, 0.7f, 0.3f); 
			break;
        case "Centuga":
            nebulaColor1 = new Color(0f, 1f, 1f, 0.5f);
            nebulaColor2 = new Color(0f, 1f, 1f, 0.3f);
            break;
        case "Dank":
            nebulaColor1 = new Color(0.5f, 0f, 0f, 0.5f);
            nebulaColor2 = new Color(0.5f, 0f, 0f, 0.3f);
            break;
        default:
            nebulaColor1 = new Color(1f, 1f, 1f, 0.4f);
            nebulaColor2 = new Color(1f, 1f, 1f, 0.2f);
            break;
    }

    float scale = 0.1f;
    float intensity = 0.6f;

    for (int y = 0; y < height; y++)
    {
        for (int x = 0; x < width; x++)
        {
            Vector2 position = new Vector2(x, y);
            float distanceFromCenter = Vector2.Distance(position, center);
            float normalizedDistance = distanceFromCenter / maxDistance;

            float perlinX = x * scale;
            float perlinY = y * scale;
            float noise = Mathf.PerlinNoise(perlinX, perlinY);

            float edgeAlpha = Mathf.Clamp01(1f - normalizedDistance);
            edgeAlpha *= Mathf.Lerp(1f, 0f, normalizedDistance * 2f); 

            float radialEffect = Mathf.Clamp01(1f - normalizedDistance);
            Color nebulaColor = Color.Lerp(nebulaColor1, nebulaColor2, noise * intensity * radialEffect);
            nebulaColor.a *= edgeAlpha;

            texture.SetPixel(x, y, nebulaColor);
        }
    }

    texture.Apply();

    return Sprite.Create(texture, new Rect(0, 0, width, height), new Vector2(0.5f, 0.5f));
}

private Color RandomColor(Color[] colors)
{
    return colors[UnityEngine.Random.Range(0, colors.Length)];
}

private void GeneratePlanetsForStar(Star star)
{
    star.planetInfo = new PlanetInfo[star.planetCount];
    string starSystemName = star.name;
    string starType = star.starType; 

    for (int i = 0; i < star.planetCount; i++)
    {
        string planetType = GetPlanetTypeBasedOnStar(starType); 

        
        int sizeX = UnityEngine.Random.Range(1, 25);
        int sizeY = UnityEngine.Random.Range(1, 25);
        string size = $"{sizeX} x {sizeY}";

        
        bool hasFauna = UnityEngine.Random.value > 0.5f; 

        star.planetInfo[i] = new PlanetInfo
        {
            name = $"{starSystemName} {ToRomanNumeral(i + 1)}",
            description = GenerateNormalDescription(starType, planetType),
            resources = GenerateResources(),
            dangerRating = UnityEngine.Random.Range(1, 10),
            dangerDescription = GenerateDangerDescription(starType, planetType),
            planetType = planetType,
            size = size, 
            hasFauna = hasFauna 
        };
    }
}


private string GetPlanetTypeBasedOnStar(string starType)
{
    switch (starType)
    {
        case "Red Dwarf":
            return GetRandomPlanetType(new[] { "Desert World", "Icy", "Swamp World", "Mushroom World" });

        case "Yellow Dwarf":
            return GetRandomPlanetType(new[] { "Desert World", "Oceanic", "Gas Giant (Habitable)", "Lemon World" });

        case "Blue Giant":
            return GetRandomPlanetType(new[] { "Gas Giant", "Crystal World", "Lava World", "Wasteland World" });

        case "White Dwarf":
            return GetRandomPlanetType(new[] { "Desert World", "Icy", "Mechanical World", "Corrupted World" });

        case "Neutron Star":
            return GetRandomPlanetType(new[] { "Desert World", "Gas Giant", "Jungle World", "Corrupted World" });

        case "Brown Dwarf":
            return GetRandomPlanetType(new[] { "Icy", "Gas Giant", "Swamp World", "Mushroom World" });

        case "Supergiant":
            return GetRandomPlanetType(new[] { "Gas Giant", "Crystal World", "Lava World", "Wasteland World" });

        case "Pulsar":
            return GetRandomPlanetType(new[] { "Desert World", "Swamp World", "Jungle World", "Corrupted World" });

        case "White Supergiant":
            return GetRandomPlanetType(new[] { "Gas Giant", "Crystal World", "Mechanical World", "Wasteland World" });

        case "Red Supergiant":
            return GetRandomPlanetType(new[] { "Desert World", "Oceanic", "Lava World", "Mushroom World" });

        case "Black Hole":
            return GetRandomPlanetType(new[] { "Desert World", "Icy", "Jungle World", "Corrupted World" });

        case "Rainbow Star":
            return GetRandomPlanetType(new[] { "Crystal World", "Oceanic", "Jungle World", "Lemon World" });

        case "Void Star":
            return GetRandomPlanetType(new[] { "Icy", "Gas Giant", "Lava World", "Corrupted World" });

        case "Crystal Star":
            return GetRandomPlanetType(new[] { "Crystal World", "Mechanical World", "Oceanic", "Lemon World" });

        case "Quantum Star":
            return GetRandomPlanetType(new[] { "Desert World", "Gas Giant", "Swamp World", "Wasteland World" });

        case "Echo Star":
            return GetRandomPlanetType(new[] { "Jungle World", "Oceanic", "Mechanical World", "Lemon World" });

        case "Chrono Star":
            return GetRandomPlanetType(new[] { "Icy", "Desert World", "Crystal World", "Corrupted World" });

        case "Phantom Star":
            return GetRandomPlanetType(new[] { "Swamp World", "Jungle World", "Lava World", "Mushroom World" });

        case "Prism Star":
            return GetRandomPlanetType(new[] { "Oceanic", "Crystal World", "Gas Giant", "Lemon World" });

        case "Nebula Star":
            return GetRandomPlanetType(new[] { "Gas Giant (Habitable)", "Swamp World", "Icy", "Mushroom World" });

        case "Graviton Star":
            return GetRandomPlanetType(new[] { "Lava World", "Crystal World", "Mechanical World", "Wasteland World" });

        case "Aurora Star":
            return GetRandomPlanetType(new[] { "Oceanic", "Jungle World", "Icy", "Lemon World" });

        default:
            return GetRandomPlanetType(); 
    }
}

private string GetRandomPlanetType(string[] possibleTypes = null)
{
    if (possibleTypes == null)
    {
        possibleTypes = new[] { "Desert World", "Gas Giant", "Oceanic", "Icy", "Crystal World", "Swamp World", "Lava World", "Gas Giant (Habitable)", "Mechanical World", "Jungle World", "Corrupted World", "Lemon World", "Mushroom World", "Wasteland World" };
    }
    int index = UnityEngine.Random.Range(0, possibleTypes.Length);
    return possibleTypes[index];
}

private Sprite CreateStarSprite(Star star)
{
    int textureSize = 64; 
    Texture2D texture = new Texture2D(textureSize, textureSize);
    Color[] pixels = new Color[textureSize * textureSize];

    Color starColor = GetStarColor(star.starType);

    Vector2 center = new Vector2(textureSize / 2, textureSize / 2);
    float radius = textureSize / 2f;
    float shineRadius = radius * 0.6f; 
    float streakLength = radius * 0.5f; 

    for (int y = 0; y < textureSize; y++)
    {
        for (int x = 0; x < textureSize; x++)
        {
            Vector2 pixelPos = new Vector2(x, y);
            float distance = Vector2.Distance(center, pixelPos);

            float alpha = Mathf.Clamp01((radius - distance) / radius);

            float shine = Mathf.Clamp01((shineRadius - distance) / shineRadius);

            Vector2 direction = (pixelPos - center).normalized;
            float streak = Mathf.Clamp01(Mathf.Abs(Vector2.Dot(direction, Vector2.right)) * streakLength / radius);

            pixels[y * textureSize + x] = starColor * (alpha + shine * 0.5f + streak * 0.2f);
        }
    }

    texture.SetPixels(pixels);
    texture.Apply();

    return Sprite.Create(texture, new Rect(0, 0, textureSize, textureSize), new Vector2(0.5f, 0.5f));
}

private Color GetStarColor(string starType)
{
    switch (starType)
    {
        case "Red Dwarf":
            return Color.red;

        case "Yellow Dwarf":
            return Color.yellow;

        case "Blue Giant":
            return Color.blue;

        case "White Dwarf":
            return Color.white;

        case "Neutron Star":
            return Color.cyan;

        case "Brown Dwarf":
            return new Color(139f / 255f, 69f / 255f, 19f / 255f); 

        case "Supergiant":
            return new Color(255f / 255f, 165f / 255f, 0f / 255f); 

        case "Pulsar":
            return new Color(75f / 255f, 0f / 255f, 130f / 255f); 

        case "White Supergiant":
            return new Color(240f / 255f, 248f / 255f, 255f / 255f); 

        case "Red Supergiant":
            return new Color(255f / 255f, 99f / 255f, 71f / 255f); 

        case "Black Hole":
            return new Color(255f / 255f, 255f / 255f, 255f / 255f, 0.0f); 

        case "Rainbow Star":
            return Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time, 1));

        case "Void Star":
            return Color.black;

        case "Crystal Star":
            return new Color(173f / 255f, 216f / 255f, 230f / 255f); 

        case "Quantum Star":
            return new Color(127f / 255f, 255f / 255f, 212f / 255f); 

        case "Echo Star":
            return new Color(147f / 255f, 112f / 255f, 219f / 255f); 

        case "Chrono Star":
            return new Color(218f / 255f, 112f / 255f, 214f / 255f); 

        case "Phantom Star":
            return new Color(255f / 255f, 255f / 255f, 255f / 255f, 0.3f);

        case "Prism Star":
            return Color.Lerp(Color.red, Color.blue, Mathf.PingPong(Time.time * 2, 1)); 

        case "Nebula Star":
            return new Color(238f / 255f, 130f / 255f, 238f / 255f); 

        case "Graviton Star":
            return new Color(105f / 255f, 105f / 255f, 105f / 255f); 

        case "Aurora Star":
            return new Color(72f / 255f, 61f / 255f, 139f / 255f); 

        default:
            return Color.white;
    }
}

private void SaveStarsAndPlanets()
{
    string savePath = Path.Combine(appDataLocation, activeGalaxy, "Galaxies", galaxyName);

    Directory.CreateDirectory(savePath);

    JsonSerializerSettings settings = new JsonSerializerSettings();
    settings.Converters.Add(new Vector3Converter());
    settings.Converters.Add(new GameObjectConverter());

    foreach (Star star in stars)
    {
        string starPath = Path.Combine(savePath, star.name);
        Directory.CreateDirectory(starPath);

        string starData = JsonConvert.SerializeObject(star, settings);
        File.WriteAllText(Path.Combine(starPath, "star.json"), starData);

    }
}

private void LoadStarsAndPlanets(string path)
{
    if (!Directory.Exists(path))
    {
        Debug.LogError($"Directory does not exist: {path}");
        return;
    }

    string[] starFolders = Directory.GetDirectories(path);
    foreach (string starFolder in starFolders)
    {
        string starFilePath = Path.Combine(starFolder, "star.json");
        if (File.Exists(starFilePath))
        {
            string starData = File.ReadAllText(starFilePath);

            Star star = JsonConvert.DeserializeObject<Star>(starData, new StarConverter());
            stars.Add(star);

        }
    }
}

private void GenerateLoadedStars(string path)
{
	            ClearStars();
		            ClearAllActiveSprites();
        GenerateNebulas();

    Debug.Log("Starting to load stars from path: " + path);

        LoadStarsAndPlanets(path);
        Debug.Log("Successfully loaded stars and planets from path: " + path);

    foreach (Star starData in stars)
    {
        try
        {

            GameObject starObject = new GameObject("Star");
            Star starComponent = starObject.AddComponent<Star>();

            starComponent.name = starData.name;
            starComponent.starType = starData.starType;
            starComponent.planetCount = starData.planetCount;
            starComponent.selectedPlanet = starData.selectedPlanet;
            starComponent.planetInfo = starData.planetInfo ?? new PlanetInfo[0]; 

            SpriteRenderer spriteRenderer = starObject.AddComponent<SpriteRenderer>();

            spriteRenderer.sprite = CreateStarSprite(starData); 

            if (spriteRenderer.sprite != null)
            {

            }
            else
            {
                Debug.LogWarning("Failed to create or assign sprite.");
            }
            spriteRenderer.color = GetStarColor(starData.starType);

            starObject.transform.position = starData.transform.position;

        }
        catch (InvalidCastException castEx)
        {
            Debug.LogError("Invalid cast exception while generating star: " + starData.name + ". Exception: " + castEx.Message);
            Debug.LogError($"Star data type: {starData.GetType().FullName}");
            Debug.LogError($"Star position: {starData.transform.position}");
        }
        catch (Exception ex)
        {
            Debug.LogError("Failed to generate star: " + starData.name + ". Exception: " + ex.Message);
        }
    }

        starsGenerationComplete = true;
        isGeneratingStars = false;

    Debug.Log("Finished generating all stars.");
}

    private void SetRandomPlanetIfNeeded()
    {
        string currentPlanet = PlanetManager.instance.GetCurrentPlanet();
        if (string.IsNullOrEmpty(currentPlanet))
        {

            if (stars.Count > 0)
            {
                Star randomStar = stars[UnityEngine.Random.Range(0, stars.Count)];
                if (randomStar.planetInfo.Length > 0)
                {
                    PlanetInfo randomPlanet = randomStar.planetInfo[UnityEngine.Random.Range(0, randomStar.planetInfo.Length)];
                    PlanetManager.instance.SetCurrentPlanet(randomPlanet.name);
                }
            }
        }
    }

private void OnGUI()
{
    BottomBar();

    if (hoveredStar != null)
    {
        Vector2 mousePos = Event.current.mousePosition;

        string starInfo = $"{localizationManager.Localize("star_info_name")}: {hoveredStar.name}\n" +
                          $"{localizationManager.Localize("star_info_type")}: {hoveredStar.starType}\n" +
                          $"{localizationManager.Localize("star_info_planets")}: {hoveredStar.planetCount}";

        Vector2 textSize = GUI.skin.box.CalcSize(new GUIContent(starInfo));
        GUI.Box(new Rect(mousePos.x + 10, mousePos.y + 10, textSize.x + 10, textSize.y + 10), starInfo);

        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            selectedStar = hoveredStar;
            AddToJourneyTracker(selectedStar);
            showPlanetWindow = true;
            Event.current.Use();
        }
    }

    if (showJourneyTrackerWindow)
    {
        Rect journeyTrackerWindowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 400, 400);
        GUI.Window(12, journeyTrackerWindowRect, JourneyTrackerWindow, localizationManager.Localize("journey_tracker"));
    }

	if (selectedStar != null)
	{
		Rect starInfoWindowRect = new Rect(10, 10, 350, 450); 
		GUI.Window(0, starInfoWindowRect, StarInfoWindow, 
			new GUIContent(localizationManager.Localize("star_information"), "Details about the selected star"));
	}
	
    if (showPlanetWindow && selectedStar != null)
    {
        Rect planetInfoWindowRect = new Rect(360, 10, 300, 400);
        GUI.Window(1, planetInfoWindowRect, PlanetInfoWindow, localizationManager.Localize("planet_information"));
    }

    if (showParametersWindow)
    {
        Rect parametersWindowRect = new Rect(450, 100, 300, 200);
        GUILayout.Window(1, parametersWindowRect, PlanetParametersWindow, localizationManager.Localize("parameters"));
    }
    
    if (showTutorialPrompt)
    {
        GUI.Window(2, new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200), TutorialPromptWindow, localizationManager.Localize("tutorial"));
    }

    if (showTutorialStep1)
    {
        GUI.Window(3, new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200), TutorialStep1Window, localizationManager.Localize("tutorial_step1"));
    }

    if (showTutorialStep2)
    {
        GUI.Window(4, new Rect(Screen.width / 2 - 150, Screen.height / 2 - 100, 300, 200), TutorialStep2Window, localizationManager.Localize("tutorial_step2"));
    }

    Rect smallWindowRect = new Rect(Screen.width - 160, 10, 150, 150);
    GUI.Window(5, smallWindowRect, SmallWindow, localizationManager.Localize("options"));


if (showGalaxySelectionWindow) 
{
    Rect galaxyWindowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 300) / 2, 400, 400);
    Rect descriptionWindowRect = new Rect(galaxyWindowRect.x + galaxyWindowRect.width + 20, galaxyWindowRect.y, 300, 400);
    Rect infoWindowRect = new Rect(galaxyWindowRect.x - 320, galaxyWindowRect.y, 300, 400);

    GUI.Window(6, galaxyWindowRect, GalaxySelectionWindow, new GUIContent(localizationManager.Localize("select_galaxy"), "Browse galaxies"));
    GUI.Window(7, descriptionWindowRect, GalaxyDescriptionWindow, new GUIContent(localizationManager.Localize("galaxy_description"), "Galaxy details"));
    GUI.Window(8, infoWindowRect, GalaxyInfoWindow, new GUIContent(localizationManager.Localize("galaxy_info"), "Galaxy stats"));

    Rect closeButtonRect = new Rect(galaxyWindowRect.x + (galaxyWindowRect.width / 2) - 50, galaxyWindowRect.y + galaxyWindowRect.height + 15, 100, 35);

    if (GUI.Button(closeButtonRect, localizationManager.Localize("close")))
    {
        showGalaxySelectionWindow = false;
    }
}



    if (showFavoritesWindow)
    {
        Rect favoritesWindowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 400, 400);
        GUI.Window(8, favoritesWindowRect, FavoritesWindow, localizationManager.Localize("favorite_stars"));
    }

	
	if (isGeneratingStars)
	{
		GUI.Window(
			2, 
			new Rect(Screen.width / 2 - 350, Screen.height / 2 - 250, 700, 500), 
			StarLoadingWindow, 
			localizationManager.Localize("loading")
		);
	}

    if (showSearchWindow)
    {
        Rect searchWindowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 500) / 2, 400, 500);
        GUI.Window(9, searchWindowRect, SearchWindow, localizationManager.Localize("search_stars"));
    }

    if (showFilterWindow)
    {
        Rect filterWindowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 400, 400);
        GUI.Window(10, filterWindowRect, FilterWindow, localizationManager.Localize("filter_options"));
    }

    if (showCompendiumWindow)
    {
        Rect compendiumWindowRect = new Rect((Screen.width - 400) / 2, (Screen.height - 400) / 2, 400, 400);
        GUI.Window(11, compendiumWindowRect, CompendiumWindow, localizationManager.Localize("compendium"));
    }


GUIStyle galaxyInfoStyle = new GUIStyle(GUI.skin.label);
galaxyInfoStyle.fontSize = 16; 
galaxyInfoStyle.fontStyle = FontStyle.Italic;
galaxyInfoStyle.normal.textColor = new Color(0.8f, 0.8f, 0.9f); 
galaxyInfoStyle.alignment = TextAnchor.MiddleLeft;

GUIStyle galaxyNameStyle = new GUIStyle(GUI.skin.label);
galaxyNameStyle.fontSize = 30; 
galaxyNameStyle.fontStyle = FontStyle.Bold;
galaxyNameStyle.normal.textColor = new Color(1f, 0.84f, 0f); 
galaxyNameStyle.alignment = TextAnchor.MiddleLeft;


float blockWidth = 600f;
float blockHeight = 50f;
float blockX = 10f; 
float blockY = Screen.height - 10f; 


float textSpacing = 20f; 
float infoTextHeight = 20f; 
float galaxyNameHeight = 30f; 


GUI.Label(new Rect(blockX, blockY - galaxyNameHeight - textSpacing, blockWidth, infoTextHeight), "You are currently in", galaxyInfoStyle);
GUI.Label(new Rect(blockX, blockY - galaxyNameHeight, blockWidth, galaxyNameHeight), galaxyName, galaxyNameStyle);

}


private void SearchWindow(int windowID)
{
    GUILayout.BeginVertical();

    if (GUILayout.Button(localizationManager.Localize("filter")))
    {
        showFilterWindow = true;
    }

    GUILayout.Label(localizationManager.Localize("search_stars"));
    searchQuery = GUILayout.TextField(searchQuery);

    applyFilters = GUILayout.Toggle(applyFilters, localizationManager.Localize("apply_filters_label"));

    scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(380), GUILayout.Height(300));

    bool selectionMade = false;

    foreach (Star star in stars)
    {
        bool matchesSearchQuery = string.IsNullOrEmpty(searchQuery) || star.name.StartsWith(searchQuery, StringComparison.OrdinalIgnoreCase);
        bool matchesFilters = !applyFilters || 
            (star.starType == selectedStarType || selectedStarType == "Any") &&
            star.planetCount >= minPlanets && star.planetCount <= maxPlanets;

        if (matchesSearchQuery && matchesFilters)
        {
            if (GUILayout.Button(star.name))
            {
                selectedStar = star;
                MoveCameraToStar(star);
                showSearchWindow = false; 
                selectionMade = true;
                break; 
            }
        }
    }

    if (!selectionMade && !string.IsNullOrEmpty(searchQuery))
    {
        GUILayout.Label(localizationManager.Localize("no_results_found"));
    }

    GUILayout.EndScrollView();

    if (GUILayout.Button(localizationManager.Localize("close")))
    {
        showSearchWindow = false;
    }

    GUILayout.EndVertical();
}

private void FilterWindow(int windowID)
{
    GUILayout.BeginVertical("box");

    GUILayout.Label("Filter Options:");

    string[] starTypes = { 
        "Any", 
        "Red Dwarf", 
        "Yellow Dwarf", 
        "Blue Giant", 
        "White Dwarf", 
        "Neutron Star", 
        "Brown Dwarf", 
        "Supergiant", 
        "Pulsar", 
        "White Supergiant", 
        "Red Supergiant", 
        "Black Hole" 
    };
    int selectedIndex = Array.IndexOf(starTypes, selectedStarType);
    selectedIndex = GUILayout.SelectionGrid(selectedIndex, starTypes, starTypes.Length / 2);

    selectedStarType = starTypes[selectedIndex];

    GUILayout.Label("Minimum Number of Planets:");
    int.TryParse(GUILayout.TextField(minPlanets.ToString()), out minPlanets);

    GUILayout.Label("Maximum Number of Planets:");
    int.TryParse(GUILayout.TextField(maxPlanets.ToString()), out maxPlanets);

    if (GUILayout.Button(localizationManager.Localize("apply")))
    {
        showFilterWindow = false;
    }
    if (GUILayout.Button(localizationManager.Localize("cancel")))
    {
        showFilterWindow = false;
    }

    GUILayout.EndVertical();
}

private void StarLoadingWindow(int windowID)
{
    if (localizationManager == null)
    {
        Debug.LogError("LocalizationManager is not initialized!");
        GUILayout.Label("LocalizationManager is not available.");
        return;
    }

    string loadingMessage = localizationManager.Localize("stars_loading_message");

    if (randomFacts == null || randomFacts.Count == 0)
    {
        string errorMessage = (randomFacts == null) ? "randomFacts list is not initialized!" : "randomFacts list is empty!";
        Debug.LogWarning(errorMessage);
        GUILayout.Label("No random facts available.");
        return;
    }

    string randomFact = randomFacts[UnityEngine.Random.Range(0, randomFacts.Count)];

    
    GUIStyle titleStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 50, 
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        wordWrap = true,
        normal = { textColor = Color.cyan }
    };

    
    GUIStyle subtitleStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 36, 
        fontStyle = FontStyle.Italic,
        alignment = TextAnchor.MiddleCenter,
        wordWrap = true,
        normal = { textColor = Color.yellow }
    };

    
    GUIStyle italicStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 24, 
        fontStyle = FontStyle.Italic,
        alignment = TextAnchor.UpperCenter,
        wordWrap = true
    };

    
    GUILayout.BeginVertical();

    GUILayout.Space(10);
    GUILayout.Label("ModernBox", titleStyle);  
    GUILayout.Label("SPACE AGE", subtitleStyle);  

    GUILayout.Space(30);  
    GUILayout.Label(loadingMessage, italicStyle);  

    GUILayout.Space(15);
    GUILayout.Label(localizationManager.Localize("did_you_know"), italicStyle);

    
    GUILayout.BeginScrollView(Vector2.zero, GUILayout.Height(120));
    GUILayout.Label($"*{randomFact}*", italicStyle);
    GUILayout.EndScrollView();

    GUILayout.EndVertical();
}



    private void TutorialPromptWindow(int windowID)
    {
        GUILayout.Label(localizationManager.Localize("tutorial"));

        if (GUILayout.Button(localizationManager.Localize("yes")))
        {
            showTutorialPrompt = false;
            showTutorialStep1 = true;
        }

        if (GUILayout.Button(localizationManager.Localize("no")))
        {
            showTutorialPrompt = false;
            tutorialShown = true;
        }
    }

    private void TutorialStep1Window(int windowID)
    {
        GUILayout.Label(localizationManager.Localize("tutorial1"));

        if (GUILayout.Button(localizationManager.Localize("next")))
        {
            showTutorialStep1 = false;
            showTutorialStep2 = true;
        }

        if (GUILayout.Button(localizationManager.Localize("skip")))
        {
            showTutorialStep1 = false;
            tutorialShown = true;
        }
    }

    private void TutorialStep2Window(int windowID)
    {
        GUILayout.Label(localizationManager.Localize("tutorial2"));

        if (GUILayout.Button(localizationManager.Localize("finish")))
        {
            showTutorialStep2 = false;
            tutorialShown = true;
        }

        if (GUILayout.Button(localizationManager.Localize("skip")))
        {
            showTutorialStep2 = false;
            tutorialShown = true;
        }
    }

	private void SmallWindow(int windowID)
	{
		
		GUIStyle titleStyle = new GUIStyle(GUI.skin.label)
		{
			fontSize = 20,
			fontStyle = FontStyle.Bold,
			alignment = TextAnchor.MiddleCenter,
			wordWrap = true,
			normal = { textColor = new Color(0.4f, 0.9f, 1.0f) } 
		};

		GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
		{
			fontSize = 14,
			fontStyle = FontStyle.Bold,
			alignment = TextAnchor.MiddleCenter,
			normal = { background = MakeTex(2, 2, new Color(0f, 0.2f, 0.2f, 0.7f)) }, 
			hover = { background = MakeTex(2, 2, new Color(0.1f, 0.5f, 0.5f, 1f)) } 
		};

		


		
		if (GUILayout.Button(localizationManager.Localize("galaxy_select"), buttonStyle))
		{
			showGalaxySelectionWindow = true;
		}

		
		if (GUILayout.Button(localizationManager.Localize("favorite_systems"), buttonStyle))
		{
			showFavoritesWindow = true;
		}

		
		if (GUILayout.Button(localizationManager.Localize("search_stars"), buttonStyle))
		{
			showSearchWindow = true;
		}

		
		if (GUILayout.Button(localizationManager.Localize("exit"), buttonStyle))
		{
			Debug.Log("Exiting Starmap");
			SpaceManager.DisableSpace(); 
		}
	}

    private void FavoritesWindow(int windowID)
    {
        List<string> favoriteStarNames = LoadFavorites();
        List<Star> allStars = GetAllStarGameObjects();

        Debug.Log("Loading favorites window.");

        foreach (string favoriteName in favoriteStarNames)
        {
            Star star = allStars.Find(s => s.name.Equals(favoriteName, StringComparison.OrdinalIgnoreCase));

            if (star != null)
            {
                if (GUILayout.Button(star.name))
                {
                    Debug.Log($"Favorite star selected: {star.name}");
                    selectedStar = star;
                    showPlanetWindow = false;
                    showFavoritesWindow = false;
                    MoveCameraToStar(star);
                    break;
                }
            }
            else
            {
                Debug.Log($"Star not found: {favoriteName}");
            }
        }

        if (GUILayout.Button(localizationManager.Localize("close")))
        {
            Debug.Log("Closing favorites window.");
            showFavoritesWindow = false;
        }
    }

    private void MoveCameraToStar(Star star)
    {
        Vector3 starPosition = star.transform.position;
        mainCamera.transform.position = new Vector3(starPosition.x, starPosition.y, mainCamera.transform.position.z);
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize * 0.5f, minZoom, maxZoom); 

        Debug.Log($"Moved camera to star: {star.name}, Position: {starPosition}");
    }

    private void SaveFavorites()
    {
        File.WriteAllLines(favoritesFilePath, favoritesList);
        Debug.Log($"Saved favorites: {string.Join(", ", favoritesList)}");
    }

    public void AddFavorite(string starName)
    {
        if (!favoritesList.Contains(starName))
        {
            favoritesList.Add(starName);
            SaveFavorites();
            Debug.Log($"Added to favorites: {starName}");
        }
        else
        {
            Debug.Log($"{starName} is already in favorites.");
        }
    }

    public void RemoveFavorite(string starName)
    {
        if (favoritesList.Contains(starName))
        {
            favoritesList.Remove(starName);
            SaveFavorites();
            Debug.Log($"Removed from favorites: {starName}");
        }
        else
        {
            Debug.Log($"{starName} is not in favorites.");
        }
    }

private List<Star> GetAllStarGameObjects()
{
    List<Star> stars = GameObject.FindObjectsOfType<Star>().ToList();
    Debug.Log($"Found {stars.Count} stars in the scene.");
    return stars;
}

private Star FindStarByName(string starName)
{

    List<Star> stars = GetAllStarGameObjects();

    Star foundStar = stars.FirstOrDefault(star => star.name == starName);

    if (foundStar == null)
    {
        Debug.LogWarning($"Star with name {starName} not found.");
    }

    return foundStar;
}

private List<string> LoadFavorites()
{
    List<string> favorites = new List<string>();
    string path = Path.Combine(Application.persistentDataPath, "favorites.txt");

    if (File.Exists(path))
    {
        string[] lines = File.ReadAllLines(path);
        favorites.AddRange(lines.Select(line => line.Trim()));
        Debug.Log($"Loaded favorites from file: {string.Join(", ", favorites)}");
    }
    else
    {
        Debug.Log("Favorites file does not exist.");
    }

    return favorites;
}

    private void CompendiumWindow(int windowID)
    {

        Rect sidebarRect = new Rect(0, 0, 150, 500);
        Rect contentRect = new Rect(150, 0, 450, 500);

        GUILayout.BeginArea(sidebarRect, GUI.skin.box);
        sidebarScrollPosition = GUILayout.BeginScrollView(sidebarScrollPosition);

        foreach (CompendiumEntry entry in compendiumEntries)
        {
            if (GUILayout.Button(entry.Title))
            {
                currentTitle = entry.Title;
                currentContent = entry.Content;
            }
        }

        GUILayout.EndScrollView();
        GUILayout.EndArea();

        GUILayout.BeginArea(contentRect, GUI.skin.box);
        GUILayout.Label(currentTitle, new GUIStyle(GUI.skin.label) { fontStyle = FontStyle.Bold, fontSize = 16 });
        contentScrollPosition = GUILayout.BeginScrollView(contentScrollPosition);
        GUILayout.Label(currentContent);
        GUILayout.EndScrollView();
        GUILayout.EndArea();
    }

private int planetsVisited = 0; 

private void BottomBar()
{
    string planetCountFilePath = Path.Combine(Application.persistentDataPath, "ModernBox", "PlanetCount.txt");

    if (File.Exists(planetCountFilePath))
    {
        string fileContents = File.ReadAllText(planetCountFilePath);
        if (int.TryParse(fileContents, out int visitedCount))
        {
            planetsVisited = visitedCount;
        }
        else
        {
            Debug.LogError("Failed to parse planetsVisited from PlanetCount.txt");
            planetsVisited = 0;
        }
    }
    else
    {
        Debug.LogWarning("PlanetCount.txt not found, initializing planetsVisited to 0.");
        planetsVisited = 0;
    }


    GUIStyle barStyle = new GUIStyle();
    barStyle.normal.background = MakeGradientTexture(Screen.width, 50, new Color(0.15f, 0.15f, 0.2f, 0.8f), new Color(0f, 0f, 0.2f, 0.9f));
    GUI.Box(new Rect(0, Screen.height - 60, Screen.width, 60), GUIContent.none, barStyle);


    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button);
    buttonStyle.fontSize = 14;
    buttonStyle.fontStyle = FontStyle.Bold;
    buttonStyle.alignment = TextAnchor.MiddleCenter;
    buttonStyle.normal.textColor = Color.cyan;
    buttonStyle.hover.textColor = Color.white;
    buttonStyle.normal.background = MakeTex(2, 2, new Color(0f, 0.5f, 0.5f, 0.6f));
    buttonStyle.hover.background = MakeTex(2, 2, new Color(0.2f, 0.7f, 0.8f, 0.8f));

    float buttonWidth = 120f;
    float buttonHeight = 40f;
    float spacing = 15f;

    float compendiumX = Screen.width - buttonWidth - 20f;
    float journeyTrackerX = compendiumX - (buttonWidth + spacing);
    float trackStarX = journeyTrackerX - (buttonWidth + spacing);
    float websiteButtonX = trackStarX - (buttonWidth + spacing);

    if (GUI.Button(new Rect(journeyTrackerX, Screen.height - 50, buttonWidth, buttonHeight), localizationManager.Localize("journey_tracker"), buttonStyle))
    {
        showJourneyTrackerWindow = !showJourneyTrackerWindow;
    }

    if (GUI.Button(new Rect(trackStarX, Screen.height - 50, buttonWidth, buttonHeight), localizationManager.Localize("current_star"), buttonStyle))
    {
        string currentStarName = PlanetManager.instance.FindParentStar();
        Star currentStarObject = FindStarByName(currentStarName);
        Debug.Log($"Star {currentStarName} was found.");
        MoveCameraToStar(currentStarObject);
    }

    if (GUI.Button(new Rect(compendiumX, Screen.height - 50, buttonWidth, buttonHeight), localizationManager.Localize("compendium"), buttonStyle))
    {
        showCompendiumWindow = !showCompendiumWindow;
    }

    if (planetsVisited >= 150)
    {
        if (GUI.Button(new Rect(websiteButtonX, Screen.height - 50, buttonWidth, buttonHeight), localizationManager.Localize("arg_redacted"), buttonStyle))
        {
            Application.OpenURL("https://www.youtube.com/watch?v=dQw4w9WgXcQ");
        }
    }


    GUIStyle fancyTextStyle = new GUIStyle();
    fancyTextStyle.fontSize = 18; 
    fancyTextStyle.fontStyle = FontStyle.Bold;
    fancyTextStyle.alignment = TextAnchor.MiddleCenter;
    fancyTextStyle.normal.textColor = new Color(1f, 0.84f, 0f); 

    GUIStyle smallerTextStyle = new GUIStyle();
    smallerTextStyle.fontSize = 14; 
    smallerTextStyle.fontStyle = FontStyle.Italic;
    smallerTextStyle.alignment = TextAnchor.MiddleCenter;
    smallerTextStyle.normal.textColor = Color.white;


    float textWidth = 400f;
    float textHeight = 30f;
    float centerX = Screen.width / 2f;
    float barY = Screen.height - 60 + 15f; 

    GUI.Label(new Rect(centerX - textWidth / 2, barY, textWidth, textHeight), "ModernBox 2.0.1.0", fancyTextStyle);
    GUI.Label(new Rect(centerX - textWidth / 2, barY + 20f, textWidth, textHeight), "BY TUXXEGO", smallerTextStyle);

}



private Texture2D MakeTex(int width, int height, Color col)
{
    Color[] pix = new Color[width * height];
    for (int i = 0; i < pix.Length; i++)
    {
        pix[i] = col;
    }
    Texture2D result = new Texture2D(width, height);
    result.SetPixels(pix);
    result.Apply();
    return result;
}


private Texture2D MakeGradientTexture(int width, int height, Color topColor, Color bottomColor)
{
    Texture2D texture = new Texture2D(width, height);
    for (int y = 0; y < height; y++)
    {
        Color color = Color.Lerp(topColor, bottomColor, (float)y / height);
        for (int x = 0; x < width; x++)
        {
            texture.SetPixel(x, y, color);
        }
    }

    texture.Apply();
    return texture;
}

private string hoveredGalaxy = null; 

private void GalaxySelectionWindow(int windowID)
{
    string planetCountFilePath = Path.Combine(Application.persistentDataPath, "ModernBox", "PlanetCount.txt");

    if (File.Exists(planetCountFilePath))
    {
        string fileContents = File.ReadAllText(planetCountFilePath);
        if (int.TryParse(fileContents, out int visitedCount))
        {
            planetsVisited = visitedCount;
        }
        else
        {
            Debug.LogError("Failed to parse planetsVisited from PlanetCount.txt");
            planetsVisited = 0;
        }
    }
    else
    {
        Debug.LogWarning("PlanetCount.txt not found, initializing planetsVisited to 0.");
        planetsVisited = 0;
    }

    
    GUIStyle galaxyButtonStyle = new GUIStyle(GUI.skin.button)
    {
        fontSize = 15,
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        fixedHeight = 30,
        wordWrap = true,
        normal = { textColor = new Color(0.5f, 1f, 1f) },  
        hover = { textColor = new Color(1f, 0.5f, 0.8f) }  
    };

    
    GUIStyle unavailableLabelStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 18,
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        wordWrap = true,
        normal = { textColor = new Color(1f, 0.3f, 0.3f) }  
    };

    
    GUILayout.Label("Explore the Galaxies", new GUIStyle(GUI.skin.label)
    {
        fontSize = 30,
        fontStyle = FontStyle.BoldAndItalic,
        alignment = TextAnchor.UpperCenter,
        normal = { textColor = new Color(1f, 0.9f, 0.3f) }  
    });

    GUILayout.Space(20); 

    
    scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(350), GUILayout.Height(400));

    foreach (string galaxy in predefinedGalaxies)
    {
        int requiredPlanets = galaxyRequirements.ContainsKey(galaxy) ? galaxyRequirements[galaxy] : 0;

        if (planetsVisited >= requiredPlanets)
        {
            if (GUILayout.Button(galaxy, galaxyButtonStyle))
            {
                isGeneratingStars = true;
                ClearAllActiveSprites();
                Debug.Log($"Loading galaxy: {galaxy}");

                string galaxyPath = Path.Combine(appDataLocation, galaxy, "Galaxies", galaxy);

                if (Directory.Exists(galaxyPath))
                {
                    showGalaxySelectionWindow = false;
                    ClearStars();
                    SaveActiveGalaxy(galaxy);
                    activeGalaxy = galaxy;
                    GenerateLoadedStars(galaxyPath);
                }
                else
                {
                    ClearStars();
                    SaveActiveGalaxy(galaxy);
                    activeGalaxy = galaxy;
                    GenerateStars();
                }
                isGeneratingStars = false;
            }
        }
        else
        {
            string labelText = $"{galaxy} (Requires {requiredPlanets} planets, you have {planetsVisited})";
            GUILayout.Label(labelText, unavailableLabelStyle);
        }

        
        if (GUILayoutUtility.GetLastRect().Contains(Event.current.mousePosition))
        {
            galaxyDescription = GetGalaxyDescription(galaxy);
            hoveredGalaxy = galaxy;
        }
    }

    GUILayout.EndScrollView();

    GUILayout.Space(20); 

    
    GUIStyle closeButtonStyle = new GUIStyle(GUI.skin.button)
    {
        fontSize = 18,
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        normal = { textColor = Color.white },
        hover = { textColor = Color.red }  
    };

    if (GUILayout.Button(localizationManager.Localize("close"), closeButtonStyle))
    {
        showGalaxySelectionWindow = false;
    }
}


private void GalaxyDescriptionWindow(int windowID)
{
    GUIStyle descriptionStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 20,
        fontStyle = FontStyle.Italic,
        wordWrap = true,
        alignment = TextAnchor.MiddleCenter,
        normal = { textColor = new Color(0.8f, 0.9f, 1f) }  
    };

    GUILayout.Label(galaxyDescription, descriptionStyle);
}


private void GalaxyInfoWindow(int windowID)
{
    GUIStyle infoStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 18,
        fontStyle = FontStyle.Normal,
        wordWrap = true,
        alignment = TextAnchor.MiddleLeft,
        normal = { textColor = new Color(0.5f, 1f, 0.5f) }  
    };

    if (hoveredGalaxy != null)
    {
        if (hoveredGalaxy == "Dank")
        {
            GUILayout.Label(localizationManager.Localize("stars_unknown"), infoStyle);
            GUILayout.Label(localizationManager.Localize("danger_unknown"), infoStyle);
        }
        else if (galaxyStarCounts.ContainsKey(hoveredGalaxy) && galaxyDangerRatings.ContainsKey(hoveredGalaxy))
        {
            GUILayout.Label(
                string.Format(localizationManager.Localize("stars_count"), galaxyStarCounts[hoveredGalaxy]), 
                infoStyle
            );
            GUILayout.Label(
                string.Format(localizationManager.Localize("danger_rating"), galaxyDangerRatings[hoveredGalaxy]), 
                infoStyle
            );
        }
        else
        {
            GUILayout.Label(localizationManager.Localize("no_information"), infoStyle);
        }
    }
    else
    {
        GUILayout.Label(localizationManager.Localize("no_galaxy_selected"), infoStyle);
    }
}



private void StarInfoWindow(int windowID)
{
    if (selectedStar == null) return;

    
    GUIStyle titleStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 28,
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        wordWrap = true,
        normal = { textColor = new Color(0.4f, 0.9f, 1.0f) } 
    };

    GUIStyle contentStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 18,
        fontStyle = FontStyle.Italic,
        wordWrap = true,
        normal = { textColor = Color.white }
    };

    GUIStyle favoriteButtonStyle = new GUIStyle(GUI.skin.button)
    {
        fontSize = 18,
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        normal = { textColor = Color.yellow },
        hover = { textColor = new Color(0.9f, 0.2f, 0.2f) } 
    };

    GUIStyle planetButtonStyle = new GUIStyle(GUI.skin.button)
    {
        fontSize = 16,
        alignment = TextAnchor.MiddleLeft,
        normal = { textColor = new Color(0.6f, 1.0f, 0.6f) }, 
        hover = { textColor = Color.cyan }
    };

    
    GUILayout.Label(selectedStar.name, titleStyle); 
    GUILayout.Space(10); 

    GUILayout.Label($"Type: {selectedStar.starType}", contentStyle);
    GUILayout.Label($"Planets: {selectedStar.planetCount}", contentStyle);

    
    bool isFavorite = favoritesList.Contains(selectedStar.name);
    if (GUILayout.Button(isFavorite ? "★ Unfavorite Star" : "☆ Favorite Star", favoriteButtonStyle))
    {
        if (isFavorite) RemoveFavorite(selectedStar.name);
        else AddFavorite(selectedStar.name);
    }

    GUILayout.Space(15); 

    
    GUILayout.Label("Planets in System:", contentStyle);
    for (int i = 0; i < selectedStar.planetCount; i++)
    {
        PlanetInfo planetInfo = selectedStar.planetInfo[i];
        if (planetInfo != null)
        {
            if (GUILayout.Button(planetInfo.name, planetButtonStyle))
            {
                selectedStar.selectedPlanet = i;
                showPlanetWindow = true;
                Event.current.Use(); 
            }
        }
    }

    
    GUILayout.FlexibleSpace(); 
    if (GUILayout.Button(localizationManager.Localize("close"), favoriteButtonStyle))
    {
        selectedStar = null; 
    }
}

	private void JourneyTrackerWindow(int windowID)
{
    GUILayout.BeginVertical();

    foreach (string starName in journeyTracker)
    {
        Star star = FindStarByName(starName);
        if (star != null)
        {
            if (GUILayout.Button(starName))
            {
                selectedStar = star;
                MoveCameraToStar(star);
            }
        }
    }

    if (GUILayout.Button(localizationManager.Localize("close")))
    {
        showJourneyTrackerWindow = false;
    }

    GUILayout.EndVertical();
}

private void AddToJourneyTracker(Star star)
{
    if (star != null && !journeyTracker.Contains(star.name))
    {
        journeyTracker.Add(star.name);
        SaveJourneyTracker();
    }
}

private void SaveJourneyTracker()
{
    string path = Path.Combine(Application.persistentDataPath, "JourneyTracker.txt");
    File.WriteAllLines(path, journeyTracker);
    Debug.Log($"Saved journey tracker: {string.Join(", ", journeyTracker)}");
}

private void LoadJourneyTracker()
{
    string path = Path.Combine(Application.persistentDataPath, "JourneyTracker.txt");
    if (File.Exists(path))
    {
        string[] lines = File.ReadAllLines(path);
        journeyTracker.Clear();
        journeyTracker.AddRange(lines.Select(line => line.Trim()));
        Debug.Log($"Loaded journey tracker: {string.Join(", ", journeyTracker)}");
    }
    else
    {
        Debug.Log("JourneyTracker.txt does not exist.");
    }
}



private void PlanetInfoWindow(int windowID)
{
    PlanetInfo planetInfo = selectedStar.planetInfo[selectedStar.selectedPlanet];

    
    GUIStyle titleStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 28,
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        normal = { textColor = new Color(0.4f, 0.9f, 1.0f) }, 
        wordWrap = true
    };

    GUIStyle contentStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 18,
        fontStyle = FontStyle.Italic,
        normal = { textColor = Color.white },
        wordWrap = true
    };

    GUIStyle visitedStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 18,
        fontStyle = FontStyle.Bold,
        normal = { textColor = Color.green }
    };

    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
    {
        fontSize = 16,
        fontStyle = FontStyle.Bold,
        normal = { textColor = new Color(0.6f, 1.0f, 0.6f) }, 
        hover = { textColor = Color.cyan },
        alignment = TextAnchor.MiddleCenter
    };

    
    GUILayout.Label($"Planet Information", titleStyle); 
    GUILayout.Space(10); 

    GUILayout.Label($"Name: {planetInfo.name}", contentStyle);
    GUILayout.Label($"Type: {planetInfo.planetType}", contentStyle);

    if (IsPlanetVisited(planetInfo.name))
    {
        GUILayout.Label(localizationManager.Localize("visited"), visitedStyle);
    }

    
    GUILayout.Space(15);
    
    if (GUILayout.Button(localizationManager.Localize("visit"), buttonStyle))
    {
        Debug.Log($"Visiting planet: {planetInfo.name}");
        ClearAllActiveSprites();
        SaveVisitedPlanet(planetInfo.name);
        SpaceManager.GeneratePlanet(planetInfo.name, planetInfo.planetType, planetInfo.size);
    }

    if (GUILayout.Button(localizationManager.Localize("parameters"), buttonStyle))
    {
        showParametersWindow = true; 
    }

    GUILayout.Space(10); 
    if (GUILayout.Button(localizationManager.Localize("close"), buttonStyle))
    {
        showPlanetWindow = false;
    }
}

private void PlanetParametersWindow(int windowID)
{
    PlanetInfo planetInfo = selectedStar.planetInfo[selectedStar.selectedPlanet];

    GUIStyle titleStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 28,
        fontStyle = FontStyle.Bold,
        alignment = TextAnchor.MiddleCenter,
        normal = { textColor = new Color(0.4f, 0.9f, 1.0f) }, 
        wordWrap = true
    };

    GUIStyle contentStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 18,
        fontStyle = FontStyle.Italic,
        normal = { textColor = Color.white },
        wordWrap = true
    };

    GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
    {
        fontSize = 16,
        fontStyle = FontStyle.Bold,
        normal = { textColor = new Color(0.6f, 1.0f, 0.6f) }, 
        hover = { textColor = Color.cyan },
        alignment = TextAnchor.MiddleCenter
    };

    GUIStyle footerTextStyle = new GUIStyle(GUI.skin.label)
    {
        fontSize = 16,
        fontStyle = FontStyle.Italic,
        alignment = TextAnchor.MiddleCenter,
        normal = { textColor = new Color(1f, 0.8f, 0.2f) }, 
        wordWrap = true
    };

    GUILayout.Label($"Planet Parameters", titleStyle); 
    GUILayout.Space(10); 

    GUILayout.Label($"Size: {planetInfo.size}", contentStyle);

    GUILayout.Space(15); 
    if (GUILayout.Button(localizationManager.Localize("close"), buttonStyle))
    {
        showParametersWindow = false; 
    }


    GUILayout.FlexibleSpace(); 
    GUILayout.Label("Planet Parameters are in beta and more parameters will be added in the future.", footerTextStyle);
}





private void SaveVisitedPlanet(string planetName)
{
    string filePath = Path.Combine(Application.persistentDataPath, "visited_planets.txt");

    if (!File.Exists(filePath))
    {
        File.WriteAllText(filePath, planetName + Environment.NewLine);
    }
    else
    {
        var visitedPlanets = File.ReadAllLines(filePath).ToList();
        if (!visitedPlanets.Contains(planetName))
        {
            File.AppendAllText(filePath, planetName + Environment.NewLine);
        }
    }
}

private bool IsPlanetVisited(string planetName)
{
    string filePath = Path.Combine(Application.persistentDataPath, "visited_planets.txt");

    if (File.Exists(filePath))
    {
        var visitedPlanets = File.ReadAllLines(filePath);
        return visitedPlanets.Contains(planetName);
    }

    return false;
}

    private void Update()
    {
        if (mainCamera == null)
        {
            Debug.LogError("Main camera is not available for update.");
            return;
        }

        hoveredStar = GetHoveredStar();

        float moveX = Input.GetAxis("Horizontal");
        float moveY = Input.GetAxis("Vertical");
        Vector3 moveDirection = new Vector3(moveX, moveY, 0);
        mainCamera.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        float scroll = Input.GetAxis("Mouse ScrollWheel");
        mainCamera.orthographicSize = Mathf.Clamp(mainCamera.orthographicSize - scroll * zoomSpeed, minZoom, maxZoom);
    }

private Star GetHoveredStar()
{

    if (stars == null || stars.Count == 0)
    {
        return null;
    }

    Vector2 mousePos = mainCamera.ScreenToWorldPoint(Input.mousePosition);

    foreach (Star star in stars)
    {
        if (Vector2.Distance(mousePos, star.transform.position) < 0.5f)
        {
            return star;
        }
    }

    return null;
}

private static string GenerateStarName()
{
    string completedStarName = "";

    for (int i = 0; i < pattern.Length; i++)
    {
        if (pattern[i] == 'p')
        {
            completedStarName += prefixes[rand.Next(prefixes.Length)];
        }
        else if (pattern[i] == 's')
        {
            completedStarName += syllables[rand.Next(syllables.Length)];
        }
        else if (pattern[i] == 'x')
        {
            completedStarName += suffixes[rand.Next(suffixes.Length)];
        }
    }

    int randomNumber = UnityEngine.Random.Range(1, 1000);
    completedStarName += "-" + randomNumber.ToString(); 

    return completedStarName;
}

private Dictionary<string, float[]> galaxyStarWeights = new Dictionary<string, float[]>
{
    { "Crabby Way", new float[] { 0.1f, 0.2f, 0.1f, 0.05f, 0.05f, 0.1f, 0.1f, 0.1f, 0.05f, 0.1f, 0.1f, 0.05f, 0.05f, 0.03f, 0.03f, 0.03f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f } },
    { "Tuxxus", new float[] { 0.05f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.05f, 0.05f, 0.04f, 0.04f, 0.04f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f } },
    { "Krummple", new float[] { 0.1f, 0.2f, 0.1f, 0.1f, 0.05f, 0.05f, 0.1f, 0.05f, 0.05f, 0.1f, 0.1f, 0.05f, 0.05f, 0.03f, 0.03f, 0.03f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f } },
    { "BlueNight", new float[] { 0.1f, 0.1f, 0.3f, 0.05f, 0.05f, 0.05f, 0.05f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.05f, 0.04f, 0.04f, 0.04f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f } },
    { "Glass", new float[] { 0.1f, 0.1f, 0.3f, 0.05f, 0.05f, 0.05f, 0.05f, 0.1f, 0.1f, 0.1f, 0.1f, 0.05f, 0.05f, 0.04f, 0.04f, 0.04f, 0.03f, 0.03f, 0.03f, 0.03f, 0.03f } },
    { "Centuga", new float[] { 0.05f, 0.05f, 0.15f, 0.05f, 0.1f, 0.1f, 0.15f, 0.05f, 0.05f, 0.1f, 0.05f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f } }, 
    { "Dank", new float[] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.2f, 0.1f, 0.05f, 0.05f, 0.1f, 0.05f, 0.05f, 0.05f, 0.03f, 0.03f, 0.03f, 0.02f, 0.02f, 0.02f, 0.02f, 0.02f } },
};

private string[] starTypes = { 
    "Red Dwarf", 
    "Yellow Dwarf", 
    "Blue Giant", 
    "White Dwarf", 
    "Neutron Star", 
    "Brown Dwarf", 
    "Supergiant", 
    "Pulsar", 
    "White Supergiant", 
    "Red Supergiant", 
    "Black Hole",
    "Rainbow Star",         
    "Void Star",            
    "Crystal Star",         
    "Quantum Star",         
    "Echo Star",            
    "Chrono Star",          
    "Phantom Star",         
    "Prism Star",           
    "Nebula Star",          
    "Graviton Star",        
    "Aurora Star"           
};

private string GenerateStarType()
{

    if (!galaxyStarWeights.TryGetValue(activeGalaxy, out float[] weights))
    {

	Debug.Log("Gay Balls");
        weights = new float[] { 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f, 0.1f };
    }

    float totalWeight = weights.Sum();
    float[] normalizedWeights = weights.Select(weight => weight / totalWeight).ToArray();

    float randomValue = UnityEngine.Random.value;
    float cumulativeWeight = 0f;
    for (int i = 0; i < normalizedWeights.Length; i++)
    {
        cumulativeWeight += normalizedWeights[i];
        if (randomValue <= cumulativeWeight)
        {
            return starTypes[i];
        }
    }

    return starTypes[starTypes.Length - 1]; 
}

private string GetGalaxyDescription(string galaxyName)
{
    switch (galaxyName)
    {
        case "Crabby Way":
            return localizationManager.Localize("crabby_way");
        case "Tuxxus":
            return localizationManager.Localize("tuxxus");
        case "Krummple":
            return localizationManager.Localize("krummple");
        case "BlueNight":
            return localizationManager.Localize("bluenight");
        case "Glass":
            return localizationManager.Localize("glass");
        case "Centuga":
            return localizationManager.Localize("centuga");
        case "Dank":
            return localizationManager.Localize("dank");
        default:
            return "No description available.";
    }
}

	private string ToRomanNumeral(int number)
{

    string[] romanNumerals = { "I", "II", "III", "IV", "V", "VI", "VII", "VIII", "IX", "X" };

    if (number < 1 || number > romanNumerals.Length)
    {
        return number.ToString(); 
    }

    return romanNumerals[number - 1];
}

private void ClearStars()
{
    foreach (Star star in stars)
    {
        if (star != null)
        {
            Destroy(star.gameObject); 
        }
    }
    stars.Clear(); 
}

private void ClearAllActiveSprites()
{

    SpriteRenderer[] allSprites = GameObject.FindObjectsOfType<SpriteRenderer>();

    foreach (SpriteRenderer sprite in allSprites)
    {

        Destroy(sprite.gameObject);
    }
}

private string GenerateNormalDescription(string starType, string planetType)
{

    var surfacePhrases = new List<string>
    {
        "features a diverse landscape with mountains and valleys",
        "is covered in vast plains with scattered rocky formations",
        "has a smooth, oceanic surface with occasional island chains",
        "boasts an icy crust with hidden liquid oceans beneath",
        "is adorned with glowing crystals that refract light into beautiful patterns",
        "is enveloped in a thick, murky swamp with bioluminescent flora",
        "is dominated by rivers of molten lava and active volcanoes",
        "has floating islands within its gaseous layers, creating an ethereal landscape",
        "is covered by an artificial surface with advanced technology remnants",
        "experiences extreme tidal forces creating massive ocean swells and geological instability"
    };

    var climatePhrases = new List<string>
    {
        "experiences a temperate climate with mild seasons",
        "has a tropical climate with heavy rainfall year-round",
        "enjoys a cool, arid climate with minimal weather variation",
        "features extreme temperature fluctuations between day and night",
        "has a stable, mild climate due to the crystal structure's influence",
        "features a humid and unstable climate with frequent fog and rain",
        "is subject to intense heat and volcanic activity",
        "maintains a stable climate within floating habitats despite external gas turbulence",
        "has a climate controlled by sophisticated machinery, maintaining a constant temperature",
        "experiences extreme climate shifts due to tidal forces"
    };

    var atmospherePhrases = new List<string>
    {
        "has a breathable atmosphere with a balanced composition",
        "features a thick atmosphere rich in exotic gases",
        "boasts a thin atmosphere with limited oxygen",
        "possesses a highly variable atmosphere with frequent weather changes",
        "has an atmosphere rich in mineral vapors that contribute to its unique appearance",
        "contains dense, toxic gases making it unsuitable for most life forms",
        "features a highly corrosive atmosphere due to volcanic activity",
        "has breathable layers within the upper atmosphere but harsh conditions below",
        "has an artificial atmosphere created for specific technological purposes",
        "features an atmosphere with extreme pressure variations due to tidal effects"
    };

    var floraFaunaPhrases = new List<string>
    {
        "home to a variety of unique flora and fauna",
        "inhabited by a few hardy species adapted to harsh conditions",
        "features a rich ecosystem with vibrant and diverse life forms",
        "has a sparse and resilient biosphere with minimal life",
        "is inhabited by crystal-based life forms that have unique energy properties",
        "hosts bioluminescent plants and aggressive swamp creatures",
        "is home to resilient life forms adapted to the extreme heat",
        "features floating flora and fauna within its gaseous layers",
        "is populated by robotic life forms and advanced machinery",
        "has a unique ecosystem affected by the extreme tidal forces"
    };

    var geologicalPhrases = new List<string>
    {
        "has an active geological landscape with frequent volcanic activity",
        "features ancient geological formations with minimal tectonic activity",
        "is characterized by a dynamic crust with shifting tectonic plates",
        "displays a stable geological environment with few changes over millennia",
        "boasts crystalline geological formations that create stunning visual effects",
        "features shifting swamp terrain with unstable ground",
        "is characterized by a molten surface with ongoing volcanic eruptions",
        "has floating landmasses with stable geological features despite gaseous turbulence",
        "has a surface covered by artificial structures and technology",
        "experiences frequent geological upheavals due to tidal forces"
    };

    string description = "";

    switch (starType)
    {
        case "Red Dwarf":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(floraFaunaPhrases) + ". ";
            break;
        case "Yellow Dwarf":
            description += RandomPhrase(climatePhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            break;
        case "Blue Giant":
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            description += RandomPhrase(climatePhrases) + ". ";
            break;
        case "White Dwarf":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(atmospherePhrases) + ". ";
            break;
        case "Neutron Star":
            description += RandomPhrase(geologicalPhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            break;
        case "Brown Dwarf":
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            description += RandomPhrase(geologicalPhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            break;
        case "Supergiant":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(atmospherePhrases) + ". ";
            break;
        case "Pulsar":
            description += RandomPhrase(geologicalPhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            description += RandomPhrase(climatePhrases) + ", ";
            description += RandomPhrase(floraFaunaPhrases) + ". ";
            break;
        case "White Supergiant":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(atmospherePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            break;
        case "Red Supergiant":
            description += RandomPhrase(climatePhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(atmospherePhrases) + ". ";
            break;
        case "Black Hole":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(atmospherePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            break;
        case "Rainbow Star":
            description += RandomPhrase(climatePhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            break;
        case "Void Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(atmospherePhrases) + ". ";
            break;
        case "Crystal Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(floraFaunaPhrases) + ". ";
            break;
        case "Quantum Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(geologicalPhrases) + ", ";
            description += RandomPhrase(floraFaunaPhrases) + ". ";
            break;
        case "Echo Star":
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            break;
        case "Chrono Star":
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(surfacePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            break;
        case "Phantom Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(geologicalPhrases) + ", ";
            description += RandomPhrase(floraFaunaPhrases) + ". ";
            break;
        case "Prism Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            break;
        case "Nebula Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(floraFaunaPhrases) + ". ";
            break;
        case "Graviton Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(floraFaunaPhrases) + ", ";
            description += RandomPhrase(geologicalPhrases) + ". ";
            break;
        case "Aurora Star":
            description += RandomPhrase(surfacePhrases) + ", ";
            description += RandomPhrase(climatePhrases) + ". ";
            description += RandomPhrase(atmospherePhrases) + ", ";
            description += RandomPhrase(floraFaunaPhrases) + ". ";
            break;
        default:
            description += "The planet features a diverse and dynamic environment.";
            break;
    }

    switch (planetType)
    {
        case "Desert World":
            description += "The desert surface is a notable feature of this planet.";
            break;
        case "Gas Giant":
            description += "The gaseous composition creates a unique and visually stunning environment.";
            break;
        case "Oceanic":
            description += "The extensive oceans provide a rich and dynamic ecosystem.";
            break;
        case "Icy":
            description += "The icy surface presents a stark, yet beautiful landscape.";
            break;
        case "Crystal World":
            description += "The planet's surface is covered in luminous crystals that create a surreal visual effect.";
            break;
        case "Swamp World":
            description += "The planet is shrouded in murky swamps with glowing, bioluminescent vegetation.";
            break;
        case "Lava World":
            description += "The planet features an intense volcanic landscape with rivers of molten lava.";
            break;
        case "Gas Giant (Habitable)":
            description += "Floating islands and habitats within the upper atmosphere provide a unique living environment.";
            break;
        case "Mechanical World":
            description += "An artificial surface dominated by advanced technology and remnants of a bygone civilization.";
            break;
        case "Jungle World":
            description += "Filled with dense flora and diverse fauna.";
            break;
        case "Corrupted World":
            description += "The planet is a desolate and twisted wasteland, corrupted by unknown forces.";
            break;
        case "Lemon World":
            description += "The surface is covered in yellow, citrus-like vegetation, creating a surreal and fragrant landscape.";
            break;
        case "Mushroom World":
            description += "Giant mushrooms dominate the landscape, providing shelter and resources to the unique ecosystem.";
            break;
        case "Wasteland World":
            description += "The planet is a barren and scorched wasteland, with ruins of ancient civilizations scattered across its surface.";
            break;
        default:
            description += "The planet features a diverse and dynamic environment.";
            break;
    }

    return description;
}

private string RandomPhrase(List<string> phrases)
{
    int index = UnityEngine.Random.Range(0, phrases.Count);
    return phrases[index];
}

    private Dictionary<string, int> GenerateResources()
    {

        string[] resourceTypes = { "Steel", "Soil", "Water", "Gold", "Uranium" };
        Dictionary<string, int> resources = new Dictionary<string, int>();
        foreach (string resource in resourceTypes)
        {
            resources[resource] = UnityEngine.Random.Range(0, 1000);
        }
        return resources;
    }

private string GenerateDangerDescription(string starType, string planetType)
{

    var dangerPhrases = new List<string>
    {
        "The planet is plagued by frequent seismic activity.",
        "The atmosphere is filled with toxic gases, making it uninhabitable.",
        "The planet experiences extreme weather conditions with frequent storms.",
        "Radiation from the star poses a serious threat to any form of life.",
        "The surface is unstable, with constant volcanic eruptions.",
        "The planet's gravity creates intense tidal forces, causing severe geological instability.",
        "The environment is filled with hazardous materials and contaminants.",
        "Frequent meteor showers bombard the surface, creating dangerous conditions.",
        "The planet's atmosphere is corrosive and hostile to most known life forms.",
        "Extreme temperature fluctuations make survival difficult and unpredictable."
    };

    var hazardPhrases = new List<string>
    {
        "Unstable surface with frequent eruptions",
        "Toxic atmosphere with corrosive elements",
        "High radiation levels affecting electronics and life forms",
        "Severe gravitational effects causing tidal waves and geological disruptions",
        "Dangerous weather patterns including violent storms and temperature extremes",
        "High risk of meteor impacts and space debris",
        "Hazardous chemical spills and environmental contamination",
        "Extreme tidal forces leading to significant geological instability",
        "High volcanic activity with continuous lava flows",
        "Unpredictable climate variations making the environment hostile"
    };

    string description = "";

    switch (starType)
    {
        case "Red Dwarf":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "due to the star's minimal luminosity and unstable radiation output. ";
            description += "This creates a challenging environment for survival and exploration.";
            break;
        case "Yellow Dwarf":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "resulting from the planet's position in the habitable zone with fluctuating conditions. ";
            description += "The diverse but hazardous environment demands careful navigation.";
            break;
        case "Blue Giant":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "because of the intense radiation and high energy output of the star. ";
            description += "These factors contribute to a hazardous environment for both equipment and life.";
            break;
        case "White Dwarf":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "due to the star's extreme density and high gravitational pull. ";
            description += "This causes severe environmental hazards and challenges for exploration.";
            break;
        case "Neutron Star":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "caused by the intense gravitational forces and high radiation levels from the star. ";
            description += "These conditions make the planet's environment extremely dangerous.";
            break;
        case "Brown Dwarf":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "as the star's low energy output leads to unstable conditions on nearby planets. ";
            description += "Explorers must be prepared for unpredictable hazards.";
            break;
        case "Supergiant":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "due to the massive energy output and unstable stellar conditions. ";
            description += "The extreme environment presents significant challenges for survival.";
            break;
        case "Pulsar":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "due to the pulsar's intense radiation bursts and high-energy emissions. ";
            description += "These factors create hazardous conditions for any exploration or habitation.";
            break;
        case "White Supergiant":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "resulting from the star's enormous size and high energy levels. ";
            description += "The environment is fraught with danger due to these extreme conditions.";
            break;
        case "Red Supergiant":
            description += RandomPhrase(dangerPhrases) + ", ";
            description += "because of the star's immense size and unstable energy output. ";
            description += "These factors contribute to a highly dangerous environment.";
            break;
        case "Black Hole":
            description += "The planet orbits a black hole, creating extreme gravitational effects and intense tidal forces. ";
            description += "The environment is highly hazardous with severe space-time distortions and gravitational disruptions.";
            break;
        default:
            description += "Planet faces danger due to " + RandomPhrase(dangerPhrases) + ". ";
            description += "These conditions result from its proximity to " + starType + ". ";
            description += "The hazardous environment requires careful consideration for exploration.";
            break;
    }

    switch (planetType)
    {
        case "Desert World":
            description += " The desert surface is prone to seismic instability and geological hazards.";
            break;
        case "Gas Giant":
            description += " The gaseous composition creates unpredictable atmospheric conditions and hazardous weather patterns.";
            break;
        case "Oceanic":
            description += " The extensive oceans contribute to dangerous weather conditions and extreme climate variations.";
            break;
        case "Icy":
            description += " The icy surface creates challenges for exploration due to extreme cold and unstable terrain.";
            break;
        case "Crystal World":
            description += " The crystalline surface is not only visually stunning but also presents unique environmental hazards.";
            break;
        case "Swamp World":
            description += " The swampy environment is filled with hazardous gases and dangerous wildlife.";
            break;
        case "Lava World":
            description += " The volcanic activity creates severe hazards, including constant lava flows and unstable terrain.";
            break;
        case "Gas Giant (Habitable)":
            description += " The floating habitats are subject to unpredictable atmospheric conditions and hazards.";
            break;
        case "Mechanical World":
            description += " The artificial surface and technological remnants create environmental hazards due to malfunctioning systems.";
            break;
        case "Jungle World":
            description += " Extreme tidal forces create severe geological instability and environmental challenges.";
            break;
        case "Corrupted World":
            description += "The planet is highly unstable, with areas of corruption that could pose unknown dangers.";
            break;
        case "Lemon World":
            description += "While the surface appears harmless, the acidic environment poses a hidden threat.";
            break;
        case "Mushroom World":
            description += "The giant mushrooms release spores that can be toxic to unprepared explorers.";
            break;
        case "Wasteland World":
            description += "The harsh environment and radiation pockets make this planet extremely dangerous.";
            break;
    }

    return description;
}

    private void OnDisable()
    {

        if (mainCamera != null)
        {
            Destroy(mainCamera.gameObject);
            mainCamera = null;
        }
    }
}

[System.Serializable]
public class Star : MonoBehaviour
{
    public string name;
    public string starType;
    public int planetCount;
    public PlanetInfo[] planetInfo;
    public int selectedPlanet;

    [JsonIgnore] 
    public GameObject gameObject; 
}

[System.Serializable]
public class PlanetInfo
{
    public string name;
    public string description;
    public Dictionary<string, int> resources;
    public int dangerRating;
    public string dangerDescription;
    public string planetType; 
    public string size; 
    public bool hasFauna; 
}


    public class CompendiumEntry
    {
        public string Title { get; }
        public string Content { get; }

        public CompendiumEntry(string title, string content)
        {
            Title = title;
            Content = content;
        }
    }

public class Vector3Converter : JsonConverter
{
    public override bool CanConvert(Type objectType)
    {
        return objectType == typeof(Vector3);
    }

    public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
    {
        Vector3 vector = (Vector3)value;
        writer.WriteStartObject();
        writer.WritePropertyName("x");
        writer.WriteValue(vector.x);
        writer.WritePropertyName("y");
        writer.WriteValue(vector.y);
        writer.WritePropertyName("z");
        writer.WriteValue(vector.z);
        writer.WriteEndObject();
    }

    public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
    {
        JObject obj = JObject.Load(reader);
        float x = obj["x"].Value<float>();
        float y = obj["y"].Value<float>();
        float z = obj["z"].Value<float>();
        return new Vector3(x, y, z);
    }
}