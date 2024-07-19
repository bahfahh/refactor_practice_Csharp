namespace Tennis
{
    public class TennisGame1 : ITennisGame
    {
        private int _playerScore1 = 0;
        private int _playerScore2 = 0;
        private readonly string _player1Name;
        private readonly string _player2Name;
        public TennisGame1(string player1Name, string player2Name)
        {
            _player1Name = player1Name;
            _player2Name = player2Name;
        }
        public void WonPoint(string playerName)
        {
            if (playerName == _player1Name)
                _playerScore1 += 1;
            else
                _playerScore2 += 1;
        }
        public string GetScore()
        {
            return _playerScore1 == _playerScore2 ? _playerScore1 switch
            {
                0 => "Love-All",
                1 => "Fifteen-All",
                2 => "Thirty-All",
                _ => "Deuce",
            } : (_playerScore1 >= 4 || _playerScore2 >= 4) ? (_playerScore1 - _playerScore2) switch
            {
                1 => "Advantage player1",
                -1 => "Advantage player2",
                >= 2 => "Win for player1",
                _ => "Win for player2",
            } : $"{ConvertScoreToText(_playerScore1)}-{ConvertScoreToText(_playerScore2)}";
        }
        private static string ConvertScoreToText(int score)
        {
            return score switch
            {
                0 => "Love",
                1 => "Fifteen",
                2 => "Thirty",
                _ => "Forty",
            };
        }
    }
}
