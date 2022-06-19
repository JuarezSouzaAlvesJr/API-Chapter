using ChapterFST2.Contexts;
using ChapterFST2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Adição do arquivo ChapterContext.
builder.Services.AddScoped<ChapterContext, ChapterContext>(); //<nome do serviço, onde ele está implementado> , pois a lógica dele está aplicada nesse mesmo arquivo

//Adição do arquivo LivroRepository.
builder.Services.AddTransient<LivroRepository, LivroRepository>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
