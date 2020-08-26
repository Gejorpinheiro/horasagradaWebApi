using System;
using System.ComponentModel.DataAnnotations;

namespace HoraSagradaWebApi.Domain
{
    public class Usuario
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }
        public DateTime? DataVotacao { get; set; }
    }
}