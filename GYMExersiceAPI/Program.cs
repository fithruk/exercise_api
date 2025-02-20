
using GYMExersiceAPI.ExersiceStore.DataAccess;
using GYMExersiceAPI.ExersiceStore.DataAccess.DataFeeder;
using GYMExersiceAPI.ExersiceStore.DataAccess.Repositories;
using GYMExersiceAPI.Sevices;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ExerciseStroreDBContext>(options =>
    options.UseMySql(connectionString, 
        new MySqlServerVersion(new Version(8, 0, 25)),
        mysqlOptions => mysqlOptions.EnableRetryOnFailure()));


builder.Services.AddScoped<Feeder>();
builder.Services.AddScoped<ExersiceRepository>();
builder.Services.AddScoped<ExersiceStepRepository>();
builder.Services.AddScoped<ExersiceInstructionsRepository>();
builder.Services.AddScoped<ExerciseService>();
builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        policy =>
        {
            policy.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
        });
});


var app = builder.Build();

app.UseCors("AllowAll"); 
app.UseRouting();
app.MapControllers();


if (app.Environment.IsDevelopment())
{
    //app.MapOpenApi();
    app.UseDeveloperExceptionPage();
}

//app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var dbContext = scope.ServiceProvider.GetRequiredService<ExerciseStroreDBContext>();
   Feeder feeder = scope.ServiceProvider.GetRequiredService<Feeder>();
   await feeder.FeedAsync();
   await dbContext.SaveChangesAsync();
}


app.Run();
