using System.Collections.Generic;
using System.Linq;
using AAD.Settings;
using RimWorld;
using Verse;

namespace AAD;

[StaticConstructorOnStartup]
public static class MakeDuckRecipe
{
    static MakeDuckRecipe()
    {
        var allTheIngredients = new List<IngredientCount>();

        // var exclusions = settings.excludedCats.NullOrEmpty()
        //     ? defaultExclusions
        //     : settings.excludedCats;
        //
        // var inclusions = settings.includedCats.NullOrEmpty()
        //     ? defaultInclusions
        //     : settings.includedCats;

        var allThingDefs = DefDatabase<ThingDef>.AllDefsListForReading;
        foreach (var thingDef in allThingDefs.Where(t =>
                     t.PlayerAcquirable && t.selectable &&
                     ((t.CountAsResource || ThingCategoryDefOf.Items
                          .ContainedInThisOrDescendant(t))
                      && 
                      // !exclusions.Any(excludedCat =>
                      //     excludedCat.ContainedInThisOrDescendant(t))
                      // || inclusions.Any(includedCat =>
                      //     includedCat.ContainedInThisOrDescendant(t))
                      t.thingCategories.Any(cat => AlmightyAchievementDuckSettings.GetOrCreateUseCategorySetting(cat.defName) && cat.ContainedInThisOrDescendant(t))
                      ) && t != DuckDefOf.AAD_AlmightyAchievementDuck
                 ))
        {
            var ingredient = new IngredientCount();
            ingredient.filter.SetAllow(thingDef, true);
            ingredient.SetBaseCount(1);

            allTheIngredients.Add(ingredient);
        }

        DuckDefOf.AAD_Make_AlmightyAchievementDuck.ingredients = allTheIngredients;

        //TODO: refactor this:
        // foreach (var category in DefDatabase<ThingCategoryDef>.AllDefsListForReading.Where(_ => !exclusions.Union(inclusions).Any(c => c.ThisAndChildCategoryDefs.Contains(c))))
        // {
            // Log.Error(category.defName + " was not found in recipe exclude or inclusion list");
        // }


        // foreach (var ing in DuckDefOf.Make_AlmightyAchievementDuck.ingredients)
        // {
        //     Log.Message(ing.ToStringSafe());
        // }
    }
}