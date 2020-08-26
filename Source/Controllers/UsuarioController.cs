using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HoraSagradaWebApi.Models;
using HoraSagradaWebApi.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HoraSagradaWebApi.Controllers
{
    [Route("api/[controller]")]
    public class UsuarioController
    {
        private readonly IUsuarioRepository _usuarioRepo;
        public UsuarioController(IUsuarioRepository _usuarioRepo)
        {
            this._usuarioRepo = _usuarioRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioModel>>> Get()
        {
            var usuarios = await _usuarioRepo.GetUsuarios();

            if (usuarios == null)
                return new NotFoundResult();

            return new ObjectResult(UsuarioModel.ToListModel(usuarios));
        }

        [HttpGet("{nomeUsuario}")]
        public async Task<ActionResult<UsuarioModel>> Get(string nomeUsuario)
        {
            var usuario = await _usuarioRepo.GetUsuarioByNome(nomeUsuario);

            if (usuario == null)
                return new NotFoundResult();

            return new ObjectResult(UsuarioModel.ToModel(usuario));
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Post([FromBody] UsuarioModel usuario)
        {
            if (usuario == null)
                return new NoContentResult();

            if (await _usuarioRepo.GetUsuarioByNome(usuario.Nome) != null)
                return new ConflictResult();

            return new ObjectResult(UsuarioModel.ToModel(await _usuarioRepo.AddUsuario(usuario)));
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}