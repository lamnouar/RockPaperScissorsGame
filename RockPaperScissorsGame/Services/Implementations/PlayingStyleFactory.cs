using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace RockPaperScissorsGame.Services.Implementations
{
    class PlayingStyleFactory : IPlayingStyleFactory
    {
        private readonly IEnumerable<IPlayingStyleService> _playingStyleServices;

        public PlayingStyleFactory(IEnumerable<IPlayingStyleService> playingStyleServices)
        {
            _playingStyleServices = playingStyleServices;
        }

        public IPlayingStyleService GetPlayingStyleService(PlayerStyle playerStyle)
                => _playingStyleServices.Single(x => x.PlayerStyle == playerStyle);
    }
}
