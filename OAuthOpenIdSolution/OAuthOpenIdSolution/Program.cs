using AuthServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options =>
{
    options.EmitStaticAudienceClaim = true;
})
.AddInMemoryClients(Config.Clients)
.AddInMemoryApiScopes(Config.ApiScopes)
.AddInMemoryIdentityResources(Config.IdentityResources)
.AddDeveloperSigningCredential();

var app = builder.Build();
app.UseIdentityServer();
app.Run();