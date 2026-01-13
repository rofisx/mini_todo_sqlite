using Microsoft.EntityFrameworkCore;
using todoapi_sqllite.Data;

var builder = WebApplication.CreateBuilder(args);

// =====================
// Services
// =====================
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// DbContext SQLite
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// =====================
// Build App
// =====================
var app = builder.Build();

// =====================
// URLs (konsisten)
// =====================
app.Urls.Add("http://localhost:5000"); // Swagger + API
// Jika ingin HTTPS juga:
// app.Urls.Add("https://localhost:5001");

// =====================
// Middleware
// =====================
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Gunakan HTTPS opsional di dev
// app.UseHttpsRedirection();

// =====================
// Map endpoints
// =====================
app.MapControllers();
app.MapGet("/", () => "Todo API Running");

// =====================
// Run App
// =====================
app.Run();
