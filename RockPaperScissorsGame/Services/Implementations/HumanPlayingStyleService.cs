using RockPaperScissorsGame.Constants;
using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Helpers;
using RockPaperScissorsGame.Services.Interfaces;
using System;

namespace RockPaperScissorsGame.Services.Implementations
{
    public class HumanPlayingStyleService : IPlayingStyleService
    {
        public PlayerStyle PlayerStyle { get; protected set; } = PlayerStyle.HumanStyle;


        public Choice GetCurrentSelection(Choice? previousChoice = null)
        {
            Console.WriteLine(Messages.CHOICES_MENU);
            var availableChoices = Enum.GetValues(typeof(Choice));

            foreach (var choice in availableChoices)
                Console.WriteLine($"{(int)choice} - {choice}");

            var choiceAsString = Console.ReadLine();

            if (!int.TryParse(choiceAsString, out int choiceAsInt) || !Enum.IsDefined(typeof(Choice), choiceAsInt))
                return GetCurrentSelection();

            return EnumHelper.GetValue<Choice>(choiceAsInt);
        }
    }
}
