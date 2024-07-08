var builder = WebApplication.CreateBuilder(args);


//Add services to the container
builder.Services.AddCarter();


builder.Services.AddMediatR(config =>
{
    config.RegisterServicesFromAssemblies(typeof(Program).Assembly);
});

builder.Services.AddMarten(opt =>
{
    opt.Connection(builder.Configuration.GetConnectionString("Database")!);
}).UseLightweightSessions();


var app = builder.Build();

//Configure the HTTP request pipeine
app.MapCarter();


app.Run();
