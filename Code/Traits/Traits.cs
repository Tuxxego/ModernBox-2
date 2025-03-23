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
using M2;
 
namespace M2
{
    class Traits
    {

        public static void init()
        { 
 
            ///Dynastic hates Peoplewoven -50 , Peoplewoven and Martial have mutual mate -200, Mercantile vs Peoplewoven -50, Dynastic and Mercantile are neutral, Mercantile and Martial are -20 relationship
            ///// extra ideology traits like generalissimo to make a kingdom hated , others like isolationist make kingdom neutral

         ActorTrait Dynastic = new ActorTrait();
         Dynastic.id = "Dynastic";
         Dynastic.path_icon = "ui/Icons/Dynastic";
         Dynastic.type = TraitType.Positive;
         Dynastic.group_id = MBTraitGroup.IdeologiesBox;
         Dynastic.opposite = "Mercantile,Peoplewoven,Martial,Chaosvolt";
         Dynastic.can_be_cured = false;
         Dynastic.needs_to_be_explored = false;
         Dynastic.can_be_given = true;
         Dynastic.can_be_removed = true;
         Dynastic.birth = 10f;
         Dynastic.inherit = 1f;
         Dynastic.base_stats[S.max_age] = 30f;
         Dynastic.base_stats[S.attack_speed] = 0;
         Dynastic.base_stats[S.intelligence] = -10;
         Dynastic.base_stats[S.warfare] = 0;
         Dynastic.base_stats[S.diplomacy] = 10;
         Dynastic.base_stats[S.stewardship] = 10;
         Dynastic.base_stats[S.opinion] = 0f;
         Dynastic.base_stats[S.loyalty_traits] = 15f;
         Dynastic.base_stats[S.fertility] = -0.15f;
         Dynastic.base_stats[S.cities] = 0;
         AssetManager.traits.add(Dynastic);
         addTraitToLocalizedLibrary(Dynastic.id, "LONG LIVE THE KING!!!!");
         PlayerConfig.unlockTrait("Dynastic");


          ActorTrait Mercantile= new ActorTrait();
         Mercantile.id = "Mercantile";
         Mercantile.path_icon = "ui/Icons/Mercantile";
         Mercantile.type = TraitType.Positive;
         Mercantile.opposite = "Dynastic,Peoplewoven,Martial,Chaosvolt";
         Mercantile.group_id = MBTraitGroup.IdeologiesBox;
         Mercantile.can_be_cured = false;
         Mercantile.needs_to_be_explored = false;
         Mercantile.can_be_given = true;
         Mercantile.can_be_removed = true;
         Mercantile.birth = 10f;
         Mercantile.inherit = 0.5f;
         Mercantile.base_stats[S.max_age] = 0f;
         Mercantile.base_stats[S.attack_speed] = 0;
         Mercantile.base_stats[S.intelligence] = 5;
         Mercantile.base_stats[S.warfare] = 0;
         Mercantile.base_stats[S.diplomacy] = 10;
         Mercantile.base_stats[S.stewardship] = 0;
         Mercantile.base_stats[S.opinion] = 10f;
         Mercantile.base_stats[S.loyalty_traits] = 15f;
         Mercantile.base_stats[S.cities] = -3;
         AssetManager.traits.add(Mercantile);
         addTraitToLocalizedLibrary(Mercantile.id, "The very best prices, the yugest golden toilets, and the bestest hairstyles");
         PlayerConfig.unlockTrait("Mercantile");

          ActorTrait Peoplewoven= new ActorTrait();
         Peoplewoven.id = "Peoplewoven";
         Peoplewoven.path_icon = "ui/Icons/Peoplewoven";
         Peoplewoven.type = TraitType.Positive;
         Peoplewoven.opposite = "Dynastic,Mercantile,Martial,Chaosvolt";
         Peoplewoven.group_id = MBTraitGroup.IdeologiesBox;
         Peoplewoven.can_be_cured = false;
         Peoplewoven.needs_to_be_explored = false;
         Peoplewoven.can_be_given = true;
         Peoplewoven.can_be_removed = true;
         Peoplewoven.birth = 10f;
         Peoplewoven.inherit = 0.8f;
         Peoplewoven.base_stats[S.max_age] = 0f;
         Peoplewoven.base_stats[S.attack_speed] = 0;
         Peoplewoven.base_stats[S.intelligence] = 5;
         Peoplewoven.base_stats[S.warfare] = 10;
         Peoplewoven.base_stats[S.diplomacy] = 5;
         Peoplewoven.base_stats[S.stewardship] = 3;
         Peoplewoven.base_stats[S.opinion] = 10f;
         Peoplewoven.base_stats[S.loyalty_traits] = -50f;
         Peoplewoven.base_stats[S.cities] = 3;
         AssetManager.traits.add(Peoplewoven);
         addTraitToLocalizedLibrary(Peoplewoven.id, "WE HAVE COME TO THE ONLY PLACE NOT YET CORRUPTED BY MERCANTILES, SPACEBOX!");
         PlayerConfig.unlockTrait("Peoplewoven");

          ActorTrait Martial= new ActorTrait();
         Martial.id = "Martial";
         Martial.path_icon = "ui/Icons/Martial";
         Martial.opposite = "Dynastic,Mercantile,Peoplewoven,Chaosvolt";
         Martial.type = TraitType.Positive;
         Martial.group_id = MBTraitGroup.IdeologiesBox;
         Martial.can_be_cured = false;
         Martial.needs_to_be_explored = false;
         Martial.can_be_given = true;
         Martial.can_be_removed = true;
         Martial.birth = 10f;
         Martial.inherit = 0.8f;
         Martial.base_stats[S.max_age] = 0f;
         Martial.base_stats[S.attack_speed] = 0;
         Martial.base_stats[S.intelligence] = 10;
         Martial.base_stats[S.warfare] = 20;
         Martial.base_stats[S.diplomacy] = -10;
         Martial.base_stats[S.stewardship] = 5;
         Martial.base_stats[S.opinion] = -20f;
         Martial.base_stats[S.loyalty_traits] = -50f;
         Martial.base_stats[S.cities] = 3;
         AssetManager.traits.add(Martial);
         addTraitToLocalizedLibrary(Martial.id, "TUXXEDAN TECHNOLOGY IS THE BEST");
         PlayerConfig.unlockTrait("Martial");


         ActorTrait Chaosvolt = new ActorTrait();
         Chaosvolt.id = "Chaosvolt";
         Chaosvolt.path_icon = "ui/Icons/Chaosvolt";
         Chaosvolt.opposite = "Martial,Dynastic,Mercantile,Peoplewoven";
         Chaosvolt.type = TraitType.Positive;
         Chaosvolt.group_id = MBTraitGroup.IdeologiesBox;
         Chaosvolt.can_be_cured = false;
         Chaosvolt.needs_to_be_explored = false;
         Chaosvolt.can_be_given = true;
         Chaosvolt.can_be_removed = true;
         Chaosvolt.birth = 8f;
         Chaosvolt.inherit = 0f;
         Chaosvolt.base_stats[S.max_age] = -10f;
         Chaosvolt.base_stats[S.attack_speed] = 15;
         Chaosvolt.base_stats[S.intelligence] = 2;
         Chaosvolt.base_stats[S.warfare] = 20;
         Chaosvolt.base_stats[S.diplomacy] = -500;
         Chaosvolt.base_stats[S.stewardship] = -400;
         Chaosvolt.base_stats[S.opinion] = -800f;
         Chaosvolt.base_stats[S.loyalty_traits] = -10000f;
         Chaosvolt.base_stats[S.cities] = -100;
         AssetManager.traits.add(Chaosvolt);
         addTraitToLocalizedLibrary(Chaosvolt.id, "THE CHAINS ARE BROKEN, THE PEOPLE RISE");
         PlayerConfig.unlockTrait("Chaosvolt");


    OpinionAsset opinion_ideology = new OpinionAsset
         {
             id = "opinion_ideology",
             translation_key = "opinion_ideology",
             translation_key_negative = "opinion_ideology_negative",
             calc = delegate (Kingdom pMain, Kingdom pTarget)
             {
                 int opinion = 0;
                 if (pMain.king == null || pTarget.king == null)
                     return opinion;

                 bool mainPeoplewoven = pMain.king.hasTrait("Peoplewoven");
                 bool mainMartial = pMain.king.hasTrait("Martial");
                 bool mainMercantile = pMain.king.hasTrait("Mercantile");
                 bool mainDynastic = pMain.king.hasTrait("Dynastic");
                 bool mainChaosvolt = pMain.king.hasTrait("Chaosvolt");

                 bool targetPeoplewoven = pTarget.king.hasTrait("Peoplewoven");
                 bool targetMartial = pTarget.king.hasTrait("Martial");
                 bool targetMercantile = pTarget.king.hasTrait("Mercantile");
                 bool targetDynastic = pTarget.king.hasTrait("Dynastic");
                 bool targetChaosvolt = pTarget.king.hasTrait("Chaosvolt");

                 if ((mainPeoplewoven && targetMartial) || (mainMartial && targetPeoplewoven))
                 {
                     opinion -= 100;
                 }
                 if ((mainPeoplewoven && targetDynastic) || (mainDynastic && targetPeoplewoven))
                 {
                     opinion -= 200;
                 }
                 if ((mainPeoplewoven || mainMartial) && targetMercantile)
                 {
                     opinion -= 50;
                 }
                 if ((targetPeoplewoven || targetMartial) && mainMercantile)
                 {
                     opinion -= 50;
                 }
                 if ((mainPeoplewoven && targetPeoplewoven) || (mainMartial && targetMartial) || (mainMercantile && targetMercantile) || (mainDynastic && targetDynastic))
                 {
                     opinion += 200;
                 }

                 if (mainChaosvolt)
                 {
                     opinion -= 500;
                 }
                 if (targetChaosvolt)
                 {
                     opinion -= 500;
                 }
                 if (mainChaosvolt && targetChaosvolt)
                 {
                     opinion -= 600;
                 }

                 return opinion;
             }
         };
         AssetManager.opinion_library.add(opinion_ideology);

         LoyaltyAsset opinion_leader_ideology = new LoyaltyAsset
         {
             id = "opinion_leader_ideology",
             translation_key = "opinion_leader_ideology",
             translation_key_negative = "opinion_leader_ideology_negative",
             calc = delegate(City pCity)
             {
                 int opinion = 0;
                 Actor leader = pCity.leader;
                 Actor king = pCity.kingdom?.king;
                 if (leader == null || king == null)
                     return opinion;

                 bool leaderPeoplewoven = leader.hasTrait("Peoplewoven");
                 bool leaderMartial = leader.hasTrait("Martial");
                 bool leaderMercantile = leader.hasTrait("Mercantile");
                 bool leaderDynastic = leader.hasTrait("Dynastic");
                 bool leaderChaosvolt = leader.hasTrait("Chaosvolt");

                 bool kingPeoplewoven = king.hasTrait("Peoplewoven");
                 bool kingMartial = king.hasTrait("Martial");
                 bool kingMercantile = king.hasTrait("Mercantile");
                 bool kingDynastic = king.hasTrait("Dynastic");
                 bool kingChaosvolt = king.hasTrait("Chaosvolt");

                 if ((leaderPeoplewoven && kingMartial) || (leaderMartial && kingPeoplewoven))
                 {
                     opinion -= 250;
                 }
                 if ((leaderMartial && kingMartial) || (leaderPeoplewoven && kingPeoplewoven) || (leaderMercantile && kingMercantile) || (leaderDynastic && kingDynastic))
                 {
                     opinion += 200;
                 }
                 if ((leaderPeoplewoven && kingDynastic) || (leaderDynastic && kingPeoplewoven))
                 {
                     opinion -= 250;
                 }
                 if ((leaderPeoplewoven || leaderMartial) && kingMercantile)
                 {
                     opinion -= 50;
                 }
                 if ((kingPeoplewoven || kingMartial) && leaderMercantile)
                 {
                     opinion -= 50;
                 }

                 if (leaderChaosvolt)
                 {
                     opinion -= 600;
                 }
                 if (kingChaosvolt)
                 {
                     opinion -= 600;
                 }
                 if (leaderChaosvolt && kingChaosvolt)
                 {
                     opinion -= 800;
                 }

                 return opinion;
             }
         };
         AssetManager.loyalty_library.add(opinion_leader_ideology);


		 ActorTrait exhausted= new ActorTrait();
         exhausted.id = "exhausted";
         exhausted.path_icon = "ui/Icons/Humvee";
         exhausted.type = TraitType.Negative;
         exhausted.group_id = MBTraitGroup.ModernBox;
         exhausted.can_be_cured = false;
         exhausted.needs_to_be_explored = false;
         exhausted.can_be_given = false;
         exhausted.can_be_removed = false;
         exhausted.birth = 0.0f;
         exhausted.inherit = 0.0f;
         AssetManager.traits.add(exhausted);
         addTraitToLocalizedLibrary(exhausted.id, "exhausted");
         PlayerConfig.unlockTrait("exhausted");

        ActorTrait spawnedvehicle= new ActorTrait();
         spawnedvehicle.id = "spawnedvehicle";
         spawnedvehicle.path_icon = "ui/Icons/Humvee";
         spawnedvehicle.type = TraitType.Negative;
         spawnedvehicle.group_id = MBTraitGroup.ModernBox;
         spawnedvehicle.can_be_cured = false;
         spawnedvehicle.needs_to_be_explored = false;
         spawnedvehicle.can_be_given = false;
         spawnedvehicle.can_be_removed = false;
         spawnedvehicle.birth = 0.0f;
         spawnedvehicle.inherit = 0.0f;
         AssetManager.traits.add(spawnedvehicle);
         addTraitToLocalizedLibrary(spawnedvehicle.id, "spawnedvehicle");
         PlayerConfig.unlockTrait("spawnedvehicle");
		 
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

         ActorTrait SupportRole= new ActorTrait();
         SupportRole.id = "SupportRole";
         SupportRole.path_icon = "ui/Icons/iconHealingAura";
         SupportRole.action_special_effect = (WorldAction)Delegate.Combine(SupportRole.action_special_effect, new WorldAction(friendlyAuraEffect));
         SupportRole.type = TraitType.Negative;
         SupportRole.group_id = MBTraitGroup.ModernBox;
         SupportRole.needs_to_be_explored = false;
         SupportRole.special_effect_interval = 5f;
         SupportRole.birth = 0.001f;
         AssetManager.traits.add(SupportRole);
         addTraitToLocalizedLibrary(SupportRole.id, "Heals and cures nearby allies");
         PlayerConfig.unlockTrait("SupportRole");

        }



[HarmonyPatch(typeof(MapBorder), "generateTexture")]
public static class MapBorder_generateTexture_Combined_Patch
{
    static void Postfix(MapBorder __instance)
    {
        BannerLoader loader = __instance.GetComponent<BannerLoader>();
        if (loader == null || loader.kingdom == null)
            return;

        Kingdom kingdom = loader.kingdom;
        string dynamicId = Traits.GetDynamicBannerId(kingdom);
        BannerContainer bannerContainer;

        if (!BannerGenerator.dict.TryGetValue(dynamicId, out bannerContainer))
        {
            if (!BannerGenerator.dict.TryGetValue(kingdom.race.banner_id, out bannerContainer))
                return;
        }

        if (kingdom.data.banner_background_id < 0 || kingdom.data.banner_background_id >= bannerContainer.backrounds.Count)
            kingdom.data.banner_background_id = 0;

        if (kingdom.data.banner_icon_id < 0 || kingdom.data.banner_icon_id >= bannerContainer.icons.Count)
            kingdom.data.banner_icon_id = 0;

        loader.partBackround.sprite = bannerContainer.backrounds[kingdom.data.banner_background_id];
        loader.partIcon.sprite = bannerContainer.icons[kingdom.data.banner_icon_id];

        if (!loader.gameObject.name.StartsWith("KingdomBanner_"))
            return;

        Transform flagTransform = __instance.transform.Find("KingdomFlag");
        GameObject flagGO;

        if (flagTransform == null)
        {
            flagGO = new GameObject("KingdomFlag");
            flagGO.transform.SetParent(__instance.transform, false);

            SpriteRenderer flagSR = flagGO.AddComponent<SpriteRenderer>();
            SpriteRenderer borderSR = __instance.GetComponent<SpriteRenderer>();
            if (borderSR != null)
                flagSR.sortingOrder = borderSR.sortingOrder + 1;
        }
        else
        {
            flagGO = flagTransform.gameObject;
        }

        Sprite flagSprite = bannerContainer.icons[kingdom.data.banner_icon_id];
        if (flagSprite == null)
            return;

        SpriteRenderer srFlag = flagGO.GetComponent<SpriteRenderer>();
        srFlag.sprite = flagSprite;
        srFlag.color = new Color(0.85f, 0.85f, 0.85f, 1f);

        SpriteRenderer borderRenderer = __instance.GetComponent<SpriteRenderer>();
        if (borderRenderer == null)
            return;

        Vector3 topRightWorld = borderRenderer.bounds.max;
        Vector3 topRightLocal = __instance.transform.InverseTransformPoint(topRightWorld);

        Vector3 flagSize = flagSprite.bounds.size;
        Vector3 offset = new Vector3(flagSize.x / 2f, flagSize.y / 2f, 0f);
        flagGO.transform.localPosition = topRightLocal - offset;

        flagGO.transform.localScale = new Vector3(0.5f, 0.5f, 1f);
    }
}




[HarmonyPatch(typeof(BannerLoader), "load")]
public static class Combined_BannerLoader_Load_Patch
{
    static void Postfix(BannerLoader __instance, Kingdom pKingdom)
    {
        if (__instance == null || pKingdom == null)
            return;

        string dynamicId = Traits.GetDynamicBannerId(pKingdom);
        BannerContainer bannerContainer;
        if (!BannerGenerator.dict.TryGetValue(dynamicId, out bannerContainer))
        {
            if (!BannerGenerator.dict.TryGetValue(pKingdom.race.banner_id, out bannerContainer))
                return;
        }

        if (pKingdom.data.banner_background_id < 0 || pKingdom.data.banner_background_id >= bannerContainer.backrounds.Count)
            pKingdom.data.banner_background_id = 0;
        if (pKingdom.data.banner_icon_id < 0 || pKingdom.data.banner_icon_id >= bannerContainer.icons.Count)
            pKingdom.data.banner_icon_id = 0;

        __instance.partBackround.sprite = bannerContainer.backrounds[pKingdom.data.banner_background_id];
        __instance.partIcon.sprite = bannerContainer.icons[pKingdom.data.banner_icon_id];
        __instance.partBackround.color = pKingdom.kingdomColor.getColorMain2();
        __instance.partIcon.color = pKingdom.kingdomColor.getColorBanner();

        if (!__instance.gameObject.name.StartsWith("KingdomBanner_"))
            return;
        if (__instance.GetComponentInParent<MapText>() == null)
            return;

        Transform parent = __instance.partIcon.transform.parent;
        Transform existing = parent.Find("BigOverlayLogo");
        Sprite emblem = bannerContainer.icons[pKingdom.data.banner_icon_id];
        if (emblem == null)
            return;

        if (existing != null)
        {
            Image overlayIcon = existing.GetComponent<Image>();
            overlayIcon.sprite = emblem;
            overlayIcon.color = new Color(0.85f, 0.85f, 0.85f, 1f);
            return;
        }

        GameObject clone = UnityEngine.Object.Instantiate(__instance.partIcon.gameObject, parent);
        clone.name = "BigOverlayLogo";
        Image icon = clone.GetComponent<Image>();
        RectTransform rt = icon.rectTransform;
        rt.localScale = new Vector3(5f, 5f, 1f);
        rt.pivot = new Vector2(0.5f, 0.5f);
        rt.anchorMin = new Vector2(0.5f, 0.5f);
        rt.anchorMax = new Vector2(0.5f, 0.5f);
        rt.anchoredPosition = Vector2.zero;
        icon.sprite = emblem;
        icon.color = new Color(0.85f, 0.85f, 0.85f, 1f);
        clone.transform.SetAsFirstSibling();
    }
}


      [HarmonyPatch(typeof(Kingdom), "generateBanner")]
    public static class Kingdom_GenerateBanner_Patch
    {
        static void Postfix(Kingdom __instance, bool pReset)
        {
            string dynamicId = Traits.GetDynamicBannerId(__instance);
            if (BannerGenerator.dict.ContainsKey(dynamicId))
            {
                BannerContainer bannerContainer = BannerGenerator.dict[dynamicId];
                if (__instance.data.banner_icon_id == -1)
                {
                    __instance.data.banner_icon_id = Toolbox.randomInt(0, bannerContainer.icons.Count);
                }
                if (__instance.data.banner_background_id == -1)
                {
                    __instance.data.banner_background_id = Toolbox.randomInt(0, bannerContainer.backrounds.Count);
                }
            }
        }
    }

public static string GetDynamicBannerId(Kingdom kingdom)
{
    if (kingdom == null || kingdom.race == null)
        return "human";

    string lowerRace = kingdom.race.id.ToLower();

    if (lowerRace != "human" && lowerRace != "orc" && lowerRace != "dwarf" && lowerRace != "elf")
        return kingdom.race.banner_id;

    string baseBannerId = kingdom.race.banner_id;
    Actor king = kingdom.king;
    if (king != null)
    {
        if (king.hasTrait("Peoplewoven"))
            return "communist" + baseBannerId;
        else if (king.hasTrait("Martial"))
            return "fascist" + baseBannerId;
        else if (king.hasTrait("Mercantile"))
            return "capitalist" + baseBannerId;
        else if (king.hasTrait("Dynastic"))
            return "monarch" + baseBannerId;
        else if (king.hasTrait("Chaosvolt"))
            return "anarch" + baseBannerId;

    }
    return baseBannerId;
}


[HarmonyPatch(typeof(KingdomBehCheckKing), "execute")]
public static class KingdomBehCheckKing_IdeologyPatch {
    static void Postfix(Kingdom pKingdom) {
        if (pKingdom == null)
            return;

        Actor king = pKingdom.king;
        if (king == null || !king.isAlive())
            return;

        string[] commonIdeologies = new string[] { "Peoplewoven", "Martial", "Mercantile", "Dynastic" };

        bool kingHasIdeology = false;
        foreach (string trait in commonIdeologies) {
            if (king.hasTrait(trait)) {
                kingHasIdeology = true;
                break;
            }
        }

        bool kingHasChaosvolt = king.hasTrait("Chaosvolt");
        if (kingHasChaosvolt)
            kingHasIdeology = true;

        if (!kingHasIdeology) {
            string chosenIdeology = commonIdeologies[Toolbox.randomInt(0, commonIdeologies.Length)];
            king.addTrait(chosenIdeology);
            kingHasIdeology = true;
        }

        string kingIdeology = null;
        foreach (string trait in commonIdeologies) {
            if (king.hasTrait(trait)) {
                kingIdeology = trait;
                break;
            }
        }

        if (kingIdeology == null && kingHasChaosvolt)
            kingIdeology = "Chaosvolt";

        if (string.IsNullOrEmpty(kingIdeology))
            return;

        foreach (Actor actor in pKingdom.units.getSimpleList()) {
            if (actor == null || actor == king)
                continue;

            bool actorHasIdeology = false;
            foreach (string trait in commonIdeologies) {
                if (actor.hasTrait(trait)) {
                    actorHasIdeology = true;
                    break;
                }
            }

            if (actor.hasTrait("Chaosvolt"))
                actorHasIdeology = true;

            if (kingHasChaosvolt) {
                if (!actor.hasTrait("Chaosvolt")) {
                    if (!actorHasIdeology) {
                        actor.addTrait("Chaosvolt");
                    }
                    else if (Toolbox.randomChance(0.4f)) {
                        actor.addTrait("Chaosvolt");
                    }
                }
            }
            else {
                if (!actorHasIdeology) {
                    actor.addTrait(kingIdeology);
                }
                else if (!actor.hasTrait(kingIdeology) && Toolbox.randomChance(0.4f)) {
                    actor.addTrait(kingIdeology);
                }
            }
        }
    }
}





        public static bool friendlyAuraEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    if (Toolbox.randomChance(0.4f))
    {
        World.world.getObjectsInChunks(pTile, 4, MapObjectType.Actor);
        Actor auraOwner = pTarget.a;

        string[] negativeTraits = new string[]
        {
            "plague", "crippled", "mushSpores", "tumorInfection", "cursed", "skin_burns", "eyepatch", "infected"
        };

        string[] negativeStatuses = new string[]
        {
            "burning", "frozen", "poisoned", "slowness", "cough", "ash_fever"
        };

        string[] buffStatuses = new string[]
          { "powerup", "shield", "caffeinated", "rage", "powerup" , "enchanted", "invincible" };

        for (int i = 0; i < World.world.temp_map_objects.Count; i++)
        {
            Actor actor = (Actor)World.world.temp_map_objects[i];

            if (actor != auraOwner &&
                actor.data.health < actor.getMaxHealth() &&
                actor.kingdom == auraOwner.kingdom)
            {
                actor.restoreHealth(40);
                actor.spawnParticle(Toolbox.color_heal);

                foreach (string trait in negativeTraits)
                {
                    actor.removeTrait(trait);
                }
                foreach (string status in negativeStatuses)
                {
                    actor.finishStatusEffect(status);
                }

                if (Toolbox.randomChance(0.5f))
                {
                    int index = UnityEngine.Random.Range(0, buffStatuses.Length);
                    string selectedBuff = buffStatuses[index];
                    actor.addStatusEffect(selectedBuff);
                }
            }
        }
    }
    return true;
}



public static bool UnitpotentialEffect(BaseSimObject pTarget, WorldTile pTile = null)
{
    Actor actor = pTarget?.a;
    if (actor == null)
        return false;

    HandleCartTransformation(actor, pTile);
   cloneVehicleBasedOnCityCount(pTarget, pTile);
   NomadHandlerEffect(pTarget, pTile);
    HandleLandAirUnitTransformations(actor, pTile);
    HandleOrcBoatTransformations(actor, pTile);

    return true;
}

private static void HandleCartTransformation(Actor a, WorldTile pTile)
{
    if (a.asset.id != "baseoffensiveunit")
        return;

    bool useSupport = Toolbox.randomChance(0.2f);
    string raceCategory = "human";
    if (a.kingdom != null)
    {
        string kRace = a.kingdom.asset.id.ToLower();
        if (CartTransformations.OffensiveOptions.ContainsKey(kRace))
        {
            raceCategory = kRace;
        }
    }

    if (a.city != null)
    {
        int spawnedCount = 0;
        foreach (Actor unit in a.city.units.getSimpleList())
        {
            if (unit.hasTrait("spawnedvehicle"))
                spawnedCount++;
        }
        if (spawnedCount >= 20)
        {
            return;
        }
    }

    Culture culture = World.world.cultures.get(a.data.culture);
    List<string> candidates = new List<string>();

    if (!useSupport)
    {
        var options = CartTransformations.OffensiveOptions[raceCategory];
        if (culture != null)
        {
            if (culture.hasTech("Future") && options.ContainsKey("future"))
                candidates.AddRange(options["future"]);
            else if (culture.hasTech("MilitaryModern") && options.ContainsKey("modern"))
                candidates.AddRange(options["modern"]);
            else if (culture.hasTech("Firearms") && options.ContainsKey("industrial"))
                candidates.AddRange(options["industrial"]);
            else if (culture.hasTech("Renaissance") && options.ContainsKey("renaissance"))
                candidates.AddRange(options["renaissance"]);
            else if (culture.hasTech("Medieval") && options.ContainsKey("medieval"))
                candidates.AddRange(options["medieval"]);
        }
    }
    else
    {
        var options = CartTransformations.SupportOptions[raceCategory];
        if (culture != null)
        {
            if (culture.hasTech("Future") && options.ContainsKey("future"))
                candidates.AddRange(options["future"]);
            else if (culture.hasTech("MilitaryModern") && options.ContainsKey("modern"))
                candidates.AddRange(options["modern"]);
            else if (culture.hasTech("Firearms") && options.ContainsKey("industrial"))
                candidates.AddRange(options["industrial"]);
            else if (culture.hasTech("Renaissance") && options.ContainsKey("renaissance"))
                candidates.AddRange(options["renaissance"]);
            else if (culture.hasTech("Medieval") && options.ContainsKey("medieval"))
                candidates.AddRange(options["medieval"]);
        }
    }

    float transformationChance = 0.5f;
    if (Toolbox.randomChance(transformationChance) && candidates.Count > 0)
    {
        int index = Toolbox.randomInt(0, candidates.Count);
        string chosenTransformation = candidates[index];
        TransformUnit(a, chosenTransformation, pTile);
    }
}




public static class CartTransformations
{
  public static Dictionary<string, Dictionary<string, List<string>>> OffensiveOptions =
        new Dictionary<string, Dictionary<string, List<string>>>
    {
         { "human", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "SpaceMarine" , "HeliELite" , "eliteGunship" , "TIEfighter" , "EliteBomber" , "F55FighterJet" , "P9000" , "Terran" , "dreadnaught" , "Railgun" , "teslatruckgun" , "HumanTitan" , "MA9000" , "atst" } },
            { "modern",      new List<string>{ "Heli" , "MIRVBomber" , "FighterJet" , "Tank" , "MissileSystem" , "wheeledtank" , "modernhumvee" , "wwartillery" } },
            { "industrial",  new List<string>{ "Zeppelin" , "EliteZeppelin" , "AbramTank" , "shermanww" , "Humvee" , "tankie" , "genericwwtank" , "landship" , "bigtankww" , "americanbomberww" , "biplane" , "wwartillery" } },
            { "renaissance", new List<string>{ "humancavalry" , "balloonunit" , "humancannon" , "davincitank" } },
            { "medieval",    new List<string>{ "catapulta" , "batteringram" , "humancavalry" } }
        }},
        { "orc", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "spaceork" , "HeliELite" , "eliteGunship" , "TIEfighter" , "EliteBomber" , "F55FighterJet" , "P9000" , "Terran" , "dreadnaught" , "Railgun" , "teslatruckgun" , "HumanTitan" , "MA9000" , "atst" } },
           { "modern",      new List<string>{ "Heli" , "MIRVBomber" , "FighterJet" , "Tank" , "MissileSystem" , "wheeledtank" , "modernhumvee" , "wwartillery" } },
            { "industrial",  new List<string>{ "Zeppelin" , "EliteZeppelin" , "AbramTank" , "shermanww" , "Humvee" , "tankie" , "genericwwtank" , "landship" , "bigtankww" , "americanbomberww" , "biplane" , "wwartillery" } },
            { "renaissance", new List<string>{ "ogreunit", "orccannon", "armoredwolf" , "davincitank" } },
            { "medieval",    new List<string>{ "orcatapulta" , "ogreunit" , "armoredwolf" } }
        }},
        { "dwarf", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "SpaceMarine" , "HeliELite" , "eliteGunship" , "TIEfighter" , "EliteBomber" , "F55FighterJet" , "P9000" , "Terran" , "dreadnaught" , "Railgun" , "teslatruckgun" , "HumanTitan" , "MA9000" , "atst" } },
            { "modern",      new List<string>{ "Heli" , "MIRVBomber" , "FighterJet" , "Tank" , "MissileSystem" , "wheeledtank" , "modernhumvee" , "wwartillery" } },
            { "industrial",  new List<string>{ "Zeppelin" , "EliteZeppelin" , "AbramTank" , "shermanww" , "Humvee" , "tankie" , "genericwwtank" , "landship" , "bigtankww" , "americanbomberww" , "biplane" , "wwartillery" } },
            { "renaissance", new List<string>{ "santaguin" , "Gunship" , "dwarfcannon" , "davincitank" } },
            { "medieval",    new List<string>{ "santaguin" , "golemgem" } }
        }},
        { "elf", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "SpaceMarine" , "HeliELite" , "eliteGunship" , "TIEfighter" , "EliteBomber" , "F55FighterJet" , "P9000" , "Terran" , "dreadnaught" , "Railgun" , "teslatruckgun" , "HumanTitan" , "MA9000" , "atst" } },
            { "modern",      new List<string>{ "Heli" , "MIRVBomber" , "FighterJet" , "Tank" , "MissileSystem" , "wheeledtank" , "modernhumvee" , "wwartillery" } },
            { "industrial",  new List<string>{ "Zeppelin" , "EliteZeppelin" , "AbramTank" , "shermanww" , "Humvee" , "tankie" , "genericwwtank" , "landship" , "bigtankww" , "americanbomberww" , "biplane" , "wwartillery" } },
            { "renaissance", new List<string>{ "treant" , "elfcannon" , "bigfaerydragon" , "davincitank" } },
            { "medieval",    new List<string>{ "woolyrhino" , "treant" } }
        }}
    };

    public static Dictionary<string, Dictionary<string, List<string>>> SupportOptions =
        new Dictionary<string, Dictionary<string, List<string>>>
    {
        { "human", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "AT9000" , "supportatst" } },
            { "modern",      new List<string>{ "modernsupporttruck" } },
            { "industrial",  new List<string>{ "wwsupporttruck" } },
            { "renaissance", new List<string>{ "humanpaladin" } },
            { "medieval",    new List<string>{ "humanpaladin" } }
        }},
        { "orc", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "AT9000" , "supportatst" } },
            { "modern",      new List<string>{ "modernsupporttruck" } },
            { "industrial",  new List<string>{ "wwsupporttruck" } },
            { "renaissance", new List<string>{ "orcwarlock" } },
            { "medieval",    new List<string>{ "orcwarlock" } }
        }},
        { "dwarf", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "AT9000" , "supportatst" } },
            { "modern",      new List<string>{ "modernsupporttruck" } },
            { "industrial",  new List<string>{ "wwsupporttruck" } },
            { "renaissance", new List<string>{ "dwarfdoctor" } },
            { "medieval",    new List<string>{ "dwarfdoctor" } }
        }},
        { "elf", new Dictionary<string, List<string>> {
            { "future",      new List<string>{ "AT9000" , "supportatst" } },
            { "modern",      new List<string>{ "modernsupporttruck"} },
            { "industrial",  new List<string>{ "wwsupporttruck" } },
            { "renaissance", new List<string>{ "fairelf" } },
            { "medieval",    new List<string>{ "fairydragon" } }
        }}
    };

}

public static bool cloneVehicleBasedOnCityCount(BaseSimObject pTarget, WorldTile pTile = null)
{
    Actor original = pTarget?.a;
    if (original == null || !original.isAlive())
        return false;

    if (original.hasTrait("exhausted"))
        return true;

 if (pTile == null)
        pTile = original.currentTile;

    int numCities = original.kingdom?.cities.Count ?? 0;
    int clonesToSpawn = 0;
    string unitId = original.asset.id.ToLower();

    if (unitId == "Humvee")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

    else if (unitId == "spaceork")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

  else if (unitId == "SpaceMarine")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

    else if (unitId == "HeliELite")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

  else if (unitId == "eliteGunship")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

    else if (unitId == "TIEfighter")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

      else if (unitId == "humancavalry")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

    else if (unitId == "Terran")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

    else if (unitId == "teslatruckgun")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

    else if (unitId == "modernhumvee")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

          else if (unitId == "Heli")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

         else if (unitId == "landship")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

      else if (unitId == "armoredwolf")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

       else if (unitId == "biplane")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }
    else if (unitId == "golemgem")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }
      else if (unitId == "woolyrhino")
    {
        if (numCities == 1)
            clonesToSpawn = 2;
        else if (numCities >= 2 && numCities <= 3)
            clonesToSpawn = 1;
        else
            clonesToSpawn = 0;
    }

    else if (unitId == "balloonunit")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
    else if (unitId == "batteringram")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

   else if (unitId == "catapulta")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
  else if (unitId == "orcatapulta")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

  else if (unitId == "ogreunit")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

    else if (unitId == "santaguin")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

    else if (unitId == "dwarfcannon")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

    else if (unitId == "Gunship")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

          else if (unitId == "treant")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

         else if (unitId == "davincitank")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
        else if (unitId == "bigfaerydragon")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
       else if (unitId == "elfcannon")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

       else if (unitId == "tankie")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

     else if (unitId == "genericwwtank")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
    else if (unitId == "Zeppelin")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
          else if (unitId == "wheeledtank")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
          else if (unitId == "FighterJet")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
        else if (unitId == "dreadnaught")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
            else if (unitId == "P9000")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
      else if (unitId == "Railgun")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

     else if (unitId == "F55FighterJet")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }

    else if (unitId == "Tank")
    {
        clonesToSpawn = (numCities == 1) ? 1 : 0;
    }
    else
    {
        return false;
    }

    if (clonesToSpawn <= 0)
        return false;

       WorldTile spawnTile = original.currentTile;
  for (int i = 0; i < clonesToSpawn; i++)
    {
        Actor clone = World.world.units.createNewUnit(original.asset.id, spawnTile, original.zPosition.y);
        if (clone != null)
        {
            ActorTool.copyUnitToOtherUnit(original, clone);
            if (original.kingdom != null)
                clone.setKingdom(original.kingdom);
            clone.joinCity(original.city);
            clone.addTrait("exhausted");
            clone.removeTrait("spawnedvehicle");
            EffectsLibrary.spawn("fx_spawn", clone.currentTile, clone.zPosition.y.ToString());
            clone.makeWait(1f);
        }
    }
    original.addTrait("exhausted");
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
            actor.getHit(10000000000f);
        }
        return true;
    }


    if (actor.kingdom?.id == "ModernKingdom" || actor.kingdom?.id == "MissileLauncherFULLRANGETARGETTING" ||
        (actor.kingdom?.asset.nomads == true) || (actor.kingdom?.cities.Count == 0))
    {

        actor.getHit(10000000000f);
        return true;
    }


    if (actor.hasTrait("madness"))
    {
        actor.removeTrait("madness");
        actor.getHit(10000000000f);
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

    else if (a.asset.id == "Railgun")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "OmegaRailgun", pTile);
        }
    }

    else if (a.asset.id == "Zeppelin")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "EliteZeppelin", pTile);
        }
    }

    else if (a.asset.id == "P9000")
    {
      if (a.hasTrait("veteran"))
        {
            TransformUnit(a, "EliteP9000", pTile);
        }
    }

    else if (a.asset.id == "SpaceMarine")
    {
      if (a.hasTrait("veteran") && a.hasTrait("skin_burns"))
        {
            TransformUnit(a, "dreadnaught", pTile);
        }
        else if (a.hasTrait("veteran") && a.hasTrait("crippled"))
        {
            TransformUnit(a, "dreadnaught", pTile);
        }
    }

   else if (a.asset.id == "HumanTitan")
    {
     if (a.data.kills > 200)
            {
                TransformUnit(a, "HumanTitanElite", pTile);
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

    float transformationChance = 0.1f;

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
        return;

    ActorTool.copyUnitToOtherUnit(originalActor, newActor);
    if (originalActor.kingdom != null)
        newActor.setKingdom(originalActor.kingdom);
    newActor.joinCity(originalActor.city);

    if (originalActor.homeBuilding != null)
    {
        newActor.setHomeBuilding(originalActor.homeBuilding);
        UnitSpawner spawner = originalActor.homeBuilding.GetComponent<UnitSpawner>();
        if (spawner != null)
        {
            spawner.units.Remove(originalActor);
            spawner.units_current = Math.Max(0, spawner.units_current - 1);
            spawner.setUnitFromHere(newActor);
        }
    }

    EffectsLibrary.spawn("fx_spawn", newActor.currentTile);
    ActionLibrary.removeUnit(originalActor);
    newActor.addTrait("spawnedvehicle");
}



[HarmonyPatch(typeof(UnitSpawner), "update")]
public static class UnitSpawner_Update_Patch {
    static void Postfix(UnitSpawner __instance, float pElapsed) {
        List<Actor> deadUnits = new List<Actor>();
        foreach(var unit in __instance.units) {
            if (!unit.isAlive()) {
                deadUnits.Add(unit);
            }
        }
        foreach(var dead in deadUnits) {
            __instance.callbackUnitDied(dead);
        }
    }
}



private static void TransformUnitNOBUILDING(Actor originalActor, string newActorId, WorldTile pTile)
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
        if (!string.IsNullOrEmpty(buildingID))
        {
            MapBox.instance.buildings.addBuilding(buildingID, targetTile, false, false, BuildPlacingType.New);
        }
    }

    return true;
}

private static string GetBuildingForActor(Actor actor)
{
    switch (actor.asset.id)
    {
        case "Terran":
            return "Terran_scraps";
        case "MissileSystem":
            return "MissileSystem_scraps";
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
        case "Gunship":
            return "Gunship_scraps";
        case "Heli":
            return "Heli_scraps";
               case "spaceork":
            return "SpaceMarine_scraps";
              case "AbramTank":
            return "AbramTank_scraps";
        case "dreadnaught":
            return "dreadnaught_scraps";
        case "EliteBomber":
            return "EliteBomber_scraps";
        case "eliteGunship":
            return "eliteGunship_scraps";
        case "EliteP9000":
            return "EliteP9000_scraps";
        case "EliteZeppelin":
            return "EliteZeppelin_scraps";
        case "shermanww":
            return "shermanww_scraps";
        case "F55FighterJet":
            return "FighterJet_scraps";
        case "HeliELite":
            return "HeliELite_scraps";
        case "SpaceMarine":
            return "SpaceMarine_scraps";
               case "TIEfighter":
            return "TIEfighter_scraps";
        case "americanbomberww":
            return "americanbomberww_scraps";
        case "AT9000":
            return "AT9000_scraps";
        case "balloonunit":
            return "balloonunit_scraps";
        case "bigtankww":
            return "bigtankww_scraps";
        case "biplane":
            return "biplane_scraps";
        case "davincitank":
            return "davincitank_scraps";
        case "P9000":
            return "P9000_scraps";
        case "genericwwtank":
            return "genericwwtank_scraps";
        case "HumanTitan":
            return "HumanTitan_scraps";
               case "HumanTitanElite":
            return "HumanTitanElite_scraps";
              case "landship":
            return "landship_scraps";
        case "MA9000":
            return "MA9000_scraps";
        case "modernhumvee":
            return "modernhumvee_scraps";
        case "modernsupporttruck":
            return "modernsupporttruck_scraps";
        case "OmegaRailgun":
            return "OmegaRailgun_scraps";
        case "Railgun":
            return "Railgun_scraps";
        case "tankie":
            return "tankie_scraps";
        case "teslatruckgun":
            return "teslatruckgun_scraps";
        case "wheeledtank":
            return "wheeledtank_scraps";
        case "wwartillery":
            return "wwartillery_scraps";
               case "wwsupporttruck":
            return "wwsupporttruck_scraps";
        default:
        return "";
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
