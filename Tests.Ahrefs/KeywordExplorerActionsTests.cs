using Tests.Ahrefs.Base;
using Apps.Ahrefs.Actions;
using Apps.Ahrefs.Models.Requests.KeywordExplorer;
using Blackbird.Applications.Sdk.Common.Exceptions;

namespace Tests.Ahrefs;

[TestClass]
public class KeywordExplorerActionsTests : TestBase
{
    private const string FreeKeywordAhrefs = "ahrefs";
    private const string FreeKeywordWordcount = "wordcount";

    [TestMethod]
    public async Task GetKeywords_CountryAndKeywords_ReturnsKeywords()
    {
		// Arrange
		var action = new KeywordExplorerActions(InvocationContext);
		var request = new GetKeywordsRequest { Country = "us", Keywords = [FreeKeywordAhrefs, FreeKeywordWordcount] };

		// Act
		var result = await action.GetKeywords(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetKeywords_CountryAndKeywordsAndTarget_ReturnsKeywords()
    {
        // Arrange
        var action = new KeywordExplorerActions(InvocationContext);
        var request = new GetKeywordsRequest { Country = "us", Keywords = [FreeKeywordAhrefs, FreeKeywordWordcount], Target = "ahrefs.com" };

        // Act
        var result = await action.GetKeywords(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetRelatedTerms_CountryAndKeywords_ReturnsRelatedTerms()
    {
        // Arrange
        var actions = new KeywordExplorerActions(InvocationContext);
        var request = new GetRelatedTermsRequest { Country = "us", Keywords = [FreeKeywordAhrefs, FreeKeywordWordcount] };

        // Act
        var result = await actions.GetRelatedTerms(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetVolumeHistory_NoDates_ReturnsVolumeHistory()
    {
        // Arrange
        var actions = new KeywordExplorerActions(InvocationContext);
        var request = new GetVolumeHistoryRequest { Country = "us", Keyword = FreeKeywordAhrefs };

        // Act
        var result = await actions.GetVolumeHistory(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }
    
    [TestMethod]
    public async Task GetVolumeHistory_CorrectDates_ReturnsVolumeHistory()
    {
        // Arrange
        var actions = new KeywordExplorerActions(InvocationContext);
        var request = new GetVolumeHistoryRequest
        {
            Country = "us",
            Keyword = FreeKeywordAhrefs,
            DateFrom = new DateTime(2025, 01, 01),
            DateTo = DateTime.Now,
        };

        // Act
        var result = await actions.GetVolumeHistory(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetVolumeHistory_IncorrectDates_ThrowsException()
    {
        // Arrange
        var actions = new KeywordExplorerActions(InvocationContext);
        var request = new GetVolumeHistoryRequest { 
            Country = "us", 
            Keyword = FreeKeywordAhrefs, 
            DateFrom = DateTime.Now, 
            DateTo = DateTime.Now - TimeSpan.FromDays(1)
        };

        // Act & Assert
        await Assert.ThrowsExactlyAsync<PluginMisconfigurationException>(async () => await actions.GetVolumeHistory(request));
    }

    [TestMethod]
    public async Task GetVolumeByCountry_WithLimit_ReturnsCountries()
    {
        // Arrange
        var actions = new KeywordExplorerActions(InvocationContext);
        int limit = 50;
        var request = new GetVolumeByCountryRequest { Keyword = FreeKeywordAhrefs, Limit = limit };

        // Act
        var result = await actions.GetVolumeByCountry(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
        Assert.AreEqual(limit, result.VolumeByCountry.Count);
    }

    [TestMethod]
    public async Task GetVolumeByCountry_WithNoLimit_ReturnsCountries()
    {
        // Arrange
        var actions = new KeywordExplorerActions(InvocationContext);
        var request = new GetVolumeByCountryRequest { Keyword = FreeKeywordAhrefs };

        // Act
        var result = await actions.GetVolumeByCountry(request);

        // Assert
        PrintJsonResult(result);
        Assert.IsNotNull(result);
        Assert.AreEqual(20, result.VolumeByCountry.Count);
    }

    [TestMethod]
    public async Task GetMatchingTerms_ReturnsMatchingTerms()
    {
        // Arrange
        var actions = new KeywordExplorerActions(InvocationContext);
        var request = new GetMatchingTermsRequest { Country = "us", Keywords = [FreeKeywordAhrefs, FreeKeywordWordcount] };

        // Act
        var response = await actions.GetMatchingTerms(request);

        // Assert
        PrintJsonResult(response);
        Assert.IsNotNull(response);
    }
}
