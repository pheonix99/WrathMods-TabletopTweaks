﻿using Kingmaker.EntitySystem.Stats;
using TabletopTweaks.Config;
using TabletopTweaks.Extensions;
using TabletopTweaks.Utilities;

namespace TabletopTweaks.NewContent.Feats {
    static class MagicalAptitude {
        public static void AddMagicalAptitude() {
            var MagicalAptitude = FeatTools.CreateSkillFeat(StatType.SkillKnowledgeArcana, StatType.SkillUseMagicDevice, bp => {
                bp.AssetGuid = ModSettings.Blueprints.GetGUID("MagicalAptitude");
                bp.name = "MagicalAptitude";
                bp.SetName("Magical Aptitude");
                bp.SetDescriptionTagged("You are skilled at spellcasting and using magic items." +
                    "\nYou get a +2 bonus on Knowledge (Arcana) and " +
                    "Use Magic Device skill checks. If you have 10 or more ranks in one of these skills," +
                    " the bonus increases to +4 for that skill.");
            });
            Resources.AddBlueprint(MagicalAptitude);
            if (ModSettings.AddedContent.Feats.DisableAll || !ModSettings.AddedContent.Feats.Enabled["MagicalAptitude"]) { return; }
            FeatTools.AddAsFeat(MagicalAptitude);
        }
    }
}