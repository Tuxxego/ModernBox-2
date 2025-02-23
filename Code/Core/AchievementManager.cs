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
            AddAchievement("deleted", "Nothing left...", "Bro deleted the whole universe ☠️.", "ui/Icons/UniversalDestroyer");
            AddAchievement("danksshittybomb", "Erased", "Drop the Eraser Bomb.", "ui/Icons/Eraser");
            AddAchievement("planetlander", "Multi Planetary", "Visit another planet.", "ui/Icons/Planet");
        }

        private void AddAchievement(string id, string name, string description, string spritePath)
        {
            if (!achievements.ContainsKey(id))
            {
                achievements.Add(id, new Achievement(id, name, description, spritePath));
            }
        }

		public void ResetAchievements()
		{
			foreach (var achievement in achievements.Values)
			{
				PlayerPrefs.SetInt(achievement.ID, 0);
			}
			PlayerPrefs.Save();

			foreach (var achievement in achievements.Values)
			{
				AchievementsWindow.EditButton(achievement.ID, "???", "???");
			}
			
			Debug.Log("All achievements have been reset.");
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
				AchievementsWindow.EditButton(id, unlockedAchievement.Name, unlockedAchievement.Description);
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

			GUIStyle nameStyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = 16,
				alignment = TextAnchor.UpperLeft,
				fontStyle = FontStyle.Bold,
				normal = { textColor = Color.white }
			};
			GUIStyle textStyle = new GUIStyle(GUI.skin.label)
			{
				fontSize = 14,
				alignment = TextAnchor.UpperLeft,
				normal = { textColor = Color.white }
			};

			AchievementNotification currentNotification = notifications[0];
			Sprite iconSprite = Resources.Load<Sprite>(currentNotification.Achievement.SpritePath);
			Texture2D iconTexture = null;

			if (iconSprite != null)
			{
				iconTexture = SpriteToTexture2D(iconSprite);
			}
			else
			{
				Debug.LogError("Achievement image not found: " + currentNotification.Achievement.SpritePath);
			}

			GUI.Label(new Rect(startX, startY + 5, bannerWidth, 25), "NEW M2 ACHIEVEMENT UNLOCKED", titleStyle);

			if (iconTexture != null)
			{
				GUI.DrawTexture(new Rect(startX + 10, startY + 35, 50, 50), iconTexture);
			}

			GUI.Label(new Rect(startX + 70, startY + 35, 300, 30), currentNotification.Achievement.Name, nameStyle);
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

		private Texture2D SpriteToTexture2D(Sprite sprite)
		{
			if (sprite == null) return null;

			Texture2D texture = new Texture2D((int)sprite.rect.width, (int)sprite.rect.height);
			Color[] pixels = sprite.texture.GetPixels(
				(int)sprite.rect.x,
				(int)sprite.rect.y,
				(int)sprite.rect.width,
				(int)sprite.rect.height
			);
			texture.SetPixels(pixels);
			texture.Apply();
			return texture;
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
