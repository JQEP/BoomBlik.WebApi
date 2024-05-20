using BoomBlik.Modules.Reports;
using FluentValidation;
using Asp.Versioning;
using boomblik_api.Behaviour;
using boomblik_api.Configuration;
using boomblik_api.Middleware;
using BoomBlik.Infrastructure.Repository;
using Swashbuckle.AspNetCore.SwaggerGen;
using Microsoft.Extensions.Options;

var configuration = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")}.json", optional: true, reloadOnChange: true)
    .Build();

var builder = WebApplication.CreateBuilder(args);


builder.Services.RegisterInfrastructureRepository(builder.Configuration);

builder.Services.RegisterReportsModule(builder.Configuration);
builder.Services.RegisterInfrastructureRepository(builder.Configuration);

builder.Services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

builder.Services.AddValidatorsFromAssembly(typeof(ReportsModule).Assembly);


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(
    
        typeof(ReportsModule).Assembly
    );

    config.AddOpenBehavior(typeof(RequestValidationBehavior<,>));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy =>
    {
        var corsPolicy = configuration.GetSection("CorsPolicy");
        var allowedOrigins = corsPolicy.GetSection("AllowedOrigins").Get<string[]>();
        var allowedMethods = corsPolicy.GetSection("AllowedMethods").Get<string[]>();
        var allowedHeaders = corsPolicy.GetSection("AllowedHeaders").Get<string[]>();

        policy.WithOrigins(allowedOrigins)
            .WithMethods(allowedMethods)
            .WithHeaders(allowedHeaders);
    });
});


builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddApiVersioning(options =>
{
    options.DefaultApiVersion = new ApiVersion(1, 0);
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.ReportApiVersions = true;
})
.AddApiExplorer(options =>
{
    options.GroupNameFormat = "'v'VVV";
    options.SubstituteApiVersionInUrl = true;
});

builder.Services.AddSwaggerGen(options =>
{
    /*options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "BoomBlik API",
        Version = "v1",
        Description = "The BoomBlik API used for the BoomBlik application."
    });*/
    options.EnableAnnotations();
});

builder.Services.AddHttpLogging(logging => {
    logging.CombineLogs = true;
});

var app = builder.Build();

app.UseHttpLogging();

// Handles exceptions thrown by the application.
app.UseMiddleware<ExceptionMiddleware>();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        var descriptions = app.DescribeApiVersions();

        foreach (var description in descriptions)
        {
            options.SwaggerEndpoint($"/swagger/{description.GroupName}/swagger.json", description.GroupName.ToUpperInvariant());
        }
    });
}

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
