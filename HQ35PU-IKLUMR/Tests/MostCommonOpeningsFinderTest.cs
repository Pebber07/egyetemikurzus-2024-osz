using NUnit.Framework;
using HQ35PUIKLUMR.Model;
using HQ35PU_IKLUMR.Statistics;
using System.Collections.Generic;
using HQ35PUIKLUMR;

[TestFixture]
public class MostCommonOpeningsFinderTests
{
    private List<Game> games;

    [SetUp]
    public void SetUp()
    {
        games = new List<Game>
        {
            new Game("Player1", "Player2", 2000, 1800, "1-0", "C54", "Tournament1", new DateTime(2023, 5, 1), "1.e4 e5 2.Nf3 Nc6...", 20),
            new Game("Player3", "Player4", 2200, 1900, "0-1", "C54", "Tournament2", new DateTime(2023, 6, 1), "1.e4 c5 2.Nc3 Nc6...", 30),
            new Game("Player5", "Player6", 2100, 2000, "1/2-1/2", "A45", "Tournament3", new DateTime(2023, 7, 1), "1.d4 Nf6 2.e3 g6...", 50)
        };
    }

    [Test]
    public void FindMostCommonOpeningsWithResults_FindsTopOpeningsWithResults()
    {
        using (var writer = new StringWriter())
        {
            Console.SetOut(writer);
            MostCommonOpeningsFinder.FindMostCommonOpeningsWithResults(games, 1);

            var output = writer.ToString();
            Assert.That(output, Does.Contain(ECOCodeService.GetOpeningName("C54")));
            
        }
    }
}

