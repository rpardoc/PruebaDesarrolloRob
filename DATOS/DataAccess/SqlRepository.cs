using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DATOS.DataAccess
{
    public class SqlRepository
    {
        private readonly string connectionString;


        public SqlRepository()
        {

            connectionString =
            ConfigurationManager
            .ConnectionStrings["BD"]
            .ConnectionString;

        }

        public DataTable ExecuteQuery(
            string procedure,
            params SqlParameter[] parameters)
        {

            DataTable table =
            new DataTable();


            using (SqlConnection cn =
                new SqlConnection(connectionString))
            {

                using (SqlCommand cmd =
                    new SqlCommand(procedure, cn))
                {

                    cmd.CommandType =
                    CommandType.StoredProcedure;


                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);



                    using (SqlDataAdapter da =
                    new SqlDataAdapter(cmd))
                    {

                        da.Fill(table);

                    }

                }

            }

            return table;

        }


        public int ExecuteNonQuery(
            string procedure,
            params SqlParameter[] parameters)
        {

            using (SqlConnection cn =
                new SqlConnection(connectionString))
            {

                using (SqlCommand cmd =
                    new SqlCommand(procedure, cn))
                {

                    cmd.CommandType =
                    CommandType.StoredProcedure;


                    if (parameters != null)
                        cmd.Parameters.AddRange(parameters);



                    cn.Open();


                    return cmd.ExecuteNonQuery();

                }

            }

        }
    }
}
