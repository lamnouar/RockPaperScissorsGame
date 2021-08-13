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
            DisplayPlayingMode();

            var selectedModeAsString = Console.ReadLine();
            if (!int.TryParse(selectedModeAsString, out int selectedMode) || (selectedMode != 1 && selectedMode != 2))
                InitializePlayers();

            InitializePlayerOne();

            InitializePlayerTwo(selectedMode);
        }



        private static void DisplayPlayingMode()
        {
            Console.WriteLine(Messages.MODE_SELECTION);
            Console.WriteLine(Messages.SINGLE_PLAYER_MODE);
            Console.WriteLine(Messages.MULTIPLAYER_MODE);
        }

        public void Play()
        {
            var players = new[] { _playerOne, _playerTwo };
            var round = 1;

            while (players.All(x => x.Score < 3))
            {
                Console.WriteLine(string.Format(Messages.CURRENT_ROUND, round));
                PlayRound(players);
                DisplayRoundResult(round);

                foreach (var player in players)
                    player.InitializeSelection();

                round++;
            }

            DisplayFinalResult(players);
        }

        private void DisplayRoundResult(int round)
        {
            Console.WriteLine(string.Format(Messages.ROUND_CHOICES, round, _playerOne.Name, _playerOne.CurrentSelection, _playerTwo.Name, _playerTwo.CurrentSelection));
            Console.WriteLine(string.Format(Messages.ROUND_SCORE, round, _playerOne.Name, _playerOne.Score, _playerTwo.Name, _playerTwo.Score));
        }

        private void PlayRound(Player[] players)
        {
            while (_playerOne.CurrentSelection == _playerTwo.CurrentSelection)
                foreach (var player in players)
                {
                    Console.WriteLine(string.Format(Messages.PLAYER_NAME, player.Name));
                    player.Play();
                }

            if (_parameters.ChoiceCaracteristics.Single(x => x.Choice == _playerOne.CurrentSelection).LoseAgainst.Contains(_playerTwo.CurrentSelection))
                _playerTwo.Score++;
            else
                _playerOne.Score++;
        }

        private void DisplayFinalResult(Player[] players)
        {
            var winner = players.Single(x => x.Score == 3);

            Console.WriteLine(string.Format(Messages.FINAL_SCORE, _playerOne.Name, _playerOne.Score, _playerTwo.Name, _playerTwo.Score));
            Console.WriteLine(string.Format(Messages.GAME_WINNER, winner.Name));
        }

        private void InitializePlayerTwo(int selectedMode)
        {
            if (selectedMode == 1)
                _playerTwo = new Player(Messages.COMPUTER_NAME, Enums.PlayerStyle.ComputerRandomStyle, _playingStyleFactory);
            else
            {
                Console.WriteLine(string.Format(Messages.ENTER_PLAYER_NAME, 2));
                var playerName2 = Console.ReadLine();

                _playerTwo = new Player(playerName2, Enums.PlayerStyle.HumanStyle, _playingStyleFactory);
            }
        }

        private void InitializePlayerOne()
        {
            Console.WriteLine(string.Format(Messages.ENTER_PLAYER_NAME, 1));
            var playerName1 = Console.ReadLine();

            _playerOne = new Player(playerName1, Enums.PlayerStyle.HumanStyle, _playingStyleFactory);
        }
    }
}
