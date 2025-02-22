using System.Collections.Generic;
using UnityEngine;

namespace M2
{
    public class AchievementManager : MonoBehaviour
    {
        public static AchievementManager Instance;
        private Dictionary<string, Achievement> achievements = new Dictionary<string, Achievement>();
        private List<AchievementNotification> notifications = new List<AchievementNotification>();
        private bool showNotification = false;
        private float notificationTimer = 0f;
        private const float notificationDuration = 20f;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
                InitializeAchievements();
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void InitializeAchievements()
        {
            AddAchievement("played_m2", "Goated Fella", "Play WorldBox with M2", "ui/Icons/tabIconModernWarfare");
            AddAchievement("moab_drop", "Not so super", "Yeah at one point this was the biggest bomb...", "ui/Icons/MOAB");
            AddAchievement("discord", "Tuxean", "You joined Tuxia! (Or you faked)", "ui/Icons/DiscordServer");
            AddAchievement("bomb_overload", "BOMBS OVERLOAD!!!", "Drop every bomb at least once.", "ui/Icons/Overload");
            AddAchievement("deleted", "Nothing left...", "Bro deleted the whole universe ☠️.", "ui/Icons/Deleter");
        }

        private void AddAchievement(string id, string name, string description, string spritePath)
        {
            if (!achievements.ContainsKey(id))
            {
                achievements.Add(id, new Achievement(id, name, description, spritePath));
            }
        }

        public void UnlockAchievement(string id)
        {
            if (achievements.ContainsKey(id) && !IsAchievementUnlocked(id))
            {
                PlayerPrefs.SetInt(id, 1);
                PlayerPrefs.Save();
                Achievement unlockedAchievement = achievements[id];
                notifications.Add(new AchievementNotification(unlockedAchievement));
                showNotification = true;
                notificationTimer = 0f;
            }
        }

        public bool IsAchievementUnlocked(string id)
        {
            return PlayerPrefs.GetInt(id, 0) == 1;
        }

        private void OnGUI()
        {
            if (showNotification && notifications.Count > 0)
            {
                DrawAchievementBanner();
            }
        }

       public List<Achievement> GetAllAchievements()
        {
            Debug.Log("Retrieving all achievements: " + achievements.Count);
            return new List<Achievement>(achievements.Values);
        }
	
		private void DrawAchievementBanner()
		{
			if (notifications.Count == 0) return;

			float bannerWidth = 400;
			float bannerHeight = 120;
			float startX = (Screen.width - bannerWidth) / 2;
			float startY = Mathf.Lerp(-bannerHeight, 50, notificationTimer / 1.0f);

			GUI.Box(new Rect(startX, startY, bannerWidth, bannerHeight), "");

			GUIStyle titleStyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = 18,
				alignment = TextAnchor.MiddleCenter,
				fontStyle = FontStyle.Bold,
				normal = { textColor = Color.yellow }
			};

			GUIStyle textStyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = 14,
				alignment = TextAnchor.UpperLeft,
				normal = { textColor = Color.white }
			};

			AchievementNotification currentNotification = notifications[0];
			Texture2D icon = Resources.Load<Texture2D>(currentNotification.Achievement.SpritePath + ".png");

			if (icon == null)
			{
				Debug.LogError("Achievement image not found: " + currentNotification.Achievement.SpritePath);
			}

			GUI.Label(new Rect(startX, startY + 5, bannerWidth, 25), "NEW M2 ACHIEVEMENT UNLOCKED", titleStyle);

			if (icon != null)
			{
				GUI.DrawTexture(new Rect(startX + 10, startY + 35, 50, 50), icon);
			}

			GUI.Label(new Rect(startX + 70, startY + 35, 300, 30), currentNotification.Achievement.Name, textStyle);
			GUI.Label(new Rect(startX + 70, startY + 60, 300, 30), currentNotification.Achievement.Description, textStyle);

			notificationTimer += Time.deltaTime;
			if (notificationTimer >= notificationDuration)
			{
				notifications.RemoveAt(0);
				notificationTimer = 0f;
				if (notifications.Count == 0)
				{
					showNotification = false;
				}
			}
		}
	}


    public class Achievement
    {
        public string ID { get; }
        public string Name { get; }
        public string Description { get; }
        public string SpritePath { get; }

        public Achievement(string id, string name, string description, string spritePath)
        {
            ID = id;
            Name = name;
            Description = description;
            SpritePath = spritePath;
        }
    }

    public class AchievementNotification
    {
        public Achievement Achievement { get; }

        public AchievementNotification(Achievement achievement)
        {
            Achievement = achievement;
        }
    }
}
