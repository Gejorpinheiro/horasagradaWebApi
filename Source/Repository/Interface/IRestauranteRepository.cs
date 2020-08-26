using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoraSagradaWebApi.Domain;
using HoraSagradaWebApi.Models;

namespace HoraSagradaWebApi.Repository
{
    public interface IRestauranteRepository
    {
        Task<Restaurante> GetRestauranteById(Guid id);
        Task<IEnumerable<Restaurante>> GetRestaurantes();
        Task<Restaurante> UpdateRestaurante(RestauranteModel restaurante);
        Task<Restaurante> AddRestaurante(RestauranteModel restaurante);
        void RemoveRestaurante(Guid id);
    }
}