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

namespace ModernBox
{
    class Kaiju
    {
        public static void init(){
          create_Kaijus();
        }

          public static void create_Kaijus(){



EffectAsset Atomboom = new EffectAsset();
Atomboom.id = "Atomboom";
Atomboom.sound_launch = "event:/SFX/EXPLOSIONS/ExplosionAntimatterBomb";
Atomboom.use_basic_prefab = true;
Atomboom.sorting_layer_id = "EffectsTop";
Atomboom.sprite_path = "effects/Atomboom";
Atomboom.draw_light_area = true;
AssetManager.effects_library.add(Atomboom);


EffectAsset AtomBeam_trail = new EffectAsset();
AtomBeam_trail.id = "AtomBeam_trail";
AtomBeam_trail.use_basic_prefab = true;
AtomBeam_trail.sorting_layer_id = "EffectsTop";
AtomBeam_trail.sprite_path = "effects/AtomBeam_trail_t";
AtomBeam_trail.draw_light_area = true;
AtomBeam_trail.show_on_mini_map = true;
AtomBeam_trail.limit = 15;
AssetManager.effects_library.add(AtomBeam_trail);


var atombeamterra = AssetManager.terraform.clone("atombeamterra", "bomb");
		atombeamterra.damage = 500;
		atombeamterra.explode_strength = 1;
		atombeamterra.transform_to_wasteland = true;
		atombeamterra.applies_to_high_flyers = true;
		atombeamterra.shake = true;
        AssetManager.terraform.add(atombeamterra);



            	ProjectileAsset AtomBeam = new ProjectileAsset();
            AtomBeam.id = "AtomBeam";
            AtomBeam.speed = 60f;
			AtomBeam.texture = "AtomBeam";
			AtomBeam.trail_effect_enabled = true;
            AtomBeam.trail_effect_id = "AtomBeam_trail";
            AtomBeam.trail_effect_scale = 0.25f;
			AtomBeam.trail_effect_timer = 0.1f;
			AtomBeam.texture_shadow = "shadows/projectiles/shadow_ball";
			AtomBeam.terraform_option = "atombeamterra";
			AtomBeam.draw_light_area = true;
			AtomBeam.terraform_range = 10;
			AtomBeam.sound_launch = "event:/SFX/WEAPONS/WeaponFireballStart";
			AtomBeam.sound_impact = "event:/SFX/WEAPONS/WeaponFireballLand";
			AtomBeam.end_effect = "Atomboom";
			AtomBeam.scale_start = 0.4f;
			AtomBeam.scale_target = 0.4f;
			AtomBeam.look_at_target = true;
          AtomBeam.can_be_left_on_ground = false;
          AtomBeam.can_be_blocked = false;
		  AtomBeam.world_actions = (AttackAction)Delegate.Combine(AtomBeam.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(AtomBeam);



var Godzilla_Boss = AssetManager.kingdoms.clone("Godzilla_Boss", "$TEMPLATE_MOB$");
Godzilla_Boss.concept = false;
Godzilla_Boss.id = "Godzilla_Boss";
Godzilla_Boss.default_kingdom_color = new ColorAsset("#679ead");
Godzilla_Boss.mobs = true;
Godzilla_Boss.always_attack_each_other = true;
Godzilla_Boss.force_look_all_chunks = true;
Godzilla_Boss.units_always_aggressive = true;
Godzilla_Boss.setIcon("ui/icons/Godzilla");
Godzilla_Boss.addTag("sliceable");
Godzilla_Boss.addFriendlyTag("nature_creature");
Godzilla_Boss.addEnemyTag("civ");
Godzilla_Boss.addFriendlyTag("wild_kaiju");
Godzilla_Boss.addFriendlyTag("crocodile");
Godzilla_Boss.addFriendlyTag("civ_crocodile");
AssetManager.kingdoms.add(Godzilla_Boss);
World.world.kingdoms_wild.newWildKingdom(Godzilla_Boss);

var Godzilla_wild = AssetManager.kingdoms.clone("Godzilla_wild", "$TEMPLATE_ANIMAL$");
Godzilla_wild.concept = false;
Godzilla_wild.id = "Godzilla_wild";
Godzilla_wild.default_kingdom_color = new ColorAsset("#679ead");
Godzilla_wild.setIcon("ui/icons/Godzilla");
Godzilla_wild.addTag("sliceable");
Godzilla_wild.addTag("nature_creature");
Godzilla_wild.addFriendlyTag("nature_creature");
Godzilla_wild.addTag("neutral_animals");
Godzilla_wild.addTag("neutral");
Godzilla_wild.addTag("wild_kaiju");
Godzilla_wild.addFriendlyTag("crocodile");
Godzilla_wild.addFriendlyTag("civ_crocodile");
AssetManager.kingdoms.add(Godzilla_wild);
World.world.kingdoms_wild.newWildKingdom(Godzilla_wild);





          var Godzilla = AssetManager.actor_library.clone("Godzilla", "$mob$");
          Godzilla.is_humanoid = false;
	      Godzilla.civ = false;
          Godzilla.name_locale = "Godzilla";
          Godzilla.animation_speed_based_on_walk_speed = false;
Godzilla.has_avatar_prefab = false;
Godzilla.get_override_avatar_frames = (Actor pActor) => new Sprite[] { SpriteTextureLoader.getSprite("actors/Avatars/godzilla_avatar") };
Godzilla.has_override_avatar_frames = true;
Godzilla.inspect_avatar_scale = 1f;
Godzilla.inspect_avatar_offset_y = 6f;
          Godzilla.shadow_texture = "unitShadow_6";
          Godzilla.immune_to_slowness = true;
          Godzilla.effect_damage = true;
          Godzilla.unit_other = true;
          Godzilla.collective_term = "group_den";
          Godzilla.default_attack = "base_attack";
          Godzilla.affected_by_dust = false;
          Godzilla.kingdom_id_civilization = string.Empty;
		  Godzilla.build_order_template_id = string.Empty;
          Godzilla.show_on_meta_layer = false;
          Godzilla.show_in_knowledge_window = false;
		  Godzilla.show_in_taxonomy_tooltip = false;
          Godzilla.render_status_effects = true;
          Godzilla.use_phenotypes = false;
          Godzilla.death_animation_angle = true;
          Godzilla.can_be_inspected = true;
          Godzilla.name_template_sets = AssetLibrary<ActorAsset>.a<string>("crocodile_set");
          Godzilla.kingdom_id_wild = "Godzilla_Boss";
          Godzilla.update_z = true;
          Godzilla.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Godzilla.addDecision("random_move_towards_civ_building");
          Godzilla.base_stats["lifespan"] = 200f;
        Godzilla.base_stats["mass_2"] = 100000f;
        Godzilla.base_stats["mass"] = 2000f;
        Godzilla.base_stats["stamina"] = 500f;
        Godzilla.base_stats["scale"] = 0.4f;
        Godzilla.base_stats["size"] = 4f;
        Godzilla.base_stats["health"] = 40000f;
		Godzilla.base_stats["speed"] = 40f;
		Godzilla.base_stats["armor"] = 40f;
		Godzilla.base_stats["attack_speed"] = 0.4f;
		Godzilla.base_stats["damage"] = 1000f;
		Godzilla.base_stats["knockback"] = 4f;
		Godzilla.base_stats["accuracy"] = 1f;
		Godzilla.base_stats["targets"] = 10f;
		Godzilla.base_stats["area_of_effect"] = 5f;
		Godzilla.base_stats["range"] = 2f;
		Godzilla.base_stats["critical_damage_multiplier"] = 10f;
		Godzilla.base_stats["multiplier_supply_timer"] = 1f;
          Godzilla.disable_jump_animation = true;
          Godzilla.can_be_moved_by_powers = true;
          Godzilla.actor_size = ActorSize.S16_Buffalo;
        Godzilla.animation_walk = Kaiju.walk_0_5;
        Godzilla.animation_idle = ActorAnimationSequences.walk_0;
		Godzilla.animation_swim = Kaiju.swim_0_5;
          Godzilla.can_flip = true;
          Godzilla.check_flip = (BaseSimObject _, WorldTile _) => true;
          Godzilla.texture_asset = new ActorTextureSubAsset("actors/Godzilla/", false);
          Godzilla.icon = "Godzilla";
          Godzilla.die_in_lava = false;
          Godzilla.visible_on_minimap = true;
          Godzilla.experience_given = 1000000;
          Godzilla.can_have_subspecies = false;
          Godzilla.affected_by_dust = false;
          Godzilla.inspect_children = false;
          Godzilla.special = true;
          Godzilla.has_advanced_textures = false;
          Godzilla.inspect_sex = false;
		  Godzilla.inspect_show_species = false;
		  Godzilla.inspect_generation = false;
          Godzilla.needs_to_be_explored = false;
          Godzilla.force_land_creature = true;
		  Godzilla.color_hex = "#679ead";
          Godzilla.addTrait("Godzilla_Power");
          Godzilla.addTrait("regeneration");
          Godzilla.addTrait("tough");
          Godzilla.addResource("adamantine", 100);
		Godzilla.addResource("gold", 2000);
 AssetManager.actor_library.add(Godzilla);
			Localization.addLocalization(Godzilla.name_locale, Godzilla.name_locale);


BuildingAsset Godzila_remains = AssetManager.buildings.clone("Godzila_remains", "$mineral$");
Godzila_remains.base_stats["health"] = 100000f;
Godzila_remains.smoke = true;
Godzila_remains.smoke_interval = 2.5f;
Godzila_remains.smoke_offset = new Vector2Int(2, 3);
Godzila_remains.produce_biome_food = true;
Godzila_remains.sprite_path = "buildings/Godzila_remains";
Godzila_remains.setShadow(0.5f, 0.23f, 0.27f);
Godzila_remains.addResource("bones", 200);
Godzila_remains.addResource("stone", 300);
Godzila_remains.addResource("adamantine", 30);
  Godzila_remains.has_sprites_main = true;
  Godzila_remains.has_sprites_ruin = false;
  Godzila_remains.has_sprites_main_disabled = false;
  Godzila_remains.has_sprites_special = false;
  Godzila_remains.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
AssetManager.buildings.add(Godzila_remains);
PreloadHelpers.loadBuildingSprites(Godzila_remains);






var GodzilaEgg = AssetManager.subspecies_traits.clone("GodzilaEgg", "$egg$");
GodzilaEgg.rarity = Rarity.R0_Normal;
GodzilaEgg.id = "GodzilaEgg";
GodzilaEgg.id_egg = "GodzilaEgg";
GodzilaEgg.group_id = "eggs";
GodzilaEgg.phenotype_egg = true;
GodzilaEgg.base_stats_meta["maturation"] = 100f;
GodzilaEgg.sprite_path = "eggs/GodzilaEgg";
GodzilaEgg.path_icon = "ui/icons/GodzilaEgg";
AssetManager.subspecies_traits.add(GodzilaEgg);
Localization.AddOrSet("subspecies_trait_GodzilaEgg", "Godzilla Egg");
Localization.AddOrSet("subspecies_trait_GodzilaEgg_info", "A mysterious egg, rumored to hatch a kaiju.");
Localization.AddOrSet("subspecies_trait_GodzilaEgg_suggested_species", "Iguanazilla");


          var Iguanazilla = AssetManager.actor_library.clone("Iguanazilla", "$mob$");
          Iguanazilla.is_humanoid = false;
	      Iguanazilla.civ = false;
          Iguanazilla.name_locale = "Iguanazilla";
          Iguanazilla.animation_speed_based_on_walk_speed = false;
          Iguanazilla.has_avatar_prefab = false;
          Iguanazilla.inspect_avatar_scale = 0.4f;
          Iguanazilla.inspect_avatar_offset_y = -4f;
          Iguanazilla.shadow_texture = "unitShadow_6";
          Iguanazilla.immune_to_slowness = true;
          Iguanazilla.effect_damage = true;
          Iguanazilla.unit_other = true;
          Iguanazilla.collective_term = "group_den";
          Iguanazilla.setSocialStructure("group_den", 10);
          Iguanazilla.default_attack = "base_attack";
          Iguanazilla.affected_by_dust = true;
          Iguanazilla.inspect_children = true;
          Iguanazilla.kingdom_id_civilization = string.Empty;
		  Iguanazilla.build_order_template_id = string.Empty;
          Iguanazilla.show_on_meta_layer = true;
          Iguanazilla.show_in_knowledge_window = true;
		  Iguanazilla.show_in_taxonomy_tooltip = true;
          Iguanazilla.render_status_effects = true;
          Iguanazilla.use_phenotypes = true;
          Iguanazilla.death_animation_angle = true;
          Iguanazilla.can_be_inspected = true;
          Iguanazilla.name_template_sets = AssetLibrary<ActorAsset>.a<string>("crocodile_set");
          Iguanazilla.kingdom_id_wild = "Godzilla_wild";
          Iguanazilla.update_z = true;
          Iguanazilla.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Iguanazilla.base_stats["lifespan"] = 100f;
        Iguanazilla.base_stats["mass_2"] = 1000f;
        Iguanazilla.base_stats["mass"] = 20f;
        Iguanazilla.base_stats["stamina"] = 500f;
        Iguanazilla.base_stats["scale"] = 0.1f;
        Iguanazilla.base_stats["size"] = 1f;
        Iguanazilla.base_stats["health"] = 500f;
		Iguanazilla.base_stats["speed"] = 40f;
		Iguanazilla.base_stats["armor"] = 40f;
		Iguanazilla.base_stats["attack_speed"] = 0.4f;
		Iguanazilla.base_stats["damage"] = 30f;
		Iguanazilla.base_stats["knockback"] = 2f;
		Iguanazilla.base_stats["accuracy"] = 1f;
		Iguanazilla.base_stats["targets"] = 3f;
		Iguanazilla.base_stats["area_of_effect"] = 2f;
		Iguanazilla.base_stats["range"] = 1f;
		Iguanazilla.base_stats["critical_damage_multiplier"] = 10f;
		Iguanazilla.base_stats["multiplier_supply_timer"] = 1f;
          Iguanazilla.disable_jump_animation = true;
          Iguanazilla.can_be_moved_by_powers = true;
          Iguanazilla.actor_size = ActorSize.S16_Buffalo;
        Iguanazilla.animation_walk = Kaiju.walk_0_5;
        Iguanazilla.animation_idle = ActorAnimationSequences.walk_0;
		Iguanazilla.animation_swim = Kaiju.swim_0_5;
          Iguanazilla.can_flip = true;
          Iguanazilla.check_flip = (BaseSimObject _, WorldTile _) => true;
          Iguanazilla.texture_asset = new ActorTextureSubAsset("actors/Iguanazilla/", false);
          Iguanazilla.icon = "Godzilla";
          Iguanazilla.die_in_lava = false;
          Iguanazilla.visible_on_minimap = false;
          Iguanazilla.experience_given = 20;
          Iguanazilla.can_have_subspecies = true;
          Iguanazilla.affected_by_dust = false;
          Iguanazilla.special = true;
          Iguanazilla.has_advanced_textures = false;
          Iguanazilla.inspect_sex = true;
		  Iguanazilla.inspect_show_species = true;
		  Iguanazilla.inspect_generation = true;
          Iguanazilla.needs_to_be_explored = false;
          Iguanazilla.force_land_creature = true;
          Iguanazilla.has_baby_form = true;
          Iguanazilla.addGenome(("health", 80f), ("stamina", 120f), ("mutation", 1f), ("speed", 12f), ("lifespan", 80f), ("damage", 20f), ("armor", 15f), ("offspring", 2f));
          Iguanazilla.addSubspeciesTrait("stomach");
          Iguanazilla.addSubspeciesTrait("reproduction_strategy_oviparity");
		Iguanazilla.addSubspeciesTrait("GodzilaEgg");
        Iguanazilla.addSubspeciesTrait("aquatic");
        Iguanazilla.addSubspeciesTrait("diet_xylophagy");
        Iguanazilla.addSubspeciesTrait("diet_algivore");
        Iguanazilla.addSubspeciesTrait("death_grow_mythril");
        Iguanazilla.addSubspeciesTrait("bioproduct_gems");
      Iguanazilla.addSubspeciesTrait("long_lifespan");
        Iguanazilla.addSubspeciesTrait("reproduction_hermaphroditic");
       Iguanazilla.addSubspeciesTrait("population_minimal");
       Iguanazilla.addSubspeciesTrait("photosynthetic_skin");
		Iguanazilla.addSubspeciesTrait("parental_care");
        Iguanazilla.addSubspeciesTrait("heat_resistance");
          Iguanazilla.animal_breeding_close_units_limit = 4;
          Iguanazilla.can_evolve_into_new_species = false;
		  Iguanazilla.color_hex = "#679ead";
          Iguanazilla.addTrait("tough");
          Iguanazilla.name_taxonomic_kingdom = "animalia";
		Iguanazilla.name_taxonomic_phylum = "chordata";
		Iguanazilla.name_taxonomic_class = "reptilia";
		Iguanazilla.name_taxonomic_order = "Archosauria";
		Iguanazilla.name_taxonomic_family = "Titanus";
		Iguanazilla.name_taxonomic_genus = "Gojira";
        Iguanazilla.addResource("adamantine", 2);
		Iguanazilla.addResource("gold", 10);
        Iguanazilla.source_meat = true;
Iguanazilla.phenotypes_dict = new Dictionary<string, List<string>>() {
    { "default_color", new List<string> { "gray_black" } },
    { "biome_savanna", new List<string> { "savanna", "dark_orange" } },
    { "biome_swamp", new List<string> { "swamp" } },
    { "biome_corrupted", new List<string> { "corrupted" } },
    { "biome_desert", new List<string> { "desert" } },
    { "biome_infernal", new List<string> { "infernal" } },
    { "biome_lemon", new List<string> { "lemon" } },
    { "biome_mushroom", new List<string> { "pink_yellow_mushroom" } },
    { "biome_sand", new List<string> { "dark_orange", "wood" } },
    { "biome_singularity", new List<string> { "bright_violet" } },
    { "biome_garlic", new List<string> { "mid_gray" } },
    { "biome_maple", new List<string> { "dark_orange" } },
    { "biome_permafrost", new List<string> { "polar" } },
    { "biome_rocklands", new List<string> { "gray_black" } },
    { "biome_celestial", new List<string> { "bright_purple" } }
};

Iguanazilla.phenotypes_list = new List<string> {
    "gray_black",
    "savanna",
    "dark_orange",
    "swamp",
    "corrupted",
    "desert",
    "infernal",
    "lemon",
    "pink_yellow_mushroom",
    "wood",
    "bright_violet",
    "mid_gray",
    "polar",
    "bright_purple"
};
 AssetManager.actor_library.add(Iguanazilla);
			Localization.addLocalization(Iguanazilla.name_locale, Iguanazilla.name_locale);









EffectAsset SmellySplash = new EffectAsset();
SmellySplash.id = "SmellySplash";
SmellySplash.use_basic_prefab = true;
SmellySplash.sorting_layer_id = "EffectsTop";
SmellySplash.sprite_path = "effects/SmellySplash";
SmellySplash.draw_light_area = false;
AssetManager.effects_library.add(SmellySplash);



var BigBigMassiveBoulderterra = AssetManager.terraform.clone("BigBigMassiveBoulderterra", "flash");
		BigBigMassiveBoulderterra.damage = 500;
        BigBigMassiveBoulderterra.flash = false;
		BigBigMassiveBoulderterra.explode_strength = 1;
        BigBigMassiveBoulderterra.explode_tile = true;
        BigBigMassiveBoulderterra.explosion_pixel_effect = true;
        BigBigMassiveBoulderterra.remove_tornado = true;
        BigBigMassiveBoulderterra.apply_force = true;
        BigBigMassiveBoulderterra.damage_buildings = true;
		BigBigMassiveBoulderterra.transform_to_wasteland = false;
		BigBigMassiveBoulderterra.applies_to_high_flyers = true;
		BigBigMassiveBoulderterra.shake = true;
        AssetManager.terraform.add(BigBigMassiveBoulderterra);



            	ProjectileAsset BigBigMassiveBoulder = new ProjectileAsset();
            BigBigMassiveBoulder.id = "BigBigMassiveBoulder";
            BigBigMassiveBoulder.speed = 60f;
			BigBigMassiveBoulder.texture = "BigBigMassiveBoulder";
			BigBigMassiveBoulder.texture_shadow = "shadows/projectiles/shadow_ball";
			BigBigMassiveBoulder.terraform_option = "BigBigMassiveBoulderterra";
			BigBigMassiveBoulder.draw_light_area = true;
			BigBigMassiveBoulder.terraform_range = 10;
			BigBigMassiveBoulder.sound_launch = "event:/SFX/WEAPONS/WeaponStartThrow";
			BigBigMassiveBoulder.sound_impact = "event:/SFX/WEAPONS/WeaponRockLand";
			BigBigMassiveBoulder.end_effect = "SmellySplash";
			BigBigMassiveBoulder.scale_start = 0.2f;
			BigBigMassiveBoulder.scale_target = 0.2f;
			BigBigMassiveBoulder.look_at_target = true;
          BigBigMassiveBoulder.can_be_left_on_ground = true;
          BigBigMassiveBoulder.can_be_blocked = false;
          AssetManager.projectiles.add(BigBigMassiveBoulder);



var KingKong_Boss = AssetManager.kingdoms.clone("KingKong_Boss", "$TEMPLATE_MOB$");
KingKong_Boss.concept = false;
KingKong_Boss.id = "KingKong_Boss";
KingKong_Boss.default_kingdom_color = new ColorAsset("#679ead");
KingKong_Boss.mobs = true;
KingKong_Boss.always_attack_each_other = true;
KingKong_Boss.force_look_all_chunks = true;
KingKong_Boss.units_always_aggressive = true;
KingKong_Boss.setIcon("ui/icons/iconKingKong");
KingKong_Boss.addTag("sliceable");
KingKong_Boss.addFriendlyTag("nature_creature");
KingKong_Boss.addEnemyTag("civ");
KingKong_Boss.addFriendlyTag("wild_kaiju");
KingKong_Boss.addFriendlyTag("civ_monkey");
KingKong_Boss.addFriendlyTag("monkey");
AssetManager.kingdoms.add(KingKong_Boss);
World.world.kingdoms_wild.newWildKingdom(KingKong_Boss);

var KingKong_wild = AssetManager.kingdoms.clone("KingKong_wild", "$TEMPLATE_ANIMAL$");
KingKong_wild.concept = false;
KingKong_wild.id = "KingKong_wild";
KingKong_wild.default_kingdom_color = new ColorAsset("#679ead");
KingKong_wild.setIcon("ui/icons/iconKingKong");
KingKong_wild.addTag("sliceable");
KingKong_wild.addFriendlyTag("elf");
KingKong_wild.addFriendlyTag("nature_creature");
KingKong_wild.addTag("neutral_animals");
KingKong_wild.addTag("neutral");
KingKong_wild.addTag("wild_kaiju");
KingKong_wild.addFriendlyTag("civ_monkey");
KingKong_wild.addFriendlyTag("monkey");
AssetManager.kingdoms.add(KingKong_wild);
World.world.kingdoms_wild.newWildKingdom(KingKong_wild);



          var KingKong = AssetManager.actor_library.clone("KingKong", "$mob$");
          KingKong.is_humanoid = false;
	      KingKong.civ = false;
          KingKong.name_locale = "King Kong";
          KingKong.animation_speed_based_on_walk_speed = false;
          KingKong.has_avatar_prefab = false;
KingKong.has_avatar_prefab = false;
KingKong.get_override_avatar_frames = (Actor pActor) => new Sprite[] { SpriteTextureLoader.getSprite("actors/Avatars/Kong_avatar") };
KingKong.has_override_avatar_frames = true;
KingKong.inspect_avatar_scale = 1f;
KingKong.inspect_avatar_offset_y = 6f;
          KingKong.shadow_texture = "unitShadow_6";
          KingKong.immune_to_slowness = true;
          KingKong.effect_damage = true;
          KingKong.unit_other = true;
          KingKong.collective_term = "group_troop";
          KingKong.default_attack = "base_attack";
          KingKong.affected_by_dust = false;
          KingKong.kingdom_id_civilization = string.Empty;
		  KingKong.build_order_template_id = string.Empty;
          KingKong.show_on_meta_layer = false;
          KingKong.show_in_knowledge_window = false;
		  KingKong.show_in_taxonomy_tooltip = false;
          KingKong.render_status_effects = true;
          KingKong.use_phenotypes = false;
          KingKong.death_animation_angle = true;
          KingKong.can_be_inspected = true;
          KingKong.name_template_sets = AssetLibrary<ActorAsset>.a<string>("monkey_set");
          KingKong.kingdom_id_wild = "KingKong_Boss";
          KingKong.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          KingKong.addDecision("random_move_towards_civ_building");
          KingKong.update_z = true;
        KingKong.base_stats["lifespan"] = 200f;
        KingKong.base_stats["mass_2"] = 10000f;
        KingKong.base_stats["mass"] = 1000f;
        KingKong.base_stats["stamina"] = 500f;
        KingKong.base_stats["scale"] = 0.4f;
        KingKong.base_stats["size"] = 3f;
        KingKong.base_stats["health"] = 30000f;
		KingKong.base_stats["speed"] = 60f;
		KingKong.base_stats["armor"] = 0f;
		KingKong.base_stats["attack_speed"] = 2f;
		KingKong.base_stats["damage"] = 1000f;
		KingKong.base_stats["knockback"] = 4f;
		KingKong.base_stats["accuracy"] = 1f;
		KingKong.base_stats["targets"] = 5f;
		KingKong.base_stats["area_of_effect"] = 10f;
		KingKong.base_stats["range"] = 5f;
		KingKong.base_stats["critical_damage_multiplier"] = 50f;
		KingKong.base_stats["multiplier_supply_timer"] = 1f;
          KingKong.disable_jump_animation = true;
          KingKong.can_be_moved_by_powers = true;
          KingKong.actor_size = ActorSize.S16_Buffalo;
        KingKong.animation_walk = ActorAnimationSequences.walk_0_4;
        KingKong.animation_idle = ActorAnimationSequences.walk_0;
		KingKong.animation_swim = ActorAnimationSequences.swim_0_3;
		 KingKong.can_flip = true;
          KingKong.check_flip = (BaseSimObject _, WorldTile _) => true;
          KingKong.texture_asset = new ActorTextureSubAsset("actors/KingKong/", false);
          KingKong.icon = "iconKingKong";
          KingKong.die_in_lava = false;
          KingKong.visible_on_minimap = true;
          KingKong.experience_given = 1000000;
          KingKong.can_have_subspecies = false;
          KingKong.affected_by_dust = false;
          KingKong.inspect_children = false;
          KingKong.special = true;
          KingKong.has_advanced_textures = false;
          KingKong.inspect_sex = false;
		  KingKong.inspect_show_species = false;
		  KingKong.inspect_generation = false;
          KingKong.needs_to_be_explored = false;
          KingKong.inspect_avatar_scale = 1f;
          KingKong.force_land_creature = true;
		  KingKong.color_hex = "#679ead";
          KingKong.addTrait("regeneration");
          KingKong.addTrait("genius");
          KingKong.addTrait("strong");
          KingKong.addTrait("KingKong_Power");
          KingKong.addTrait("dodge");
		  KingKong.addTrait("deflect_projectile");
		  KingKong.addTrait("dash");
		  KingKong.addTrait("block");
          KingKong.addResource("adamantine", 100);
		KingKong.addResource("gold", 2000);
 AssetManager.actor_library.add(KingKong);
			Localization.addLocalization(KingKong.name_locale, KingKong.name_locale);


BuildingAsset KingKong_remains = AssetManager.buildings.clone("KingKong_remains", "$mineral$");
KingKong_remains.base_stats["health"] = 100000f;
KingKong_remains.smoke = true;
KingKong_remains.smoke_interval = 2.5f;
KingKong_remains.smoke_offset = new Vector2Int(2, 3);
KingKong_remains.produce_biome_food = true;
KingKong_remains.sprite_path = "buildings/KingKong_remains";
KingKong_remains.setShadow(0.5f, 0.23f, 0.27f);
KingKong_remains.addResource("bones", 200);
KingKong_remains.addResource("stone", 300);
KingKong_remains.addResource("adamantine", 30);
  KingKong_remains.has_sprites_main = true;
  KingKong_remains.has_sprites_ruin = false;
  KingKong_remains.has_sprites_main_disabled = false;
  KingKong_remains.has_sprites_special = false;
  KingKong_remains.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
AssetManager.buildings.add(KingKong_remains);
PreloadHelpers.loadBuildingSprites(KingKong_remains);

          var Kong = AssetManager.actor_library.clone("Kong", "$mob$");
          Kong.is_humanoid = false;
	      Kong.civ = false;
          Kong.name_locale = "Kong";
          Kong.animation_speed_based_on_walk_speed = false;
          Kong.has_avatar_prefab = false;
          Kong.inspect_avatar_scale = 1f;
          Kong.inspect_avatar_offset_y = -4f;
          Kong.shadow_texture = "unitShadow_6";
          Kong.immune_to_slowness = true;
          Kong.effect_damage = true;
          Kong.unit_other = true;
          Kong.collective_term = "group_troop";
          Kong.setSocialStructure("group_troop", 25);
          Kong.default_attack = "base_attack";
          Kong.affected_by_dust = true;
          Kong.inspect_children = true;
          Kong.kingdom_id_civilization = string.Empty;
		  Kong.build_order_template_id = string.Empty;
          Kong.show_on_meta_layer = true;
          Kong.show_in_knowledge_window = true;
		  Kong.show_in_taxonomy_tooltip = true;
          Kong.render_status_effects = true;
          Kong.use_phenotypes = true;
          Kong.death_animation_angle = true;
          Kong.can_be_inspected = true;
          Kong.name_template_sets = AssetLibrary<ActorAsset>.a<string>("monkey_set");
          Kong.kingdom_id_wild = "KingKong_wild";
          Kong.update_z = true;
          Kong.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Kong.base_stats["lifespan"] = 100f;
        Kong.base_stats["mass_2"] = 500f;
        Kong.base_stats["mass"] = 20f;
        Kong.base_stats["stamina"] = 500f;
        Kong.base_stats["scale"] = 0.15f;
        Kong.base_stats["size"] = 1f;
        Kong.base_stats["health"] = 250f;
		Kong.base_stats["speed"] = 40f;
		Kong.base_stats["armor"] = 10f;
		Kong.base_stats["attack_speed"] = 1f;
		Kong.base_stats["damage"] = 20f;
		Kong.base_stats["knockback"] = 2f;
		Kong.base_stats["accuracy"] = 1f;
		Kong.base_stats["targets"] = 3f;
		Kong.base_stats["area_of_effect"] = 2f;
		Kong.base_stats["range"] = 1f;
		Kong.base_stats["critical_damage_multiplier"] = 10f;
		Kong.base_stats["multiplier_supply_timer"] = 1f;
          Kong.disable_jump_animation = true;
          Kong.can_be_moved_by_powers = true;
          Kong.actor_size = ActorSize.S16_Buffalo;
        Kong.animation_walk = ActorAnimationSequences.walk_0_4;
        Kong.animation_idle = ActorAnimationSequences.walk_0;
		Kong.animation_swim = ActorAnimationSequences.swim_0_3;
          Kong.can_flip = true;
          Kong.check_flip = (BaseSimObject _, WorldTile _) => true;
          Kong.texture_asset = new ActorTextureSubAsset("actors/Kong/", false);
          Kong.icon = "iconKingKong";
          Kong.die_in_lava = false;
          Kong.visible_on_minimap = false;
          Kong.experience_given = 20;
          Kong.can_have_subspecies = true;
          Kong.affected_by_dust = false;
          Kong.special = true;
          Kong.has_advanced_textures = false;
          Kong.inspect_sex = true;
		  Kong.inspect_show_species = true;
		  Kong.inspect_generation = true;
          Kong.needs_to_be_explored = false;
          Kong.force_land_creature = true;
          Kong.has_baby_form = true;
         Kong.addGenome(("health", 80f), ("stamina", 150f), ("mutation", 1f), ("speed", 14f), ("lifespan", 80f), ("damage", 12f), ("armor", 5f), ("offspring", 8f));
        Kong.addSubspeciesTrait("reproduction_strategy_viviparity");
		Kong.addSubspeciesTrait("gestation_extremely_long");
        Kong.addSubspeciesTrait("voracious");
		Kong.addSubspeciesTrait("reproduction_sexual");
		Kong.addSubspeciesTrait("population_minimal");
		Kong.addSubspeciesTrait("stomach");
		Kong.addSubspeciesTrait("amygdala");
		Kong.addSubspeciesTrait("nimble");
		Kong.addSubspeciesTrait("shiny_love");
        Kong.addSubspeciesTrait("diet_herbivore");
        Kong.addSubspeciesTrait("heat_resistance");
          Kong.animal_breeding_close_units_limit = 4;
          Kong.can_evolve_into_new_species = false;
		  Kong.color_hex = "#679ead";
          Kong.addTrait("agile");
          Kong.addTrait("genius");
          Kong.name_taxonomic_kingdom = "animalia";
		Kong.name_taxonomic_phylum = "chordata";
		Kong.name_taxonomic_class = "mammalia";
		Kong.name_taxonomic_order = "primates";
		Kong.name_taxonomic_family = "Hominidae";
		Kong.name_taxonomic_genus = "Megaprimatus";
		Kong.name_taxonomic_species = "Kong";
          Kong.addResource("adamantine", 2);
		Kong.addResource("gold", 10);
        Kong.source_meat = true;
Kong.phenotypes_dict = new Dictionary<string, List<string>>() {
    { "default_color", new List<string> { "skin_black" } },
    { "biome_savanna", new List<string> { "savanna", "dark_orange" } },
    { "biome_swamp", new List<string> { "swamp" } },
    { "biome_corrupted", new List<string> { "corrupted" } },
    { "biome_desert", new List<string> { "desert" } },
    { "biome_infernal", new List<string> { "infernal" } },
    { "biome_lemon", new List<string> { "lemon" } },
    { "biome_mushroom", new List<string> { "pink_yellow_mushroom" } },
    { "biome_sand", new List<string> { "dark_orange", "wood" } },
    { "biome_singularity", new List<string> { "bright_violet" } },
    { "biome_garlic", new List<string> { "mid_gray" } },
    { "biome_maple", new List<string> { "dark_orange" } },
    { "biome_permafrost", new List<string> { "polar" } },
    { "biome_rocklands", new List<string> { "gray_black" } },
    { "biome_celestial", new List<string> { "bright_purple" } }
};

Kong.phenotypes_list = new List<string> {
    "skin_black",
    "savanna",
    "dark_orange",
    "swamp",
    "corrupted",
    "desert",
    "infernal",
    "lemon",
    "pink_yellow_mushroom",
    "wood",
    "bright_violet",
    "mid_gray",
    "polar",
    "bright_purple"
};
 AssetManager.actor_library.add(Kong);
			Localization.addLocalization(Kong.name_locale, Kong.name_locale);





var Ghidorah_Boss = AssetManager.kingdoms.clone("Ghidorah_Boss", "$TEMPLATE_MOB$");
Ghidorah_Boss.concept = false;
Ghidorah_Boss.id = "Ghidorah_Boss";
Ghidorah_Boss.default_kingdom_color = new ColorAsset("#679ead");
Ghidorah_Boss.mobs = true;
Ghidorah_Boss.always_attack_each_other = true;
Ghidorah_Boss.force_look_all_chunks = true;
Ghidorah_Boss.units_always_aggressive = true;
Ghidorah_Boss.setIcon("ui/icons/Ghidorah");
Ghidorah_Boss.addTag("sliceable");
Ghidorah_Boss.addEnemyTag("civ");
Ghidorah_Boss.addFriendlyTag("wild_kaiju");
AssetManager.kingdoms.add(Ghidorah_Boss);
World.world.kingdoms_wild.newWildKingdom(Ghidorah_Boss);

var Ghidorah_wild = AssetManager.kingdoms.clone("Ghidorah_wild", "$TEMPLATE_MOB$");
Ghidorah_wild.concept = false;
Ghidorah_wild.id = "Ghidorah_wild";
Ghidorah_wild.default_kingdom_color = new ColorAsset("#679ead");
Ghidorah_wild.setIcon("ui/icons/Ghidorah");
Ghidorah_wild.addTag("sliceable");
Ghidorah_wild.addTag("wild_kaiju");
AssetManager.kingdoms.add(Ghidorah_wild);
World.world.kingdoms_wild.newWildKingdom(Ghidorah_wild);


EffectAsset ElectroBeam_trail = new EffectAsset();
ElectroBeam_trail.id = "ElectroBeam_trail";
ElectroBeam_trail.use_basic_prefab = true;
ElectroBeam_trail.sorting_layer_id = "EffectsTop";
ElectroBeam_trail.sprite_path = "effects/ElectroBeam_trail";
ElectroBeam_trail.draw_light_area = true;
ElectroBeam_trail.show_on_mini_map = true;
ElectroBeam_trail.limit = 15;
AssetManager.effects_library.add(ElectroBeam_trail);


var ElectroBeamterra = AssetManager.terraform.clone("ElectroBeamterra", "bomb");
		ElectroBeamterra.damage = 500;
		ElectroBeamterra.explode_strength = 1;
		ElectroBeamterra.transform_to_wasteland = false;
		ElectroBeamterra.applies_to_high_flyers = true;
		ElectroBeamterra.shake = true;
        AssetManager.terraform.add(ElectroBeamterra);



            	ProjectileAsset ElectroBeam = new ProjectileAsset();
            ElectroBeam.id = "ElectroBeam";
            ElectroBeam.speed = 60f;
			ElectroBeam.texture = "ElectroBeam";
			ElectroBeam.trail_effect_enabled = true;
            ElectroBeam.trail_effect_id = "ElectroBeam_trail";
            ElectroBeam.trail_effect_scale = 0.25f;
			ElectroBeam.trail_effect_timer = 0.1f;
			ElectroBeam.texture_shadow = "shadows/projectiles/shadow_ball";
			ElectroBeam.terraform_option = "ElectroBeamterra";
			ElectroBeam.draw_light_area = true;
			ElectroBeam.terraform_range = 10;
			ElectroBeam.sound_launch = "event:/SFX/WEAPONS/WeaponFireballStart";
			ElectroBeam.sound_impact = "event:/SFX/WEAPONS/WeaponFireballLand";
			ElectroBeam.end_effect = "fx_lightning_big";
			ElectroBeam.scale_start = 0.4f;
			ElectroBeam.scale_target = 0.4f;
			ElectroBeam.look_at_target = true;
          ElectroBeam.can_be_left_on_ground = false;
          ElectroBeam.can_be_blocked = false;
		  ElectroBeam.world_actions = (AttackAction)Delegate.Combine(ElectroBeam.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(ElectroBeam);


          var Ghidorah = AssetManager.actor_library.clone("Ghidorah", "$mob$");
          Ghidorah.is_humanoid = false;
	      Ghidorah.civ = false;
          Ghidorah.name_locale = "Ghidorah";
          Ghidorah.animation_speed_based_on_walk_speed = false;
Ghidorah.has_avatar_prefab = false;
Ghidorah.get_override_avatar_frames = (Actor pActor) => new Sprite[] { SpriteTextureLoader.getSprite("actors/Avatars/Ghidorah_avatar") };
Ghidorah.has_override_avatar_frames = true;
Ghidorah.inspect_avatar_scale = 1f;
Ghidorah.inspect_avatar_offset_y = 6f;
          Ghidorah.shadow_texture = "unitShadow_6";
          Ghidorah.immune_to_slowness = true;
          Ghidorah.effect_damage = true;
          Ghidorah.unit_other = true;
          Ghidorah.collective_term = "group_den";
          Ghidorah.default_attack = "jaws";
          Ghidorah.affected_by_dust = false;
          Ghidorah.kingdom_id_civilization = string.Empty;
		  Ghidorah.build_order_template_id = string.Empty;
          Ghidorah.show_on_meta_layer = false;
          Ghidorah.show_in_knowledge_window = false;
		  Ghidorah.show_in_taxonomy_tooltip = false;
          Ghidorah.render_status_effects = true;
          Ghidorah.use_phenotypes = false;
          Ghidorah.death_animation_angle = true;
          Ghidorah.can_be_inspected = true;
          Ghidorah.name_template_sets = AssetLibrary<ActorAsset>.a<string>("evil_mage_set");
          Ghidorah.kingdom_id_wild = "Ghidorah_Boss";
          Ghidorah.update_z = true;
          Ghidorah.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Ghidorah.addDecision("random_move_towards_civ_building");
          Ghidorah.base_stats["lifespan"] = 200f;
        Ghidorah.base_stats["mass_2"] = 100000f;
        Ghidorah.base_stats["mass"] = 2000f;
        Ghidorah.base_stats["stamina"] = 500f;
        Ghidorah.base_stats["scale"] = 0.4f;
        Ghidorah.base_stats["size"] = 4f;
        Ghidorah.base_stats["health"] = 60000f;
		Ghidorah.base_stats["speed"] = 40f;
		Ghidorah.base_stats["armor"] = 40f;
		Ghidorah.base_stats["attack_speed"] = 1.2f;
		Ghidorah.base_stats["damage"] = 1000f;
		Ghidorah.base_stats["knockback"] = 4f;
		Ghidorah.base_stats["accuracy"] = 1f;
		Ghidorah.base_stats["targets"] = 10f;
		Ghidorah.base_stats["area_of_effect"] = 5f;
		Ghidorah.base_stats["range"] = 2f;
		Ghidorah.base_stats["critical_damage_multiplier"] = 10f;
		Ghidorah.base_stats["multiplier_supply_timer"] = 1f;
          Ghidorah.disable_jump_animation = true;
          Ghidorah.can_be_moved_by_powers = true;
          Ghidorah.actor_size = ActorSize.S16_Buffalo;
        Ghidorah.animation_walk = Kaiju.walk_0_5;
        Ghidorah.animation_idle = Kaiju.idle_0;
		Ghidorah.animation_swim = Kaiju.walk_0_5;
          Ghidorah.can_flip = true;
          Ghidorah.check_flip = (BaseSimObject _, WorldTile _) => true;
          Ghidorah.texture_asset = new ActorTextureSubAsset("actors/Ghidorah/", false);
          Ghidorah.icon = "Ghidorah";
          Ghidorah.die_in_lava = false;
          Ghidorah.visible_on_minimap = true;
          Ghidorah.experience_given = 1000000;
          Ghidorah.can_have_subspecies = false;
          Ghidorah.affected_by_dust = false;
          Ghidorah.inspect_children = false;
          Ghidorah.special = true;
          Ghidorah.has_advanced_textures = false;
          Ghidorah.inspect_sex = false;
		  Ghidorah.inspect_show_species = false;
		  Ghidorah.inspect_generation = false;
          Ghidorah.needs_to_be_explored = false;
          Ghidorah.force_land_creature = true;
		  Ghidorah.color_hex = "#679ead";
          Ghidorah.addTrait("Ghidorah_Power");
          Ghidorah.addTrait("regeneration");
          Ghidorah.addTrait("evil");
        Ghidorah.addResource("adamantine", 100);
		Ghidorah.addResource("gold", 2000);
 AssetManager.actor_library.add(Ghidorah);
			Localization.addLocalization(Ghidorah.name_locale, Ghidorah.name_locale);




BuildingAsset Ghidorah_remains = AssetManager.buildings.clone("Ghidorah_remains", "$mineral$");
Ghidorah_remains.base_stats["health"] = 100000f;
Ghidorah_remains.smoke = true;
Ghidorah_remains.smoke_interval = 2.5f;
Ghidorah_remains.smoke_offset = new Vector2Int(2, 3);
Ghidorah_remains.produce_biome_food = true;
Ghidorah_remains.sprite_path = "buildings/Ghidorah_remains";
Ghidorah_remains.setShadow(0.5f, 0.23f, 0.27f);
Ghidorah_remains.addResource("bones", 200);
Ghidorah_remains.addResource("stone", 300);
Ghidorah_remains.addResource("adamantine", 30);
 Ghidorah_remains.has_sprites_main = true;
  Ghidorah_remains.has_sprites_ruin = false;
  Ghidorah_remains.has_sprites_main_disabled = false;
  Ghidorah_remains.has_sprites_special = false;
  Ghidorah_remains.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
AssetManager.buildings.add(Ghidorah_remains);
PreloadHelpers.loadBuildingSprites(Ghidorah_remains);



 var GhidorahEgg = AssetManager.subspecies_traits.clone("GhidorahEgg", "$egg$");
GhidorahEgg.rarity = Rarity.R0_Normal;
GhidorahEgg.id = "GhidorahEgg";
GhidorahEgg.id_egg = "GhidorahEgg";
GhidorahEgg.group_id = "eggs";
GhidorahEgg.phenotype_egg = true;
GhidorahEgg.base_stats_meta["maturation"] = 100f;
GhidorahEgg.sprite_path = "eggs/GhidorahEgg";
GhidorahEgg.path_icon = "ui/icons/GhidorahEgg";
AssetManager.subspecies_traits.add(GhidorahEgg);
Localization.AddOrSet("subspecies_trait_GhidorahEgg", "Ghidorah Egg");
Localization.AddOrSet("subspecies_trait_GhidorahEgg_info", "A mysterious egg, rumored to hatch a kaiju.");
Localization.AddOrSet("subspecies_trait_GhidorahEgg_suggested_species", "Hydraflians");


          var Hydraflians = AssetManager.actor_library.clone("Hydraflians", "$mob$");
          Hydraflians.is_humanoid = false;
	      Hydraflians.civ = false;
          Hydraflians.name_locale = "Hydraflians";
          Hydraflians.animation_speed_based_on_walk_speed = false;
          Hydraflians.has_avatar_prefab = false;
          Hydraflians.inspect_avatar_scale = 0.4f;
          Hydraflians.inspect_avatar_offset_y = -4f;
          Hydraflians.shadow_texture = "unitShadow_6";
          Hydraflians.immune_to_slowness = true;
          Hydraflians.effect_damage = true;
          Hydraflians.unit_other = true;
          Hydraflians.collective_term = "group_den";
          Hydraflians.setSocialStructure("group_den", 10);
          Hydraflians.default_attack = "base_attack";
          Hydraflians.affected_by_dust = true;
          Hydraflians.inspect_children = true;
          Hydraflians.kingdom_id_civilization = string.Empty;
		  Hydraflians.build_order_template_id = string.Empty;
          Hydraflians.show_on_meta_layer = true;
          Hydraflians.show_in_knowledge_window = true;
		  Hydraflians.show_in_taxonomy_tooltip = true;
          Hydraflians.render_status_effects = true;
          Hydraflians.use_phenotypes = true;
          Hydraflians.death_animation_angle = true;
          Hydraflians.can_be_inspected = true;
          Hydraflians.name_template_sets = AssetLibrary<ActorAsset>.a<string>("crocodile_set");
          Hydraflians.kingdom_id_wild = "Ghidorah_wild";
          Hydraflians.update_z = true;
          Hydraflians.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Hydraflians.base_stats["lifespan"] = 100f;
        Hydraflians.base_stats["mass_2"] = 1000f;
        Hydraflians.base_stats["mass"] = 20f;
        Hydraflians.base_stats["stamina"] = 500f;
        Hydraflians.base_stats["scale"] = 0.1f;
        Hydraflians.base_stats["size"] = 1f;
        Hydraflians.base_stats["health"] = 500f;
		Hydraflians.base_stats["speed"] = 40f;
		Hydraflians.base_stats["armor"] = 40f;
		Hydraflians.base_stats["attack_speed"] = 0.4f;
		Hydraflians.base_stats["damage"] = 30f;
		Hydraflians.base_stats["knockback"] = 2f;
		Hydraflians.base_stats["accuracy"] = 1f;
		Hydraflians.base_stats["targets"] = 3f;
		Hydraflians.base_stats["area_of_effect"] = 2f;
		Hydraflians.base_stats["range"] = 1f;
		Hydraflians.base_stats["critical_damage_multiplier"] = 10f;
		Hydraflians.base_stats["multiplier_supply_timer"] = 1f;
          Hydraflians.disable_jump_animation = true;
          Hydraflians.can_be_moved_by_powers = true;
          Hydraflians.actor_size = ActorSize.S16_Buffalo;
        Hydraflians.animation_walk = Kaiju.walk_0_5;
        Hydraflians.animation_idle = Kaiju.idle_0;
		Hydraflians.animation_swim = Kaiju.walk_0_5;
          Hydraflians.can_flip = true;
          Hydraflians.check_flip = (BaseSimObject _, WorldTile _) => true;
          Hydraflians.texture_asset = new ActorTextureSubAsset("actors/Hydraflians/", false);
          Hydraflians.icon = "Ghidorah";
          Hydraflians.die_in_lava = false;
          Hydraflians.visible_on_minimap = false;
          Hydraflians.experience_given = 20;
          Hydraflians.can_have_subspecies = true;
          Hydraflians.affected_by_dust = false;
          Hydraflians.special = true;
          Hydraflians.has_advanced_textures = false;
          Hydraflians.inspect_sex = true;
		  Hydraflians.inspect_show_species = true;
		  Hydraflians.inspect_generation = true;
          Hydraflians.needs_to_be_explored = false;
          Hydraflians.force_land_creature = true;
          Hydraflians.has_baby_form = true;
          Hydraflians.addGenome(("health", 80f), ("stamina", 120f), ("mutation", 1f), ("speed", 12f), ("lifespan", 80f), ("damage", 20f), ("armor", 15f), ("offspring", 2f));
          Hydraflians.addSubspeciesTrait("stomach");
          Hydraflians.addSubspeciesTrait("reproduction_strategy_oviparity");
		Hydraflians.addSubspeciesTrait("GhidorahEgg");
        Hydraflians.addSubspeciesTrait("diet_carnivore");
        Hydraflians.addSubspeciesTrait("diet_hematophagy");
        Hydraflians.addSubspeciesTrait("bioproduct_gold");
        Hydraflians.addSubspeciesTrait("voracious");
      Hydraflians.addSubspeciesTrait("long_lifespan");
        Hydraflians.addSubspeciesTrait("reproduction_hermaphroditic");
       Hydraflians.addSubspeciesTrait("population_minimal");
       Hydraflians.addSubspeciesTrait("aggressive");
        Hydraflians.addSubspeciesTrait("gift_of_thunder");
		Hydraflians.addSubspeciesTrait("gift_of_air");
		Hydraflians.addSubspeciesTrait("parental_care");
        Hydraflians.addSubspeciesTrait("heat_resistance");
          Hydraflians.animal_breeding_close_units_limit = 4;
          Hydraflians.can_evolve_into_new_species = false;
		  Hydraflians.color_hex = "#679ead";
          Hydraflians.addTrait("flesh_eater");
          Hydraflians.addTrait("evil");
          Hydraflians.addTrait("gluttonous");
         Hydraflians.addResource("adamantine", 2);
		Hydraflians.addResource("gold", 10);
          Hydraflians.name_taxonomic_kingdom = "lunanimalia";
		Hydraflians.name_taxonomic_phylum = "moonchordata";
		Hydraflians.name_taxonomic_class = "xenoreptilia";
		Hydraflians.name_taxonomic_order = "astrosauria";
		Hydraflians.name_taxonomic_family = "invadere";
		Hydraflians.name_taxonomic_genus = "Ghidorah";
        Hydraflians.source_meat = true;
Hydraflians.phenotypes_dict = new Dictionary<string, List<string>>() {
    { "default_color", new List<string> { "bright_yellow" } },
    { "biome_savanna", new List<string> { "savanna", "dark_orange" } },
    { "biome_swamp", new List<string> { "swamp" } },
    { "biome_corrupted", new List<string> { "corrupted" } },
    { "biome_desert", new List<string> { "desert" } },
    { "biome_infernal", new List<string> { "infernal" } },
    { "biome_lemon", new List<string> { "lemon" } },
    { "biome_mushroom", new List<string> { "pink_yellow_mushroom" } },
    { "biome_sand", new List<string> { "dark_orange", "wood" } },
    { "biome_singularity", new List<string> { "bright_violet" } },
    { "biome_garlic", new List<string> { "mid_gray" } },
    { "biome_maple", new List<string> { "dark_orange" } },
    { "biome_permafrost", new List<string> { "polar" } },
    { "biome_rocklands", new List<string> { "gray_black" } },
    { "biome_celestial", new List<string> { "bright_purple" } }
};

Hydraflians.phenotypes_list = new List<string> {
    "bright_yellow",
    "savanna",
    "dark_orange",
    "swamp",
    "corrupted",
    "desert",
    "infernal",
    "lemon",
    "pink_yellow_mushroom",
    "wood",
    "bright_violet",
    "mid_gray",
    "polar",
    "bright_purple"
};
 AssetManager.actor_library.add(Hydraflians);
			Localization.addLocalization(Hydraflians.name_locale, Hydraflians.name_locale);












var Rodan_Boss = AssetManager.kingdoms.clone("Rodan_Boss", "$TEMPLATE_MOB$");
Rodan_Boss.concept = false;
Rodan_Boss.id = "Rodan_Boss";
Rodan_Boss.default_kingdom_color = new ColorAsset("#679ead");
Rodan_Boss.mobs = true;
Rodan_Boss.always_attack_each_other = true;
Rodan_Boss.force_look_all_chunks = true;
Rodan_Boss.units_always_aggressive = true;
Rodan_Boss.setIcon("ui/icons/Rodan");
Rodan_Boss.addTag("sliceable");
Rodan_Boss.addEnemyTag("civ");
Rodan_Boss.addFriendlyTag("wild_kaiju");
AssetManager.kingdoms.add(Rodan_Boss);
World.world.kingdoms_wild.newWildKingdom(Rodan_Boss);

var Rodan_wild = AssetManager.kingdoms.clone("Rodan_wild", "$TEMPLATE_MOB$");
Rodan_wild.concept = false;
Rodan_wild.id = "Rodan_wild";
Rodan_wild.default_kingdom_color = new ColorAsset("#679ead");
Rodan_wild.setIcon("ui/icons/Rodan");
Rodan_wild.addTag("sliceable");
Rodan_wild.addTag("wild_kaiju");
AssetManager.kingdoms.add(Rodan_wild);
World.world.kingdoms_wild.newWildKingdom(Rodan_wild);


EffectAsset FieryShock_trail = new EffectAsset();
FieryShock_trail.id = "FieryShock_trail";
FieryShock_trail.use_basic_prefab = true;
FieryShock_trail.sorting_layer_id = "EffectsTop";
FieryShock_trail.sprite_path = "effects/FieryShock_trail";
FieryShock_trail.draw_light_area = true;
FieryShock_trail.show_on_mini_map = true;
FieryShock_trail.limit = 15;
AssetManager.effects_library.add(FieryShock_trail);


EffectAsset magma_tornado = new EffectAsset();
magma_tornado.id = "magma_tornado";
magma_tornado.use_basic_prefab = true;
magma_tornado.sorting_layer_id = "EffectsTop";
magma_tornado.sprite_path = "effects/magma_tornado";
magma_tornado.sound_loop_idle = "event:/SFX/NATURE/TornadoIdleLoop";
magma_tornado.draw_light_area = true;
magma_tornado.show_on_mini_map = true;
magma_tornado.limit = 20;
AssetManager.effects_library.add(magma_tornado);


var FieryShockterra = AssetManager.terraform.clone("FieryShockterra", "bomb");
		FieryShockterra.damage = 500;
		FieryShockterra.explode_strength = 1;
		FieryShockterra.transform_to_wasteland = false;
		FieryShockterra.applies_to_high_flyers = true;
            FieryShockterra.set_fire = true;
			FieryShockterra.apply_force = true;
			FieryShockterra.add_burned = true;
			FieryShockterra.force_power = 2.5f;
			FieryShockterra.attack_type = AttackType.Fire;
        AssetManager.terraform.add(FieryShockterra);



            	ProjectileAsset FieryShock = new ProjectileAsset();
            FieryShock.id = "FieryShock";
            FieryShock.speed = 60f;
			FieryShock.texture = "FieryShock";
			FieryShock.trail_effect_enabled = true;
            FieryShock.trail_effect_id = "FieryShock_trail";
            FieryShock.trail_effect_scale = 0.25f;
			FieryShock.trail_effect_timer = 0.1f;
			FieryShock.texture_shadow = "shadows/projectiles/shadow_ball";
			FieryShock.terraform_option = "FieryShockterra";
			FieryShock.draw_light_area = true;
			FieryShock.terraform_range = 10;
			FieryShock.sound_launch = "event:/SFX/WEAPONS/WeaponFireballStart";
			FieryShock.sound_impact = "event:/SFX/WEAPONS/WeaponFireballLand";
			FieryShock.end_effect = "firepower_boom";
			FieryShock.scale_start = 0.4f;
			FieryShock.scale_target = 0.4f;
			FieryShock.look_at_target = true;
          FieryShock.can_be_left_on_ground = false;
          FieryShock.can_be_blocked = false;
		  FieryShock.world_actions = (AttackAction)Delegate.Combine(FieryShock.world_actions, new AttackAction(ActionLibrary.burnTile));
          AssetManager.projectiles.add(FieryShock);


          var Rodan = AssetManager.actor_library.clone("Rodan", "$mob$");
          Rodan.is_humanoid = false;
	      Rodan.civ = false;
          Rodan.name_locale = "Rodan";
          Rodan.animation_speed_based_on_walk_speed = false;
Rodan.has_avatar_prefab = false;
Rodan.get_override_avatar_frames = (Actor pActor) => new Sprite[] { SpriteTextureLoader.getSprite("actors/Avatars/Rodan_avatar") };
Rodan.has_override_avatar_frames = true;
Rodan.inspect_avatar_scale = 1f;
Rodan.inspect_avatar_offset_y = 6f;
          Rodan.shadow_texture = "unitShadow_6";
          Rodan.immune_to_slowness = true;
          Rodan.effect_damage = true;
          Rodan.unit_other = true;
          Rodan.collective_term = "group_den";
          Rodan.default_attack = "jaws";
          Rodan.affected_by_dust = false;
          Rodan.kingdom_id_civilization = string.Empty;
		  Rodan.build_order_template_id = string.Empty;
          Rodan.show_on_meta_layer = false;
          Rodan.show_in_knowledge_window = false;
		  Rodan.show_in_taxonomy_tooltip = false;
          Rodan.render_status_effects = true;
          Rodan.use_phenotypes = false;
          Rodan.death_animation_angle = true;
          Rodan.can_be_inspected = true;
          Rodan.name_template_sets = AssetLibrary<ActorAsset>.a<string>("evil_mage_set");
          Rodan.kingdom_id_wild = "Rodan_Boss";
          Rodan.update_z = true;
          Rodan.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Rodan.addDecision("random_move_towards_civ_building");
          Rodan.base_stats["lifespan"] = 200f;
        Rodan.base_stats["mass_2"] = 100000f;
        Rodan.base_stats["mass"] = 2000f;
        Rodan.base_stats["stamina"] = 500f;
        Rodan.base_stats["scale"] = 0.4f;
        Rodan.base_stats["size"] = 4f;
        Rodan.base_stats["health"] = 25000f;
		Rodan.base_stats["speed"] = 60f;
		Rodan.base_stats["armor"] = 60f;
		Rodan.base_stats["attack_speed"] = 1.2f;
		Rodan.base_stats["damage"] = 1000f;
		Rodan.base_stats["knockback"] = 4f;
		Rodan.base_stats["accuracy"] = 1f;
		Rodan.base_stats["targets"] = 10f;
		Rodan.base_stats["area_of_effect"] = 5f;
		Rodan.base_stats["range"] = 2f;
		Rodan.base_stats["critical_damage_multiplier"] = 10f;
		Rodan.base_stats["multiplier_supply_timer"] = 1f;
          Rodan.disable_jump_animation = true;
          Rodan.can_be_moved_by_powers = true;
          Rodan.actor_size = ActorSize.S16_Buffalo;
        Rodan.animation_walk = ActorAnimationSequences.walk_0_3;
        Rodan.animation_idle = Kaiju.idle_0_6;
		Rodan.animation_swim = ActorAnimationSequences.walk_0_3;
          Rodan.can_flip = true;
          Rodan.check_flip = (BaseSimObject _, WorldTile _) => true;
          Rodan.texture_asset = new ActorTextureSubAsset("actors/Rodan/", false);
          Rodan.icon = "Rodan";
          Rodan.die_in_lava = false;
          Rodan.visible_on_minimap = true;
          Rodan.experience_given = 1000000;
          Rodan.can_have_subspecies = false;
          Rodan.affected_by_dust = false;
          Rodan.inspect_children = false;
          Rodan.special = true;
          Rodan.has_advanced_textures = false;
          Rodan.inspect_sex = false;
		  Rodan.inspect_show_species = false;
		  Rodan.inspect_generation = false;
          Rodan.needs_to_be_explored = false;
          Rodan.force_land_creature = true;
		  Rodan.color_hex = "#679ead";
          Rodan.addTrait("Rodan_Power");
          Rodan.addTrait("regeneration");
          Rodan.addTrait("freeze_proof");
          Rodan.addTrait("fire_proof");
          Rodan.addTrait("tough");
        Rodan.addResource("adamantine", 100);
		Rodan.addResource("gold", 2000);
        Rodan.flying = true;
        Rodan.very_high_flyer = true;
			Rodan.die_on_blocks = false;
			Rodan.ignore_blocks = true;
			Rodan.move_from_block = false;
			Rodan.run_to_water_when_on_fire = false;
 AssetManager.actor_library.add(Rodan);
			Localization.addLocalization(Rodan.name_locale, Rodan.name_locale);




BuildingAsset Rodan_remains = AssetManager.buildings.clone("Rodan_remains", "$mineral$");
Rodan_remains.base_stats["health"] = 100000f;
Rodan_remains.smoke = true;
Rodan_remains.smoke_interval = 2.5f;
Rodan_remains.smoke_offset = new Vector2Int(2, 3);
Rodan_remains.produce_biome_food = true;
Rodan_remains.sprite_path = "buildings/Rodan_remains";
Rodan_remains.setShadow(0.5f, 0.23f, 0.27f);
Rodan_remains.addResource("bones", 200);
Rodan_remains.addResource("stone", 300);
Rodan_remains.addResource("adamantine", 30);
 Rodan_remains.has_sprites_main = true;
  Rodan_remains.has_sprites_ruin = false;
  Rodan_remains.has_sprites_main_disabled = false;
  Rodan_remains.has_sprites_special = false;
  Rodan_remains.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
AssetManager.buildings.add(Rodan_remains);
PreloadHelpers.loadBuildingSprites(Rodan_remains);



 var RodanEgg = AssetManager.subspecies_traits.clone("RodanEgg", "$egg$");
RodanEgg.rarity = Rarity.R0_Normal;
RodanEgg.id = "RodanEgg";
RodanEgg.id_egg = "RodanEgg";
RodanEgg.group_id = "eggs";
RodanEgg.phenotype_egg = true;
RodanEgg.base_stats_meta["maturation"] = 50f;
RodanEgg.sprite_path = "eggs/RodanEgg";
RodanEgg.path_icon = "ui/icons/RodanEgg";
RodanEgg.after_hatch_from_egg_action = delegate(Actor pActor)
		{
			ActionLibrary.fireDropsSpawn(pActor);
		};
AssetManager.subspecies_traits.add(RodanEgg);
Localization.AddOrSet("subspecies_trait_RodanEgg", "Rodan Egg");
Localization.AddOrSet("subspecies_trait_RodanEgg_info", "A mysterious egg, rumored to hatch a kaiju.");
Localization.AddOrSet("subspecies_trait_RodanEgg_suggested_species", "Radon");


          var Radon = AssetManager.actor_library.clone("Radon", "$mob$");
          Radon.is_humanoid = false;
	      Radon.civ = false;
          Radon.name_locale = "Radon";
          Radon.animation_speed_based_on_walk_speed = false;
          Radon.animation_speed_based_on_walk_speed = false;
          Radon.has_avatar_prefab = false;
          Radon.inspect_avatar_scale = 1f;
          Radon.inspect_avatar_offset_y = -4f;
          Radon.shadow_texture = "unitShadow_6";
          Radon.immune_to_slowness = true;
          Radon.effect_damage = true;
          Radon.unit_other = true;
          Radon.collective_term = "group_den";
          Radon.setSocialStructure("group_den", 10);
          Radon.default_attack = "fire_hands";
          Radon.affected_by_dust = true;
          Radon.inspect_children = true;
          Radon.kingdom_id_civilization = string.Empty;
		  Radon.build_order_template_id = string.Empty;
          Radon.show_on_meta_layer = true;
          Radon.show_in_knowledge_window = true;
		  Radon.show_in_taxonomy_tooltip = true;
          Radon.render_status_effects = true;
          Radon.use_phenotypes = true;
          Radon.death_animation_angle = true;
          Radon.can_be_inspected = true;
          Radon.name_template_sets = AssetLibrary<ActorAsset>.a<string>("crocodile_set");
          Radon.kingdom_id_wild = "Rodan_wild";
          Radon.update_z = true;
          Radon.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Radon.base_stats["lifespan"] = 100f;
        Radon.base_stats["mass_2"] = 1000f;
        Radon.base_stats["mass"] = 20f;
        Radon.base_stats["stamina"] = 500f;
        Radon.base_stats["scale"] = 0.1f;
        Radon.base_stats["size"] = 1f;
        Radon.base_stats["health"] = 200f;
		Radon.base_stats["speed"] = 60f;
		Radon.base_stats["armor"] = 60f;
		Radon.base_stats["attack_speed"] = 3f;
		Radon.base_stats["damage"] = 20f;
		Radon.base_stats["knockback"] = 2f;
		Radon.base_stats["accuracy"] = 1f;
		Radon.base_stats["targets"] = 1f;
		Radon.base_stats["area_of_effect"] = 2f;
		Radon.base_stats["range"] = 1f;
		Radon.base_stats["critical_damage_multiplier"] = 10f;
		Radon.base_stats["multiplier_supply_timer"] = 1f;
          Radon.disable_jump_animation = true;
          Radon.can_be_moved_by_powers = true;
          Radon.actor_size = ActorSize.S16_Buffalo;
        Radon.animation_walk = ActorAnimationSequences.walk_0_3;
        Radon.animation_idle = Kaiju.idle_0_6;
		Radon.animation_swim = ActorAnimationSequences.walk_0_3;
          Radon.can_flip = true;
          Radon.check_flip = (BaseSimObject _, WorldTile _) => true;
          Radon.texture_asset = new ActorTextureSubAsset("actors/Radon/", false);
          Radon.icon = "Rodan";
          Radon.die_in_lava = false;
          Radon.visible_on_minimap = false;
          Radon.experience_given = 20;
          Radon.can_have_subspecies = true;
          Radon.affected_by_dust = false;
          Radon.special = true;
          Radon.has_advanced_textures = false;
          Radon.inspect_sex = true;
		  Radon.inspect_show_species = true;
		  Radon.inspect_generation = true;
          Radon.needs_to_be_explored = false;
          Radon.force_land_creature = true;
          Radon.has_baby_form = true;
          Radon.addGenome(("health", 80f), ("stamina", 120f), ("mutation", 1f), ("speed", 12f), ("lifespan", 80f), ("damage", 20f), ("armor", 15f), ("offspring", 2f));
          Radon.addSubspeciesTrait("stomach");
          Radon.addSubspeciesTrait("reproduction_strategy_oviparity");
		Radon.addSubspeciesTrait("RodanEgg");
        Radon.addSubspeciesTrait("diet_carnivore");
        Radon.addSubspeciesTrait("diet_xylophagy");
        Radon.addSubspeciesTrait("bioproduct_stone");
        Radon.addSubspeciesTrait("voracious");
      Radon.addSubspeciesTrait("long_lifespan");
        Radon.addSubspeciesTrait("reproduction_hermaphroditic");
       Radon.addSubspeciesTrait("population_minimal");
       Radon.addSubspeciesTrait("aggressive");
        Radon.addSubspeciesTrait("gift_of_fire");
		Radon.addSubspeciesTrait("gift_of_air");
		Radon.addSubspeciesTrait("parental_care");
        Radon.addSubspeciesTrait("heat_resistance");
          Radon.animal_breeding_close_units_limit = 4;
          Radon.can_evolve_into_new_species = false;
		  Radon.color_hex = "#679ead";
          Radon.addTrait("flesh_eater");
          Radon.addTrait("evil");
          Radon.addTrait("gluttonous");
         Radon.addResource("adamantine", 2);
		Radon.addResource("gold", 10);
          Radon.name_taxonomic_kingdom = "Animalia";
		Radon.name_taxonomic_phylum = "Chordata";
		Radon.name_taxonomic_class = "Sauropsida";
		Radon.name_taxonomic_order = "Archosauria";
		Radon.name_taxonomic_family = "Pterosauromorpha";
		Radon.name_taxonomic_genus = "Radontitanus";
        Radon.source_meat = true;
Radon.phenotypes_dict = new Dictionary<string, List<string>>() {
    { "default_color", new List<string> { "dark_red" } },
    { "biome_savanna", new List<string> { "savanna", "dark_orange" } },
    { "biome_swamp", new List<string> { "swamp" } },
    { "biome_corrupted", new List<string> { "corrupted" } },
    { "biome_desert", new List<string> { "desert" } },
    { "biome_infernal", new List<string> { "infernal" } },
    { "biome_lemon", new List<string> { "lemon" } },
    { "biome_mushroom", new List<string> { "pink_yellow_mushroom" } },
    { "biome_sand", new List<string> { "dark_orange", "wood" } },
    { "biome_singularity", new List<string> { "bright_violet" } },
    { "biome_garlic", new List<string> { "mid_gray" } },
    { "biome_maple", new List<string> { "dark_orange" } },
    { "biome_permafrost", new List<string> { "polar" } },
    { "biome_rocklands", new List<string> { "gray_black" } },
    { "biome_celestial", new List<string> { "bright_purple" } }
};

Radon.phenotypes_list = new List<string> {
    "dark_red",
    "savanna",
    "dark_orange",
    "swamp",
    "corrupted",
    "desert",
    "infernal",
    "lemon",
    "pink_yellow_mushroom",
    "wood",
    "bright_violet",
    "mid_gray",
    "polar",
    "bright_purple"
};
        Radon.flying = true;
        Radon.very_high_flyer = true;
			Radon.die_on_blocks = false;
			Radon.ignore_blocks = true;
			Radon.move_from_block = false;
			Radon.run_to_water_when_on_fire = false;
 AssetManager.actor_library.add(Radon);
			Localization.addLocalization(Radon.name_locale, Radon.name_locale);



var Mechagodzilla_Boss = AssetManager.kingdoms.clone("Mechagodzilla_Boss", "$TEMPLATE_MOB$");
Mechagodzilla_Boss.concept = false;
Mechagodzilla_Boss.id = "Mechagodzilla_Boss";
Mechagodzilla_Boss.default_kingdom_color = new ColorAsset("#679ead");
Mechagodzilla_Boss.mobs = true;
Mechagodzilla_Boss.always_attack_each_other = true;
Mechagodzilla_Boss.force_look_all_chunks = true;
Mechagodzilla_Boss.units_always_aggressive = true;
Mechagodzilla_Boss.setIcon("ui/icons/Mechagodzilla");
Mechagodzilla_Boss.addTag("sliceable");
Mechagodzilla_Boss.addFriendlyTag("nature_creature");
Mechagodzilla_Boss.addEnemyTag("civ");
Mechagodzilla_Boss.addFriendlyTag("wild_kaiju");
AssetManager.kingdoms.add(Mechagodzilla_Boss);
World.world.kingdoms_wild.newWildKingdom(Mechagodzilla_Boss);

var Mechagodzilla_wild = AssetManager.kingdoms.clone("Mechagodzilla_wild", "$TEMPLATE_ANIMAL$");
Mechagodzilla_wild.concept = false;
Mechagodzilla_wild.id = "Mechagodzilla_wild";
Mechagodzilla_wild.default_kingdom_color = new ColorAsset("#679ead");
Mechagodzilla_wild.setIcon("ui/icons/Mechagodzilla");
Mechagodzilla_wild.addTag("sliceable");
Mechagodzilla_wild.addTag("nature_creature");
Mechagodzilla_wild.addFriendlyTag("nature_creature");
Mechagodzilla_wild.addTag("neutral_animals");
Mechagodzilla_wild.addTag("neutral");
Mechagodzilla_wild.addTag("wild_kaiju");
AssetManager.kingdoms.add(Mechagodzilla_wild);
World.world.kingdoms_wild.newWildKingdom(Mechagodzilla_wild);





          var Mechagodzilla = AssetManager.actor_library.clone("Mechagodzilla", "$mob$");
          Mechagodzilla.is_humanoid = false;
	      Mechagodzilla.civ = false;
          Mechagodzilla.name_locale = "Mechagodzilla";
          Mechagodzilla.animation_speed_based_on_walk_speed = false;
Mechagodzilla.has_avatar_prefab = false;
Mechagodzilla.get_override_avatar_frames = (Actor pActor) => new Sprite[] { SpriteTextureLoader.getSprite("actors/Avatars/Mechagodzilla_avatar") };
Mechagodzilla.has_override_avatar_frames = true;
Mechagodzilla.inspect_avatar_scale = 1f;
Mechagodzilla.inspect_avatar_offset_y = 6f;
          Mechagodzilla.shadow_texture = "unitShadow_6";
          Mechagodzilla.immune_to_slowness = true;
          Mechagodzilla.effect_damage = true;
          Mechagodzilla.unit_other = true;
          Mechagodzilla.collective_term = "group_den";
          Mechagodzilla.default_attack = "base_attack";
          Mechagodzilla.affected_by_dust = false;
          Mechagodzilla.kingdom_id_civilization = string.Empty;
		  Mechagodzilla.build_order_template_id = string.Empty;
          Mechagodzilla.show_on_meta_layer = false;
          Mechagodzilla.show_in_knowledge_window = false;
		  Mechagodzilla.show_in_taxonomy_tooltip = false;
          Mechagodzilla.render_status_effects = true;
          Mechagodzilla.use_phenotypes = false;
          Mechagodzilla.death_animation_angle = true;
          Mechagodzilla.can_be_inspected = true;
          Mechagodzilla.name_template_sets = AssetLibrary<ActorAsset>.a<string>("crocodile_set");
          Mechagodzilla.kingdom_id_wild = "Mechagodzilla_Boss";
          Mechagodzilla.update_z = true;
          Mechagodzilla.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Mechagodzilla.addDecision("random_move_towards_civ_building");
          Mechagodzilla.base_stats["lifespan"] = 200f;
        Mechagodzilla.base_stats["mass_2"] = 100000f;
        Mechagodzilla.base_stats["mass"] = 2000f;
        Mechagodzilla.base_stats["stamina"] = 500f;
        Mechagodzilla.base_stats["scale"] = 0.4f;
        Mechagodzilla.base_stats["size"] = 4f;
        Mechagodzilla.base_stats["health"] = 40000f;
		Mechagodzilla.base_stats["speed"] = 40f;
		Mechagodzilla.base_stats["armor"] = 40f;
		Mechagodzilla.base_stats["attack_speed"] = 0.4f;
		Mechagodzilla.base_stats["damage"] = 1000f;
		Mechagodzilla.base_stats["knockback"] = 4f;
		Mechagodzilla.base_stats["accuracy"] = 1f;
		Mechagodzilla.base_stats["targets"] = 10f;
		Mechagodzilla.base_stats["area_of_effect"] = 5f;
		Mechagodzilla.base_stats["range"] = 2f;
		Mechagodzilla.base_stats["critical_damage_multiplier"] = 10f;
		Mechagodzilla.base_stats["multiplier_supply_timer"] = 1f;
          Mechagodzilla.disable_jump_animation = true;
          Mechagodzilla.can_be_moved_by_powers = true;
          Mechagodzilla.actor_size = ActorSize.S16_Buffalo;
        Mechagodzilla.animation_walk = Kaiju.walk_0_5;
        Mechagodzilla.animation_idle = ActorAnimationSequences.walk_0;
		Mechagodzilla.animation_swim = Kaiju.swim_0_5;
          Mechagodzilla.can_flip = true;
          Mechagodzilla.check_flip = (BaseSimObject _, WorldTile _) => true;
          Mechagodzilla.texture_asset = new ActorTextureSubAsset("actors/Mechagodzilla/", false);
          Mechagodzilla.icon = "Mechagodzilla";
          Mechagodzilla.die_in_lava = false;
          Mechagodzilla.visible_on_minimap = true;
          Mechagodzilla.experience_given = 1000000;
          Mechagodzilla.can_have_subspecies = false;
          Mechagodzilla.affected_by_dust = false;
          Mechagodzilla.inspect_children = false;
          Mechagodzilla.special = true;
          Mechagodzilla.has_advanced_textures = false;
          Mechagodzilla.inspect_sex = false;
		  Mechagodzilla.inspect_show_species = false;
		  Mechagodzilla.inspect_generation = false;
          Mechagodzilla.needs_to_be_explored = false;
          Mechagodzilla.force_land_creature = true;
		  Mechagodzilla.color_hex = "#679ead";
          Mechagodzilla.addTrait("Mechagodzilla_Power");
          Mechagodzilla.addTrait("tough");
          Mechagodzilla.addResource("adamantine", 100);
		Mechagodzilla.addResource("gold", 2000);
 AssetManager.actor_library.add(Mechagodzilla);
			Localization.addLocalization(Mechagodzilla.name_locale, Mechagodzilla.name_locale);


BuildingAsset Mechagodzilla_remains = AssetManager.buildings.clone("Mechagodzilla_remains", "$mineral$");
Mechagodzilla_remains.base_stats["health"] = 100000f;
Mechagodzilla_remains.smoke = true;
Mechagodzilla_remains.smoke_interval = 2.5f;
Mechagodzilla_remains.smoke_offset = new Vector2Int(2, 3);
Mechagodzilla_remains.produce_biome_food = true;
Mechagodzilla_remains.sprite_path = "buildings/Mechagodzilla_remains";
Mechagodzilla_remains.setShadow(0.5f, 0.23f, 0.27f);
Mechagodzilla_remains.addResource("bones", 200);
Mechagodzilla_remains.addResource("common_metals", 300);
Mechagodzilla_remains.addResource("adamantine", 30);
  Mechagodzilla_remains.has_sprites_main = true;
  Mechagodzilla_remains.has_sprites_ruin = false;
  Mechagodzilla_remains.has_sprites_main_disabled = false;
  Mechagodzilla_remains.has_sprites_special = false;
  Mechagodzilla_remains.atlas_asset = AssetManager.dynamic_sprites_library.get("buildings");
AssetManager.buildings.add(Mechagodzilla_remains);
PreloadHelpers.loadBuildingSprites(Mechagodzilla_remains);



 var Mecha_egg = AssetManager.subspecies_traits.clone("Mecha_egg", "$egg$");
Mecha_egg.rarity = Rarity.R0_Normal;
Mecha_egg.id = "Mecha_egg";
Mecha_egg.id_egg = "Mecha_egg";
Mecha_egg.group_id = "eggs";
Mecha_egg.phenotype_egg = true;
Mecha_egg.base_stats_meta["maturation"] = 50f;
Mecha_egg.sprite_path = "eggs/Mecha_egg";
Mecha_egg.path_icon = "ui/icons/Mecha_egg";
AssetManager.subspecies_traits.add(Mecha_egg);
Localization.AddOrSet("subspecies_trait_Mecha_egg", "Mechagodzilla Egg");
Localization.AddOrSet("subspecies_trait_Mecha_egg_info", "A mysterious egg, rumored to hatch a kaiju.");
Localization.AddOrSet("subspecies_trait_Mecha_egg_suggested_species", "Guidorahhead");

          var Guidorahhead = AssetManager.actor_library.clone("Guidorahhead", "$mob$");
          Guidorahhead.is_humanoid = false;
	      Guidorahhead.civ = false;
          Guidorahhead.name_locale = "Guidorahhead";
          Guidorahhead.animation_speed_based_on_walk_speed = false;
          Guidorahhead.has_avatar_prefab = false;
          Guidorahhead.inspect_avatar_scale = 0.4f;
          Guidorahhead.inspect_avatar_offset_y = -4f;
          Guidorahhead.shadow_texture = "unitShadow_6";
          Guidorahhead.immune_to_slowness = true;
          Guidorahhead.effect_damage = true;
          Guidorahhead.unit_other = true;
          Guidorahhead.collective_term = "group_den";
          Guidorahhead.setSocialStructure("group_den", 10);
          Guidorahhead.default_attack = "base_attack";
          Guidorahhead.affected_by_dust = true;
          Guidorahhead.inspect_children = true;
          Guidorahhead.kingdom_id_civilization = string.Empty;
		  Guidorahhead.build_order_template_id = string.Empty;
          Guidorahhead.show_on_meta_layer = true;
          Guidorahhead.show_in_knowledge_window = true;
		  Guidorahhead.show_in_taxonomy_tooltip = true;
          Guidorahhead.render_status_effects = true;
          Guidorahhead.use_phenotypes = true;
          Guidorahhead.death_animation_angle = true;
          Guidorahhead.can_be_inspected = true;
          Guidorahhead.name_template_sets = AssetLibrary<ActorAsset>.a<string>("crocodile_set");
          Guidorahhead.kingdom_id_wild = "Mechagodzilla_wild";
          Guidorahhead.update_z = true;
          Guidorahhead.job = AssetLibrary<ActorAsset>.a<string>("attacker");
          Guidorahhead.base_stats["lifespan"] = 100f;
        Guidorahhead.base_stats["mass_2"] = 1000f;
        Guidorahhead.base_stats["mass"] = 20f;
        Guidorahhead.base_stats["stamina"] = 500f;
        Guidorahhead.base_stats["scale"] = 0.1f;
        Guidorahhead.base_stats["size"] = 1f;
        Guidorahhead.base_stats["health"] = 500f;
		Guidorahhead.base_stats["speed"] = 40f;
		Guidorahhead.base_stats["armor"] = 40f;
		Guidorahhead.base_stats["attack_speed"] = 0.4f;
		Guidorahhead.base_stats["damage"] = 30f;
		Guidorahhead.base_stats["knockback"] = 2f;
		Guidorahhead.base_stats["accuracy"] = 1f;
		Guidorahhead.base_stats["targets"] = 3f;
		Guidorahhead.base_stats["area_of_effect"] = 2f;
		Guidorahhead.base_stats["range"] = 1f;
		Guidorahhead.base_stats["critical_damage_multiplier"] = 10f;
		Guidorahhead.base_stats["multiplier_supply_timer"] = 1f;
          Guidorahhead.disable_jump_animation = true;
          Guidorahhead.can_be_moved_by_powers = true;
          Guidorahhead.actor_size = ActorSize.S16_Buffalo;
        Guidorahhead.animation_walk = ActorAnimationSequences.walk_0_2;
        Guidorahhead.animation_idle = ActorAnimationSequences.walk_0;
		Guidorahhead.animation_swim = ActorAnimationSequences.swim_0_2;
          Guidorahhead.can_flip = true;
          Guidorahhead.check_flip = (BaseSimObject _, WorldTile _) => true;
          Guidorahhead.texture_asset = new ActorTextureSubAsset("actors/Guidorahhead/", false);
          Guidorahhead.icon = "Guidorahhead";
          Guidorahhead.die_in_lava = false;
          Guidorahhead.visible_on_minimap = false;
          Guidorahhead.has_baby_form = false;
          Guidorahhead.experience_given = 20;
          Guidorahhead.can_have_subspecies = true;
          Guidorahhead.affected_by_dust = false;
          Guidorahhead.special = true;
          Guidorahhead.has_advanced_textures = false;
          Guidorahhead.inspect_sex = true;
		  Guidorahhead.inspect_show_species = true;
		  Guidorahhead.inspect_generation = true;
          Guidorahhead.needs_to_be_explored = false;
          Guidorahhead.force_land_creature = true;
          Guidorahhead.addGenome(("health", 80f), ("stamina", 120f), ("mutation", 1f), ("speed", 12f), ("lifespan", 80f), ("damage", 20f), ("armor", 15f), ("offspring", 2f));
          Guidorahhead.addSubspeciesTrait("stomach");
          Guidorahhead.addSubspeciesTrait("reproduction_parthenogenesis");
          Guidorahhead.addSubspeciesTrait("reproduction_strategy_oviparity");
        Guidorahhead.addSubspeciesTrait("diet_hematophagy");
        Guidorahhead.addSubspeciesTrait("death_grow_mythril");
        Guidorahhead.addSubspeciesTrait("gift_of_thunder");
      Guidorahhead.addSubspeciesTrait("long_lifespan");
        Guidorahhead.addSubspeciesTrait("Mecha_egg");
       Guidorahhead.addSubspeciesTrait("population_minimal");
       Guidorahhead.addSubspeciesTrait("photosynthetic_skin");
		Guidorahhead.addSubspeciesTrait("parental_care");
        Guidorahhead.addSubspeciesTrait("heat_resistance");
          Guidorahhead.animal_breeding_close_units_limit = 4;
          Guidorahhead.can_evolve_into_new_species = false;
		  Guidorahhead.color_hex = "#679ead";
          Guidorahhead.addTrait("tough");
          Guidorahhead.name_taxonomic_kingdom = "robotica";
		Guidorahhead.name_taxonomic_phylum = "necromanticus";
		Guidorahhead.name_taxonomic_class = "craniata";
		Guidorahhead.name_taxonomic_order = "mechmech";
		Guidorahhead.name_taxonomic_family = "droida";
		Guidorahhead.name_taxonomic_genus = "RogueControlSystem";
        Guidorahhead.addResource("adamantine", 2);
		Guidorahhead.addResource("gold", 10);
        Guidorahhead.source_meat = true;
Guidorahhead.phenotypes_dict = new Dictionary<string, List<string>>() {
    { "default_color", new List<string> { "bright_yellow" } },
    { "biome_savanna", new List<string> { "savanna", "dark_orange" } },
    { "biome_swamp", new List<string> { "swamp" } },
    { "biome_corrupted", new List<string> { "corrupted" } },
    { "biome_desert", new List<string> { "desert" } },
    { "biome_infernal", new List<string> { "infernal" } },
    { "biome_lemon", new List<string> { "lemon" } },
    { "biome_mushroom", new List<string> { "pink_yellow_mushroom" } },
    { "biome_sand", new List<string> { "dark_orange", "wood" } },
    { "biome_singularity", new List<string> { "bright_violet" } },
    { "biome_garlic", new List<string> { "mid_gray" } },
    { "biome_maple", new List<string> { "dark_orange" } },
    { "biome_permafrost", new List<string> { "polar" } },
    { "biome_rocklands", new List<string> { "gray_black" } },
    { "biome_celestial", new List<string> { "bright_purple" } }
};

Guidorahhead.phenotypes_list = new List<string> {
    "bright_yellow",
    "savanna",
    "dark_orange",
    "swamp",
    "corrupted",
    "desert",
    "infernal",
    "lemon",
    "pink_yellow_mushroom",
    "wood",
    "bright_violet",
    "mid_gray",
    "polar",
    "bright_purple"
};
 AssetManager.actor_library.add(Guidorahhead);
			Localization.addLocalization(Guidorahhead.name_locale, Guidorahhead.name_locale);


          }


public static readonly string[] idle_0 = Toolbox.a<string>("idle_0");

public static readonly string[] idle_0_6 = Toolbox.a<string>("idle_0", "idle_1", "idle_2", "idle_3", "idle_4", "idle_5", "idle_6" );

public static readonly string[] walk_0_5 = Toolbox.a<string>("walk_0", "walk_1", "walk_2", "walk_3", "walk_4", "walk_5" );

public static readonly string[] swim_0_5 = Toolbox.a<string>("swim_0", "swim_1", "swim_2", "swim_3", "swim_4", "swim_5" );



	public static BaseEffect spawnAtTile(string pID, WorldTile pTile, float pScale)
	{
		BaseEffect tEffect = spawn(pID, pTile);
		if (tEffect == null)
		{
			return null;
		}
		tEffect.prepare(pTile, pScale);
		return tEffect;
	}

public static BaseEffect spawn(string pID, WorldTile pTile = null, string pParam1 = null, string pParam2 = null, float pFloatParam1 = 0f, float pX = -1f, float pY = -1f, Actor pActor = null)
	{
		BaseEffect tEffect = check(pID);
		if (tEffect == null)
		{
			return null;
		}
		EffectAsset tAsset = AssetManager.effects_library.get(pID);
		if (tAsset.spawn_action != null)
		{
			tAsset.spawn_action(tEffect, pTile, pParam1, pParam2, pFloatParam1, pActor);
		}
		if (tAsset.has_sound_launch)
		{
			float tX = pX;
			float tY = pY;
			if (pTile != null && tX == -1f && tY == -1f)
			{
				tX = pTile.x;
				tY = pTile.y;
			}
			MusicBox.playSound(tAsset.sound_launch, tX, tY);
		}
		if (pX != -1f && pY != -1f)
		{
			tEffect.transform.position = new Vector3(pX, pY, 0f);
		}
		if (tAsset.has_sound_loop_idle)
		{
			tEffect.fmod_instance = MusicBox.attachToObject(tAsset.sound_loop_idle, tEffect.gameObject, tEffect);
		}
		return tEffect;
	}

private static BaseEffect check(string pID)
	{
		EffectAsset tAsset = AssetManager.effects_library.get(pID);
		if (tAsset == null)
		{
			return null;
		}
		if (tAsset.cooldown_interval > 0.0 && tAsset.checkIsUnderCooldown())
		{
			return null;
		}
		if (!tAsset.show_on_mini_map && MapBox.isRenderMiniMap())
		{
			return null;
		}
		return World.world.stack_effects.get(pID).spawnNew();
	}









    }
}
