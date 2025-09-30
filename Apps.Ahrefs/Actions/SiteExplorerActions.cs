using Apps.Ahrefs.Extensions;
using Apps.Ahrefs.Models.Requests.SiteExplorer;
using Apps.Ahrefs.Models.Responses.SiteExplorer;
using Blackbird.Applications.Sdk.Common;
using Blackbird.Applications.Sdk.Common.Actions;
using Blackbird.Applications.Sdk.Common.Invocation;
using RestSharp;
using System.Text;

namespace Apps.Ahrefs.Actions;

[ActionList("Site explorer")]
public class SiteExplorerActions(InvocationContext invocationContext) : Invocable(invocationContext)
{
    [Action("Get backlinks", Description = "Gets all backlinks for the specified target")]
    public async Task<BacklinksResponse> GetBacklinks([ActionParameter] GetBacklinksRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/all-backlinks?target={request.Target}&" +
            "select=anchor,domain_rating_target,domain_rating_source,positions,name_source,url_from,url_to"
        );

        query.AppendIfNotEmpty("mode", request.Mode);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<BacklinksResponse>(restRequest);
    }

    [Action("Get domain rating", Description = "Gets the domain rating of the specified target for a specific date")]
    public async Task<DomainRatingResponse> GetDomainRating([ActionParameter] GetDomainRatingRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/domain-rating?target={request.Target}" +
            $"&date={request.Date:yyyy-MM-dd}"
        );

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<DomainRatingResponse>(restRequest);
    }

    [Action("Get referred domains", Description = "Gets referring domains for the specified target")]
    public async Task<ReferringDomainsResponse> GetReferringDomains([ActionParameter] GetReferringDomainsRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/refdomains?target={request.Target}" +
            $"&select=domain,dofollow_refdomains,domain_rating,links_to_target,positions_source_domain"
        );

        query.AppendIfNotEmpty("mode", request.Mode);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<ReferringDomainsResponse>(restRequest);
    }

    [Action("Get anchors", Description = "Gets anchors for the specified target")]
    public async Task<AnchorsResponse> GetAnchors([ActionParameter] GetAnchorsRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/anchors?target={request.Target}" +
            $"&select=anchor,links_to_target,lost_links,refdomains,refpages,top_domain_rating"
        );

        query.AppendIfNotEmpty("mode", request.Mode);

        var restRequest = new RestRequest(query.ToString());
        return await Client.ExecuteWithErrorHandling<AnchorsResponse>(restRequest);
    }
}