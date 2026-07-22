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
                comunaRepository.GetById(idComuna);



            return Mapper.ToComunaDTO(comuna);

        }


        public bool ActualizarComuna(
            ActualizarComunaDTO dto)
        {

            if (dto == null)
                return false;



            Comuna comuna =
                comunaRepository.GetById(dto.IdComuna);



            if (comuna == null)
                return false;



            if (comuna.InformacionAdicional == null)
            {
                comuna.InformacionAdicional =
                    new InformacionAdicional();
            }



            comuna.InformacionAdicional.Superficie =
                dto.Superficie;


            comuna.InformacionAdicional.Poblacion =
                dto.Poblacion;


            comuna.InformacionAdicional.Densidad =
                dto.Densidad;



            return comunaRepository.Update(comuna);

        }

    }
}