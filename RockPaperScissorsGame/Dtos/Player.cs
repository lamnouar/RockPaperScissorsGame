using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Services;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Dtos
{
    public class Player
    {
        private readonly IPlayingStyleService playingStyleService;

        public string Name { get; set; }
        public int Score { get; set; }
        public Choice CurrentSelection { get; protected set; }
        public Queue<Choice> PreviousSelections { get; set; } = new Queue<Choice>();

        public void Play()
        {
            CurrentSelection = playingStyleService.GetCurrentSelection();
            PreviousSelections.Enqueue(CurrentSelection);
        }
    }
}
