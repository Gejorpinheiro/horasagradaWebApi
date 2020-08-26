using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoraSagradaWebApi.Models;
using HoraSagradaWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HoraSagradaWebApi.Controllers
{
    [Route("api/[controller]")]
    public class RestauranteController
    {
        private readonly IRestauranteRepository _restauranteRepo;
        public RestauranteController(IRestauranteRepository restauranteRepo)
        {
            this._restauranteRepo = restauranteRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RestauranteModel>>> Get()
        {
            var restaurantes = await _restauranteRepo.GetRestaurantes();

            if(restaurantes == null)
                return new EmptyResult();

            return new ObjectResult(RestauranteModel.ToListModel(restaurantes));
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<RestauranteModel>> Get(Guid id)
        {
            var restaurante = await _restauranteRepo.GetRestauranteById(id);

            if(restaurante == null)
                return new EmptyResult();

            return new ObjectResult(RestauranteModel.ToModel(restaurante));
        }

        [HttpPost]
        public async Task<ActionResult<RestauranteModel>> Post([FromBody] RestauranteModel restaurante)
        {
            if(restaurante == null)
                return new EmptyResult();

            try
            {
                return new ObjectResult(RestauranteModel.ToModel(await _restauranteRepo.AddRestaurante(restaurante)));
            }
            catch (Exception)
            {
                return new EmptyResult();
            }
        }

        [HttpPut]
        public async Task<ActionResult<RestauranteModel>> Put([FromBody] RestauranteModel restaurante)
        {
            if(restaurante == null)
                return new EmptyResult();

            try
            {
                return new ObjectResult(await _restauranteRepo.UpdateRestaurante(restaurante));
            }
            catch (Exception)
            {
                return new EmptyResult();
            }
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(Guid id)
        {
            try
            {
                _restauranteRepo.RemoveRestaurante(id);
                return new OkResult();
            }
            catch (Exception)
            {
                return new EmptyResult();
            }
        }
    }
}