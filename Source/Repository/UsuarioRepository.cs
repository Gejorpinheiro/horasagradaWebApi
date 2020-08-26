using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HoraSagradaWebApi.Context;
using HoraSagradaWebApi.Domain;
using HoraSagradaWebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HoraSagradaWebApi.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly ApplicationDbContext _context;
        public UsuarioRepository(ApplicationDbContext context)
        {
            this._context = context;
        }

        public async Task<Usuario> GetUsuarioByNome(string nome)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Nome.Equals(nome));
        }

        public async Task<IEnumerable<Usuario>> GetUsuarios()
        {
            return await _context.Usuario.ToListAsync();
        }

        public async Task<Usuario> AddUsuario(UsuarioModel usuario)
        {
            Usuario novoUsuario = new Usuario()
            {
                Id = new Guid(),
                Nome = usuario.Nome
            };

            await _context.Usuario.AddAsync(novoUsuario);

            await _context.SaveChangesAsync();

            return novoUsuario;
        }
    }
}