using System.Collections.Generic;
using UnityEngine;

public class MagmaTornadoEffect : BaseEffect
{
    private const float TORNADO_SCALE_DECREASE_SPLIT_MULTIPLIER = 0.5f;
    private const float TORNADO_SCALE_DECREASE_MULTIPLIER = 0.5f;
    private const float TORNADO_SCALE_INCREASE_MULTIPLIER = 1.5f;
    private const float TORNADO_SCALE_MIN = 0.1f;
    private const float TORNADO_SCALE_MAX = 5f;
    public const float TORNADO_SCALE_DEFAULT = 0.5f;
    private const int RANDOM_TILE_RANGE = 5;
    private const float ACTION_INTERVAL_FORCE = 0.1f;
    private const float ACTION_INTERVAL_TERRAFORM = 0.3f;
    private const float SHRINK_TIMER = 10f;
    private const float MOVE_SPEED = 0.15f;

    private float _tornado_timer_force;
    private float _tornado_timer_terraform;
    private float _shrink_timer;
    private float _target_scale = 0.5f;
    private WorldTile _target_tile;
    private static readonly Dictionary<WorldTile, HashSet<MagmaTornadoEffect>> _tornadoes_by_tiles = new Dictionary<WorldTile, HashSet<MagmaTornadoEffect>>();
    internal float colorEffect;
    internal Material colorMaterial;

     public override void prepare(WorldTile pTile, float pScale = 0.5f)
    {
        base.prepare(pTile, pScale);
        current_tile = World.world.GetTileSimple((int)base.transform.localPosition.x, (int)base.transform.localPosition.y);
        _target_tile = Toolbox.getRandomTileWithinDistance(current_tile, 5);
        setScale(0.11000001f);
        _target_scale = pScale;
        _tornado_timer_force = 0.1f;
        _tornado_timer_terraform = 0.3f;
        _shrink_timer = 10f;
        addTornadoToTile();
    }

    public override void update(float pElapsed)
    {
        base.update(pElapsed);
        updateChangeScale(pElapsed);
        if (World.world.isPaused() || isKilled())
            return;
        updateColorEffect(pElapsed);
        if (state == 2)
        {
            deathAnimation(pElapsed);
            return;
        }
        updateMovement();
        updateShrinking(pElapsed);
        if (_tornado_timer_force > 0f)
        {
            _tornado_timer_force -= pElapsed;
        }
        else
        {
            _tornado_timer_force = 0.1f;
            tornadoActionForce(current_tile);
        }
        if (_tornado_timer_terraform > 0f)
        {
            _tornado_timer_terraform -= pElapsed;
            return;
        }
        _tornado_timer_terraform = 0.3f;
        tornadoActionTerraform(current_tile, scale);
    }

    private void updateMovement()
    {
        WorldTile tNewTile = World.world.GetTileSimple((int)base.transform.localPosition.x, (int)base.transform.localPosition.y);
        if (tNewTile != current_tile)
        {
            removeTornadoFromTile();
            current_tile = tNewTile;
            addTornadoToTile();
        }
        if (current_tile == _target_tile)
        {
            _target_tile = Toolbox.getRandomTileWithinDistance(current_tile, 5);
        }
        Vector3 tDirection = (_target_tile.posV3 - base.transform.localPosition).normalized;
        base.transform.localPosition += tDirection * 0.15f;
    }

    private void updateShrinking(float pElapsed)
    {
        if (_shrink_timer > 0f)
        {
            _shrink_timer -= pElapsed;
            return;
        }
        _shrink_timer = Randy.randomFloat(7.5f, 12.5f);
        shrink();
    }

    private void tornadoActionTerraform(WorldTile pTile, float pScale = 0.5f)
    {
        BrushData brush = Brush.get((int)(pScale * 6f));
        bool tDamage = true;
        if (!MapAction.checkTileDamageGaiaCovenant(pTile, pDamage: true))
        {
            tDamage = false;
        }
        for (int i = 0; i < brush.pos.Length; i++)
        {
            int tX = pTile.pos.x + brush.pos[i].x;
            int tY = pTile.pos.y + brush.pos[i].y;
            if (tX < 0 || tX >= MapBox.width || tY < 0 || tY >= MapBox.height)
                continue;
            WorldTile tTile = World.world.GetTileSimple(tX, tY);
            if (tTile.Type.ocean)
            {
                MapAction.removeLiquid(tTile);
                if (Randy.randomChance(0.15f))
                {
                    spawnBurst(tTile, "rain", pScale);
                }
            }
            if (tDamage)
            {
                if (tTile.top_type != null || tTile.Type.life)
                {
                    MapAction.decreaseTile(tTile, pDamage: false);
                }
                if (tTile.Type.lava)
                {
                    LavaHelper.removeLava(tTile);
                    spawnBurst(tTile, "lava", pScale);
                }
            }
            if (tTile.hasBuilding() && tTile.building.asset.can_be_damaged_by_tornado)
            {
                tTile.building.getHit(1f);
                tTile.building.addStatusEffect("burning");
            }
            if (tTile.isTemporaryFrozen())
            {
                tTile.unfreeze(10);
            }
            if (tTile.isOnFire())
            {
                tTile.stopFire();
            }

            tTile.startFire(pForce: true);
            tTile.doUnits(actor => actor.addStatusEffect("burning"));
        }
    }

    private void tornadoActionForce(WorldTile pTile)
    {
        World.world.applyForceOnTile(pTile, 10, 3f, pForceOut: false);
    }

    private static void spawnBurst(WorldTile pTile, string pType, float pScale)
    {
        if (World.world.drop_manager.getActiveIndex() <= 3000)
        {
            World.world.drop_manager.spawnParabolicDrop(pTile, pType, 0f, 0.62f, 104f * pScale, 0.7f, 23.5f * pScale);
        }
    }

    internal void shrink()
    {
        if (!isKilled())
        {
            float tScale = scale * 0.5f;
            if (tScale < 0.1f)
            {
                die();
            }
            else
            {
                resizeTornado(tScale);
            }
        }
    }

    internal void grow()
    {
        if (!isKilled())
        {
            float tScale = Mathf.Min(scale * 1.5f, 5f);
            if (tScale >= 5f)
            {
                AchievementLibrary.achievementTORNADO.check();
            }
            resizeTornado(tScale);
        }
    }

    internal bool split()
    {
        if (isKilled())
        {
            return false;
        }
        AchievementLibrary.achievementBabyTornado.check();
        float tNextScale = scale * 0.5f;
        if (tNextScale < 0.1f)
        {
            die();
            return true;
        }
        EffectsLibrary.spawnAtTile("magma_tornado", current_tile, tNextScale);
        resizeTornado(tNextScale);
        return true;
    }

    internal void resizeTornado(float pScale)
    {
        _target_scale = pScale;
    }

    public void startColorEffect(string pType = "red")
    {
        colorEffect = 0.3f;
        if (pType == "red")
        {
            colorMaterial = LibraryMaterials.instance.mat_damaged;
        }
        else if (pType == "white")
        {
            colorMaterial = LibraryMaterials.instance.mat_highlighted;
        }
        updateColorEffect(0f);
    }

    private void updateColorEffect(float pElapsed)
    {
        if (colorEffect != 0f)
        {
            colorEffect -= pElapsed;
            if (colorEffect < 0f)
            {
                colorEffect = 0f;
            }
        }
    }

    internal static void growTornados(WorldTile pTile)
    {
        resizeOnTile(pTile, "grow");
        for (int i = 0; i < pTile.neighboursAll.Length; i++)
        {
            resizeOnTile(pTile.neighboursAll[i], "grow");
        }
    }

    internal static void shrinkTornados(WorldTile pTile)
    {
        resizeOnTile(pTile, "shrink");
        for (int i = 0; i < pTile.neighboursAll.Length; i++)
        {
            resizeOnTile(pTile.neighboursAll[i], "shrink");
        }
    }

    internal static void resizeOnTile(WorldTile pTile, string direction)
    {
        foreach (BaseEffect tEffect in World.world.stack_effects.get("magma_tornado").getList())
        {
            if (tEffect.active && tEffect.current_tile == pTile)
            {
                MagmaTornadoEffect tTornado = tEffect as MagmaTornadoEffect;
                if (direction == "grow")
                {
                    tTornado.grow();
                }
                else
                {
                    tTornado.shrink();
                }
            }
        }
    }

    private void deathAnimation(float pElapsed)
    {
        if (scale > 0f)
        {
            updateChangeScale(pElapsed);
        }
        else
        {
            kill();
        }
    }

    public void die()
    {
        state = 2;
        resizeTornado(0f);
        removeTornadoFromTile();
    }

    internal void updateChangeScale(float pElapsed)
    {
        if (scale == _target_scale)
        {
            return;
        }
        if (scale < _target_scale)
        {
            startColorEffect();
        }
        else
        {
            startColorEffect("white");
        }
        if (scale > _target_scale)
        {
            setScale(scale - 0.2f * pElapsed);
            if (scale < _target_scale)
            {
                setScale(_target_scale);
            }
        }
        else
        {
            setScale(scale + 0.2f * pElapsed);
            if (scale > _target_scale)
            {
                setScale(_target_scale);
            }
        }
        if (scale <= 0.1f)
        {
            die();
        }
    }

    private void addTornadoToTile()
    {
        if (!_tornadoes_by_tiles.TryGetValue(current_tile, out var tEffects))
        {
            tEffects = UnsafeCollectionPool<HashSet<MagmaTornadoEffect>, MagmaTornadoEffect>.Get();
            _tornadoes_by_tiles.Add(current_tile, tEffects);
        }
        tEffects.Add(this);
    }

    private void removeTornadoFromTile()
    {
        if (_tornadoes_by_tiles.TryGetValue(current_tile, out var tEffects))
        {
            tEffects.Remove(this);
            if (tEffects.Count == 0)
            {
                UnsafeCollectionPool<HashSet<MagmaTornadoEffect>, MagmaTornadoEffect>.Release(tEffects);
                _tornadoes_by_tiles.Remove(current_tile);
            }
        }
    }

    public static HashSet<MagmaTornadoEffect> getTornadoesFromTile(WorldTile pTile)
    {
        if (!_tornadoes_by_tiles.TryGetValue(pTile, out var tEffects))
        {
            return null;
        }
        return tEffects;
    }

    public static void Clear()
    {
        foreach (HashSet<MagmaTornadoEffect> value in _tornadoes_by_tiles.Values)
        {
            UnsafeCollectionPool<HashSet<MagmaTornadoEffect>, MagmaTornadoEffect>.Release(value);
        }
        _tornadoes_by_tiles.Clear();
    }
}
