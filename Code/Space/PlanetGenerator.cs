using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using NCMS;
using NCMS.Utils;
using UnityEngine;
using ReflectionUtility;
using HarmonyLib;
using System.Reflection;
using Newtonsoft.Json;
using System.Collections;
using System.IO.Compression;
using ai;
using UnityEngine.Tilemaps;

namespace M2
{
    class PlanetGenerator : MonoBehaviour
    {

		public static int mapSizeX = 13;
		public static int mapSizeY = 13;
        private MapGenTemplateLibrary mapGenTemplateLibrary; 

		public void Awake()
		{

		}

		public static bool setMapSize_Prefix(ref int pWidth, ref int pHeight)
		{

				pWidth = mapSizeX;
				pHeight = mapSizeY;

			return true;
		}

        private static void ClearBiomes()
        {
            BiomeLibrary.pool_biomes.Clear();
        }

        private static void LogAndClearBiomes()
        {

            Debug.Log("Current Biome Pool:");
            foreach (var biome in BiomeLibrary.pool_biomes)
            {
                Debug.Log(biome.ToString()); 
            }

            ClearBiomes();

            Debug.Log("Biome Pool After Clearing:");
            if (BiomeLibrary.pool_biomes.Count == 0)
            {
                Debug.Log("Biome pool is now empty.");
            }
            else
            {
                foreach (var biome in BiomeLibrary.pool_biomes)
                {
                    Debug.Log(biome.ToString()); 
                }
            }
        }

        public static void ChoosePlanetBiomes(string type, bool hasFauna)
        {


         EffectAsset evilspawn = new EffectAsset
            {
                id = "evilspawn",
                use_basic_prefab = true,
                sprite_path = "effects/fx_teleport_red_t",
                draw_light_area = true,
                show_on_mini_map = false,
                limit = 80,
                sorting_layer_id = "EffectsTop"
            };
            evilspawn.spawn_action = (effect, tile, param1, param2, floatParam) =>
            {
                if (effect != null)
                {
                    SpriteRenderer renderer = effect.GetComponent<SpriteRenderer>();
                    if (renderer != null)
                    {
                        renderer.sortingLayerName = evilspawn.sorting_layer_id;
                    }
                }
                return effect;
            };
            AssetManager.effects_library.add(evilspawn);



			Harmony harmony = new Harmony("tuxxego.worldbox.spaceindabox");

			MethodInfo original = AccessTools.Method(typeof(MapBox), "setMapSize");
			MethodInfo patch = AccessTools.Method(typeof(PlanetGenerator), "setMapSize_Prefix");
			harmony.Patch(original, new HarmonyMethod(patch));
			Debug.Log("Pre patch: MapBox.setMapSize");

				Config.current_map_template = "ballsass";

            LogAndClearBiomes();

            switch (type.ToLower())
            {
                case "desert world":
                    Debug.Log("Desert World biome selected.");
				Config.current_map_template = "boring_plains";

	BiomeAsset tartarus = new BiomeAsset();
            tartarus.id = "biome_tartarus";
			tartarus.tile_low = "tartarus_low";
			tartarus.tile_high = "tartarus_high";
			tartarus.force_unit_skin_set = "desert";
			tartarus.grow_strength = 20;
			tartarus.spread_biome = true;
			tartarus.generator_pool_amount = 80;
            tartarus.grow_vegetation_auto = true;
			tartarus.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			tartarus.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			tartarus.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
			tartarus.addTree("tartarus_desert_bones_big", 1);
			tartarus.addTree("tartarus_tar_bones_big", 1);
			tartarus.addTree("tartarus_vent", 1);
            tartarus.addPlant("tartarus_desert_bones", 2);
            tartarus.addPlant("tartarus_tar_bones", 1);
			tartarus.addPlant("tartarus_ruins", 1);
            tartarus.addUnit("scandid", 4);
            tartarus.addUnit("Duneworm", 1);
			tartarus.addMineral(SB.mineral_bones, 20);
			tartarus.addMineral(SB.mineral_stone, 20);
			tartarus.addMineral(SB.mineral_metals, 5);
            AssetManager.biome_library.add(tartarus);
            AssetManager.biome_library.addBiomeToPool(tartarus);

            TopTileType tartarus_low = AssetManager.topTiles.clone("tartarus_low", ST.infernal_low);
            tartarus_low.color = Toolbox.makeColor("#272727", -1f);
            tartarus_low.setBiome("biome_tartarus");
			tartarus_low.rank_type = TileRank.Low;
            tartarus_low.setDrawLayer(TileZIndexes.infernal_low, null);
            tartarus_low.food_resource = SR.desert_berries;
            tartarus_low.liquid = true;
            tartarus_low.ground = false;
            tartarus_low.ocean = true;
		    tartarus_low.stepActionChance = 1f;
            tartarus_low.hold_lava = false;
            tartarus_low.can_be_frozen = true;
            tartarus_low.burnable = false;
            tartarus_low.walkMod = 1f;
            tartarus_low.layerType = TileLayerType.Ground;
			tartarus_low.biome_asset = tartarus;
            AssetManager.topTiles.add(tartarus_low);
            AssetManager.topTiles.loadSpritesForTile(tartarus_low);
            AssetManager.topTiles.add(AssetManager.topTiles.get("tartarus_low"));
            MapBox.instance.tilemap.layers[tartarus_low.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

            TopTileType tartarus_high = AssetManager.topTiles.clone("tartarus_high", ST.infernal_high);
            tartarus_high.color = Toolbox.makeColor("#d57d4f", -1f);
            tartarus_high.setBiome("biome_tartarus");
			tartarus_high.rank_type = TileRank.High;
            tartarus_high.setDrawLayer(TileZIndexes.infernal_high);
            tartarus_high.stepActionChance = 1f;
            tartarus_high.food_resource = SR.desert_berries;
            tartarus_high.liquid = false;
            tartarus_high.hold_lava = false;
            tartarus_high.can_be_frozen = true;
            tartarus_high.burnable = false;
            tartarus_high.layerType = TileLayerType.Ground;
			tartarus_high.biome_asset = tartarus;
            AssetManager.topTiles.add(tartarus_high);
            AssetManager.topTiles.loadSpritesForTile(tartarus_high);
            AssetManager.topTiles.add(AssetManager.topTiles.get("tartarus_high"));
            MapBox.instance.tilemap.layers[tartarus_high.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

			break;

    case "icy":
            SetRandomMapTemplate();

            BiomeAsset IcePlanet = new BiomeAsset();
            IcePlanet.id = "biome_IcePlanet";
			      IcePlanet.tile_low = "permafrost_low";
			      IcePlanet.tile_high = "permafrost_high";
			      IcePlanet.grow_strength = 10;
			      IcePlanet.spread_biome = true;
			      IcePlanet.generator_pool_amount = 80;
            IcePlanet.grow_vegetation_auto = true;
			      IcePlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      IcePlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        IcePlanet.addUnit(SA.frog, 1);
		        IcePlanet.addUnit(SA.sheep, 1);
				  IcePlanet.addTree("Ruins1", 30);
		        IcePlanet.addMineral(SB.mineral_stone, 5);
		        IcePlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(IcePlanet);
            AssetManager.biome_library.addBiomeToPool(IcePlanet);

            BiomeAsset IcePlanet1 = new BiomeAsset();
            IcePlanet1.id = "biome_IcePlanet1";
			      IcePlanet1.tile_low = "frozen_low";
			      IcePlanet1.tile_high = "frozen_high";
			      IcePlanet1.grow_strength = 10;
			      IcePlanet1.spread_biome = true;
			      IcePlanet1.generator_pool_amount = 80;
            IcePlanet1.grow_vegetation_auto = true;
			      IcePlanet1.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      IcePlanet1.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        IcePlanet1.addUnit(SA.frog, 1);
		        IcePlanet1.addUnit(SA.sheep, 1);
		        IcePlanet1.addMineral(SB.mineral_stone, 5);
				  IcePlanet1.addTree("Ruins1", 30);
		        IcePlanet1.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(IcePlanet1);
            AssetManager.biome_library.addBiomeToPool(IcePlanet1);
break;			

    case "oceanic":

				Config.current_map_template = "empty";
break;
    case "mechanical world":
				Config.current_map_template = "boring_plains";

	            BiomeAsset RobotPlanet = new BiomeAsset();
            RobotPlanet.id = "biome_RobotPlanet";
			      RobotPlanet.tile_low = "cybertile_low";
			      RobotPlanet.tile_high = "cybertile_high";
			      RobotPlanet.grow_strength = 10;
			      RobotPlanet.spread_biome = true;
			      RobotPlanet.generator_pool_amount = 80;
            RobotPlanet.grow_vegetation_auto = true;
			      RobotPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      RobotPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      RobotPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        RobotPlanet.addUnit(SA.frog, 1);
		        RobotPlanet.addUnit(SA.sheep, 1);
		        RobotPlanet.addMineral(SB.mineral_stone, 5);
		        RobotPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(RobotPlanet);
            AssetManager.biome_library.addBiomeToPool(RobotPlanet);
			break;			

    case "lava world":
				Config.current_map_template = "boring_plains";

            BiomeAsset LavaPlanet = new BiomeAsset();
            LavaPlanet.id = "biome_LavaPlanet";
			      LavaPlanet.tile_low = "infernal_low";
			      LavaPlanet.tile_high = "infernal_high";
			      LavaPlanet.grow_strength = 10;
			      LavaPlanet.spread_biome = true;
			      LavaPlanet.generator_pool_amount = 80;
            LavaPlanet.grow_vegetation_auto = true;
			      LavaPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      LavaPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      LavaPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        LavaPlanet.addUnit(Creatures.Terlanius, 8);
		        LavaPlanet.addMineral(SB.mineral_stone, 5);
				  LavaPlanet.addTree("Ruins1", 30);
		        LavaPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(LavaPlanet);
            AssetManager.biome_library.addBiomeToPool(LavaPlanet);

			break;
    case "corrupted world":
				Config.current_map_template = "boring_plains";
           // AssetManager.biome_library.addBiomeToPool(Creatures.Glitch);
			//	Creatures.addGlitchToPool();
            BiomeAsset CorruptedPlanet = new BiomeAsset();
            CorruptedPlanet.id = "biome_CorruptedPlanet";
			      CorruptedPlanet.tile_low = "corruption_low";
			      CorruptedPlanet.tile_high = "corruption_high";
			      CorruptedPlanet.grow_strength = 10;
			      CorruptedPlanet.spread_biome = true;
			      CorruptedPlanet.generator_pool_amount = 80;
            CorruptedPlanet.grow_vegetation_auto = true;
			      CorruptedPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      CorruptedPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      CorruptedPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        CorruptedPlanet.addMineral(SB.mineral_stone, 5);
		        CorruptedPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(CorruptedPlanet);
           // AssetManager.biome_library.addBiomeToPool(CorruptedPlanet);

			BiomeAsset Glitch = new BiomeAsset();
            Glitch.id = "biome_Glitch";
			Glitch.tile_low = "Glitch_low";
			Glitch.tile_high = "Glitch_high";
			Glitch.force_unit_skin_set = "infernal";
			Glitch.grow_strength = 20;
			Glitch.spread_biome = true;
			Glitch.generator_pool_amount = 80;
            Glitch.grow_vegetation_auto = true;
			Glitch.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			Glitch.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			Glitch.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
			Glitch.addTree("Glitch_tree", 2);
			Glitch.addPlant("Glitch_plant", 4);
			Glitch.addTree("Glitch_tree_big", 1);
            Glitch.addTree("Glitch_candle", 2);
			Glitch.addPlant("Glitch_tomb", 4);
            Glitch.addUnit("glitchspectre", 2);
            Glitch.addUnit("glitchdrake", 1);
            Glitch.addUnit("glitchtarantula", 2);
			Glitch.addMineral(SB.mineral_bones, 20);
			Glitch.addMineral(SB.mineral_adamantine, 20);
            AssetManager.biome_library.add(Glitch);
            AssetManager.biome_library.addBiomeToPool(Glitch);

            TopTileType Glitch_low = AssetManager.topTiles.clone("Glitch_low", ST.infernal_low);
            Glitch_low.color = Toolbox.makeColor("#898672", -1f);
            Glitch_low.setBiome("biome_Glitch");
			Glitch_low.rank_type = TileRank.Low;
            Glitch_low.setDrawLayer(TileZIndexes.infernal_low, null);
            Glitch_low.food_resource = SR.evil_beets;
            Glitch_low.liquid = false;
            Glitch_low.ground = true;
            Glitch_low.unitDeathAction = new WorldAction(spawnGlitchCreature);
		    Glitch_low.stepActionChance = 1f;
            Glitch_low.hold_lava = false;
            Glitch_low.can_be_frozen = true;
            Glitch_low.burnable = false;
            Glitch_low.walkMod = 1f;
            Glitch_low.layerType = TileLayerType.Ground;
			Glitch_low.biome_asset = Glitch;
            AssetManager.topTiles.add(Glitch_low);
            AssetManager.topTiles.loadSpritesForTile(Glitch_low);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Glitch_low"));
            MapBox.instance.tilemap.layers[Glitch_low.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

            TopTileType Glitch_high = AssetManager.topTiles.clone("Glitch_high", ST.infernal_high);
            Glitch_high.color = Toolbox.makeColor("#343434", -1f);
            Glitch_high.setBiome("biome_Glitch");
			Glitch_high.rank_type = TileRank.High;
            Glitch_high.setDrawLayer(TileZIndexes.infernal_high);
            Glitch_high.unitDeathAction = new WorldAction(spawnGlitchCreature);
            Glitch_high.stepActionChance = 1f;
            Glitch_high.food_resource = SR.evil_beets;
            Glitch_high.liquid = false;
            Glitch_high.hold_lava = false;
            Glitch_high.can_be_frozen = true;
            Glitch_high.burnable = false;
            Glitch_high.layerType = TileLayerType.Ground;
			Glitch_high.biome_asset = Glitch;
            AssetManager.topTiles.add(Glitch_high);
            AssetManager.topTiles.loadSpritesForTile(Glitch_high);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Glitch_high"));
            MapBox.instance.tilemap.layers[Glitch_high.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;
			
			break;
    case "chess world":
				Config.current_map_template = "boring_plains";


			BiomeAsset Chess = new BiomeAsset();
            Chess.id = "biome_Chess";
			Chess.tile_low = "Chess_low";
			Chess.tile_high = "Chess_high";
			Chess.force_unit_skin_set = "infernal";
			Chess.grow_strength = 20;
			Chess.spread_biome = true;
			Chess.generator_pool_amount = 80;
            Chess.grow_vegetation_auto = true;
			Chess.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			Chess.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			Chess.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
			Chess.addTree("Chess_tree", 20);
			Chess.addTree("Chess_tree_2", 20);
			Chess.addTree("Chess_tree_3", 20);
			/*
			Chess.addTree("Chess_tree", 2);
			Chess.addPlant("Chess_plant", 4);
			Chess.addTree("Chess_tree_big", 1);
            Chess.addTree("Chess_candle", 2);
			Chess.addPlant("Chess_tomb", 4);
            Chess.addUnit("glitchspectre", 2);
            Chess.addUnit("glitchdrake", 1);
            Chess.addUnit("glitchtarantula", 2);
			Chess.addMineral(SB.mineral_bones, 20);
			Chess.addMineral(SB.mineral_adamantine, 20);
            AssetManager.biome_library.add(Chess);
			*/
            AssetManager.biome_library.addBiomeToPool(Chess);
			
            TopTileType Chess_low = AssetManager.topTiles.clone("Chess_low", ST.infernal_low);
            Chess_low.color = Toolbox.makeColor("#898672", -1f);
            Chess_low.setBiome("biome_Chess");
			Chess_low.rank_type = TileRank.Low;
            Chess_low.setDrawLayer(TileZIndexes.infernal_low, null);
            Chess_low.food_resource = SR.evil_beets;
            Chess_low.liquid = false;
            Chess_low.ground = true;
          //  Chess_low.unitDeathAction = new WorldAction(spawnChessCreature);
		    Chess_low.stepActionChance = 1f;
            Chess_low.hold_lava = false;
            Chess_low.can_be_frozen = true;
            Chess_low.burnable = false;
            Chess_low.walkMod = 1f;
            Chess_low.layerType = TileLayerType.Ground;
			Chess_low.biome_asset = Chess;
            AssetManager.topTiles.add(Chess_low);
            AssetManager.topTiles.loadSpritesForTile(Chess_low);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Chess_low"));
            MapBox.instance.tilemap.layers[Chess_low.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;

            TopTileType Chess_high = AssetManager.topTiles.clone("Chess_high", ST.infernal_high);
            Chess_high.color = Toolbox.makeColor("#808080", -1f);
            Chess_high.setBiome("biome_Chess");
			Chess_high.rank_type = TileRank.High;
            Chess_high.setDrawLayer(TileZIndexes.infernal_high);
           // Chess_high.unitDeathAction = new WorldAction(spawnChessCreature);
            Chess_high.stepActionChance = 1f;
            Chess_high.food_resource = SR.evil_beets;
            Chess_high.liquid = false;
            Chess_high.hold_lava = false;
            Chess_high.can_be_frozen = true;
            Chess_high.burnable = false;
            Chess_high.layerType = TileLayerType.Ground;
			Chess_high.biome_asset = Chess;
            AssetManager.topTiles.add(Chess_high);
            AssetManager.topTiles.loadSpritesForTile(Chess_high);
            AssetManager.topTiles.add(AssetManager.topTiles.get("Chess_high"));
            MapBox.instance.tilemap.layers[Chess_high.render_z].tilemap.GetComponent<TilemapRenderer>().mode = TilemapRenderer.Mode.Individual;
			
			break;
    case "lemon world":

            SetRandomMapTemplate();

            BiomeAsset LemonPlanet = new BiomeAsset();
            LemonPlanet.id = "biome_LemonPlanet";
			      LemonPlanet.tile_low = "lemon_low";
			      LemonPlanet.tile_high = "lemon_high";
			      LemonPlanet.grow_strength = 10;
			      LemonPlanet.spread_biome = true;
			      LemonPlanet.generator_pool_amount = 80;
            LemonPlanet.grow_vegetation_auto = true;
			      LemonPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      LemonPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      LemonPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        LemonPlanet.addUnit(Creatures.Terlanius, 1);
		        LemonPlanet.addMineral(SB.mineral_stone, 5);
		        LemonPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(LemonPlanet);
            AssetManager.biome_library.addBiomeToPool(LemonPlanet);

			break;
    case "mushroom world":

            SetRandomMapTemplate();

            BiomeAsset MushroomPlanet = new BiomeAsset();
            MushroomPlanet.id = "biome_MushroomPlanet";
			      MushroomPlanet.tile_low = "mushroom_low";
			      MushroomPlanet.tile_high = "mushroom_high";
			      MushroomPlanet.grow_strength = 10;
			      MushroomPlanet.spread_biome = true;
			      MushroomPlanet.generator_pool_amount = 80;
            MushroomPlanet.grow_vegetation_auto = true;
			      MushroomPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      MushroomPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      MushroomPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        MushroomPlanet.addUnit(Creatures.Terlanius, 1);
		        MushroomPlanet.addMineral(SB.mineral_stone, 5);
		        MushroomPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(MushroomPlanet);
            AssetManager.biome_library.addBiomeToPool(MushroomPlanet);

			break;
    case "wasteland world":
				Config.current_map_template = "boring_plains";

            BiomeAsset WastelandPlanet = new BiomeAsset();
            WastelandPlanet.id = "biome_WastelandPlanet";
			      WastelandPlanet.tile_low = "wasteland_low";
			      WastelandPlanet.tile_high = "wasteland_high";
			      WastelandPlanet.grow_strength = 10;
			      WastelandPlanet.spread_biome = true;
			      WastelandPlanet.generator_pool_amount = 80;
            WastelandPlanet.grow_vegetation_auto = true;
			      WastelandPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      WastelandPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      WastelandPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        WastelandPlanet.addUnit(Creatures.Terlanius, 1);
		        WastelandPlanet.addMineral(SB.mineral_stone, 5);
		        WastelandPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(WastelandPlanet);
            AssetManager.biome_library.addBiomeToPool(WastelandPlanet);

			break;
    case "crystal world":

            SetRandomMapTemplate();

            BiomeAsset CrystalPlanet = new BiomeAsset();
            CrystalPlanet.id = "biome_CrystalPlanet";
			      CrystalPlanet.tile_low = "crystal_low";
			      CrystalPlanet.tile_high = "crystal_high";
			      CrystalPlanet.grow_strength = 10;
			      CrystalPlanet.spread_biome = true;
			      CrystalPlanet.generator_pool_amount = 80;
            CrystalPlanet.grow_vegetation_auto = true;
			      CrystalPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      CrystalPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      CrystalPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        CrystalPlanet.addUnit(SA.frog, 1);
		        CrystalPlanet.addUnit(SA.sheep, 1);
		        CrystalPlanet.addMineral(SB.mineral_stone, 5);
		        CrystalPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(CrystalPlanet);
            AssetManager.biome_library.addBiomeToPool(CrystalPlanet);
break;			

    case "swamp world":

            SetRandomMapTemplate();

            BiomeAsset SwampPlanet = new BiomeAsset();
            SwampPlanet.id = "biome_SwampPlanet";
			      SwampPlanet.tile_low = "swamp_low";
			      SwampPlanet.tile_high = "swamp_high";
			      SwampPlanet.grow_strength = 10;
			      SwampPlanet.spread_biome = true;
			      SwampPlanet.generator_pool_amount = 80;
            SwampPlanet.grow_vegetation_auto = true;
			      SwampPlanet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      SwampPlanet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      SwampPlanet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        SwampPlanet.addUnit(SA.frog, 1);
		        SwampPlanet.addUnit(SA.sheep, 1);
		        SwampPlanet.addMineral(SB.mineral_stone, 5);
		        SwampPlanet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(SwampPlanet);
            AssetManager.biome_library.addBiomeToPool(SwampPlanet);
break;			

    case "jungle world":

            BiomeAsset Jungle1Planet = new BiomeAsset();
            Jungle1Planet.id = "biome_Jungle1Planet";
			      Jungle1Planet.tile_low = "jungle_low";
			      Jungle1Planet.tile_high = "jungle_high";
			      Jungle1Planet.grow_strength = 10;
			      Jungle1Planet.spread_biome = true;
			      Jungle1Planet.generator_pool_amount = 20;
            Jungle1Planet.grow_vegetation_auto = true;
			      Jungle1Planet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Jungle1Planet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Jungle1Planet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Jungle1Planet.addUnit(SA.frog, 1);
		        Jungle1Planet.addUnit(SA.sheep, 1);
		        Jungle1Planet.addUnit(Creatures.Terlanius, 1);
		        Jungle1Planet.addMineral(SB.mineral_stone, 5);
		        Jungle1Planet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(Jungle1Planet);
            AssetManager.biome_library.addBiomeToPool(Jungle1Planet);

            BiomeAsset Jungle2Planet = new BiomeAsset();
            Jungle2Planet.id = "biome_Jungle2Planet";
			      Jungle2Planet.tile_low = "enchanted_low";
			      Jungle2Planet.tile_high = "enchanted_high";
			      Jungle2Planet.grow_strength = 10;
			      Jungle2Planet.spread_biome = true;
			      Jungle2Planet.generator_pool_amount = 80;
            Jungle2Planet.grow_vegetation_auto = true;
			      Jungle2Planet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Jungle2Planet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Jungle2Planet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Jungle2Planet.addUnit(SA.frog, 1);
		        Jungle2Planet.addUnit(SA.sheep, 1);
		        Jungle2Planet.addUnit(Creatures.Terlanius, 1);
		        Jungle2Planet.addMineral(SB.mineral_stone, 5);
		        Jungle2Planet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(Jungle2Planet);
            AssetManager.biome_library.addBiomeToPool(Jungle2Planet);

            BiomeAsset Jungle3Planet = new BiomeAsset();
            Jungle3Planet.id = "biome_Jungle3Planet";
			      Jungle3Planet.tile_low = "swamp_low";
			      Jungle3Planet.tile_high = "swamp_high";
			      Jungle3Planet.grow_strength = 10;
			      Jungle3Planet.spread_biome = true;
			      Jungle3Planet.generator_pool_amount = 80;
            Jungle3Planet.grow_vegetation_auto = true;
			      Jungle3Planet.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Jungle3Planet.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Jungle3Planet.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Jungle3Planet.addUnit(SA.frog, 1);
		        Jungle3Planet.addUnit(SA.sheep, 1);
		        Jungle3Planet.addUnit(Creatures.Terlanius, 1);
		        Jungle3Planet.addMineral(SB.mineral_stone, 5);
		        Jungle3Planet.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(Jungle3Planet);
            AssetManager.biome_library.addBiomeToPool(Jungle3Planet);

break;			

    case "gas giant":

            BiomeAsset GasGiant = new BiomeAsset();
            GasGiant.id = "biome_GasGiant";
			      GasGiant.tile_low = "GasGiant_low";
			      GasGiant.tile_high = "GasGiant_high";
			      GasGiant.grow_strength = 10;
			      GasGiant.spread_biome = true;
			      GasGiant.generator_pool_amount = 80;
            GasGiant.grow_vegetation_auto = true;
			      GasGiant.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      GasGiant.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      GasGiant.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        GasGiant.addUnit(SA.frog, 1);
		        GasGiant.addUnit(SA.sheep, 1);
		        GasGiant.addMineral(SB.mineral_stone, 5);
		        GasGiant.addMineral(SB.mineral_metals, 3);
            AssetManager.biome_library.add(GasGiant);
            AssetManager.biome_library.addBiomeToPool(GasGiant);

            TopTileType GasGiant_low = AssetManager.topTiles.clone("GasGiant_low", ST.mushroom_low);
            GasGiant_low.color = Toolbox.makeColor("#3b3aad", -1f);
            GasGiant_low.setBiome("biome_GasGiant");
		        GasGiant_low.force_unit_skin_set = "enchanted";
			      GasGiant_low.rank_type = TileRank.Low;
            GasGiant_low.setDrawLayer(TileZIndexes.mushroom_low, null);

            GasGiant_low.stepActionChance = 1437f;
            GasGiant_low.fireChance = 0.02f;
            GasGiant_low.food_resource = SR.mushrooms;
				    GasGiant_low.biome_asset = GasGiant;
            AssetManager.topTiles.add(GasGiant_low);
            AssetManager.topTiles.loadSpritesForTile(GasGiant_low);
            TopTileType GasGiant_high = AssetManager.topTiles.clone("GasGiant_high", ST.mushroom_high);
            GasGiant_high.color = Toolbox.makeColor("#000c8d", -1f);
            GasGiant_high.setBiome("biome_GasGiant");
			      GasGiant_high.rank_type = TileRank.High;
		        GasGiant_high.force_unit_skin_set = "enchanted";
            GasGiant_high.setDrawLayer(TileZIndexes.mushroom_high, null);

            GasGiant_high.stepActionChance = 1437f;
            GasGiant_high.fireChance = 0.02f;
            GasGiant_high.food_resource = SR.mushrooms;
				    GasGiant_high.biome_asset = GasGiant;
            AssetManager.topTiles.add(GasGiant_high);
            AssetManager.topTiles.loadSpritesForTile(GasGiant_high);

break;			

                default:
                    Debug.Log("Space biome selected.");

            BiomeAsset Space = new BiomeAsset();
            Space.id = "biome_Space";
			      Space.tile_low = "Space_low";
			      Space.tile_high = "Space_high";
			      Space.grow_strength = 10;
			      Space.spread_biome = true;
			      Space.generator_pool_amount = 80;
			      Space.force_unit_skin_set = "mushroom";
            Space.grow_vegetation_auto = true;
			      Space.grow_type_selector_minerals = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomMineral);
			      Space.grow_type_selector_trees = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomTrees);
			      Space.grow_type_selector_plants = new GrowTypeSelector(TileActionLibrary.getGrowTypeRandomPlants);
		        Space.addUnit(SA.frog, 1);
		        Space.addUnit(SA.sheep, 1);
		        Space.addMineral(SB.mineral_stone, 5);
		        Space.addMineral(SB.mineral_metals, 3);
		        Space.addTree("Space_tree", 1);
		        Space.addPlant("Space", 1);
            AssetManager.biome_library.add(Space);
            AssetManager.biome_library.addBiomeToPool(Space);

            TopTileType Space_low = AssetManager.topTiles.clone("Space_low", ST.mushroom_low);
            Space_low.color = Toolbox.makeColor("#3b3aad", -1f);
            Space_low.setBiome("biome_Space");
		        Space_low.force_unit_skin_set = "enchanted";
			      Space_low.rank_type = TileRank.Low;
            Space_low.setDrawLayer(TileZIndexes.mushroom_low, null);

            Space_low.stepActionChance = 1437f;
            Space_low.fireChance = 0.02f;
            Space_low.food_resource = SR.mushrooms;
				    Space_low.biome_asset = Space;
            AssetManager.topTiles.add(Space_low);
            AssetManager.topTiles.loadSpritesForTile(Space_low);
            TopTileType Space_high = AssetManager.topTiles.clone("Space_high", ST.mushroom_high);
            Space_high.color = Toolbox.makeColor("#000c8d", -1f);
            Space_high.setBiome("biome_Space");
			      Space_high.rank_type = TileRank.High;
		        Space_high.force_unit_skin_set = "enchanted";
            Space_high.setDrawLayer(TileZIndexes.mushroom_high, null);

            Space_high.stepActionChance = 1437f;
            Space_high.fireChance = 0.02f;
            Space_high.food_resource = SR.mushrooms;
				    Space_high.biome_asset = Space;
            AssetManager.topTiles.add(Space_high);
            AssetManager.topTiles.loadSpritesForTile(Space_high);

                    break;
            }
        }

        public static bool spawnGlitchCreature(BaseSimObject pTarget, WorldTile pTile = null)
        {
            Actor a = pTarget.a;
            if (!pTarget.isActor())
            {
                return false;
            }

            if (!a.asset.canTurnIntoTumorMonster)
            {
                return false;
            }

            string newUnitID;
            if (a.asset.has_soul)
            {
                newUnitID = "glitchspectre";
            }
            else if (a.asset.animal)
            {
                newUnitID = "glitchtarantula";
            }
            else
            {
                newUnitID = "glitchspectre";
            }

            Actor actor = World.world.units.createNewUnit(newUnitID, pTile);
            actor.removeTrait("blessed");
            ActorTool.copyUnitToOtherUnit(pTarget.a, actor);
            EffectsLibrary.spawnAt("evilspawn", actor.currentTile.posV3, 0.1f);
            ActionLibrary.removeUnit(a);

            return true;
        }

     public static void SetRandomMapTemplate()
        {

            string[] options = { "boring_plains", "ballsass" };

            int randomIndex = UnityEngine.Random.Range(0, options.Length);

            Config.current_map_template = options[randomIndex];

            Debug.Log($"Current map template set to: {Config.current_map_template}");
        }
    }
}
