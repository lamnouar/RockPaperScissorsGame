using RockPaperScissorsGame.Enums;
using System;

namespace RockPaperScissorsGame.Services
{
    public class ComputerRandomPlayingStyleService : IPlayingStyleService
    {
        private readonly Random _random = new Random();
        public virtual Choice GetCurrentSelection(Choice? previousChoice = null)
        {
            var enumType = typeof(Choice);
            var enumValues = enumType.GetEnumValues();
            int randomChoice = _random.Next(enumValues.Length);

            return (Choice)enumValues.GetValue(randomChoice);
        }
    }
}
