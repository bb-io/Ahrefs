using Tests.Ahrefs.Base;
using Apps.Ahrefs.Actions;
using Apps.Ahrefs.Models.Requests.SiteExplorer;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Tests.Ahrefs;

[TestClass]
public class SiteExplorerActionsTests : TestBase
{
    private const string FreeTargetAhrefsCom = "ahrefs.com";
    private const string FreeTargetWordcountCom = "wordcount.com";

    [TestMethod]
    public async Task GetBacklinks_InsufficientPlan_ThrowsException()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetBacklinksRequest { Target = "blackbird.io" };

        // Act & Assert
        await Assert.ThrowsExactlyAsync<PluginMisconfigurationException>(async () => await actions.GetBacklinks(request));
    }

    [TestMethod]
    public async Task GetBacklinks_TargetOnly_ReturnsBacklinks()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetBacklinksRequest { Target = FreeTargetWordcountCom };

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
        var request = new GetBacklinksRequest { Target = FreeTargetWordcountCom, Mode = "exact" };

        // Act
        var result = await actions.GetBacklinks(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetDomainRating_DatetimeNow_ReturnsDomainRating()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetDomainRatingRequest { Target = FreeTargetAhrefsCom, Date = DateTime.Now };

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
        var request = new GetReferringDomainsRequest { Target = FreeTargetAhrefsCom };

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
        var request = new GetReferringDomainsRequest { Target = FreeTargetAhrefsCom, Mode = "exact" };

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
        var request = new GetAnchorsRequest { Target = FreeTargetAhrefsCom };

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
        var request = new GetAnchorsRequest { Target = FreeTargetAhrefsCom, Mode = "exact" };

        // Act
        var result = await actions.GetAnchors(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task GetAnchors_IncorrectTargetFormat_ThrowsException()
    {
        // Arrange
        var actions = new SiteExplorerActions(InvocationContext);
        var request = new GetAnchorsRequest { Target = "incorrect!!!!!", Mode = "exact" };

        // Act & Assert
        await Assert.ThrowsExactlyAsync<PluginMisconfigurationException>(async () => await actions.GetAnchors(request));
    }
}
