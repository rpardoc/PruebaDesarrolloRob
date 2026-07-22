using System.Collections.Generic;

namespace DATOS.Entities
{
    public class Region
    {
        public Region()
        {
            Comunas = new List<Comuna>();
        }


        public int IdRegion { get; set; }


        public string NombreRegion { get; set; }


        public List<Comuna> Comunas { get; set; }
    }
}
