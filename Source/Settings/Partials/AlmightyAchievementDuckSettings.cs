using RimWorld;
using UnityEngine;
using Verse;

namespace AlmightyAchievementDuck.Settings;

public partial class AlmightyAchievementDuckSettings
{
    private static Vector2 scrollPosition = Vector2.zero;
    private float lastDrawnHeight;

    public void DoSettingsWindowContents(Rect inRect)
    {
        var listingStandard = new Listing_Standard();
        listingStandard.Begin(inRect);


        var resetRect = new Rect(0f, listingStandard.CurHeight,
            (listingStandard.ColumnWidth * 0.25f) - 6f, 30f);
        if (Widgets.ButtonText(resetRect,
                "AlmightyAchievementDuck_ResetCats".Translate()))
        {
            ResetCats();
            Write();
        }

        listingStandard.Gap(32f);

        listingStandard.Label("AlmightyAchievementDuck_UseCategory".Translate());


        var viewRect = new Rect(inRect.x, listingStandard.CurHeight, inRect.width,
            inRect.height - listingStandard.CurHeight);
        var scrollRect = new Rect(viewRect.x, viewRect.y, viewRect.width - 32f,
            lastDrawnHeight);

        // DrawBoxSolid(viewRect, Color.red);
        // DrawBoxSolid(scrollRect, Color.green);

        var scrollable = scrollRect.height > viewRect.height;
        if (scrollable)
        {
            Widgets.BeginScrollView(viewRect, ref scrollPosition, scrollRect);
        }
        else
        {
            scrollPosition = Vector2.zero;
        }

        var listingTree = new Listing_Tree_ThingCategories();
        listingTree.ColumnWidth = (scrollRect.width - 17f) / 2;

        var treeRect = new Rect(inRect.x, listingStandard.CurHeight, inRect.width - 16f,
            scrollRect.height);

        // DrawBoxSolid(treeRect, Color.cyan);

        listingTree.Begin(treeRect);
        foreach (var child in ThingCategoryDefOf.Root.childCategories)
        {
            listingTree.DoCategory(child.treeNode, 0, 32);
        }

        listingTree.End();

        if (scrollable)
        {
            Widgets.EndScrollView();
        }

        // Widgets.EndGroup();
        lastDrawnHeight = listingTree.CurHeight;
        listingStandard.End();
    }
}