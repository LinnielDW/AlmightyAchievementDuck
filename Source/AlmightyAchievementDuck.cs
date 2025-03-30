using System.Reflection;
using AAD.Settings;
using HarmonyLib;
using UnityEngine;
using Verse;

namespace AAD;

public class AlmightyAchievementDuck : Mod
{
    public static AlmightyAchievementDuckSettings settings;

    public AlmightyAchievementDuck(ModContentPack content) : base(content)
    {
        settings = GetSettings<AlmightyAchievementDuckSettings>();
        
        var harmony = new Harmony("com.arquebus.rimworld.mod.almightyachievementduck");
        harmony.PatchAll(Assembly.GetExecutingAssembly());
    }

    public override string SettingsCategory()
    {
        return "AAD_SettingsTitle".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        settings.DoSettingsWindowContents(inRect);
    }
}

public class DuckShaderTypeDef : ShaderTypeDef
{
    public override void PostLoad()
    {
        if (!shaderPath.NullOrEmpty())
            LongEventHandler.ExecuteWhenFinished(delegate
            {
                Log.Message("Loading shader at path: " + shaderPath);
                ShaderDatabase.lookup[shaderPath] = modContentPack.assetBundles
                    .loadedAssetBundles[0].LoadAsset<Shader>(shaderPath);

                Log.Message("Shader " + ShaderDatabase.lookup[shaderPath] + " loaded");
            });
    }
}