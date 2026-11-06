using System;

namespace BuildAnalyzer.Core
{
    public class CharacterBuild
    {
        public string Name { get; set; } = string.Empty;

        public double BaseAttack { get; set; }

        public double WeaponAttack { get; set; }

        public double CritChance { get; set; }

        public double CritDamagePercent { get; set; }

        public double CalculateTotalAttack()
        {
            return BaseAttack + WeaponAttack;
        }

        public double CalculateAverageDamage()
        {
            double totalAttack = CalculateTotalAttack();
            return totalAttack * (1 + (CritChance / 100.0) * (CritDamagePercent / 100.0));
        }
        public string GetBuildRating()
        {
            double avgDamage = CalculateAverageDamage();

            if (avgDamage < 1500)
                return "Слабая";
            if (avgDamage >= 1500 && avgDamage < 2500)
                return "Нормальная";
            if (avgDamage >= 2500 && avgDamage < 3500)
                return "Хорошая";

            return "Отличная";
        }
    }
}
