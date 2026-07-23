using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PruebaWebMvc.Dto
{
    public class ComunaDTO
    {
        public int IdComuna { get; set; }

        public int IdRegion { get; set; }

        [Required]
        public string NombreComuna { get; set; }


        [Range(0, 99999999.99)]
        public decimal Superficie { get; set; }


        [Range(0, int.MaxValue)]
        public int Poblacion { get; set; }


        [Range(0, 99999999.99)]
        public decimal Densidad { get; set; }
    }
}