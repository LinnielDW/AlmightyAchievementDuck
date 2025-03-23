global using static AlmightyAchievementDuck.AlmightyAchievementDuck;
using System.Linq;
using UnityEngine;
using Verse;


namespace AlmightyAchievementDuck;

public class AlmightyAchievementDuck : Mod
{
    public static AlmightyAchievementDuckSettings settings;

    public AlmightyAchievementDuck(ModContentPack content) : base(content)
    {
        settings = GetSettings<AlmightyAchievementDuckSettings>();
    }

    public override string SettingsCategory()
    {
        return "AlmightyAchievementDuck_SettingsTitle".Translate();
    }

    public override void DoSettingsWindowContents(Rect inRect)
    {
        base.DoSettingsWindowContents(inRect);
        settings.DoSettingsWindowContents(inRect);
    }
}