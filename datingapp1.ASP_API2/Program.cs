using datingapp1.Persistence.EF;
using datingapp1.Application;
using datingapp1.Persistence.EF.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddPersistenceServices(builder.Configuration);
builder.Services.DatingAppInstallation();

builder.Services.AddIdentityServices(builder.Configuration);

builder.Services.AddCors(options =>
    {
        options.AddPolicy("Open",
            builder => builder.AllowAnyOrigin()
            .AllowAnyHeader().AllowAnyMethod());
    });

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("Open");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
