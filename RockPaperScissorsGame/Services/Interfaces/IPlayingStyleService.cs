using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Services.Interfaces
{
    public interface IPlayingStyleService
    {
        public PlayerStyle PlayerStyle { get; }
        Choice GetCurrentSelection(Choice? previousSelection = null);
    }
}
