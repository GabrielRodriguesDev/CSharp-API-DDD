using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.User
{
    public class UserDtoUpdate
    {
        [Required(ErrorMessage = "Id é obrigatório.")]
        public Guid Id { get; set; }


        [Required(ErrorMessage = "Nome é um campo óbrigatório.")]
        [StringLength(60, ErrorMessage = "Nome deve ter no máximo {1} caracteres.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "E-mail é um campo obrigatório.")]
        [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
        [StringLength(100, ErrorMessage = "E-mail deve ter no máximo {100} caracteres.")]
        public string Email { get; set; }
    }
}
