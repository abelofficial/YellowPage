using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using YellowPage.Api.Data;
using YellowPage.Api.Services;

var builder = WebApplication.CreateBuilder(args);

if (Environment.GetEnvironmentVariable("ENVIRONMENT") == "production")
{
    var conStrBuilder = new SqlConnectionStringBuilder(
        builder.Configuration.GetConnectionString("YellowPageDbProd"));

    // Fetch connection secrets
    conStrBuilder.DataSource = Environment.GetEnvironmentVariable("DbServer");
    conStrBuilder.UserID = Environment.GetEnvironmentVariable("DbUserId");
    conStrBuilder.Password = Environment.GetEnvironmentVariable("DbPassword");
    builder.Services.AddDbContext<YellowPageDb>(options =>
    options.UseSqlServer(conStrBuilder.ConnectionString));
}
else
{
    builder.Services.AddDbContext<YellowPageDb>(options =>
       options.UseSqlServer(builder.Configuration.GetConnectionString("YellowPageDb")));
}

// configure strongly typed settings objects
var key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWTSecret"));
builder.Services.AddAuthentication(x =>
{
    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(x =>
{
    x.Events = new JwtBearerEvents
    {
        OnTokenValidated = context =>
        {
            var userService = context.HttpContext.RequestServices.GetRequiredService<IAuthService>();
            var userId = int.Parse(context.Principal.Identity.Name);
            var user = userService.GetById(userId);
            if (user == null)
            {
                // return unauthorized if user no longer exists
                context.Fail("Unauthorized");
            }
            return Task.CompletedTask;
        }
    };
    x.RequireHttpsMetadata = false;
    x.SaveToken = true;
    x.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuerSigningKey = true,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        ValidateIssuer = false,
        ValidateAudience = false
    };
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddSwaggerGen(opt =>
{
    opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyAPI", Version = "v1" });
    opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        In = ParameterLocation.Header,
        Description = "Please enter token",
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        BearerFormat = "JWT",
        Scheme = "bearer"
    });

    opt.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type=ReferenceType.SecurityScheme,
                    Id="Bearer"
                }
            },
            new string[]{}
        }
    });
});


var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});



app.UseCors(x => x.AllowAnyHeader().AllowAnyMethod().WithOrigins("http://localhost:3000"));
app.UseHttpsRedirection();

app.UseAuthorization();
app.UseAuthentication();

app.MapControllers();

app.Run();
