using System.Collections.Generic;
using DATOS.Entities;

namespace DATOS.Interfaces
{
    public interface IComunaRepository
    {
        IEnumerable<Comuna> GetByRegion(
            int idRegion);

        Comuna GetById(
            int idRegion,
            int idComuna);

        bool Update(
            Comuna comuna);
    }
}
