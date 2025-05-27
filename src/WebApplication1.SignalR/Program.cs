using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using WebApplication1.SignalR.Hubs;

var builder = WebApplication.CreateBuilder(args);

//builder.Services.AddRazorPages();
builder.Services.AddSignalR();

builder.Logging.AddConsole();
builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new()
    {
        ValidateIssuer = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidateAudience = true,
        ValidAudience = builder.Configuration["Jwt:Audience"],
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:SecretKey"]??"")),
        ValidateLifetime = true,
        ClockSkew = TimeSpan.FromSeconds(30),
        RequireExpirationTime = true,
    };
});
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();
//// Configure the HTTP request pipeline.
//if (!app.Environment.IsDevelopment())
//{
//    app.UseExceptionHandler("/Error");
//    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
//    app.UseHsts();
//}
//app.UseHttpsRedirection();
//app.UseStaticFiles();

app.UseRouting();

//app.UseAuthorization();
//app.MapRazorPages();

app.MapHub<ChatHub>("/chatHub");

app.Run();
