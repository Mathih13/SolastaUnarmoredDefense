using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SolastaModApi;
using SolastaModApi.Extensions;

namespace SolastaUnarmoredDefense.Builders
{
    internal class UnarmoredDefenseData
    {
        public string Guid { get; set; }
        public string Attribute { get; set; }
        public bool CanUseShield { get; set; }
    }


    internal class UnarmoredDefenseFightingStyleBuilder :
   BaseDefinitionBuilder<FightingStyleDefinition>
    {
        protected UnarmoredDefenseFightingStyleBuilder(string name, UnarmoredDefenseData data)
          : base(DatabaseHelper.FightingStyleDefinitions.Defense, name, data.Guid)
        {
            var attributeString = GetAttributeStringFromInput(data.Attribute);

            Definition.GuiPresentation.Title = GenerateTitle(attributeString);
            Definition.GuiPresentation.Description = GenerateDescription(data, attributeString);
            Definition.GuiPresentation.SetSpriteReference(DatabaseHelper.CharacterSubclassDefinitions.DomainBattle.GuiPresentation.SpriteReference);

            Definition.Features.Clear();
        }

        private string GenerateTitle(string attributeString)
        {
            return $"SolastaUnarmoredDefense/&{attributeString}Title";
        }

        private string GenerateDescription(UnarmoredDefenseData data, string attributeString)
        {
            if (data.CanUseShield)
            {
                return $"SolastaUnarmoredDefense/&{attributeString}ShieldTrueDescription";
            }
            else
            {
                return $"SolastaUnarmoredDefense/&{attributeString}ShieldFalseDescription";
            }

        }

        private static string GetAttributeStringFromInput(string attribute)
        {

            foreach (var score in AttributeDefinitions.AbilityScoreNames)
            {
                if (attribute.ToLower() == score.ToLower())
                {
                    return score;
                }
            }

            throw new Exception("Attempted to build Unarmored Defense with illegal attribute: " + attribute);
        }

        private static string GenerateInternalName(string attribute, bool canUseShield)
        {
            return $"UnarmoredDefenseFightingStyle({attribute})/shield={canUseShield}";
        }

        public static FightingStyleDefinition CreateAndAddToDB(UnarmoredDefenseData data)
            => new UnarmoredDefenseFightingStyleBuilder(GenerateInternalName(data.Attribute, data.CanUseShield), data).AddToDB();

        public static FightingStyleDefinition UnarmoredDefenseVersion(UnarmoredDefenseData data)
            => CreateAndAddToDB(data);
    }
}
