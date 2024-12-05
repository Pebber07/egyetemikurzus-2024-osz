using System;
using System.Collections.Generic;
using System.IO;
using NUnit.Framework;
using HQ35PUIKLUMR.Model;
using HQ35PU_IKLUMR.Statistics;
using System.Linq;

[TestFixture]
public class OpeningWinRateListerTests
{
    private List<Game> games;

    [SetUp]
    public void SetUp()
    {
        games = new List<Game>
        {
            new Game("Tapodi, Norman Lajos", "Papp, Bence", 2100, 2300, "1-0", "Kir�lycsel", "Tournament1", new DateTime(2023, 5, 1), "e4 e5 f4...", 30),
            new Game("Papp, Bence", "Tubak, D�niel", 2300, 2200, "1/2-1/2", "Kir�lycsel", "Tournament2", new DateTime(2023, 6, 1), "e4 e5 f4...", 40),
            new Game("Tapodi, Norman Lajos", "Miszler, Levente", 2100, 2250, "0-1", "Francia v�delem", "Tournament3", new DateTime(2023, 7, 1), "e4 e6...", 50)
        };
    }

    [Test]
    public void ShowOpeningWinRates_ShowsCorrectStatistics_ForGivenOpening()
    {
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);

            OpeningWinRateLister.ShowOpeningWinRates(games, "Kir�lycsel");

            var output = writer.ToString();

            Assert.That(output, Does.Contain("Kir�lycsel nyit�s statisztik�i:"));
            Assert.That(output, Does.Contain("Nyert partik: 1 (33.33%)"));
            Assert.That(output, Does.Contain("D�ntetlen partik: 1 (33.33%)"));
            Assert.That(output, Does.Contain("Veres�gek: 0 (0.00%)"));
        }
    }

    [Test]
    public void ShowOpeningWinRates_ReturnsNoGames_ForOpeningNotInList()
    {
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);

            OpeningWinRateLister.ShowOpeningWinRates(games, "Random Defense");
            var output = writer.ToString();

            Assert.That(output, Does.Contain("Random Defense nyit�s nem szerepel a megadott j�t�kok k�z�tt."));
        }
    }
}