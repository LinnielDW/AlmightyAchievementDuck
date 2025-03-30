using System.Collections.Generic;
using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace AAD;

public static class AchievementDuckUtils
{
    public static readonly CachedTexture DuckGizmoTexture = new("duckascend");
}

public class AchievementDuckThingClass : ThingWithComps
{
    public override void SpawnSetup(Map map, bool respawningAfterLoad)
    {
        base.SpawnSetup(map, respawningAfterLoad);
        Log.Message(Graphic.data.graphicClass);
        Log.Message(Graphic.Shader);
        Log.Message(Graphic.data.shaderType);

        foreach (var shaderParameter in Graphic.data.shaderParameters)
        {
            Log.Message(shaderParameter.name);
            Log.Message(shaderParameter.value);
        }
        // Graphic.Shader.property
    }

    public override IEnumerable<Gizmo> GetGizmos()
    {
        foreach (Gizmo gizmo in base.GetGizmos())
        {
            yield return gizmo;
        }

        yield return new Command_Action
        {
            defaultLabel = "AAD_GizmoLabel".Translate(),
            defaultDesc = "AAD_GizmoDesc".Translate(),
            icon = AchievementDuckUtils.DuckGizmoTexture.Texture,
            action = delegate
            {
                GameVictoryUtility.ShowCredits(MakeDuckminionCredits(),
                    SongDefOf.EndCreditsSong);
            }
        };
    }

    public static string MakeDuckminionCredits()
    {
        StringBuilder stringBuilder = new StringBuilder();
        stringBuilder.Append("AAD_AchieveDuckminion_pt1".Translate());

        stringBuilder.AppendLine();
        stringBuilder.AppendLine();
        stringBuilder.Append("AAD_AchieveDuckminion_pt2".Translate());
        
        MakeWitnessedDuck(stringBuilder);

        MakeInMemoryOfDuck(stringBuilder);
        
        stringBuilder.AppendLine();
        stringBuilder.AppendLine();
        stringBuilder.AppendLine();
        stringBuilder.Append("AAD_AchieveDuckminion_pt3".Translate());
        return stringBuilder.ToString();
    }

    private static void MakeInMemoryOfDuck(StringBuilder stringBuilder)
    {
        var deadPawns = Find.WorldPawns.AllPawnsDead.Where(p => p.IsColonist).ToList();
        if (!deadPawns.Any()) return;

        stringBuilder.AppendLine();
        stringBuilder.AppendLine("AAD_ColonistsDead".Translate());
        foreach (var pawn in deadPawns)
        {
            stringBuilder.AppendLine("   " + pawn.LabelCap);
        }
    }

    private static void MakeWitnessedDuck(StringBuilder stringBuilder)
    {
        if (!PawnsFinder.AllMaps_FreeColonists.Any()) return;

        stringBuilder.AppendLine();
        stringBuilder.AppendLine();
        stringBuilder.AppendLine("AAD_ColonistsAlive".Translate());
        foreach (Pawn pawn in PawnsFinder.AllMaps_FreeColonists)
        {
            stringBuilder.AppendLine("   " + pawn.LabelCap);
        }
    }
}