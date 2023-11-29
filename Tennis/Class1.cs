namespace Tennis
{
    public class TennisGame1
    {
        private int player1Score = 0;
        private int player2Score = 0;
        private string player1Name;
        private string player2Name;

        public TennisGame1(string player1Name, string player2Name)
        {
            this.player1Name = player1Name;
            this.player2Name = player2Name;
        }

        public void WonPoint(string playerName)
        {
            if (playerName == "player1")
                player1Score += 1;
            else
                player2Score += 1;
        }

        public string GetScore()
        {
            var scoresAreEven= player1Score == player2Score;
            if (scoresAreEven)
            {
                return EvenScores();
            }

            var isEndOfSet = player1Score >= 4 || player2Score >= 4;
            if (isEndOfSet)
            {
                return EndOfSetScore();
            }
            return OddMidSetScores();
        }

        private string OddMidSetScores()
        {
            string score = "";
            for (var i = 1; i < 3; i++)
            {
                var tempScore = 0;
                if (i == 1) tempScore = player1Score;
                else
                {
                    score += "-";
                    tempScore = player2Score;
                }

                score = AppendScore(tempScore, score);
            }

            return score;
        }

        private static string AppendScore(int score, string inputString)
        {
            switch (score)
            {
                case 0:
                    inputString += "Love";
                    break;
                case 1:
                    inputString += "Fifteen";
                    break;
                case 2:
                    inputString += "Thirty";
                    break;
                case 3:
                    inputString += "Forty";
                    break;
            }

            return inputString;
        }

        private string EndOfSetScore()
        {
            string score;
            var minusResult = player1Score - player2Score;
            if (minusResult == 1) score = "Advantage player1";
            else if (minusResult == -1) score = "Advantage player2";
            else if (minusResult >= 2) score = "Win for player1";
            else score = "Win for player2";
            return score;
        }

        private string EvenScores()
        {
            string score;
            switch (player1Score)
            {
                case 0:
                    score = "Love-All";
                    break;
                case 1:
                    score = "Fifteen-All";
                    break;
                case 2:
                    score = "Thirty-All";
                    break;
                default:
                    score = "Deuce";
                    break;
            }

            return score;
        }
    }
}