using MvcExamenAWS2.Helpers;
using MvcExamenAWS2.Models;
using MvcExamenAWS2.Services;
using Newtonsoft.Json;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
string json = await HelperSecretManager.GetSecretsAsync();
KeysModel keys = JsonConvert.DeserializeObject<KeysModel>(json);
builder.Services.AddSingleton<KeysModel>(x => keys);

builder.Services.AddTransient<ServiceApiEventos>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
