using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Validation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// register all layer services
builder.Services
    .ConfigureApplicationServices()
    .ConfigurePersistenceServices();



// healthCheck config
builder.Services.AddHealthChecks();

// openIddict config
var openIddictSetting = builder.Configuration.GetSection("OpenIddict");

builder.Services.AddOpenIddict()
    .AddValidation(options =>
    {
        options.SetIssuer(openIddictSetting["AuthorizationServer"]!);
        options.AddAudiences(openIddictSetting["ResourceName"]!);

        options.AddEncryptionKey(new SymmetricSecurityKey(
            Convert.FromBase64String(openIddictSetting["EncryptionKey"]!)));

        options.UseSystemNetHttp();

        options.UseAspNetCore();
    });

builder.Services.AddAuthentication(OpenIddictValidationAspNetCoreDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();





var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapHealthChecks("/healthz");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
