using Application;
using Persistence;

var builder = WebApplication.CreateBuilder(args);

// TODO: You should call the service registrations here
builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.AddApplicationServices();

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

app.Run();