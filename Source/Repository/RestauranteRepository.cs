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
    public class RestauranteRepository : IRestauranteRepository
    {
        private readonly ApplicationDbContext _context;
        public RestauranteRepository(ApplicationDbContext context)
        {
            this._context = context;

        }

        public async Task<IEnumerable<Restaurante>> GetRestaurantes()
        {
            return await _context.Restaurante.ToListAsync();
        }

        public async Task<Restaurante> GetRestauranteById(Guid id)
        {
            return await _context.Restaurante.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<Restaurante> AddRestaurante(RestauranteModel restaurante)
        {
            Restaurante novoRestaurante = new Restaurante()
            {
                Id = new Guid(),
                Nome = restaurante.Nome,
                Endereco = restaurante.Endereco,
                Votos = 0,
                Escolhido = false,
                VotadoNaSemana = false
            };

            await _context.Restaurante.AddAsync(novoRestaurante);
            await _context.SaveChangesAsync();

            return novoRestaurante;
        }

        public async Task<Restaurante> UpdateRestaurante(RestauranteModel restaurante)
        {
            var restauranteUptodate = await this.GetRestauranteById(restaurante.Id);

            restauranteUptodate.Nome = restaurante.Nome;
            restauranteUptodate.Endereco = restaurante.Endereco;
            restauranteUptodate.Votos = restaurante.Votos;

            await _context.SaveChangesAsync();

            return restauranteUptodate;
        }

        public async void RemoveRestaurante(Guid id)
        {
            var restauranteToRemove = await _context.Restaurante.FirstOrDefaultAsync(r => r.Id == id);

            _context.Restaurante.Remove(restauranteToRemove);
            await _context.SaveChangesAsync();
        }
    }
}