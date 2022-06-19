using ChapterFST2.Contexts;
using ChapterFST2.Models;

namespace ChapterFST2.Repositories
{
    public class LivroRepository
    {
        //variável privada, ou seja, que só pode ser servida dentro desse arquivo; "readonly" (apenas de leitura), ou seja, não poderá ser alterada; "_context" - nome da variável do tipo private
        private readonly ChapterContext _context;

        //método construtor
        public LivroRepository(ChapterContext context) //entre parênteses está a injeção de dependência, ou seja, todos vez que chamarmos o LivroRepository, ele irá chamar o conteúdo do context.
        {
            _context = context;
        }

        //Método para listar os livros presentes no banco de dados.
        public List<Livro> Listar()
        {
            return _context.Livros.ToList(); //vai conectar com o banco, acessar a tabela Livros, pegar o conteúdo lá presente e devolver os dados obtidos na forma de uma lista
        }

    }
}

//O LivroRepository depende do Context.