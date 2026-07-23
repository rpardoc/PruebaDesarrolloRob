using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Linq;

using DATOS.Entities;
using DATOS.Interfaces;
using DATOS.DataAccess;

namespace DATOS.Repositories
{
    public class ComunaRepository : IComunaRepository
    {
        private readonly SqlRepository db;

        public ComunaRepository()
        {
            db = new SqlRepository();
        }

        public IEnumerable<Comuna> GetByRegion(
    int idRegion)
        {

            DataTable dt =
                db.ExecuteQuery(
                    "sp_Comuna_ListarPorRegion",

                    new SqlParameter(
                        "@IdRegion",
                        idRegion));


            return dt.AsEnumerable()
            .Select(x => new Comuna
            {

                IdComuna =
                    x.Field<int>("IdComuna"),


                NombreComuna =
                    x.Field<string>("Nombre"),


                IdRegion =
                    x.Field<int>("IdRegion"),


                InformacionAdicional =
                    new InformacionAdicional
                    {

                        Superficie =
                            x.Field<decimal>("Superficie"),


                        Poblacion =
                            x.Field<int>("Poblacion"),


                        Densidad =
                            x.Field<decimal>("Densidad")

                    }

            });

        }

        public Comuna GetById(
     int idRegion,
     int idComuna)
        {

            DataTable dt =
                db.ExecuteQuery(
                    "sp_Comuna_Obtener",

                    new SqlParameter(
                        "@IdRegion",
                        idRegion),

                    new SqlParameter(
                        "@IdComuna",
                        idComuna));


            if (dt.Rows.Count == 0)
                return null;


            DataRow row =
                dt.Rows[0];


            return new Comuna
            {
                IdComuna =
                    row.Field<int>("IdComuna"),

                NombreComuna =
                    row.Field<string>("Nombre"),

                IdRegion =
                    row.Field<int>("IdRegion"),

                InformacionAdicional =
                    ConvertirXML(
                        row["InformacionAdicional"]
                        .ToString())
            };
        }


        private InformacionAdicional ConvertirXML(string xml)
        {
            if (string.IsNullOrEmpty(xml))
                return new InformacionAdicional();


            XElement nodo =
                XElement.Parse(xml);


            return new InformacionAdicional
            {
                Superficie =
                    decimal.Parse(nodo.Element("Superficie").Value),

                Poblacion =
                    int.Parse(nodo.Element("Poblacion").Value),

                Densidad =
                    decimal.Parse(nodo.Element("Densidad").Value)
            };
        }


        public bool Update(Comuna comuna)
        {
           
            int resultado =
                db.ExecuteNonQuery(

                "SP_Comuna_Actualizar",

                new SqlParameter(
                    "@IdRegion",
                    comuna.IdRegion),

                new SqlParameter(
                    "@IdComuna",
                    comuna.IdComuna),

                new SqlParameter(
                    "@Nombre",
                    comuna.NombreComuna),

                new SqlParameter(
                    "@Superficie",
                    SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Value = comuna.InformacionAdicional.Superficie
                },

                new SqlParameter(
                    "@Poblacion",
                    comuna.InformacionAdicional.Poblacion),

                new SqlParameter(
                    "@Densidad",
                    SqlDbType.Decimal)
                {
                    Precision = 10,
                    Scale = 2,
                    Value = comuna.InformacionAdicional.Densidad
                }

                );


            // MERGE con SET NOCOUNT ON puede retornar -1 aun cuando fue exitoso.
            return resultado > 0 || resultado == -1;
        }

    }
}
