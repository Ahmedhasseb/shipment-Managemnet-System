using Applcation;
using Infrastructure;
using ShipmentApi.ExceptionMiddleWrare;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddInfrastructure(builder.Configuration.GetConnectionString("MyDB")!, builder.Configuration);
builder.Services.AddApplcation();
builder.Services.AddExceptionHandler<VaildtionExecptionHandelr>();
builder.Services.AddExceptionHandler<GlobalExecptionMiddleWare>();
builder.Services.AddProblemDetails(config =>
{
    config.CustomizeProblemDetails=option =>
    {
        option.ProblemDetails.Extensions.Add("traceId", option.HttpContext.TraceIdentifier  );
    };
});
var app = builder.Build();
await app.SeedIdentityAsync();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseExceptionHandler();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
