using ChapterFST2.Contexts;
using ChapterFST2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Adi��o do arquivo ChapterContext.
builder.Services.AddScoped<ChapterContext, ChapterContext>(); //<nome do servi�o, onde ele est� implementado> , pois a l�gica dele est� aplicada nesse mesmo arquivo

//Adi��o do arquivo LivroRepository.
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
