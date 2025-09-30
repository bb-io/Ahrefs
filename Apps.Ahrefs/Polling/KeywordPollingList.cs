using RestSharp;
using System.Text;
using Apps.Ahrefs.Extensions;
using Apps.Ahrefs.Polling.Models;
using Apps.Ahrefs.Models.Requests.SiteExplorer;
using Apps.Ahrefs.Models.Requests.KeywordExplorer;
using Apps.Ahrefs.Models.Responses.SiteExplorer;
using Apps.Ahrefs.Models.Responses.KeywordExplorer;
using Blackbird.Applications.Sdk.Common.Polling;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Ahrefs.Polling;

[PollingEventList("Keywords")]
public class KeywordPollingList(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [PollingEvent("On new suggested keyword", Description = "Triggers whenever new suggested keywords appear")]
    public async Task<PollingEventResponse<PollingMemory, KeywordIdeasResponse>> OnNewSuggestedKeyword(
        PollingEventRequest<PollingMemory> pollingRequest,
        [PollingEventParameter] GetSearchSuggestionsRequest suggestionsRequest
    )
    {
        if (pollingRequest.Memory is null)
            return DontFlyBird<KeywordIdeasResponse>();

        var query = new StringBuilder(
            $"/keywords-explorer/search-suggestions?country={suggestionsRequest.Country}" +
            $"&select=keyword,cpc,cps,volume,first_seen&order_by=first_seen" +
            $"&where={{ \"field\": \"first_seen\", \"is\": [\"gt\", \"{pollingRequest.Memory!.LastPollingTime:yyyy-MM-dd'T'HH:mm:ss'Z'}\"] }}"
        );
        query.AppendIfNotEmpty("keywords", suggestionsRequest.Keywords);

        var request = new RestRequest(query.ToString());
        var result = await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(request);

        if (!result.Keywords.Any())
            return DontFlyBird<KeywordIdeasResponse>();

        return new()
        {
            FlyBird = true,
            Result = result,
            Memory = new() { LastPollingTime = DateTime.UtcNow }
        };
    }

    [PollingEvent("On tracked keyword ranking drop", Description = "Triggers whenever a tracking keyword drops in rank")]
    public async Task<PollingEventResponse<PollingMemory, KeywordHistoryResponse>> OnTrackedKeywordRankingDrop(
        PollingEventRequest<PollingMemory> pollingRequest,
        [PollingEventParameter] GetKeywordHistoryRequest keywordHistoryRequest
    )
    {
        if (pollingRequest.Memory is null)
            return DontFlyBird<KeywordHistoryResponse>();

        var query = new StringBuilder(
            $"/site-explorer/keywords-history?select=date,top3,top4_10,top11_plus,top11_20,top21_50,top51_plus" +
            $"&date_from={pollingRequest.Memory!.LastPollingTime:yyyy-MM-dd'T'HH:mm:ss'Z'}" +
            $"&date_to={pollingRequest.PollingTime:yyyy-MM-dd'T'HH:mm:ss'Z'}"
        );
        query.AppendIfNotEmpty("mode", keywordHistoryRequest.Mode);
        query.AppendIfNotEmpty("target", keywordHistoryRequest.Target);
        query.AppendIfNotEmpty("history_grouping", keywordHistoryRequest.HistoryGrouping ?? "daily");

        var request = new RestRequest(query.ToString());
        var result = await Client.ExecuteWithErrorHandling<KeywordHistoryResponse>(request);

        bool dropped = CheckIfKeywordRankingDropped(result);

        if (!dropped)
            return DontFlyBird<KeywordHistoryResponse>();
        else return new()
        {
            FlyBird = true,
            Result = result,
            Memory = new() { LastPollingTime = DateTime.UtcNow }
        };
    }

    private static bool CheckIfKeywordRankingDropped(KeywordHistoryResponse historyResponse)
    {
        var history = historyResponse.KeywordHistory.OrderBy(x => x.Date).ToList();
        if (history.Count < 2)
            return false;

        var prev = history[^2];
        var latest = history[^1];

        return latest.Top3 < prev.Top3 ||
                latest.Top4_10 < prev.Top4_10 ||
                latest.Top11_20 < prev.Top11_20 ||
                latest.Top21_50 < prev.Top21_50 ||
                latest.Top51Plus < prev.Top51Plus;
    }
    
    private static PollingEventResponse<PollingMemory, T> DontFlyBird<T>()
    {
        return new()
        {
            FlyBird = false,
            Memory = new() { LastPollingTime = DateTime.UtcNow }
        };
    }
}
