using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AlmightyAchievementDuck;

public partial class AlmightyAchievementDuckSettings : ModSettings
{
    private static Dictionary<string, bool> UseCategoryDefSettings = new();

    private List<string> _useCategoryDefNames;
    private List<bool> _boolValues;

    public override void ExposeData()
    {
        base.ExposeData();
        Scribe_Collections.Look(ref UseCategoryDefSettings, "UseCategoryDefSettings",
            LookMode.Value, LookMode.Value, ref _useCategoryDefNames, ref _boolValues,
            true);

        if (Scribe.mode == LoadSaveMode.LoadingVars)
        {
            UseCategoryDefSettings ??= new Dictionary<string, bool>();
        }
    }

    public static bool GetOrCreateUseCategorySetting(string categoryDefName)
    {
        bool settingsValue;
        if (UseCategoryDefSettings.ContainsKey(categoryDefName))
        {
            settingsValue = UseCategoryDefSettings.TryGetValue(categoryDefName, true);
        }
        else
        {
            if (DuckDefaults.DefaultCats.TryGetValue(categoryDefName,
                    out var defaultEnabledValue))
            {
                SetUseCatDefSettingCascading(
                    DefDatabase<ThingCategoryDef>.GetNamed(categoryDefName),
                    defaultEnabledValue);
                settingsValue = false;
            }
            else
            {
                settingsValue = true;
            }
        }

        return settingsValue;
    }

    private static void ResetCats()
    {
        foreach (var categoryDef in ThingCategoryDefOf.Root.childCategories)
        {
            SetUseCatDefSettingCascading(categoryDef, true);
        }

        foreach (var defaultCatSetting in DuckDefaults.DefaultCats)
        {
            SetUseCatDefSettingCascading(
                DefDatabase<ThingCategoryDef>.GetNamed(defaultCatSetting.Key),
                defaultCatSetting.Value);
        }
    }

    public static void SetUseCatDefSettingCascading(ThingCategoryDef thingCategoryDef,
        bool enabledSetting)
    {
        UseCategoryDefSettings[thingCategoryDef.defName] = enabledSetting;
        foreach (var childCat in thingCategoryDef.childCategories)
        {
            UseCategoryDefSettings[childCat.defName] = enabledSetting;
            SetUseCatDefSettingCascading(childCat, enabledSetting);
        }
    }
}