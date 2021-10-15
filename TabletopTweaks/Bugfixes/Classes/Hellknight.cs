﻿using HarmonyLib;
using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.Blueprints.Classes.Selection;
using Kingmaker.Blueprints.JsonSystem;
using Kingmaker.Utility;
using System.Linq;
using TabletopTweaks.Config;
using TabletopTweaks.Extensions;

namespace TabletopTweaks.Bugfixes.Classes {
    class Hellknight {
        [HarmonyPatch(typeof(BlueprintsCache), "Init")]
        static class BlueprintsCache_Init_Patch {
            static bool Initialized;

            static void Postfix() {
                if (Initialized) return;
                Initialized = true;
                Main.LogHeader("Patching Hellknight Resources");

                PatchPentamicFaith();
               

                void PatchPentamicFaith() {
                    if (ModSettings.Fixes.Hellknight.IsDisabled("PentamicFaith")) { return; }

                    var HellKnightOrderOfTheGodclaw = Resources.GetBlueprint<BlueprintFeature>("5636564c278583342aec54eb2b409029");
                    var HellknightDisciplinePentamicFaith = Resources.GetBlueprint<BlueprintFeatureSelection>("b9750875e9d7454e85347d739a1bc894");

                    HellknightDisciplinePentamicFaith.RemovePrerequisites<PrerequisiteFeature>();
                    HellknightDisciplinePentamicFaith.AddPrerequisiteFeature(HellKnightOrderOfTheGodclaw);
                    Main.LogPatch("Patched", HellknightDisciplinePentamicFaith);
                }
                BlueprintCharacterClass Hellknight = Resources.GetBlueprint<BlueprintCharacterClass>("ed246f1680e667b47b7427d51e651059");
                PatchArmorTraining();
                void PatchArmorTraining()
                {
                    if (ModSettings.Fixes.Fighter.Base.IsDisabled("AdvancedArmorTraining")) { return; }

                    var BaseProgression = Hellknight.Progression;
                    LevelEntry level1 = BaseProgression.LevelEntries.FirstOrDefault(x => x.Level == 1);
                    level1.m_Features.Add(Resources.GetModBlueprint<BlueprintFeature>("HellknightArmorTrainingProgression").ToReference<BlueprintFeatureBaseReference>());

                    var ArmorTraining = Resources.GetBlueprint<BlueprintFeature>("3c380607706f209499d951b29d3c44f3");
                    var ArmorTrainingSelection = Resources.GetModBlueprint<BlueprintFeatureSelection>("ArmorTrainingSelection");
                    var ArmorTrainingSpeedFeature = Resources.GetModBlueprint<BlueprintFeature>("ArmorTrainingSpeedFeature");

                    BaseProgression.LevelEntries
                        .Where(entry => entry.m_Features.Contains(ArmorTraining.ToReference<BlueprintFeatureBaseReference>()))
                        .ForEach(entry =>
                        {
                            entry.m_Features.Add(ArmorTrainingSelection.ToReference<BlueprintFeatureBaseReference>());
                            entry.m_Features.Remove(ArmorTraining.ToReference<BlueprintFeatureBaseReference>());
                            entry.m_Features.Add(ArmorTrainingSpeedFeature.ToReference<BlueprintFeatureBaseReference>());
                        });

                    Main.LogPatch("Patched", BaseProgression);

                }
            }
        }
    }
}
