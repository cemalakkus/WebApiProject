var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var env = builder.Environment;

//Prod ve Dev ortam�n config ayarlar�n�n otomatikle�tirme i�lemleri.
builder.Configuration
    .SetBasePath(env.ContentRootPath) //WebApiProject.Api nin bulundu�u path'i local veya sunucu olsun otomatik olarak al�r.
    .AddJsonFile("appsettings.json", optional: false) //Her zaman bu dosyay� okuyacak.
    .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true); //Buras� olabilir veya olmayabilir. Opsiyoneldir.

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

