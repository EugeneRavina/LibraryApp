using Library.BFF.Api;
using Library.BFF.Core.Services;
using Microsoft.Extensions.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register IHttpClientFactory
builder.Services.AddHttpClient();

//Register services
builder.Services.AddScoped<ILibraryService, LibraryService>();

// Add AppSettings
builder.Services.Configure<AppSettings>(builder.Configuration.GetSection("AppSettings"));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Enable CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("libraryUI",
        policy =>
        {
            policy.WithOrigins("http://localhost:4200") // Angular app URL
                  .AllowAnyHeader()
                  .AllowAnyMethod();
        });
});

var app = builder.Build();

// Use CORS
app.UseCors("libraryUI");

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