//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using NCMS.Utils;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Threading;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using UnityEngine.UI;
using System.IO;
using pathfinding;
using System.Reflection;

namespace M2 {
class UpgradesUwU {

       public static void init(){


BuildingAsset moaiemoji = AssetManager.buildings.get("statue");
moaiemoji.priority = 8888888;
moaiemoji.cost = new ConstructionCost(0, 1, 0, 1);

     //========= BARRACKS ============//
//
//
//
//=============================================================================//




BuildingAsset baseBarracks = AssetManager.buildings.get("barracks_human");
baseBarracks.upgradeLevel = 1;
baseBarracks.canBeUpgraded = true;
baseBarracks.priority = 8888888;
baseBarracks.fundament = new BuildingFundament(3, 3, 4, 0);
baseBarracks.cost = new ConstructionCost(0, 0, 0, 1);
baseBarracks.race = SK.human;
baseBarracks.shadow = false;
baseBarracks.type = SB.type_barracks;
baseBarracks.upgradeTo = "Barracks_rain_human";
baseBarracks.spawnUnits = true;
baseBarracks.spawnUnits_asset = "baseoffensiveunit";

BuildingAsset Barracks_rain_human = AssetManager.buildings.clone("Barracks_rain_human", "barracks_human");
Barracks_rain_human.id = "Barracks_rain_human";
Barracks_rain_human.upgradeLevel = 2;
Barracks_rain_human.priority = 300;
Barracks_rain_human.upgradedFrom = "barracks_human";
Barracks_rain_human.canBeUpgraded = true;
Barracks_rain_human.upgradeTo = "Barracks_industrial_human";
Barracks_rain_human.race = SK.human;
Barracks_rain_human.shadow = false;
Barracks_rain_human.fundament = new BuildingFundament(1, 1, 2, 0);
Barracks_rain_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
Barracks_rain_human.tech = "Renaissance";
Barracks_rain_human.base_stats[S.health] = 500f;
Barracks_rain_human.type = SB.type_barracks;
Barracks_rain_human.sprite_path = "buildings/Barracks_rain_human";
AssetManager.buildings.loadSprites(Barracks_rain_human);
AssetManager.buildings.add(Barracks_rain_human);


BuildingAsset Barracks_industrial_human = AssetManager.buildings.clone("Barracks_industrial_human", "barracks_human");
Barracks_industrial_human.id = "Barracks_industrial_human";
Barracks_industrial_human.upgradeLevel = 3;
Barracks_industrial_human.priority = 400;
Barracks_industrial_human.upgradedFrom = "Barracks_rain_human";
Barracks_industrial_human.canBeUpgraded = true;
Barracks_industrial_human.upgradeTo = "Barracks_modern_human";
Barracks_industrial_human.race = SK.human;
Barracks_industrial_human.smoke = true;
Barracks_industrial_human.type = SB.type_barracks;
Barracks_industrial_human.smokeInterval = 2.5f;
Barracks_industrial_human.smokeOffset = new Vector2Int(2, 3);
Barracks_industrial_human.shadow = false;
Barracks_industrial_human.fundament = new BuildingFundament(1, 1, 2, 0);
Barracks_industrial_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
Barracks_industrial_human.tech = "Firearms";
Barracks_industrial_human.base_stats[S.health] = 700f;
Barracks_industrial_human.sprite_path = "buildings/Barracks_industrial_human";
AssetManager.buildings.loadSprites(Barracks_industrial_human);
AssetManager.buildings.add(Barracks_industrial_human);


BuildingAsset Barracks_modern_human = AssetManager.buildings.clone("Barracks_modern_human", "barracks_human");
Barracks_modern_human.id = "Barracks_modern_human";
Barracks_modern_human.upgradeLevel = 4;
Barracks_modern_human.priority = 500;
Barracks_modern_human.upgradedFrom = "Barracks_industrial_human";
Barracks_modern_human.canBeUpgraded = true;
Barracks_modern_human.upgradeTo = "Barracks_future_human";
Barracks_modern_human.race = SK.human;
Barracks_modern_human.type = SB.type_barracks;
Barracks_modern_human.shadow = false;
Barracks_modern_human.fundament = new BuildingFundament(1, 1, 2, 0);
Barracks_modern_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
Barracks_modern_human.tech = "MilitaryModern";
Barracks_modern_human.base_stats[S.health] = 1000f;
Barracks_modern_human.sprite_path = "buildings/Barracks_modern_human";
AssetManager.buildings.loadSprites(Barracks_modern_human);
AssetManager.buildings.add(Barracks_modern_human);

BuildingAsset Barracks_future_human = AssetManager.buildings.clone("Barracks_future_human", "barracks_human");
Barracks_future_human.id = "Barracks_future_human";
Barracks_future_human.upgradeLevel = 5;
Barracks_future_human.priority = 600;
Barracks_future_human.upgradedFrom = "Barracks_modern_human";
Barracks_future_human.canBeUpgraded = false;
Barracks_future_human.upgradeTo = "Barracks_future_human";
Barracks_future_human.race = SK.human;
Barracks_future_human.type = SB.type_barracks;
Barracks_future_human.shadow = false;
Barracks_future_human.fundament = new BuildingFundament(1, 1, 2, 0);
Barracks_future_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
Barracks_future_human.tech = "Future";
Barracks_future_human.base_stats[S.health] = 2000f;
Barracks_future_human.sprite_path = "buildings/Barracks_future_human";
AssetManager.buildings.loadSprites(Barracks_future_human);
AssetManager.buildings.add(Barracks_future_human);



            //========= WATCH TOWER ============//
//
//
//
//=============================================================================//


BuildingAsset basewatch_tower = AssetManager.buildings.get("watch_tower_human");
basewatch_tower.upgradeLevel = 1;
basewatch_tower.canBeUpgraded = true;
basewatch_tower.upgradeTo = "watch_tower_rain_human";
basewatch_tower.priority = 200;

BuildingAsset watch_tower_rain_human = AssetManager.buildings.clone("watch_tower_rain_human", "watch_tower_human");
watch_tower_rain_human.id = "watch_tower_rain_human";
watch_tower_rain_human.upgradeLevel = 2;
watch_tower_rain_human.priority = 300;
watch_tower_rain_human.upgradedFrom = "watch_tower_human";
watch_tower_rain_human.canBeUpgraded = true;
watch_tower_rain_human.upgradeTo = "watch_tower_industrial_human";
watch_tower_rain_human.race = SK.human;
watch_tower_rain_human.shadow = false;
watch_tower_rain_human.fundament = new BuildingFundament(1, 1, 1, 0);
watch_tower_rain_human.cost = new ConstructionCost(1, 10, 5, 1); //wood, stone, metals, gold
watch_tower_rain_human.tech = "Renaissance";
watch_tower_rain_human.base_stats[S.targets] = 1f;
watch_tower_rain_human.base_stats[S.area_of_effect] = 1f;
watch_tower_rain_human.base_stats[S.damage] = 20f;
watch_tower_rain_human.base_stats[S.knockback] = 2f;
watch_tower_rain_human.base_stats[S.range] = 20f;
watch_tower_rain_human.base_stats[S.attack_speed] = 10;
watch_tower_rain_human.tower_projectile = "cannonballprojectile";
watch_tower_rain_human.tower_projectile_offset = 4f;
watch_tower_rain_human.tower_projectile_amount = 4;
watch_tower_rain_human.base_stats[S.health] = 5000f;
watch_tower_rain_human.sprite_path = "buildings/watch_tower_rain_human";
AssetManager.buildings.loadSprites(watch_tower_rain_human);
AssetManager.buildings.add(watch_tower_rain_human);


BuildingAsset watch_tower_industrial_human = AssetManager.buildings.clone("watch_tower_industrial_human", "watch_tower_human");
watch_tower_industrial_human.id = "watch_tower_industrial_human";
watch_tower_industrial_human.upgradeLevel = 3;
watch_tower_industrial_human.priority = 400;
watch_tower_industrial_human.upgradedFrom = "watch_tower_rain_human";
watch_tower_industrial_human.canBeUpgraded = true;
watch_tower_industrial_human.upgradeTo = "watch_tower_modern_human";
watch_tower_industrial_human.race = SK.human;
watch_tower_industrial_human.smoke = true;
watch_tower_industrial_human.smokeInterval = 2.5f;
watch_tower_industrial_human.smokeOffset = new Vector2Int(2, 3);
watch_tower_industrial_human.shadow = false;
watch_tower_industrial_human.fundament = new BuildingFundament(1, 1, 1, 0);
watch_tower_industrial_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
watch_tower_industrial_human.tech = "Industrial";
watch_tower_industrial_human.base_stats[S.targets] = 1f;
watch_tower_industrial_human.base_stats[S.area_of_effect] = 1f;
watch_tower_industrial_human.base_stats[S.damage] = 10f;
watch_tower_industrial_human.base_stats[S.knockback] = 0f;
watch_tower_industrial_human.base_stats[S.range] = 30f;
watch_tower_industrial_human.base_stats[S.attack_speed] = 10000;
watch_tower_industrial_human.tower_projectile = "shotgun_bullet";
watch_tower_industrial_human.tower_projectile_offset = 4f;
watch_tower_industrial_human.tower_projectile_amount = 1;
watch_tower_industrial_human.base_stats[S.health] = 5000f;
watch_tower_industrial_human.sprite_path = "buildings/watch_tower_industrial_human";
AssetManager.buildings.loadSprites(watch_tower_industrial_human);
AssetManager.buildings.add(watch_tower_industrial_human);

BuildingAsset watch_tower_modern_human = AssetManager.buildings.clone("watch_tower_modern_human", "watch_tower_human");
watch_tower_modern_human.id = "watch_tower_modern_human";
watch_tower_modern_human.upgradeLevel = 4;
watch_tower_modern_human.priority = 500;
watch_tower_modern_human.upgradedFrom = "watch_tower_industrial_human";
watch_tower_modern_human.canBeUpgraded = true;
watch_tower_modern_human.upgradeTo = "watch_tower_future_human";
watch_tower_modern_human.race = SK.human;
watch_tower_modern_human.shadow = false;
watch_tower_modern_human.fundament = new BuildingFundament(1, 1, 1, 0);
watch_tower_modern_human.cost = new ConstructionCost(0, 1, 5, 5); //wood, stone, metals, gold
watch_tower_modern_human.tech = "MilitaryModern";
watch_tower_modern_human.base_stats[S.targets] = 1f;
watch_tower_modern_human.base_stats[S.area_of_effect] = 1f;
watch_tower_modern_human.base_stats[S.damage] = 200f;
watch_tower_modern_human.base_stats[S.knockback] = 6f;
watch_tower_modern_human.base_stats[S.range] = 100f;
watch_tower_modern_human.base_stats[S.attack_speed] = 1;
watch_tower_modern_human.tower_projectile = "artilleryshell";
watch_tower_modern_human.tower_projectile_offset = 4f;
watch_tower_modern_human.tower_projectile_amount = 1;
watch_tower_modern_human.base_stats[S.health] = 6000f;
watch_tower_modern_human.sprite_path = "buildings/watch_tower_modern_human";
AssetManager.buildings.loadSprites(watch_tower_modern_human);
AssetManager.buildings.add(watch_tower_modern_human);


BuildingAsset watch_tower_future_human = AssetManager.buildings.clone("watch_tower_future_human", "watch_tower_human");
watch_tower_future_human.id = "watch_tower_future_human";
watch_tower_future_human.upgradeLevel = 5;
watch_tower_future_human.priority = 600;
watch_tower_future_human.upgradedFrom = "watch_tower_industrial_human";
watch_tower_future_human.canBeUpgraded = false;
watch_tower_future_human.upgradeTo = "watch_tower_future_human";
watch_tower_future_human.race = SK.human;
watch_tower_future_human.shadow = false;
watch_tower_future_human.fundament = new BuildingFundament(1, 1, 1, 0);
watch_tower_future_human.cost = new ConstructionCost(0, 1, 10, 10); //wood, stone, metals, gold
watch_tower_future_human.tech = "Future";
watch_tower_future_human.base_stats[S.targets] = 1f;
watch_tower_future_human.base_stats[S.area_of_effect] = 1f;
watch_tower_future_human.base_stats[S.damage] = 1000f;
watch_tower_future_human.base_stats[S.knockback] = 3f;
watch_tower_future_human.base_stats[S.range] = 150f;
watch_tower_future_human.base_stats[S.attack_speed] = 100;
watch_tower_future_human.tower_projectile = "big_plasma_bomb";
watch_tower_future_human.tower_projectile_offset = 4f;
watch_tower_future_human.tower_projectile_amount = 1;
watch_tower_future_human.base_stats[S.health] = 7000f;
watch_tower_future_human.sprite_path = "buildings/watch_tower_future_human";
AssetManager.buildings.loadSprites(watch_tower_future_human);
AssetManager.buildings.add(watch_tower_future_human);



            //========= HOUSES ============//
//
//
//
//=============================================================================//


BuildingAsset tent_human = AssetManager.buildings.get("tent_human");
tent_human.fundament = new BuildingFundament(1, 1, 0, 1);

BuildingAsset basehouse_human_0 = AssetManager.buildings.get("house_human_0");
basehouse_human_0.upgradeLevel = 1;
basehouse_human_0.fundament = new BuildingFundament(1, 1, 0, 1);
basehouse_human_0.cost = new ConstructionCost(1, 0, 0, 0);

BuildingAsset basehouse_human_1 = AssetManager.buildings.get("house_human_1");
basehouse_human_1.upgradeLevel = 1;
basehouse_human_1.priority = 20;
basehouse_human_1.fundament = new BuildingFundament(1, 1, 0, 1);
basehouse_human_1.cost = new ConstructionCost(1, 1, 0, 0);

BuildingAsset basehouse_human_2 = AssetManager.buildings.get("house_human_2");
basehouse_human_2.upgradeLevel = 2;
basehouse_human_2.priority = 30;
basehouse_human_2.fundament = new BuildingFundament(1, 1, 0, 1);
basehouse_human_2.cost = new ConstructionCost(1, 1, 0, 0);

BuildingAsset basehouse_human_3 = AssetManager.buildings.get("house_human_3");
basehouse_human_3.upgradeLevel = 3;
basehouse_human_3.priority = 40;
basehouse_human_3.fundament = new BuildingFundament(1, 1, 0, 1);
basehouse_human_3.cost = new ConstructionCost(1, 1, 0, 0);

BuildingAsset basehouse_human_4 = AssetManager.buildings.get("house_human_4");
basehouse_human_4.upgradeLevel = 4;
basehouse_human_4.priority = 50;
basehouse_human_4.fundament = new BuildingFundament(1, 1, 0, 1);
basehouse_human_4.cost = new ConstructionCost(1, 1, 0, 0);

BuildingAsset basehouse_human_5 = AssetManager.buildings.get("house_human_5");
basehouse_human_5.upgradeLevel = 5;
basehouse_human_5.priority = 60;
basehouse_human_5.fundament = new BuildingFundament(1, 1, 0, 1);
basehouse_human_5.cost = new ConstructionCost(1, 1, 0, 1);
basehouse_human_5.canBeUpgraded = true;
basehouse_human_5.upgradeTo = "house_industrial_human";
basehouse_human_5.tech = "Renaissance";

BuildingAsset house_industrial_human = AssetManager.buildings.clone("house_industrial_human", "house_human_5");
house_industrial_human.id = "house_industrial_human";
house_industrial_human.upgradeLevel = 6;
house_industrial_human.housing = 12;
house_industrial_human.priority = 70;
house_industrial_human.upgradedFrom = "house_human_5";
house_industrial_human.canBeUpgraded = true;
house_industrial_human.upgradeTo = "house_modern_human";
house_industrial_human.race = SK.human;
house_industrial_human.smoke = true;
house_industrial_human.smokeInterval = 2.5f;
house_industrial_human.smokeOffset = new Vector2Int(2, 3);
house_industrial_human.shadow = false;
house_industrial_human.fundament = new BuildingFundament(1, 1, 0, 1);
house_industrial_human.cost = new ConstructionCost(0, 1, 1, 0); //wood, stone, metals, gold
house_industrial_human.tech = "Industrial";
house_industrial_human.base_stats[S.health] = 800f;
house_industrial_human.sprite_path = "buildings/house_industrial_human";
AssetManager.buildings.loadSprites(house_industrial_human);
AssetManager.buildings.add(house_industrial_human);


BuildingAsset house_modern_human = AssetManager.buildings.clone("house_modern_human", "house_human_5");
house_modern_human.id = "house_modern_human";
house_modern_human.upgradeLevel = 7;
house_modern_human.housing = 16;
house_modern_human.priority = 80;
house_modern_human.upgradedFrom = "house_industrial_human";
house_modern_human.canBeUpgraded = true;
house_modern_human.upgradeTo = "house_future_human";
house_modern_human.race = SK.human;
house_modern_human.shadow = false;
house_modern_human.fundament = new BuildingFundament(1, 1, 0, 1);
house_modern_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
house_modern_human.tech = "Skyscraper";
house_modern_human.base_stats[S.health] = 1000f;
house_modern_human.sprite_path = "buildings/house_modern_human";
AssetManager.buildings.loadSprites(house_modern_human);
AssetManager.buildings.add(house_modern_human);


BuildingAsset house_future_human = AssetManager.buildings.clone("house_future_human", "house_human_5");
house_future_human.id = "house_future_human";
house_future_human.upgradeLevel = 8;
house_future_human.housing = 20;
house_future_human.priority = 90;
house_future_human.upgradedFrom = "house_modern_human";
house_future_human.canBeUpgraded = false;
house_future_human.upgradeTo = "house_future_human";
house_future_human.race = SK.human;
house_future_human.shadow = false;
house_future_human.fundament = new BuildingFundament(1, 1, 0, 1);
house_future_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
house_future_human.tech = "Future";
house_future_human.base_stats[S.health] = 2000f;
house_future_human.sprite_path = "buildings/house_future_human";
AssetManager.buildings.loadSprites(house_future_human);
AssetManager.buildings.add(house_future_human);



            //========= HALLS ============//
//
//
//
//=============================================================================//

BuildingAsset hallhuman_1 = AssetManager.buildings.get("hall_human_1");
hallhuman_1.upgradeLevel = 1;
hallhuman_1.priority = 200;
hallhuman_1.cost = new ConstructionCost(1, 1, 0, 1);

BuildingAsset hallhuman_2 = AssetManager.buildings.get("hall_human_2");
hallhuman_2.upgradeLevel = 2;
hallhuman_2.priority = 300;
hallhuman_2.tech = "Renaissance";
hallhuman_2.canBeUpgraded = true;
hallhuman_2.upgradeTo = "hall_industrial_human";
hallhuman_2.cost = new ConstructionCost(1, 1, 0, 1);


BuildingAsset hall_industrial_human = AssetManager.buildings.clone("hall_industrial_human", "hall_human_2");
hall_industrial_human.id = "hall_industrial_human";
hall_industrial_human.upgradeLevel = 6;
hall_industrial_human.housing = 20;
hall_industrial_human.priority = 400;
hall_industrial_human.upgradedFrom = "hall_human_2";
hall_industrial_human.canBeUpgraded = true;
hall_industrial_human.upgradeTo = "hall_modern_human";
hall_industrial_human.race = SK.human;
hall_industrial_human.smoke = true;
hall_industrial_human.smokeInterval = 2.5f;
hall_industrial_human.smokeOffset = new Vector2Int(2, 3);
hall_industrial_human.shadow = false;
hall_industrial_human.cost = new ConstructionCost(0, 1, 1, 0); //wood, stone, metals, gold
hall_industrial_human.tech = "Industrial";
hall_industrial_human.base_stats[S.health] = 800f;
hall_industrial_human.sprite_path = "buildings/hall_industrial_human";
AssetManager.buildings.loadSprites(hall_industrial_human);
AssetManager.buildings.add(hall_industrial_human);


BuildingAsset hall_modern_human = AssetManager.buildings.clone("hall_modern_human", "hall_human_2");
hall_modern_human.id = "hall_modern_human";
hall_modern_human.upgradeLevel = 7;
hall_modern_human.housing = 30;
hall_modern_human.priority = 500;
hall_modern_human.upgradedFrom = "hall_industrial_human";
hall_modern_human.canBeUpgraded = true;
hall_modern_human.upgradeTo = "hall_future_human";
hall_modern_human.race = SK.human;
hall_modern_human.shadow = false;
hall_modern_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
hall_modern_human.tech = "Skyscraper";
hall_modern_human.base_stats[S.health] = 1000f;
hall_modern_human.sprite_path = "buildings/hall_modern_human";
AssetManager.buildings.loadSprites(hall_modern_human);
AssetManager.buildings.add(hall_modern_human);


BuildingAsset hall_future_human = AssetManager.buildings.clone("hall_future_human", "hall_human_2");
hall_future_human.id = "hall_future_human";
hall_future_human.upgradeLevel = 8;
hall_future_human.housing = 40;
hall_future_human.priority = 600;
hall_future_human.upgradedFrom = "hall_modern_human";
hall_future_human.canBeUpgraded = false;
hall_future_human.upgradeTo = "hall_future_human";
hall_future_human.race = SK.human;
hall_future_human.shadow = false;
hall_future_human.cost = new ConstructionCost(0, 1, 1, 1); //wood, stone, metals, gold
hall_future_human.tech = "Future";
hall_future_human.base_stats[S.health] = 2000f;
hall_future_human.sprite_path = "buildings/hall_future_human";
AssetManager.buildings.loadSprites(hall_future_human);
AssetManager.buildings.add(hall_future_human);


            //========= MINES ============//
//
//
//
//=============================================================================//


BuildingAsset humanmine = AssetManager.buildings.clone("mine_human", "mine");
humanmine.upgradeLevel = 1;
humanmine.priority = 1000;
humanmine.canBeUpgraded = true;
humanmine.shadow = false;
humanmine.race = SK.human;
humanmine.upgradeTo = "mine_rain_human";
humanmine.sprite_path = "buildings/mine";
humanmine.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleMine";
humanmine.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
humanmine.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
humanmine.cost = new ConstructionCost(0, 0, 0, 1);
AssetManager.buildings.loadSprites(humanmine);
AssetManager.buildings.add(humanmine);

BuildingAsset mine_rain_human = AssetManager.buildings.clone("mine_rain_human", "mine");
mine_rain_human.id = "mine_rain_human";
mine_rain_human.upgradeLevel = 2;
mine_rain_human.priority = 3000;
mine_rain_human.upgradedFrom = "mine_human";
mine_rain_human.canBeUpgraded = true;
mine_rain_human.upgradeTo = "mine_industrial_human";
mine_rain_human.race = SK.human;
mine_rain_human.shadow = false;
mine_rain_human.cost = new ConstructionCost(0, 0, 0, 1); //wood, stone, metals, gold
mine_rain_human.tech = "Renaissance";
mine_rain_human.base_stats[S.health] = 2000f;
mine_rain_human.sprite_path = "buildings/mine_rain_human";
AssetManager.buildings.loadSprites(mine_rain_human);
AssetManager.buildings.add(mine_rain_human);

BuildingAsset mine_industrial_human = AssetManager.buildings.clone("mine_industrial_human", "mine");
mine_industrial_human.id = "mine_industrial_human";
mine_industrial_human.upgradeLevel = 3;
mine_industrial_human.priority = 4000;
mine_industrial_human.upgradedFrom = "mine_rain_human";
mine_industrial_human.canBeUpgraded = true;
mine_industrial_human.upgradeTo = "mine_modern_human";
mine_industrial_human.race = SK.human;
mine_industrial_human.smoke = true;
mine_industrial_human.smokeInterval = 2.5f;
mine_industrial_human.smokeOffset = new Vector2Int(2, 3);
mine_industrial_human.shadow = false;
mine_industrial_human.cost = new ConstructionCost(0, 0, 0, 1); //wood, stone, metals, gold
mine_industrial_human.tech = "Industrial";
mine_industrial_human.base_stats[S.health] = 3000f;
mine_industrial_human.sprite_path = "buildings/mine_industrial_human";
AssetManager.buildings.loadSprites(mine_industrial_human);
AssetManager.buildings.add(mine_industrial_human);

BuildingAsset mine_modern_human = AssetManager.buildings.clone("mine_modern_human", "mine");
mine_modern_human.id = "mine_modern_human";
mine_modern_human.upgradeLevel = 4;
mine_modern_human.priority = 5000;
mine_modern_human.upgradedFrom = "mine_industrial_human";
mine_modern_human.canBeUpgraded = true;
mine_modern_human.upgradeTo = "mine_future_human";
mine_modern_human.race = SK.human;
mine_modern_human.shadow = false;
mine_modern_human.cost = new ConstructionCost(0, 0, 0, 1); //wood, stone, metals, gold
mine_modern_human.tech = "MilitaryModern";
mine_modern_human.base_stats[S.health] = 4000f;
mine_modern_human.sprite_path = "buildings/mine_modern_human";
AssetManager.buildings.loadSprites(mine_modern_human);
AssetManager.buildings.add(mine_modern_human);

BuildingAsset mine_future_human = AssetManager.buildings.clone("mine_future_human", "mine");
mine_future_human.id = "mine_future_human";
mine_future_human.upgradeLevel = 5;
mine_future_human.priority = 6000;
mine_future_human.upgradedFrom = "mine_industrial_human";
mine_future_human.canBeUpgraded = false;
mine_future_human.upgradeTo = "mine_future_human";
mine_future_human.race = SK.human;
mine_future_human.shadow = false;
mine_future_human.cost = new ConstructionCost(0, 0, 0, 1); //wood, stone, metals, gold
mine_future_human.tech = "Future";
mine_future_human.base_stats[S.health] = 8000f;
mine_future_human.sprite_path = "buildings/mine_future_human";
AssetManager.buildings.loadSprites(mine_future_human);
AssetManager.buildings.add(mine_future_human);




            //========= TEMPLES ============//
//
//
//
//=============================================================================//

BuildingAsset basetemple = AssetManager.buildings.get("temple_human");
basetemple.upgradeLevel = 1;
basetemple.canBeUpgraded = true;
basetemple.upgradeTo = "temple_rain_human";
basetemple.priority = 8888888;
basetemple.shadow = false;
basetemple.type = SB.type_temple;
basetemple.fundament = new BuildingFundament(2, 2, 2, 0);
basetemple.cost = new ConstructionCost(0, 0, 0, 1);


BuildingAsset temple_rain_human = AssetManager.buildings.clone("temple_rain_human", "temple_human");
temple_rain_human.id = "temple_rain_human";
temple_rain_human.upgradeLevel = 2;
temple_rain_human.priority = 8888888;
temple_rain_human.upgradedFrom = "temple_human";
temple_rain_human.canBeUpgraded = true;
temple_rain_human.upgradeTo = "temple_industrial_human";
temple_rain_human.race = SK.human;
temple_rain_human.type = SB.type_temple;
temple_rain_human.fundament = new BuildingFundament(2, 2, 2, 0);
temple_rain_human.shadow = false;
temple_rain_human.cost = new ConstructionCost(1, 1, 1, 1); //wood, stone, metals, gold
temple_rain_human.tech = "Renaissance";
temple_rain_human.base_stats[S.health] = 4000f;
temple_rain_human.sprite_path = "buildings/temple_rain_human";
temple_rain_human.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleTemple";
temple_rain_human.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
temple_rain_human.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
AssetManager.buildings.loadSprites(temple_rain_human);
AssetManager.buildings.add(temple_rain_human);


BuildingAsset temple_industrial_human = AssetManager.buildings.clone("temple_industrial_human", "temple_human");
temple_industrial_human.id = "temple_industrial_human";
temple_industrial_human.upgradeLevel = 3;
temple_industrial_human.priority = 8888888;
temple_industrial_human.upgradedFrom = "temple_rain_human";
temple_industrial_human.canBeUpgraded = true;
temple_industrial_human.upgradeTo = "temple_modern_human";
temple_industrial_human.race = SK.human;
temple_industrial_human.smoke = true;
temple_industrial_human.smokeInterval = 2.5f;
temple_industrial_human.type = SB.type_temple;
temple_industrial_human.fundament = new BuildingFundament(2, 2, 2, 0);
temple_industrial_human.smokeOffset = new Vector2Int(2, 3);
temple_industrial_human.shadow = false;
temple_industrial_human.cost = new ConstructionCost(1, 1, 1, 1); //wood, stone, metals, gold
temple_industrial_human.tech = "Industrial";
temple_industrial_human.base_stats[S.health] = 5000f;
temple_industrial_human.sprite_path = "buildings/temple_industrial_human";
temple_industrial_human.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleTemple";
temple_industrial_human.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
temple_industrial_human.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
AssetManager.buildings.loadSprites(temple_industrial_human);
AssetManager.buildings.add(temple_industrial_human);

BuildingAsset temple_modern_human = AssetManager.buildings.clone("temple_modern_human", "temple_human");
temple_modern_human.id = "temple_modern_human";
temple_modern_human.upgradeLevel = 4;
temple_modern_human.priority = 8888888;
temple_modern_human.type = SB.type_temple;
temple_modern_human.fundament = new BuildingFundament(2, 2, 2, 0);
temple_modern_human.upgradedFrom = "temple_industrial_human";
temple_modern_human.canBeUpgraded = true;
temple_modern_human.upgradeTo = "temple_future_human";
temple_modern_human.race = SK.human;
temple_modern_human.shadow = false;
temple_modern_human.cost = new ConstructionCost(1, 1, 1, 1); //wood, stone, metals, gold
temple_modern_human.tech = "MilitaryModern";
temple_modern_human.base_stats[S.health] = 6000f;
temple_modern_human.sprite_path = "buildings/temple_modern_human";
temple_modern_human.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleTemple";
temple_modern_human.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
temple_modern_human.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
AssetManager.buildings.loadSprites(temple_modern_human);
AssetManager.buildings.add(temple_modern_human);


BuildingAsset temple_future_human = AssetManager.buildings.clone("temple_future_human", "temple_human");
temple_future_human.id = "temple_future_human";
temple_future_human.upgradeLevel = 5;
temple_future_human.priority = 8888888;
temple_future_human.type = SB.type_temple;
temple_future_human.fundament = new BuildingFundament(2, 2, 2, 0);
temple_future_human.upgradedFrom = "temple_industrial_human";
temple_future_human.canBeUpgraded = false;
temple_future_human.upgradeTo = "temple_future_human";
temple_future_human.race = SK.human;
temple_future_human.shadow = false;
temple_future_human.cost = new ConstructionCost(1, 1, 1, 1); //wood, stone, metals, gold
temple_future_human.tech = "Future";
temple_future_human.base_stats[S.health] = 7000f;
temple_future_human.sprite_path = "buildings/temple_future_human";
temple_future_human.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleTemple";
temple_future_human.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
temple_future_human.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
AssetManager.buildings.loadSprites(temple_future_human);
AssetManager.buildings.add(temple_future_human);



     //========= DOCKS ============//
//
//
//
//=============================================================================//

BuildingAsset basedock = AssetManager.buildings.get("docks_human");
basedock.upgradeLevel = 1;
basedock.canBeUpgraded = true;
basedock.priority = 200;
basedock.shadow = false;
basedock.upgradeTo = "dock_rain_human";
//basedock.boats_assets.Add("human_renaissance_trading");
//basedock.boats_assets.Add("human_renaissance_battleship");
//basedock.boats_assets.Add("human_renaissance_corvette1");
//basedock.boats_assets.Add("human_renaissance_corvette2");
//basedock.boats_assets.Add("human_industrial_trading");
//basedock.boats_assets.Add("human_industrial_corvette1");
//basedock.boats_assets.Add("human_industrial_corvette2");
//basedock.boats_assets.Add("human_industrial_battleship");
//basedock.boats_assets.Add("human_modern_battleship");
//basedock.boats_assets.Add("human_modern_trading");
//basedock.boats_assets.Add("human_modern_corvette1");
//basedock.boats_assets.Add("human_modern_corvette2");
//basedock.boats_assets.Add("human_modern_submarine");

BuildingAsset dock_rain_human = AssetManager.buildings.clone("dock_rain_human", "fishing_docks_human");
dock_rain_human.id = "dock_rain_human";
dock_rain_human.draw_light_area = true;
dock_rain_human.draw_light_size = 0.5f;
dock_rain_human.draw_light_area_offset_y = 8f;
dock_rain_human.upgradeLevel = 2;
dock_rain_human.docks = true;
dock_rain_human.priority = 30000;
dock_rain_human.upgradedFrom = "docks_human";
dock_rain_human.canBeUpgraded = true;
dock_rain_human.upgradeTo = "dock_industrial_human";
dock_rain_human.race = SK.human;
dock_rain_human.shadow = false;
dock_rain_human.boats_assets = List.Of<string>("fishing_boat_renaissance", "human_renaissance_trading", "human_renaissance_battleship", "human_renaissance_corvette1", "human_renaissance_corvette2");
dock_rain_human.cost = new ConstructionCost(0, 0, 0, 1); //wood, stone, metals, gold
dock_rain_human.tech = "Renaissance";
dock_rain_human.base_stats[S.health] = 15000f;
dock_rain_human.sprite_path = "buildings/dock_rain_human";
dock_rain_human.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleDocks";
dock_rain_human.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
dock_rain_human.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
AssetManager.buildings.loadSprites(dock_rain_human);
AssetManager.buildings.add(dock_rain_human);

BuildingAsset dock_industrial_human = AssetManager.buildings.clone("dock_industrial_human", "fishing_docks_human");
dock_industrial_human.id = "dock_industrial_human";
dock_industrial_human.draw_light_area = true;
dock_industrial_human.draw_light_size = 0.5f;
dock_industrial_human.draw_light_area_offset_y = 8f;
dock_industrial_human.upgradeLevel = 3;
dock_industrial_human.priority = 40000;
dock_industrial_human.docks = true;
dock_industrial_human.upgradedFrom = "dock_rain_human";
dock_industrial_human.canBeUpgraded = true;
dock_industrial_human.upgradeTo = "dock_modern_human";
dock_industrial_human.race = SK.human;
dock_industrial_human.smoke = true;
dock_industrial_human.smokeInterval = 2.5f;
dock_industrial_human.boats_assets = List.Of<string>("fishing_boat_industrial", "human_industrial_trading", "human_industrial_corvette1", "human_industrial_corvette2", "human_industrial_battleship");
dock_industrial_human.smokeOffset = new Vector2Int(2, 3);
dock_industrial_human.shadow = false;
dock_industrial_human.cost = new ConstructionCost(0, 0, 0, 1); //wood, stone, metals, gold
dock_industrial_human.tech = "Firearms";
dock_industrial_human.base_stats[S.health] = 20000f;
dock_industrial_human.sprite_path = "buildings/dock_industrial_human";
dock_industrial_human.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleDocks";
dock_industrial_human.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
dock_industrial_human.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
AssetManager.buildings.loadSprites(dock_industrial_human);
AssetManager.buildings.add(dock_industrial_human);

BuildingAsset dock_modern_human = AssetManager.buildings.clone("dock_modern_human", "fishing_docks_human");
dock_modern_human.id = "dock_modern_human";
dock_modern_human.draw_light_area = true;
dock_modern_human.draw_light_size = 0.5f;
dock_modern_human.draw_light_area_offset_y = 8f;
dock_modern_human.upgradeLevel = 4;
dock_modern_human.docks = true;
dock_modern_human.priority = 50000;
dock_modern_human.upgradedFrom = "dock_industrial_human";
dock_modern_human.canBeUpgraded = false;
dock_modern_human.upgradeTo = "dock_future_human";
dock_modern_human.race = SK.human;
dock_modern_human.shadow = false;
dock_modern_human.boats_assets = List.Of<string>("fishing_boat_modern", "human_modern_battleship", "human_modern_trading", "human_modern_corvette1", "human_modern_corvette2", "human_modern_submarine");
dock_modern_human.cost = new ConstructionCost(0, 0, 0, 1); //wood, stone, metals, gold
dock_modern_human.tech = "MilitaryModern";
dock_modern_human.base_stats[S.health] = 50000f;
dock_modern_human.sprite_path = "buildings/dock_modern_human";
dock_modern_human.sound_idle = "event:/SFX/BUILDINGS_IDLE/IdleDocks";
dock_modern_human.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingStone";
dock_modern_human.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingStone";
AssetManager.buildings.loadSprites(dock_modern_human);
AssetManager.buildings.add(dock_modern_human);


/////////////REMOVE////////////////
RemoveBuildingOrderKeysToCivRaces(SB.order_mine, SB.mine);

RemoveBuildingOrderKeysToCivRaces(SB.order_docks_0, SB.fishing_docks_human);
RemoveBuildingOrderKeysToCivRaces(SB.order_docks_1, SB.docks_human);

RemoveBuildingOrderKeysToCivRaces(SB.order_tent, SB.tent_human);
RemoveBuildingOrderKeysToCivRaces(SB.order_house_0, SB.house_human_0);
RemoveBuildingOrderKeysToCivRaces(SB.order_house_1, SB.house_human_1);
RemoveBuildingOrderKeysToCivRaces(SB.order_house_2, SB.house_human_2);
RemoveBuildingOrderKeysToCivRaces(SB.order_house_3, SB.house_human_3);
RemoveBuildingOrderKeysToCivRaces(SB.order_house_4, SB.house_human_4);
RemoveBuildingOrderKeysToCivRaces(SB.order_house_5, SB.house_human_5);

RemoveBuildingOrderKeysToCivRaces(SB.order_hall_0, SB.hall_human_0);
RemoveBuildingOrderKeysToCivRaces(SB.order_hall_1, SB.hall_human_1);
RemoveBuildingOrderKeysToCivRaces(SB.order_hall_2, SB.hall_human_2);

/////////////ADD////////////////
AddBuildingOrderKeysToCivRaces(SB.order_docks_0, SB.fishing_docks_human);
AddBuildingOrderKeysToCivRaces(SB.order_docks_1, SB.docks_human);

AddBuildingOrderKeysToCivRaces(SB.order_tent, SB.tent_human);
AddBuildingOrderKeysToCivRaces(SB.order_house_0, SB.house_human_0);
AddBuildingOrderKeysToCivRaces(SB.order_house_1, SB.house_human_1);
AddBuildingOrderKeysToCivRaces(SB.order_house_2, SB.house_human_2);
AddBuildingOrderKeysToCivRaces(SB.order_house_3, SB.house_human_3);
AddBuildingOrderKeysToCivRaces(SB.order_house_4, SB.house_human_4);
AddBuildingOrderKeysToCivRaces(SB.order_house_5, SB.house_human_5);

AddBuildingOrderKeysToCivRaces(SB.order_hall_0, SB.hall_human_0);
AddBuildingOrderKeysToCivRaces(SB.order_hall_1, SB.hall_human_1);
AddBuildingOrderKeysToCivRaces(SB.order_hall_2, SB.hall_human_2);

RaceBuildOrderAsset based = AssetManager.race_build_orders.get("kingdom_base");
based.addUpgrade("order_docks_1");
AddBuildingOrderKeysToCivRaces("order_docks_2", "dock_rain_human");
based.addUpgrade("order_docks_2");
AddBuildingOrderKeysToCivRaces("order_docks_3", "dock_industrial_human");
based.addUpgrade("order_docks_3");
AddBuildingOrderKeysToCivRaces("order_docks_4", "dock_modern_human");
AddBuildingOrderKeysToCivRaces("order_mine", "mine_human");
based.addUpgrade("order_mine");
AddBuildingOrderKeysToCivRaces("order_mine_1", "mine_rain_human");
based.addUpgrade("order_mine_1");
AddBuildingOrderKeysToCivRaces("order_mine_2", "mine_industrial_human");
based.addUpgrade("order_mine_2");
AddBuildingOrderKeysToCivRaces("order_mine_3", "mine_modern_human");
based.addUpgrade("order_mine_3");
AddBuildingOrderKeysToCivRaces("order_mine_4", "mine_future_human");
based.addUpgrade("order_hall_0");
based.addUpgrade("order_hall_1");
based.addUpgrade("order_hall_2");
AddBuildingOrderKeysToCivRaces("order_hall_3", "hall_industrial_human");
based.addUpgrade("order_hall_3");
AddBuildingOrderKeysToCivRaces("order_hall_4", "hall_modern_human");
based.addUpgrade("order_hall_4");
AddBuildingOrderKeysToCivRaces("order_hall_5", "hall_future_human");
based.addUpgrade("order_tent");
based.addUpgrade("order_house_0");
based.addUpgrade("order_house_1");
based.addUpgrade("order_house_2");
based.addUpgrade("order_house_3");
based.addUpgrade("order_house_4");
based.addUpgrade("order_house_5");
AddBuildingOrderKeysToCivRaces("order_house_6", "house_industrial_human");
based.addUpgrade("order_house_6");
AddBuildingOrderKeysToCivRaces("order_house_7", "house_modern_human");
based.addUpgrade("order_house_7");
AddBuildingOrderKeysToCivRaces("order_house_8", "house_future_human");
AddBuildingOrderKeysToCivRaces("order_barracks", "barracks_human");
based.addUpgrade("order_barracks");
AddBuildingOrderKeysToCivRaces("order_barracks_1", "Barracks_rain_human");
based.addUpgrade("order_barracks_1");
AddBuildingOrderKeysToCivRaces("order_barracks_2", "Barracks_industrial_human");
based.addUpgrade("order_barracks_2");
AddBuildingOrderKeysToCivRaces("order_barracks_3", "Barracks_modern_human");
based.addUpgrade("order_barracks_3");
AddBuildingOrderKeysToCivRaces("order_barracks_4", "Barracks_future_human");
based.addUpgrade(SB.order_watch_tower);
AddBuildingOrderKeysToCivRaces("order_watch_tower_1", "watch_tower_rain_human");
based.addUpgrade("order_watch_tower_1");
AddBuildingOrderKeysToCivRaces("order_watch_tower_2", "watch_tower_industrial_human");
based.addUpgrade("order_watch_tower_2");
AddBuildingOrderKeysToCivRaces("order_watch_tower_3", "watch_tower_modern_human");
based.addUpgrade("order_watch_tower_3");
AddBuildingOrderKeysToCivRaces("order_watch_tower_4", "watch_tower_future_human");
AddBuildingOrderKeysToCivRaces("order_temple", "temple_human");
based.addUpgrade("order_temple");
AddBuildingOrderKeysToCivRaces("order_temple_1", "temple_rain_human");
based.addUpgrade("order_temple_1");
AddBuildingOrderKeysToCivRaces("order_temple_2", "temple_industrial_human");
based.addUpgrade("order_temple_2");
AddBuildingOrderKeysToCivRaces("order_temple_3", "temple_modern_human");
based.addUpgrade("order_temple_3");
AddBuildingOrderKeysToCivRaces("order_temple_4", "temple_future_human");

        BuildOrder barracksOrder = based.addBuilding("order_barracks", 1, 0, 30, 10);
        if (barracksOrder != null)
        {
            barracksOrder.requirements_orders = new List<string> { SB.order_bonfire };
        }
        BuildOrder templeOrder = based.addBuilding("order_temple", 1, 0, 30, 10);
        if (templeOrder != null)
        {
            templeOrder.requirements_orders = new List<string> { SB.order_bonfire };
        }
        BuildOrder towerOrder = based.addBuilding("order_watch_tower", 1, 0, 30, 10);
        if (towerOrder != null)
        {
            towerOrder.requirements_orders = new List<string> { SB.order_bonfire };
        }


        BuildOrder mineOrder = based.addBuilding("order_mine", 1, 0, 30, 10);
        if (mineOrder != null)
        {
            mineOrder.requirements_orders = new List<string> { SB.order_bonfire };
        }
         BuildOrder dockfirstOrder = based.addBuilding("order_docks_0", 1, 0, 30, 10);
        if (dockfirstOrder != null)
        {
            dockfirstOrder.requirements_orders = new List<string> { SB.order_bonfire };
        }
         BuildOrder docktwoOrder = based.addBuilding("order_docks_1", 1, 0, 30, 10);
        if (docktwoOrder != null)
        {
            docktwoOrder.requirements_orders = new List<string> { SB.order_bonfire };
        }

 BuildOrder statuelmao = based.addBuilding("order_statue", 1, 0, 30, 10);
        if (statuelmao != null)
        {
            statuelmao.requirements_orders = new List<string> { SB.order_bonfire };
        }

        BuildOrder windmillone = based.addBuilding("order_windmill_0", 1, 0, 30, 10);
        if (windmillone != null)
        {
            windmillone.requirements_orders = new List<string> { SB.order_bonfire };
        }

        BuildOrder windmilltwo = based.addBuilding("order_windmill_1", 1, 0, 30, 10);
        if (windmilltwo != null)
        {
            windmilltwo.requirements_orders = new List<string> { SB.order_bonfire };
        }


  }



    private static void RemoveBuildingOrderKeysToCivRaces(string key, string value)
    {
        foreach (Race race in AssetManager.raceLibrary.list.Where(r => r.civilization))
        {
            if (race.building_order_keys.ContainsKey(key))
            {
                race.building_order_keys.Remove(key);
            }
        }
    }

    private static void AddBuildingOrderKeysToCivRaces(string key, string value)
    {
        foreach (Race race in AssetManager.raceLibrary.list.Where(r => r.civilization))
        {
            race.building_order_keys[key] = value;
        }
    }


  }
  }


