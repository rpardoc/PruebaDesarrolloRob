using System.Collections.Generic;
using DATOS.Entities;

namespace DATOS.Interfaces
{
    public interface IRegionRepository
    {
        IEnumerable<Region> GetAll();
        Region GetById(int idRegion);
    }
}
