using Microsoft.Extensions.DependencyInjection;
using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Services.Interfaces;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Dtos
{
    public class Player
    {
        private IPlayingStyleService _playingStyleService;
        private readonly PlayerStyle _playerStyle;

        public string Name { get; set; }
        public int Score { get; set; }
        public Choice CurrentSelection { get; protected set; }
        public Queue<Choice> PreviousSelections { get; set; } = new Queue<Choice>();


        public Player(string name, PlayerStyle playerStyle, IPlayingStyleFactory playingStyleFactory)
        {
            Name = name;
            _playerStyle = playerStyle;
            _playingStyleService = playingStyleFactory.GetPlayingStyleService(_playerStyle);
        }

        public void Play()
        {
            CurrentSelection = _playingStyleService.GetCurrentSelection();
            PreviousSelections.Enqueue(CurrentSelection);
        }

        public void InitializeSelection()
        {
            CurrentSelection = Choice.Rock;
        }
    }
}
