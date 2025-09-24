using Tests.Ahrefs.Base;
using Apps.Ahrefs.Actions;
using Apps.Ahrefs.Models.Requests;

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
}
