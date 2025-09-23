using Apps.Ahrefs.Api;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;

namespace Apps.Ahrefs.Actions;

[ActionList("Keyword explorer")]
public class KeywordExplorerActions(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [Action("Get keywords", Description = "Gets all keywords of the specified target, country and keywords")]
    public async Task<KeywordsResponse> GetKeywords([ActionParameter] GetKeywordsRequest request)
    {
        var client = new AhrefsClient(Creds);
        return await client.GetKeywords(request);
    }
}
