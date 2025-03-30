using HarmonyLib;
using RimWorld;
using Verse;

namespace AAD;

[HarmonyPatch(typeof(ReliquaryUtility), "IsRelic")]
public class ReliquaryUtility_IsRelic_Patch
{
    public static void Postfix(ref bool __result, Thing thing)
    {
        if (thing.def == DuckDefOf.AAD_AlmightyAchievementDuck && ModsConfig.IdeologyActive)
        {
            __result = true;
        }
    }
}