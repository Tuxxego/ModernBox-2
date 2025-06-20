using System;
using tools;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using ReflectionUtility;
using HarmonyLib;
using System.Text.RegularExpressions;
using Beebyte.Obfuscator;
using ai;
using ai.behaviours;
using NeoModLoader;
using NeoModLoader.General;

namespace ModernBox
{
    class KaijuTraits
    {


        public static void init()
        {

        ActorTraitGroupAsset Kaiju = new ActorTraitGroupAsset();
        Kaiju.id = "Kaiju";
        Kaiju.name = "trait_group_Kaiju";
        Kaiju.color = "#5EFFFF";
        AssetManager.trait_groups.add(Kaiju);
        LM.AddToCurrentLocale("trait_group_Kaiju", "Kaiju");



StatusAsset poweredGodzillaStatus = new StatusAsset();
poweredGodzillaStatus.id = "poweredGodzillaStatus";
poweredGodzillaStatus.duration = 100f;
poweredGodzillaStatus.path_icon = "ui/icons/iconPoweredGodzilla";
poweredGodzillaStatus.locale_id = "status_poweredGodzillaStatus";
poweredGodzillaStatus.locale_description = "status_poweredGodzillaStatus_desc";
poweredGodzillaStatus.action_on_receive = ApplyPoweredGodzilla;
poweredGodzillaStatus.action_finish = RemovePoweredGodzilla;
poweredGodzillaStatus.base_stats["armor"] = 20f;
poweredGodzillaStatus.base_stats["damage"] = 300f;
poweredGodzillaStatus.base_stats["multiplier_damage"] = 0.5f;
poweredGodzillaStatus.base_stats["multiplier_crit"] = 0.5f;
poweredGodzillaStatus.base_stats["scale"] = 0.05f;
poweredGodzillaStatus.base_stats["multiplier_attack_speed"] = 0.3f;
poweredGodzillaStatus.draw_light_area = true;
poweredGodzillaStatus.draw_light_size = 4f;
AssetManager.status.add(poweredGodzillaStatus);
LM.AddToCurrentLocale("status_poweredGodzillaStatus", "Godzilla's true power");
LM.AddToCurrentLocale("status_poweredGodzillaStatus_desc", "The King shall retain his throne");



            ActorTrait GodzillaPower = new ActorTrait();
            GodzillaPower.id = "Godzilla_Power";
            GodzillaPower.rarity = Rarity.R0_Normal;
            GodzillaPower.group_id = "Kaiju";
            GodzillaPower.unlocked_with_achievement = false;
            GodzillaPower.path_icon = "ui/icons/iconGodzillaPower";
            GodzillaPower.can_be_given = false;
            GodzillaPower.needs_to_be_explored = false;
            GodzillaPower.action_special_effect = (WorldAction)Delegate.Combine(GodzillaPower.action_special_effect, new WorldAction(GodzillaEssenseEffect));
            GodzillaPower.action_death = (WorldAction)Delegate.Combine(GodzillaPower.action_death, new WorldAction(GodzillaScrapsEffect));
           if (GodzillaPower.base_stats == null)
            GodzillaPower.base_stats = new BaseStats();
            GodzillaPower.base_stats.addTag("immunity_fire");
            AssetManager.traits.add(GodzillaPower);
            LM.AddToCurrentLocale("trait_Godzilla_Power", "Godzilla Power");
            LM.AddToCurrentLocale("trait_Godzilla_Power_info", "The King of Monsters. Earthquakes, Atomic Beams and an impenetrable defense");
            LM.AddToCurrentLocale("trait_Godzilla_Power_info_2", "The bestest trait, perhabs, the biggest trait, so yuge");




           StatusAsset poweredKingKongStatus = new StatusAsset();
poweredKingKongStatus.id = "poweredKingKongStatus";
poweredKingKongStatus.duration = 100f;
poweredKingKongStatus.path_icon = "ui/icons/iconPoweredKingKong";
poweredKingKongStatus.locale_id = "status_poweredKingKongStatus";
poweredKingKongStatus.locale_description = "status_poweredKingKongStatus_desc";
poweredKingKongStatus.action_on_receive = ApplyPoweredKingKong;
poweredKingKongStatus.action_finish = RemovePoweredKingKong;
poweredKingKongStatus.base_stats["armor"] = 30f;
poweredKingKongStatus.base_stats["damage"] = 300f;
poweredKingKongStatus.base_stats["multiplier_damage"] = 0.5f;
poweredKingKongStatus.base_stats["multiplier_crit"] = 0.5f;
poweredKingKongStatus.base_stats["scale"] = 0.1f;
poweredKingKongStatus.base_stats["multiplier_attack_speed"] = 0.3f;
poweredKingKongStatus.draw_light_area = true;
poweredKingKongStatus.draw_light_size = 4f;
AssetManager.status.add(poweredKingKongStatus);
LM.AddToCurrentLocale("status_poweredKingKongStatus", "Saiyan Beserker Kong");
LM.AddToCurrentLocale("status_poweredKingKongStatus_desc", "KingKong is powered up!");


            ActorTrait KingKongPower = new ActorTrait();
            KingKongPower.id = "KingKong_Power";
            KingKongPower.rarity = Rarity.R0_Normal;
            KingKongPower.group_id = "Kaiju";
            KingKongPower.path_icon = "ui/icons/iconKingKongPower";
            KingKongPower.can_be_given = false;
            KingKongPower.needs_to_be_explored=false;
            KingKongPower.action_special_effect = (WorldAction)Delegate.Combine(KingKongPower.action_special_effect, new WorldAction(KingKongEssenceEffect));
            KingKongPower.action_death = (WorldAction)Delegate.Combine(KingKongPower.action_death, new WorldAction(KingKongScrapsEffect));
            if (KingKongPower.base_stats == null)
    KingKongPower.base_stats = new BaseStats();
            KingKongPower.base_stats.addTag("immunity_fire");
            AssetManager.traits.add(KingKongPower);
            LM.AddToCurrentLocale("trait_KingKong_Power", "King Kong strenght");
            LM.AddToCurrentLocale("trait_KingKong_Power_info", "Extremely intelligent and gifted with great size, this beast can rule over all others");
            LM.AddToCurrentLocale("trait_KingKong_Power_info_2", "mhmmmm... monkey");




            StatusAsset poweredGhidorahStatus = new StatusAsset();
poweredGhidorahStatus.id = "poweredGhidorahStatus";
poweredGhidorahStatus.duration = 100f;
poweredGhidorahStatus.path_icon = "ui/icons/iconPoweredGhidorah";
poweredGhidorahStatus.locale_id = "status_poweredGhidorahStatus";
poweredGhidorahStatus.locale_description = "status_poweredGhidorahStatus_desc";
poweredGhidorahStatus.action_on_receive = ApplyPoweredGhidorah;
poweredGhidorahStatus.action_finish = RemovePoweredGhidorah;
poweredGhidorahStatus.base_stats["armor"] = 30f;
poweredGhidorahStatus.base_stats["damage"] = 300f;
poweredGhidorahStatus.base_stats["multiplier_damage"] = 0.5f;
poweredGhidorahStatus.base_stats["multiplier_crit"] = 0.5f;
poweredGhidorahStatus.base_stats["scale"] = 0.2f;
poweredGhidorahStatus.base_stats["multiplier_attack_speed"] = 0.3f;
poweredGhidorahStatus.draw_light_area = true;
poweredGhidorahStatus.draw_light_size = 4f;
AssetManager.status.add(poweredGhidorahStatus);
LM.AddToCurrentLocale("status_poweredGhidorahStatus", "Guidorah Ultimate form");
LM.AddToCurrentLocale("status_poweredGhidorahStatus_desc", "THE ENTIRE WORLD SHALL BE DEVOURED");

            ActorTrait GhidorahPower = new ActorTrait();
            GhidorahPower.id = "Ghidorah_Power";
            GhidorahPower.rarity = Rarity.R0_Normal;
            GhidorahPower.group_id = "Kaiju";
            GhidorahPower.path_icon = "ui/icons/iconGhidorahPower";
            GhidorahPower.can_be_given = false;
            GhidorahPower.needs_to_be_explored=false;
            GhidorahPower.action_special_effect = (WorldAction)Delegate.Combine(GhidorahPower.action_special_effect, new WorldAction(GhidorahEssenceEffect));
if (GhidorahPower.base_stats == null)
    GhidorahPower.base_stats = new BaseStats();
            GhidorahPower.base_stats.addTag("immunity_fire");
            GhidorahPower.action_death = (WorldAction)Delegate.Combine(GhidorahPower.action_death, new WorldAction(GhidorahScrapsEffect));
            AssetManager.traits.add(GhidorahPower);
            LM.AddToCurrentLocale("trait_Ghidorah_Power", "Ghidorah's overwhelming power");
            LM.AddToCurrentLocale("trait_Ghidorah_Power_info", "Earth, Kaijus, Monsters, Beasts, all but food to be consumed");
            LM.AddToCurrentLocale("trait_Ghidorah_Power_info_2", "Each head thinks the other is sus for stealing food");









StatusAsset poweredRodanStatus = new StatusAsset();
poweredRodanStatus.id = "poweredRodanStatus";
poweredRodanStatus.duration = 100f;
poweredRodanStatus.path_icon = "ui/icons/iconPoweredRodan";
poweredRodanStatus.locale_id = "status_poweredRodanStatus";
poweredRodanStatus.locale_description = "status_poweredRodanStatus_desc";
poweredRodanStatus.action_on_receive = ApplyPoweredRodan;
poweredRodanStatus.action_finish = RemovePoweredRodan;
poweredRodanStatus.base_stats["armor"] = 30f;
poweredRodanStatus.base_stats["damage"] = 300f;
poweredRodanStatus.base_stats["multiplier_damage"] = 0.5f;
poweredRodanStatus.base_stats["multiplier_crit"] = 0.5f;
poweredRodanStatus.base_stats["scale"] = 0.2f;
poweredRodanStatus.base_stats["multiplier_attack_speed"] = 0.3f;
poweredRodanStatus.draw_light_area = true;
poweredRodanStatus.draw_light_size = 4f;
AssetManager.status.add(poweredRodanStatus);
LM.AddToCurrentLocale("status_poweredRodanStatus", "Rodan Ultimate form");
LM.AddToCurrentLocale("status_poweredRodanStatus_desc", "BURN BABY, BURN");

            ActorTrait RodanPower = new ActorTrait();
            RodanPower.id = "Rodan_Power";
            RodanPower.rarity = Rarity.R0_Normal;
            RodanPower.group_id = "Kaiju";
            RodanPower.path_icon = "ui/icons/iconRodanPower";
            RodanPower.can_be_given = false;
            RodanPower.needs_to_be_explored=false;
            RodanPower.action_special_effect = (WorldAction)Delegate.Combine(RodanPower.action_special_effect, new WorldAction(RodanEssenceEffect));
if (RodanPower.base_stats == null)
    RodanPower.base_stats = new BaseStats();
            RodanPower.base_stats.addTag("immunity_fire");
            RodanPower.action_death = (WorldAction)Delegate.Combine(RodanPower.action_death, new WorldAction(RodanScrapsEffect));
            AssetManager.traits.add(RodanPower);
            LM.AddToCurrentLocale("trait_Rodan_Power", "Rodan's fiery essence");
            LM.AddToCurrentLocale("trait_Rodan_Power_info", "From the deep down magma to the surface, the king of the skies shall oversee it all");
            LM.AddToCurrentLocale("trait_Rodan_Power_info_2", "This is what happens when you give tacobell to a iguana");




StatusAsset poweredMechagodzillaStatus = new StatusAsset();
poweredMechagodzillaStatus.id = "poweredMechagodzillaStatus";
poweredMechagodzillaStatus.duration = 100f;
poweredMechagodzillaStatus.path_icon = "ui/icons/DamagedMechagodzilla";
poweredMechagodzillaStatus.locale_id = "status_poweredMechagodzillaStatus";
poweredMechagodzillaStatus.locale_description = "status_poweredMechagodzillaStatus_desc";
poweredMechagodzillaStatus.action_on_receive = ApplyPoweredMechagodzilla;
poweredMechagodzillaStatus.action_finish = RemovePoweredMechagodzilla;
poweredMechagodzillaStatus.base_stats["armor"] = -30f;
poweredMechagodzillaStatus.base_stats["damage"] = 3000f;
poweredMechagodzillaStatus.base_stats["multiplier_damage"] = 2f;
poweredMechagodzillaStatus.base_stats["multiplier_crit"] = 0.5f;
poweredMechagodzillaStatus.base_stats["scale"] = 0.2f;
poweredMechagodzillaStatus.base_stats["multiplier_attack_speed"] = 2f;
poweredMechagodzillaStatus.draw_light_area = true;
poweredMechagodzillaStatus.draw_light_size = 4f;
AssetManager.status.add(poweredMechagodzillaStatus);
LM.AddToCurrentLocale("status_poweredMechagodzillaStatus", "Mechagodzilla Ultimate form");
LM.AddToCurrentLocale("status_poweredMechagodzillaStatus_desc", "BURN BABY, BURN");

            ActorTrait MechagodzillaPower = new ActorTrait();
            MechagodzillaPower.id = "Mechagodzilla_Power";
            MechagodzillaPower.rarity = Rarity.R0_Normal;
            MechagodzillaPower.group_id = "Kaiju";
            MechagodzillaPower.path_icon = "ui/icons/Mechagodzilla";
            MechagodzillaPower.can_be_given = false;
            MechagodzillaPower.needs_to_be_explored=false;
            MechagodzillaPower.action_special_effect = (WorldAction)Delegate.Combine(MechagodzillaPower.action_special_effect, new WorldAction(MechagodzillaEssenceEffect));
if (MechagodzillaPower.base_stats == null)
    MechagodzillaPower.base_stats = new BaseStats();
            MechagodzillaPower.base_stats.addTag("immunity_fire");
            MechagodzillaPower.action_death = (WorldAction)Delegate.Combine(MechagodzillaPower.action_death, new WorldAction(MechagodzillaScrapsEffect));
            AssetManager.traits.add(MechagodzillaPower);
            LM.AddToCurrentLocale("trait_Mechagodzilla_Power", "Mechagodzilla's fiery essence");
            LM.AddToCurrentLocale("trait_Mechagodzilla_Power_info", "From the deep down magma to the surface, the king of the skies shall oversee it all");
            LM.AddToCurrentLocale("trait_Mechagodzilla_Power_info_2", "This is what happens when you give tacobell to a iguana");




            
        }









public static Dictionary<long, ActorAsset> originalGodzillaAssets = new Dictionary<long, ActorAsset>();

public static Dictionary<long, ActorAsset> originalKingKongAssets = new Dictionary<long, ActorAsset>();

public static Dictionary<long, ActorAsset> originalGhidorahAssets = new Dictionary<long, ActorAsset>();

public static Dictionary<long, ActorAsset> originalRodanAssets = new Dictionary<long, ActorAsset>();





  public static ActorAsset CreateRenderingProxyAsset(ActorAsset original, string customTexturePath, string transformationName)
    {
        var proxy = new ActorAsset();

        proxy.id = original.id + "_proxy_" + Guid.NewGuid().ToString();
        proxy.name_locale = original.name_locale;
        proxy.icon = original.icon;
        proxy.actor_size = original.actor_size;
        proxy.animation_walk = original.animation_walk;
        proxy.animation_idle = original.animation_idle;
        proxy.animation_swim = original.animation_swim;
        proxy.path_icon = original.path_icon;
        proxy.has_avatar_prefab = false;
        proxy.has_override_avatar_frames = true;
        proxy.get_override_avatar_frames = (Actor pActor) => new Sprite[] { SpriteTextureLoader.getSprite("actors/Avatars/" + transformationName + "_avatar") };
        proxy.inspect_avatar_scale = original.inspect_avatar_scale;
        proxy.inspect_avatar_offset_y = original.inspect_avatar_offset_y;
        proxy.can_flip = true;
        proxy.check_flip = (BaseSimObject _, WorldTile _) => true;

        var textureAsset = new ActorTextureSubAsset(customTexturePath, false);
        textureAsset.texture_path_main = customTexturePath + "main";
        textureAsset.texture_path_base = customTexturePath;
        proxy.texture_asset = textureAsset;

        proxy.base_stats = original.base_stats;
        proxy.default_attack = original.default_attack;
        proxy.job = original.job;
        proxy.job_citizen = original.job_citizen;
        proxy.job_kingdom = original.job_kingdom;
        proxy.job_baby = original.job_baby;
        proxy.job_attacker = original.job_attacker;
        proxy.traits = original.traits;
        proxy.decision_ids = original.decision_ids;
        proxy.has_advanced_textures = false;
        proxy.use_phenotypes = false;
        proxy.can_be_inspected = true;
        proxy.death_animation_angle = true;
        proxy.animation_speed_based_on_walk_speed = false;
        proxy.disable_jump_animation = true;
        proxy.can_be_moved_by_powers = true;
        proxy.can_be_killed_by_stuff = true;
		proxy.can_be_killed_by_life_eraser = true;
		proxy.can_attack_buildings = true;
		proxy.can_be_hurt_by_powers = true;
		proxy.effect_damage = true;
		proxy.can_be_cloned = false;

        return proxy;
    }






    public static bool ApplyPoweredGodzilla(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (!originalGodzillaAssets.ContainsKey(actor.data.id))
            originalGodzillaAssets[actor.data.id] = actor.asset;

        var proxyAsset = CreateRenderingProxyAsset(actor.asset, "actors/PoweredGodzilla/", "PoweredGodzilla");
        actor.asset = proxyAsset;

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }

    public static bool RemovePoweredGodzilla(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (originalGodzillaAssets.TryGetValue(actor.data.id, out var originalAsset)) {
            actor.asset = originalAsset;
            originalGodzillaAssets.Remove(actor.data.id);
        }

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }





public static bool GodzillaEssenseEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor godzilla = pSelf.a;
    bool result = false;
    result |= GodzillaStatusOnLowHealthEffect(godzilla);
    result |= GodzillaBeamEffect(pSelf, pTile);
    return result;
}


public static bool GodzillaStatusOnLowHealthEffect(Actor actor)
{
    if (actor == null || !actor.isAlive())
        return false;
    float healthRatio = actor.getHealthRatio();
    if (healthRatio < 0.5f && !actor.hasStatus("poweredGodzillaStatus"))
    {
        actor.addStatusEffect("poweredGodzillaStatus", 100f);
        return true;
    }
    return false;
}



public static bool GodzillaBeamEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor godzilla = pSelf.a;
    if (!godzilla.isAlive())
        return false;

    if (!Randy.randomChance(0.3f))
        return false;

    float maxRange = 50f;
    Actor target = null;
    float closestDist = float.MaxValue;

    foreach (var other in World.world.units)
    {
        if (other == null || !other.isAlive() || other == godzilla)
            continue;
        if (other.kingdom == null || godzilla.kingdom == null || !godzilla.kingdom.isEnemy(other.kingdom))
            continue;

        float dist = Vector2.Distance(godzilla.current_position, other.current_position);
        if (dist < maxRange && dist < closestDist)
        {
            closestDist = dist;
            target = other;
        }
    }

    if (target == null)
        return false;

    Vector3 start = godzilla.current_position;
    Vector3 end = target.current_position;
    Vector3 dir = (end - start).normalized;
    float distToTarget = Vector3.Distance(start, end);

    Vector3 attackVector = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, distToTarget);
    Vector3 startProjectile = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, godzilla.stats["size"]);
    startProjectile.y += 0.5f;

    World.world.projectiles.spawn(godzilla, null, "AtomBeam", startProjectile, attackVector);
    godzilla.punchTargetAnimation(attackVector, true, false, 50f);

    return true;
}


public static bool GodzillaScrapsEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;
    if (selfActor == null) return false;

    WorldTile targetTile = selfActor.current_tile;
    if (targetTile != null)
    {
        World.world.buildings.addBuilding("Godzila_remains", targetTile, false, false, BuildPlacingType.New);

        for (int i = 0; i < 12; i++)
        {
            World.world.units.createNewUnit(
                "Iguanazilla",
                targetTile,
                pMiracleSpawn: false,
                selfActor.position_height,
                null, null,
                pSpawnWithItems: false,
                pAdultAge: false
            );
        }
        return true;
    }
    return false;
}














    public static bool ApplyPoweredKingKong(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (!originalGodzillaAssets.ContainsKey(actor.data.id))
            originalGodzillaAssets[actor.data.id] = actor.asset;

        var proxyAsset = CreateRenderingProxyAsset(actor.asset, "actors/AngryKingKong/", "AngryKingKong");
        actor.asset = proxyAsset;

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }

    public static bool RemovePoweredKingKong(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (originalGodzillaAssets.TryGetValue(actor.data.id, out var originalAsset)) {
            actor.asset = originalAsset;
            originalGodzillaAssets.Remove(actor.data.id);
        }

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }



public static bool KingKongEssenceEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor KingKong = pSelf.a;
    bool result = false;
    result |= KingKongStatusOnLowHealthEffect(KingKong);
    result |= KingKongBeamEffect(pSelf, pTile);
    return result;
}


public static bool KingKongStatusOnLowHealthEffect(Actor actor)
{
    if (actor == null || !actor.isAlive())
        return false;
    float healthRatio = actor.getHealthRatio();
    if (healthRatio < 0.5f && !actor.hasStatus("poweredKingKongStatus"))
    {
        actor.addStatusEffect("poweredKingKongStatus", 100f);
        return true;
    }
    return false;
}



public static bool KingKongBeamEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor KingKong = pSelf.a;
    if (!KingKong.isAlive())
        return false;

    if (!Randy.randomChance(0.3f))
        return false;

    float maxRange = 50f;
    Actor target = null;
    float closestDist = float.MaxValue;

    foreach (var other in World.world.units)
    {
        if (other == null || !other.isAlive() || other == KingKong)
            continue;
        if (other.kingdom == null || KingKong.kingdom == null || !KingKong.kingdom.isEnemy(other.kingdom))
            continue;

        float dist = Vector2.Distance(KingKong.current_position, other.current_position);
        if (dist < maxRange && dist < closestDist)
        {
            closestDist = dist;
            target = other;
        }
    }

    if (target == null)
        return false;

    Vector3 start = KingKong.current_position;
    Vector3 end = target.current_position;
    Vector3 dir = (end - start).normalized;
    float distToTarget = Vector3.Distance(start, end);

    Vector3 attackVector = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, distToTarget);
    Vector3 startProjectile = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, KingKong.stats["size"]);
    startProjectile.y += 0.5f;

    World.world.projectiles.spawn(KingKong, null, "BigBigMassiveBoulder", startProjectile, attackVector);
    KingKong.punchTargetAnimation(attackVector, true, false, 50f);

    return true;
}


public static bool KingKongScrapsEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;
    if (selfActor == null) return false;

    WorldTile targetTile = selfActor.current_tile;
    if (targetTile != null)
    {
        World.world.buildings.addBuilding("KingKong_remains", targetTile, false, false, BuildPlacingType.New);

        for (int i = 0; i < 12; i++)
        {
            World.world.units.createNewUnit(
                "Kong",
                targetTile,
                pMiracleSpawn: false,
                selfActor.position_height,
                null, null,
                pSpawnWithItems: false,
                pAdultAge: false
            );
        }
        return true;
    }
    return false;
}















    public static bool ApplyPoweredGhidorah(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (!originalGodzillaAssets.ContainsKey(actor.data.id))
            originalGodzillaAssets[actor.data.id] = actor.asset;

        var proxyAsset = CreateRenderingProxyAsset(actor.asset, "actors/FinalBossGhidorah/", "FinalBossGhidorah");
        actor.asset = proxyAsset;

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }

    public static bool RemovePoweredGhidorah(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (originalGodzillaAssets.TryGetValue(actor.data.id, out var originalAsset)) {
            actor.asset = originalAsset;
            originalGodzillaAssets.Remove(actor.data.id);
        }

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }




public static bool GhidorahEssenceEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor Ghidorah = pSelf.a;
    bool result = false;
    result |= GhidorahStatusOnLowHealthEffect(Ghidorah);
    result |= GhidorahBeamEffect(pSelf, pTile);
    return result;
}


public static bool GhidorahStatusOnLowHealthEffect(Actor actor)
{
    if (actor == null || !actor.isAlive())
        return false;
    float healthRatio = actor.getHealthRatio();
    if (healthRatio < 0.5f && !actor.hasStatus("poweredGhidorahStatus"))
    {
        actor.addStatusEffect("poweredGhidorahStatus", 100f);
        return true;
    }
    return false;
}



public static bool GhidorahBeamEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor Ghidorah = pSelf.a;
    if (!Ghidorah.isAlive())
        return false;

    if (!Randy.randomChance(0.3f))
        return false;

    float maxRange = 50f;
    Actor target = null;
    float closestDist = float.MaxValue;

    foreach (var other in World.world.units)
    {
        if (other == null || !other.isAlive() || other == Ghidorah)
            continue;
        if (other.kingdom == null || Ghidorah.kingdom == null || !Ghidorah.kingdom.isEnemy(other.kingdom))
            continue;

        float dist = Vector2.Distance(Ghidorah.current_position, other.current_position);
        if (dist < maxRange && dist < closestDist)
        {
            closestDist = dist;
            target = other;
        }
    }

    if (target == null)
        return false;

    Vector3 start = Ghidorah.current_position;
    Vector3 end = target.current_position;
    Vector3 dir = (end - start).normalized;
    float distToTarget = Vector3.Distance(start, end);

    Vector3 attackVector = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, distToTarget);
    Vector3 startProjectile = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, Ghidorah.stats["size"]);
    startProjectile.y += 0.5f;

    World.world.projectiles.spawn(Ghidorah, null, "ElectroBeam", startProjectile, attackVector);
    Ghidorah.punchTargetAnimation(attackVector, true, false, 50f);

    return true;
}


public static bool GhidorahScrapsEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;
    if (selfActor == null) return false;

    WorldTile targetTile = selfActor.current_tile;
    if (targetTile != null)
    {
        World.world.buildings.addBuilding("Ghidorah_remains", targetTile, false, false, BuildPlacingType.New);

        for (int i = 0; i < 12; i++)
        {
            World.world.units.createNewUnit(
                "Hydraflians",
                targetTile,
                pMiracleSpawn: false,
                selfActor.position_height,
                null, null,
                pSpawnWithItems: false,
                pAdultAge: false
            );
        }
        return true;
    }
    return false;
}













    public static bool ApplyPoweredRodan(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (!originalGodzillaAssets.ContainsKey(actor.data.id))
            originalGodzillaAssets[actor.data.id] = actor.asset;

        var proxyAsset = CreateRenderingProxyAsset(actor.asset, "actors/FieryRodan/", "FieryRodan");
        actor.asset = proxyAsset;

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }

    public static bool RemovePoweredRodan(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (originalGodzillaAssets.TryGetValue(actor.data.id, out var originalAsset)) {
            actor.asset = originalAsset;
            originalGodzillaAssets.Remove(actor.data.id);
        }

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }




public static bool RodanEssenceEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor Rodan = pSelf.a;
    bool result = false;
    result |= RodanStatusOnLowHealthEffect(Rodan);
    result |= RodanBeamEffect(pSelf, pTile);
    return result;
}



public static bool RodanStatusOnLowHealthEffect(Actor actor)
{
    if (actor == null || !actor.isAlive())
        return false;
    float healthRatio = actor.getHealthRatio();
    if (healthRatio < 0.5f && !actor.hasStatus("poweredRodanStatus"))
    {
        actor.addStatusEffect("poweredRodanStatus", 100f);
        return true;
    }
    return false;
}



public static bool RodanBeamEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor Rodan = pSelf.a;
    if (!Rodan.isAlive())
        return false;

    if (!Randy.randomChance(0.3f))
        return false;

    float maxRange = 50f;
    Actor target = null;
    float closestDist = float.MaxValue;

    foreach (var other in World.world.units)
    {
        if (other == null || !other.isAlive() || other == Rodan)
            continue;
        if (other.kingdom == null || Rodan.kingdom == null || !Rodan.kingdom.isEnemy(other.kingdom))
            continue;

        float dist = Vector2.Distance(Rodan.current_position, other.current_position);
        if (dist < maxRange && dist < closestDist)
        {
            closestDist = dist;
            target = other;
        }
    }

    if (target == null)
        return false;

    Vector3 start = Rodan.current_position;
    Vector3 end = target.current_position;
    Vector3 dir = (end - start).normalized;
    float distToTarget = Vector3.Distance(start, end);

    Vector3 attackVector = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, distToTarget);
    Vector3 startProjectile = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, Rodan.stats["size"]);
    startProjectile.y += 0.5f;

    World.world.projectiles.spawn(Rodan, null, "FieryShock", startProjectile, attackVector);
    Rodan.punchTargetAnimation(attackVector, true, false, 50f);

    return true;
}



public static bool RodanScrapsEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;
    if (selfActor == null) return false;

    WorldTile targetTile = selfActor.current_tile;
    if (targetTile != null)
    {
        World.world.buildings.addBuilding("Rodan_remains", targetTile, false, false, BuildPlacingType.New);

        for (int i = 0; i < 12; i++)
        {
            World.world.units.createNewUnit(
                "Radon",
                targetTile,
                pMiracleSpawn: false,
                selfActor.position_height,
                null, null,
                pSpawnWithItems: false,
                pAdultAge: false
            );
        }
        return true;
    }
    return false;
}





















                public static bool ApplyPoweredMechagodzilla(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (!originalGodzillaAssets.ContainsKey(actor.data.id))
            originalGodzillaAssets[actor.data.id] = actor.asset;

        var proxyAsset = CreateRenderingProxyAsset(actor.asset, "actors/DamagedMechagodzilla/", "DamagedMechagodzilla");
        actor.asset = proxyAsset;

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }

    public static bool RemovePoweredMechagodzilla(BaseSimObject pSelf, WorldTile pTile = null)
    {
        var actor = pSelf as Actor;
        if (actor == null) return false;

        if (originalGodzillaAssets.TryGetValue(actor.data.id, out var originalAsset)) {
            actor.asset = originalAsset;
            originalGodzillaAssets.Remove(actor.data.id);
        }

        actor.clearGraphicsFully();
        actor.dirty_sprite_main = true;
        actor.checkAnimationContainer();
        return true;
    }




public static bool MechagodzillaEssenceEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor Mechagodzilla = pSelf.a;
    bool result = false;
    result |= MechagodzillaStatusOnLowHealthEffect(Mechagodzilla);
    result |= MechagodzillaBeamEffect(pSelf, pTile);
    return result;
}



public static bool MechagodzillaStatusOnLowHealthEffect(Actor actor)
{
    if (actor == null || !actor.isAlive())
        return false;
    float healthRatio = actor.getHealthRatio();
    if (healthRatio < 0.5f && !actor.hasStatus("poweredMechagodzillaStatus"))
    {
        actor.addStatusEffect("poweredMechagodzillaStatus", 100f);
        return true;
    }
    return false;
}



public static bool MechagodzillaBeamEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    if (pSelf == null || !pSelf.isActor())
        return false;

    Actor Mechagodzilla = pSelf.a;
    if (!Mechagodzilla.isAlive())
        return false;

    if (!Randy.randomChance(0.3f))
        return false;

    float maxRange = 50f;
    Actor target = null;
    float closestDist = float.MaxValue;

    foreach (var other in World.world.units)
    {
        if (other == null || !other.isAlive() || other == Mechagodzilla)
            continue;
        if (other.kingdom == null || Mechagodzilla.kingdom == null || !Mechagodzilla.kingdom.isEnemy(other.kingdom))
            continue;

        float dist = Vector2.Distance(Mechagodzilla.current_position, other.current_position);
        if (dist < maxRange && dist < closestDist)
        {
            closestDist = dist;
            target = other;
        }
    }

    if (target == null)
        return false;

    Vector3 start = Mechagodzilla.current_position;
    Vector3 end = target.current_position;
    Vector3 dir = (end - start).normalized;
    float distToTarget = Vector3.Distance(start, end);

    Vector3 attackVector = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, distToTarget);
    Vector3 startProjectile = Toolbox.getNewPoint(start.x, start.y, end.x, end.y, Mechagodzilla.stats["size"]);
    startProjectile.y += 0.5f;

    World.world.projectiles.spawn(Mechagodzilla, null, "ElectroBeam", startProjectile, attackVector);
    Mechagodzilla.punchTargetAnimation(attackVector, true, false, 50f);

    return true;
}



public static bool MechagodzillaScrapsEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;
    if (selfActor == null) return false;

    WorldTile targetTile = selfActor.current_tile;
    if (targetTile != null)
    {
        World.world.buildings.addBuilding("Mechagodzilla_remains", targetTile, false, false, BuildPlacingType.New);

        for (int i = 0; i < 12; i++)
        {
            World.world.units.createNewUnit(
                "Guidorahhead",
                targetTile,
                pMiracleSpawn: false,
                selfActor.position_height,
                null, null,
                pSpawnWithItems: false,
                pAdultAge: false
            );
        }
        return true;
    }
    return false;
}













    }
}
