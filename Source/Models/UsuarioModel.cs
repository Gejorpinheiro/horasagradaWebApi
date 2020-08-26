using System;
using System.Collections.Generic;
using HoraSagradaWebApi.Domain;

namespace HoraSagradaWebApi.Models
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public DateTime? DataVotacao { get; set; }
        public static UsuarioModel ToModel(Usuario usuario)
        {
            return new UsuarioModel()
            {
                Id = usuario.Id,
                Nome = usuario.Nome,
                DataVotacao = usuario.DataVotacao
            };
        }
        public static IEnumerable<UsuarioModel> ToListModel(IEnumerable<Usuario> usuarios)
        {
            List<UsuarioModel> listUsuarios = new List<UsuarioModel>();
            
            foreach (var usuario in usuarios)
            {
                listUsuarios.Add(
                    UsuarioModel.ToModel(usuario)
                );
            }

            return listUsuarios;
        }
    }
}