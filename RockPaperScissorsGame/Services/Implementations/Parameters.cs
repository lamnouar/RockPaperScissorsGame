using RockPaperScissorsGame.Dtos;
using RockPaperScissorsGame.Enums;
using RockPaperScissorsGame.Services.Interfaces;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Services.Implementations
{
    public class Parameters : IParameters
    {
        public IList<ChoiceCaracteristics> ChoiceCaracteristics { get; private set; } = new List<ChoiceCaracteristics>();

        public Parameters()
        {
            InitializeChoices();
        }

        private void InitializeChoices()
        {
            ChoiceCaracteristics.Add(new ChoiceCaracteristics { Choice = Choice.Rock, LoseAgainst = new List<Choice> { Choice.Paper } });
            ChoiceCaracteristics.Add(new ChoiceCaracteristics { Choice = Choice.Paper, LoseAgainst = new List<Choice> { Choice.Scissors } });
            ChoiceCaracteristics.Add(new ChoiceCaracteristics { Choice = Choice.Scissors, LoseAgainst = new List<Choice> { Choice.Rock } });
            ChoiceCaracteristics.Add(new ChoiceCaracteristics { Choice = Choice.Flamethrower, LoseAgainst = new List<Choice> { Choice.Rock, Choice.Scissors } });
        }
    }
}
