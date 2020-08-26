using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace HoraSagradaWebApi.Domain
{
    public class Restaurante
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public int? Votos { get; set; }
        public IEnumerable<Usuario> UsuariosVotantes { get; set; }
        public bool? Escolhido { get; set; }
        public DateTime? DataUltimaEscolha { get; set; }
        public bool? VotadoNaSemana { get; set; }
    }
}