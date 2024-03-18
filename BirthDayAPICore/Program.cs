using BirthDayAPICore.Services;
using BirthDayAPICore.Settings;
using Microsoft.Extensions.Options;
//se crează un builder pentru aplicația ASP.NET Core
var builder = WebApplication.CreateBuilder(args);


//adaugă suportul pentru controlere în aplicație.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
//spunem cum se face injectarea (interfata si implementarea unui serviciu petru a  putea fi injectat
//in clasele in care sunt folosite)
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection(nameof(MongoDBSettings)));
builder.Services.AddSingleton<IMongoDBSettings>(sp => sp.GetRequiredService<IOptions<MongoDBSettings>>().Value);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy",
                              policy =>
                              {
                                  policy.WithOrigins("http://localhost:4200")
                                  .AllowAnyHeader()
                                  .AllowAnyMethod()
                                  .AllowCredentials();
                              });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IUsersCollectionService, UsersCollectionService>();

builder.Services.AddSingleton<IBirthDayCollectionService, BirthDayCollectionService>();

var app = builder.Build();

//Se configurează pipeline-ul de procesare al cererilor HTTP utilizând diferite metode
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
