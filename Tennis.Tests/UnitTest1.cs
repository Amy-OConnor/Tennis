namespace Tennis.Tests;

public class Tests
{
    [TestCase(0, 0, "Love-All")]
    [TestCase(1, 0, "Fifteen-Love")]
    [TestCase(1, 1, "Fifteen-All")]
    [TestCase(2, 1, "Thirty-Fifteen")]
    [TestCase(2, 2, "Thirty-All")]
    [TestCase(3, 2, "Forty-Thirty")]
    [TestCase(3, 0, "Forty-Love")]
    [TestCase(3, 3, "Deuce")]
    [TestCase(4, 3, "Advantage player1")]
    [TestCase(3, 4, "Advantage player2")]
    [TestCase(5, 4, "Advantage player1")]
    [TestCase(5, 5, "Deuce")]
    [TestCase(5, 3, "Win for player1")]
    [TestCase(3, 5, "Win for player2")]
    [TestCase(2, 4, "Win for player2")]
    public void Get_score(int player1Score, int player2Score, string score)
    {
        var tennisGame1 = new TennisGame1("player1", "player2");

        for (var i = 0; i < player1Score; i++)
        {
            tennisGame1.WonPoint("player1");
        }

        for (var i = 0; i < player2Score; i++)
        {
            tennisGame1.WonPoint("player2");
        }
        Assert.That(tennisGame1.GetScore(), Is.EqualTo(score));
    }
}
