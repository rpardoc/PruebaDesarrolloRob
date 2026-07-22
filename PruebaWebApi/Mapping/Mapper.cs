using System.Collections.Generic;
using System.Linq;

using DATOS.Entities;

using PruebaWebApi.DTO;


namespace PruebaWebApi.Mapping
{
    public static class Mapper
    {


        // REGION ENTITY -> REGION DTO

        public static RegionDTO ToRegionDTO(
            Region region)
        {

            if (region == null)
                return null;


            return new RegionDTO
            {
                IdRegion = region.IdRegion,

                NombreRegion = region.NombreRegion
            };

        }



        public static IEnumerable<RegionDTO> ToRegionDTO(
            IEnumerable<Region> regiones)
        {

            if (regiones == null)
                return new List<RegionDTO>();


            return regiones.Select(
                ToRegionDTO
            );

        }




        // COMUNA ENTITY -> COMUNA DTO

        public static ComunaDTO ToComunaDTO(
            Comuna comuna)
        {

            if (comuna == null)
                return null;



            return new ComunaDTO
            {
                IdComuna = comuna.IdComuna,

                IdRegion = comuna.IdRegion,

                NombreComuna = comuna.NombreComuna,


                Superficie =
                    comuna.InformacionAdicional != null
                    ? comuna.InformacionAdicional.Superficie
                    : 0,


                Poblacion =
                    comuna.InformacionAdicional != null
                    ? comuna.InformacionAdicional.Poblacion
                    : 0,


                Densidad =
                    comuna.InformacionAdicional != null
                    ? comuna.InformacionAdicional.Densidad
                    : 0

            };

        }




        public static IEnumerable<ComunaDTO> ToComunaDTO(
            IEnumerable<Comuna> comunas)
        {

            if (comunas == null)
                return new List<ComunaDTO>();


            return comunas.Select(
                ToComunaDTO
            );

        }





        // DTO -> ENTITY (para actualizar comuna)

        public static Comuna ToComunaEntity(
            ActualizarComunaDTO dto)
        {

            if (dto == null)
                return null;



            return new Comuna
            {
                IdComuna = dto.IdComuna,


                InformacionAdicional =
                new InformacionAdicional
                {

                    Superficie = dto.Superficie,

                    Poblacion = dto.Poblacion,

                    Densidad = dto.Densidad

                }

            };

        }


    }
}