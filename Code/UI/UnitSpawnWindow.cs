using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using NCMS.Utils;

namespace ModernBox
{
    public class UnitSpawnWindow : MonoBehaviour
    {
        public static UnitSpawnWindow Instance { get; private set; }

        private ScrollWindow window;
        private GameObject content;
        private bool initialized = false;
        private Dictionary<string, PowerButton> loserButtons = new Dictionary<string, PowerButton>();

        public static void Create()
        {
            if (Instance != null) return;

            GameObject obj = new GameObject("UnitSpawnWindow");
            Instance = obj.AddComponent<UnitSpawnWindow>();
            DontDestroyOnLoad(obj);
        }

        private PowersTab getPowersTab(string id)
        {
            GameObject gameObject = GameObjects.FindEvenInactive(id);
            return gameObject?.GetComponent<PowersTab>();
        }

        public void Init()
        {
            if (initialized) return;

            PowersTab tab = getPowersTab("ModernBox");
            window = Windows.CreateNewWindow("AllUnits", "SPAWN VEHICLES");
           var scrollView = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View");
            scrollView.gameObject.SetActive(true);
            content = GameObject.Find($"/Canvas Container Main/Canvas - Windows/windows/{window.name}/Background/Scroll View/Viewport/Content");
            content.GetComponent<RectTransform>().sizeDelta = new Vector2(0, 9999);

            int buttonsPerRow = 4;
            int buttonSpacingX = 1;
            int buttonSpacingY = 1;
            int startX = 0;
            int startY = 0;

            int index = 0;
            foreach (var unit in UnitTracker.Instance.units)
            {
                if (unit.sprite == null)
                {
                    ModernBoxLogger.Warning($"[M3] Skipping unit {unit.id} because sprite is null.");
                    continue;
                }

                int row = index / buttonsPerRow;
                int col = index % buttonsPerRow;

                int posX = startX + (col * buttonSpacingX);
                int posY = startY + (row * buttonSpacingY);

                var loserButton = PowerButtons.CreateButton(
                    $"spawn_{unit.id}",
                    unit.sprite,
                    $"LOSER ({unit.id})",
                    $"This is the LOSER button for {unit.id}.",
                    new Vector2(-500, -500),
                    ButtonType.GodPower,
                    tab.transform,
                    () => ModernBoxLogger.Log($"LOSER {unit.id} activated.")
                );

                loserButtons[unit.id] = loserButton;

                new ButtonBuilder($"balls_{unit.id}")
                    .SetSprite(unit.sprite)
                    .SetTitle($"Spawn ({unit.id})")
                    .SetDescription($"Spawn the unit: {unit.id}")
                    .SetPosition(col, row)
                    .SetType(ButtonType.Click)
                    .SetTransform(content.transform)
                    .SetFunction(() => {
                        window.clickHide();

                        if (loserButtons.TryGetValue(unit.id, out var lb))
                        {
                            string powerId = $"spawn_{unit.id}";
                            GodPower spawnPower = AssetManager.powers.get(powerId);
                            if (spawnPower != null)
                            {
                                PowerButtonSelector.instance.setSelectedPower(lb, spawnPower);
                                PowerButtonSelector.instance.clickPowerButton(lb);
                            }
                            else
                            {
                                ModernBoxLogger.Warning($"[UnitSpawnWindow] GodPower not found: {powerId}");
                            }
                        }
                    })
                    .Build();

                index++;
            }

            initialized = true;
            ModernBoxLogger.Log("[M3] UnitSpawnWindow initialized.");
        }
    }
}
