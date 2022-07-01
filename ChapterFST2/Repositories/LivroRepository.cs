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
            return _context.Livros.ToList(); //"_context" é a variável usada para conectar com o banco; irá acessar a tabela Livros, pegar o conteúdo lá presente e devolver os dados obtidos na forma de uma lista
        }

        //Método BuscarPorId
        public Livro BuscarPorId(int id)
        {
            return _context.Livros.Find(id);
        }

        //Método para cadastrar um novo livro. O retorno é vazio (void), pois a intenção é enviar um dado, não receber.
        public void Cadastrar(Livro livro)
        {
            _context.Livros.Add(livro);

            _context.SaveChanges(); //para salvar a alteração feita no banco de dados
        }

        public void Deletar(int id)
        {
            Livro livro = _context.Livros.Find(id);

                _context.Remove(livro);
                _context.SaveChanges();
        }

        public void Atualizar(int id, Livro livro)
        {
            Livro livroBuscado = _context.Livros.Find(id);

            if(livroBuscado != null)
            {
                livroBuscado.Titulo = livro.Titulo;
                livroBuscado.QuantidadePaginas = livro.QuantidadePaginas;
                livroBuscado.Disponivel = livro.Disponivel;
            }

            _context.Livros.Update(livroBuscado);

            _context.SaveChanges();
        }

    }
}

//O LivroRepository depende do Context.