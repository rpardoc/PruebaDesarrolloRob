using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using DATOS.Entities;
using DATOS.Interfaces;
using DATOS.DataAccess;

namespace DATOS.Repositories
{
    public class RegionRepository : IRegionRepository
    {
        private readonly SqlRepository db;


        public RegionRepository()
        {
            db = new SqlRepository();
        }

        public IEnumerable<Region> GetAll()
        {

            DataTable dt =
            db.ExecuteQuery(
            "sp_Region_Listar");


            return dt.AsEnumerable()
            .Select(x => new Region
            {

                IdRegion =
            x.Field<int>("IdRegion"),


                NombreRegion =
            x.Field<string>("Nombre")


            });

        }


        public Region GetById(
        int idRegion)
        {

            DataTable dt =
            db.ExecuteQuery(
            "sp_Region_Obtener",

            new SqlParameter(
            "@IdRegion",
            idRegion)
            );



            if (dt.Rows.Count == 0)
                return null;



            DataRow row =
            dt.Rows[0];


            return new Region
            {

                IdRegion =
            row.Field<int>("IdRegion"),


                NombreRegion =
            row.Field<string>("Nombre")

            };

        }

}
}
