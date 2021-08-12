using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Services
{
    public interface IPlayingStyleService
    {
        Choice GetCurrentSelection(Choice? previousChoice = null);
    }
}
