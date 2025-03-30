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
    // public override void SpawnSetup(Map map, bool respawningAfterLoad)
    // {
    //     base.SpawnSetup(map, respawningAfterLoad);
    //     Log.Message(Graphic.data.graphicClass);
    //     Log.Message(Graphic.Shader);
    //     Log.Message(Graphic.data.shaderType);
    //     Log.Message("Color" + Graphic.data.color);
    //     Log.Message("Color2" + Graphic.data.colorTwo);
    //
    //     foreach (var shaderParameter in Graphic.data.shaderParameters)
    //     {
    //         Log.Message(shaderParameter.name);
    //         Log.Message(shaderParameter.value);
    //     }
    // }

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
                GameVictoryUtility.ShowCredits(AchievementDuckCreditUtils.MakeDuckminionCredits(),
                    SongDefOf.EndCreditsSong);
            }
        };
    }
}