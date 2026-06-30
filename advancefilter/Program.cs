using advancefilter.Services;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors(options =>
{
    //options.AddPolicy("AllowFrontend",
    //    policy =>
    //    {
    //        policy.SetIsOriginAllowed(origin =>
    //                new Uri(origin).Host == "localhost")
    //              .AllowAnyHeader()
    //              .AllowAnyMethod();
    //    });

    //builder.Services.AddCors(options =>
    //{
        options.AddPolicy("AllowFrontend",
            policy =>
            {

                policy
                    .WithOrigins(
                        "http://localhost:5500",     
                        "http://127.0.0.1:5500"
                    )    
                    .AllowAnyHeader()
                    .AllowAnyMethod();
            });
    });
//});

builder.Services.AddHttpClient<GroqService>();

builder.Services.AddControllers();

builder.Services.AddSingleton<MovieCacheService>();

builder.Services.AddHttpClient<TMDBService>();

builder.Services.AddScoped<MovieFilterService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var app = builder.Build();


    app.UseSwagger();
    app.UseSwaggerUI();


app.UseCors("AllowFrontend");


app.UseHttpsRedirection();


app.UseAuthorization();


app.MapControllers();


app.Run();