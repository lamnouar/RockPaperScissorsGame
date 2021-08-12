using RockPaperScissorsGame.Dtos;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Services
{
    public interface IParametres
    {
        public IList<ChoiceCaracteristics> ChoiceCaracteristics { get;  }
    }
}
