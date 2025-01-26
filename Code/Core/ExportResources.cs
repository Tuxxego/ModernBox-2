// this is copy pasted from ancient warfare mod


using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.IO;
using M2;

using UnityEngine.Tilemaps;
using Newtonsoft.Json;
using System.IO.Compression;

public static class ExportResources
{
    public static JsonTilesDataDefault defaultMaterial = null;

    public class JsonTilesData
    {
        public Dictionary<string, string> tiles { get; set; }
        public Dictionary<string, string> topTiles { get; set; }
    }

    public class JsonTilesDataDefault
    {
        public Dictionary<string, Color32> tiles = new();
        public Dictionary<string, Color32> topTiles = new();
    }

    public static void loadMaterial()
    {
        string materialPath = Application.persistentDataPath + "/material";

        if (!Directory.Exists(materialPath))
        {
            Directory.CreateDirectory(materialPath);
            init_materialPack(materialPath);
        }

        string[] files = Directory.GetDirectories(materialPath);
        if (files.Length == 0)
        {
            init_materialPack(materialPath);
        }

        string materialName = "ass";
        string materialPath2 = Path.Combine(materialPath, materialName);
        Toolbox.color_ocean = Toolbox.makeColor("#3370CC", -1f);
        if (materialName == "default" || string.IsNullOrEmpty(materialName))
        {
            WorldTip.showNow("材质包名称为默认");
            if (defaultMaterial != null)
            {
                foreach (var tile in AssetManager.tiles.list)
                {
                    if (defaultMaterial.tiles.TryGetValue(tile.id, out var tile2))
                    {
                        tile.color = tile2;
                    }
                }
                foreach (var tile in AssetManager.topTiles.list)
                {
                    if (defaultMaterial.topTiles.TryGetValue(tile.id, out var tile2))
                    {
                        tile.color = tile2;
                    }
                }
                if (World.world.tilesMap != null)
                {
                    foreach (var tile in World.world.tilesMap)
                    {
                        World.world.updateDirtyTile(tile);
                    }
                }
            }
            return;
        }
        if (Directory.Exists(materialPath2))
        {
            string colorFilePath = Path.Combine(materialPath2, "color.json");

            if (File.Exists(colorFilePath))
            {
                string jsonText = File.ReadAllText(colorFilePath);
                if (string.IsNullOrEmpty(jsonText))
                {
                    WorldTip.showNow("color.json 文件为空");
                }

                JsonTilesData colorData = JsonConvert.DeserializeObject<JsonTilesData>(jsonText);
                if (defaultMaterial == null)
                {
                    defaultMaterial = new();
                    foreach (var tile in AssetManager.tiles.list)
                    {
                        defaultMaterial.tiles.Add(tile.id, tile.color);
                    }
                    foreach (var tile in AssetManager.topTiles.list)
                    {
                        defaultMaterial.topTiles.Add(tile.id, tile.color);
                    }
                }
                foreach (var tile in AssetManager.tiles.list)
                {
                    if (colorData.tiles.TryGetValue(tile.id, out var tile2))
                    {
                        tile.color = (Color32)Toolbox.makeColor(tile2);
                        if (tile.id == ST.deep_ocean)
                        {
                            Toolbox.color_ocean = tile.color;
                        }
                    }
                }
                foreach (var tile in AssetManager.topTiles.list)
                {
                    if (colorData.topTiles.TryGetValue(tile.id, out var tile2))
                    {
                        tile.color = (Color32)Toolbox.makeColor(tile2);
                    }
                }
                if (World.world.tilesMap != null)
                {
                    foreach (var tile in World.world.tilesMap)
                    {
                        World.world.updateDirtyTile(tile);
                    }
                }

                WorldTip.showNow("载入成功");
            }
            else
            {
                WorldTip.showNow("color.json 文件不存在!");
            }
        }
        else
        {
            WorldTip.showNow("指定的材质包路径不存在: " + materialPath2);
        }

        return;
    }

    public static void init_materialPack(string materialPath)
    {
        string zipFilePath = $"{Mod.Info.Path}/material.zip";
        string targetDirectory = materialPath;

        if (File.Exists(zipFilePath) && Directory.Exists(targetDirectory))
        {
            ZipFile.ExtractToDirectory(zipFilePath, targetDirectory, true);
        }
    }

    public static void init_LoadingScreen(string path)
    {
        string zipFilePath =
            $"{Mod.Info.Path}/EmbededResources/LoadingScreen/backgroundImage/LoadingScreen.zip";
        string targetDirectory = path;

        if (File.Exists(zipFilePath) && Directory.Exists(targetDirectory))
        {
            ZipFile.ExtractToDirectory(zipFilePath, targetDirectory, true);
        }
    }

    public static void ExportAllTiles()
    {
        string resourcePath = "tiles";
        string exportPath = Application.persistentDataPath + "/material/default";

        // 确保导出文件夹存在
        if (!Directory.Exists(exportPath))
        {
            Directory.CreateDirectory(exportPath);
        }

        foreach (TileType pType in AssetManager.tiles.list)
        {
            Sprite[] sprites = Resources.LoadAll<Sprite>(Path.Combine(resourcePath, pType.id));

            if (sprites != null)
            {
                foreach (Sprite sprite in sprites)
                {
                    Sprite selectedSprite = sprite;
                    if (selectedSprite == null)
                    {
                        Debug.LogError("Please select a Sprite object in the Unity Editor.");
                        return;
                    }

                    // 获取Sprite的Texture
                    Texture2D texture = selectedSprite.texture;
                    if (texture is Texture2D)
                    {
                        //    Debug.Log(texture.width + "  " + texture.height);
                        // 将Texture转换为可读写格式
                        Texture2D readableTexture = new Texture2D(
                            texture.width,
                            texture.height,
                            TextureFormat.ARGB32,
                            false
                        );
                        // 从原始Texture中获取像素数据
                        readableTexture.SetPixels32(selectedSprite.texture.GetPixels32());
                        // 应用像素数据
                        readableTexture.Apply();

                        // 导出路径，这里使用项目的PersistentDataPath来存储图片
                        string path = Path.Combine(exportPath, pType.id);
                        if (!Directory.Exists(path))
                        {
                            Directory.CreateDirectory(path);
                        }
                        path = Path.Combine(path, sprite.name + ".png");
                        // 将Texture2D保存为PNG图片
                        File.WriteAllBytes(path, readableTexture.EncodeToPNG());

                        Debug.Log("Sprite exported successfully: " + path);
                    }
                    else
                    {
                        Debug.LogError("The texture of the sprite is not a Texture2D.");
                    }
                }
            }
            else
            {
                Debug.LogError("No sprites found in the specified folder.");
            }
        }
    }
}
