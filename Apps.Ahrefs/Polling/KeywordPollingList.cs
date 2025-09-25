using Apps.Ahrefs.Extensions;
using Apps.Ahrefs.Models.Requests.KeywordExplorer;
using Apps.Ahrefs.Models.Responses.KeywordExplorer;
using Apps.Ahrefs.Polling.Models;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.Sdk.Common.Polling;
using RestSharp;
using System.Text;

namespace Apps.Ahrefs.Polling;

[PollingEventList("Keywords")]
public class KeywordPollingList(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [PollingEvent("On new suggested keyword", Description = "On new suggested keyword")]
    public async Task<PollingEventResponse<PollingMemory, KeywordIdeasResponse>> OnNewSuggestedKeyword(
        PollingEventRequest<PollingMemory> pollingRequest,
        [PollingEventParameter] GetSearchSuggestionsRequest suggestionsRequest
    )
    {
        if (pollingRequest.Memory is null)
            DontFlyBird();

        var query = new StringBuilder(
            $"/keywords-explorer/search-suggestions?country={suggestionsRequest.Country}" +
            $"&select=keyword,cpc,cps,volume,first_seen&order_by=first_seen" +
            $"&where={{ \"field\": \"first_seen\", \"is\": [\"gt\", \"{pollingRequest.Memory!.LastPollingTime:yyyy-MM-dd'T'HH:mm:ss'Z'}\"] }}"
        );
        query.AppendIfNotEmpty("keywords", suggestionsRequest.Keywords);

        var request = new RestRequest(query.ToString());
        var result = await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(request);

        if (!result.Keywords.Any())
            DontFlyBird();

        return new()
        {
            FlyBird = true,
            Result = result,
            Memory = new() { LastPollingTime = DateTime.UtcNow }
        };
    }

    private static PollingEventResponse<PollingMemory, KeywordIdeasResponse> DontFlyBird()
    {
        return new()
        {
            FlyBird = false,
            Memory = new() { LastPollingTime = DateTime.UtcNow }
        };
    }
}
