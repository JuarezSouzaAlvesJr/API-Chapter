using ChapterFST2.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterFST2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        //injeção de dependência (processo semelhante ao feito no arquivo LivroRepository.cs)
        private readonly LivroRepository _livroRepository;

        public LivroController(LivroRepository livroRepository)
        {
            _livroRepository = livroRepository;
        }

        //Criação do método GET para exibir o conteúdo da lista de livros presente no banco de dados.
        [HttpGet]   
        public IActionResult Listar()
        {
            //TRATATIVA DE ERRO
            //Tentará realizar a lógica; caso dê erro, irá aparecer apenas a mensagem de erro salva na Exception de nome 'e'.
            try
            {
                return Ok(_livroRepository.Listar());
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}


//O controle depende do LivroRepository.