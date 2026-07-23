using System.Collections.Generic;
using PruebaWebApi.DTO;

namespace PruebaWebApi.Interfaces
{
    public interface IRegionService
    {
        IEnumerable<RegionDTO> ObtenerRegiones();


        RegionDTO ObtenerRegion(int idRegion);


        IEnumerable<ComunaDTO> ObtenerComunas(
            int idRegion);


        ComunaDTO ObtenerComuna(
            int idRegion,
            int idComuna);


        bool ActualizarComuna(
      int idRegion,
      ActualizarComunaDTO dto);
    }
}
