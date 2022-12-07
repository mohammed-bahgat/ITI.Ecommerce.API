using ITI.Ecommerce.Models;

using Microsoft.AspNetCore.Identity;

using ITI.Ecommerce.Services;

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle



builder.Services.AddDbContext<ApplicationDbContext>(options =>
options.UseLazyLoadingProxies().UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<Customer, IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();

//Configure the  the controller with newtonsoftJsason packages.
builder.Services.AddControllers().AddNewtonsoftJson(op =>
{
    op.SerializerSettings.Formatting = Newtonsoft.Json.Formatting.Indented;
    op.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.User.AllowedUserNameCharacters = string.Empty;
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
});




builder.Services.AddTransient<ICustomerService, CustomerService>();
builder.Services.AddTransient<IProductService, ProductService>();
builder.Services.AddTransient<IProductImageService, ProductImageService>();



builder.Services.AddEndpointsApiExplorer();
builder.Services.AddTransient<IOrderService, OrderService>();
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
