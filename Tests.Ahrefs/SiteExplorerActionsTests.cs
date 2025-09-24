using Apps.Ahrefs.Actions;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Newtonsoft.Json;
using Tests.Ahrefs.Base;

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
        PrintJsonResult(result);
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
        PrintJsonResult(result);
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
        PrintJsonResult(result);
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
        PrintJsonResult(result);
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
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetReferringDomains_TargetOnly_ReturnsReferringDomains()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetReferringDomainsRequest { Target = "ahrefs.com" };

        // Act
        var result = await actions.GetReferringDomains(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetReferringDomains_TargetAndMode_ReturnsReferringDomains()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetReferringDomainsRequest { Target = "ahrefs.com", Mode = "exact" };

        // Act
        var result = await actions.GetReferringDomains(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetReferringDomains_TargetAndModeAndProtocol_ReturnsReferringDomains()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetReferringDomainsRequest { Target = "ahrefs.com", Mode = "exact", Protocol = "http" };

        // Act
        var result = await actions.GetReferringDomains(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetAnchors_TargetOnly_ReturnsAnchors()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetAnchorsRequest { Target = "ahrefs.com" };

        // Act
        var result = await actions.GetAnchors(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task GetAnchors_TargetAndMode_ReturnsAnchors()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetAnchorsRequest { Target = "ahrefs.com", Mode = "exact" };

        // Act
        var result = await actions.GetAnchors(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetAnchors_TargetAndModeAndProtocol_ReturnsAnchors()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetAnchorsRequest { Target = "ahrefs.com", Mode = "exact", Protocol = "http" };

        // Act
        var result = await actions.GetAnchors(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    private static void PrintJsonResult(object result)
    {
        Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
    }
}
