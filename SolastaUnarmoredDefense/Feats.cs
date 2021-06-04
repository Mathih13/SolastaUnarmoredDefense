using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaUnarmoredDefense.Builders;

namespace SolastaUnarmoredDefense
{
    public static class Feats
    {
        public static FightingStyleDefinition UnarmoredDefenseCon = UnarmoredDefenseFeatBuilder.UnarmoredDefenseVersion(new UnarmoredDefenseData
        {
            Guid = "015022c0-07ed-4945-b0a0-4a29ba5e2a5b",
            Attribute = "Constitution",
            CanUseShield = true
        });

        public static FightingStyleDefinition UnarmoredDefenseWis = UnarmoredDefenseFeatBuilder.UnarmoredDefenseVersion(new UnarmoredDefenseData
        {
            Guid = "08cdcd45-372a-430c-aaef-67cc59fe6328",
            Attribute = "Wisdom",
            CanUseShield = false
        });
    }
}
