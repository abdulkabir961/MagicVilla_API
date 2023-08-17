using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//Take note to be able to set the request to json use addNewTonsoftJson while for xml use the other one
//builder.Services.AddControllers(option =>
//{
//    option.ReturnHttpNotAcceptable = true;
//}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();

//using serilog for logger
Log.Logger = new LoggerConfiguration().MinimumLevel.Information()
    .WriteTo.File("log/villaLogs.txt", rollingInterval: RollingInterval.Day).CreateLogger();

builder.Host.UseSerilog();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
