﻿namespace Tennis
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
            var isEndOfSet = player1Score >= 4 || player2Score >= 4;
            if (!isEndOfSet)
            {
                var scoresAreEven = player1Score == player2Score;

                if (scoresAreEven) return EvenScores();
                
                return LabelForPoints(player1Score) + "-" + LabelForPoints(player2Score);
            }

            return EndOfSetScore();
        }

        private static string LabelForPoints(int score)
        {
            switch (score)
            {
                case 0:
                    return "Love";
                case 1:
                    return "Fifteen";
                case 2:
                    return "Thirty";
                case 3:
                    return "Forty";
            }

            return "";
        }

        private string EndOfSetScore()
        {
            if (player1Score == player2Score + 1) return "Advantage player1";
            if (player2Score == player1Score + 1) return "Advantage player2";
            if (player1Score == player2Score + 2) return "Win for player1";
            if (player1Score == player2Score) return "Deuce";
            return "Win for player2";
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