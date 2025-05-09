using Microsoft.Extensions.Azure;
using Azure.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateIssuer = true,
            ValidIssuer = builder.Configuration["JsonWebToken:Issuer"],

            ValidateAudience = true,
            ValidAudience = builder.Configuration["JsonWebToken:Audience"],

            ValidateLifetime = false,

            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JsonWebToken:Key"])),
        };
    });
    

builder.Services.InfrastructureRegister(builder.Configuration);
builder.Services.PersistenceRegister(builder.Configuration);
builder.Services.ApplicationRegister();


var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<CultureMiddleware>();

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseMiddleware<UserExistsMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
