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
class Commerce {

  internal void init() { commerce_init(); }
  private void commerce_init() {

    Harmony harmony = new Harmony("com.tux.modernbox.modernbox");
            MethodInfo balls = typeof(BaseSimObject).GetMethod(nameof(BaseSimObject.findEnemyObjectTarget), BindingFlags.Instance | BindingFlags.NonPublic);
            MethodInfo dalls = typeof(Commerce).GetMethod(nameof(Commerce.findEnemyObjectTarget_prefix));
            harmony.Patch(balls, new HarmonyMethod(dalls)); 
    RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");

    /*
    BuildingAsset casino = AssetManager.buildings.clone("casino", "!city_building");
    AssetManager.buildings.add(casino);
    casino.id = "casino";
    casino.priority = 69999;
    casino.fundament = new BuildingFundament(2, 2, 2, 0);
    casino.cost = new ConstructionCost(pWood : 15, pStone : 25, pGold : 250);
    casino.burnable = false;
    casino.build_place_single = true;
    casino.tech = "Casino";
    casino.build_place_batch = false;
    casino.base_stats[S.health] = 3000f;
    casino.base_stats[S.size] = 1.0f;
    casino.canBeLivingHouse = false;
    casino.resources_given.Add(new ResourceContainer{id = "Gold", amount = 2});
    loadSprites(casino);

    AddBuildingOrderKeysToCivRaces("order_casino", "casino");

    human.addBuilding("order_casino", 1, pPop : 50, pBuildings : 16);

    BuildingAsset restaurant = AssetManager.buildings.clone("restaurant", "!city_building");
    AssetManager.buildings.add(restaurant);
    restaurant.id = "restaurant";
    restaurant.priority = 69999;
    restaurant.fundament = new BuildingFundament(2, 2, 2, 0);
    restaurant.cost = new ConstructionCost(pWood : 15, pStone : 25, pGold : 250);
    restaurant.burnable = false;
    restaurant.build_place_single = true;
    restaurant.tech = "Casino";
    restaurant.build_place_batch = false;
    restaurant.base_stats[S.health] = 3000f;
    restaurant.base_stats[S.size] = 1.0f;
    restaurant.canBeLivingHouse = false;
    restaurant.resources_given.Add(new ResourceContainer{id = "Gold", amount = 2});
    loadSprites(restaurant);

    AddBuildingOrderKeysToCivRaces("order_restaurant", "restaurant");

    human.addBuilding("order_restaurant", 1, pPop : 50, pBuildings : 16);

    BuildingAsset mall = AssetManager.buildings.clone("mall", "!city_building");
    AssetManager.buildings.add(mall);
    mall.id = "mall";
    mall.priority = 69999;
    mall.fundament = new BuildingFundament(2, 2, 2, 0);
    mall.cost = new ConstructionCost(pWood : 15, pStone : 25, pGold : 250);
    mall.burnable = false;
    mall.build_place_single = true;
    mall.tech = "Casino";
    mall.build_place_batch = false;
    mall.base_stats[S.health] = 3000f;
    mall.base_stats[S.size] = 1.0f;
    mall.canBeLivingHouse = false;
    mall.resources_given.Add(new ResourceContainer{id = "Gold", amount = 2});
    loadSprites(mall);

    AddBuildingOrderKeysToCivRaces("order_mall", "mall");

    human.addBuilding("order_mall", 1, pPop : 50, pBuildings : 16);



    BuildingAsset school = AssetManager.buildings.clone("school", "!city_building");
    AssetManager.buildings.add(school);
    school.id = "school";
    school.priority = 69999;
    school.fundament = new BuildingFundament(2, 2, 2, 0);
    school.cost = new ConstructionCost(pWood : 15, pStone : 25, pGold : 250);
    school.burnable = false;
    school.build_place_single = true;
    school.tech = "Casino";
    school.build_place_batch = false;
    school.base_stats[S.health] = 3000f;
    school.base_stats[S.size] = 1.0f;
    school.canBeLivingHouse = false;
    school.resources_given.Add(new ResourceContainer{id = "Gold", amount = 2});
    loadSprites(school);

    AddBuildingOrderKeysToCivRaces("order_school", "school");

    human.addBuilding("order_school", 1, pPop : 50, pBuildings : 16);

    BuildingAsset modernbuilding = AssetManager.buildings.clone("modernbuilding", "!city_building");
    AssetManager.buildings.add(modernbuilding);
    modernbuilding.id = "modernbuilding";
    modernbuilding.priority = 69999;
    modernbuilding.fundament = new BuildingFundament(2, 2, 2, 0);
    modernbuilding.cost = new ConstructionCost(0, 2, 1, 1);
    modernbuilding.tech = "Casino";
    modernbuilding.housing = 60;
    modernbuilding.base_stats[S.health] = 3000f;
    loadSprites(modernbuilding);

    AddBuildingOrderKeysToCivRaces("order_modernbuilding", "modernbuilding");

    human.addBuilding("order_modernbuilding", 1, pPop : 50, pBuildings : 16);

    BuildingAsset AirFactory = AssetManager.buildings.clone("AirFactory", "!city_building");
    AssetManager.buildings.add(AirFactory);
    AirFactory.id = "AirFactory";
    AirFactory.priority = 69999;
    AirFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    AirFactory.cost = new ConstructionCost(0, 2, 1, 1);
    AirFactory.tech = "MIRVBomber";
    AirFactory.housing = 60;
	AirFactory.spawnUnits = true;
    AirFactory.spawnUnits_asset = "MIRVBomber";
    AirFactory.base_stats[S.health] = 3000f;
    loadSprites(AirFactory);

    BuildingAsset TankFactory = AssetManager.buildings.clone("TankFactory", "!city_building");
    AssetManager.buildings.add(TankFactory);
    TankFactory.id = "TankFactory";
    TankFactory.priority = 69999;
    TankFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    TankFactory.cost = new ConstructionCost(0, 2, 1, 1);
    TankFactory.tech = "Tanks";
    TankFactory.housing = 60;
	TankFactory.spawnUnits = true;
    TankFactory.spawnUnits_asset = "Tank";
    TankFactory.base_stats[S.health] = 3000f;
    loadSprites(TankFactory);

    BuildingAsset TerranFactory = AssetManager.buildings.clone("TerranFactory", "!city_building");
    AssetManager.buildings.add(TerranFactory);
    TerranFactory.id = "TerranFactory";
    TerranFactory.priority = 69999;
    TerranFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    TerranFactory.cost = new ConstructionCost(0, 2, 1, 1);
    TerranFactory.tech = "Terrans";
    TerranFactory.housing = 60;
	TerranFactory.spawnUnits = true;
    TerranFactory.spawnUnits_asset = "Terran";
    TerranFactory.base_stats[S.health] = 3000f;
    loadSprites(TerranFactory);

    BuildingAsset P9000Factory = AssetManager.buildings.clone("P9000Factory", "!city_building");
    AssetManager.buildings.add(P9000Factory);
    P9000Factory.id = "P9000Factory";
    P9000Factory.priority = 69999;
    P9000Factory.fundament = new BuildingFundament(2, 2, 2, 0);
    P9000Factory.cost = new ConstructionCost(0, 2, 1, 1);
    P9000Factory.tech = "P9000s";
    P9000Factory.housing = 60;
	P9000Factory.spawnUnits = false;
    P9000Factory.spawnUnits_asset = "P9000";
    P9000Factory.base_stats[S.health] = 3000f;
    loadSprites(P9000Factory);

            BuildingAsset RailgunFactory = AssetManager.buildings.clone("RailgunFactory", "!city_building");
            AssetManager.buildings.add(RailgunFactory);
            RailgunFactory.id = "RailgunFactory";
            RailgunFactory.priority = 69999;
            RailgunFactory.fundament = new BuildingFundament(2, 2, 2, 0);
            RailgunFactory.cost = new ConstructionCost(0, 2, 1, 1);
            RailgunFactory.tech = "Railguns";
            RailgunFactory.housing = 60;
			RailgunFactory.spawnUnits = true;
            RailgunFactory.spawnUnits_asset = "Railgun";
            RailgunFactory.base_stats[S.health] = 3000f;
            loadSprites(RailgunFactory);

    BuildingAsset HumveeFactory = AssetManager.buildings.clone("HumveeFactory", "!city_building");
    AssetManager.buildings.add(HumveeFactory);
    HumveeFactory.id = "HumveeFactory";
    HumveeFactory.priority = 69999;
    HumveeFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    HumveeFactory.cost = new ConstructionCost(0, 2, 1, 1);
    HumveeFactory.tech = "Tanks";
    HumveeFactory.housing = 60;
	HumveeFactory.spawnUnits = true;
    HumveeFactory.spawnUnits_asset = "Humvee";
    HumveeFactory.base_stats[S.health] = 3000f;
    loadSprites(HumveeFactory);

    BuildingAsset HelicopterFactory = AssetManager.buildings.clone("HelicopterFactory", "!city_building");
    AssetManager.buildings.add(HelicopterFactory);
    HelicopterFactory.id = "HelicopterFactory";
    HelicopterFactory.priority = 69999;
    HelicopterFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    HelicopterFactory.cost = new ConstructionCost(0, 2, 1, 1);
    HelicopterFactory.tech = "Helicopter";
    HelicopterFactory.housing = 60;
	HelicopterFactory.spawnUnits = true;
    HelicopterFactory.spawnUnits_asset = "Heli";
    HelicopterFactory.base_stats[S.health] = 3000f;
    loadSprites(HelicopterFactory);

    BuildingAsset DroneFactory = AssetManager.buildings.clone("DroneFactory", "!city_building");
    AssetManager.buildings.add(DroneFactory);
    DroneFactory.id = "DroneFactory";
    DroneFactory.priority = 69999;
    DroneFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    DroneFactory.cost = new ConstructionCost(0, 2, 1, 1);
    DroneFactory.tech = "Drone";
    DroneFactory.housing = 60;
	DroneFactory.spawnUnits = true;
    DroneFactory.spawnUnits_asset = "Drone";
    DroneFactory.base_stats[S.health] = 3000f;
    loadSprites(DroneFactory);

    BuildingAsset AirshipFactory = AssetManager.buildings.clone("AirshipFactory", "!city_building");
    AssetManager.buildings.add(AirshipFactory);
    AirshipFactory.id = "AirshipFactory";
    AirshipFactory.priority = 69999;
    AirshipFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    AirshipFactory.cost = new ConstructionCost(0, 2, 1, 1);
    AirshipFactory.tech = "Casino";
    AirshipFactory.housing = 60;
	AirshipFactory.spawnUnits = true;
    AirshipFactory.spawnUnits_asset = "Zeppelin";
    AirshipFactory.base_stats[S.health] = 3000f;
    loadSprites(AirshipFactory);

    BuildingAsset FighterJetFactory = AssetManager.buildings.clone("FighterJetFactory", "!city_building");
    AssetManager.buildings.add(FighterJetFactory);
    FighterJetFactory.id = "FighterJetFactory";
    FighterJetFactory.priority = 69999;
    FighterJetFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    FighterJetFactory.cost = new ConstructionCost(0, 2, 1, 1);
    FighterJetFactory.tech = "FighterJet";
    FighterJetFactory.housing = 60;
	FighterJetFactory.spawnUnits = true;
    FighterJetFactory.spawnUnits_asset = "FighterJet";
    FighterJetFactory.base_stats[S.health] = 3000f;
    loadSprites(FighterJetFactory);

    BuildingAsset BoiFactory = AssetManager.buildings.clone("BoiFactory", "!city_building");
    AssetManager.buildings.add(BoiFactory);
    BoiFactory.id = "BoiFactory";
    BoiFactory.priority = 69999;
    BoiFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    BoiFactory.cost = new ConstructionCost(0, 2, 1, 1);
    BoiFactory.tech = "Boi";
    BoiFactory.housing = 60;
	BoiFactory.spawnUnits = true;
    BoiFactory.spawnUnits_asset = "MissileSystem";
    BoiFactory.base_stats[S.health] = 3000f;
    loadSprites(BoiFactory);

    BuildingAsset GunshipFactory = AssetManager.buildings.clone("GunshipFactory", "!city_building");
    AssetManager.buildings.add(GunshipFactory);
    GunshipFactory.id = "GunshipFactory";
    GunshipFactory.priority = 69999;
    GunshipFactory.fundament = new BuildingFundament(2, 2, 2, 0);
    GunshipFactory.cost = new ConstructionCost(0, 2, 1, 1);
    GunshipFactory.tech = "Gunship";
    GunshipFactory.housing = 60;
	GunshipFactory.spawnUnits = true;
    GunshipFactory.spawnUnits_asset = "Gunship";
    GunshipFactory.base_stats[S.health] = 3000f;
    loadSprites(GunshipFactory);

    BuildingAsset Barracks_modern_human = AssetManager.buildings.clone("Barracks_modern_human", "!city_building");
    AssetManager.buildings.add(Barracks_modern_human);
    Barracks_modern_human.id = "Barracks_modern_human";
    Barracks_modern_human.priority = 89893289;
    Barracks_modern_human.fundament = new BuildingFundament(2, 2, 2, 0);
    Barracks_modern_human.cost = new ConstructionCost(pCommonMetals: 1, pGold: 1);
    Barracks_modern_human.tech = "MilitaryModern";
    Barracks_modern_human.housing = 60;
    Barracks_modern_human.spawnUnits = true;
    Barracks_modern_human.spawnUnits_asset = "Soldier";
    Barracks_modern_human.base_stats[S.health] = 3000f;
    loadSprites(Barracks_modern_human);
    */


            BuildingAsset MissileSilo = AssetManager.buildings.clone("MissileSilo", "!city_building");
            AssetManager.buildings.add(MissileSilo);
            MissileSilo.id = "MissileSilo";
            MissileSilo.type = "MissileSilo";
            MissileSilo.priority = 3750;
            MissileSilo.fundament = new BuildingFundament(4, 2, 2, 0);
            MissileSilo.cost = new ConstructionCost(pCommonMetals: 32, pGold: 72);
            MissileSilo.burnable = false;
            MissileSilo.canBeUpgraded = false;
            MissileSilo.tower_projectile_amount = 1;
            MissileSilo.build_place_single = true;
            MissileSilo.build_place_batch = false;
            MissileSilo.base_stats[S.health] = 2500;
            MissileSilo.canBeLivingHouse = true;
            MissileSilo.tech = "Nukes";
            MissileSilo.buildRoadTo = false;
            MissileSilo.tower = true;
            MissileSilo.tower_projectile = "NUKER";
            MissileSilo.tower_projectile_offset = 4f;
            MissileSilo.tower_projectile_reload = 64f;
            AssetManager.buildings.loadSprites(MissileSilo);


			BuildingAsset Ruins1 = AssetManager.buildings.clone("Ruins1", "tree");
			Ruins1.id = "Ruins1";
			Ruins1.fundament = new BuildingFundament(1, 1, 1, 0);
			Ruins1.limit_per_zone = 20;
			Ruins1.canBePlacedOnLiquid = true;
			Ruins1.spread_ids = List.Of<string>("Ruins1");
             loadSprites(Ruins1);
            AssetManager.buildings.add(Ruins1);

            BuildingAsset scraps = AssetManager.buildings.clone("scraps", "!building");
            scraps.affected_by_drought = false;
		    scraps.burnable = false;
		    scraps.remove_ruins = true;
		scraps.ignoreBuildings = false;
		scraps.ignoredByCities = true;
		scraps.ignore_same_building_id = true;
		scraps.buildingType = BuildingType.Mineral;
            scraps.base_stats[S.health] = 100f;
            scraps.has_ruins_graphics = false;
		    scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    scraps.race = "nature";
            scraps.kingdom = "nature";
            scraps.checkForCloseBuilding = false;
		    scraps.canBeLivingHouse = false;
            scraps.canBePlacedOnLiquid = true;
            scraps.ignoreBuildings = true;
            scraps.canBeHarvested = true;
            scraps.setShadow(0.5f, 0.03f, 0.12f);
            scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(scraps);
            AssetManager.buildings.loadSprites(scraps);


BuildingAsset Soldier_scraps = AssetManager.buildings.clone("Soldier_scraps", "scraps");
            Soldier_scraps.affected_by_drought = false;
		    Soldier_scraps.burnable = false;
            Soldier_scraps.base_stats[S.health] = 100f;
            Soldier_scraps.has_ruins_graphics = false;
		    Soldier_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Soldier_scraps.race = "nature";
            Soldier_scraps.kingdom = "nature";
            Soldier_scraps.checkForCloseBuilding = false;
		    Soldier_scraps.canBeLivingHouse = false;
            Soldier_scraps.canBePlacedOnLiquid = true;
            Soldier_scraps.ignoreBuildings = true;
            Soldier_scraps.canBeHarvested = true;
            Soldier_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Soldier_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Soldier_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 1, false);
            AssetManager.buildings.add(Soldier_scraps);
            AssetManager.buildings.loadSprites(Soldier_scraps);

            BuildingAsset P9000_scraps = AssetManager.buildings.clone("P9000_scraps", "scraps");
            P9000_scraps.affected_by_drought = false;
		    P9000_scraps.burnable = false;
            P9000_scraps.base_stats[S.health] = 100f;
            P9000_scraps.has_ruins_graphics = false;
		    P9000_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    P9000_scraps.race = "nature";
            P9000_scraps.kingdom = "nature";
            P9000_scraps.checkForCloseBuilding = false;
		    P9000_scraps.canBeLivingHouse = false;
            P9000_scraps.canBePlacedOnLiquid = true;
            P9000_scraps.ignoreBuildings = true;
            P9000_scraps.canBeHarvested = true;
            P9000_scraps.setShadow(0.5f, 0.03f, 0.12f);
            P9000_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    P9000_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(P9000_scraps);
            AssetManager.buildings.loadSprites(P9000_scraps);


BuildingAsset AbramTank_scraps = AssetManager.buildings.clone("AbramTank_scraps", "scraps");
            AbramTank_scraps.affected_by_drought = false;
		    AbramTank_scraps.burnable = false;
            AbramTank_scraps.base_stats[S.health] = 100f;
            AbramTank_scraps.has_ruins_graphics = false;
		    AbramTank_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    AbramTank_scraps.race = "nature";
            AbramTank_scraps.kingdom = "nature";
            AbramTank_scraps.checkForCloseBuilding = false;
		    AbramTank_scraps.canBeLivingHouse = false;
            AbramTank_scraps.canBePlacedOnLiquid = true;
            AbramTank_scraps.ignoreBuildings = true;
            AbramTank_scraps.canBeHarvested = true;
            AbramTank_scraps.setShadow(0.5f, 0.03f, 0.12f);
            AbramTank_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    AbramTank_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(AbramTank_scraps);
            AssetManager.buildings.loadSprites(AbramTank_scraps);

            BuildingAsset dreadnaught_scraps = AssetManager.buildings.clone("dreadnaught_scraps", "scraps");
            dreadnaught_scraps.affected_by_drought = false;
		    dreadnaught_scraps.burnable = false;
            dreadnaught_scraps.base_stats[S.health] = 100f;
            dreadnaught_scraps.has_ruins_graphics = false;
		    dreadnaught_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    dreadnaught_scraps.race = "nature";
            dreadnaught_scraps.kingdom = "nature";
            dreadnaught_scraps.checkForCloseBuilding = false;
		    dreadnaught_scraps.canBeLivingHouse = false;
            dreadnaught_scraps.canBePlacedOnLiquid = true;
            dreadnaught_scraps.ignoreBuildings = true;
            dreadnaught_scraps.canBeHarvested = true;
            dreadnaught_scraps.setShadow(0.5f, 0.03f, 0.12f);
            dreadnaught_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    dreadnaught_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(dreadnaught_scraps);
            AssetManager.buildings.loadSprites(dreadnaught_scraps);

BuildingAsset EliteBomber_scraps = AssetManager.buildings.clone("EliteBomber_scraps", "scraps");
            EliteBomber_scraps.affected_by_drought = false;
		    EliteBomber_scraps.burnable = false;
            EliteBomber_scraps.base_stats[S.health] = 100f;
            EliteBomber_scraps.has_ruins_graphics = false;
		    EliteBomber_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    EliteBomber_scraps.race = "nature";
            EliteBomber_scraps.kingdom = "nature";
            EliteBomber_scraps.checkForCloseBuilding = false;
		    EliteBomber_scraps.canBeLivingHouse = false;
            EliteBomber_scraps.canBePlacedOnLiquid = true;
            EliteBomber_scraps.ignoreBuildings = true;
            EliteBomber_scraps.canBeHarvested = true;
            EliteBomber_scraps.setShadow(0.5f, 0.03f, 0.12f);
            EliteBomber_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    EliteBomber_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(EliteBomber_scraps);
            AssetManager.buildings.loadSprites(EliteBomber_scraps);


BuildingAsset eliteGunship_scraps = AssetManager.buildings.clone("eliteGunship_scraps", "scraps");
            eliteGunship_scraps.affected_by_drought = false;
		    eliteGunship_scraps.burnable = false;
            eliteGunship_scraps.base_stats[S.health] = 100f;
            eliteGunship_scraps.has_ruins_graphics = false;
		    eliteGunship_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    eliteGunship_scraps.race = "nature";
            eliteGunship_scraps.kingdom = "nature";
            eliteGunship_scraps.checkForCloseBuilding = false;
		    eliteGunship_scraps.canBeLivingHouse = false;
            eliteGunship_scraps.canBePlacedOnLiquid = true;
            eliteGunship_scraps.ignoreBuildings = true;
            eliteGunship_scraps.canBeHarvested = true;
            eliteGunship_scraps.setShadow(0.5f, 0.03f, 0.12f);
            eliteGunship_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    eliteGunship_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(eliteGunship_scraps);
            AssetManager.buildings.loadSprites(eliteGunship_scraps);

            BuildingAsset EliteP9000_scraps = AssetManager.buildings.clone("EliteP9000_scraps", "scraps");
            EliteP9000_scraps.affected_by_drought = false;
		    EliteP9000_scraps.burnable = false;
            EliteP9000_scraps.base_stats[S.health] = 100f;
            EliteP9000_scraps.has_ruins_graphics = false;
		    EliteP9000_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    EliteP9000_scraps.race = "nature";
            EliteP9000_scraps.kingdom = "nature";
            EliteP9000_scraps.checkForCloseBuilding = false;
		    EliteP9000_scraps.canBeLivingHouse = false;
            EliteP9000_scraps.canBePlacedOnLiquid = true;
            EliteP9000_scraps.ignoreBuildings = true;
            EliteP9000_scraps.canBeHarvested = true;
            EliteP9000_scraps.setShadow(0.5f, 0.03f, 0.12f);
            EliteP9000_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    EliteP9000_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(EliteP9000_scraps);
            AssetManager.buildings.loadSprites(EliteP9000_scraps);

            BuildingAsset EliteZeppelin_scraps = AssetManager.buildings.clone("EliteZeppelin_scraps", "scraps");
            EliteZeppelin_scraps.affected_by_drought = false;
		    EliteZeppelin_scraps.burnable = false;
            EliteZeppelin_scraps.base_stats[S.health] = 100f;
            EliteZeppelin_scraps.has_ruins_graphics = false;
		    EliteZeppelin_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    EliteZeppelin_scraps.race = "nature";
            EliteZeppelin_scraps.kingdom = "nature";
            EliteZeppelin_scraps.checkForCloseBuilding = false;
		    EliteZeppelin_scraps.canBeLivingHouse = false;
            EliteZeppelin_scraps.canBePlacedOnLiquid = true;
            EliteZeppelin_scraps.ignoreBuildings = true;
            EliteZeppelin_scraps.canBeHarvested = true;
            EliteZeppelin_scraps.setShadow(0.5f, 0.03f, 0.12f);
            EliteZeppelin_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    EliteZeppelin_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(EliteZeppelin_scraps);
            AssetManager.buildings.loadSprites(EliteZeppelin_scraps);

            BuildingAsset eliteMissileSystem_scraps = AssetManager.buildings.clone("eliteMissileSystem_scraps", "scraps");
            eliteMissileSystem_scraps.affected_by_drought = false;
		    eliteMissileSystem_scraps.burnable = false;
            eliteMissileSystem_scraps.base_stats[S.health] = 100f;
            eliteMissileSystem_scraps.has_ruins_graphics = false;
		    eliteMissileSystem_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    eliteMissileSystem_scraps.race = "nature";
            eliteMissileSystem_scraps.kingdom = "nature";
            eliteMissileSystem_scraps.checkForCloseBuilding = false;
		    eliteMissileSystem_scraps.canBeLivingHouse = false;
            eliteMissileSystem_scraps.canBePlacedOnLiquid = true;
            eliteMissileSystem_scraps.ignoreBuildings = true;
            eliteMissileSystem_scraps.canBeHarvested = true;
            eliteMissileSystem_scraps.setShadow(0.5f, 0.03f, 0.12f);
            eliteMissileSystem_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    eliteMissileSystem_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(eliteMissileSystem_scraps);
            AssetManager.buildings.loadSprites(eliteMissileSystem_scraps);

            BuildingAsset F55FighterJet_scraps = AssetManager.buildings.clone("F55FighterJet_scraps", "scraps");
            F55FighterJet_scraps.affected_by_drought = false;
		    F55FighterJet_scraps.burnable = false;
            F55FighterJet_scraps.base_stats[S.health] = 100f;
            F55FighterJet_scraps.has_ruins_graphics = false;
		    F55FighterJet_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    F55FighterJet_scraps.race = "nature";
            F55FighterJet_scraps.kingdom = "nature";
            F55FighterJet_scraps.checkForCloseBuilding = false;
		    F55FighterJet_scraps.canBeLivingHouse = false;
            F55FighterJet_scraps.canBePlacedOnLiquid = true;
            F55FighterJet_scraps.ignoreBuildings = true;
            F55FighterJet_scraps.canBeHarvested = true;
            F55FighterJet_scraps.setShadow(0.5f, 0.03f, 0.12f);
            F55FighterJet_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    F55FighterJet_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(F55FighterJet_scraps);
            AssetManager.buildings.loadSprites(F55FighterJet_scraps);

            BuildingAsset HeliELite_scraps = AssetManager.buildings.clone("HeliELite_scraps", "scraps");
            HeliELite_scraps.affected_by_drought = false;
		    HeliELite_scraps.burnable = false;
            HeliELite_scraps.base_stats[S.health] = 100f;
            HeliELite_scraps.has_ruins_graphics = false;
		    HeliELite_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    HeliELite_scraps.race = "nature";
            HeliELite_scraps.kingdom = "nature";
            HeliELite_scraps.checkForCloseBuilding = false;
		    HeliELite_scraps.canBeLivingHouse = false;
            HeliELite_scraps.canBePlacedOnLiquid = true;
            HeliELite_scraps.ignoreBuildings = true;
            HeliELite_scraps.canBeHarvested = true;
            HeliELite_scraps.setShadow(0.5f, 0.03f, 0.12f);
            HeliELite_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    HeliELite_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(HeliELite_scraps);
            AssetManager.buildings.loadSprites(HeliELite_scraps);

            BuildingAsset OmegaRailgun_scraps = AssetManager.buildings.clone("OmegaRailgun_scraps", "scraps");
            OmegaRailgun_scraps.affected_by_drought = false;
		    OmegaRailgun_scraps.burnable = false;
            OmegaRailgun_scraps.base_stats[S.health] = 100f;
            OmegaRailgun_scraps.has_ruins_graphics = false;
		    OmegaRailgun_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    OmegaRailgun_scraps.race = "nature";
            OmegaRailgun_scraps.kingdom = "nature";
            OmegaRailgun_scraps.checkForCloseBuilding = false;
		    OmegaRailgun_scraps.canBeLivingHouse = false;
            OmegaRailgun_scraps.canBePlacedOnLiquid = true;
            OmegaRailgun_scraps.ignoreBuildings = true;
            OmegaRailgun_scraps.canBeHarvested = true;
            OmegaRailgun_scraps.setShadow(0.5f, 0.03f, 0.12f);
            OmegaRailgun_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    OmegaRailgun_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(OmegaRailgun_scraps);
            AssetManager.buildings.loadSprites(OmegaRailgun_scraps);

            BuildingAsset SpaceMarine_scraps = AssetManager.buildings.clone("SpaceMarine_scraps", "scraps");
            SpaceMarine_scraps.affected_by_drought = false;
		    SpaceMarine_scraps.burnable = false;
            SpaceMarine_scraps.base_stats[S.health] = 100f;
            SpaceMarine_scraps.has_ruins_graphics = false;
		    SpaceMarine_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    SpaceMarine_scraps.race = "nature";
            SpaceMarine_scraps.kingdom = "nature";
            SpaceMarine_scraps.checkForCloseBuilding = false;
		    SpaceMarine_scraps.canBeLivingHouse = false;
            SpaceMarine_scraps.canBePlacedOnLiquid = true;
            SpaceMarine_scraps.ignoreBuildings = true;
            SpaceMarine_scraps.canBeHarvested = true;
            SpaceMarine_scraps.setShadow(0.5f, 0.03f, 0.12f);
            SpaceMarine_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    SpaceMarine_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(SpaceMarine_scraps);
            AssetManager.buildings.loadSprites(SpaceMarine_scraps);

            BuildingAsset TIEfighter_scraps = AssetManager.buildings.clone("TIEfighter_scraps", "scraps");
            TIEfighter_scraps.affected_by_drought = false;
		    TIEfighter_scraps.burnable = false;
            TIEfighter_scraps.base_stats[S.health] = 100f;
            TIEfighter_scraps.has_ruins_graphics = false;
		    TIEfighter_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    TIEfighter_scraps.race = "nature";
            TIEfighter_scraps.kingdom = "nature";
            TIEfighter_scraps.checkForCloseBuilding = false;
		    TIEfighter_scraps.canBeLivingHouse = false;
            TIEfighter_scraps.canBePlacedOnLiquid = true;
            TIEfighter_scraps.ignoreBuildings = true;
            TIEfighter_scraps.canBeHarvested = true;
            TIEfighter_scraps.setShadow(0.5f, 0.03f, 0.12f);
            TIEfighter_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    TIEfighter_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(TIEfighter_scraps);
            AssetManager.buildings.loadSprites(TIEfighter_scraps);

            BuildingAsset wheeledtank_scraps = AssetManager.buildings.clone("wheeledtank_scraps", "scraps");
            wheeledtank_scraps.affected_by_drought = false;
		    wheeledtank_scraps.burnable = false;
            wheeledtank_scraps.base_stats[S.health] = 100f;
            wheeledtank_scraps.has_ruins_graphics = false;
		    wheeledtank_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    wheeledtank_scraps.race = "nature";
            wheeledtank_scraps.kingdom = "nature";
            wheeledtank_scraps.checkForCloseBuilding = false;
		    wheeledtank_scraps.canBeLivingHouse = false;
            wheeledtank_scraps.canBePlacedOnLiquid = true;
            wheeledtank_scraps.ignoreBuildings = true;
            wheeledtank_scraps.canBeHarvested = true;
            wheeledtank_scraps.setShadow(0.5f, 0.03f, 0.12f);
            wheeledtank_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    wheeledtank_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(wheeledtank_scraps);
            AssetManager.buildings.loadSprites(wheeledtank_scraps);

            BuildingAsset Terran_scraps = AssetManager.buildings.clone("Terran_scraps", "scraps");
            Terran_scraps.affected_by_drought = false;
		    Terran_scraps.burnable = false;
            Terran_scraps.base_stats[S.health] = 100f;
            Terran_scraps.has_ruins_graphics = false;
		    Terran_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Terran_scraps.race = "nature";
            Terran_scraps.kingdom = "nature";
            Terran_scraps.checkForCloseBuilding = false;
		    Terran_scraps.canBeLivingHouse = false;
            Terran_scraps.canBePlacedOnLiquid = true;
            Terran_scraps.ignoreBuildings = true;
            Terran_scraps.canBeHarvested = true;
            Terran_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Terran_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Terran_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(Terran_scraps);
            AssetManager.buildings.loadSprites(Terran_scraps);

            BuildingAsset MissileSystem_scraps = AssetManager.buildings.clone("MissileSystem_scraps", "scraps");
            MissileSystem_scraps.affected_by_drought = false;
		    MissileSystem_scraps.burnable = false;
            MissileSystem_scraps.base_stats[S.health] = 100f;
            MissileSystem_scraps.has_ruins_graphics = false;
		    MissileSystem_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    MissileSystem_scraps.race = "nature";
            MissileSystem_scraps.kingdom = "nature";
            MissileSystem_scraps.checkForCloseBuilding = false;
		    MissileSystem_scraps.canBeLivingHouse = false;
            MissileSystem_scraps.canBePlacedOnLiquid = true;
            MissileSystem_scraps.ignoreBuildings = true;
            MissileSystem_scraps.canBeHarvested = true;
            MissileSystem_scraps.setShadow(0.5f, 0.03f, 0.12f);
            MissileSystem_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    MissileSystem_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(MissileSystem_scraps);
            AssetManager.buildings.loadSprites(MissileSystem_scraps);

            BuildingAsset Railgun_scraps = AssetManager.buildings.clone("Railgun_scraps", "scraps");
            Railgun_scraps.affected_by_drought = false;
		    Railgun_scraps.burnable = false;
            Railgun_scraps.base_stats[S.health] = 100f;
            Railgun_scraps.has_ruins_graphics = false;
		    Railgun_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Railgun_scraps.race = "nature";
            Railgun_scraps.kingdom = "nature";
            Railgun_scraps.checkForCloseBuilding = false;
		    Railgun_scraps.canBeLivingHouse = false;
            Railgun_scraps.canBePlacedOnLiquid = true;
            Railgun_scraps.ignoreBuildings = true;
            Railgun_scraps.canBeHarvested = true;
            Railgun_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Railgun_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Railgun_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(Railgun_scraps);
            AssetManager.buildings.loadSprites(Railgun_scraps);

            BuildingAsset Humvee_scraps = AssetManager.buildings.clone("Humvee_scraps", "scraps");
            Humvee_scraps.affected_by_drought = false;
		    Humvee_scraps.burnable = false;
            Humvee_scraps.base_stats[S.health] = 100f;
            Humvee_scraps.has_ruins_graphics = false;
		    Humvee_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Humvee_scraps.race = "nature";
            Humvee_scraps.kingdom = "nature";
            Humvee_scraps.checkForCloseBuilding = false;
		    Humvee_scraps.canBeLivingHouse = false;
            Humvee_scraps.canBePlacedOnLiquid = true;
            Humvee_scraps.ignoreBuildings = true;
            Humvee_scraps.canBeHarvested = true;
            Humvee_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Humvee_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Humvee_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(Humvee_scraps);
            AssetManager.buildings.loadSprites(Humvee_scraps);

            BuildingAsset Tank_scraps = AssetManager.buildings.clone("Tank_scraps", "scraps");
            Tank_scraps.affected_by_drought = false;
		    Tank_scraps.burnable = false;
            Tank_scraps.base_stats[S.health] = 100f;
            Tank_scraps.has_ruins_graphics = false;
		    Tank_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Tank_scraps.race = "nature";
            Tank_scraps.kingdom = "nature";
            Tank_scraps.checkForCloseBuilding = false;
		    Tank_scraps.canBeLivingHouse = false;
            Tank_scraps.canBePlacedOnLiquid = true;
            Tank_scraps.ignoreBuildings = true;
            Tank_scraps.canBeHarvested = true;
            Tank_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Tank_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Tank_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(Tank_scraps);
            AssetManager.buildings.loadSprites(Tank_scraps);

            BuildingAsset FighterJet_scraps = AssetManager.buildings.clone("FighterJet_scraps", "scraps");
            FighterJet_scraps.affected_by_drought = false;
		    FighterJet_scraps.burnable = false;
            FighterJet_scraps.base_stats[S.health] = 100f;
            FighterJet_scraps.has_ruins_graphics = false;
		    FighterJet_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    FighterJet_scraps.race = "nature";
            FighterJet_scraps.kingdom = "nature";
            FighterJet_scraps.checkForCloseBuilding = false;
		    FighterJet_scraps.canBeLivingHouse = false;
            FighterJet_scraps.canBePlacedOnLiquid = true;
            FighterJet_scraps.ignoreBuildings = true;
            FighterJet_scraps.canBeHarvested = true;
            FighterJet_scraps.setShadow(0.5f, 0.03f, 0.12f);
            FighterJet_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    FighterJet_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(FighterJet_scraps);
            AssetManager.buildings.loadSprites(FighterJet_scraps);

            BuildingAsset MIRVBomber_scraps = AssetManager.buildings.clone("MIRVBomber_scraps", "scraps");
            MIRVBomber_scraps.affected_by_drought = false;
		    MIRVBomber_scraps.burnable = false;
            MIRVBomber_scraps.base_stats[S.health] = 100f;
            MIRVBomber_scraps.has_ruins_graphics = false;
		    MIRVBomber_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    MIRVBomber_scraps.race = "nature";
            MIRVBomber_scraps.kingdom = "nature";
            MIRVBomber_scraps.checkForCloseBuilding = false;
		    MIRVBomber_scraps.canBeLivingHouse = false;
            MIRVBomber_scraps.canBePlacedOnLiquid = true;
            MIRVBomber_scraps.ignoreBuildings = true;
            MIRVBomber_scraps.canBeHarvested = true;
            MIRVBomber_scraps.setShadow(0.5f, 0.03f, 0.12f);
            MIRVBomber_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    MIRVBomber_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(MIRVBomber_scraps);
            AssetManager.buildings.loadSprites(MIRVBomber_scraps);

            BuildingAsset Zeppelin_scraps = AssetManager.buildings.clone("Zeppelin_scraps", "scraps");
            Zeppelin_scraps.affected_by_drought = false;
		    Zeppelin_scraps.burnable = false;
            Zeppelin_scraps.base_stats[S.health] = 100f;
            Zeppelin_scraps.has_ruins_graphics = false;
		    Zeppelin_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Zeppelin_scraps.race = "nature";
            Zeppelin_scraps.kingdom = "nature";
            Zeppelin_scraps.checkForCloseBuilding = false;
		    Zeppelin_scraps.canBeLivingHouse = false;
            Zeppelin_scraps.canBePlacedOnLiquid = true;
            Zeppelin_scraps.ignoreBuildings = true;
            Zeppelin_scraps.canBeHarvested = true;
            Zeppelin_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Zeppelin_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Zeppelin_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(Zeppelin_scraps);
            AssetManager.buildings.loadSprites(Zeppelin_scraps);

            BuildingAsset Drone_scraps = AssetManager.buildings.clone("Drone_scraps", "scraps");
            Drone_scraps.affected_by_drought = false;
		    Drone_scraps.burnable = false;
            Drone_scraps.base_stats[S.health] = 100f;
            Drone_scraps.has_ruins_graphics = false;
		    Drone_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Drone_scraps.race = "nature";
            Drone_scraps.kingdom = "nature";
            Drone_scraps.checkForCloseBuilding = false;
		    Drone_scraps.canBeLivingHouse = false;
            Drone_scraps.canBePlacedOnLiquid = true;
            Drone_scraps.ignoreBuildings = true;
            Drone_scraps.canBeHarvested = true;
            Drone_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Drone_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Drone_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 1, false);
            AssetManager.buildings.add(Drone_scraps);
            AssetManager.buildings.loadSprites(Drone_scraps);

            BuildingAsset Gunship_scraps = AssetManager.buildings.clone("Gunship_scraps", "scraps");
            Gunship_scraps.affected_by_drought = false;
		    Gunship_scraps.burnable = false;
            Gunship_scraps.base_stats[S.health] = 100f;
            Gunship_scraps.has_ruins_graphics = false;
		    Gunship_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Gunship_scraps.race = "nature";
            Gunship_scraps.kingdom = "nature";
            Gunship_scraps.checkForCloseBuilding = false;
		    Gunship_scraps.canBeLivingHouse = false;
            Gunship_scraps.canBePlacedOnLiquid = true;
            Gunship_scraps.ignoreBuildings = true;
            Gunship_scraps.canBeHarvested = true;
            Gunship_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Gunship_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Gunship_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(Gunship_scraps);
            AssetManager.buildings.loadSprites(Gunship_scraps);

            BuildingAsset Heli_scraps = AssetManager.buildings.clone("Heli_scraps", "scraps");
            Heli_scraps.affected_by_drought = false;
		    Heli_scraps.burnable = false;
            Heli_scraps.base_stats[S.health] = 100f;
            Heli_scraps.has_ruins_graphics = false;
		    Heli_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    Heli_scraps.race = "nature";
            Heli_scraps.kingdom = "nature";
            Heli_scraps.checkForCloseBuilding = false;
		    Heli_scraps.canBeLivingHouse = false;
            Heli_scraps.canBePlacedOnLiquid = true;
            Heli_scraps.ignoreBuildings = true;
            Heli_scraps.canBeHarvested = true;
            Heli_scraps.setShadow(0.5f, 0.03f, 0.12f);
            Heli_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    Heli_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(Heli_scraps);
            AssetManager.buildings.loadSprites(Heli_scraps);


            BuildingAsset americanbomberww_scraps = AssetManager.buildings.clone("americanbomberww_scraps", "scraps");
            americanbomberww_scraps.affected_by_drought = false;
		    americanbomberww_scraps.burnable = false;
            americanbomberww_scraps.base_stats[S.health] = 100f;
            americanbomberww_scraps.has_ruins_graphics = false;
		    americanbomberww_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    americanbomberww_scraps.race = "nature";
            americanbomberww_scraps.kingdom = "nature";
            americanbomberww_scraps.checkForCloseBuilding = false;
		    americanbomberww_scraps.canBeLivingHouse = false;
            americanbomberww_scraps.canBePlacedOnLiquid = true;
            americanbomberww_scraps.ignoreBuildings = true;
            americanbomberww_scraps.canBeHarvested = true;
            americanbomberww_scraps.setShadow(0.5f, 0.03f, 0.12f);
            americanbomberww_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    americanbomberww_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 1, false);
            AssetManager.buildings.add(americanbomberww_scraps);
            AssetManager.buildings.loadSprites(americanbomberww_scraps);

            BuildingAsset AT9000_scraps = AssetManager.buildings.clone("AT9000_scraps", "scraps");
            AT9000_scraps.affected_by_drought = false;
		    AT9000_scraps.burnable = false;
            AT9000_scraps.base_stats[S.health] = 100f;
            AT9000_scraps.has_ruins_graphics = false;
		    AT9000_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    AT9000_scraps.race = "nature";
            AT9000_scraps.kingdom = "nature";
            AT9000_scraps.checkForCloseBuilding = false;
		    AT9000_scraps.canBeLivingHouse = false;
            AT9000_scraps.canBePlacedOnLiquid = true;
            AT9000_scraps.ignoreBuildings = true;
            AT9000_scraps.canBeHarvested = true;
            AT9000_scraps.setShadow(0.5f, 0.03f, 0.12f);
            AT9000_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    AT9000_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(AT9000_scraps);
            AssetManager.buildings.loadSprites(AT9000_scraps);


BuildingAsset balloonunit_scraps = AssetManager.buildings.clone("balloonunit_scraps", "scraps");
            balloonunit_scraps.affected_by_drought = false;
		    balloonunit_scraps.burnable = false;
            balloonunit_scraps.base_stats[S.health] = 100f;
            balloonunit_scraps.has_ruins_graphics = false;
		    balloonunit_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    balloonunit_scraps.race = "nature";
            balloonunit_scraps.kingdom = "nature";
            balloonunit_scraps.checkForCloseBuilding = false;
		    balloonunit_scraps.canBeLivingHouse = false;
            balloonunit_scraps.canBePlacedOnLiquid = true;
            balloonunit_scraps.ignoreBuildings = true;
            balloonunit_scraps.canBeHarvested = true;
            balloonunit_scraps.setShadow(0.5f, 0.03f, 0.12f);
            balloonunit_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    balloonunit_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(balloonunit_scraps);
            AssetManager.buildings.loadSprites(balloonunit_scraps);

            BuildingAsset bigtankww_scraps = AssetManager.buildings.clone("bigtankww_scraps", "scraps");
            bigtankww_scraps.affected_by_drought = false;
		    bigtankww_scraps.burnable = false;
            bigtankww_scraps.base_stats[S.health] = 100f;
            bigtankww_scraps.has_ruins_graphics = false;
		    bigtankww_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    bigtankww_scraps.race = "nature";
            bigtankww_scraps.kingdom = "nature";
            bigtankww_scraps.checkForCloseBuilding = false;
		    bigtankww_scraps.canBeLivingHouse = false;
            bigtankww_scraps.canBePlacedOnLiquid = true;
            bigtankww_scraps.ignoreBuildings = true;
            bigtankww_scraps.canBeHarvested = true;
            bigtankww_scraps.setShadow(0.5f, 0.03f, 0.12f);
            bigtankww_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    bigtankww_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(bigtankww_scraps);
            AssetManager.buildings.loadSprites(bigtankww_scraps);

BuildingAsset biplane_scraps = AssetManager.buildings.clone("biplane_scraps", "scraps");
            biplane_scraps.affected_by_drought = false;
		    biplane_scraps.burnable = false;
            biplane_scraps.base_stats[S.health] = 100f;
            biplane_scraps.has_ruins_graphics = false;
		    biplane_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    biplane_scraps.race = "nature";
            biplane_scraps.kingdom = "nature";
            biplane_scraps.checkForCloseBuilding = false;
		    biplane_scraps.canBeLivingHouse = false;
            biplane_scraps.canBePlacedOnLiquid = true;
            biplane_scraps.ignoreBuildings = true;
            biplane_scraps.canBeHarvested = true;
            biplane_scraps.setShadow(0.5f, 0.03f, 0.12f);
            biplane_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    biplane_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(biplane_scraps);
            AssetManager.buildings.loadSprites(biplane_scraps);


BuildingAsset davincitank_scraps = AssetManager.buildings.clone("davincitank_scraps", "scraps");
            davincitank_scraps.affected_by_drought = false;
		    davincitank_scraps.burnable = false;
            davincitank_scraps.base_stats[S.health] = 100f;
            davincitank_scraps.has_ruins_graphics = false;
		    davincitank_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    davincitank_scraps.race = "nature";
            davincitank_scraps.kingdom = "nature";
            davincitank_scraps.checkForCloseBuilding = false;
		    davincitank_scraps.canBeLivingHouse = false;
            davincitank_scraps.canBePlacedOnLiquid = true;
            davincitank_scraps.ignoreBuildings = true;
            davincitank_scraps.canBeHarvested = true;
            davincitank_scraps.setShadow(0.5f, 0.03f, 0.12f);
            davincitank_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    davincitank_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(davincitank_scraps);
            AssetManager.buildings.loadSprites(davincitank_scraps);

            BuildingAsset genericwwtank_scraps = AssetManager.buildings.clone("genericwwtank_scraps", "scraps");
            genericwwtank_scraps.affected_by_drought = false;
		    genericwwtank_scraps.burnable = false;
            genericwwtank_scraps.base_stats[S.health] = 100f;
            genericwwtank_scraps.has_ruins_graphics = false;
		    genericwwtank_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    genericwwtank_scraps.race = "nature";
            genericwwtank_scraps.kingdom = "nature";
            genericwwtank_scraps.checkForCloseBuilding = false;
		    genericwwtank_scraps.canBeLivingHouse = false;
            genericwwtank_scraps.canBePlacedOnLiquid = true;
            genericwwtank_scraps.ignoreBuildings = true;
            genericwwtank_scraps.canBeHarvested = true;
            genericwwtank_scraps.setShadow(0.5f, 0.03f, 0.12f);
            genericwwtank_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    genericwwtank_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(genericwwtank_scraps);
            AssetManager.buildings.loadSprites(genericwwtank_scraps);

            BuildingAsset HumanTitan_scraps = AssetManager.buildings.clone("HumanTitan_scraps", "scraps");
            HumanTitan_scraps.affected_by_drought = false;
		    HumanTitan_scraps.burnable = false;
            HumanTitan_scraps.base_stats[S.health] = 100f;
            HumanTitan_scraps.has_ruins_graphics = false;
		    HumanTitan_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    HumanTitan_scraps.race = "nature";
            HumanTitan_scraps.kingdom = "nature";
            HumanTitan_scraps.checkForCloseBuilding = false;
		    HumanTitan_scraps.canBeLivingHouse = false;
            HumanTitan_scraps.canBePlacedOnLiquid = true;
            HumanTitan_scraps.ignoreBuildings = true;
            HumanTitan_scraps.canBeHarvested = true;
            HumanTitan_scraps.setShadow(0.5f, 0.03f, 0.12f);
            HumanTitan_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    HumanTitan_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(HumanTitan_scraps);
            AssetManager.buildings.loadSprites(HumanTitan_scraps);

            BuildingAsset shermanww_scraps = AssetManager.buildings.clone("shermanww_scraps", "scraps");
            shermanww_scraps.affected_by_drought = false;
		    shermanww_scraps.burnable = false;
            shermanww_scraps.base_stats[S.health] = 100f;
            shermanww_scraps.has_ruins_graphics = false;
		    shermanww_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    shermanww_scraps.race = "nature";
            shermanww_scraps.kingdom = "nature";
            shermanww_scraps.checkForCloseBuilding = false;
		    shermanww_scraps.canBeLivingHouse = false;
            shermanww_scraps.canBePlacedOnLiquid = true;
            shermanww_scraps.ignoreBuildings = true;
            shermanww_scraps.canBeHarvested = true;
            shermanww_scraps.setShadow(0.5f, 0.03f, 0.12f);
            shermanww_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    shermanww_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(shermanww_scraps);
            AssetManager.buildings.loadSprites(shermanww_scraps);

            BuildingAsset HumanTitanElite_scraps = AssetManager.buildings.clone("HumanTitanElite_scraps", "scraps");
            HumanTitanElite_scraps.affected_by_drought = false;
		    HumanTitanElite_scraps.burnable = false;
            HumanTitanElite_scraps.base_stats[S.health] = 100f;
            HumanTitanElite_scraps.has_ruins_graphics = false;
		    HumanTitanElite_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    HumanTitanElite_scraps.race = "nature";
            HumanTitanElite_scraps.kingdom = "nature";
            HumanTitanElite_scraps.checkForCloseBuilding = false;
		    HumanTitanElite_scraps.canBeLivingHouse = false;
            HumanTitanElite_scraps.canBePlacedOnLiquid = true;
            HumanTitanElite_scraps.ignoreBuildings = true;
            HumanTitanElite_scraps.canBeHarvested = true;
            HumanTitanElite_scraps.setShadow(0.5f, 0.03f, 0.12f);
            HumanTitanElite_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    HumanTitanElite_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(HumanTitanElite_scraps);
            AssetManager.buildings.loadSprites(HumanTitanElite_scraps);

            BuildingAsset landship_scraps = AssetManager.buildings.clone("landship_scraps", "scraps");
            landship_scraps.affected_by_drought = false;
		    landship_scraps.burnable = false;
            landship_scraps.base_stats[S.health] = 100f;
            landship_scraps.has_ruins_graphics = false;
		    landship_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    landship_scraps.race = "nature";
            landship_scraps.kingdom = "nature";
            landship_scraps.checkForCloseBuilding = false;
		    landship_scraps.canBeLivingHouse = false;
            landship_scraps.canBePlacedOnLiquid = true;
            landship_scraps.ignoreBuildings = true;
            landship_scraps.canBeHarvested = true;
            landship_scraps.setShadow(0.5f, 0.03f, 0.12f);
            landship_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    landship_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(landship_scraps);
            AssetManager.buildings.loadSprites(landship_scraps);

            BuildingAsset MA9000_scraps = AssetManager.buildings.clone("MA9000_scraps", "scraps");
            MA9000_scraps.affected_by_drought = false;
		    MA9000_scraps.burnable = false;
            MA9000_scraps.base_stats[S.health] = 100f;
            MA9000_scraps.has_ruins_graphics = false;
		    MA9000_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    MA9000_scraps.race = "nature";
            MA9000_scraps.kingdom = "nature";
            MA9000_scraps.checkForCloseBuilding = false;
		    MA9000_scraps.canBeLivingHouse = false;
            MA9000_scraps.canBePlacedOnLiquid = true;
            MA9000_scraps.ignoreBuildings = true;
            MA9000_scraps.canBeHarvested = true;
            MA9000_scraps.setShadow(0.5f, 0.03f, 0.12f);
            MA9000_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    MA9000_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(MA9000_scraps);
            AssetManager.buildings.loadSprites(MA9000_scraps);

            BuildingAsset modernhumvee_scraps = AssetManager.buildings.clone("modernhumvee_scraps", "scraps");
            modernhumvee_scraps.affected_by_drought = false;
		    modernhumvee_scraps.burnable = false;
            modernhumvee_scraps.base_stats[S.health] = 100f;
            modernhumvee_scraps.has_ruins_graphics = false;
		    modernhumvee_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    modernhumvee_scraps.race = "nature";
            modernhumvee_scraps.kingdom = "nature";
            modernhumvee_scraps.checkForCloseBuilding = false;
		    modernhumvee_scraps.canBeLivingHouse = false;
            modernhumvee_scraps.canBePlacedOnLiquid = true;
            modernhumvee_scraps.ignoreBuildings = true;
            modernhumvee_scraps.canBeHarvested = true;
            modernhumvee_scraps.setShadow(0.5f, 0.03f, 0.12f);
            modernhumvee_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    modernhumvee_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(modernhumvee_scraps);
            AssetManager.buildings.loadSprites(modernhumvee_scraps);

            BuildingAsset modernsupporttruck_scraps = AssetManager.buildings.clone("modernsupporttruck_scraps", "scraps");
            modernsupporttruck_scraps.affected_by_drought = false;
		    modernsupporttruck_scraps.burnable = false;
            modernsupporttruck_scraps.base_stats[S.health] = 100f;
            modernsupporttruck_scraps.has_ruins_graphics = false;
		    modernsupporttruck_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    modernsupporttruck_scraps.race = "nature";
            modernsupporttruck_scraps.kingdom = "nature";
            modernsupporttruck_scraps.checkForCloseBuilding = false;
		    modernsupporttruck_scraps.canBeLivingHouse = false;
            modernsupporttruck_scraps.canBePlacedOnLiquid = true;
            modernsupporttruck_scraps.ignoreBuildings = true;
            modernsupporttruck_scraps.canBeHarvested = true;
            modernsupporttruck_scraps.setShadow(0.5f, 0.03f, 0.12f);
            modernsupporttruck_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    modernsupporttruck_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(modernsupporttruck_scraps);
            AssetManager.buildings.loadSprites(modernsupporttruck_scraps);

            BuildingAsset tankie_scraps = AssetManager.buildings.clone("tankie_scraps", "scraps");
            tankie_scraps.affected_by_drought = false;
		    tankie_scraps.burnable = false;
            tankie_scraps.base_stats[S.health] = 100f;
            tankie_scraps.has_ruins_graphics = false;
		    tankie_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    tankie_scraps.race = "nature";
            tankie_scraps.kingdom = "nature";
            tankie_scraps.checkForCloseBuilding = false;
		    tankie_scraps.canBeLivingHouse = false;
            tankie_scraps.canBePlacedOnLiquid = true;
            tankie_scraps.ignoreBuildings = true;
            tankie_scraps.canBeHarvested = true;
            tankie_scraps.setShadow(0.5f, 0.03f, 0.12f);
            tankie_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    tankie_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(tankie_scraps);
            AssetManager.buildings.loadSprites(tankie_scraps);

            BuildingAsset teslatruckgun_scraps = AssetManager.buildings.clone("teslatruckgun_scraps", "scraps");
            teslatruckgun_scraps.affected_by_drought = false;
		    teslatruckgun_scraps.burnable = false;
            teslatruckgun_scraps.base_stats[S.health] = 100f;
            teslatruckgun_scraps.has_ruins_graphics = false;
		    teslatruckgun_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    teslatruckgun_scraps.race = "nature";
            teslatruckgun_scraps.kingdom = "nature";
            teslatruckgun_scraps.checkForCloseBuilding = false;
		    teslatruckgun_scraps.canBeLivingHouse = false;
            teslatruckgun_scraps.canBePlacedOnLiquid = true;
            teslatruckgun_scraps.ignoreBuildings = true;
            teslatruckgun_scraps.canBeHarvested = true;
            teslatruckgun_scraps.setShadow(0.5f, 0.03f, 0.12f);
            teslatruckgun_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    teslatruckgun_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(teslatruckgun_scraps);
            AssetManager.buildings.loadSprites(teslatruckgun_scraps);

            BuildingAsset wwartillery_scraps = AssetManager.buildings.clone("wwartillery_scraps", "scraps");
            wwartillery_scraps.affected_by_drought = false;
		    wwartillery_scraps.burnable = false;
            wwartillery_scraps.base_stats[S.health] = 100f;
            wwartillery_scraps.has_ruins_graphics = false;
		    wwartillery_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    wwartillery_scraps.race = "nature";
            wwartillery_scraps.kingdom = "nature";
            wwartillery_scraps.checkForCloseBuilding = false;
		    wwartillery_scraps.canBeLivingHouse = false;
            wwartillery_scraps.canBePlacedOnLiquid = true;
            wwartillery_scraps.ignoreBuildings = true;
            wwartillery_scraps.canBeHarvested = true;
            wwartillery_scraps.setShadow(0.5f, 0.03f, 0.12f);
            wwartillery_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    wwartillery_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(wwartillery_scraps);
            AssetManager.buildings.loadSprites(wwartillery_scraps);

            BuildingAsset wwsupporttruck_scraps = AssetManager.buildings.clone("wwsupporttruck_scraps", "scraps");
            wwsupporttruck_scraps.affected_by_drought = false;
		    wwsupporttruck_scraps.burnable = false;
            wwsupporttruck_scraps.base_stats[S.health] = 100f;
            wwsupporttruck_scraps.has_ruins_graphics = false;
		    wwsupporttruck_scraps.fundament = new BuildingFundament(1, 0, 1, 0);
		    wwsupporttruck_scraps.race = "nature";
            wwsupporttruck_scraps.kingdom = "nature";
            wwsupporttruck_scraps.checkForCloseBuilding = false;
		    wwsupporttruck_scraps.canBeLivingHouse = false;
            wwsupporttruck_scraps.canBePlacedOnLiquid = true;
            wwsupporttruck_scraps.ignoreBuildings = true;
            wwsupporttruck_scraps.canBeHarvested = true;
            wwsupporttruck_scraps.setShadow(0.5f, 0.03f, 0.12f);
            wwsupporttruck_scraps.sound_built = "event:/SFX/BUILDINGS/SpawnBuildingGeneric";
		    wwsupporttruck_scraps.sound_destroyed = "event:/SFX/BUILDINGS/DestroyBuildingGeneric";
            AssetManager.buildings.addResource("common_metals", 10, false);
            AssetManager.buildings.add(wwsupporttruck_scraps);
            AssetManager.buildings.loadSprites(wwsupporttruck_scraps);




//ProfessionAsset kingskinfix = AssetManager.professions.get("king");
//kingskinfix.use_skin_culture = true;

//ProfessionAsset leaderskinfix = AssetManager.professions.get("leader");
//leaderskinfix.use_skin_culture = true;


//////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    MethodInfo original = typeof(BuildOrder).GetMethod(nameof(BuildOrder.getBuildingAsset), BindingFlags.Instance | BindingFlags.Public);
    MethodInfo prefix = typeof(Commerce).GetMethod(nameof(getBuildingAsset_Prefix), BindingFlags.Static | BindingFlags.NonPublic);
    harmony.Patch(original, new HarmonyMethod(prefix));
    original = typeof(Building).GetMethod(nameof(Building.checkSpriteToRender), BindingFlags.Instance | BindingFlags.Public);
    prefix = typeof(Commerce).GetMethod(nameof(Building_checkSpriteToRender_Prefix), BindingFlags.Static | BindingFlags.NonPublic);
    harmony.Patch(original, new HarmonyMethod(prefix));
  }



      private static void AddBuildingOrderKeysToCivRaces1(string key, string value)
    {
        foreach (Race race in AssetManager.raceLibrary.list.Where(r => r.civilization))
        {
            race.building_order_keys[key] = value;
        }
    }

    private static void loadSprites1(BuildingAsset asset)
    {
        AssetManager.buildings.loadSprites(asset);
    }


[HarmonyPatch(typeof(BuildOrder), "getBuildingAsset")]
public static class BuildOrder_GetBuildingAsset_Patch
{
    static bool Prefix(Asset __instance, ref BuildingAsset __result, City pCity, string pBuildingID = null)
    {
        if (string.IsNullOrEmpty(pBuildingID))
            pBuildingID = __instance.id;
        try
        {
            string orderKey = pCity.race.building_order_keys[pBuildingID];
            __result = AssetManager.buildings.get(orderKey);
        }
        catch (Exception e)
        {
            Debug.LogError("Failed to get building order key for " + pBuildingID + ": " + e.Message);
        }
        return false;
    }
}

[HarmonyPatch(typeof(ai.behaviours.CityBehBuild), "haveRequiredBuildings")]
public static class CityBehBuild_HaveRequiredBuildings_Patch
{
    static bool Prefix(BuildOrder pOrder, City pCity, ref bool __result)
    {
        if (pOrder == null || pOrder.requirements_orders == null || pOrder.requirements_orders.Count == 0)
        {
            __result = true;
            return false;
        }
        foreach (string req in pOrder.requirements_orders)
        {
            BuildingAsset reqAsset = pOrder.getBuildingAsset(pCity, req);
            if (reqAsset == null || pCity.countBuildingExact(reqAsset.id) == 0)
            {
                __result = false;
                return false;
            }
        }
        __result = true;
        return false;
    }
}




/*
  public static void toggleDrones() {
    Main.modifyBoolOption("DronesOption", PowerButtons.GetToggleValue("Drones_Toggle"));
    if (PowerButtons.GetToggleValue("Drones_Toggle")) {
      turnOnDrones();
    } else {
      turnOffDrones();
    }
  }


  public static void turnOnDrones() { SetFactorySpawnUnits("DroneFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_DroneFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_DroneFactory", "DroneFactory"); }

  public static void turnOffDrones()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_DroneFactory"); }






  public static void toggleAirFactory() {
    Main.modifyBoolOption("MIRVBomberOption", PowerButtons.GetToggleValue("AirFactory_toggle"));
    if (PowerButtons.GetToggleValue("AirFactory_toggle")) {
      turnOnAirFactory();
    } else {
      turnOffAirFactory();
    }
  }


  public static void turnOnAirFactory() { SetFactorySpawnUnits("AirFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_AirFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_AirFactory", "AirFactory"); }

  public static void turnOffAirFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_AirFactory"); }




  public static void toggleTankFactory() {
    Main.modifyBoolOption("TankOption", PowerButtons.GetToggleValue("TankFactory_toggle"));
    if (PowerButtons.GetToggleValue("TankFactory_toggle")) {
      turnOnTankFactory();
    } else {
      turnOffTankFactory();
    }
  }


  public static void turnOnTankFactory() { SetFactorySpawnUnits("TankFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_TankFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_TankFactory", "TankFactory"); }

  public static void turnOffTankFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_TankFactory"); }

  

    public static void toggleTerranFactory() {
    Main.modifyBoolOption("TerranOption", PowerButtons.GetToggleValue("TerranFactory_toggle"));
    if (PowerButtons.GetToggleValue("TerranFactory_toggle")) {
      turnOnTerranFactory();
    } else {
      turnOffTerranFactory();
    }
  }


  public static void turnOnTerranFactory() { SetFactorySpawnUnits("TerranFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_TerranFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_TerranFactory", "TerranFactory"); }

  public static void turnOffTerranFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_TerranFactory"); }
  


      public static void toggleP9000Factory() {
    Main.modifyBoolOption("P9000Option", PowerButtons.GetToggleValue("P9000Factory_toggle"));
    if (PowerButtons.GetToggleValue("P9000Factory_toggle")) {
      turnOnP9000Factory();
    } else {
      turnOffP9000Factory();
    }
  }


  public static void turnOnP9000Factory() { SetFactorySpawnUnits("P9000Factory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_P9000Factory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_P9000Factory", "P9000Factory"); }

  public static void turnOffP9000Factory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_P9000Factory"); }

  


  public static void toggleBarracks() {
    Main.modifyBoolOption("SoldierOption", PowerButtons.GetToggleValue("Soldier_toggle"));
    if (PowerButtons.GetToggleValue("Soldier_toggle")) {
      turnOnSoldiers();
    } else {
      turnOffSoldiers();
    }
  }

   public static void turnOnSoldiers() { SetFactorySpawnUnits("Barracks_modern_human", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_Barracks_modern_human", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_Barracks_modern_human", "Barracks_modern_human"); }

  public static void turnOffSoldiers()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_Barracks_modern_human"); }


        public static void toggleRailgunFactory()
        {
            Main.modifyBoolOption("RailgunOption", PowerButtons.GetToggleValue("RailgunFactory_toggle"));
            if (PowerButtons.GetToggleValue("RailgunFactory_toggle"))
            {
                turnOnRailgunFactory();
            }
            else
            {
                turnOffRailgunFactory();
            }
        }


  public static void turnOnRailgunFactory() { SetFactorySpawnUnits("RailgunFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_RailgunFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_RailgunFactory", "RailgunFactory"); }

  public static void turnOffRailgunFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_RailgunFactory"); }




        public static void toggleHumveeFactory() {
    Main.modifyBoolOption("HumveeOption", PowerButtons.GetToggleValue("HumveeFactory_toggle"));
    if (PowerButtons.GetToggleValue("HumveeFactory_toggle")) {
      turnOnHumveeFactory();
    } else {
      turnOffHumveeFactory();
    }
  }


  public static void turnOnHumveeFactory() { SetFactorySpawnUnits("HumveeFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_HumveeFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_HumveeFactory", "HumveeFactory"); }

  public static void turnOffHumveeFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_HumveeFactory"); }



  public static void toggleHelicopterFactory() {
    Main.modifyBoolOption("HeliOption", PowerButtons.GetToggleValue("HelicopterFactory_toggle"));
    if (PowerButtons.GetToggleValue("HelicopterFactory_toggle")) {
      turnOnHelicopterFactory();
    } else {
      turnOffHelicopterFactory();
    }
  }


  public static void turnOnHelicopterFactory() { SetFactorySpawnUnits("HelicopterFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_HelicopterFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_HelicopterFactory", "HelicopterFactory"); }

  public static void turnOffHelicopterFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_HelicopterFactory"); }


  public static void toggleFighterJetFactory() {
    Main.modifyBoolOption("FighterJetOption", PowerButtons.GetToggleValue("FighterJetFactory_toggle"));
    if (PowerButtons.GetToggleValue("FighterJetFactory_toggle")) {
      turnOnFighterJetFactory();
    } else {
      turnOffFighterJetFactory();
    }
  }

  public static void turnOnFighterJetFactory() { SetFactorySpawnUnits("FighterJetFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_FighterJetFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_FighterJetFactory", "FighterJetFactory"); }

  public static void turnOffFighterJetFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_FighterJetFactory"); }


  public static void toggleAirshipFactory() {
    Main.modifyBoolOption("AirshipOption", PowerButtons.GetToggleValue("AirshipFactory_toggle"));
    if (PowerButtons.GetToggleValue("AirshipFactory_toggle")) {
      turnOnAirshipFactory();
    } else {
      turnOffAirshipFactory();
    }
  }


  public static void turnOnAirshipFactory() { SetFactorySpawnUnits("AirshipFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_AirshipFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_AirshipFactory", "AirshipFactory"); }

  public static void turnOffAirshipFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_AirshipFactory"); }


  public static void toggleBoiFactory() {
    Main.modifyBoolOption("BoiOption", PowerButtons.GetToggleValue("BoiFactory_toggle"));
    if (PowerButtons.GetToggleValue("BoiFactory_toggle")) {
      turnOnBoiFactory();
    } else {
      turnOffBoiFactory();
    }
  }
  public static void turnOnBoiFactory() { SetFactorySpawnUnits("BoiFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_BoiFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_BoiFactory", "BoiFactory"); }

  public static void turnOffBoiFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_BoiFactory"); }


  public static void toggleGunshipFactory() {
    Main.modifyBoolOption("GunshipOption", PowerButtons.GetToggleValue("GunshipFactory_toggle"));
    if (PowerButtons.GetToggleValue("GunshipFactory_toggle")) {
      turnOnGunshipFactory();
    } else {
      turnOffGunshipFactory();
    }
  }

   public static void turnOnGunshipFactory() { SetFactorySpawnUnits("GunshipFactory", true);
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
      human.addBuilding("order_GunshipFactory", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_GunshipFactory", "GunshipFactory"); }

  public static void turnOffGunshipFactory()  { RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");
			RemoveBuilding(human, "order_GunshipFactory"); }

  private static void SetFactoriesSpawnDrone(bool spawn) {
    List<string> droneIDs = new List<string>{"DroneFactory"};
    foreach (string droneID in droneIDs) {
      BuildingAsset dronefac = AssetManager.buildings.get(droneID);
      if (dronefac != null) {
        dronefac.spawnUnits = true;
      }
    }
  }
  */


	private static void SetFactorySpawnUnits(string factoryID, bool spawn) {
		BuildingAsset factory = AssetManager.buildings.get(factoryID);
		if (factory != null) {
			factory.spawnUnits = spawn;


    RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");

			if (!spawn) {
			//	RemoveBuildingOrderKeysToCivRaces($"order_{factoryID}", factoryID);
				RemoveBuilding(human, factoryID);

			}
			else
			{
				human.addBuilding($"order_{factoryID}", 1, pPop : 50, pBuildings : 16);
			//	AddBuildingOrderKeysToCivRaces($"order_{factoryID}", factoryID);
			}
		}
	}

  public static void toggleNukes() {
    Main.modifyBoolOption("NukeOption", PowerButtons.GetToggleValue("Nuke_toggle"));
    if (PowerButtons.GetToggleValue("Nuke_toggle")) {
      turnOnNukes();
    } else {
      turnOffNukes();
    }
  }

  public static void turnOnNukes() 
  { 
  OpenNukeWindow();
      RaceBuildOrderAsset human = AssetManager.race_build_orders.get("kingdom_base");

      human.addBuilding("order_MissileSilo", 1, pPop : 50, pBuildings : 16);
  AddBuildingOrderKeysToCivRaces("order_MissileSilo", "MissileSilo");
  }

  public static void turnOffNukes() {
      RemoveBuildingOrderKeysToCivRaces("order_MissileSilo", "MissileSilo");
}


  private static void OpenNukeWindow() {


    Windows.ShowWindow("NukeWindow");

  }
  
    private static void AddBuildingOrderKeysToCivRaces(string key, string value)
    {
        foreach (Race race in AssetManager.raceLibrary.list.Where(r => r.civilization))
        {
            race.building_order_keys[key] = value;
        }
    }


    /*
public static void toggleRenaissance() {
    Main.modifyBoolOption("RenaissanceOption", PowerButtons.GetToggleValue("Renaissance_toggle"));
    if (PowerButtons.GetToggleValue("Renaissance_toggle")) {
      turnOnRenaissance();
    } else {
      turnOffRenaissance();
    }
  }

  public static void turnOnRenaissance()
  {
  EnableTech("Renaissance");
  }

  public static void turnOffRenaissance() {
  DisableTech("Renaissance");
}


public static void EnableTech(string techId)
{
    foreach (Race race in AssetManager.raceLibrary.list.Where(r => r.civilization))
    {
        race.culture_forbidden_tech.Remove(techId);
    }
}

public static void DisableTech(string techId)
{
    foreach (Race race in AssetManager.raceLibrary.list.Where(r => r.civilization))
    {
        if (!race.culture_forbidden_tech.Contains(techId))
            race.culture_forbidden_tech.Add(techId);
    }
}

*/



  private static bool getBuildingAsset_Prefix(Asset __instance, ref BuildingAsset __result, City pCity, string pBuildingID = null) {
    if (string.IsNullOrEmpty(pBuildingID))
      pBuildingID = __instance.id;
    try {
      string buildingOrderKey = pCity.race.building_order_keys[pBuildingID];
      __result = AssetManager.buildings.get(buildingOrderKey);
    } catch (Exception e) {
      Debug.Log("Failed to get building order key for " + pBuildingID);
      Debug.Log(e);
    }

    return false;
  }
private static bool Building_checkSpriteToRender_Prefix(Building __instance) {
    bool isNotRuin = true;
    bool isRuin = __instance.isRuin();
    if (isRuin)
        isNotRuin = false;
    
    if (__instance.isUnderConstruction()) {
        __instance.last_main_sprite = __instance.asset.sprites.construction;
        __instance.spriteRenderer.sprite = __instance.last_main_sprite;
    } else {
        Sprite[] pSpriteAnimations;
        try {
            if (__instance.asset.has_special_animation_state)
                pSpriteAnimations = !__instance.hasResources ? __instance.animData.special : __instance.animData.main;
            else if (isRuin && __instance.asset.has_ruins_graphics) {
                pSpriteAnimations = __instance.animData.ruins;
            } else if (__instance.asset.spawn_drops && __instance.data.hasFlag(S.stop_spawn_drops))
                pSpriteAnimations = __instance.animData.main_disabled;
            else if (__instance.data.state == BuildingState.CivAbandoned) {
                pSpriteAnimations = __instance.animData.main_disabled.Length == 0 ? __instance.animData.main : __instance.animData.main_disabled;
                isNotRuin = false;
            } else {
                pSpriteAnimations = __instance.animData.main;
                Sprite[] spriteArray = __instance.asset.get_override_sprite_main?.Invoke(__instance);
                if (spriteArray != null)
                    pSpriteAnimations = spriteArray;
            }

            Sprite pBuildingSprite;
            try {
                pBuildingSprite = !__instance.check_spawn_animation 
                    ? (!isNotRuin || pSpriteAnimations.Length == 1 ? pSpriteAnimations[0] 
                        : AnimationHelper.getSpriteFromList(__instance.GetHashCode(), pSpriteAnimations, __instance.asset.animation_speed)) 
                    : __instance.getSpawnFrameSprite();
            } catch (Exception ex) {
                Debug.LogError($"Error calculating sprite for Building '{__instance.name}': {ex.Message}\n{ex.StackTrace}");
                __instance.kill();
                __instance.startRemove();
                return false;
            }

            if (!(__instance.last_main_sprite != pBuildingSprite) && __instance._last_color_asset == __instance.kingdom.kingdomColor)
                return false;

            __instance._last_colored_sprite = UnitSpriteConstructor.getRecoloredSpriteBuilding(pBuildingSprite, __instance.kingdom.kingdomColor);
            __instance.spriteRenderer.sprite = __instance._last_colored_sprite;
            __instance.last_main_sprite = pBuildingSprite;
            __instance._last_color_asset = __instance.kingdom.kingdomColor;
        } catch (Exception ex) {
            Debug.LogError($"Unhandled error in Building_checkSpriteToRender_Prefix for Building '{__instance.name}': {ex.Message}\n{ex.StackTrace}");
            return false;
        }
    }

    return false;
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
      public static void RemoveBuilding(RaceBuildOrderAsset raceBuildOrder, string buildingID) {
        if (raceBuildOrder == null || raceBuildOrder.list == null) {
            UnityEngine.Debug.LogError("RaceBuildOrderAsset or its list is null.");
            return;
        }

        var buildingToRemove = raceBuildOrder.list.FirstOrDefault(b => b.id == buildingID);

        if (buildingToRemove != null) {
            raceBuildOrder.list.Remove(buildingToRemove);
            UnityEngine.Debug.Log($"Building with ID {buildingID} removed successfully.");
        } else {
            UnityEngine.Debug.LogWarning($"Building with ID {buildingID} not found in the list.");
        }
    }
	
       [HarmonyPatch(typeof(BaseSimObject), "findEnemyObjectTarget")]
[HarmonyPrefix]
public static bool findEnemyObjectTarget_prefix(BaseSimObject __instance, ref BaseSimObject __result)
{
    bool pFindClosest = Toolbox.randomChance(0.6f);
    int range = -1;
    if (__instance is Building building && building.asset.id == "MissileSilo")
    {
        range = 25;
    }
    EnemyFinderData enemyFinderData = EnemiesFinder.findEnemiesFrom(__instance.currentTile, __instance.kingdom, range);
    if (enemyFinderData.list == null)
    {
        __result = null;
        return false;
    }
    BaseSimObject candidate = null;
    __instance.checkObjectList(enemyFinderData.list, pFindClosest, out candidate);

    if (__instance is Building silo && silo.asset.id == "MissileSilo" && __instance.kingdom != null)
    {
        if (candidate != null && candidate.kingdom == __instance.kingdom)
        {
            __result = null;
            return false;
        }
        if (candidate?.a != null)
        {
            if (candidate.a.data.health < 10000)
            {
                __result = null;
                return false;
            }
        }
    }
    __result = candidate;
    return false;
}






[HarmonyPatch(typeof(ActorBase), "getUnitTexturePath")]
public static class ActorBase_getUnitTexturePath_Patch
{
      /////////////////SOLDIER/////////////////////
    /////////////////////////////////////////////
    static string GetFutureSoldierTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Soldier_future_human";
            case "orc":   return "Soldier_future_orc";
            case "elf":   return "Soldier_future_elf";
            case "dwarf": return "Soldier_future_dwarf";
            default:
                return "Soldier_future_human";
        }
    }
      static string GetModernSoldierTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Soldier_modern_human";
            case "orc":   return "Soldier_modern_orc";
            case "elf":   return "Soldier_modern_elf";
            case "dwarf": return "Soldier_modern_dwarf";
            default:
                return "Soldier_modern_human";
        }
    }
    static string GetIndustrialSoldierTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Soldier_industrial_human";
            case "orc":   return "Soldier_industrial_orc";
            case "elf":   return "Soldier_industrial_elf";
            case "dwarf": return "Soldier_industrial_dwarf";
            default:
                return "Soldier_industrial_human";
        }
    }
    static string GetMedievalSoldierTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Soldier_medieval_human";
            case "orc":   return "Soldier_medieval_orc";
            case "elf":   return "Soldier_medieval_elf";
            case "dwarf": return "Soldier_medieval_dwarf";
            default:
                return "Soldier_medieval_human";
        }
    }
    //////////////////LEADER//////////////////////
    /////////////////////////////////////////////
    static string GetModernLeaderTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Leader_modern_human";
            case "orc":   return "Leader_modern_orc";
            case "elf":   return "Leader_modern_elf";
            case "dwarf": return "Leader_modern_dwarf";
            default:
                return "Leader_modern_human";
        }
    }
    static string GetRainLeaderTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Leader_rain_human";
            case "orc":   return "Leader_rain_orc";
            case "elf":   return "Leader_rain_elf";
            case "dwarf": return "Leader_rain_dwarf";
            default:
                return "Leader_rain_human";
        }
    }
        /////////////////KING//////////////////////
    /////////////////////////////////////////////
     static string GetModernKingTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "King_modern_human";
            case "orc":   return "King_modern_orc";
            case "elf":   return "King_modern_elf";
            case "dwarf": return "King_modern_dwarf";
            default:
                return "King_modern_human";
        }
    }
    static string GetRainKingTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "King_rain_human";
            case "orc":   return "King_rain_orc";
            case "elf":   return "King_rain_elf";
            case "dwarf": return "King_rain_dwarf";
            default:
                return "King_rain_human";
        }
    }
        //////////////UNITS/CIVILIANS////////////////////
    /////////////////////////////////////////////
     static string GetModernUnitTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Unit_modern_human";
            case "orc":   return "Unit_modern_orc";
            case "elf":   return "Unit_modern_elf";
            case "dwarf": return "Unit_modern_dwarf";
            default:
                return "Unit_modern_human";
        }
    }
    static string GetRainUnitTexture(string race)
    {
        switch (race.ToLower())
        {
            case "human": return "Unit_rain_human";
            case "orc":   return "Unit_rain_orc";
            case "elf":   return "Unit_rain_elf";
            case "dwarf": return "Unit_rain_dwarf";
            default:
                return "Unit_rain_human";
        }
    }
        /////////////////////////////////////////////
    /////////////////////////////////////////////

    [HarmonyPostfix]
    public static void Postfix(ActorBase __instance, ref string __result)
    {
        if (__instance.professionAsset.use_skin_culture &&
            __instance.professionAsset.profession_id == UnitProfession.Warrior)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null)
            {
                string race = __instance.asset.race;
                if (culture.hasTech("Future"))
                {
                    __result = GetFutureSoldierTexture(race);
                }
                 else if (culture.hasTech("MilitaryModern"))
                {
                    __result = GetModernSoldierTexture(race);
                }
                 else if (culture.hasTech("Industrial"))
                {
                    __result = GetIndustrialSoldierTexture(race);
                }
                else if (culture.hasTech("Renaissance"))
                {
                    __result = GetMedievalSoldierTexture(race);
                }
            }
        }
        else if (__instance.professionAsset.profession_id == UnitProfession.Leader)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null)
            {
                string race = __instance.asset.race;
                if (culture.hasTech("MilitaryModern"))
                {
                    __result = GetModernLeaderTexture(race);
                }
                else if (culture.hasTech("Renaissance"))
                {
                    __result = GetRainLeaderTexture(race);
                }
            }
        }
         else if (__instance.professionAsset.profession_id == UnitProfession.King)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null)
            {
                string race = __instance.asset.race;
                if (culture.hasTech("MilitaryModern"))
                {
                    __result = GetModernKingTexture(race);
                }
                else if (culture.hasTech("Renaissance"))
                {
                    __result = GetRainKingTexture(race);
                }
            }
        }
        else if (__instance.professionAsset.use_skin_culture &&
            __instance.professionAsset.profession_id == UnitProfession.Unit)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null)
            {
                string race = __instance.asset.race;
                if (culture.hasTech("MilitaryModern"))
                {
                    __result = GetModernUnitTexture(race);
                }
                else if (culture.hasTech("Renaissance"))
                {
                    __result = GetRainUnitTexture(race);
                }
            }
        }
    }
}


[HarmonyPatch(typeof(ActorBase), "checkSpriteHead")]
public static class ActorBase_checkSpriteHead_Patch
{
    [HarmonyPrefix]
    public static bool Prefix(ActorBase __instance)
    {
        if (!__instance.dirty_sprite_head)
        {
            return true;
        }
        if (__instance.asset.unit && __instance.data.profession == UnitProfession.Warrior)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null && (culture.hasTech("MilitaryModern") || culture.hasTech("Renaissance")))
            {
                __instance.dirty_sprite_head = false;
                string pPath = "actors/Soldier_head";
                __instance.setHeadSprite(ActorAnimationLoader.getHeadFromFullPath(pPath));
                return false;
            }
        }
        else if (__instance.asset.unit && __instance.data.profession == UnitProfession.King)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null && (culture.hasTech("MilitaryModern") || culture.hasTech("Renaissance")))
            {
                __instance.dirty_sprite_head = false;
                string pPath = "actors/Soldier_head";
                __instance.setHeadSprite(ActorAnimationLoader.getHeadFromFullPath(pPath));
                return false;
            }
        }
                else if (__instance.asset.unit && __instance.data.profession == UnitProfession.Leader)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null && (culture.hasTech("MilitaryModern") || culture.hasTech("Renaissance")))
            {
                __instance.dirty_sprite_head = false;
                string pPath = "actors/Soldier_head";
                __instance.setHeadSprite(ActorAnimationLoader.getHeadFromFullPath(pPath));
                return false;
            }
        }
                else if (__instance.asset.unit && __instance.data.profession == UnitProfession.Unit)
        {
            Culture culture = World.world.cultures.get(__instance.data.culture);
            if (culture != null && (culture.hasTech("MilitaryModern") || culture.hasTech("Renaissance")))
            {
                __instance.dirty_sprite_head = false;
                string pPath = "actors/Soldier_head";
                __instance.setHeadSprite(ActorAnimationLoader.getHeadFromFullPath(pPath));
                return false;
            }
        }

        return true;
    }
}





      [HarmonyPostfix]
        [HarmonyPatch(typeof(ActorAnimationLoader), "generateFrameData")]

        public static void generateFrameData_post(ActorAnimationLoader __instance,string pFrameString, AnimationContainerUnit pAnimContainer, Dictionary<string, Sprite> pFrames, string pFramesIDs)
        {

        }

        public static Sprite[] loadAllSprite(string path, bool withFolders = false)
        {
            string p = $"{Main.mainPath}/EmbededResources/{path}";
            DirectoryInfo folder = new DirectoryInfo(p);
            List<Sprite> res = new List<Sprite>();
            foreach (FileInfo file in folder.GetFiles("*.png"))
            {
                Sprite sprite = Sprites.LoadSprite($"{file.FullName}");
                sprite.name = file.Name.Replace(".png", "");
                res.Add(sprite);
            }
            foreach (DirectoryInfo cFolder in folder.GetDirectories())
            {
                foreach (FileInfo file in cFolder.GetFiles("*.png"))
                {
                    Sprite sprite = Sprites.LoadSprite($"{file.FullName}");
                    sprite.name = file.Name.Replace(".png", "");
                    res.Add(sprite);
                }
            }
            return res.ToArray();
        }



  private static Dictionary<string, Sprite[]> cached_sprite_list;
  internal static void loadSprites(BuildingAsset pTemplate) {
    if (cached_sprite_list is null) {
      cached_sprite_list = Reflection.GetField(typeof(SpriteTextureLoader), null, "cached_sprite_list") as Dictionary<string, Sprite[]>;
    }

    string pPath = pTemplate.sprite_path;
    if (String.IsNullOrEmpty(pPath)) {
      pPath = $"buildings/{pTemplate.id}";
    }

    if (cached_sprite_list.ContainsKey(pPath)) {
      cached_sprite_list.Remove(pPath);
    }

    AssetManager.buildings.loadSprites(pTemplate);
  }
}
}
