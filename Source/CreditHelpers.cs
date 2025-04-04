﻿using System.Linq;
using System.Text;
using RimWorld;
using Verse;

namespace AAD;

public static class AchievementDuckCreditUtils
{
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