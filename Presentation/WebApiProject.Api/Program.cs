var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

//Prod ve Dev ortamýn config ayarlarýnýn otomatikleþtirme iþlemleri.
builder.Configuration
    .SetBasePath(env.ContentRootPath) //WebApiProject.Api nin bulunduðu path'i local veya sunucu olsun otomatik olarak alýr.
    .AddJsonFile("appsettings.json", optional: false) //Her zaman bu dosyayý okuyacak.
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); //Burasý olabilir veya olmayabilir. Opsiyoneldir.

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseAuthorization();

app.MapControllers();

app.Run();

