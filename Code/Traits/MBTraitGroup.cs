//========= MODERNBOX 2.1.0.1 ============//
//
// Made by Tuxxego
//
//=============================================================================//
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReflectionUtility;
namespace M2
{
    class MBTraitGroup
    {
 
        public static string ModernBox = "ModernBox";
        public static string IdeologiesBox = "IdeologiesBox";
        public static void init()
        {
 
            ActorTraitGroupAsset ModernBox = new ActorTraitGroupAsset();
            ModernBox.id = "ModernBox";
            ModernBox.name = "trait_group_ModernBox";
            ModernBox.color = Toolbox.makeColor("#FFFF00", -1f);
            AssetManager.trait_groups.add(ModernBox);
            addTraitGroupToLocalizedLibrary(ModernBox.id, "ModernBox");


            ActorTraitGroupAsset IdeologiesBox = new ActorTraitGroupAsset();
            IdeologiesBox.id = "IdeologiesBox";
            IdeologiesBox.name = "trait_group_IdeologiesBox";
            IdeologiesBox.color = Toolbox.makeColor("#FFFF00", -1f);
            AssetManager.trait_groups.add(IdeologiesBox);
            addTraitGroupToLocalizedLibrary(IdeologiesBox.id, "IdeologiesBox");


        }
        private static void addTraitGroupToLocalizedLibrary(string id, string name)
        {
            string language = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "language") as string;
            Dictionary<string, string> localizedText = Reflection.GetField(LocalizedTextManager.instance.GetType(), LocalizedTextManager.instance, "localizedText") as Dictionary<string, string>;
            localizedText.Add("trait_group_" + id, name);
        }
    }
}
