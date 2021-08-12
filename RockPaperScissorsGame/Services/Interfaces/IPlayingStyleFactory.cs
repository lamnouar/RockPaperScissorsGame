using RockPaperScissorsGame.Enums;

namespace RockPaperScissorsGame.Services.Interfaces
{
    public interface IPlayingStyleFactory
    {
        public IPlayingStyleService GetPlayingStyleService(PlayerStyle playerStyle);
    }
}
