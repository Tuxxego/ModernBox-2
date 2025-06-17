using UnityEngine;
using UnityEngine.UI;
using System.Text;

public class StatManager : MonoBehaviour
{
    public static StatManager Instance { get; private set; }

    public float timePlayed;
    public int bombsDropped;
    public int planetsVisited;
    public int unitsSpawned;
    public int currentVehicles;

    private Text statLabel;
    private Text CubanstatLabel;
    private Image glowingImage;
    private float pulseTime = 0f;
    private Image flashingAdImage;
    private float flashTime = 0f;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void RegisterStatLabel(Text label)
    {
        statLabel = label;
    }

    public void RegisterStatCubanLabel(Text label)
    {
        CubanstatLabel = label;
    }

    public void RegisterImage(Image image)
    {
        glowingImage = image;
    }

    public void RegisterFlashingImage(Image image)
    {
        flashingAdImage = image;
    }

    public void DropBomb() => bombsDropped++;
    public void VisitPlanet() => planetsVisited++;
    public void SpawnUnit() => unitsSpawned++;

    void Update()
    {
        timePlayed += Time.deltaTime;

        // Count actors with "Unitpotential" trait
        int potentialUnits = 0;
        foreach (Actor actor in MapBox.instance.units)
        {
            if (actor != null && actor.hasTrait("Unitpotential"))
            {
                potentialUnits++;
            }
        }
        currentVehicles = potentialUnits;

        if (statLabel != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<b>Time Playing:</b> {FormatTime(timePlayed)}");
            sb.AppendLine($"<b>Bombs Dropped:</b> {bombsDropped}");
            sb.AppendLine($"<b>Current Vehicles:</b> {currentVehicles}");
            sb.AppendLine($"<b>AI Nukes Dropped:</b> {unitsSpawned}");
            sb.AppendLine($"<b>Planets Visited:</b> {planetsVisited}");
            sb.AppendLine($"<b>Version: 3.5.0.0</b>");
            statLabel.text = sb.ToString();
        }

        if (CubanstatLabel != null)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"<b>Time under Castro:</b> {FormatTime(timePlayed)}");
            sb.AppendLine($"<b>Capitalists killed:</b> {bombsDropped}");
            sb.AppendLine($"<b>People fed:</b> {planetsVisited}");
            sb.AppendLine($"<b>Anti Communists:</b> {unitsSpawned}");
            CubanstatLabel.text = sb.ToString();
        }

        if (glowingImage != null)
        {
            pulseTime += Time.deltaTime * 2f;
            float glow = Mathf.Sin(pulseTime) * 0.25f + 0.75f;
            glowingImage.color = new Color(glow, glow, glow, 1f);
            glowingImage.transform.localScale = Vector3.one * (1f + Mathf.Sin(pulseTime) * 0.05f);
        }
        
        if (flashingAdImage != null)
        {
            var hover = flashingAdImage.GetComponent<DiscordAdHover>();
            if (hover != null && hover.isHovered)
            {
                flashingAdImage.color = Color.yellow;
                flashingAdImage.transform.localScale = Vector3.one * 1.15f;
            }
            else
            {
                flashTime += Time.deltaTime * 4f;
                float scale = 1f + Mathf.Abs(Mathf.Sin(flashTime)) * 0.15f;
                flashingAdImage.color = new Color(1f, 1f, 1f, 0.9f + Mathf.Sin(flashTime * 2f) * 0.1f);
                flashingAdImage.transform.localScale = Vector3.one * scale;
            }
        }
    }

    private string FormatTime(float time)
    {
        int minutes = Mathf.FloorToInt(time / 60f);
        int seconds = Mathf.FloorToInt(time % 60f);
        return $"{minutes:D2}:{seconds:D2}";
    }
}
