using Apps.Ahrefs.Extensions;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
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

    [Action("Get related terms", Description = "Gets related terms of the specified country and keywords")]
    public async Task<RelatedTermsResponse> GetRelatedTerms([ActionParameter] GetRelatedTermsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/related-terms?country={request.Country}" +
            $"&select=keyword,cpc,cps,volume&keywords=wordcount,ahrefs"
        );

        query.AppendIfNotEmpty("keywords", request.Keywords);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<RelatedTermsResponse>(restRequest);
    }
}
