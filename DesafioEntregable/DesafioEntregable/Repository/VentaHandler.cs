using DesafioEntregable.Controllers.DTOS;
using DesafioEntregable.Modells;
using System.Data.SqlClient;

namespace DesafioEntregable.Repository
{
    public class VentaHandler : DBHandler
    {
        public List<ClaseVenta> traerVenta()
        {
            List<ClaseVenta> listaVenta = new List<ClaseVenta>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT * FROM Venta";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parVenta = new ClaseVenta();

                                parVenta.setId(Convert.ToInt32(dataReader["Id"]));

                                listaVenta.Add(parVenta);


                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return listaVenta;
        }

        public static bool insertarVenta(PostVenta venta)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                // var queryInsert = "INSERT INTO Venta (Id, Comentarios) Values (@Id, @Comentarios)";
                var queryInsert = "INSERT INTO Venta (Comentarios) Values (@Comentarios)";

                bool insert = false;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    // sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.BigInt) { Value = venta._idCVenta });
                    sqlCommand.Parameters.Add(new SqlParameter("Comentarios", System.Data.SqlDbType.VarChar) { Value = venta._comentarioCVenta });
                    

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {

                        insert = true;

                    }
                }
                sqlConnection.Close();
                return insert;
            }
        }


    }
}
