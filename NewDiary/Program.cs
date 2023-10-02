using NewDiary.Data;
using Microsoft.EntityFrameworkCore;
using NewDiary.Data.EntityFramework;
using Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal;
using NewDiary.Data.Abstract;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MSSQLString"));
});

//Сервисы по взаимодействию с БД
builder.Services.AddTransient<IAuditoriumRepository, EFAuditoriumRepository>();
builder.Services.AddTransient<IComputerRepository, EFComputerRepository>();
builder.Services.AddTransient<IDepartmentRepository, EFDepartmentRepository>();
builder.Services.AddTransient<IEmployeeRepository, EFEmployeeRepository>();
builder.Services.AddTransient<IGroupWorkRepository, EFGroupWorkRepository>();
builder.Services.AddTransient<IWorkRepository, EFWorkRepository>();
builder.Services.AddTransient<IDiaryEntryRepository, EFDiaryEntryRepository>();

//Менеджер всех запросов к БД
builder.Services.AddTransient<DataManager>();

//builder.WebHost.ConfigureKestrel(serverOptions =>
//{
//    serverOptions.ListenAnyIP(5222, listenOptions =>
//    {
//        listenOptions.UseHttps();
//    });
//});
//builder.WebHost.UseKestrel();

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

