using ITI.Ecommerce.Models;
using ITI.Ecommerce.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseLazyLoadingProxies().UseSqlServer(@"Data Source=DESKTOP-7M0US3B\SQLEXPRESS01;initial catalog = ITI.EcommerceDB; integrated security = true;");
});
//Configure the  the controller with newtonsoftJsason packages.
builder.Services.AddControllers().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});
builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductImageService, ProductImageService>();


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(c => c.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
app.MapControllerRoute("main", "{controller=Home}/{action=Index}");
app.UseAuthorization();

 

app.Run();
