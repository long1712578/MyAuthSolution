using Duende.IdentityModel.Client;

var client = new HttpClient();
var disco = await client.GetDiscoveryDocumentAsync("https://localhost:5001");

var tokenResponse = await client.RequestClientCredentialsTokenAsync(new ClientCredentialsTokenRequest
{
    Address = disco.TokenEndpoint,
    ClientId = "client",
    ClientSecret = "secret",
    Scope = "api1"
});

var apiClient = new HttpClient();
apiClient.SetBearerToken(tokenResponse.AccessToken);
var response = await apiClient.GetAsync("https://localhost:6001/identity");
Console.WriteLine(await response.Content.ReadAsStringAsync());