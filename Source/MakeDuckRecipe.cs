using System.Linq;
using AAD.Settings;
using Verse;

namespace AAD;

[StaticConstructorOnStartup]
public static class MakeDuckRecipe
{
    static MakeDuckRecipe()
    {
        var allThingDefs = DefDatabase<ThingDef>.AllDefsListForReading;

        // foreach (var t in allThingDefs.Where(t => t.thingCategories is { Count: > 1 }))
        // {
        //     Log.Warning(t.defName + ": " + t.thingCategories.ToStringSafeEnumerable());
        // }
            
        foreach (var thingDef in allThingDefs.Where(t =>
                     t.PlayerAcquirable && 
                     t.selectable &&
                     t.category == ThingCategory.Item && 
                     t.thingCategories != null && 
                     t.thingCategories.Any(cat => 
                         AlmightyAchievementDuckSettings.GetOrCreateUseCategorySetting(cat.defName)) && 
                     t != DuckDefOf.AAD_AlmightyAchievementDuck
                 ))
        {
            var ingredient = new IngredientCount();
            ingredient.SetBaseCount(1);
            ingredient.filter.SetAllow(thingDef, true);
            DuckDefOf.AAD_Make_AlmightyAchievementDuck.ingredients.Add(ingredient);
            DuckDefOf.AAD_Make_AlmightyAchievementDuck.fixedIngredientFilter.SetAllow(thingDef, true);
        }
    }
}