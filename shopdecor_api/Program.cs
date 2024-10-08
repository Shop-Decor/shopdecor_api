using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using shopdecor_api.Data;
using shopdecor_api.Models.Domain;
using shopdecor_api.Repositories.AccountRepositories;
using shopdecor_api.Repositories.BillRepositories;
using shopdecor_api.Repositories.Category_SizeRepositories;
using shopdecor_api.Repositories.CategoryColorRepositories;
using shopdecor_api.Repositories.CategoryRepositories;
using shopdecor_api.Repositories.DiscountRepositories;
using shopdecor_api.Repositories.ImageRepositories;
using shopdecor_api.Repositories.OrderDetailRepositories;
using shopdecor_api.Repositories.OrderRepositories;
using shopdecor_api.Repositories.Product_CategoryRepositories;
using shopdecor_api.Repositories.ProductDetailsRepositories;
using shopdecor_api.Repositories.ProductRepositories;
using shopdecor_api.Repositories.StatisticalRepositories;
using shopdecor_api.Services;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddNewtonsoftJson(options =>
    {
        options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
        options.SerializerSettings.PreserveReferencesHandling = Newtonsoft.Json.PreserveReferencesHandling.None;
    });

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(option =>
{
    option.SwaggerDoc("v1", new OpenApiInfo { Title = "SeaBug", Version = "v1" });
    option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter a valid token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "Bearer"
    });
    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] { }
        }
    });
});

builder.Services.AddDbContext<SeabugDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(builder.Configuration.GetConnectionString("seabug"));
});

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepnsitetory, CategoryRepositetory>();
builder.Services.AddScoped<ICategory_SizeRepositories, Category_SizeRepositories>();
builder.Services.AddScoped<ICategoryColorRepositories, CategoryColorRepositories>();
builder.Services.AddScoped<IDiscountRepository, DiscountRepository>();
builder.Services.AddScoped<IOrderRipository, OrderRepository>();
builder.Services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
builder.Services.AddScoped<IBillRepository, BillRepository>();
builder.Services.AddScoped<IImageRepository, ImageRepository>();
builder.Services.AddScoped<IAccountRepository, AccountRepository>();
builder.Services.AddScoped<IProductDetailsRepositories, ProductDetailsRepositories>();
builder.Services.AddScoped<IProduct_CategoryRepository, Product_CategoryRepository>();
builder.Services.AddScoped<StatisticalRepository>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);

builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<SeabugDbContext>()
    .AddDefaultTokenProviders();

// JWT Authentication
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(options =>
{
    options.SaveToken = true;
    options.RequireHttpsMetadata = false;
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidAudience = builder.Configuration["JWT:ValidAudience"],
        ValidIssuer = builder.Configuration["JWT:ValidIssuer"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Secret"]))
    };
});

builder.Services.AddSingleton<IVnPayService, VnPayService>();
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(builder =>
    {
        builder.WithOrigins("*")
                   .AllowAnyMethod()
                   .AllowAnyHeader();
    });
});

builder.Services.AddScoped<AccountService>();

var app = builder.Build();

// Automatically create the first admin account on startup
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var accountService = services.GetRequiredService<AccountService>();
        var result = await accountService.CreateFirstAccount();
        if (!result.Succeeded)
        {
            // Handle the error, log it if necessary
            var logger = services.GetRequiredService<ILogger<Program>>();
            logger.LogError("Failed to create first account: {Errors}", string.Join(", ", result.Errors.Select(e => e.Description)));
        }
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "An error occurred while creating the first account.");
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
