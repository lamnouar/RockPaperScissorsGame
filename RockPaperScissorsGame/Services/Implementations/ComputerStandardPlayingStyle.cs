using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Services.Interfaces;
using System.Linq;

namespace RockPaperScissorsGame.Services.Implementations
{
    public class ComputerStandardPlayingStyle : ComputerRandomPlayingStyleService, IPlayingStyleService
    {
        private readonly IParameters _parameters;
        public override PlayerStyle PlayerStyle { get; protected set; } = PlayerStyle.ComputerStandardStyle;

        public ComputerStandardPlayingStyle(IParameters parameters)
        {
            _parameters = parameters;
        }

        public override Choice GetCurrentSelection(Choice? previousChoice = null)
        {
            if (previousChoice is null)
                return base.GetCurrentSelection();

            return _parameters.ChoiceCaracteristics.Single(x => x.Choice == previousChoice).LoseAgainst.First();
        }
    }
}
