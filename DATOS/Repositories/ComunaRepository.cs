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
            "sp_Comuna_Listar",

            new SqlParameter(
            "@IdRegion",
            idRegion));



            return dt.AsEnumerable()
            .Select(x => new Comuna
            {

                IdComuna =
            x.Field<int>("IdComuna"),


                NombreComuna =
            x.Field<string>("NombreComuna"),


                IdRegion =
            x.Field<int>("IdRegion")


            });

        }

        public Comuna GetById(
        int idComuna)
        {

            DataTable dt =
            db.ExecuteQuery(
            "sp_Comuna_Obtener",

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
            row.Field<string>("NombreComuna"),


                IdRegion =
            row.Field<int>("IdRegion"),


                InformacionAdicional =
            ConvertirXML(
            row["InformacionAdicional"]
            .ToString())

            };

        }


        private InformacionAdicional ConvertirXML(
        string xml)
        {

            XElement nodo =
            XElement.Parse(xml);


            return new InformacionAdicional
            {

                Superficie =
            decimal.Parse(
            nodo.Element("Superficie").Value),


                Poblacion =
            int.Parse(
            nodo.Element("Poblacion").Value),


                Densidad =
            decimal.Parse(
            nodo.Element("Densidad").Value)

            };

        }


        public bool Update(
        Comuna comuna)
        {

            string xml =

            $@"<InformacionAdicional>
            <Superficie>{comuna.InformacionAdicional.Superficie}</Superficie>
            <Poblacion>{comuna.InformacionAdicional.Poblacion}</Poblacion>
            <Densidad>{comuna.InformacionAdicional.Densidad}</Densidad>
            </InformacionAdicional>";



            int resultado =
            db.ExecuteNonQuery(

            "sp_Comuna_Actualizar",

            new SqlParameter(
            "@IdComuna",
            comuna.IdComuna),


            new SqlParameter(
            "@NombreComuna",
            comuna.NombreComuna),


            new SqlParameter(
            "@InformacionAdicional",
            xml)

            );

            return resultado > 0;

        }

    }
}
