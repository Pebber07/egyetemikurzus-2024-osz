using NUnit.Framework;
using HQ35PUIKLUMR.Model;
using HQ35PU_IKLUMR.Statistics;
using System.Collections.Generic;

[TestFixture]
public class AverageEloListerTests
{
    private List<Game> games;

    [SetUp]
    public void SetUp()
    {
        games = new List<Game>
        {
            new Game("Player1", "Player2", 2000, 1800, "1-0", "A00", "Tournament1", new DateTime(2023, 5, 1), "a3 h6", 1),
            new Game("Player3", "Player4", 2200, 1900, "0-1", "A00", "Tournament2", new DateTime(2023, 6, 1), "g4 h5", 1),
            new Game("Player5", "Player1", 2100, 2000, "1/2-1/2", "A00", "Tournament3", new DateTime(2023, 7, 1), "a4 a5", 1)
        };
    }

    [Test]
    public void ListElo_CalculatesCorrectAverageAndTopPlayers()
    {
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);
            AverageEloLister.ListElo(games, 2);

            var output = writer.ToString();
            Assert.That(output, Does.Contain("Top 2 legmagasabb ELO-val rendelkező játékos:"));
            Assert.That(output, Does.Contain("Player3: 2200"));
            Assert.That(output, Does.Contain("Player5: 2100"));
        }
    }
}


