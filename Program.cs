using Biblia.Data.Data;
using Biblia.Data.Repositories;
using Biblia.Service.Services.Interfaces;
using Biblia.Service.Services;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()      // permite qualquer domínio
              .AllowAnyMethod()      // permite GET, POST, etc
              .AllowAnyHeader();     // permite cabeçalhos customizados
    });
});

builder.Services.AddMemoryCache();

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    }); 
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// SQLite
builder.Services.AddDbContext<BibliaContext>(options =>
    options.UseSqlite("Data Source=biblia.db"));

// Dependency Injection
builder.Services.AddScoped<IBibliaRepository, BibliaRepository>();
builder.Services.AddScoped<IBibliaService, BibliaService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// ================================================
// 🔹 CHAMADA AUTOMÁTICA DO SEED NA PRIMEIRA EXECUÇÃO
// ================================================
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var context = services.GetRequiredService<BibliaContext>();

        // Garante que o banco existe e está migrado
        await context.Database.EnsureCreatedAsync();

        // Executa o seed apenas se o banco estiver vazio
        await SeedData.InicializarAsync(context);

        Console.WriteLine("✅ Banco de dados inicializado com sucesso!");
    }
    catch (Exception ex)
    {
        Console.WriteLine("❌ Erro ao inicializar o banco de dados: " + ex.Message);
    }
}

app.UseCors("DevPolicy");

app.UseHttpsRedirection();
app.MapControllers();
app.Run();


