using RockPaperScissorsGame.Dtos;
using RockPaperScissorsGame.Enums;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Services
{
    public class Parametres : IParametres
    {
        public IList<ChoiceCaracteristics> ChoiceCaracteristics { get; private set; } = new List<ChoiceCaracteristics>();

        public Parametres()
        {
            InitializeChoices();
        }

        private void InitializeChoices()
        {
            ChoiceCaracteristics.Add(new ChoiceCaracteristics { Choice = Choice.Rock, LoseAgainst = new List<Choice> { Choice.Paper } });
            ChoiceCaracteristics.Add( new ChoiceCaracteristics { Choice = Choice.Paper, LoseAgainst = new List<Choice> { Choice.Scissors } });
            ChoiceCaracteristics.Add(new ChoiceCaracteristics { Choice = Choice.Scissors, LoseAgainst = new List<Choice> { Choice.Rock } });
        }
    }
}
