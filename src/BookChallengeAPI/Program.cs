using BookChallengeAPI.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

//configure CORS policy
var  MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy  =>
                      {
                          policy.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod();
                      });
});

// Add services to the container.

/// Adds MVC controller support to the services container. This enables routing 
/// and model binding functionality for MVC controllers.
builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//EF Core database context
builder.Services.AddDbContext <ChallengeDbContext>(dbContextOptions => 
dbContextOptions.UseSqlite(builder.Configuration.GetConnectionString("ChallengeDBConnectionString")));

builder.Services.AddSingleton<BooksFactory>();

builder.Services.AddScoped<IChallengeRepository, ChallengeRepository>();
builder.Services.AddScoped<IChallengeService, ChallengeService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


/// Configures the app to require HTTPS for all requests.
app.UseHttpsRedirection();

//marks the position in the pipeline where a routing decision is made
//app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();


/// Configures the HTTP request pipeline by adding endpoint routing 
/// middleware that maps incoming requests to controller actions.
/// marks the position in the pipeline where the selected endpoint will be executed
// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// }
// );

//instead of app.UseEndpoints(endpoints =>) and app.useRouting() you can simply use app.MapControllers();

app.MapControllers();

app.Run();
