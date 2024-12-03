using NUnit.Framework;
using HQ35PUIKLUMR.Model;
using HQ35PU_IKLUMR.Statistics;
using System.Collections.Generic;

[TestFixture]
public class LongestGamesFinderTests
{
    private List<Game> games;

    [SetUp]
    public void SetUp()
    {
        games = new List<Game>
        {
            new Game("Player1", "Player2", 2000, 1800, "1-0", "C54", "Tournament1", new DateTime(2023, 5, 1), "1.e4 e5 2.Nf3 Nc6...", 20),
            new Game("Player3", "Player4", 2200, 1900, "1/2-1/2", "B23", "Tournament2", new DateTime(2023, 6, 1), "1.e4 c5 2.Nc3 Nc6...", 45),
            new Game("Player5", "Player6", 2100, 2000, "0-1", "A45", "Tournament3", new DateTime(2023, 7, 1), "1.d4 Nf6 2.e3 g6...", 50)
        };
    }

    [Test]
    public void FindLongestGames_FindsLongestGames()
    {
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);
            LongestGamesFinder.FindLongestGames(games, 1);

            var output = writer.ToString();
            Assert.That(output, Does.Contain("Player5"));
            Assert.That(output, Does.Contain("Lépésszám: 50"));
        }
    }
}

