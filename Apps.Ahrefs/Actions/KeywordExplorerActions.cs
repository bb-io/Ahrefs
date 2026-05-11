using Apps.Ahrefs.Extensions;
using Apps.Ahrefs.Models.Entities;
using Apps.Ahrefs.Models.Requests.KeywordExplorer;
using Apps.Ahrefs.Models.Responses.KeywordExplorer;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Files;
using Blackbird.Applications.Sdk.Common.Invocation;
using Blackbird.Applications.SDK.Extensions.FileManagement.Interfaces;
using Blackbird.Filters.Termbases;
using RestSharp;
using System.Text;

namespace Apps.Ahrefs.Actions;

[ActionList("Keyword explorer")]
public class KeywordExplorerActions(InvocationContext invocationContext, IFileManagementClient fileManagementClient) : Invocable(invocationContext)
{
    [Action("Get keywords", Description = "Gets a keyword overview for the specified target, country and keywords")]
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
        var result = await Client.ExecuteWithErrorHandling<KeywordsResponse>(restRequest);
        result.TermbaseFile = await BuildTbx(result.Keywords, request.Country);
        return result;
    }

    [Action("Get volume history", Description = "Gets volume history for the specified country, time period and keywords")]
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

    [Action("Get volume by country", Description = "Gets the volume of the specified keyword by country")]
    public async Task<VolumeByCountryResponse> GetVolumeByCountry([ActionParameter] GetVolumeByCountryRequest request)
    {
        string query = $"/keywords-explorer/volume-by-country?keyword={request.Keyword}&limit={request.Limit}";

        var restRequest = new RestRequest(query);
        return await Client.ExecuteWithErrorHandling<VolumeByCountryResponse>(restRequest);
    }

    [Action("Get matching terms", Description = "Gets matching terms for the specified country and keywords")]
    public async Task<KeywordIdeasResponse> GetMatchingTerms([ActionParameter] GetMatchingTermsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/matching-terms?country={request.Country}" +
            $"&select=keyword,cpc,cps,volume,first_seen"
        );
        query.AppendIfNotEmpty("keywords", request.Keywords);

        var restRequest = new RestRequest(query.ToString());
        var result = await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(restRequest);
        result.TermbaseFile = await BuildTbx(result.Keywords, request.Country);
        return result;
    }

    [Action("Get related terms", Description = "Gets related terms for the specified country and keywords")]
    public async Task<KeywordIdeasResponse> GetRelatedTerms([ActionParameter] GetRelatedTermsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/related-terms?country={request.Country}" +
            $"&select=keyword,cpc,cps,volume,first_seen"
        );
        query.AppendIfNotEmpty("keywords", request.Keywords);

        var restRequest = new RestRequest(query.ToString());
        var result = await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(restRequest);
        result.TermbaseFile = await BuildTbx(result.Keywords, request.Country);
        return result;
    }  
        
    [Action("Get search suggestions", Description = "Gets search suggestions for the specified country and keywords")]
    public async Task<KeywordIdeasResponse> GetSearchSuggestions([ActionParameter] GetSearchSuggestionsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/search-suggestions?country={request.Country}" +
            $"&select=keyword,cpc,cps,volume,first_seen"
        );
        query.AppendIfNotEmpty("keywords", request.Keywords);

        var restRequest = new RestRequest(query.ToString());
        var result = await Client.ExecuteWithErrorHandling<KeywordIdeasResponse>(restRequest);
        result.TermbaseFile = await BuildTbx(result.Keywords, request.Country);
        return result;
    }

    private async Task<FileReference> BuildTbx(IEnumerable<IKeyword> keywords, string language)
    {
        var termbase = new Termbase
        {
            Language = language,
            TbxFileName = "ahrefs_export.tbx"
        };

        foreach(var keyword in keywords)
        {
            var groupId = "ahrefs_group_" + keyword.Word.Replace(' ', '_');
            var termId = "ahrefs_term_" + keyword.Word.Replace(' ', '_'); ;
            var group = new TermGroup() { Definition = keyword.Word, Id = groupId, Terms = [new Term(keyword.Word, language) { Id = termId}] };
            termbase.TermGroups.Add(group);
        }

        return await fileManagementClient.UploadAsync(new MemoryStream(Encoding.UTF8.GetBytes(termbase.Serialize())), "application/x-tbx", termbase.TbxFileName);
    }
}
