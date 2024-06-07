
using IdentityServer;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddLogging(logging => logging.AddConsole());


var migrationAssembly = typeof(Config).Assembly.GetName().Name;
builder.Services.AddRazorPages();

builder.Services.AddIdentityServer(options =>
{ 
    options.Events.RaiseErrorEvents = true;
    options.Events.RaiseInformationEvents = true;
    options.Events.RaiseFailureEvents = true;
    options.Events.RaiseSuccessEvents = true;
    options.EmitStaticAudienceClaim = true;
    options.ServerSideSessions.RemoveExpiredSessionsFrequency = TimeSpan.FromSeconds(60);
    options.ServerSideSessions.RemoveExpiredSessions = true;
})
    .AddTestUsers(TestUsers.Users)
    .AddInMemoryIdentityResources(Config.IdentityResources)
    .AddInMemoryApiScopes(Config.ApiScopes)
    .AddInMemoryClients(Config.Clients)
    .AddInMemoryApiResources(Config.ApiResources)
    .AddServerSideSessions();

builder.Services.AddAuthentication();

var app = builder.Build();

app.UseIdentityServer();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages().RequireAuthorization();

app.Run();

