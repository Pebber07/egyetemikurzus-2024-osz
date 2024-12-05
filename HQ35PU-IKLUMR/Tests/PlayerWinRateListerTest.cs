using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using HQ35PUIKLUMR.Model;
using HQ35PU_IKLUMR.Statistics;
using System.Linq;

[TestFixture]
public class PlayerWinRateListerTests
{
    private List<Game> games;

    [SetUp]
    public void SetUp()
    {
        games = new List<Game>
        {
            new Game("Tapodi, Norman Lajos", "Valaki", 2108, 2000, "1-0", "C54", "Tournament1", new DateTime(2023, 5, 1), "e4 e5...", 30), 
            new Game("Tapodi, Norman Lajos", "Valaki1", 2112, 2200, "1/2-1/2", "B23", "Tournament2", new DateTime(2023, 6, 1), "e4 c5...", 40),
            new Game("Player4", "Tapodi, Norman Lajos", 2200, 2400, "1-0", "A45", "Tournament3", new DateTime(2023, 7, 1), "d4 Nf6...", 50)
        };
    }

    [Test]
    public void ShowPlayerWinRates_ShowsCorrectStatistics_ForGivenPlayer()
    {
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);
            PlayerWinRateLister.showPlayerWinRates(games, "Tapodi, Norman Lajos");

            var output = writer.ToString();

            // Helyesek-e a statisztikák
            Assert.That(output, Does.Contain("Tapodi, Norman Lajos statisztikái:"));
            Assert.That(output, Does.Contain("Gyõzelmek: 1 (33,33%)"));
            Assert.That(output, Does.Contain("Döntetlen: 1 (33,33%)"));
            Assert.That(output, Does.Contain("Vereségek: 1 (33,33%)"));
        }
    }

    [Test]
    public void ShowPlayerWinRates_ReturnsNoGames_ForPlayerNotInList()
    {
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);

            // Nem létezõ játékos
            PlayerWinRateLister.showPlayerWinRates(games, "Valaki3");
            var output = writer.ToString();

            Assert.That(output, Does.Contain("Valaki3 nem szerepelt a megadott partik között."));
        }
    }
}