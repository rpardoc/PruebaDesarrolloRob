namespace PruebaWebApi.DTO
{
    public class ComunaDTO
    {
        public int IdComuna { get; set; }

        public int IdRegion { get; set; }

        public string NombreComuna { get; set; }

        public decimal Superficie { get; set; }

        public int Poblacion { get; set; }

        public decimal Densidad { get; set; }
    }
}
