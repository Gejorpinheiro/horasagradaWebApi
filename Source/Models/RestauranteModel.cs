using System;
using System.Collections.Generic;
using HoraSagradaWebApi.Domain;

namespace HoraSagradaWebApi.Models
{
    public class RestauranteModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int? Votos { get; set; }
        public IEnumerable<UsuarioModel> UsuariosVotantes { get; set; }
        public bool? Escolhido { get; set; }
        public DateTime? DataUltimaEscolha { get; set; }
        public bool? VotadoNaSemana { get; set; }

        public static RestauranteModel ToModel(Restaurante restaurante)
        {
            return new RestauranteModel()
            {
                Id = restaurante.Id,
                Nome = restaurante.Nome,
                Endereco = restaurante.Endereco,
                Votos = restaurante.Votos,
                UsuariosVotantes = restaurante.UsuariosVotantes == null ? new List<UsuarioModel>() : UsuarioModel.ToListModel(restaurante.UsuariosVotantes),
                Escolhido = restaurante.Escolhido,
                DataUltimaEscolha = restaurante.DataUltimaEscolha,
                VotadoNaSemana = restaurante.VotadoNaSemana                       
            };
        }

        public static IEnumerable<RestauranteModel> ToListModel(IEnumerable<Restaurante> restaurantes)
        {
            List<RestauranteModel> listRestaurante = new List<RestauranteModel>();

            foreach(var restaurante in restaurantes)
            {
                listRestaurante.Add(RestauranteModel.ToModel(restaurante));
            }

            return listRestaurante;
        }
    }
}