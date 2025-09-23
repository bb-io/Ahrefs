using Apps.Ahrefs.Api;
using Blackbird.Applications.Sdk.Common.Authentication;
using Blackbird.Applications.Sdk.Common.Connections;
using RestSharp;

namespace Apps.Ahrefs.Connections;

public class ConnectionValidator : IConnectionValidator
{
    public async ValueTask<ConnectionValidationResponse> ValidateConnection(
        IEnumerable<AuthenticationCredentialsProvider> authenticationCredentialsProviders,
        CancellationToken cancellationToken)
    {
        try
        {
            var client = new AhrefsClient(authenticationCredentialsProviders);
            var freeTestQuery = "/site-explorer/domain-rating?date=2025-09-23&target=wordcount.com";

            await client.ExecuteWithErrorHandling(new RestRequest(freeTestQuery));

            return new()
            {
                IsValid = true
            };
        }
        catch (Exception ex)
        {
            return new()
            {
                IsValid = false,
                Message = ex.Message
            };
        }

    }
}