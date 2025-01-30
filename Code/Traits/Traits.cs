//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using ReflectionUtility;
using HarmonyLib;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using life;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Config;
using System.Reflection;
using UnityEngine.Tilemaps;
using System.IO;
using NCMS;
using Newtonsoft.Json;
using M2;
using DG.Tweening;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using System.Reflection.Emit;
using UnityEngine.Purchasing.MiniJSON;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;
using UnityEngine.CrashReportHandler;
using System.IO.Compression;
using Beebyte.Obfuscator;
using ai;
using ai.behaviours;
using EpPathFinding.cs;
using life.taxi;
using SleekRender;
using tools;
using tools.debug;
using UnityEngine.EventSystems;
using WorldBoxConsole;
using UnityEngine.UI;
using static TopTileLibrary;
using pathfinding;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Assertions.Must;
using Random=UnityEngine.Random;
 
namespace M2
{
    class Traits
    {
        //Traits
        public static void init()
        { 
 

		 
		 ActorTrait Jet= new ActorTrait();
         Jet.id = "Jet";
         Jet.path_icon = "ui/Icons/Plane";
         Jet.type = TraitType.Negative;
         Jet.group_id = MBTraitGroup.ModernBox;
         Jet.can_be_cured = false;
         Jet.needs_to_be_explored = false;
         Jet.can_be_given = false;
         Jet.can_be_removed = false;
         Jet.only_active_on_era_flag = false;
         Jet.era_active_night = false;
         Jet.era_active_moon = false;
         Jet.birth = 0.0f;
         Jet.inherit = 0.0f;
         Jet.base_stats[S.fertility] = 0.0f;
         Jet.base_stats[S.max_children] = 0f;
         Jet.base_stats[S.max_age] = 0f;
         Jet.base_stats[S.attack_speed] = 0;
         Jet.base_stats[S.damage] = 0;
         Jet.base_stats[S.speed] = 0f;
         Jet.base_stats[S.health] = 0;
         Jet.base_stats[S.accuracy] = 0f;
         Jet.base_stats[S.range] = 0;
         Jet.base_stats[S.armor] = 0;
         Jet.base_stats[S.scale] = 0.0f;
         Jet.base_stats[S.dodge] = 0f;
         Jet.base_stats[S.targets] = 0f;
         Jet.base_stats[S.critical_chance] = 0.0f;
         Jet.base_stats[S.knockback] = 0f;
         Jet.base_stats[S.knockback_reduction] = 0f;
         Jet.base_stats[S.intelligence] = 0;
         Jet.base_stats[S.warfare] = 0;
         Jet.base_stats[S.diplomacy] = 0;
         Jet.base_stats[S.stewardship] = 0;
         Jet.base_stats[S.opinion] = 0f;
         Jet.base_stats[S.loyalty_traits] = 0f;
         Jet.base_stats[S.cities] = 0;
         Jet.base_stats[S.zone_range] = 0;
         AssetManager.traits.add(Jet);
         addTraitToLocalizedLibrary(Jet.id, "Fly through the sky...");
         PlayerConfig.unlockTrait("Jet");
		 
		 ActorTrait Unitpotential= new ActorTrait();
         Unitpotential.id = "Unitpotential";
         Unitpotential.path_icon = "ui/Icons/UnitpotentialIcon";
         Unitpotential.action_death = (WorldAction)Delegate.Combine(Unitpotential.action_death, new WorldAction(scrapsEffect));
         Unitpotential.action_special_effect = (WorldAction)Delegate.Combine(Unitpotential.action_special_effect, new WorldAction(UnitpotentialEffect));
         Unitpotential.type = TraitType.Negative;
         Unitpotential.group_id = MBTraitGroup.ModernBox;
         Unitpotential.can_be_cured = false;
         Unitpotential.needs_to_be_explored = false;
         Unitpotential.can_be_given = false;
         Unitpotential.can_be_removed = false;
         Unitpotential.only_active_on_era_flag = false;
         Unitpotential.era_active_night = false;
         Unitpotential.era_active_moon = false;
         Unitpotential.birth = 0.0f;
         Unitpotential.inherit = 0.0f;
         Unitpotential.base_stats[S.fertility] = -100f;
         Unitpotential.base_stats[S.max_children] = 0f;
         Unitpotential.base_stats[S.max_age] = 0f;
         Unitpotential.base_stats[S.attack_speed] = 0;
         Unitpotential.base_stats[S.damage] = 0;
         Unitpotential.base_stats[S.speed] = 0f;
         Unitpotential.base_stats[S.health] = 0;
         Unitpotential.base_stats[S.accuracy] = 0f;
         Unitpotential.base_stats[S.range] = 0;
         Unitpotential.base_stats[S.armor] = 0;
         Unitpotential.base_stats[S.scale] = 0.0f;
         Unitpotential.base_stats[S.dodge] = 0f;
         Unitpotential.base_stats[S.targets] = 0f;
         Unitpotential.base_stats[S.critical_chance] = 0.0f;
         Unitpotential.base_stats[S.knockback] = 0f;
         Unitpotential.base_stats[S.knockback_reduction] = 0f;
         Unitpotential.base_stats[S.intelligence] = 0;
         Unitpotential.base_stats[S.warfare] = 0;
         Unitpotential.base_stats[S.diplomacy] = 0;
         Unitpotential.base_stats[S.stewardship] = 0;
         Unitpotential.base_stats[S.opinion] = 0f;
         Unitpotential.base_stats[S.loyalty_traits] = 0f;
         Unitpotential.base_stats[S.cities] = 0;
         Unitpotential.base_stats[S.zone_range] = 0;
         AssetManager.traits.add(Unitpotential);
         addTraitToLocalizedLibrary(Unitpotential.id, "Allows expanded unit roster for civs. Cool stuff");
         PlayerConfig.unlockTrait("Unitpotential");

		 ActorTrait MIRVBoat= new ActorTrait();
         MIRVBoat.id = "MIRVBoat";
         MIRVBoat.path_icon = "ui/Icons/Boat";
         MIRVBoat.type = TraitType.Negative;
         MIRVBoat.group_id = MBTraitGroup.ModernBox;
         MIRVBoat.can_be_cured = false;
         MIRVBoat.needs_to_be_explored = false;
         MIRVBoat.can_be_given = false;
         MIRVBoat.can_be_removed = false;
         MIRVBoat.only_active_on_era_flag = false;
         MIRVBoat.era_active_night = false;
         MIRVBoat.era_active_moon = false;
         MIRVBoat.birth = 0.0f;
         MIRVBoat.inherit = 0.0f;
         MIRVBoat.base_stats[S.fertility] = 0.0f;
         MIRVBoat.base_stats[S.max_children] = 0f;
         MIRVBoat.base_stats[S.max_age] = 0f;
         MIRVBoat.base_stats[S.attack_speed] = 0;
         MIRVBoat.base_stats[S.damage] = 0;
         MIRVBoat.base_stats[S.speed] = 0f;
         MIRVBoat.base_stats[S.health] = 0;
         MIRVBoat.base_stats[S.accuracy] = 0f;
         MIRVBoat.base_stats[S.range] = 0;
         MIRVBoat.base_stats[S.armor] = 0;
         MIRVBoat.base_stats[S.scale] = 0.0f;
         MIRVBoat.base_stats[S.dodge] = 0f;
         MIRVBoat.base_stats[S.targets] = 0f;
         MIRVBoat.base_stats[S.critical_chance] = 0.0f;
         MIRVBoat.base_stats[S.knockback] = 0f;
         MIRVBoat.base_stats[S.knockback_reduction] = 0f;
         MIRVBoat.base_stats[S.intelligence] = 0;
         MIRVBoat.base_stats[S.warfare] = 0;
         MIRVBoat.base_stats[S.diplomacy] = 0;
         MIRVBoat.base_stats[S.stewardship] = 0;
         MIRVBoat.base_stats[S.opinion] = 0f;
         MIRVBoat.base_stats[S.loyalty_traits] = 0f;
         MIRVBoat.base_stats[S.cities] = 0;
         MIRVBoat.base_stats[S.zone_range] = 0;
         AssetManager.traits.add(MIRVBoat);
         addTraitToLocalizedLibrary(MIRVBoat.id, "He's a armored boy");
         PlayerConfig.unlockTrait("MIRVBoat");
 
 		 ActorTrait Helicopter= new ActorTrait();
         Helicopter.id = "Helicopter";
         Helicopter.path_icon = "ui/Icons/Heli";
         Helicopter.type = TraitType.Negative;
         Helicopter.group_id = MBTraitGroup.ModernBox;
         Helicopter.can_be_cured = false;
         Helicopter.needs_to_be_explored = false;
         Helicopter.can_be_given = false;
         Helicopter.can_be_removed = false;
         Helicopter.only_active_on_era_flag = false;
         Helicopter.era_active_night = false;
         Helicopter.era_active_moon = false;
         Helicopter.birth = 0.0f;
         Helicopter.inherit = 0.0f;
         Helicopter.base_stats[S.fertility] = 0.0f;
         Helicopter.base_stats[S.max_children] = 0f;
         Helicopter.base_stats[S.max_age] = 0f;
         Helicopter.base_stats[S.attack_speed] = 0;
         Helicopter.base_stats[S.damage] = 0;
         Helicopter.base_stats[S.speed] = 0f;
         Helicopter.base_stats[S.health] = 0;
         Helicopter.base_stats[S.accuracy] = 0f;
         Helicopter.base_stats[S.range] = 0;
         Helicopter.base_stats[S.armor] = 0;
         Helicopter.base_stats[S.scale] = 0.0f;
         Helicopter.base_stats[S.dodge] = 0f;
         Helicopter.base_stats[S.targets] = 0f;
         Helicopter.base_stats[S.critical_chance] = 0.0f;
         Helicopter.base_stats[S.knockback] = 0f;
         Helicopter.base_stats[S.knockback_reduction] = 0f;
         Helicopter.base_stats[S.intelligence] = 0;
         Helicopter.base_stats[S.warfare] = 0;
         Helicopter.base_stats[S.diplomacy] = 0;
         Helicopter.base_stats[S.stewardship] = 0;
         Helicopter.base_stats[S.opinion] = 0f;
         Helicopter.base_stats[S.loyalty_traits] = 0f;
         Helicopter.base_stats[S.cities] = 0;
         Helicopter.base_stats[S.zone_range] = 0;
         AssetManager.traits.add(Helicopter);
         addTraitToLocalizedLibrary(Helicopter.id, "HELICOPTER HELICOPTER BRRRRRRRRRRRR");
         PlayerConfig.unlockTrait("Helicopter");
		 
		 ActorTrait Tank= new ActorTrait();
         Tank.id = "Tank";
         Tank.path_icon = "ui/Icons/Tank";
         Tank.type = TraitType.Negative;
         Tank.group_id = MBTraitGroup.ModernBox;
         Tank.can_be_cured = false;
         Tank.needs_to_be_explored = false;
         Tank.can_be_given = false;
         Tank.can_be_removed = false;
         Tank.only_active_on_era_flag = false;
         Tank.era_active_night = false;
         Tank.era_active_moon = false;
         Tank.birth = 0.0f;
         Tank.inherit = 0.0f;
         Tank.base_stats[S.fertility] = 0.0f;
         Tank.base_stats[S.max_children] = 0f;
         Tank.base_stats[S.max_age] = 0f;
         Tank.base_stats[S.attack_speed] = 0;
         Tank.base_stats[S.damage] = 0;
         Tank.base_stats[S.speed] = 0f;
         Tank.base_stats[S.health] = 0;
         Tank.base_stats[S.accuracy] = 0f;
         Tank.base_stats[S.range] = 0;
         Tank.base_stats[S.armor] = 0;
         Tank.base_stats[S.scale] = 0.0f;
         Tank.base_stats[S.dodge] = 0f;
         Tank.base_stats[S.targets] = 0f;
         Tank.base_stats[S.critical_chance] = 0.0f;
         Tank.base_stats[S.knockback] = 0f;
         Tank.base_stats[S.knockback_reduction] = 0f;
         Tank.base_stats[S.intelligence] = 0;
         Tank.base_stats[S.warfare] = 0;
         Tank.base_stats[S.diplomacy] = 0;
         Tank.base_stats[S.stewardship] = 0;
         Tank.base_stats[S.opinion] = 0f;
         Tank.base_stats[S.loyalty_traits] = 0f;
         Tank.base_stats[S.cities] = 0;
         Tank.base_stats[S.zone_range] = 0;
         AssetManager.traits.add(Tank);
         addTraitToLocalizedLibrary(Tank.id, "Armoured Vehicle.");
         PlayerConfig.unlockTrait("Tank");

            ActorTrait Railgun = new ActorTrait();
            Railgun.id = "Railgun";
            Railgun.path_icon = "ui/Icons/Railgun";
            Railgun.type = TraitType.Negative;
            Railgun.group_id = MBTraitGroup.ModernBox;
            Railgun.can_be_cured = false;
            Railgun.needs_to_be_explored = false;
            Railgun.can_be_given = false;
            Railgun.can_be_removed = false;
            Railgun.only_active_on_era_flag = false;
            Railgun.era_active_night = false;
            Railgun.era_active_moon = false;
            Railgun.birth = 0.0f;
            Railgun.inherit = 0.0f;
            Railgun.base_stats[S.fertility] = 0.0f;
            Railgun.base_stats[S.max_children] = 0f;
            Railgun.base_stats[S.max_age] = 0f;
            Railgun.base_stats[S.attack_speed] = 0;
            Railgun.base_stats[S.damage] = 0;
            Railgun.base_stats[S.speed] = 0f;
            Railgun.base_stats[S.health] = 0;
            Railgun.base_stats[S.accuracy] = 0f;
            Railgun.base_stats[S.range] = 0;
            Railgun.base_stats[S.armor] = 0;
            Railgun.base_stats[S.scale] = 0.0f;
            Railgun.base_stats[S.dodge] = 0f;
            Railgun.base_stats[S.targets] = 0f;
            Railgun.base_stats[S.critical_chance] = 0.0f;
            Railgun.base_stats[S.knockback] = 0f;
            Railgun.base_stats[S.knockback_reduction] = 0f;
            Railgun.base_stats[S.intelligence] = 0;
            Railgun.base_stats[S.warfare] = 0;
            Railgun.base_stats[S.diplomacy] = 0;
            Railgun.base_stats[S.stewardship] = 0;
            Railgun.base_stats[S.opinion] = 0f;
            Railgun.base_stats[S.loyalty_traits] = 0f;
            Railgun.base_stats[S.cities] = 0;
            Railgun.base_stats[S.zone_range] = 0;
            AssetManager.traits.add(Railgun);
            addTraitToLocalizedLibrary(Railgun.id, "Armoured Vehicle.");
            PlayerConfig.unlockTrait("Railgun");

            ActorTrait Humvee= new ActorTrait();
         Humvee.id = "Humvee";
         Humvee.path_icon = "ui/Icons/Humvee";
         Humvee.type = TraitType.Negative;
         Humvee.group_id = MBTraitGroup.ModernBox;
         Humvee.can_be_cured = false;
         Humvee.needs_to_be_explored = false;
         Humvee.can_be_given = false;
         Humvee.can_be_removed = false;
         Humvee.only_active_on_era_flag = false;
         Humvee.era_active_night = false;
         Humvee.era_active_moon = false;
         Humvee.birth = 0.0f;
         Humvee.inherit = 0.0f;
         Humvee.base_stats[S.fertility] = 0.0f;
         Humvee.base_stats[S.max_children] = 0f;
         Humvee.base_stats[S.max_age] = 0f;
         Humvee.base_stats[S.attack_speed] = 0;
         Humvee.base_stats[S.damage] = 0;
         Humvee.base_stats[S.speed] = 0f;
         Humvee.base_stats[S.health] = 0;
         Humvee.base_stats[S.accuracy] = 0f;
         Humvee.base_stats[S.range] = 0;
         Humvee.base_stats[S.armor] = 0;
         Humvee.base_stats[S.scale] = 0.0f;
         Humvee.base_stats[S.dodge] = 0f;
         Humvee.base_stats[S.targets] = 0f;
         Humvee.base_stats[S.critical_chance] = 0.0f;
         Humvee.base_stats[S.knockback] = 0f;
         Humvee.base_stats[S.knockback_reduction] = 0f;
         Humvee.base_stats[S.intelligence] = 0;
         Humvee.base_stats[S.warfare] = 0;
         Humvee.base_stats[S.diplomacy] = 0;
         Humvee.base_stats[S.stewardship] = 0;
         Humvee.base_stats[S.opinion] = 0f;
         Humvee.base_stats[S.loyalty_traits] = 0f;
         Humvee.base_stats[S.cities] = 0;
         Humvee.base_stats[S.zone_range] = 0;
         AssetManager.traits.add(Humvee);
         addTraitToLocalizedLibrary(Humvee.id, "Awesome military vehicle.");
         PlayerConfig.unlockTrait("Humvee");
 
 		 ActorTrait Zeppelin= new ActorTrait();
         Zeppelin.id = "Zeppelin";
         Zeppelin.path_icon = "ui/Icons/Airship";
         Zeppelin.type = TraitType.Negative;
         Zeppelin.group_id = MBTraitGroup.ModernBox;
         Zeppelin.can_be_cured = false;
         Zeppelin.needs_to_be_explored = false;
         Zeppelin.can_be_given = false;
         Zeppelin.can_be_removed = false;
         Zeppelin.only_active_on_era_flag = false;
         Zeppelin.era_active_night = false;
         Zeppelin.era_active_moon = false;
         Zeppelin.birth = 0.0f;
         Zeppelin.inherit = 0.0f;
         Zeppelin.base_stats[S.fertility] = 0.0f;
         Zeppelin.base_stats[S.max_children] = 0f;
         Zeppelin.base_stats[S.max_age] = 0f;
         Zeppelin.base_stats[S.attack_speed] = 0;
         Zeppelin.base_stats[S.damage] = 0;
         Zeppelin.base_stats[S.speed] = 0f;
         Zeppelin.base_stats[S.health] = 0;
         Zeppelin.base_stats[S.accuracy] = 0f;
         Zeppelin.base_stats[S.range] = 0;
         Zeppelin.base_stats[S.armor] = 0;
         Zeppelin.base_stats[S.scale] = 0.0f;
         Zeppelin.base_stats[S.dodge] = 0f;
         Zeppelin.base_stats[S.targets] = 0f;
         Zeppelin.base_stats[S.critical_chance] = 0.0f;
         Zeppelin.base_stats[S.knockback] = 0f;
         Zeppelin.base_stats[S.knockback_reduction] = 0f;
         Zeppelin.base_stats[S.intelligence] = 0;
         Zeppelin.base_stats[S.warfare] = 0;
         Zeppelin.base_stats[S.diplomacy] = 0;
         Zeppelin.base_stats[S.stewardship] = 0;
         Zeppelin.base_stats[S.opinion] = 0f;
         Zeppelin.base_stats[S.loyalty_traits] = 0f;
         Zeppelin.base_stats[S.cities] = 0;
         Zeppelin.base_stats[S.zone_range] = 0;
         AssetManager.traits.add(Zeppelin);
         addTraitToLocalizedLibrary(Zeppelin.id, "Big airship.");
         PlayerConfig.unlockTrait("Zeppelin");

        }



public static bool UnitpotentialEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    Actor actor = pTarget?.a;
    if (actor == null)
        return false;

   NomadHandlerEffect(pTarget, pTile);
    HandleLandAirUnitTransformations(actor, pTile);
    HandleOrcBoatTransformations(actor, pTile);

    return true;
}

public static bool NomadHandlerEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    Actor actor = pTarget?.a;
    if (actor == null || !actor.isAlive())
        return false;
    if (actor.asset.unit || actor.data.getAge() < 2)
    {
        return false;
    }

    if ((actor.kingdom?.asset.nomads == true) || actor.kingdom?.id == "ModernKingdom" || actor.kingdom?.id == "MissileLauncherFULLRANGETARGETTING" || actor.hasTrait("madness") || (actor.kingdom?.cities.Count == 0))
    {
        if (actor.asset.id == "orcraider")
        {
            Actor orc = World.world.units.createNewUnit("unit_orc", actor.currentTile);
            if (orc != null)
            {
                EffectsLibrary.spawn("fx_spawn", orc.currentTile);
            }

            Actor wolf = World.world.units.createNewUnit("wolf", actor.currentTile);
            if (wolf != null)
            {
                EffectsLibrary.spawn("fx_spawn", wolf.currentTile);
            }

            if (actor.hasTrait("madness"))
            {
                actor.removeTrait("madness");
            }


            ActionLibrary.removeUnit(actor);
        }
        else if (actor.asset.id == "armoredwolf")
        {

            Actor wolf = World.world.units.createNewUnit("wolf", actor.currentTile);
            if (wolf != null)
            {
                EffectsLibrary.spawn("fx_spawn", wolf.currentTile);
            }

            if (actor.hasTrait("madness"))
            {
                actor.removeTrait("madness");
            }

            ActionLibrary.removeUnit(actor);
        }
        else
        {

            if (actor.hasTrait("madness"))
            {
                actor.removeTrait("madness");
            }
            actor.getHit(10000000f);
        }
        return true;
    }


    if (actor.kingdom?.id == "ModernKingdom" || actor.kingdom?.id == "MissileLauncherFULLRANGETARGETTING" ||
        (actor.kingdom?.asset.nomads == true) || (actor.kingdom?.cities.Count == 0))
    {

        actor.getHit(10000000f);
        return true;
    }


    if (actor.hasTrait("madness"))
    {
        actor.removeTrait("madness");
        actor.getHit(10000000f);
        return true;
    }

    return true;
}



private static void HandleLandAirUnitTransformations(Actor a, WorldTile pTile)
{
    if (a.asset.id == "Tank")
    {
        if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "AbramTank", pTile);
        }
    }

    else if (a.asset.id == "MissileSystem")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "eliteMissileSystem", pTile);
        }
    }

    else if (a.asset.id == "Railgun")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "OmegaRailgun", pTile);
        }
    }

    else if (a.asset.id == "Humvee")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "wheeledtank", pTile);
        }
    }

    else if (a.asset.id == "Heli")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "HeliELite", pTile);
        }
    }

    else if (a.asset.id == "Gunship")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "eliteGunship", pTile);
        }
    }

    else if (a.asset.id == "Drone")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "TIEfighter", pTile);
        }
    }

    else if (a.asset.id == "Zeppelin")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "EliteZeppelin", pTile);
        }
    }

    else if (a.asset.id == "MIRVBomber")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "EliteBomber", pTile);
        }
    }

    else if (a.asset.id == "FighterJet")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "F55FighterJet", pTile);
        }
    }

    else if (a.asset.id == "P9000")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "EliteP9000", pTile);
        }
    }

    else if (a.asset.id == "Terran")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "dreadnaught", pTile);
        }
    }

    else if (a.asset.id == "Soldier")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "SpaceMarine", pTile);
        }
    }

}




private static void HandleOrcBoatTransformations(Actor a, WorldTile pTile)
{

    if (!a.hasTrait("boat"))
    {
        return;
    }

    if (a.kingdom == null || a.kingdom.asset.id != "orc")
    {
        return;
    }

    if (a.hasTrait("thorns"))
    {
        return;
    }

    float transformationChance = 0.5f;

    if (Toolbox.randomChance(transformationChance))
    {

        Actor newActor = World.world.units.createNewUnit("orcwarturtle", pTile);
        if (newActor != null)
        {

            newActor.race = a.race;
            newActor.kingdom = a.kingdom;
            newActor.joinCity(a.city);
            EffectsLibrary.spawn("fx_spawn", newActor.currentTile);
        }
    }
    else
    {
        a.addTrait("thorns");
    }
}




private static void TransformUnit(Actor originalActor, string newActorId, WorldTile pTile)
{
    Actor newActor = World.world.units.createNewUnit(newActorId, pTile);
    if (newActor == null)
    {
        return;
    }
    ActorTool.copyUnitToOtherUnit(originalActor, newActor);
    if (originalActor.kingdom != null)
    {
        newActor.setKingdom(originalActor.kingdom);
    }
   newActor.joinCity(originalActor.city);
    EffectsLibrary.spawn("fx_spawn", newActor.currentTile);
    ActionLibrary.removeUnit(originalActor);
}


            public static bool scrapsEffect(BaseSimObject pSelf, WorldTile pTile = null)
{
    Actor selfActor = pSelf as Actor;
    if (selfActor == null) return false;

    WorldTile targetTile = selfActor.currentTile;
    if (targetTile.building == null)
    {
        string buildingID = GetBuildingForActor(selfActor);
        MapBox.instance.buildings.addBuilding(buildingID, targetTile, false, false, BuildPlacingType.New);
    }

    return true;
}

private static string GetBuildingForActor(Actor actor)
{
    string defaultBuilding = "scraps";

    switch (actor.asset.id)
    {
        case "P9000":
            return "P9000_scraps";
        case "Terran":
            return "Terran_scraps";
        case "MissileSystem":
            return "MissileSystem_scraps";
        case "Railgun":
            return "Railgun_scraps";
        case "Humvee":
            return "Humvee_scraps";
        case "Tank":
            return "Tank_scraps";
        case "FighterJet":
            return "FighterJet_scraps";
        case "MIRVBomber":
            return "MIRVBomber_scraps";
        case "Zeppelin":
            return "Zeppelin_scraps";
        case "Drone":
            return "Drone_scraps";
        case "Gunship":
            return "Gunship_scraps";
        case "Heli":
            return "Heli_scraps";
        default:
            return defaultBuilding;
    }
}



        public static void addTraitToLocalizedLibrary(string id, string description)
        {
        string language = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "language") as string;
        Dictionary<string, string> localizedText = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "localizedText") as Dictionary<string, string>;
        localizedText.Add("trait_" + id, id);
        localizedText.Add("trait_" + id + "_info", description);
        }
    }
}
