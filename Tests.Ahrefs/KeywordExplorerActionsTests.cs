using Tests.Ahrefs.Base;
using Apps.Ahrefs.Actions;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;

namespace Tests.Ahrefs;

[TestClass]
public class KeywordExplorerActionsTests : TestBase
{
    [TestMethod]
    public async Task GetKeywords_CountryAndKeywords_ReturnsKeywords()
    {
		// Arrange
		var action = new KeywordExplorerActions(InvocationContext);
		var request = new GetKeywordsRequest { Country = "us", Keywords = ["ahrefs", "wordcount"] };

		// Act
		var result = await action.GetKeywords(request);

        // Assert
        PrintKeywords(result);
        Assert.IsNotNull(result);
    }

    [TestMethod]
    public async Task GetKeywords_CountryAndKeywordsAndTarget_ReturnsKeywords()
    {
        // Arrange
        var action = new KeywordExplorerActions(InvocationContext);
        var request = new GetKeywordsRequest { Country = "us", Keywords = ["ahrefs", "wordcount"], Target = "ahrefs.com" };

        // Act
        var result = await action.GetKeywords(request);

        // Assert
        PrintKeywords(result);
        Assert.IsNotNull(result);
    }

    private static void PrintKeywords(KeywordsResponse result)
    {
        Console.WriteLine($"Total count: {result.Keywords.Count()}");
        foreach (var item in result.Keywords)
        {
            Console.WriteLine($"{item.Word} - {item.Clicks}");
        }
    }
}
