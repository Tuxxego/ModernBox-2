//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using System.Reflection;
using NCMS;
using UnityEngine;
using ReflectionUtility;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HarmonyLib;
using NCMS.Utils;
using System.Runtime.CompilerServices;
using DG.Tweening;
using EpPathFinding.cs;
using life.taxi;
using SleekRender;
using tools.debug;
using UnityEngine.EventSystems;
using WorldBoxConsole;
using Newtonsoft.Json;
using UnityEngine.Scripting;
using System.ComponentModel;

namespace M2
{
    public class Tech
    {
        public static void init(){

            Harmony harmony = new Harmony("Brug");
            MethodInfo original = AccessTools.Method(typeof(Culture), "haveRequiredTechFor");
            MethodInfo postfix = AccessTools.Method(typeof(Tech), "haveRequiredTechFor_Postfix");
            harmony.Patch(original, null, new HarmonyMethod(postfix));



        var culture_convert_chance_1 = AssetManager.culture_tech.get("culture_convert_chance_1");
        culture_convert_chance_1.knowledge_cost = -2f;
            AssetManager.culture_tech.add(culture_convert_chance_1);

        var culture_convert_chance_2 = AssetManager.culture_tech.get("culture_convert_chance_2");
        culture_convert_chance_2.knowledge_cost = -2f;
            AssetManager.culture_tech.add(culture_convert_chance_2);

        var culture_convert_chance_3 = AssetManager.culture_tech.get("culture_convert_chance_3");
        culture_convert_chance_3.knowledge_cost = -2f;
 AssetManager.culture_tech.add(culture_convert_chance_3);

        var culture_spread_speed_1 = AssetManager.culture_tech.get("culture_spread_speed_1");
        culture_spread_speed_1.knowledge_cost = -2f;
 AssetManager.culture_tech.add(culture_spread_speed_1);

        var culture_spread_speed_2 = AssetManager.culture_tech.get("culture_spread_speed_2");
        culture_spread_speed_2.knowledge_cost = -2f;
AssetManager.culture_tech.add(culture_spread_speed_2);

        var culture_spread_speed_3 = AssetManager.culture_tech.get("culture_spread_speed_3");
        culture_spread_speed_3.knowledge_cost = -2f;
AssetManager.culture_tech.add(culture_spread_speed_3);

        var ancestors_knowledge = AssetManager.culture_tech.get("ancestors_knowledge");
        ancestors_knowledge.knowledge_cost = -2f;
        AssetManager.culture_tech.add(ancestors_knowledge);

        var way_of_live = AssetManager.culture_tech.get("way_of_live");
        way_of_live.knowledge_cost = -2f;
        AssetManager.culture_tech.add(way_of_live);

        var heroes = AssetManager.culture_tech.get("heroes");
        heroes.knowledge_cost = -2f;
        AssetManager.culture_tech.add(heroes);

        var zones_1 = AssetManager.culture_tech.get("zones_1");
        zones_1.knowledge_cost = -2f;
        AssetManager.culture_tech.add(zones_1);

        var zones_2 = AssetManager.culture_tech.get("zones_2");
        zones_2.knowledge_cost = -2f;
        AssetManager.culture_tech.add(zones_2);

        var zones_3 = AssetManager.culture_tech.get("zones_3");
        zones_3.knowledge_cost = -2f;
AssetManager.culture_tech.add(zones_3);

        var housing_1 = AssetManager.culture_tech.get("housing_1");
        housing_1.knowledge_cost = -2f;
AssetManager.culture_tech.add(housing_1);

        var housing_2 = AssetManager.culture_tech.get("housing_2");
        housing_2.knowledge_cost = -2f;
AssetManager.culture_tech.add(housing_2);

        var housing_3 = AssetManager.culture_tech.get("housing_3");
        housing_3.knowledge_cost = -2f;
AssetManager.culture_tech.add(housing_3);

        var governance_1 = AssetManager.culture_tech.get("governance_1");
        governance_1.knowledge_cost = -2f;
AssetManager.culture_tech.add(governance_1);

        var governance_2 = AssetManager.culture_tech.get("governance_2");
        governance_2.knowledge_cost = -2f;
AssetManager.culture_tech.add(governance_2);

        var governance_3 = AssetManager.culture_tech.get("governance_3");
        governance_3.knowledge_cost = -2f;
AssetManager.culture_tech.add(governance_3);

        var knowledge_gain_1 = AssetManager.culture_tech.get("knowledge_gain_1");
        knowledge_gain_1.knowledge_cost = -2f;
AssetManager.culture_tech.add(knowledge_gain_1);

        var knowledge_gain_2 = AssetManager.culture_tech.get("knowledge_gain_2");
        knowledge_gain_2.knowledge_cost = -2f;
        AssetManager.culture_tech.add(knowledge_gain_2);

        var knowledge_gain_3 = AssetManager.culture_tech.get("knowledge_gain_3");
        knowledge_gain_3.knowledge_cost = -2f;
AssetManager.culture_tech.add(knowledge_gain_3);

        var army_training_1 = AssetManager.culture_tech.get("army_training_1");
        army_training_1.knowledge_cost = -2f;
        AssetManager.culture_tech.add(army_training_1);

        var army_training_2 = AssetManager.culture_tech.get("army_training_2");
        army_training_2.knowledge_cost = -2f;
AssetManager.culture_tech.add(army_training_2);

        var army_training_3 = AssetManager.culture_tech.get("army_training_3");
        army_training_3.knowledge_cost = -2f;
AssetManager.culture_tech.add(army_training_3);

        var military_strategy = AssetManager.culture_tech.get("military_strategy");
        military_strategy.knowledge_cost = -2f;
        AssetManager.culture_tech.add(military_strategy);

        var defense_strategy = AssetManager.culture_tech.get("defense_strategy");
        defense_strategy.knowledge_cost = -2f;
AssetManager.culture_tech.add(defense_strategy);

        var house_tier_0 = AssetManager.culture_tech.get("house_tier_0");
        house_tier_0.knowledge_cost = -2f;
AssetManager.culture_tech.add(house_tier_0);

        var house_tier_1 = AssetManager.culture_tech.get("house_tier_1");
        house_tier_1.knowledge_cost = -2f;
        AssetManager.culture_tech.add(house_tier_1);

        var house_tier_2 = AssetManager.culture_tech.get("house_tier_2");
        house_tier_2.knowledge_cost = -2f;
AssetManager.culture_tech.add(house_tier_2);

        var house_tier_3 = AssetManager.culture_tech.get("house_tier_3");
        house_tier_3.knowledge_cost = -2f;
        AssetManager.culture_tech.add(house_tier_3);

        var house_tier_4 = AssetManager.culture_tech.get("house_tier_4");
        house_tier_4.knowledge_cost = -2f;
        AssetManager.culture_tech.add(house_tier_4);

        var house_tier_5 = AssetManager.culture_tech.get("house_tier_5");
        house_tier_5.knowledge_cost = -2f;
        AssetManager.culture_tech.add(house_tier_5);

        var building_docks = AssetManager.culture_tech.get("building_docks");
        building_docks.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_docks);

        var building_roads = AssetManager.culture_tech.get("building_roads");
        building_roads.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_roads);

        var building_well = AssetManager.culture_tech.get("building_well");
        building_well.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_well);

        var building_watch_tower = AssetManager.culture_tech.get("building_watch_tower");
        building_watch_tower.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_watch_tower);

        var building_watch_tower_bonus = AssetManager.culture_tech.get("building_watch_tower_bonus");
        building_watch_tower_bonus.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_watch_tower_bonus);

        var building_statues = AssetManager.culture_tech.get("building_statues");
        building_statues.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_statues);

        var building_mine = AssetManager.culture_tech.get("building_mine");
        building_mine.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_mine);

        var building_barracks = AssetManager.culture_tech.get("building_barracks");
        building_barracks.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_barracks);

        var building_windmill = AssetManager.culture_tech.get("building_windmill");
        building_windmill.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_windmill);

        var building_temple = AssetManager.culture_tech.get("building_temple");
        building_temple.knowledge_cost = -2f;
        AssetManager.culture_tech.add(building_temple);

        var mining_efficiency = AssetManager.culture_tech.get("mining_efficiency");
        mining_efficiency.knowledge_cost = -2f;
        AssetManager.culture_tech.add(mining_efficiency);

        var sharp_axes = AssetManager.culture_tech.get("sharp_axes");
        sharp_axes.knowledge_cost = -2f;
        AssetManager.culture_tech.add(sharp_axes);

        var weaponsmith = AssetManager.culture_tech.get("weaponsmith");
        weaponsmith.knowledge_cost = -2f;
        AssetManager.culture_tech.add(weaponsmith);

        var armorsmith = AssetManager.culture_tech.get("armorsmith");
        armorsmith.knowledge_cost = -2f;
        AssetManager.culture_tech.add(armorsmith);

        var trading = AssetManager.culture_tech.get("trading");
        trading.knowledge_cost = -2f;
        AssetManager.culture_tech.add(trading);

        var trading_efficiency = AssetManager.culture_tech.get("trading_efficiency");
        trading_efficiency.knowledge_cost = -2f;
        AssetManager.culture_tech.add(trading_efficiency);

        var boats_trading = AssetManager.culture_tech.get("boats_trading");
        boats_trading.knowledge_cost = -2f;
        AssetManager.culture_tech.add(boats_trading);

        var boats_transport = AssetManager.culture_tech.get("boats_transport");
        boats_transport.knowledge_cost = -2f;
        AssetManager.culture_tech.add(boats_transport);

        var equipment_storage_1 = AssetManager.culture_tech.get("equipment_storage_1");
        equipment_storage_1.knowledge_cost = -2f;
        AssetManager.culture_tech.add(equipment_storage_1);

        var equipment_storage_2 = AssetManager.culture_tech.get("equipment_storage_2");
        equipment_storage_2.knowledge_cost = -2f;
        AssetManager.culture_tech.add(equipment_storage_2);

        var equipment_storage_3 = AssetManager.culture_tech.get("equipment_storage_3");
        equipment_storage_3.knowledge_cost = -2f;
        AssetManager.culture_tech.add(equipment_storage_3);

        var weapon_sword = AssetManager.culture_tech.get("weapon_sword");
        weapon_sword.knowledge_cost = -2f;
        AssetManager.culture_tech.add(weapon_sword);

        var weapon_axe = AssetManager.culture_tech.get("weapon_axe");
        weapon_axe.knowledge_cost = -2f;
        AssetManager.culture_tech.add(weapon_axe);

        var weapon_hammer = AssetManager.culture_tech.get("weapon_hammer");
        weapon_hammer.knowledge_cost = -2f;
        AssetManager.culture_tech.add(weapon_hammer);

        var weapon_spear = AssetManager.culture_tech.get("weapon_spear");
        weapon_spear.knowledge_cost = -2f;
        AssetManager.culture_tech.add(weapon_spear);

        var armor_production = AssetManager.culture_tech.get("armor_production");
        armor_production.knowledge_cost = -2f;
        AssetManager.culture_tech.add(armor_production);

        var weapon_production = AssetManager.culture_tech.get("weapon_production");
        weapon_production.knowledge_cost = -2f;
        AssetManager.culture_tech.add(weapon_production);

        var weapon_bow = AssetManager.culture_tech.get("weapon_bow");
        weapon_bow.knowledge_cost = -2f;
        AssetManager.culture_tech.add(weapon_bow);

        var material_copper = AssetManager.culture_tech.get("material_copper");
        material_copper.knowledge_cost = -2f;
        AssetManager.culture_tech.add(material_copper);

        var material_bronze = AssetManager.culture_tech.get("material_bronze");
        material_bronze.knowledge_cost = -2f;
        AssetManager.culture_tech.add(material_bronze);

        var material_silver = AssetManager.culture_tech.get("material_silver");
        material_silver.knowledge_cost = -2f;
        AssetManager.culture_tech.add(material_silver);

        var material_iron = AssetManager.culture_tech.get("material_iron");
        material_iron.knowledge_cost = -2f;
        AssetManager.culture_tech.add(material_iron);

        var material_steel = AssetManager.culture_tech.get("material_steel");
        material_steel.knowledge_cost = -2f;
        AssetManager.culture_tech.add(material_steel);

        var material_mythril = AssetManager.culture_tech.get("material_mythril");
        material_mythril.knowledge_cost = -2f;
        AssetManager.culture_tech.add(material_mythril);

        var material_adamantine = AssetManager.culture_tech.get("material_adamantine");
        material_adamantine.knowledge_cost = -2f;
        AssetManager.culture_tech.add(material_adamantine);



		 CultureTechAsset Renaissance = new CultureTechAsset();
            Renaissance.id = "Renaissance";
            Renaissance.path_icon = "Renaissance";
            Renaissance.priority = false;
            Renaissance.required_level = 55;
            Renaissance.requirements = new List<string> { "house_tier_5" };
            Localization.addLocalization("tech_Renaissance", "Renaissance era");
            AssetManager.culture_tech.add(Renaissance);

            CultureTechAsset Renaissance_knowledge_gain = new CultureTechAsset();
            Renaissance_knowledge_gain.id = "Renaissance_knowledge_gain";
            Renaissance_knowledge_gain.path_icon = "icon_tech_knowledge_gain3";
            Renaissance_knowledge_gain.priority = false;
            Renaissance_knowledge_gain.required_level = 55;
		    Renaissance_knowledge_gain.stats.knowledge_gain.add(-0.3f);
            Renaissance_knowledge_gain.requirements = new List<string> { "Renaissance" };
            Localization.addLocalization("tech_Renaissance_knowledge_gain", "Renaissance knowledge gain");
            AssetManager.culture_tech.add(Renaissance_knowledge_gain);

            CultureTechAsset Renaissance_mining = new CultureTechAsset();
            Renaissance_mining.id = "Renaissance_mining";
            Renaissance_mining.path_icon = "icon_tech_mining_efficiency";
            Renaissance_mining.priority = false;
            Renaissance_mining.required_level = 55;
		    Renaissance_mining.stats.bonus_res_chance_mineral.add(0.2f);
		    Renaissance_mining.stats.bonus_res_mineral_amount.add(1f);
            Renaissance_mining.requirements = new List<string> { "Renaissance_knowledge_gain" };
            Localization.addLocalization("tech_Renaissance_mining", "Renaissance mining");
            AssetManager.culture_tech.add(Renaissance_mining);

            CultureTechAsset Renaissance_axes = new CultureTechAsset();
            Renaissance_axes.id = "Renaissance_axes";
            Renaissance_axes.path_icon = "icon_tech_sharp_axes";
            Renaissance_axes.priority = false;
            Renaissance_axes.required_level = 55;
		    Renaissance_axes.stats.bonus_res_chance_wood.add(0.2f);
		    Renaissance_axes.stats.bonus_res_wood_amount.add(1f);
            Renaissance_axes.requirements = new List<string> { "Renaissance_mining" };
            Localization.addLocalization("tech_Renaissance_axes", "Renaissance axes");
            AssetManager.culture_tech.add(Renaissance_axes);

            CultureTechAsset Renaissance_trading = new CultureTechAsset();
            Renaissance_trading.id = "Renaissance_trading";
            Renaissance_trading.path_icon = "icon_tech_trading-_efficiency";
            Renaissance_trading.priority = false;
            Renaissance_trading.required_level = 55;
            Renaissance_trading.stats.mod_trading_bonus.add(0.15f);
            Renaissance_trading.requirements = new List<string> { "Renaissance_axes" };
            Localization.addLocalization("tech_Renaissance_trading", "Renaissance trading");
            AssetManager.culture_tech.add(Renaissance_trading);

            CultureTechAsset Renaissance_storage = new CultureTechAsset();
            Renaissance_storage.id = "Renaissance_storage";
            Renaissance_storage.path_icon = "icon_tech_city_storage_3";
            Renaissance_storage.priority = false;
            Renaissance_storage.required_level = 55;
            Renaissance_storage.stats.max_city_items.value = 2f;
            Renaissance_storage.requirements = new List<string> { "Renaissance_trading" };
            Localization.addLocalization("tech_Renaissance_storage", "Renaissance storage");
            AssetManager.culture_tech.add(Renaissance_storage);

            CultureTechAsset Renaissance_armorsmith = new CultureTechAsset();
            Renaissance_armorsmith.id = "Renaissance_armorsmith";
            Renaissance_armorsmith.path_icon = "icon_tech_armorsmith";
            Renaissance_armorsmith.priority = false;
            Renaissance_armorsmith.required_level = 55;
		    Renaissance_armorsmith.stats.item_production_tries_armor.add(2f);
            Renaissance_armorsmith.requirements = new List<string> { "Renaissance_storage" };
            Localization.addLocalization("tech_Renaissance_armorsmith", "Renaissance armorsmith");
            AssetManager.culture_tech.add(Renaissance_armorsmith);

            CultureTechAsset Renaissance_weaponsmith = new CultureTechAsset();
            Renaissance_weaponsmith.id = "Renaissance_weaponsmith";
            Renaissance_weaponsmith.path_icon = "icon_tech_weaponsmith";
            Renaissance_weaponsmith.priority = false;
            Renaissance_weaponsmith.required_level = 55;
		    Renaissance_weaponsmith.stats.item_production_tries_weapons.add(2f);
            Renaissance_weaponsmith.requirements = new List<string> { "Renaissance_armorsmith" };
            Localization.addLocalization("tech_Renaissance_weaponsmith", "Renaissance weaponsmith");
            AssetManager.culture_tech.add(Renaissance_weaponsmith);

            CultureTechAsset Renaissance_heroes = new CultureTechAsset();
            Renaissance_heroes.id = "Renaissance_heroes";
            Renaissance_heroes.path_icon = "icon_tech_heroes";
            Renaissance_heroes.priority = false;
            Renaissance_heroes.required_level = 55;
	     	Renaissance_heroes.stats.bonus_max_unit_level.add(2f);
            Renaissance_heroes.requirements = new List<string> { "Renaissance_weaponsmith" };
            Localization.addLocalization("tech_Renaissance_heroes", "heroes");
            AssetManager.culture_tech.add(Renaissance_heroes);

            CultureTechAsset Renaissance_knowledge = new CultureTechAsset();
            Renaissance_knowledge.id = "Renaissance_knowledge";
            Renaissance_knowledge.path_icon = "icon_tech_ancestors_knowledge";
            Renaissance_knowledge.priority = false;
            Renaissance_knowledge.required_level = 55;
            Renaissance_knowledge.stats.bonus_born_level.value = 2f;
            Renaissance_knowledge.requirements = new List<string> { "Renaissance_heroes" };
            Localization.addLocalization("tech_Renaissance_knowledge", "Renaissance knowledge");
            AssetManager.culture_tech.add(Renaissance_knowledge);


            CultureTechAsset Renaissance_housing = new CultureTechAsset();
            Renaissance_housing.id = "Renaissance_housing";
            Renaissance_housing.path_icon = "icon_tech_housing_3";
            Renaissance_housing.priority = false;
            Renaissance_housing.required_level = 55;
		    Renaissance_housing.stats.housing.add(1f);
            Renaissance_housing.requirements = new List<string> { "Renaissance_knowledge" };
            Localization.addLocalization("tech_Renaissance_housing", "better housing");
            AssetManager.culture_tech.add(Renaissance_housing);

            CultureTechAsset Renaissance_defenses = new CultureTechAsset();
            Renaissance_defenses.id = "Renaissance_defenses";
            Renaissance_defenses.path_icon = "icon_tech_watch_tower_bonus";
            Renaissance_defenses.priority = false;
            Renaissance_defenses.required_level = 55;
		    Renaissance_defenses.stats.bonus_watch_towers.value = 2f;
            Renaissance_defenses.requirements = new List<string> { "Renaissance_housing" };
            Localization.addLocalization("tech_Renaissance_defenses", "defense tower");
            AssetManager.culture_tech.add(Renaissance_defenses);

            CultureTechAsset Renaissance_army = new CultureTechAsset();
            Renaissance_army.id = "Renaissance_army";
            Renaissance_army.path_icon = "army_training_3";
            Renaissance_army.priority = false;
            Renaissance_army.required_level = 55;
		    Renaissance_army.stats.bonus_max_army.add(0.1f);
            Renaissance_army.requirements = new List<string> { "Renaissance_defenses" };
            Localization.addLocalization("tech_Renaissance_army", "Renaissance army");
            AssetManager.culture_tech.add(Renaissance_army);

            CultureTechAsset Renaissance_strategy = new CultureTechAsset();
            Renaissance_strategy.id = "Renaissance_strategy";
            Renaissance_strategy.path_icon = "icon_tech_military_strategy";
            Renaissance_strategy.priority = false;
            Renaissance_strategy.required_level = 55;
		    Renaissance_strategy.stats.bonus_damage.add(0.1f);
            Renaissance_strategy.requirements = new List<string> { "Renaissance_army" };
            Localization.addLocalization("tech_Renaissance_strategy", "Renaissance strategy");
            AssetManager.culture_tech.add(Renaissance_strategy);

             CultureTechAsset Renaissance_defense = new CultureTechAsset();
            Renaissance_defense.id = "Renaissance_defense";
            Renaissance_defense.path_icon = "icon_tech_defense_strategy";
            Renaissance_defense.priority = false;
            Renaissance_defense.required_level = 55;
		    Renaissance_defense.stats.bonus_armor.add(0.1f);
            Renaissance_defense.requirements = new List<string> { "Renaissance_strategy" };
            Localization.addLocalization("tech_Renaissance_defense", "Renaissance defense");
            AssetManager.culture_tech.add(Renaissance_defense);




            CultureTechAsset Casino = new CultureTechAsset();
            Casino.id = "Casino";
            Casino.path_icon = "Casino";
            Casino.priority = false;
            Casino.required_level = 60;
            Casino.requirements = new List<string> { "Renaissance" };
            Localization.addLocalization("tech_Casino", "Casino");
            AssetManager.culture_tech.add(Casino);

            CultureTechAsset Industrial = new CultureTechAsset();
            Industrial.id = "Industrial";
            Industrial.path_icon = "Industrial";
            Industrial.priority = false;
            Industrial.required_level = 65;
            Industrial.requirements = new List<string> { "Renaissance_defense" };
            Localization.addLocalization("tech_Industrial", "Industrial era");
            AssetManager.culture_tech.add(Industrial);

            CultureTechAsset Firearms = new CultureTechAsset();
            Firearms.id = "Firearms";
            Firearms.path_icon = "firearm";
            Firearms.priority = false;
            Firearms.required_level = 65;
            Firearms.requirements = new List<string> { "Industrial" };
            Localization.addLocalization("tech_Firearms", "Better Firearm Production");
            AssetManager.culture_tech.add(Firearms);

            CultureTechAsset Industrial_knowledge_gain = new CultureTechAsset();
            Industrial_knowledge_gain.id = "Industrial_knowledge_gain";
            Industrial_knowledge_gain.path_icon = "icon_tech_knowledge_gain3";
            Industrial_knowledge_gain.priority = false;
            Industrial_knowledge_gain.required_level = 65;
		    Industrial_knowledge_gain.stats.knowledge_gain.add(-0.3f);
            Industrial_knowledge_gain.requirements = new List<string> { "Firearms" };
            Localization.addLocalization("tech_Industrial_knowledge_gain", "Industrial knowledge gain");
            AssetManager.culture_tech.add(Industrial_knowledge_gain);

            CultureTechAsset Industrial_mining = new CultureTechAsset();
            Industrial_mining.id = "Industrial_mining";
            Industrial_mining.path_icon = "icon_tech_mining_efficiency";
            Industrial_mining.priority = false;
            Industrial_mining.required_level = 65;
		    Industrial_mining.stats.bonus_res_chance_mineral.add(0.2f);
		    Industrial_mining.stats.bonus_res_mineral_amount.add(1f);
            Industrial_mining.requirements = new List<string> { "Industrial_knowledge_gain" };
            Localization.addLocalization("tech_Industrial_mining", "Industrial mining");
            AssetManager.culture_tech.add(Industrial_mining);

            CultureTechAsset Industrial_axes = new CultureTechAsset();
            Industrial_axes.id = "Industrial_axes";
            Industrial_axes.path_icon = "icon_tech_sharp_axes";
            Industrial_axes.priority = false;
            Industrial_axes.required_level = 65;
		    Industrial_axes.stats.bonus_res_chance_wood.add(0.2f);
		    Industrial_axes.stats.bonus_res_wood_amount.add(1f);
            Industrial_axes.requirements = new List<string> { "Industrial_mining" };
            Localization.addLocalization("tech_Industrial_axes", "Industrial axes");
            AssetManager.culture_tech.add(Industrial_axes);

            CultureTechAsset Industrial_trading = new CultureTechAsset();
            Industrial_trading.id = "Industrial_trading";
            Industrial_trading.path_icon = "icon_tech_trading-_efficiency";
            Industrial_trading.priority = false;
            Industrial_trading.required_level = 65;
            Industrial_trading.stats.mod_trading_bonus.add(0.15f);
            Industrial_trading.requirements = new List<string> { "Industrial_axes" };
            Localization.addLocalization("tech_Industrial_trading", "Industrial trading");
            AssetManager.culture_tech.add(Industrial_trading);

            CultureTechAsset Industrial_storage = new CultureTechAsset();
            Industrial_storage.id = "Industrial_storage";
            Industrial_storage.path_icon = "icon_tech_city_storage_3";
            Industrial_storage.priority = false;
            Industrial_storage.required_level = 65;
            Industrial_storage.stats.max_city_items.value = 2f;
            Industrial_storage.requirements = new List<string> { "Industrial_trading" };
            Localization.addLocalization("tech_Industrial_storage", "Industrial storage");
            AssetManager.culture_tech.add(Industrial_storage);

            CultureTechAsset Industrial_armorsmith = new CultureTechAsset();
            Industrial_armorsmith.id = "Industrial_armorsmith";
            Industrial_armorsmith.path_icon = "icon_tech_armorsmith";
            Industrial_armorsmith.priority = false;
            Industrial_armorsmith.required_level = 65;
		    Industrial_armorsmith.stats.item_production_tries_armor.add(2f);
            Industrial_armorsmith.requirements = new List<string> { "Industrial_storage" };
            Localization.addLocalization("tech_Industrial_armorsmith", "Industrial armorsmith");
            AssetManager.culture_tech.add(Industrial_armorsmith);

            CultureTechAsset Industrial_weaponsmith = new CultureTechAsset();
            Industrial_weaponsmith.id = "Industrial_weaponsmith";
            Industrial_weaponsmith.path_icon = "icon_tech_weaponsmith";
            Industrial_weaponsmith.priority = false;
            Industrial_weaponsmith.required_level = 65;
		    Industrial_weaponsmith.stats.item_production_tries_weapons.add(2f);
            Industrial_weaponsmith.requirements = new List<string> { "Industrial_armorsmith" };
            Localization.addLocalization("tech_Industrial_weaponsmith", "Industrial weaponsmith");
            AssetManager.culture_tech.add(Industrial_weaponsmith);

            CultureTechAsset Industrial_heroes = new CultureTechAsset();
            Industrial_heroes.id = "Industrial_heroes";
            Industrial_heroes.path_icon = "icon_tech_heroes";
            Industrial_heroes.priority = false;
            Industrial_heroes.required_level = 65;
	     	Industrial_heroes.stats.bonus_max_unit_level.add(2f);
            Industrial_heroes.requirements = new List<string> { "Industrial_weaponsmith" };
            Localization.addLocalization("tech_Industrial_heroes", "heroes");
            AssetManager.culture_tech.add(Industrial_heroes);

            CultureTechAsset Cyberware = new CultureTechAsset();
            Cyberware.id = "Cyberware";
            Cyberware.path_icon = "Cyberware";
            Cyberware.priority = false;
            Cyberware.required_level = 65;
            Cyberware.requirements = new List<string> { "Industrial_heroes" };
            Localization.addLocalization("tech_Cyberware", "Cyberware");
            AssetManager.culture_tech.add(Cyberware);

            CultureTechAsset Nukes = new CultureTechAsset();
            Nukes.id = "Nukes";
            Nukes.path_icon = "Nuke";
            Nukes.priority = false;
            Nukes.required_level = 65;
            Nukes.requirements = new List<string> { "Cyberware" };
            Localization.addLocalization("tech_Nukes", "Nukes");
            AssetManager.culture_tech.add(Nukes);

            CultureTechAsset Industrial_knowledge = new CultureTechAsset();
            Industrial_knowledge.id = "Industrial_knowledge";
            Industrial_knowledge.path_icon = "icon_tech_ancestors_knowledge";
            Industrial_knowledge.priority = false;
            Industrial_knowledge.required_level = 65;
            Industrial_knowledge.stats.bonus_born_level.value = 2f;
            Industrial_knowledge.requirements = new List<string> { "Industrial_heroes" };
            Localization.addLocalization("tech_Industrial_knowledge", "Industrial knowledge");
            AssetManager.culture_tech.add(Industrial_knowledge);


            CultureTechAsset Industrial_housing = new CultureTechAsset();
            Industrial_housing.id = "Industrial_housing";
            Industrial_housing.path_icon = "icon_tech_housing_3";
            Industrial_housing.priority = false;
            Industrial_housing.required_level = 65;
		    Industrial_housing.stats.housing.add(1f);
            Industrial_housing.requirements = new List<string> { "Industrial_knowledge" };
            Localization.addLocalization("tech_Industrial_housing", "better housing");
            AssetManager.culture_tech.add(Industrial_housing);

            CultureTechAsset Industrial_defenses = new CultureTechAsset();
            Industrial_defenses.id = "Industrial_defenses";
            Industrial_defenses.path_icon = "icon_tech_watch_tower_bonus";
            Industrial_defenses.priority = false;
            Industrial_defenses.required_level = 65;
		    Industrial_defenses.stats.bonus_watch_towers.value = 2f;
            Industrial_defenses.requirements = new List<string> { "Industrial_housing" };
            Localization.addLocalization("tech_Industrial_defenses", "defense tower");
            AssetManager.culture_tech.add(Industrial_defenses);

            CultureTechAsset Industrial_army = new CultureTechAsset();
            Industrial_army.id = "Industrial_army";
            Industrial_army.path_icon = "army_training_3";
            Industrial_army.priority = false;
            Industrial_army.required_level = 65;
		    Industrial_army.stats.bonus_max_army.add(0.1f);
            Industrial_army.requirements = new List<string> { "Industrial_defenses" };
            Localization.addLocalization("tech_Industrial_army", "Industrial army");
            AssetManager.culture_tech.add(Industrial_army);

            CultureTechAsset Industrial_strategy = new CultureTechAsset();
            Industrial_strategy.id = "Industrial_strategy";
            Industrial_strategy.path_icon = "icon_tech_military_strategy";
            Industrial_strategy.priority = false;
            Industrial_strategy.required_level = 65;
		    Industrial_strategy.stats.bonus_damage.add(0.1f);
            Industrial_strategy.requirements = new List<string> { "Industrial_army" };
            Localization.addLocalization("tech_Industrial_strategy", "Industrial strategy");
            AssetManager.culture_tech.add(Industrial_strategy);

             CultureTechAsset Industrial_defense = new CultureTechAsset();
            Industrial_defense.id = "Industrial_defense";
            Industrial_defense.path_icon = "icon_tech_defense_strategy";
            Industrial_defense.priority = false;
            Industrial_defense.required_level = 65;
		    Industrial_defense.stats.bonus_armor.add(0.1f);
            Industrial_defense.requirements = new List<string> { "Industrial_strategy" };
            Localization.addLocalization("tech_Industrial_defense", "Industrial defense");
            AssetManager.culture_tech.add(Industrial_defense);


            CultureTechAsset Skyscraper = new CultureTechAsset();
            Skyscraper.id = "Skyscraper";
            Skyscraper.path_icon = "Skyscraper";
            Skyscraper.priority = false;
            Skyscraper.required_level = 80;
            Skyscraper.requirements = new List<string> { "Industrial_defense" };
            Localization.addLocalization("tech_Skyscraper", "Modern Era");
            AssetManager.culture_tech.add(Skyscraper);

            CultureTechAsset MilitaryModern = new CultureTechAsset();
            MilitaryModern.id = "MilitaryModern";
            MilitaryModern.path_icon = "force";
            MilitaryModern.priority = false;
            MilitaryModern.required_level = 80;
            MilitaryModern.requirements = new List<string> { "Skyscraper" };
            Localization.addLocalization("tech_MilitaryModern", "Modern Military");
            MilitaryModern.stats.bonus_max_army.add(5000f);
            AssetManager.culture_tech.add(MilitaryModern);

            CultureTechAsset Modern_knowledge_gain = new CultureTechAsset();
            Modern_knowledge_gain.id = "Modern_knowledge_gain";
            Modern_knowledge_gain.path_icon = "icon_tech_knowledge_gain3";
            Modern_knowledge_gain.priority = false;
            Modern_knowledge_gain.required_level = 80;
		    Modern_knowledge_gain.stats.knowledge_gain.add(-0.3f);
            Modern_knowledge_gain.requirements = new List<string> { "MilitaryModern" };
            Localization.addLocalization("tech_Modern_knowledge_gain", "Modern knowledge gain");
            AssetManager.culture_tech.add(Modern_knowledge_gain);

            CultureTechAsset Modern_mining = new CultureTechAsset();
            Modern_mining.id = "Modern_mining";
            Modern_mining.path_icon = "icon_tech_mining_efficiency";
            Modern_mining.priority = false;
            Modern_mining.required_level = 80;
		    Modern_mining.stats.bonus_res_chance_mineral.add(0.2f);
		    Modern_mining.stats.bonus_res_mineral_amount.add(1f);
            Modern_mining.requirements = new List<string> { "Modern_knowledge_gain" };
            Localization.addLocalization("tech_Modern_mining", "Modern mining");
            AssetManager.culture_tech.add(Modern_mining);

            CultureTechAsset Modern_axes = new CultureTechAsset();
            Modern_axes.id = "Modern_axes";
            Modern_axes.path_icon = "icon_tech_sharp_axes";
            Modern_axes.priority = false;
            Modern_axes.required_level = 80;
		    Modern_axes.stats.bonus_res_chance_wood.add(0.2f);
		    Modern_axes.stats.bonus_res_wood_amount.add(1f);
            Modern_axes.requirements = new List<string> { "Modern_mining" };
            Localization.addLocalization("tech_Modern_axes", "Modern axes");
            AssetManager.culture_tech.add(Modern_axes);

            CultureTechAsset Modern_trading = new CultureTechAsset();
            Modern_trading.id = "Modern_trading";
            Modern_trading.path_icon = "icon_tech_trading-_efficiency";
            Modern_trading.priority = false;
            Modern_trading.required_level = 80;
            Modern_trading.stats.mod_trading_bonus.add(0.15f);
            Modern_trading.requirements = new List<string> { "Modern_axes" };
            Localization.addLocalization("tech_Modern_trading", "Modern trading");
            AssetManager.culture_tech.add(Modern_trading);

            CultureTechAsset Modern_storage = new CultureTechAsset();
            Modern_storage.id = "Modern_storage";
            Modern_storage.path_icon = "icon_tech_city_storage_3";
            Modern_storage.priority = false;
            Modern_storage.required_level = 80;
            Modern_storage.stats.max_city_items.value = 2f;
            Modern_storage.requirements = new List<string> { "Modern_trading" };
            Localization.addLocalization("tech_Modern_storage", "Modern storage");
            AssetManager.culture_tech.add(Modern_storage);

            CultureTechAsset Modern_armorsmith = new CultureTechAsset();
            Modern_armorsmith.id = "Modern_armorsmith";
            Modern_armorsmith.path_icon = "icon_tech_armorsmith";
            Modern_armorsmith.priority = false;
            Modern_armorsmith.required_level = 80;
		    Modern_armorsmith.stats.item_production_tries_armor.add(2f);
            Modern_armorsmith.requirements = new List<string> { "Modern_storage" };
            Localization.addLocalization("tech_Modern_armorsmith", "Modern armorsmith");
            AssetManager.culture_tech.add(Modern_armorsmith);

            CultureTechAsset Modern_weaponsmith = new CultureTechAsset();
            Modern_weaponsmith.id = "Modern_weaponsmith";
            Modern_weaponsmith.path_icon = "icon_tech_weaponsmith";
            Modern_weaponsmith.priority = false;
            Modern_weaponsmith.required_level = 80;
		    Modern_weaponsmith.stats.item_production_tries_weapons.add(2f);
            Modern_weaponsmith.requirements = new List<string> { "Modern_armorsmith" };
            Localization.addLocalization("tech_Modern_weaponsmith", "Modern weaponsmith");
            AssetManager.culture_tech.add(Modern_weaponsmith);

            CultureTechAsset Modern_heroes = new CultureTechAsset();
            Modern_heroes.id = "Modern_heroes";
            Modern_heroes.path_icon = "icon_tech_heroes";
            Modern_heroes.priority = false;
            Modern_heroes.required_level = 80;
	     	Modern_heroes.stats.bonus_max_unit_level.add(2f);
            Modern_heroes.requirements = new List<string> { "Modern_weaponsmith" };
            Localization.addLocalization("tech_Modern_heroes", "heroes");
            AssetManager.culture_tech.add(Modern_heroes);

            CultureTechAsset Modern_knowledge = new CultureTechAsset();
            Modern_knowledge.id = "Modern_knowledge";
            Modern_knowledge.path_icon = "icon_tech_ancestors_knowledge";
            Modern_knowledge.priority = false;
            Modern_knowledge.required_level = 80;
            Modern_knowledge.stats.bonus_born_level.value = 2f;
            Modern_knowledge.requirements = new List<string> { "Modern_heroes" };
            Localization.addLocalization("tech_Modern_knowledge", "Modern knowledge");
            AssetManager.culture_tech.add(Modern_knowledge);

            CultureTechAsset Modern_housing = new CultureTechAsset();
            Modern_housing.id = "Modern_housing";
            Modern_housing.path_icon = "icon_tech_housing_3";
            Modern_housing.priority = false;
            Modern_housing.required_level = 80;
		    Modern_housing.stats.housing.add(1f);
            Modern_housing.requirements = new List<string> { "Modern_knowledge" };
            Localization.addLocalization("tech_Modern_housing", "better housing");
            AssetManager.culture_tech.add(Modern_housing);

            CultureTechAsset Modern_defenses = new CultureTechAsset();
            Modern_defenses.id = "Modern_defenses";
            Modern_defenses.path_icon = "icon_tech_watch_tower_bonus";
            Modern_defenses.priority = false;
            Modern_defenses.required_level = 80;
		    Modern_defenses.stats.bonus_watch_towers.value = 2f;
            Modern_defenses.requirements = new List<string> { "Modern_housing" };
            Localization.addLocalization("tech_Modern_defenses", "defense tower");
            AssetManager.culture_tech.add(Modern_defenses);

            CultureTechAsset Modern_army = new CultureTechAsset();
            Modern_army.id = "Modern_army";
            Modern_army.path_icon = "army_training_3";
            Modern_army.priority = false;
            Modern_army.required_level = 80;
		    Modern_army.stats.bonus_max_army.add(0.1f);
            Modern_army.requirements = new List<string> { "Modern_defenses" };
            Localization.addLocalization("tech_Modern_army", "Modern army");
            AssetManager.culture_tech.add(Modern_army);

            CultureTechAsset Modern_strategy = new CultureTechAsset();
            Modern_strategy.id = "Modern_strategy";
            Modern_strategy.path_icon = "icon_tech_military_strategy";
            Modern_strategy.priority = false;
            Modern_strategy.required_level = 80;
		    Modern_strategy.stats.bonus_damage.add(0.1f);
            Modern_strategy.requirements = new List<string> { "Modern_army" };
            Localization.addLocalization("tech_Modern_strategy", "Modern strategy");
            AssetManager.culture_tech.add(Modern_strategy);

             CultureTechAsset Modern_defense = new CultureTechAsset();
            Modern_defense.id = "Modern_defense";
            Modern_defense.path_icon = "icon_tech_defense_strategy";
            Modern_defense.priority = false;
            Modern_defense.required_level = 80;
		    Modern_defense.stats.bonus_armor.add(0.1f);
            Modern_defense.requirements = new List<string> { "Modern_strategy" };
            Localization.addLocalization("tech_Modern_defense", "Modern defense");
            AssetManager.culture_tech.add(Modern_defense);

            CultureTechAsset Future = new CultureTechAsset();
            Future.id = "Future";
            Future.path_icon = "Future";
            Future.priority = false;
            Future.required_level = 90;
            Future.requirements = new List<string> { "Modern_defense" };
            Localization.addLocalization("tech_Future", "Future era");
            AssetManager.culture_tech.add(Future);

            CultureTechAsset Future_knowledge_gain = new CultureTechAsset();
            Future_knowledge_gain.id = "Future_knowledge_gain";
            Future_knowledge_gain.path_icon = "icon_tech_knowledge_gain3";
            Future_knowledge_gain.priority = false;
            Future_knowledge_gain.required_level = 90;
		    Future_knowledge_gain.stats.knowledge_gain.add(-0.3f);
            Future_knowledge_gain.requirements = new List<string> { "Future" };
            Localization.addLocalization("tech_Future_knowledge_gain", "Future knowledge gain");
            AssetManager.culture_tech.add(Future_knowledge_gain);

            CultureTechAsset Future_mining = new CultureTechAsset();
            Future_mining.id = "Future_mining";
            Future_mining.path_icon = "icon_tech_mining_efficiency";
            Future_mining.priority = false;
            Future_mining.required_level = 90;
		    Future_mining.stats.bonus_res_chance_mineral.add(0.2f);
		    Future_mining.stats.bonus_res_mineral_amount.add(1f);
            Future_mining.requirements = new List<string> { "Future_knowledge_gain" };
            Localization.addLocalization("tech_Future_mining", "Future mining");
            AssetManager.culture_tech.add(Future_mining);

            CultureTechAsset Future_axes = new CultureTechAsset();
            Future_axes.id = "Future_axes";
            Future_axes.path_icon = "icon_tech_sharp_axes";
            Future_axes.priority = false;
            Future_axes.required_level = 90;
		    Future_axes.stats.bonus_res_chance_wood.add(0.2f);
		    Future_axes.stats.bonus_res_wood_amount.add(1f);
            Future_axes.requirements = new List<string> { "Future_mining" };
            Localization.addLocalization("tech_Future_axes", "Future axes");
            AssetManager.culture_tech.add(Future_axes);

            CultureTechAsset Future_trading = new CultureTechAsset();
            Future_trading.id = "Future_trading";
            Future_trading.path_icon = "icon_tech_trading-_efficiency";
            Future_trading.priority = false;
            Future_trading.required_level = 90;
            Future_trading.stats.mod_trading_bonus.add(0.15f);
            Future_trading.requirements = new List<string> { "Future_axes" };
            Localization.addLocalization("tech_Future_trading", "Future trading");
            AssetManager.culture_tech.add(Future_trading);

            CultureTechAsset Future_storage = new CultureTechAsset();
            Future_storage.id = "Future_storage";
            Future_storage.path_icon = "icon_tech_city_storage_3";
            Future_storage.priority = false;
            Future_storage.required_level = 90;
            Future_storage.stats.max_city_items.value = 2f;
            Future_storage.requirements = new List<string> { "Future_trading" };
            Localization.addLocalization("tech_Future_storage", "Future storage");
            AssetManager.culture_tech.add(Future_storage);

            CultureTechAsset Future_armorsmith = new CultureTechAsset();
            Future_armorsmith.id = "Future_armorsmith";
            Future_armorsmith.path_icon = "icon_tech_armorsmith";
            Future_armorsmith.priority = false;
            Future_armorsmith.required_level = 90;
		    Future_armorsmith.stats.item_production_tries_armor.add(2f);
            Future_armorsmith.requirements = new List<string> { "Future_storage" };
            Localization.addLocalization("tech_Future_armorsmith", "Future armorsmith");
            AssetManager.culture_tech.add(Future_armorsmith);

            CultureTechAsset Future_weaponsmith = new CultureTechAsset();
            Future_weaponsmith.id = "Future_weaponsmith";
            Future_weaponsmith.path_icon = "icon_tech_weaponsmith";
            Future_weaponsmith.priority = false;
            Future_weaponsmith.required_level = 90;
		    Future_weaponsmith.stats.item_production_tries_weapons.add(2f);
            Future_weaponsmith.requirements = new List<string> { "Future_armorsmith" };
            Localization.addLocalization("tech_Future_weaponsmith", "Future weaponsmith");
            AssetManager.culture_tech.add(Future_weaponsmith);

            CultureTechAsset Future_heroes = new CultureTechAsset();
            Future_heroes.id = "Future_heroes";
            Future_heroes.path_icon = "icon_tech_heroes";
            Future_heroes.priority = false;
            Future_heroes.required_level = 90;
	     	Future_heroes.stats.bonus_max_unit_level.add(2f);
            Future_heroes.requirements = new List<string> { "Future_weaponsmith" };
            Localization.addLocalization("tech_Future_heroes", "heroes");
            AssetManager.culture_tech.add(Future_heroes);

            CultureTechAsset Future_knowledge = new CultureTechAsset();
            Future_knowledge.id = "Future_knowledge";
            Future_knowledge.path_icon = "icon_tech_ancestors_knowledge";
            Future_knowledge.priority = false;
            Future_knowledge.required_level = 90;
            Future_knowledge.stats.bonus_born_level.value = 2f;
            Future_knowledge.requirements = new List<string> { "Future_heroes" };
            Localization.addLocalization("tech_Future_knowledge", "Future knowledge");
            AssetManager.culture_tech.add(Future_knowledge);


            CultureTechAsset Future_housing = new CultureTechAsset();
            Future_housing.id = "Future_housing";
            Future_housing.path_icon = "icon_tech_housing_3";
            Future_housing.priority = false;
            Future_housing.required_level = 90;
		    Future_housing.stats.housing.add(1f);
            Future_housing.requirements = new List<string> { "Future_knowledge" };
            Localization.addLocalization("tech_Future_housing", "better housing");
            AssetManager.culture_tech.add(Future_housing);

            CultureTechAsset Future_defenses = new CultureTechAsset();
            Future_defenses.id = "Future_defenses";
            Future_defenses.path_icon = "icon_tech_watch_tower_bonus";
            Future_defenses.priority = false;
            Future_defenses.required_level = 90;
		    Future_defenses.stats.bonus_watch_towers.value = 2f;
            Future_defenses.requirements = new List<string> { "Future_housing" };
            Localization.addLocalization("tech_Future_defenses", "defense tower");
            AssetManager.culture_tech.add(Future_defenses);

            CultureTechAsset Future_army = new CultureTechAsset();
            Future_army.id = "Future_army";
            Future_army.path_icon = "army_training_3";
            Future_army.priority = false;
            Future_army.required_level = 90;
		    Future_army.stats.bonus_max_army.add(0.1f);
            Future_army.requirements = new List<string> { "Future_defenses" };
            Localization.addLocalization("tech_Future_army", "Future army");
            AssetManager.culture_tech.add(Future_army);

            CultureTechAsset Future_strategy = new CultureTechAsset();
            Future_strategy.id = "Future_strategy";
            Future_strategy.path_icon = "icon_tech_military_strategy";
            Future_strategy.priority = false;
            Future_strategy.required_level = 90;
		    Future_strategy.stats.bonus_damage.add(0.1f);
            Future_strategy.requirements = new List<string> { "Future_army" };
            Localization.addLocalization("tech_Future_strategy", "Future strategy");
            AssetManager.culture_tech.add(Future_strategy);

             CultureTechAsset Future_defense = new CultureTechAsset();
            Future_defense.id = "Future_defense";
            Future_defense.path_icon = "icon_tech_defense_strategy";
            Future_defense.priority = false;
            Future_defense.required_level = 90;
		    Future_defense.stats.bonus_armor.add(0.1f);
            Future_defense.requirements = new List<string> { "Future_strategy" };
            Localization.addLocalization("tech_Future_defense", "Future defense");
            AssetManager.culture_tech.add(Future_defense);





        }
        

        [HarmonyPatch(typeof(Culture), "getCurrentLevel")]
public static class Culture_GetCurrentLevel_Patch
{
    static void Postfix(ref int __result)
    {
        int offset = 10;
        __result += offset;
    }
}

        public static void haveRequiredTechFor_Postfix(Culture __instance, ref bool __result, CultureTechAsset pTech){
            if (pTech.requirements == null) return;
                for (int i = 0; i < pTech.requirements.Count; ++i) {
                    string item = pTech.requirements[i];
                    if (!__instance.data.list_tech_ids.Contains(item[0] == '!' ? item.Substring(1) : item)) {
                        if (item[0] != '!') {
                            __result = false;
                            return;
                        }
                    } else {
                        if (item[0] == '!') {
                            __result = false;
                            return;
                        }
                    }
                }
        __result = true;

        }

    }
}
