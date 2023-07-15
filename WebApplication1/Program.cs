using WebApplication1.Extentions;
using NLog;
using Services.Contracs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

LogManager
    .LoadConfiguration(String.Concat(Directory.GetCurrentDirectory(),"/nLog.config"));

builder.Services.AddControllers(config =>
{
    config.RespectBrowserAcceptHeader = true;   
    config.ReturnHttpNotAcceptable = true;
})
    .AddApplicationPart(typeof(Presentation.AssemblyReference).Assembly);
    //.AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureSqlContext(builder.Configuration);
builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureLoggerService();
builder.Services.AddAutoMapper(typeof(Program));


var app = builder.Build();

var logger = app.Services.GetRequiredService<ILoggerService>();
app.ConfigureExceptionHandler(logger);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

if (app.Environment.IsProduction())
{
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();