using System;
using UnityEngine;

namespace M2
{
    class biomewaves : MonoBehaviour
    {
        public static void init()
        {


EffectAsset fogjungle = new EffectAsset
{
    id = "fogjungle",
    use_basic_prefab = true,
    sprite_path = "effects/fogjungle",
    draw_light_area = false,
    draw_light_size = 0.5f,
    show_on_mini_map = false,
    limit = 30,
    sorting_layer_id = "EffectsTop"
};
fogjungle.spawn_action = new EffectAction(spawnSimpleTile);
AssetManager.effects_library.add(fogjungle);


            WorldBehaviourAsset fogjungle1 = new WorldBehaviourAsset();
            fogjungle1.id = "fogjungle1";
            fogjungle1.enabled_on_minimap = false;
            fogjungle1.interval = 0.7f;
            fogjungle1.interval_random = 0.7f;
            fogjungle1.action = new WorldBehaviourAction(FogWave.startWaves);
            fogjungle1.manager = new WorldBehaviour(fogjungle1);
            AssetManager.world_behaviours.add(fogjungle1);


        }

        public static BaseEffect spawnSimpleTile(BaseEffect pEffect, WorldTile pTile, string pParam1 = null, string pParam2 = null, float pFloatParam1 = 0f)
        {
            pEffect.spawnOnTile(pTile);
            pEffect.transform.localScale = new Vector3(0.5f / 2, 0.5f / 2, 0.5f / 2);

            return pEffect;
        }
    }
}
