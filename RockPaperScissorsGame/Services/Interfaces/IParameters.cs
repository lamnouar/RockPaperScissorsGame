using RockPaperScissorsGame.Dtos;
using System.Collections.Generic;

namespace RockPaperScissorsGame.Services.Interfaces
{
    public interface IParameters
    {
        public IList<ChoiceCaracteristics> ChoiceCaracteristics { get;  }
    }
}
