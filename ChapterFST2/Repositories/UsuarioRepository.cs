﻿using ChapterFST2.Contexts;
using ChapterFST2.Interfaces;
using ChapterFST2.Models;

namespace ChapterFST2.Repositories
{
    public class UsuarioRepository : IUsuarioRepository //herança da interface UsuarioRepository
    {

        private readonly ChapterContext _context;

        public UsuarioRepository(ChapterContext context)
        {
            _context = context;
        }

        public void Atualizar(int id, Usuario usuario)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            if (usuarioEncontrado != null)
            {
                usuarioEncontrado.Email = usuario.Email;
                usuarioEncontrado.Senha = usuario.Senha;
                usuarioEncontrado.Tipo = usuario.Tipo;
            }

            _context.Usuarios.Update(usuarioEncontrado);

            _context.SaveChanges();
        }

        public Usuario BuscarPorId(int id)
        {
            return _context.Usuarios.Find(id);
        }

        public void Cadastrar(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);

            _context.SaveChanges();
        }

        public void Deletar(int id)
        {
            Usuario usuarioEncontrado = _context.Usuarios.Find(id);

            _context.Remove(usuarioEncontrado);
            _context.SaveChanges();
        }

        public List<Usuario> Listar()
        {
            return _context.Usuarios.ToList();
        }

        public Usuario Login(string email, string senha)
        {
            return _context.Usuarios.First(u => u.Email == email && u.Senha == senha);
        }
    }
}

//Após fazer a herança e a implementação da interface lá em cima, vamos lá no arquivo program fazer a adição ("builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();"). Depois, voltamos aqui para incluir a lógica de cada método.