using DesafioEntregable.Controllers.DTOS;
using DesafioEntregable.Modells;
using System.Data.SqlClient;

namespace DesafioEntregable.Repository
{
    public class ProductoVendidoHandler : DBHandler
    {
        public List<ClaseProductoVendido> traerProductosVendidos()
        {
            List<ClaseProductoVendido> listaProductosVendidos = new List<ClaseProductoVendido>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT ProductoVendido.*,Producto.Descripciones FROM ProductoVendido INNER JOIN Producto ON Producto.Id = ProductoVendido.IdProducto";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parProductV = new ClaseProductoVendido();

                                parProductV.setId(Convert.ToInt32(dataReader["Id"]));

                                parProductV.setStock(Convert.ToInt32(dataReader["Stock"]));

                                parProductV.setIdVenta(Convert.ToInt32(dataReader["IdVenta"]));

                                parProductV.setDescripciones(Convert.ToString(dataReader["Descripciones"]));

                                listaProductosVendidos.Add(parProductV);


                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return listaProductosVendidos;
        }

        public static bool insertarProductoV(PostProductoV PVendido)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var queryInsert = "INSERT INTO ProductoVendido (Id, Stock, IdProducto, IdVenta) Values (@Id, @Stock, @IdProducto, @IdVenta)";

                bool insert = false;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.BigInt) { Value = PVendido._idPV});
                    sqlCommand.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = PVendido._stockPV});
                    sqlCommand.Parameters.Add(new SqlParameter("IdProducto", System.Data.SqlDbType.BigInt) { Value = PVendido._idProductoV });
                    sqlCommand.Parameters.Add(new SqlParameter("IdVenta", System.Data.SqlDbType.BigInt) { Value = PVendido._idVentaPV});


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
