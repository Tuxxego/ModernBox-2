// NavalVehicles.cs
//========= MODERNBOX 2.1.0.1 ============//
// Made by Tuxxego (adapted to use an inner container instead of an external Vasıta file)
//=============================================================================

using System;
using System.Collections.Generic;
using System.Reflection;
using HarmonyLib;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using ReflectionUtility;

namespace M2
{
    public static class NavalVehicles
    {
        public static void init()
        {
            var harmony = new Harmony("com.example.m2.navalvehicles");
            harmony.Patch(
                AccessTools.Method(typeof(Docks), "create"),
                postfix: new HarmonyMethod(typeof(NavalVehicles).GetMethod(nameof(Docks_Create_Postfix), BindingFlags.Static | BindingFlags.NonPublic))
            );
            harmony.Patch(
                AccessTools.Method(typeof(Docks), "getList", new Type[] { typeof(ActorAsset) }),
                postfix: new HarmonyMethod(typeof(NavalVehicles).GetMethod(nameof(GetBoatList_Postfix), BindingFlags.Static | BindingFlags.NonPublic))
            );
            harmony.Patch(
                AccessTools.Method(typeof(Docks), "setKingdom"),
                postfix: new HarmonyMethod(typeof(NavalVehicles).GetMethod(nameof(Docks_SetKingdom_Postfix), BindingFlags.Static | BindingFlags.NonPublic))
            );
            harmony.Patch(
                AccessTools.Method(typeof(Docks), "buildBoatFromHere"),
                postfix: new HarmonyMethod(typeof(NavalVehicles).GetMethod(nameof(Docks_BuildBoatFromHere_Postfix), BindingFlags.Static | BindingFlags.NonPublic))
            );

            ActorAsset orcwarturtle = AssetManager.actor_library.clone("orcwarturtle", "_boat");
            orcwarturtle.id = "orcwarturtle";
            orcwarturtle.nameLocale = "orcwarturtle";
            orcwarturtle.nameTemplate = "orc_name";
            orcwarturtle.specialAnimation = false;
            orcwarturtle.disablePunchAttackAnimation = true;
            orcwarturtle.has_override_sprite = false;
            orcwarturtle.inspect_experience = true;
            orcwarturtle.inspect_kills = true;
            orcwarturtle.skipFightLogic = false;
            orcwarturtle.canFlip = true;
            orcwarturtle.texture_path = "orc_renaissance_transport";
            orcwarturtle.animation_walk = "walk_0";
		    orcwarturtle.animation_swim = "swim_0,swim_1,swim_2";
            orcwarturtle.base_stats[S.max_age] = 25f;
            orcwarturtle.base_stats[S.health] = 2500f;
            orcwarturtle.base_stats[S.speed] = 60f;
            orcwarturtle.base_stats[S.armor] = 40f;
            orcwarturtle.base_stats[S.damage] = 200f;
            orcwarturtle.base_stats[S.attack_speed] = 15;
            orcwarturtle.base_stats[S.knockback_reduction] = 6f;
            orcwarturtle.base_stats[S.knockback] = 0.8f;
            orcwarturtle.defaultAttack = "jaws";
            orcwarturtle.drawBoatMark = true;
            orcwarturtle.drawBoatMark_big = false;
            orcwarturtle.job = "boat_transport";
            orcwarturtle.tech = "Renaissance";
            orcwarturtle.cost = new ConstructionCost(1, 0, 0, 1);
            orcwarturtle.actorSize = ActorSize.S17_Dragon;
            orcwarturtle.fmod_spawn = "event:/SFX/UNITS/Turtle/TurtleSpawn";
            orcwarturtle.fmod_attack = "event:/SFX/UNITS/Turtle/TurtleAttack";
            orcwarturtle.fmod_idle = "event:/SFX/UNITS/Turtle/TurtleIdle";
            orcwarturtle.fmod_death = "event:/SFX/UNITS/Turtle/TurtleDeath";
            orcwarturtle.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", orcwarturtle);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
            AssetManager.actor_library.CallMethod("addTrait", "nightchild");
            AssetManager.actor_library.CallMethod("addTrait", "savage");
            AssetManager.actor_library.CallMethod("addTrait", "regeneration");
            AssetManager.actor_library.CallMethod("addTrait", "slow");
            AssetManager.actor_library.CallMethod("addTrait", "weightless");
            AssetManager.actor_library.CallMethod("addTrait", "genius");
            AssetManager.actor_library.addColorSet("default_turtle");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");


            ActorAsset human_renaissance_battleship = AssetManager.actor_library.clone("human_renaissance_battleship", "_boat");
            human_renaissance_battleship.id = "human_renaissance_battleship";
            human_renaissance_battleship.nameLocale = "human_renaissance_battleship";
            human_renaissance_battleship.nameTemplate = "human_name";
                human_renaissance_battleship.kingdom = "MissileLauncherFULLRANGETARGETTING";
            human_renaissance_battleship.inspect_experience = true;
            human_renaissance_battleship.inspect_kills = true;
                        human_renaissance_battleship.landCreature = true;
            human_renaissance_battleship.disablePunchAttackAnimation = true;
            human_renaissance_battleship.skipFightLogic = false;
            human_renaissance_battleship.specialAnimation = false;
            human_renaissance_battleship.has_override_sprite = false;
            human_renaissance_battleship.canFlip = true;
            human_renaissance_battleship.texture_path = "human_renaissance_battleship";
            human_renaissance_battleship.animation_walk = "walk_0";
		    human_renaissance_battleship.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_renaissance_battleship.base_stats[S.projectiles] = 5f;
            human_renaissance_battleship.base_stats[S.max_age] = 25f;
            human_renaissance_battleship.base_stats[S.health] = 2500f;
            human_renaissance_battleship.base_stats[S.speed] = 50f;
            human_renaissance_battleship.base_stats[S.armor] = 20f;
            human_renaissance_battleship.base_stats[S.damage] = 50f;
            human_renaissance_battleship.base_stats[S.attack_speed] = 15;
            human_renaissance_battleship.base_stats[S.knockback_reduction] = 6f;
            human_renaissance_battleship.base_stats[S.knockback] = 0.8f;
            human_renaissance_battleship.base_stats[S.range] = 20f;
            human_renaissance_battleship.defaultAttack = "cannonstriker";
            human_renaissance_battleship.drawBoatMark = true;
            human_renaissance_battleship.drawBoatMark_big = false;
            human_renaissance_battleship.job = "boat_transport";
            human_renaissance_battleship.tech = "Renaissance";
            human_renaissance_battleship.cost = new ConstructionCost(1, 0, 0, 1);
            human_renaissance_battleship.actorSize = ActorSize.S17_Dragon;
            human_renaissance_battleship.sound_hit = "event:/SFX/HIT/HitWood";
            human_renaissance_battleship.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_renaissance_battleship.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_renaissance_battleship.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_renaissance_battleship.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_renaissance_battleship);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
    AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

            ActorAsset human_renaissance_trading = AssetManager.actor_library.clone("human_renaissance_trading", "_boat");
            human_renaissance_trading.id = "human_renaissance_trading";
            human_renaissance_trading.nameLocale = "human_renaissance_trading";
            human_renaissance_trading.nameTemplate = "human_name";
            human_renaissance_trading.inspect_experience = true;
             human_renaissance_trading.disablePunchAttackAnimation = true;
            human_renaissance_trading.inspect_kills = true;
            human_renaissance_trading.skipFightLogic = true;
            human_renaissance_trading.specialAnimation = false;
            human_renaissance_trading.has_override_sprite = false;
            human_renaissance_trading.canFlip = true;
            human_renaissance_trading.dieOnGround = false;
            human_renaissance_trading.landCreature = true;
            human_renaissance_trading.moveFromBlock = true;
		    human_renaissance_trading.dieOnBlocks = false;
            human_renaissance_trading.hovering = false;
            human_renaissance_trading.texture_path = "human_renaissance_trading";
            human_renaissance_trading.animation_walk = "swim_0,swim_1,swim_2,swim_3";
		    human_renaissance_trading.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_renaissance_trading.base_stats[S.projectiles] = 5f;
            human_renaissance_trading.base_stats[S.max_age] = 25f;
            human_renaissance_trading.base_stats[S.health] = 2000f;
            human_renaissance_trading.base_stats[S.speed] = 70f;
            human_renaissance_trading.base_stats[S.armor] = 20f;
            human_renaissance_trading.base_stats[S.damage] = 50f;
            human_renaissance_trading.base_stats[S.attack_speed] = 15;
            human_renaissance_trading.base_stats[S.knockback_reduction] = 6f;
            human_renaissance_trading.base_stats[S.knockback] = 0.8f;
          //  human_renaissance_trading.defaultAttack = "";
            human_renaissance_trading.drawBoatMark = true;
            human_renaissance_trading.drawBoatMark_big = false;
            human_renaissance_trading.job = "boat_trading";
            human_renaissance_trading.tech = "Renaissance";
            human_renaissance_trading.cost = new ConstructionCost(1, 0, 0, 1);
            human_renaissance_trading.actorSize = ActorSize.S17_Dragon;
            human_renaissance_trading.sound_hit = "event:/SFX/HIT/HitWood";
            human_renaissance_trading.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_renaissance_trading.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_renaissance_trading.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_renaissance_trading.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_renaissance_trading);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
    AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

      ActorAsset fishing_boat_renaissance = AssetManager.actor_library.clone("fishing_boat_renaissance", "_boat");
            fishing_boat_renaissance.id = "fishing_boat_renaissance";
            fishing_boat_renaissance.nameLocale = "fishing_boat_renaissance";
            fishing_boat_renaissance.nameTemplate = "human_name";
            fishing_boat_renaissance.inspect_experience = true;
             fishing_boat_renaissance.disablePunchAttackAnimation = true;
            fishing_boat_renaissance.inspect_kills = true;
            fishing_boat_renaissance.skipFightLogic = true;
            fishing_boat_renaissance.specialAnimation = false;
            fishing_boat_renaissance.has_override_sprite = false;
            fishing_boat_renaissance.canFlip = true;
            fishing_boat_renaissance.dieOnGround = false;
            fishing_boat_renaissance.landCreature = true;
            fishing_boat_renaissance.moveFromBlock = true;
		    fishing_boat_renaissance.dieOnBlocks = false;
            fishing_boat_renaissance.hovering = false;
            fishing_boat_renaissance.texture_path = "fishing_boat_renaissance";
            fishing_boat_renaissance.animation_walk = "swim_0,swim_1,swim_2,swim_3";
		    fishing_boat_renaissance.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            fishing_boat_renaissance.base_stats[S.projectiles] = 5f;
            fishing_boat_renaissance.base_stats[S.max_age] = 25f;
            fishing_boat_renaissance.base_stats[S.health] = 500f;
            fishing_boat_renaissance.base_stats[S.speed] = 70f;
            fishing_boat_renaissance.base_stats[S.armor] = 20f;
            fishing_boat_renaissance.base_stats[S.damage] = 50f;
            fishing_boat_renaissance.base_stats[S.attack_speed] = 15;
            fishing_boat_renaissance.base_stats[S.knockback_reduction] = 6f;
            fishing_boat_renaissance.base_stats[S.knockback] = 0.8f;
          //  fishing_boat_renaissance.defaultAttack = "";
            fishing_boat_renaissance.drawBoatMark = true;
            fishing_boat_renaissance.drawBoatMark_big = false;
            fishing_boat_renaissance.job = "boat_fishing";
            fishing_boat_renaissance.tech = "Renaissance";
            fishing_boat_renaissance.cost = new ConstructionCost(1, 0, 0, 1);
            fishing_boat_renaissance.actorSize = ActorSize.S17_Dragon;
            fishing_boat_renaissance.sound_hit = "event:/SFX/HIT/HitWood";
		fishing_boat_renaissance.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingSpawn";
		fishing_boat_renaissance.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingIdleLoop";
		fishing_boat_renaissance.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingDeath";
            fishing_boat_renaissance.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", fishing_boat_renaissance);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
    AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

            ActorAsset human_renaissance_corvette1 = AssetManager.actor_library.clone("human_renaissance_corvette1", "_boat");
            human_renaissance_corvette1.id = "human_renaissance_corvette1";
            human_renaissance_corvette1.nameLocale = "human_renaissance_corvette1";
                human_renaissance_corvette1.kingdom = "MissileLauncherFULLRANGETARGETTING";
            human_renaissance_corvette1.nameTemplate = "human_name";
            human_renaissance_corvette1.disablePunchAttackAnimation = true;
             human_renaissance_corvette1.landCreature = true;
             human_renaissance_corvette1.inspect_experience = true;
            human_renaissance_corvette1.inspect_kills = true;
            human_renaissance_corvette1.specialAnimation = false;
            human_renaissance_corvette1.has_override_sprite = false;
            human_renaissance_corvette1.skipFightLogic = true;
            human_renaissance_corvette1.canFlip = true;
            human_renaissance_corvette1.texture_path = "human_renaissance_corvette";
            human_renaissance_corvette1.animation_walk = "walk_0";
		    human_renaissance_corvette1.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_renaissance_corvette1.base_stats[S.projectiles] = 3f;
            human_renaissance_corvette1.base_stats[S.max_age] = 25f;
            human_renaissance_corvette1.base_stats[S.health] = 1000f;
            human_renaissance_corvette1.base_stats[S.range] = 20f;
            human_renaissance_corvette1.base_stats[S.speed] = 50f;
            human_renaissance_corvette1.base_stats[S.armor] = 20f;
            human_renaissance_corvette1.base_stats[S.damage] = 10f;
            human_renaissance_corvette1.base_stats[S.attack_speed] = 11;
            human_renaissance_corvette1.base_stats[S.knockback_reduction] = 6f;
            human_renaissance_corvette1.base_stats[S.knockback] = 0.8f;
            human_renaissance_corvette1.defaultAttack = "arrowstriker";
            human_renaissance_corvette1.drawBoatMark = true;
            human_renaissance_corvette1.drawBoatMark_big = false;
            human_renaissance_corvette1.job = "boat_transport";
            human_renaissance_corvette1.tech = "Renaissance";
            human_renaissance_corvette1.cost = new ConstructionCost(1, 0, 0, 1);
            human_renaissance_corvette1.actorSize = ActorSize.S17_Dragon;
            human_renaissance_corvette1.sound_hit = "event:/SFX/HIT/HitWood";
            human_renaissance_corvette1.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_renaissance_corvette1.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_renaissance_corvette1.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_renaissance_corvette1.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_renaissance_corvette1);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
    AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");


                        ActorAsset human_renaissance_corvette2 = AssetManager.actor_library.clone("human_renaissance_corvette2", "_boat");
            human_renaissance_corvette2.id = "human_renaissance_corvette2";
            human_renaissance_corvette2.nameLocale = "human_renaissance_corvette2";
                 human_renaissance_corvette2.kingdom = "MissileLauncherFULLRANGETARGETTING";
            human_renaissance_corvette2.nameTemplate = "human_name";
             human_renaissance_corvette2.disablePunchAttackAnimation = true;
             human_renaissance_corvette2.inspect_experience = true;
             human_renaissance_corvette2.landCreature = true;
            human_renaissance_corvette2.inspect_kills = true;
            human_renaissance_corvette2.skipFightLogic = false;
            human_renaissance_corvette2.specialAnimation = false;
            human_renaissance_corvette2.has_override_sprite = false;
            human_renaissance_corvette2.canFlip = true;
            human_renaissance_corvette2.texture_path = "human_renaissance_corvette";
            human_renaissance_corvette2.animation_walk = "walk_0";
		    human_renaissance_corvette2.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_renaissance_corvette2.base_stats[S.projectiles] = 3f;
            human_renaissance_corvette2.base_stats[S.max_age] = 25f;
            human_renaissance_corvette2.base_stats[S.health] = 1000f;
            human_renaissance_corvette2.base_stats[S.speed] = 50f;
            human_renaissance_corvette2.base_stats[S.armor] = 20f;
                        human_renaissance_corvette2.base_stats[S.range] = 20f;
            human_renaissance_corvette2.base_stats[S.damage] = 10f;
            human_renaissance_corvette2.base_stats[S.attack_speed] = 11;
            human_renaissance_corvette2.base_stats[S.knockback_reduction] = 6f;
            human_renaissance_corvette2.base_stats[S.knockback] = 0.8f;
            human_renaissance_corvette2.defaultAttack = "arrowstriker";
            human_renaissance_corvette2.drawBoatMark = true;
            human_renaissance_corvette2.drawBoatMark_big = false;
            human_renaissance_corvette2.job = "boat_transport";
            human_renaissance_corvette2.tech = "Renaissance";
            human_renaissance_corvette2.cost = new ConstructionCost(1, 0, 0, 1);
            human_renaissance_corvette2.actorSize = ActorSize.S17_Dragon;
            human_renaissance_corvette2.sound_hit = "event:/SFX/HIT/HitWood";
            human_renaissance_corvette2.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_renaissance_corvette2.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_renaissance_corvette2.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_renaissance_corvette2.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_renaissance_corvette2);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

            ActorAsset human_industrial_battleship = AssetManager.actor_library.clone("human_industrial_battleship", "_boat");
            human_industrial_battleship.id = "human_industrial_battleship";
            human_industrial_battleship.nameLocale = "human_industrial_battleship";
            human_industrial_battleship.nameTemplate = "human_name";
               human_industrial_battleship.kingdom = "MissileLauncherFULLRANGETARGETTING";
            human_industrial_battleship.inspect_experience = true;
               human_industrial_battleship.disablePunchAttackAnimation = true;
            human_industrial_battleship.inspect_kills = true;
            human_industrial_battleship.skipFightLogic = false;
            human_industrial_battleship.landCreature = true;
            human_industrial_battleship.specialAnimation = false;
            human_industrial_battleship.has_override_sprite = false;
            human_industrial_battleship.canFlip = true;
            human_industrial_battleship.texture_path = "human_industrial_battleship";
            human_industrial_battleship.animation_walk = "walk_0";
		    human_industrial_battleship.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_industrial_battleship.base_stats[S.projectiles] = 1f;
            human_industrial_battleship.base_stats[S.max_age] = 25f;
            human_industrial_battleship.base_stats[S.health] = 4000f;
            human_industrial_battleship.base_stats[S.speed] = 50f;
            human_industrial_battleship.base_stats[S.armor] = 40f;
            human_industrial_battleship.base_stats[S.range] = 30f;
            human_industrial_battleship.base_stats[S.damage] = 40f;
            human_industrial_battleship.base_stats[S.attack_speed] = 15;
            human_industrial_battleship.base_stats[S.knockback_reduction] = 6f;
            human_industrial_battleship.base_stats[S.knockback] = 0.8f;
            human_industrial_battleship.defaultAttack = "artillerystriker";
            human_industrial_battleship.drawBoatMark = true;
            human_industrial_battleship.drawBoatMark_big = false;
            human_industrial_battleship.job = "boat_transport";
            human_industrial_battleship.tech = "Firearms";
            human_industrial_battleship.cost = new ConstructionCost(1, 0, 0, 1);
            human_industrial_battleship.actorSize = ActorSize.S17_Dragon;
            human_industrial_battleship.sound_hit = "event:/SFX/HIT/HitMetal";
            human_industrial_battleship.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_industrial_battleship.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_industrial_battleship.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_industrial_battleship.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_industrial_battleship);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

             ActorAsset human_industrial_trading = AssetManager.actor_library.clone("human_industrial_trading", "_boat");
            human_industrial_trading.id = "human_industrial_trading";
            human_industrial_trading.nameLocale = "human_industrial_trading";
            human_industrial_trading.nameTemplate = "human_name";
              human_industrial_trading.disablePunchAttackAnimation = true;
             human_industrial_trading.inspect_experience = true;
            human_industrial_trading.inspect_kills = true;
            human_industrial_trading.skipFightLogic = true;
            human_industrial_trading.specialAnimation = false;
            human_industrial_trading.has_override_sprite = false;
            human_industrial_trading.canFlip = true;
            human_industrial_trading.texture_path = "human_industrial_trading";
            human_industrial_trading.animation_walk = "walk_0";
		    human_industrial_trading.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_industrial_trading.base_stats[S.projectiles] = 2f;
            human_industrial_trading.base_stats[S.max_age] = 25f;
            human_industrial_trading.base_stats[S.health] = 2500f;
            human_industrial_trading.base_stats[S.speed] = 50f;
            human_industrial_trading.base_stats[S.armor] = 40f;
            human_industrial_trading.base_stats[S.damage] = 40f;
            human_industrial_trading.base_stats[S.attack_speed] = 5;
            human_industrial_trading.base_stats[S.knockback_reduction] = 6f;
            human_industrial_trading.base_stats[S.knockback] = 0.8f;
            human_industrial_trading.base_stats[S.scale] = 0.1f;
           // human_industrial_trading.defaultAttack = "";
            human_industrial_trading.drawBoatMark = true;
            human_industrial_trading.drawBoatMark_big = false;
            human_industrial_trading.job = "boat_trading";
            human_industrial_trading.tech = "Firearms";
            human_industrial_trading.cost = new ConstructionCost(1, 0, 0, 1);
            human_industrial_trading.actorSize = ActorSize.S17_Dragon;
            human_industrial_trading.sound_hit = "event:/SFX/HIT/HitMetal";
            human_industrial_trading.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_industrial_trading.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_industrial_trading.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_industrial_trading.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_industrial_trading);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

            ActorAsset fishing_boat_industrial = AssetManager.actor_library.clone("fishing_boat_industrial", "_boat");
            fishing_boat_industrial.id = "fishing_boat_industrial";
            fishing_boat_industrial.nameLocale = "fishing_boat_industrial";
            fishing_boat_industrial.nameTemplate = "human_name";
            fishing_boat_industrial.inspect_experience = true;
             fishing_boat_industrial.disablePunchAttackAnimation = true;
            fishing_boat_industrial.inspect_kills = true;
            fishing_boat_industrial.skipFightLogic = true;
            fishing_boat_industrial.specialAnimation = false;
            fishing_boat_industrial.has_override_sprite = false;
            fishing_boat_industrial.canFlip = true;
            fishing_boat_industrial.dieOnGround = false;
            fishing_boat_industrial.landCreature = true;
            fishing_boat_industrial.moveFromBlock = true;
		    fishing_boat_industrial.dieOnBlocks = false;
            fishing_boat_industrial.hovering = false;
            fishing_boat_industrial.texture_path = "fishing_boat_industrial";
            fishing_boat_industrial.animation_walk = "swim_0,swim_1,swim_2,swim_3";
		    fishing_boat_industrial.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            fishing_boat_industrial.base_stats[S.projectiles] = 5f;
            fishing_boat_industrial.base_stats[S.max_age] = 25f;
            fishing_boat_industrial.base_stats[S.health] = 1000f;
            fishing_boat_industrial.base_stats[S.speed] = 70f;
            fishing_boat_industrial.base_stats[S.armor] = 30f;
            fishing_boat_industrial.base_stats[S.damage] = 50f;
            fishing_boat_industrial.base_stats[S.attack_speed] = 15;
            fishing_boat_industrial.base_stats[S.knockback_reduction] = 6f;
            fishing_boat_industrial.base_stats[S.knockback] = 0.8f;
          //  fishing_boat_industrial.defaultAttack = "";
            fishing_boat_industrial.drawBoatMark = true;
            fishing_boat_industrial.drawBoatMark_big = false;
            fishing_boat_industrial.job = "boat_fishing";
            fishing_boat_industrial.tech = "Firearms";
            fishing_boat_industrial.cost = new ConstructionCost(1, 0, 0, 1);
            fishing_boat_industrial.actorSize = ActorSize.S17_Dragon;
            fishing_boat_industrial.sound_hit = "event:/SFX/HIT/HitWood";
		fishing_boat_industrial.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingSpawn";
		fishing_boat_industrial.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingIdleLoop";
		fishing_boat_industrial.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingDeath";
            fishing_boat_industrial.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", fishing_boat_industrial);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
    AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");



            ActorAsset human_industrial_corvette1 = AssetManager.actor_library.clone("human_industrial_corvette1", "_boat");
            human_industrial_corvette1.id = "human_industrial_corvette1";
            human_industrial_corvette1.nameLocale = "human_industrial_corvette1";
            human_industrial_corvette1.nameTemplate = "human_name";
               human_industrial_corvette1.kingdom = "MissileLauncherFULLRANGETARGETTING";
             human_industrial_corvette1.inspect_experience = true;
                human_industrial_corvette1.landCreature = true;
                human_industrial_corvette1.disablePunchAttackAnimation = true;
            human_industrial_corvette1.inspect_kills = true;
            human_industrial_corvette1.specialAnimation = false;
            human_industrial_corvette1.has_override_sprite = false;
             human_industrial_corvette1.skipFightLogic = true;
            human_industrial_corvette1.canFlip = true;
            human_industrial_corvette1.texture_path = "human_industrial_corvette";
            human_industrial_corvette1.animation_walk = "walk_0";
		    human_industrial_corvette1.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_industrial_corvette1.base_stats[S.projectiles] = 1f;
            human_industrial_corvette1.base_stats[S.max_age] = 25f;
            human_industrial_corvette1.base_stats[S.health] = 3000f;
            human_industrial_corvette1.base_stats[S.speed] = 50f;
            human_industrial_corvette1.base_stats[S.armor] = 40f;
            human_industrial_corvette1.base_stats[S.range] = 30f;
            human_industrial_corvette1.base_stats[S.damage] = 40f;
            human_industrial_corvette1.base_stats[S.attack_speed] = 15;
            human_industrial_corvette1.base_stats[S.knockback_reduction] = 6f;
            human_industrial_corvette1.base_stats[S.knockback] = 0.8f;
            human_industrial_corvette1.defaultAttack = "artillerystriker";
            human_industrial_corvette1.drawBoatMark = true;
            human_industrial_corvette1.drawBoatMark_big = false;
            human_industrial_corvette1.job = "boat_transport";
            human_industrial_corvette1.tech = "Firearms";
            human_industrial_corvette1.cost = new ConstructionCost(1, 0, 0, 1);
            human_industrial_corvette1.actorSize = ActorSize.S17_Dragon;
            human_industrial_corvette1.sound_hit = "event:/SFX/HIT/HitMetal";
            human_industrial_corvette1.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_industrial_corvette1.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_industrial_corvette1.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_industrial_corvette1.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_industrial_corvette1);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");


 ActorAsset human_industrial_corvette2 = AssetManager.actor_library.clone("human_industrial_corvette2", "_boat");
            human_industrial_corvette2.id = "human_industrial_corvette2";
            human_industrial_corvette2.nameLocale = "human_industrial_corvette2";
               human_industrial_corvette2.kingdom = "MissileLauncherFULLRANGETARGETTING";
            human_industrial_corvette2.nameTemplate = "human_name";
            human_industrial_corvette2.inspect_experience = true;
             human_industrial_corvette2.disablePunchAttackAnimation = true;
            human_industrial_corvette2.inspect_kills = true;
             human_industrial_corvette2.landCreature = true;
            human_industrial_corvette2.skipFightLogic = false;
            human_industrial_corvette2.specialAnimation = false;
            human_industrial_corvette2.has_override_sprite = false;
            human_industrial_corvette2.canFlip = true;
            human_industrial_corvette2.texture_path = "human_industrial_corvette";
            human_industrial_corvette2.animation_walk = "walk_0";
		    human_industrial_corvette2.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_industrial_corvette2.base_stats[S.projectiles] = 1f;
            human_industrial_corvette2.base_stats[S.max_age] = 25f;
            human_industrial_corvette2.base_stats[S.health] = 3000f;
            human_industrial_corvette2.base_stats[S.speed] = 50f;
            human_industrial_corvette2.base_stats[S.armor] = 40f;
            human_industrial_corvette2.base_stats[S.damage] = 40f;
            human_industrial_corvette2.base_stats[S.range] = 30f;
            human_industrial_corvette2.base_stats[S.attack_speed] = 15;
            human_industrial_corvette2.base_stats[S.knockback_reduction] = 6f;
            human_industrial_corvette2.base_stats[S.knockback] = 0.8f;
            human_industrial_corvette2.defaultAttack = "artillerystriker";
            human_industrial_corvette2.drawBoatMark = true;
            human_industrial_corvette2.drawBoatMark_big = false;
            human_industrial_corvette2.job = "boat_transport";
            human_industrial_corvette2.tech = "Firearms";
            human_industrial_corvette2.cost = new ConstructionCost(1, 0, 0, 1);
            human_industrial_corvette2.actorSize = ActorSize.S17_Dragon;
            human_industrial_corvette2.sound_hit = "event:/SFX/HIT/HitMetal";
            human_industrial_corvette2.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_industrial_corvette2.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_industrial_corvette2.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_industrial_corvette2.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_industrial_corvette2);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");


        Spell jet22 = new Spell
		{
			id = "jet22",
			chance = 0.1f,
			min_distance = 0f,
			castTarget = CastTarget.Himself, };
		jet22.action = castjet22;
		 AssetManager.spells.add(jet22);

                 Spell jet55 = new Spell
		{
			id = "jet55",
			chance = 0.2f,
			min_distance = 0f,
			castTarget = CastTarget.Himself, };
		jet55.action = castjet55;
		 AssetManager.spells.add(jet55);




  ActorAsset human_modern_battleship = AssetManager.actor_library.clone("human_modern_battleship", "_boat");
            human_modern_battleship.id = "human_modern_battleship";
            human_modern_battleship.nameLocale = "human_modern_battleship";
            human_modern_battleship.nameTemplate = "human_name";
            human_modern_battleship.attack_spells = List.Of<string>("jet22", "jet22" ,"jet22", "jet22" , "jet55","jet22", "jet22" ,"jet22", "jet22" , "jet55", "jet55", "jet55", "jet55");
            human_modern_battleship.specialAnimation = false;
             human_modern_battleship.disablePunchAttackAnimation = true;
            human_modern_battleship.has_override_sprite = false;
            human_modern_battleship.inspect_experience = true;
            human_modern_battleship.inspect_kills = true;
             human_modern_battleship.kingdom = "MissileLauncherFULLRANGETARGETTING";
            human_modern_battleship.skipFightLogic = false;
            human_modern_battleship.canFlip = true;
            human_modern_battleship.texture_path = "human_modern_battleship";
            human_modern_battleship.animation_walk = "walk_0";
		    human_modern_battleship.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_modern_battleship.base_stats[S.projectiles] = 2f;
            human_modern_battleship.base_stats[S.max_age] = 25f;
                human_modern_battleship.landCreature = true;
            human_modern_battleship.base_stats[S.health] = 10000f;
            human_modern_battleship.base_stats[S.speed] = 50f;
            human_modern_battleship.base_stats[S.armor] = 50f;
            human_modern_battleship.base_stats[S.damage] = 6f;
            human_modern_battleship.base_stats[S.range] = 20f;
            human_modern_battleship.base_stats[S.attack_speed] = 15;
            human_modern_battleship.base_stats[S.knockback_reduction] = 6f;
            human_modern_battleship.base_stats[S.knockback] = 0.8f;
            human_modern_battleship.base_stats[S.scale] = 0.1f;
            human_modern_battleship.defaultAttack = "machinegunery";
            human_modern_battleship.drawBoatMark = true;
            human_modern_battleship.drawBoatMark_big = false;
            human_modern_battleship.job = "boat_transport";
            human_modern_battleship.tech = "MilitaryModern";
            human_modern_battleship.cost = new ConstructionCost(1, 0, 0, 1);
            human_modern_battleship.actorSize = ActorSize.S17_Dragon;
            human_modern_battleship.sound_hit = "event:/SFX/HIT/HitMetal";
            human_modern_battleship.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_modern_battleship.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_modern_battleship.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_modern_battleship.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_modern_battleship);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

             ActorAsset human_modern_trading = AssetManager.actor_library.clone("human_modern_trading", "_boat");
            human_modern_trading.id = "human_modern_trading";
            human_modern_trading.nameLocale = "human_modern_trading";
            human_modern_trading.nameTemplate = "human_name";
            human_modern_trading.specialAnimation = false;
               human_modern_trading.disablePunchAttackAnimation = true;
            human_modern_trading.inspect_experience = true;
            human_modern_trading.inspect_kills = true;
            human_modern_trading.skipFightLogic = true;
            human_modern_trading.has_override_sprite = false;
            human_modern_trading.canFlip = true;
            human_modern_trading.texture_path = "human_modern_trading";
            human_modern_trading.animation_walk = "walk_0";
		    human_modern_trading.animation_swim = "swim_0,swim_1,swim_2";
            human_modern_trading.base_stats[S.projectiles] = 2f;
            human_modern_trading.base_stats[S.max_age] = 25f;
            human_modern_trading.base_stats[S.health] = 2500f;
            human_modern_trading.base_stats[S.speed] = 50f;
            human_modern_trading.base_stats[S.armor] = 50f;
            human_modern_trading.base_stats[S.damage] = 40f;
            human_modern_trading.base_stats[S.attack_speed] = 5;
            human_modern_trading.base_stats[S.knockback_reduction] = 6f;
            human_modern_trading.base_stats[S.knockback] = 0.8f;
          //  human_modern_trading.defaultAttack = "";
            human_modern_trading.drawBoatMark = true;
            human_modern_trading.drawBoatMark_big = false;
            human_modern_trading.job = "boat_trading";
            human_modern_trading.tech = "MilitaryModern";
            human_modern_trading.cost = new ConstructionCost(1, 0, 0, 1);
            human_modern_trading.actorSize = ActorSize.S17_Dragon;
            human_modern_trading.sound_hit = "event:/SFX/HIT/HitMetal";
            human_modern_trading.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_modern_trading.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_modern_trading.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_modern_trading.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_modern_trading);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

                		  ActorAsset fishing_boat_modern = AssetManager.actor_library.clone("fishing_boat_modern", "_boat");
            fishing_boat_modern.id = "fishing_boat_modern";
            fishing_boat_modern.nameLocale = "fishing_boat_modern";
            fishing_boat_modern.nameTemplate = "human_name";
            fishing_boat_modern.inspect_experience = true;
             fishing_boat_modern.disablePunchAttackAnimation = true;
            fishing_boat_modern.inspect_kills = true;
            fishing_boat_modern.skipFightLogic = true;
            fishing_boat_modern.specialAnimation = false;
            fishing_boat_modern.has_override_sprite = false;
            fishing_boat_modern.canFlip = true;
            fishing_boat_modern.dieOnGround = false;
            fishing_boat_modern.landCreature = true;
            fishing_boat_modern.moveFromBlock = true;
		    fishing_boat_modern.dieOnBlocks = false;
            fishing_boat_modern.hovering = false;
            fishing_boat_modern.texture_path = "fishing_boat_modern";
            fishing_boat_modern.animation_walk = "swim_0,swim_1,swim_2,swim_3";
		    fishing_boat_modern.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            fishing_boat_modern.base_stats[S.projectiles] = 5f;
            fishing_boat_modern.base_stats[S.max_age] = 25f;
            fishing_boat_modern.base_stats[S.health] = 2000f;
            fishing_boat_modern.base_stats[S.speed] = 70f;
            fishing_boat_modern.base_stats[S.armor] = 40f;
            fishing_boat_modern.base_stats[S.damage] = 50f;
            fishing_boat_modern.base_stats[S.attack_speed] = 15;
            fishing_boat_modern.base_stats[S.knockback_reduction] = 6f;
            fishing_boat_modern.base_stats[S.knockback] = 0.8f;
          //  fishing_boat_modern.defaultAttack = "";
            fishing_boat_modern.drawBoatMark = true;
            fishing_boat_modern.drawBoatMark_big = false;
            fishing_boat_modern.job = "boat_fishing";
            fishing_boat_modern.tech = "MilitaryModern";
            fishing_boat_modern.cost = new ConstructionCost(1, 0, 0, 1);
            fishing_boat_modern.actorSize = ActorSize.S17_Dragon;
            fishing_boat_modern.sound_hit = "event:/SFX/HIT/HitWood";
		fishing_boat_modern.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingSpawn";
		fishing_boat_modern.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingIdleLoop";
		fishing_boat_modern.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatFishing/BoatFishingDeath";
            fishing_boat_modern.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", fishing_boat_modern);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
    AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");


        Spell gunboat = new Spell
		{
			id = "gunboat",
			chance = 1f,
			min_distance = 0f,
			castTarget = CastTarget.Himself, };
		gunboat.action = castgunboat;
		 AssetManager.spells.add(gunboat);


              var human_modern_gunboat = AssetManager.actor_library.clone("human_modern_gunboat", "_mob");
    // ActorAsset heli = new ActorAsset();
    // human_modern_gunboat.get_override_sprite = AssetManager.actor_library.get("Jet").get_override_sprite;
    human_modern_gunboat.race = "human";
   human_modern_gunboat.kingdom = "MissileLauncherFULLRANGETARGETTING";
    human_modern_gunboat.base_stats[S.max_age] = 4f;
    human_modern_gunboat.base_stats[S.attack_speed] = 100f;
    human_modern_gunboat.base_stats[S.accuracy] = 0f;
    human_modern_gunboat.base_stats[S.health] = 200f;
    human_modern_gunboat.base_stats[S.speed] = 70f;
    human_modern_gunboat.base_stats[S.knockback_reduction] = 3f;
    human_modern_gunboat.base_stats[S.scale] = 0.2f;
    human_modern_gunboat.base_stats[S.damage] = 1;
         human_modern_gunboat.canFlip = true;
    human_modern_gunboat.drawBoatMark_big = false;
    human_modern_gunboat.skipFightLogic = false;
    human_modern_gunboat.inspect_stats = true;
    human_modern_gunboat.landCreature = false;
    human_modern_gunboat.inspect_home = true;
      human_modern_gunboat.disablePunchAttackAnimation = true;
    human_modern_gunboat.drawBoatMark = true;
    human_modern_gunboat.flying = false;
    human_modern_gunboat.can_edit_traits = true;
    // human_modern_gunboat.tech = "FighterJet1copters";
    human_modern_gunboat.canReceiveTraits = true;
    human_modern_gunboat.very_high_flyer = false;
    human_modern_gunboat.defaultAttack = "machinegunery";
    human_modern_gunboat.isBoat = false;
    human_modern_gunboat.dieOnBlocks = false;
    human_modern_gunboat.ignoreBlocks = true;
    human_modern_gunboat.moveFromBlock = false;
    human_modern_gunboat.inspect_children = false;
    human_modern_gunboat.inspect_experience = true;
    human_modern_gunboat.dieOnGround = true;
    human_modern_gunboat.canBeCitizen = true;
    human_modern_gunboat.inspect_kills = true;
    human_modern_gunboat.hideOnMinimap = false;
    human_modern_gunboat.use_items = false;
    human_modern_gunboat.oceanCreature = true;
    human_modern_gunboat.take_items = false;
    human_modern_gunboat.nameLocale = "human_modern_gunboat";
    human_modern_gunboat.nameTemplate = "Jet_Names";
    // human_modern_gunboat.job = "attacker";
    human_modern_gunboat.job = "attacker";
    human_modern_gunboat.icon = "iconFighterJet1";
    // AssetManager.actor_library.CallMethod("addTrait", "Jet");
    AssetManager.actor_library.CallMethod("loadShadow", human_modern_gunboat);
    human_modern_gunboat.animation_swim = "swim_0,swim_1,swim_2,swim_3";
    human_modern_gunboat.animation_walk = "walk_0";
    human_modern_gunboat.texture_path = "human_modern_gunboat";
    // human_modern_gunboat.actorSize = ActorSize.S17_Dragon;
    AssetManager.actor_library.add(human_modern_gunboat);
    AssetManager.actor_library.addColorSet("heliColor");
    AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");
                AssetManager.actor_library.CallMethod("addTrait", "death_mark");
    human_modern_gunboat.color = Toolbox.makeColor("#33724D");
    Localization.addLocalization(human_modern_gunboat.nameLocale, human_modern_gunboat.nameLocale);


 ActorAsset human_modern_corvette1 = AssetManager.actor_library.clone("human_modern_corvette1", "_boat");
            human_modern_corvette1.id = "human_modern_corvette1";
            human_modern_corvette1.nameLocale = "human_modern_corvette1";
             human_modern_corvette1.kingdom = "MissileLauncherFULLRANGETARGETTING";
            human_modern_corvette1.nameTemplate = "human_name";
             human_modern_corvette1.inspect_experience = true;
              human_modern_corvette1.disablePunchAttackAnimation = true;
            human_modern_corvette1.inspect_kills = true;
               human_modern_corvette1.landCreature = true;
            human_modern_corvette1.specialAnimation = false;
            human_modern_corvette1.has_override_sprite = false;
             human_modern_corvette1.skipFightLogic = true;
            human_modern_corvette1.canFlip = true;
            human_modern_corvette1.attack_spells = List.Of<string>("gunboat", "gunboat" ,"gunboat", "gunboat" , "gunboat");
            human_modern_corvette1.texture_path = "human_modern_corvette";
            human_modern_corvette1.animation_walk = "walk_0";
		    human_modern_corvette1.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_modern_corvette1.base_stats[S.projectiles] = 1f;
            human_modern_corvette1.base_stats[S.max_age] = 25f;
            human_modern_corvette1.base_stats[S.health] = 8000f;
            human_modern_corvette1.base_stats[S.speed] = 50f;
            human_modern_corvette1.base_stats[S.armor] = 50f;
            human_modern_corvette1.base_stats[S.damage] = 40f;
            human_modern_corvette1.base_stats[S.range] = 30f;
            human_modern_corvette1.base_stats[S.attack_speed] = 10;
            human_modern_corvette1.base_stats[S.knockback_reduction] = 6f;
            human_modern_corvette1.base_stats[S.knockback] = 0.8f;
            human_modern_corvette1.base_stats[S.scale] = 0.15f;
            human_modern_corvette1.defaultAttack = "JetRocket";
            human_modern_corvette1.drawBoatMark = true;
            human_modern_corvette1.drawBoatMark_big = false;
            human_modern_corvette1.job = "boat_transport";
            human_modern_corvette1.tech = "MilitaryModern";
            human_modern_corvette1.cost = new ConstructionCost(1, 0, 0, 1);
            human_modern_corvette1.actorSize = ActorSize.S17_Dragon;
            human_modern_corvette1.sound_hit = "event:/SFX/HIT/HitMetal";
            human_modern_corvette1.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_modern_corvette1.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_modern_corvette1.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_modern_corvette1.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_modern_corvette1);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

            ActorAsset human_modern_corvette2 = AssetManager.actor_library.clone("human_modern_corvette2", "_boat");
            human_modern_corvette2.id = "human_modern_corvette2";
            human_modern_corvette2.nameLocale = "human_modern_corvette2";
            human_modern_corvette2.nameTemplate = "human_name";
                  human_modern_corvette2.kingdom = "MissileLauncherFULLRANGETARGETTING";
             human_modern_corvette2.disablePunchAttackAnimation = true;
                human_modern_corvette2.inspect_experience = true;
            human_modern_corvette2.inspect_kills = true;
            human_modern_corvette2.skipFightLogic = false;
            human_modern_corvette2.specialAnimation = false;
            human_modern_corvette2.attack_spells = List.Of<string>("gunboat", "gunboat" ,"gunboat", "gunboat" , "gunboat");
            human_modern_corvette2.has_override_sprite = false;
            human_modern_corvette2.canFlip = true;
               human_modern_corvette2.landCreature = true;
            human_modern_corvette2.texture_path = "human_modern_corvette";
            human_modern_corvette2.animation_walk = "walk_0";
		    human_modern_corvette2.animation_swim = "swim_0,swim_1,swim_2,swim_3";
            human_modern_corvette2.base_stats[S.projectiles] = 1f;
            human_modern_corvette2.base_stats[S.max_age] = 25f;
            human_modern_corvette2.base_stats[S.health] = 8000f;
            human_modern_corvette2.base_stats[S.speed] = 50f;
            human_modern_corvette2.base_stats[S.armor] = 50f;
            human_modern_corvette2.base_stats[S.damage] = 40f;
            human_modern_corvette2.base_stats[S.range] = 30f;
            human_modern_corvette2.base_stats[S.attack_speed] = 10;
            human_modern_corvette2.base_stats[S.knockback_reduction] = 6f;
            human_modern_corvette2.base_stats[S.knockback] = 0.8f;
            human_modern_corvette2.base_stats[S.scale] = 0.15f;
            human_modern_corvette2.defaultAttack = "JetRocket";
            human_modern_corvette2.drawBoatMark = true;
            human_modern_corvette2.drawBoatMark_big = false;
            human_modern_corvette2.job = "boat_transport";
            human_modern_corvette2.tech = "MilitaryModern";
            human_modern_corvette2.cost = new ConstructionCost(1, 0, 0, 1);
            human_modern_corvette2.actorSize = ActorSize.S17_Dragon;
            human_modern_corvette2.sound_hit = "event:/SFX/HIT/HitMetal";
            human_modern_corvette2.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_modern_corvette2.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_modern_corvette2.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_modern_corvette2.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_modern_corvette2);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");

             ActorAsset human_modern_submarine = AssetManager.actor_library.clone("human_modern_submarine", "_boat");
            human_modern_submarine.id = "human_modern_submarine";
            human_modern_submarine.nameLocale = "human_modern_submarine";
            human_modern_submarine.nameTemplate = "human_name";
             human_modern_submarine.disablePunchAttackAnimation = true;
            human_modern_submarine.inspect_experience = true;
            human_modern_submarine.inspect_kills = true;
            human_modern_submarine.skipFightLogic = false;
            human_modern_submarine.specialAnimation = false;
                  human_modern_submarine.landCreature = true;
            human_modern_submarine.has_override_sprite = false;
            human_modern_submarine.canFlip = true;
            human_modern_submarine.texture_path = "human_modern_submarine";
            human_modern_submarine.animation_walk = "walk_0";
		    human_modern_submarine.animation_swim = "swim_0,swim_1,swim_2,swim_3,swim_4,swim_5,swim_6,swim_7,swim_8,swim_9,swim_10";
            human_modern_submarine.base_stats[S.projectiles] = 1f;
            human_modern_submarine.base_stats[S.max_age] = 25f;
            human_modern_submarine.base_stats[S.health] = 6000f;
            human_modern_submarine.base_stats[S.speed] = 40f;
            human_modern_submarine.base_stats[S.armor] = 60f;
            human_modern_submarine.base_stats[S.damage] = 50f;
            human_modern_submarine.base_stats[S.range] = 50f;
            human_modern_submarine.base_stats[S.attack_speed] = 5;
            human_modern_submarine.base_stats[S.knockback_reduction] = 6f;
            human_modern_submarine.base_stats[S.knockback] = 0.8f;
            human_modern_submarine.base_stats[S.scale] = 0.1f;
            human_modern_submarine.defaultAttack = "missilelauncherlong";
            human_modern_submarine.drawBoatMark = true;
            human_modern_submarine.drawBoatMark_big = false;
            human_modern_submarine.job = "boat_transport";
            human_modern_submarine.tech = "MilitaryModern";
            human_modern_submarine.cost = new ConstructionCost(1, 0, 0, 1);
            human_modern_submarine.actorSize = ActorSize.S17_Dragon;
           human_modern_submarine.sound_hit = "event:/SFX/HIT/HitMetal";
            human_modern_submarine.fmod_spawn = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportSpawn";
		    human_modern_submarine.fmod_idle_loop = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportIdleLoop";
		    human_modern_submarine.fmod_death = "event:/SFX/UNITS/UNIQUE/BoatTransport/BoatTransportDeath";
            human_modern_submarine.color = Toolbox.makeColor("#fffa05");
            AssetManager.actor_library.CallMethod("loadShadow", human_modern_submarine);
            AssetManager.actor_library.CallMethod("addTrait", "light_lamp");
                AssetManager.actor_library.CallMethod("addTrait", "Unitpotential");


        }



public static bool castgunboat(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTarget != null)
    {
        pTile = pTarget.currentTile;
    }
    else if (pSelf != null)
    {
        pTile = pSelf.currentTile;
    }

    Toolbox.findSameUnitInChunkAround(pTile.chunk, "human_modern_gunboat");
    if (Toolbox.temp_list_units.Count > 6)
    {
        return false;
    }

    WorldTile worldTile = pTile?.region?.tiles.GetRandom();
    if (worldTile == null)
    {
        return false;
    }
    gunboat(pTarget ?? pSelf, worldTile);
    return true;
}

public static bool gunboat(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTile == null)
    {
        return false;
    }

    Actor originalActor = pTarget?.a;
    if (originalActor == null)
    {
        return false;
    }

    Actor newActor = World.world.units.createNewUnit("human_modern_gunboat", pTile);
    if (newActor == null)
    {
        return false;
    }

    if (originalActor.kingdom != null)
    {
        newActor.setKingdom(originalActor.kingdom);
    }
    newActor.joinCity(originalActor.city);
    newActor.makeWait(1f);

    return true;
}


public static bool castjet22(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTarget != null)
    {
        pTile = pTarget.currentTile;
    }
    else if (pSelf != null)
    {
        pTile = pSelf.currentTile;
    }

    Toolbox.findSameUnitInChunkAround(pTile.chunk, "FighterJet1");
    if (Toolbox.temp_list_units.Count > 6)
    {
        return false;
    }
    WorldTile worldTile = pTile?.region?.tiles.GetRandom();
    if (worldTile == null)
    {
        return false;
    }

    jet22(pTarget ?? pSelf, worldTile);
    return true;
}

public static bool jet22(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTile == null)
    {
        return false;
    }
    Actor originalActor = pTarget?.a;
    if (originalActor == null)
    {
        return false;
    }
    Actor newActor = World.world.units.createNewUnit("FighterJet1", pTile);
    if (newActor == null)
    {
        return false;
    }
    if (originalActor.kingdom != null)
    {
        newActor.setKingdom(originalActor.kingdom);
    }
    newActor.joinCity(originalActor.city);
    newActor.makeWait(1f);
    return true;
}


public static bool castjet55(BaseSimObject pSelf, BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTarget != null)
    {
        pTile = pTarget.currentTile;
    }
    else if (pSelf != null)
    {
        pTile = pSelf.currentTile;
    }

    Toolbox.findSameUnitInChunkAround(pTile.chunk, "F55FighterJet1");
    if (Toolbox.temp_list_units.Count > 6)
    {
        return false;
    }
    WorldTile worldTile = pTile?.region?.tiles.GetRandom();
    if (worldTile == null)
    {
        return false;
    }

    jet55(pTarget ?? pSelf, worldTile);
    return true;
}

public static bool jet55(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (pTile == null)
    {
        return false;
    }
    Actor originalActor = pTarget?.a;
    if (originalActor == null)
    {
        return false;
    }
    Actor newActor = World.world.units.createNewUnit("F55FighterJet1", pTile);
    if (newActor == null)
    {
        return false;
    }
    if (originalActor.kingdom != null)
    {
        newActor.setKingdom(originalActor.kingdom);
    }
    newActor.joinCity(originalActor.city);
    newActor.makeWait(1f);
    return true;
}







        static void Docks_Create_Postfix(Docks __instance, Building pBuilding)
        {
            if (__instance == null || pBuilding == null || pBuilding.gameObject == null)
                return;
            if (pBuilding.gameObject.GetComponent<BoatContainer>() == null)
            {
                pBuilding.gameObject.AddComponent<BoatContainer>();
            }
        }

        static void GetBoatList_Postfix(ActorAsset pAsset, Docks __instance, ref HashSet<Actor> __result)
        {
            if (pAsset == null)
                return;
            if (pAsset.id == "orcwarturtle" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.Orcwarturtle;
            }
           else if (pAsset.id == "human_renaissance_battleship" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_renaissance_battleship;
            }
               else if (pAsset.id == "human_renaissance_trading" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_renaissance_trading;
            }
                           else if (pAsset.id == "human_renaissance_corvette1" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_renaissance_corvette1;
            }
                           else if (pAsset.id == "human_renaissance_corvette2" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_renaissance_corvette2;
            }
               else if (pAsset.id == "human_industrial_battleship" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_industrial_battleship;
            }
               else if (pAsset.id == "human_industrial_trading" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_industrial_trading;
            }
                           else if (pAsset.id == "human_industrial_corvette1" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_industrial_corvette1;
            }
                           else if (pAsset.id == "human_industrial_corvette2" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_industrial_corvette2;
            }

            else if (pAsset.id == "human_modern_battleship" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_modern_battleship;
            }
               else if (pAsset.id == "human_modern_trading" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_modern_trading;
            }
               else if (pAsset.id == "human_modern_corvette1" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_modern_corvette1;
            }
                           else if (pAsset.id == "human_modern_corvette2" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_modern_corvette2;
            }
                           else if (pAsset.id == "human_modern_submarine" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.human_modern_submarine;
            }
               else if (pAsset.id == "fishing_boat_renaissance" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.fishing_boat_renaissance;
            }
                 else if (pAsset.id == "fishing_boat_industrial" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.fishing_boat_industrial;
            }
                           else if (pAsset.id == "fishing_boat_modern" && __instance.building != null)
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                __result = container.fishing_boat_modern;
            }

        }

        static void Docks_SetKingdom_Postfix(Docks __instance, Kingdom pKingdom)
        {
            if (__instance == null || __instance.building == null)
                return;
            BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
            if (container != null)
            {
                foreach (Actor boat in container.Orcwarturtle)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_renaissance_battleship)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_renaissance_trading)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_renaissance_corvette1)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_renaissance_corvette2)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
                        else if (container != null)
            {
                foreach (Actor boat in container.human_industrial_battleship)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_industrial_trading)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_industrial_corvette1)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_industrial_corvette2)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }


                        else if (container != null)
            {
                foreach (Actor boat in container.human_modern_battleship)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
                        else if (container != null)
            {
                foreach (Actor boat in container.human_modern_trading)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_modern_corvette1)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_modern_corvette2)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.human_modern_submarine)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.fishing_boat_renaissance)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.fishing_boat_industrial)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }
            else if (container != null)
            {
                foreach (Actor boat in container.fishing_boat_modern)
                {
                    if (boat != null)
                    {
                        boat.setKingdom(pKingdom);
                    }
                }
            }

        }

        static void Docks_BuildBoatFromHere_Postfix(Docks __instance, City pCity, ref Actor __result)
        {
            if (__result != null && __result.asset.id == "orcwarturtle")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.Orcwarturtle.Add(__result);
            }
            else if (__result != null && __result.asset.id == "human_renaissance_battleship")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_renaissance_battleship.Add(__result);
            }
            else if (__result != null && __result.asset.id == "human_renaissance_trading")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_renaissance_trading.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_renaissance_corvette1")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_renaissance_corvette1.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_renaissance_corvette2")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_renaissance_corvette2.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_industrial_battleship")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_industrial_battleship.Add(__result);
            }
            else if (__result != null && __result.asset.id == "human_industrial_trading")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_industrial_trading.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_industrial_corvette1")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_industrial_corvette1.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_industrial_corvette2")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_industrial_corvette2.Add(__result);
            }

                         else if (__result != null && __result.asset.id == "human_modern_battleship")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_modern_battleship.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_modern_trading")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_modern_trading.Add(__result);
            }
            else if (__result != null && __result.asset.id == "human_modern_corvette1")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_modern_corvette1.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_modern_corvette2")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_modern_corvette2.Add(__result);
            }
             else if (__result != null && __result.asset.id == "human_modern_submarine")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.human_modern_submarine.Add(__result);
            }
            else if (__result != null && __result.asset.id == "fishing_boat_renaissance")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.fishing_boat_renaissance.Add(__result);
            }
             else if (__result != null && __result.asset.id == "fishing_boat_industrial")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.fishing_boat_industrial.Add(__result);
            }
             else if (__result != null && __result.asset.id == "fishing_boat_modern")
            {
                BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
                if (container == null)
                {
                    container = __instance.building.gameObject.AddComponent<BoatContainer>();
                }
                container.fishing_boat_modern.Add(__result);
            }

        }


           [HarmonyPatch(typeof(Docks), "removeBoatFromDock")]
public static class Docks_RemoveBoatFromDock_Patch {
    static bool Prefix(Docks __instance, Actor pBoat) {
        if (__instance == null || __instance.building == null || pBoat == null)
            return false;
        BoatContainer container = __instance.building.gameObject.GetComponent<BoatContainer>();
        if (container == null) {
            pBoat.setHomeBuilding(null);
            pBoat.callbacks_on_death = (BaseActionActor)Delegate.Remove(
                pBoat.callbacks_on_death, new BaseActionActor(__instance.callbackUnitDied));
            return false;
        }

        HashSet<Actor> list = null;
        switch (pBoat.asset.id) {
            case "orcwarturtle":
                list = container.Orcwarturtle;
                break;
            case "human_renaissance_battleship":
                list = container.human_renaissance_battleship;
                break;
            case "human_renaissance_trading":
                list = container.human_renaissance_trading;
                break;
            case "human_renaissance_corvette1":
                list = container.human_renaissance_corvette1;
                break;
            case "human_renaissance_corvette2":
                list = container.human_renaissance_corvette2;
                break;
            case "human_industrial_battleship":
                list = container.human_industrial_battleship;
                break;
            case "human_industrial_trading":
                list = container.human_industrial_trading;
                break;
            case "human_industrial_corvette1":
                list = container.human_industrial_corvette1;
                break;
            case "human_industrial_corvette2":
                list = container.human_industrial_corvette2;
                break;
            case "human_modern_battleship":
                list = container.human_modern_battleship;
                break;
            case "human_modern_trading":
                list = container.human_modern_trading;
                break;
            case "human_modern_corvette1":
                list = container.human_modern_corvette1;
                break;
            case "human_modern_corvette2":
                list = container.human_modern_corvette2;
                break;
            case "human_modern_submarine":
                list = container.human_modern_submarine;
                break;
                case "fishing_boat_renaissance":
                list = container.fishing_boat_renaissance;
                break;
            case "fishing_boat_industrial":
                list = container.fishing_boat_industrial;
                break;
            case "fishing_boat_modern":
                list = container.fishing_boat_modern;
                break;
            default:
                list = null;
                break;
        }
        if (list == null) {
            pBoat.setHomeBuilding(null);
            pBoat.callbacks_on_death = (BaseActionActor)Delegate.Remove(
                pBoat.callbacks_on_death, new BaseActionActor(__instance.callbackUnitDied));
            return false;
        }
        list.Remove(pBoat);
        pBoat.setHomeBuilding(null);
        pBoat.callbacks_on_death = (BaseActionActor)Delegate.Remove(
            pBoat.callbacks_on_death, new BaseActionActor(__instance.callbackUnitDied));
        return false;
    }
}


        public class BoatContainer : MonoBehaviour
        {
            public HashSet<Actor> Orcwarturtle = new HashSet<Actor>();
            public HashSet<Actor> human_renaissance_battleship = new HashSet<Actor>();
            public HashSet<Actor> human_renaissance_trading = new HashSet<Actor>();
            public HashSet<Actor> human_renaissance_corvette1 = new HashSet<Actor>();
            public HashSet<Actor> human_renaissance_corvette2 = new HashSet<Actor>();
            public HashSet<Actor> human_industrial_battleship = new HashSet<Actor>();
            public HashSet<Actor> human_industrial_trading = new HashSet<Actor>();
            public HashSet<Actor> human_industrial_corvette1 = new HashSet<Actor>();
            public HashSet<Actor> human_industrial_corvette2 = new HashSet<Actor>();
            public HashSet<Actor> human_modern_battleship = new HashSet<Actor>();
            public HashSet<Actor> human_modern_trading = new HashSet<Actor>();
            public HashSet<Actor> human_modern_corvette1 = new HashSet<Actor>();
            public HashSet<Actor> human_modern_corvette2 = new HashSet<Actor>();
            public HashSet<Actor> human_modern_submarine = new HashSet<Actor>();
            public HashSet<Actor> fishing_boat_renaissance = new HashSet<Actor>();
            public HashSet<Actor> fishing_boat_industrial = new HashSet<Actor>();
            public HashSet<Actor> fishing_boat_modern = new HashSet<Actor>();
        }
    }
}
