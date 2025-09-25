using RestSharp;
using Newtonsoft.Json;
using Apps.Ahrefs.Constants;
using Apps.Ahrefs.Models.Utility;
using Blackbird.Applications.Sdk.Utils.RestSharp;
using Blackbird.Applications.Sdk.Utils.Extensions.Sdk;
using Blackbird.Applications.Sdk.Common.Exceptions;
using Blackbird.Applications.Sdk.Common.Authentication;

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

    public override async Task<RestResponse> ExecuteWithErrorHandling(RestRequest request)
    {
        var response = await ExecuteAsync(request);

        if (!response.IsSuccessStatusCode)
            throw ConfigureErrorException(response);

        return response;
    }

    public override async Task<T> ExecuteWithErrorHandling<T>(RestRequest request)
    {
        var restResponse = await ExecuteWithErrorHandling(request);
        var result = JsonConvert.DeserializeObject<T>(restResponse.Content, JsonSettings);

        if (result is UnitsResponse unitsResponse)
            GetUnitsFromHeader(unitsResponse, restResponse);

        return result;
    }

    private static void GetUnitsFromHeader(UnitsResponse unitsResponse, RestResponse restResponse)
    {
        var header = restResponse.Headers.FirstOrDefault(h => h.Name == "x-api-units-cost-total-actual");
        if (header != null && int.TryParse(header.Value?.ToString(), out var units))
            unitsResponse.ConsumedUnits = units;
    }

    protected override Exception ConfigureErrorException(RestResponse response)
    {
        var responseContent = response.Content!;

        if (responseContent.Contains("Insufficient plan"))
            throw new PluginApplicationException("Your Ahrefs plan does not support this action");

        if (responseContent.Contains("bad target: "))
            throw new PluginMisconfigurationException("Incorrect target format");

        throw new PluginApplicationException(responseContent);
    }
}