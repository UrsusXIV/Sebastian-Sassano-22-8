﻿using System.Data.SqlClient;
using DesafioEntregable.Controllers.DTOS;
using DesafioEntregable.Modells;


namespace DesafioEntregable.Repository
{
    public class ProductoHandler : DBHandler
    {

        public List<ClaseProducto>traerProductos()
        {
            List<ClaseProducto> listaProductos = new List<ClaseProducto>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT * FROM Producto";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    
                    
                   using(SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parProduct = new ClaseProducto();

                                parProduct.setId(Convert.ToInt32(dataReader["Id"]));

                                parProduct.setDescripciones(Convert.ToString(dataReader["Descripciones"]));

                                parProduct.setCosto(Convert.ToDouble(dataReader["Costo"]));

                                parProduct.setPrecioVenta(Convert.ToDouble(dataReader["PrecioVenta"]));

                                parProduct.setStock(Convert.ToInt32(dataReader["Stock"]));

                                parProduct.setIdUsuario(Convert.ToInt32(dataReader["IdUsuario"]));

                                listaProductos.Add(parProduct);


                            }
                          
                        }


                    }
                }
                sqlConnection.Close();
            }
            return listaProductos;
        }

        public static bool insertarProducto(PostProducto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var queryInsert = "INSERT INTO Producto (Descripciones,Costo,PrecioVenta,Stock,IdUsuario) Values(@Descripciones,@Costo,@PrecioVenta,@Stock,@IdUsuario)";

                bool insert = false;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Descripciones", System.Data.SqlDbType.VarChar) { Value = producto._descripcionesProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("Costo", System.Data.SqlDbType.Money) { Value = producto._costoProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("PrecioVenta", System.Data.SqlDbType.Money) { Value = producto._precioVentaProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = producto._stockProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.BigInt) { Value = producto._idUsuarioProductClass });

                   int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if(numberOfRows > 0)
                    {

                        insert = true;

                    }
                }
                sqlConnection.Close();
                return insert;
            }         
        }

        public static bool modificarProducto(PutProducto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var queryInsert = "UPDATE Producto SET Descripciones = @Descripciones, Costo = @Costo, PrecioVenta = @PrecioVenta, Stock = @Stock, IdUsuario = @IdUsuario WHERE Id = @Id";

                bool update = false;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Descripciones", System.Data.SqlDbType.VarChar) { Value = producto._descripcionesProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("Costo", System.Data.SqlDbType.Money) { Value = producto._costoProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("PrecioVenta", System.Data.SqlDbType.Money) { Value = producto._precioVentaProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = producto._stockProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("IdUsuario", System.Data.SqlDbType.BigInt) { Value = producto._idUsuarioProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.BigInt) { Value = producto._idProductClass });

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {

                        update = true;

                    }
                }
                sqlConnection.Close();
                return update;
            }
        }

        public static bool modificarStockProducto(PutProducto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var queryInsert = "UPDATE Producto SET Stock = @Stock WHERE Id = @Id";

                bool update = false;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryInsert, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Stock", System.Data.SqlDbType.Int) { Value = producto._stockProductClass });
                    sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.BigInt) { Value = producto._idProductClass });

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {

                        update = true;

                    }
                }
                sqlConnection.Close();
                return update;
            }
        }


        public static bool borrarProducto(DeleteProducto producto)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var deleteQuery = "DELETE FROM Producto WHERE Id = @Id";

                bool update = false;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(deleteQuery, sqlConnection))
                {
                   
                    sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.BigInt) { Value = producto._idProductClass });

                    int numberOfRows = sqlCommand.ExecuteNonQuery();

                    if (numberOfRows > 0)
                    {

                        update = true;

                    }
                }
                sqlConnection.Close();
                return update;
            }
        }


    }
}
