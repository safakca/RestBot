using Application;
using Infrastructure;
using Persistence;
using WebAPI.Hubs;

var builder = WebApplication.CreateBuilder(args);

// TODO: You should call the service registrations here
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();
builder.Services.AddSignalR();
builder.Services.AddInfrastructureServices(builder.Configuration);



// Add services to the container.
builder.Services.AddControllers(); // MVC tabanlı Controller desteği
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

app.MapHub<ChatHub>("/chathub");

app.Run();