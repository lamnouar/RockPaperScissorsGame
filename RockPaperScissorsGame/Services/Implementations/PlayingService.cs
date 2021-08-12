using RockPaperScissorsGame.Constants;
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
            Console.WriteLine(Messages.MODE_SELECTION);
            Console.WriteLine(Messages.SINGLE_PLAYER_MODE);
            Console.WriteLine(Messages.MULTIPLAYER_MODE);

            var selectedModeAsString = Console.ReadLine();
            if (!int.TryParse(selectedModeAsString, out int selectedMode) || (selectedMode != 1 && selectedMode != 2))
                InitializePlayers();

            Console.WriteLine(string.Format(Messages.ENTER_PLAYER_NAME, 1));
            var playerName1 = Console.ReadLine();

            _playerOne = new Player(playerName1, Enums.PlayerStyle.HumanStyle, _playingStyleFactory);

            if (selectedMode == 1)
            {
                _playerTwo = new Player("Computer", Enums.PlayerStyle.ComputerStandardStyle, _playingStyleFactory);
            }
            else
            {
                Console.WriteLine(string.Format(Messages.ENTER_PLAYER_NAME, 2));
                var playerName2 = Console.ReadLine();

                _playerTwo = new Player(playerName2, Enums.PlayerStyle.HumanStyle, _playingStyleFactory);
            }
        }

        public void Play()
        {
            var players = new[] { _playerOne, _playerTwo };
            var round = 1;

            while (players.All(x => x.Score < 3))
            {
                Console.WriteLine($"Round {round}");

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

                Console.WriteLine($"Round {round} choices => {_playerOne.Name}({_playerOne.CurrentSelection}) - {_playerTwo.Name}({_playerTwo.CurrentSelection})");
                Console.WriteLine($"Round {round} score => {_playerOne.Name}({_playerOne.Score}) - {_playerTwo.Name}({_playerTwo.Score})");

                foreach (var player in players)
                    player.InitializeSelection();

                round++;
            }

            var winner = players.Single(x => x.Score == 3);

            Console.WriteLine($"Final score => {_playerOne.Name} {_playerOne.Score} - {_playerTwo.Name} {_playerTwo.Score}");
            Console.WriteLine($"The winner is {winner.Name}");
        }
    }
}
