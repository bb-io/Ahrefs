using Tests.Ahrefs.Base;
using Apps.Ahrefs.Polling;
using Apps.Ahrefs.Polling.Models;
using Apps.Ahrefs.Models.Requests.KeywordExplorer;
using Blackbird.Applications.Sdk.Common.Polling;

namespace Tests.Ahrefs;

[TestClass]
public class PollingTests : TestBase
{
    private const string FreeKeywordAhrefs = "ahrefs";
    private const string FreeKeywordWordcount = "wordcount";

    [TestMethod]
    public async Task OnNewSuggestedKeyword_ReturnsSuggestions()
    {
		// Arrange
		var polling = new KeywordPollingList(InvocationContext);
        var memory = new PollingEventRequest<PollingMemory> {
            Memory = new PollingMemory { LastPollingTime = new DateTime(2025, 09, 05, 12, 0, 0) },
            PollingTime = DateTime.UtcNow,
        };
        var request = new GetSearchSuggestionsRequest { Country = "us", Keywords = [FreeKeywordWordcount, FreeKeywordAhrefs] };

        // Act
        var result = await polling.OnNewSuggestedKeyword(memory, request);

        // Assert
        Assert.IsNotNull(result.Result);
        PrintJsonResult(result.Result);
    }
}
