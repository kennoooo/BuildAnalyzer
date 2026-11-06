using System;
using System.Globalization;
using BuildAnalyzer.Core;

namespace BuildAnalyzer.App
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;

            Console.WriteLine("Анализатор характеристик игровой сборки");
            Console.WriteLine();

            CharacterBuild build = new CharacterBuild();

            Console.Write("Введите имя персонажа: ");
            build.Name = Console.ReadLine() ?? "Неизвестный герой";

            build.BaseAttack = ReadDoubleFromConsole("Введите базовую атаку: ");
            build.WeaponAttack = ReadDoubleFromConsole("Введите атаку оружия: ");
            build.CritChance = ReadDoubleFromConsole("Введите шанс критического удара (%): ");
            build.CritDamagePercent = ReadDoubleFromConsole("Введите критический урон (%): ");

            double totalAttack = build.CalculateTotalAttack();
            double avgDamage = build.CalculateAverageDamage();
            string rating = build.GetBuildRating();

            Console.WriteLine($"Результаты анализа сборки для: {build.Name}\n");
            Console.WriteLine($"Итоговая атака:          {totalAttack}");
            Console.WriteLine($"Средний ожидаемый урон:  {avgDamage}");
            Console.WriteLine($"Шанс критического удара: {build.CritChance}%");
            Console.WriteLine($"Критический урон:        {build.CritDamagePercent}%");
            Console.WriteLine($"Итоговый рейтинг сборки: {rating}");

            Console.WriteLine("\nНажмите любую клавишу для выхода...");
            Console.ReadKey();
        }

        private static double ReadDoubleFromConsole(string message)
        {
            while (true)
            {
                Console.Write(message);
                string? input = Console.ReadLine();
                if (double.TryParse(input, NumberStyles.Any, CultureInfo.InvariantCulture, out double result))
                {
                    return result;
                }
                Console.WriteLine("Ошибка ввода! Пожалуйста, введите корректное число (используйте точку для дробей).");
            }
        }
    }
}
