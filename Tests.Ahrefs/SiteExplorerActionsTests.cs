using Tests.Ahrefs.Base;
using Apps.Ahrefs.Actions;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;

namespace Tests.Ahrefs;

[TestClass]
public class SiteExplorerActionsTests : TestBase
{
    [TestMethod]
    public async Task GetAllBacklinks_TargetOnly_ReturnsBacklinks()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetAllBacklinksRequest { Target = "wordcount.com" };

        // Act
        var result = await actions.GetAllBacklinks(request);

        // Assert
        PrintBacklinks(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetAllBacklinks_TargetAndMode_ReturnsBacklinks()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetAllBacklinksRequest { Target = "wordcount.com", Mode = "exact" };

        // Act
        var result = await actions.GetAllBacklinks(request);

        // Assert
        PrintBacklinks(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetAllBacklinks_TargetAndModeAndProtocol_ReturnsBacklinks()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetAllBacklinksRequest { Target = "wordcount.com", Mode = "exact", Protocol = "http" };

        // Act
        var result = await actions.GetAllBacklinks(request);

        // Assert
        PrintBacklinks(result);
        Assert.IsNotNull(result);
    }

    private static void PrintBacklinks(BacklinksResponse result)
    {
        Console.WriteLine($"Total count: {result.Backlinks.Count()}");
        foreach (var item in result.Backlinks)
        {
            Console.WriteLine($"{item.Anchor} - {item.UrlTo}");
        }
    }
}
