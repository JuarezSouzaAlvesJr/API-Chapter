using ChapterFST2.Contexts;
using ChapterFST2.Interfaces;
using ChapterFST2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Adi��o do cors com cria��o de nova pol�tica
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy => //"CorsPolicy" - nome da pol�tica
    {
        policy.WithOrigins("http://localhost/3000") //indica��o do local de origem que pode consumir a API (apenas essa url � permitida)
        .AllowAnyHeader() //permitido qualquer header
        .AllowAnyMethod(); //permitido qualquer m�todo
    });
});

//Adi��o do arquivo ChapterContext.
builder.Services.AddScoped<ChapterContext, ChapterContext>(); //<nome do servi�o, onde ele est� implementado> , pois a l�gica dele est� aplicada nesse mesmo arquivo

//Adi��o do arquivo LivroRepository.
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
