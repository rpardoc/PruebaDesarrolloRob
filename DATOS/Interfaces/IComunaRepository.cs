using System.Collections.Generic;
using DATOS.Entities;

namespace DATOS.Interfaces
{
    public interface IComunaRepository
    {
        IEnumerable<Comuna> GetByRegion(
            int idRegion);

        Comuna GetById(
            int idComuna, int idRegion);

        bool Update(
            Comuna comuna);
    }
}
