using ChapterFST2.Models;
using Microsoft.EntityFrameworkCore;

namespace ChapterFST2.Contexts
{
    public class ChapterContext : DbContext
    {
        public ChapterContext()
        {
        }
        public ChapterContext(DbContextOptions<ChapterContext>options) : base(options){}

        // vamos utilizar esse método para configurar o banco de dados
        protected override void
        OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // cada provedor tem sua sintaxe para especificação
                optionsBuilder.UseSqlServer("Data Source = LAPTOP-VVMNGSDN\\SQLEXPRESS; initial catalog = Chapter; Integrated Security = true"); //"LAPTOP-VVMNGSDN\\SQLEXPRESS" é o nome do banco de dados instalado na minha máquina. Ele substitui o "DESKTOP-KHGJH1M\\SQLEXPRESS" que veio configurado previamente. Se o nome da minha instância tiver uma barra simples (\), preciso colocar outra barra antes dela para indicar que será interpretada como string, não como caractere especial.
                //Se no SSMS, tiver colocado autentitação por logon e password, substitua "Integrated Security = true" por "User ID=[nome de usuario]; Password=[senha]".
            }
        }

        // dbset representa as entidades que serão utilizadas nas operações de leitura, criação, atualização e deleção
        public DbSet<Livro> Livros { get; set; } //faz a conexão entre a classe Livro e a tabela Livros do banco de dados
    }
}

//ctrl + k + d para fazer a formatação

//Esse é o arquivo que fará a conexão com o banco de dados.
