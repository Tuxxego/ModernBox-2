using System.Collections;
using UnityEngine;

namespace ModernBox
{
    public class BombUtilities : MonoBehaviour
    {
        public static BombUtilities Instance { get; private set; }

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
                return;
            }
            Instance = this;

            EffectAsset IceBomb = new EffectAsset();
            IceBomb.id = "fx_ice_bomb";
            IceBomb.use_basic_prefab = true;
            IceBomb.sorting_layer_id = "EffectsTop";
            IceBomb.sprite_path = "Effects/iceBomb";
            IceBomb.draw_light_area = true;
            IceBomb.limit = 100;
            IceBomb.sound_launch = "event:/SFX/EXPLOSIONS/TsarBomb";
            AssetManager.effects_library.add(IceBomb);
        }

        public void action_MOABClick(WorldTile pTile, string pPowerID)
        {
            EffectsLibrary.spawn("fx_nuke_flash", pTile, "moab");
            World.world.startShake(pIntensity: 2.5f, pShakeX: true);
        }

        public bool action_MOABClickOTHER(BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 1.4f, 1.6f);
            StatManager.Instance.DropBomb();
            if (World.world.explosion_checker.checkNearby(pTile, 90))
                return false;

            ExplodeInRadius(pTile, 90f);
            ExplodeInFIRE(pTile, 90f);
            return true;
        }

        public void action_ClusterClick(WorldTile pTile, string pPowerID) {
        //    ProgressToThatOneAchievement("Bomb10");
            World.world.StartCoroutine(ClusterNukeCoroutine(pTile));
        }

        public void action_IceClick(WorldTile pTile, string pPowerID)
        {
            EffectsLibrary.spawn("fx_nuke_flash", pTile, "icebomb");
            World.world.startShake(pIntensity: 2.5f, pShakeX: true);
        }

        public bool action_IceClickOTHER(BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            EffectsLibrary.spawnAtTileRandomScale("fx_ice_bomb", pTile, 1.4f, 1.6f);
            StatManager.Instance.DropBomb();
            if (World.world.explosion_checker.checkNearby(pTile, 30))
                return false;

            ExplodeInIce(pTile, 30f);
            return true;
        }

        public void action_FireBombClick(WorldTile pTile, string pPowerID)
        {
            EffectsLibrary.spawn("fx_nuke_flash", pTile, "firebomb");
            StatManager.Instance.DropBomb();
            if (World.world.explosion_checker.checkNearby(pTile, 120))
                return;

            ExplodeInFIRE(pTile, 120f);
            return;
        }

        public void action_TuxiumClick(WorldTile pTile, string pPowerID)
        {
            EffectsLibrary.spawn("fx_nuke_flash", pTile, "tuxium");
            World.world.startShake(pIntensity: 2.5f, pShakeX: true);
        }

        public bool action_TuxiumClickOTHER(BaseSimObject pTarget = null, WorldTile pTile = null)
        {
            EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", pTile, 16.4f, 28.6f);
            StatManager.Instance.DropBomb();
            if (World.world.explosion_checker.checkNearby(pTile, 290))
                return false;

            ExplodeInRadius(pTile, 290f);
            return true;
        }

        public void ExplodeInRadius(WorldTile centerTile, float radius)
        {
            if (centerTile == null)
                return;

            World.world.StartCoroutine(ThisShitIsSoStupid(centerTile, radius));
        }

        private IEnumerator ThisShitIsSoStupid(WorldTile centerTile, float radius)
        {
            Vector2Int center = centerTile.pos;
            int intRadius = Mathf.CeilToInt(radius);
            int tilesPerFrame = 400;

            for (int r = 0; r <= intRadius; r++)
            {
                int tilesProcessed = 0;
                for (int x = -r; x <= r; x++)
                {
                    for (int y = -r; y <= r; y++)
                    {
                        if (Mathf.RoundToInt(Vector2.Distance(new Vector2(x, y), Vector2.zero)) != r)
                            continue;

                        int checkX = center.x + x;
                        int checkY = center.y + y;

                        WorldTile tile = World.world.GetTile(checkX, checkY);
                        if (tile != null)
                        {
                            MapAction.applyTileDamage(tile, radius, AssetManager.terraform.get("czar_bomba"));
                            //MapAction.damageWorld(tile, intRadius, AssetManager.terraform.get("czar_bomba"), null);                            
                            tilesProcessed++;
                        }

                        if (tilesProcessed >= tilesPerFrame)
                        {
                            tilesProcessed = 0;
                            yield return null;
                        }
                    }
                }
                yield return null;
            }
        }

        private IEnumerator ClusterNukeCoroutine(WorldTile pTile) {
            float duration = 5f; 
            float interval = 0.2f; 
            float elapsed = 0f; 

            while (elapsed < duration) {
                elapsed += interval;

                WorldTile randomTile = GetRandomTileWithinRadius(pTile, 35);
                if (randomTile != null) {
                    EffectsLibrary.spawnAtTileRandomScale("fx_explosion_huge", randomTile, 0.4f, 0.6f);
                    World.world.startShake(0.3f, 0.01f, 2f, true, true);
                    if (World.world.explosion_checker.checkNearby(randomTile, 20))
                    yield return new WaitForSeconds(interval);
                    StatManager.Instance.DropBomb();
                    ExplodeInRadius(randomTile, 25f);
                }

                yield return new WaitForSeconds(interval);
            }
        }

        private WorldTile GetRandomTileWithinRadius(WorldTile centerTile, int radius) {
            int x = centerTile.x + UnityEngine.Random.Range(-radius, radius + 1);
            int y = centerTile.y + UnityEngine.Random.Range(-radius, radius + 1);
            return World.world.GetTile(x, y);
        }

        public void ExplodeInIce(WorldTile centerTile, float radius)
        {
            if (centerTile == null)
                return;

            World.world.StartCoroutine(ThisIceIsSoStupid(centerTile, radius));
        }

        private IEnumerator ThisIceIsSoStupid(WorldTile centerTile, float radius)
        {
            Vector2Int center = centerTile.pos;
            int intRadius = Mathf.CeilToInt(radius);
            int tilesPerFrame = 400;

            for (int r = 0; r <= intRadius; r++)
            {
                int tilesProcessed = 0;
                for (int x = -r; x <= r; x++)
                {
                    for (int y = -r; y <= r; y++)
                    {
                        if (Mathf.RoundToInt(Vector2.Distance(new Vector2(x, y), Vector2.zero)) != r)
                            continue;

                        int checkX = center.x + x;
                        int checkY = center.y + y;

                        WorldTile tile = World.world.GetTile(checkX, checkY);
                        if (tile != null)
                        {
                            tile.freeze();
                            tilesProcessed++;
                        }

                        if (tilesProcessed >= tilesPerFrame)
                        {
                            tilesProcessed = 0;
                            yield return null;
                        }
                    }
                }
                yield return null;
            }
        }

        public void ExplodeInFIRE(WorldTile centerTile, float radius)
        {
            if (centerTile == null)
                return;

            World.world.StartCoroutine(ThisShitIsSoFire(centerTile, radius));
        }

        private IEnumerator ThisShitIsSoFire(WorldTile centerTile, float radius)
        {
            Vector2Int center = centerTile.pos;
            int intRadius = Mathf.CeilToInt(radius);
            int tilesPerFrame = 400;

            for (int r = 0; r <= intRadius; r++)
            {
                int tilesProcessed = 0;
                for (int x = -r; x <= r; x++)
                {
                    for (int y = -r; y <= r; y++)
                    {
                        if (Mathf.RoundToInt(Vector2.Distance(new Vector2(x, y), Vector2.zero)) != r)
                            continue;

                        int checkX = center.x + x;
                        int checkY = center.y + y;

                        WorldTile tile = World.world.GetTile(checkX, checkY);
                        if (tile != null)
                        {
                            tile.setFireData(true);
                            tilesProcessed++;
                        }

                        if (tilesProcessed >= tilesPerFrame)
                        {
                            tilesProcessed = 0;
                            yield return null;
                        }
                    }
                }
                yield return null;
            }
        }

        private IEnumerator PotentiallyWorkingAntiMatterBombFixUpdateFromTuxThisDOESNOTWORKButImLeavingItInCuzWhoKnowsMaybeIllReturnToItAndFixIt(WorldTile centerTile, float radius)
        {
            Vector2Int center = centerTile.pos;
            int intRadius = Mathf.CeilToInt(radius);
            int tilesPerFrame = 400;

            for (int r = 0; r <= intRadius; r++)
            {
                int tilesProcessed = 0;
                for (int x = -r; x <= r; x++)
                {
                    for (int y = -r; y <= r; y++)
                    {
                        if (Mathf.RoundToInt(Vector2.Distance(new Vector2(x, y), Vector2.zero)) != r)
                            continue;

                        int checkX = center.x + x;
                        int checkY = center.y + y;

                        WorldTile tile = World.world.GetTile(checkX, checkY);
                        // surprise of the day: this does not fucking work and i wasted 20 minutes on this stupid motherfucking shit.
                        if (tile != null)
                        {
                            TileType pType = TileLibrary.pit_deep_ocean;
                            MapAction.terraformMain(tile, pType, TerraformLibrary.destroy_no_flash);
                            tilesProcessed++;
                        }

                        if (tilesProcessed >= tilesPerFrame)
                        {
                            tilesProcessed = 0;
                            yield return null;
                        }
                    }
                }
                yield return null;
            }
        }
    }
}