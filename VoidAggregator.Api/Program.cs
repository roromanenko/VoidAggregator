using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using VoidAggregator.Api;
using VoidAggregator.Bl;
using VoidAggregator.Bl.Settings;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var services = builder.Services;
var configuration = builder.Configuration;

services.Configure<StorageSetting>(configuration.GetSection(nameof(StorageSetting)));
services.Configure<TokenGenerationSetting>(configuration.GetSection(nameof(TokenGenerationSetting)));

services.AddServices(configuration);
services.AddAutoMapper(config =>
{
	config.AddProfile<VoidAggregator.Api.AutomapperProfile>();
	config.AddProfile<VoidAggregator.Bl.AutomapperProfile>();
});

services.AddControllers().AddJsonOptions(opt =>
{
	opt.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
	opt.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

var tokenSetting = configuration.GetSection(nameof(TokenGenerationSetting)).Get<TokenGenerationSetting>();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(JwtBearerDefaults.AuthenticationScheme, options =>
	{
		options.RequireHttpsMetadata = false;
		options.SaveToken = true;

		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = false,
			ValidateAudience = false,
			ValidateLifetime = true,
			ValidateIssuerSigningKey = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenSetting.SecretKey)),
			ClockSkew = TimeSpan.Zero
		};

		options.Events = new JwtBearerEvents
		{
			OnChallenge = context =>
			{
				if(!context.Response.HasStarted)
				{
					// Override the response status code.
					context.Response.StatusCode = StatusCodes.Status401Unauthorized;

					// Emit the WWW-Authenticate header.
					context.Response.Headers.Append(HeaderNames.WWWAuthenticate, context.Options.Challenge);

					if(!string.IsNullOrEmpty(context.Error))
					{
						context.Response.WriteAsync(context.Error);
					}

					if(!string.IsNullOrEmpty(context.ErrorDescription))
					{
						context.Response.WriteAsync(context.ErrorDescription);
					}
				}
				context.HandleResponse();
				return Task.FromResult(0);
			}
		};
	});

var app = builder.Build();

// Configure the HTTP request pipeline.
if(app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

using(var serviceScope = (app as IApplicationBuilder).ApplicationServices.GetService<IServiceScopeFactory>()!.CreateScope())
{
	serviceScope.TryAddDb();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
