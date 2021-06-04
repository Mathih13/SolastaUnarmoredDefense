using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaUnarmoredDefense.Builders;

namespace SolastaUnarmoredDefense
{
    public static class FightingStyles
    {
        public static FightingStyleDefinition UnarmoredDefense_Constitution = UnarmoredDefenseFightingStyleBuilder.UnarmoredDefenseVersion(new UnarmoredDefenseData
        {
            Guid = "cd42525f-2efc-4872-9125-73780537998b",
            Attribute = "Constitution",
            CanUseShield = true
        });

        public static FightingStyleDefinition UnarmoredDefense_Wisdom = UnarmoredDefenseFightingStyleBuilder.UnarmoredDefenseVersion(new UnarmoredDefenseData
        {
            Guid = "bb61346e-3b47-44aa-8802-84dd58b2fba9",
            Attribute = "Wisdom",
            CanUseShield = false
        });
    }
}
