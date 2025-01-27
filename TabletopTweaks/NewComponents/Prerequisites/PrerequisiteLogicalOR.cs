﻿using JetBrains.Annotations;
using Kingmaker.Blueprints.Classes.Prerequisites;
using Kingmaker.UnitLogic;
using Kingmaker.UnitLogic.Class.LevelUp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabletopTweaks.NewComponents.Prerequisites {
    class PrerequisiteLogicalOR : PrerequisiteAbstractLogical
    {
       

        public override bool CheckInternal([CanBeNull] FeatureSelectionState selectionState, [NotNull] UnitDescriptor unit, [CanBeNull] LevelUpState state)
        {
            foreach (Prerequisite p in componentPrequisites)
            {
                if (p.CheckInternal(selectionState, unit, state))
                    return true;
            }
            return false;
        }

        public override string GetUITextInternal(UnitDescriptor unit)
        {
            StringBuilder s = new StringBuilder();
            for (int i = 0; i < componentPrequisites.Count; i++)
            {
                s.Append(componentPrequisites[i].GetUIText(unit));
                if (i + 1 < componentPrequisites.Count)
                    s.Append(" or ");
            }

            return s.ToString();

        }
    }
}
