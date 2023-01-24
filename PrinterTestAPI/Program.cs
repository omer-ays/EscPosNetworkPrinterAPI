﻿var builder = WebApplication.CreateBuilder(args);

// Add services to the container.


builder.WebHost.UseUrls("http://localhost:53555");
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy",
        policy =>
        {
            policy.AllowAnyOrigin().SetIsOriginAllowed(isOriginAllowed: _ => true).AllowAnyMethod().AllowAnyHeader();
        });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}




app.UseCors("CorsPolicy");
app.UseAuthorization();

app.MapControllers();

app.Run();

