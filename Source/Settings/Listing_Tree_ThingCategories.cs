using UnityEngine;
using Verse;

namespace AAD.Settings;

public class Listing_Tree_ThingCategories : Listing_Tree
{
    private Texture2D SolidCategoryBG =
        SolidColorMaterials.NewSolidColorTexture(new Color(0.1f, 0.1f, 0.1f, 0.6f));

    public void DoCategory(TreeNode_ThingCategory node, int nestLevel, int openMask)
    {
        if (!node.ChildCategoryNodes.EnumerableNullOrEmpty())
        {
            OpenCloseWidget(node, nestLevel, openMask);
        }

        var hoverRect = new Rect(0f, curY, LabelWidth, lineHeight)
        {
            xMin = XAtIndentLevel(nestLevel) + 18f
        };

        var backgroundRect = hoverRect;
        backgroundRect.width = 80f;
        backgroundRect.yMax -= 3f;
        backgroundRect.yMin += 3f;
        GUI.DrawTexture(backgroundRect, SolidCategoryBG);
        if (Mouse.IsOver(hoverRect))
        {
            GUI.DrawTexture(hoverRect, TexUI.HighlightTex);
        }

        if (Mouse.IsOver(hoverRect))
        {
            TooltipHandler.TipRegion(hoverRect,
                new TipSignal(node.catDef.LabelCap, node.catDef.GetHashCode()));
        }

        var labelRect = new Rect(hoverRect)
        {
            height = 28f
        };
        labelRect.y = hoverRect.y + hoverRect.height / 2f - labelRect.height / 2f;

        var enabledSetting = AlmightyAchievementDuckSettings.GetOrCreateUseCategorySetting(node.catDef.defName);
        var oldSetting = enabledSetting;
        Widgets.CheckboxLabeled(labelRect, node.catDef.label, ref enabledSetting);
        if (enabledSetting != oldSetting)
        {
            AlmightyAchievementDuckSettings.SetUseCatDefSettingCascading(node.catDef, enabledSetting);
        }

        EndLine();
        if (IsOpen(node, openMask))
        {
            DoCategoryChildren(node, nestLevel + 1, openMask);
        }
    }

    private void DoCategoryChildren(TreeNode_ThingCategory node, int indentLevel,
        int openMask)
    {
        foreach (var treeNode in node.ChildCategoryNodes)
        {
            DoCategory(treeNode, indentLevel, openMask);
        }
    }
}