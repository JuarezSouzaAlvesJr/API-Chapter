using ChapterFST2.Contexts;
using ChapterFST2.Interfaces;
using ChapterFST2.Repositories;
using Microsoft.IdentityModel.Tokens;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//Adi��o do cors com cria��o de nova pol�tica
builder.Services.AddCors(options =>
{
    options.AddPolicy("CorsPolicy", policy => //"CorsPolicy" - nome da pol�tica
    {
        policy.WithOrigins("http://localhost/3000")//indica��o dolocal origem que pode consumir a API (apenas essa url � permitida )
        .AllowAnyHeader() //permitido qualquer header
        .AllowAnyMethod(); //permitido qualquer m�todo
    });
});

//Definir a forma de autentica��o
builder.Services.AddAuthentication(options => 
{
    options.DefaultChallengeScheme = "JwtBearer";
    options.DefaultAuthenticateScheme = "JwtBearer";
}).AddJwtBearer("JwtBearer", options => 
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        // Valida quem est� solicitando
        ValidateIssuer = true,
        // Valida quem est� recebendo
        ValidateAudience = true,
        // Define se o tempo de expira��o ser� validado
        ValidateLifetime = true,
        // criptografia e valida��o da chave de autentica��o
        IssuerSigningKey = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("chapter-chave-autenticacao")),
        // Valida o tempo de expira��o do token
        ClockSkew = TimeSpan.FromMinutes(30),
        // Nome do issuer, de onde est� vindo
        ValidIssuer = "chapter.webapi",
        // Nome do audience, para onde est� indo
        ValidAudience = "chapter.webapi"
    };
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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
