using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoraSagradaWebApi.Domain;
using HoraSagradaWebApi.Models;

namespace HoraSagradaWebApi.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario> GetUsuarioByNome(string nome);
        Task<IEnumerable<Usuario>> GetUsuarios();
        Task<Usuario> AddUsuario(UsuarioModel usuario);
    }
}