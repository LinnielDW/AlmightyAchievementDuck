using AAD.Settings;
using UnityEngine;
using Verse;

namespace AAD;

public class AlmightyAchievementDuck : Mod
{
    public static AlmightyAchievementDuckSettings settings;

    public AlmightyAchievementDuck(ModContentPack content) : base(content)
    {
        settings = GetSettings<AlmightyAchievementDuckSettings>();
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