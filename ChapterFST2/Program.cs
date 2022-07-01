using ChapterFST2.Contexts;
using ChapterFST2.Interfaces;
using ChapterFST2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Adição do cors com criação de nova política
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy => //"CorsPolicy" - nome da política
    {
        policy.WithOrigins("http://localhost/3000") //indicação do local de origem que pode consumir a API (apenas essa url é permitida)
        .AllowAnyHeader() //permitido qualquer header
        .AllowAnyMethod(); //permitido qualquer método
    });
});

//Adição do arquivo ChapterContext.
builder.Services.AddScoped<ChapterContext, ChapterContext>(); //<nome do serviço, onde ele está implementado> , pois a lógica dele está aplicada nesse mesmo arquivo

//Adição do arquivo LivroRepository.
builder.Services.AddTransient<LivroRepository, LivroRepository>();

builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();

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

app.UseCors("CorsPolicy"); //Geralmente, deve ficar acima do Authorization

app.UseAuthorization();

app.MapControllers();

app.Run();
