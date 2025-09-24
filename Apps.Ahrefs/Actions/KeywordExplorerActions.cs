using Apps.Ahrefs.Extensions;
using Apps.Ahrefs.Models.Requests.KeywordExplorer;
using Apps.Ahrefs.Models.Responses.KeywordExplorer;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System.Text;

namespace Apps.Ahrefs.Actions;

[ActionList("Keyword explorer")]
public class KeywordExplorerActions(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [Action("Get keywords", Description = "Gets a keyword overview of the specified target, country and keywords")]
    public async Task<KeywordsResponse> GetKeywords([ActionParameter] GetKeywordsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/overview?country={request.Country}&" +
            $"select=keyword,clicks,cpc,cps"
        );
        query.AppendIfNotEmpty("keywords", request.Keywords);
        query.AppendIfNotEmpty("target_mode", request.TargetMode);
        query.AppendIfNotEmpty("target", request.Target);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<KeywordsResponse>(restRequest);
    }

    [Action("Get volume history", Description = "Gets a volume history of the specified country, time period and keywords")]
    public async Task<VolumeHistoryResponse> GetVolumeHistory([ActionParameter] GetVolumeHistoryRequest request)
    {
        if (request.DateFrom != null && request.DateTo != null)
        {
            if (request.DateFrom > request.DateTo)
                throw new PluginMisconfigurationException("Invalid date range");
        }

        var query = new StringBuilder($"/keywords-explorer/volume-history?keyword={request.Keyword}&country={request.Country}");
        query.AppendIfNotEmpty("date_to", $"{request.DateTo:yyyy-MM-dd}");
        query.AppendIfNotEmpty("date_from", $"{request.DateFrom:yyyy-MM-dd}");

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<VolumeHistoryResponse>(restRequest);
    }

    [Action("Get volume by country", Description = "Gets a volume of the specified keyword by country")]
    public async Task<VolumeByCountryResponse> GetVolumeByCountry([ActionParameter] GetVolumeByCountryRequest request)
    {
        string query = $"/keywords-explorer/volume-by-country?keyword={request.Keyword}&limit={request.Limit}";

        var restRequest = new RestRequest(query);
        return await Client.ExecuteWithErrorHandling<VolumeByCountryResponse>(restRequest);
    }

    [Action("Get mathing terms", Description = "Gets matching terms of the specified country and keywords")]
    public async Task<KeywordIdeasResponse> GetMatchingTerms([ActionParameter] GetMatchingTermsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/matching-terms?country={request.Country}" +
            $"&select=keyword,cpc,cps,volume"
        );
        query.AppendIfNotEmpty("keywords", request.Keywords);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(restRequest);
    }

    [Action("Get related terms", Description = "Gets related terms of the specified country and keywords")]
    public async Task<KeywordIdeasResponse> GetRelatedTerms([ActionParameter] GetRelatedTermsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/related-terms?country={request.Country}" +
            $"&select=keyword,cpc,cps,volume&keywords=wordcount,ahrefs"
        );
        query.AppendIfNotEmpty("keywords", request.Keywords);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(restRequest);
    }

    [Action("Get search suggestions", Description = "Gets search suggestions of the specified country and keywords")]
    public async Task<KeywordIdeasResponse> GetSearchSuggestions([ActionParameter] GetSearchSuggestionsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/search-suggestions?country={request.Country}" +
            $"&select=keyword,cpc,cps,volume&keywords=wordcount,ahrefs"
        );
        query.AppendIfNotEmpty("keywords", request.Keywords);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(restRequest);
    }
}
