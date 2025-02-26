using BLL.Services;
using BLL.ServicesContracts;
using DAL;
using DAL.Repositories;
using DAL.RepositoriesContracts;
using Microsoft.EntityFrameworkCore;
using WebApp.Filters;

var builder = WebApplication.CreateBuilder(args);

// Ajout de la clé API ici
string apiKey = builder.Configuration.GetValue<string>("ApiSettings:ApiKey"); // Assure-toi d'avoir la clé dans ton appsettings.json ou ailleurs

// Configuration de la base de données
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Ajout des services au container
builder.Services.AddControllers(options =>
{
    // Ajout du filtre ApiKeyFilter à toutes les actions
    options.Filters.Add(new ApiKeyFilter(apiKey));
});

// Services de l'application
builder.Services.AddScoped<IApplicationService, ApplicationService>();
builder.Services.AddScoped<IPasswordService, PasswordService>();

// Repositories
builder.Services.AddScoped<IApplicationRepository, ApplicationRepository>();
builder.Services.AddScoped<IPasswordRepository, PasswordRepository>();

// Ajout de Swagger
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configuration de Swagger
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

// Configuration de la requête HTTP
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseAuthorization();
app.MapControllers(); // Aucun argument ici, il n'est plus nécessaire d'ajouter le filtre ici

app.Run();
