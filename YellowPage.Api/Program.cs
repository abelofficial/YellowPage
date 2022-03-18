using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Net.Http.Headers;

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

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
        builder =>
        {
            builder.WithOrigins("http://localhost:3000", "https://yellow-page.vercel.app", "https://yellowpage.abel.st")
            .WithHeaders(HeaderNames.AccessControlAllowOrigin, "*");
        });
});


var app = builder.Build();



app.UseSwagger();
app.UseSwaggerUI(options =>
{
    options.DefaultModelsExpandDepth(-1);
});

app.UseCors(MyAllowSpecificOrigins);



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
