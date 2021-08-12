using RockPaperScissorsGame.Enums;
using System.Linq;

namespace RockPaperScissorsGame.Services
{
    public class ComputerStandardPlayingStyle : ComputerRandomPlayingStyleService, IPlayingStyleService
    {
        private readonly IParametres _parameters;
        public override Choice GetCurrentSelection(Choice? previousChoice = null)
        {
            if (previousChoice is null)
                return base.GetCurrentSelection();

            return _parameters.ChoiceCaracteristics.Single(x => x.Choice == previousChoice).LoseAgainst.First();
        }
    }
}
