using Apps.Ahrefs.Constants;
using Apps.Ahrefs.Extensions;
using Apps.Ahrefs.Models.Requests;
using Apps.Ahrefs.Models.Responses;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RestSharp;
using System.Text;

namespace Apps.Ahrefs.Api;

public class AhrefsClient : BlackBirdRestClient
{
    public AhrefsClient(IEnumerable<AuthenticationCredentialsProvider> creds) : base(new()
    {
        BaseUrl = new Uri("https://api.ahrefs.com/v3"),
    })
    {
        this.AddDefaultHeader("Authorization", creds.Get(CredsNames.ApiKey).Value);
    }

    public async Task<BacklinksResponse> GetBacklinks(GetBacklinksRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/all-backlinks?target={request.Target}&" +
            "select=anchor,domain_rating_target,domain_rating_source,positions,name_source,url_from,url_to"
        );

        query.AppendIfNotEmpty("mode", request.Mode);
        query.AppendIfNotEmpty("protocol", request.Protocol);

        var restRequest = new RestRequest(query.ToString());
        return await ExecuteWithErrorHandling<BacklinksResponse>(restRequest);
    }

    public async Task<KeywordsResponse> GetKeywords(GetKeywordsRequest request)
    {
        var query = new StringBuilder(
            $"/keywords-explorer/overview?country={request.Country}&" +
            $"select=keyword,clicks,cpc,cps"
        );

        query.AppendIfNotEmpty("keywords", request.Keywords);
        query.AppendIfNotEmpty("target_mode", request.TargetMode);
        query.AppendIfNotEmpty("target", request.Target);

        var restRequest = new RestRequest(query.ToString());
        return await ExecuteWithErrorHandling<KeywordsResponse>(restRequest);
    }

    public async Task<DomainRatingResponse> GetDomainRating(GetDomainRatingRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/domain-rating?target={request.Target}" +
            $"&date={request.Date:yyyy-MM-dd}"
        );

        query.AppendIfNotEmpty("protocol", request.Protocol);

        var restRequest = new RestRequest(query.ToString());
        return await ExecuteWithErrorHandling<DomainRatingResponse>(restRequest);
    }

    public async Task<ReferringDomainsResponse> GetReferringDomains(GetReferringDomainsRequest request)
    {
        var query = new StringBuilder(
            $"/site-explorer/refdomains?target={request.Target}" +
            $"&select=domain,dofollow_refdomains,domain_rating,links_to_target,positions_source_domain"
        );

        query.AppendIfNotEmpty("protocol", request.Protocol);
        query.AppendIfNotEmpty("mode", request.Mode);

        var restRequest = new RestRequest(query.ToString());
        return await ExecuteWithErrorHandling<ReferringDomainsResponse>(restRequest);
    }

    public override async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);

        if (!response.IsSuccessStatusCode)
            throw ConfigureErrorException(response);

        return response;
    }

    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var response = await ExecuteWithErrorHandling(request);
        return JsonConvert.DeserializeObject<T>(response.Content, JsonSettings);
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var responseContent = response.Content;

        if (responseContent.Contains("Insufficient plan"))
            throw new PluginMisconfigurationException("Your Ahrefs plan does not support this action");

        var errorMessage = JArray.Parse(response.Content)[0].ToString();
        throw new PluginApplicationException(errorMessage);
    }
}