using Microsoft.EntityFrameworkCore;
using WebApi_Project.Interfaces;
using WebApi_Project.Models;
using WebApi_Project.Services;

var builder = WebApplication.CreateBuilder(args);

// ≈÷«›… Ê ﬂÊÌ‰ ApplicationDbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServerDb")));




// ≈÷«›… «·Œœ„«  «·√Œ—Ï° „À· «·‹ Controllers
builder.Services.AddControllers();


//builder.Services.AddScoped<IProductService, ProductService>();

// ﬁœ  Õ «Ã ≈·Ï ≈÷«›… Â–« ≈–« ﬂ‰   ” Œœ„ Swaggerz
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//  ﬂÊÌ‰ «·„Ê«”Ì— «·Ê”Ìÿ… (Middleware)
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();
