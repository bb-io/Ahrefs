using Tests.Ahrefs.Base;
using Apps.Ahrefs.Actions;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Tests.Ahrefs;

[TestClass]
public class SiteExplorerActionsTests : TestBase
{
    [TestMethod]
    public async Task GetBacklinks_InsufficientPlan_ThrowsException()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetBacklinksRequest { Target = "blackbird.io" };

        // Act & Assert
        await Assert.ThrowsExceptionAsync<PluginMisconfigurationException>(async () => await actions.GetBacklinks(request));
    }

    [TestMethod]
    public async Task GetBacklinks_TargetOnly_ReturnsBacklinks()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetBacklinksRequest { Target = "wordcount.com" };

        // Act
        var result = await actions.GetBacklinks(request);

        // Assert
        PrintBacklinks(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetBacklinks_TargetAndMode_ReturnsBacklinks()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetBacklinksRequest { Target = "wordcount.com", Mode = "exact" };

        // Act
        var result = await actions.GetBacklinks(request);

        // Assert
        PrintBacklinks(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetBacklinks_TargetAndModeAndProtocol_ReturnsBacklinks()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetBacklinksRequest { Target = "wordcount.com", Mode = "exact", Protocol = "http" };

        // Act
        var result = await actions.GetBacklinks(request);

        // Assert
        PrintBacklinks(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetDomainRating_NoProtocol_ReturnsDomainRating()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetDomainRatingRequest { Target = "ahrefs.com", Date = DateTime.Now };

        // Act
        var result = await actions.GetDomainRating(request);

        // Assert
        Console.WriteLine($"{result.DomainRating.Rating} - {result.DomainRating.Rank}");
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetDomainRating_WithProtocol_ReturnsDomainRating()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetDomainRatingRequest { Target = "wordcount.com", Date = DateTime.Now, Protocol = "http" };

        // Act
        var result = await actions.GetDomainRating(request);

        // Assert
        Console.WriteLine($"{result.DomainRating.Rating} - {result.DomainRating.Rank}");
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
