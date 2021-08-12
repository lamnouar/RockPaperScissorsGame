using RockPaperScissorsGame.Enums;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Dtos
{
    public class ChoiceCaracteristics
    {
        public Choice Choice { get; set; }
        public IList<Choice> WinAgainst { get; set; }
        public IList<Choice> LoseAgainst { get; set; }
    }
}
