using System.Collections.Generic;

using DATOS.Entities;
using DATOS.Interfaces;

using PruebaWebApi.DTO;
using PruebaWebApi.Interfaces;
using PruebaWebApi.Mapping;



namespace PruebaWebApi.Services
{
    public class RegionService : IRegionService
    {

        private readonly IRegionRepository regionRepository;
        private readonly IComunaRepository comunaRepository;



        public RegionService(
            IRegionRepository regionRepository,
            IComunaRepository comunaRepository)
        {
            this.regionRepository = regionRepository;
            this.comunaRepository = comunaRepository;
        }




        public IEnumerable<RegionDTO> ObtenerRegiones()
        {

            IEnumerable<Region> regiones =
                regionRepository.GetAll();


            return Mapper.ToRegionDTO(regiones);

        }





        public RegionDTO ObtenerRegion(
            int idRegion)
        {

            Region region =
                regionRepository.GetById(idRegion);



            return Mapper.ToRegionDTO(region);

        }





        public IEnumerable<ComunaDTO> ObtenerComunas(
            int idRegion)
        {

            IEnumerable<Comuna> comunas =
                comunaRepository.GetByRegion(idRegion);



            return Mapper.ToComunaDTO(comunas);

        }

        public ComunaDTO ObtenerComuna(
            int idRegion,
            int idComuna)
        {

            Comuna comuna =
                comunaRepository.GetById(
                    idRegion,
                    idComuna);



            return Mapper.ToComunaDTO(comuna);

        }


        public bool ActualizarComuna(
      int idRegion,
      ActualizarComunaDTO dto)
        {
            if (dto == null)
                return false;


            Comuna comuna = comunaRepository.GetById(idRegion, dto.IdComuna);

            if (comuna == null)
                return false;


            if (comuna.IdRegion != idRegion)
                return false;



            comuna.NombreComuna =
                dto.NombreComuna;



            comuna.InformacionAdicional =
                new InformacionAdicional
                {
                    Superficie = dto.Superficie,

                    Poblacion = dto.Poblacion,

                    Densidad = dto.Densidad
                };


            return comunaRepository.Update(comuna);
        }

    }
}