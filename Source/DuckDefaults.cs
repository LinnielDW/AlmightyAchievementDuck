using System.Collections.Generic;
using RimWorld;
using Verse;

namespace AlmightyAchievementDuck;

[StaticConstructorOnStartup]
public static class DuckDefaults
{
    public static readonly Dictionary<string, bool> DefaultCats = new()
    {
        { ThingCategoryDefOf.MeatRaw.defName, false },
        { ThingCategoryDefOf.Leathers.defName, false },
        { ThingCategoryDefOf.Wools.defName, false },
        { ThingCategoryDefOf.Techprints.defName, false },
        { ThingCategoryDefOf.Neurotrainers.defName, false },
        { ThingCategoryDefOf.NeurotrainersPsycast.defName, false },
        { ThingCategoryDefOf.NeurotrainersSkill.defName, false },
        { ThingCategoryDefOf.Corpses.defName, false },
        { ThingCategoryDefOf.EggsFertilized.defName, false },
        { ThingCategoryDefOf.EggsUnfertilized.defName, false },
        { ThingCategoryDefOf.Buildings.defName, false },
        { DuckDefOf.Plants.defName, false },
        { DuckDefOf.Stumps.defName, false },
        { DuckDefOf.InertRelics.defName, false },
        { DuckDefOf.Unfinished.defName, false }
    };
}