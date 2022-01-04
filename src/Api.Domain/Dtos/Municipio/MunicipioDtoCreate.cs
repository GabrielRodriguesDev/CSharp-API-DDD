using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Api.Domain.Dtos.Municipio
{
    public class MunicipioDtoCreate
    {
        [Required(ErrorMessage = "É obrigratório informar o nome do municipio.")]
        [StringLength(60, ErrorMessage = "O Nome deve possuir no máximo {1} caracteres.")]
        public string Nome { get; set; }

        [Range(0, int.MaxValue, ErrorMessage = "Código do IBGE inválido.")]
        public int CodIBGE { get; set; }

        [Required(ErrorMessage = "Código UF é um campo obrigatório")]
        public Guid UfId { get; set; }

    }
}
