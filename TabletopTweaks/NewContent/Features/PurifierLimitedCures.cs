﻿using Kingmaker.Blueprints;
using Kingmaker.Blueprints.Classes;
using Kingmaker.UnitLogic.Abilities.Blueprints;
using Kingmaker.UnitLogic.FactLogic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabletopTweaks.Extensions;
using TabletopTweaks.Utilities;

namespace TabletopTweaks.NewContent.Features
{
    class PurifierLimitedCures
    { 
        public static void AddPurifierLimitedCures()
        {
            var PuriferArchetype = Resources.GetBlueprint<BlueprintArchetype>("c9df67160a77ecd4a97928f2455545d7");
            Helpers.CreateBlueprint<BlueprintFeature>("PurifierLimitedCures", bp =>
            {
                bp.IsClassFeature = true;
                bp.SetName("Basic Cure Spells");
                bp.SetDescription("Purifers still can cast the most basic cure spells");
                bp.Ranks = 1;
                bp.HideInCharacterSheetAndLevelUp = false;
                
                bp.AddComponent<AddKnownSpell>(ks =>
                {
                    ks.m_CharacterClass = PuriferArchetype.GetParentClass().ToReference<BlueprintCharacterClassReference>();
                    ks.SpellLevel = 1;
                    ks.m_Archetype = PuriferArchetype.ToReference<BlueprintArchetypeReference>();
                    ks.m_Spell = Resources.GetBlueprint<BlueprintAbility>("5590652e1c2225c4ca30c4a699ab3649").ToReference<BlueprintAbilityReference>();
                });
                bp.AddComponent<AddKnownSpell>(ks =>
                {
                    ks.m_CharacterClass = PuriferArchetype.GetParentClass().ToReference<BlueprintCharacterClassReference>();
                    ks.SpellLevel = 2;
                    ks.m_Archetype = PuriferArchetype.ToReference<BlueprintArchetypeReference>();
                    ks.m_Spell = Resources.GetBlueprint<BlueprintAbility>("6b90c773a6543dc49b2505858ce33db5").ToReference<BlueprintAbilityReference>();
                });

            });
        }
    }
}
