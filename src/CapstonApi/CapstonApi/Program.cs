using CapstoneData;
using CapstoneData.Provider;
using Microsoft.EntityFrameworkCore;
using Azure.Identity;
using Azure.Core;
using Azure.Security.KeyVault.Secrets;

var builder = WebApplication.CreateBuilder(args);
var configuration = new ConfigurationBuilder()
     .AddJsonFile($"appsettings.json");

var config = configuration.Build();
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c => {
    c.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
    c.IgnoreObsoleteActions();
    c.IgnoreObsoleteProperties();
    c.CustomSchemaIds(type => type.FullName);
});

SecretClientOptions options = new SecretClientOptions()
{
    Retry =
        {
            Delay= TimeSpan.FromSeconds(2),
            MaxDelay = TimeSpan.FromSeconds(16),
            MaxRetries = 5,
            Mode = RetryMode.Exponential
         }
};
var client = new SecretClient(new Uri(config.GetConnectionString("SecretUrl")), new DefaultAzureCredential(), options);

KeyVaultSecret secret = client.GetSecret(config.GetConnectionString("SecretKey"));

string secretValue = secret.Value;

builder.Services.AddDbContext<ICapstoneDBContext, CapstoneDBContext>(options =>
        options.UseSqlServer(secretValue));

builder.Services.AddTransient<IAutherProvider, AutherProvider>();
builder.Services.AddTransient<ICategoryProvider, CategoryProvider>();
builder.Services.AddTransient<ILabProvider, LabProvider>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
