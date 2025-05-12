using AuthServer;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddIdentityServer(options =>
{
    /// Dùng để Identity tự động thêm claim audience vào token dưới dạng chuỗi tĩnh.
    options.EmitStaticAudienceClaim = true;
})
.AddInMemoryClients(Config.Clients) // Khai báo client (app) nào được xin token.
.AddInMemoryApiScopes(Config.ApiScopes) // Xác định quyền truy cập vào API.
.AddInMemoryIdentityResources(Config.IdentityResources) // Nếu user login -> sẽ cho biết cấp phát infomation gì.
.AddDeveloperSigningCredential(); // Dùng để ký token. Chỉ dùng cho dev, không dùng cho production.

var app = builder.Build();
app.UseIdentityServer();
app.Run();    
