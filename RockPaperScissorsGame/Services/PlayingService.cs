using RockPaperScissorsGame.Dtos;
using System;

namespace RockPaperScissorsGame.Services
{
    public class PlayingService : IPlayingService
    {
        private  Player _playerOne;
        private  Player _playerTwo;

        public void InitializePlayers()
        {
            Console.WriteLine("Select how many player by pressing the associated number then press ENTER");
            Console.WriteLine("1 - Single player");
            Console.WriteLine("2 - Multiplayer player");

            var selectedModeAsString = Console.ReadLine();
            if (!int.TryParse(selectedModeAsString, out int selectedMode) || (selectedMode != 1 && selectedMode != 2))
                InitializePlayers();

            Console.WriteLine("Enter player 1's name then press ENTER");
            var playerName1 = Console.ReadLine();

            _playerOne = new Player { Name = playerName1 };

            if (selectedMode == 1)
            {
                _playerTwo = new Player { Name = "Computer" };
            }
            else
            {
                Console.WriteLine("Enter player 2's name then press ENTER");
                var playerName2 = Console.ReadLine();

                _playerTwo = new Player { Name = playerName1 };
            }
        }

        public void Play()
        {
            throw new System.NotImplementedException();
        }
    }
}
