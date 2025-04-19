using Microsoft.EntityFrameworkCore;
using WebApi_Project.Interfaces;
using WebApi_Project.Models;
using WebApi_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// ����� ������ ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDb")));




// ����� ������� ������ ��� ��� Controllers
builder.Services.AddControllers();


//builder.Services.AddScoped<IProductService, ProductService>();

// �� ����� ��� ����� ��� ��� ��� ������ Swaggerz
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// ����� �������� ������� (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
