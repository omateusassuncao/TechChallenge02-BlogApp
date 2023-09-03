using BlogRealProblems.Controller;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Builder;
using BlogRealProblems.Models;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();

//Connection SQL Server DB
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
builder.Services.AddDbContext<ApplicationContext>(opts => opts.UseSqlServer(connectionString));

//HttpRequest Services
builder.Services.AddControllers();
builder.Services.AddScoped<NoticiaController>();
builder.Services.AddTransient<Repository>();


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "NoticiasPowerPlatform", Version = "v1" });
});


////cors
//var politica = "CorsPolicy-public";

//builder.Services.AddCors(option => option.AddPolicy(politica, builder => builder.WithOrigins("http://localhost:4200", "https://localhost")
//     .AllowAnyMethod()
//                .AllowAnyHeader()
//                .AllowCredentials()
//                .Build()));

////authentication
//var key = Encoding.ASCII.GetBytes("1f1ce09a-0b07-4fd8-889e-e3e18442b081");

//builder.Services.AddAuthentication(x =>
//{
//x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//}).AddJwtBearer(x =>
//{
//x.RequireHttpsMetadata = false;
//x.SaveToken = true;
//x.TokenValidationParameters = new TokenValidationParameters
//{
//    ValidateIssuerSigningKey = true,
//    IssuerSigningKey = new SymmetricSecurityKey(key),
//    ValidateIssuer = false,
//    ValidateAudience = false
//};
//});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();
app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});

//cors
//app.UseCors("CorsPolicy-public");
//app.UseAuthorization();

app.MapRazorPages();

app.Run();
