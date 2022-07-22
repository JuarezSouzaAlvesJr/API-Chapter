using ChapterFST2.Models;
using ChapterFST2.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ChapterFST2.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [Authorize(Roles = "1")]
        [HttpGet("{id}")]//GET - método de consulta. Não pode haver dois métodos iguais, mas neste aqui foi passado o argumento 'id', o que o torna diferente do método GET anterior. Caso haja dois métodos iguais, é preciso definir uma rota diferente para cada um.
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Livro livroBuscado = _livroRepository.BuscarPorId(id);
                if (livroBuscado == null)
                {
                    return NotFound();
                }
                return Ok(livroBuscado);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPost] //Método para enviar uma informação para o banco de dados
        public IActionResult Cadastrar(Livro livro)
        {
            try
            {
                _livroRepository.Cadastrar(livro);

                return StatusCode(201);
                //return Ok("Livro cadastrado com sucesso.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            try
            {
                _livroRepository.Deletar(id);
                return Ok("Livro removido com sucesso.");
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        [HttpPut("{id}")]//Método para alteração
        public IActionResult Alterar(int id, Livro livro)
        {
            try
            {
                _livroRepository.Atualizar(id, livro);
                return StatusCode(204);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}


//O controle depende do LivroRepository.