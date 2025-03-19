using BookMyStay.Api;
using BookMyStay.Api.Services;
using BookMyStay.Api.Services.Abstractions;

var builder = WebApplication.CreateBuilder(args);

builder.AddServiceDefaults();

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddSingleton<DataSource>();
builder.Services.AddSingleton<MyFirstService>();
builder.Services.AddSingleton<ISingletonOperation, SingletonOperation>();
builder.Services.AddScoped<IScopedOperation, ScopedOperation>();
builder.Services.AddTransient<ITransientOperation, TransientOperation>();

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        c.RoutePrefix = string.Empty; 
    });
}


app.MapDefaultEndpoints();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();


//transiet -> when service required