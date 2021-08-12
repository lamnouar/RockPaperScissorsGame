using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Helpers;
using System;
using System.Collections;

namespace RockPaperScissorsGame.Services
{
    public class PersonPlayingStyleService : IPlayingStyleService
    {
        public Choice GetCurrentSelection(Choice? previousChoice = null)
        {
            Console.WriteLine("Press the number associated to your choice please!");
            var availableChoices = Enum.GetValues(typeof(Choice));

            foreach (var choice in availableChoices)
            {
                Console.WriteLine($"{(int)choice} - {choice}");
            }

            var choiceAsString = Console.ReadLine();

            if (!int.TryParse(choiceAsString, out int choiceAsInt) || !DoesSelectedItemBelongToAvailableChoices(choiceAsInt))
                GetCurrentSelection();


            return EnumHelper.GetValue<Choice>(choiceAsInt);
        }

        private bool DoesSelectedItemBelongToAvailableChoices(int selectedItem)
        {
            var enumType = typeof(Choice);
            var enumValues = new ArrayList(enumType.GetEnumValues());

            return enumValues.Contains(selectedItem);
        }
    }
}
