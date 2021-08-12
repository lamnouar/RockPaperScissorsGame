using RockPaperScissorsGame.Dtos;
using RockPaperScissorsGame.Services.Interfaces;
using System;
using System.Linq;

namespace RockPaperScissorsGame.Services.Implementations
{
    public class PlayingService : IPlayingService
    {
        private Player _playerOne;
        private Player _playerTwo;
        private readonly IParameters _parameters;
        private readonly IPlayingStyleFactory _playingStyleFactory;

        public PlayingService(IParameters parameters,
                                IPlayingStyleFactory playingStyleFactory)
        {
            _parameters = parameters;
            _playingStyleFactory = playingStyleFactory;
        }

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

            _playerOne = new Player(playerName1, Enums.PlayerStyle.HumanStyle, _playingStyleFactory);

            if (selectedMode == 1)
            {
                _playerTwo = new Player("Computer", Enums.PlayerStyle.ComputerRandomStyle, _playingStyleFactory);
            }
            else
            {
                Console.WriteLine("Enter player 2's name then press ENTER");
                var playerName2 = Console.ReadLine();

                _playerTwo = new Player(playerName2, Enums.PlayerStyle.HumanStyle, _playingStyleFactory);
            }
        }

        public void Play()
        {
            var players = new[] { _playerOne, _playerTwo };

            while (players.All(x => x.Score < 3))
            {
                while (_playerOne.CurrentSelection == _playerTwo.CurrentSelection)
                    foreach (var player in players)
                    {
                        Console.WriteLine($"Player: {player.Name}");
                        player.Play();
                    }


                if (_parameters.ChoiceCaracteristics.Single(x => x.Choice == _playerOne.CurrentSelection).LoseAgainst.Contains(_playerTwo.CurrentSelection))
                    _playerTwo.Score++;
                else
                    _playerOne.Score++;

                foreach (var player in players)
                    player.InitializeSelection();
            }

            var winner = players.Single(x => x.Score == 3);

            Console.WriteLine($"The winner is {winner.Name}");
        }
    }
}
