using DesafioEntregable.Controllers.DTOS;
using DesafioEntregable.Modells;
using System.Data.SqlClient;

namespace DesafioEntregable.Repository
{
    public class UsuarioHandler : DBHandler
    {

        public List<ClaseUsuario> traerUsuarios()
        {
            List<ClaseUsuario> listaUsuarios = new List<ClaseUsuario>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var selectQuery = "SELECT * FROM Usuario";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(selectQuery, sqlConnection))
                {
                    using (SqlDataReader dataReader = sqlCommand.ExecuteReader())
                    {
                        if (dataReader.HasRows)
                        {
                            while (dataReader.Read())
                            {
                                var parUsuario = new ClaseUsuario();

                                parUsuario.setId(Convert.ToInt32(dataReader["Id"]));

                                parUsuario.setNombre(Convert.ToString(dataReader["Nombre"]));

                                parUsuario.setApellido(Convert.ToString(dataReader["Apellido"]));

                                parUsuario.setNombreUsuario(Convert.ToString(dataReader["NombreUsuario"]));

                                parUsuario.setContraseña(Convert.ToString(dataReader["Contraseña"]));

                                parUsuario.setMail(Convert.ToString(dataReader["Mail"]));


                                listaUsuarios.Add(parUsuario);


                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return listaUsuarios;
        }

        public List<ClaseUsuario> funcionLog(string mailCargado)
        {
            List<ClaseUsuario> validacionBasica = new List<ClaseUsuario>();

            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var validacionQuery = $"SELECT Contraseña FROM Usuario WHERE Mail = '{mailCargado}'";

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(validacionQuery, sqlConnection))
                {
                    using(SqlDataReader dataReaderValidacion = sqlCommand.ExecuteReader())
                    {
                        if (dataReaderValidacion.HasRows)
                        {
                            while (dataReaderValidacion.Read())
                            {
                                var parLogValido = new ClaseUsuario();

                                parLogValido.setContraseña(Convert.ToString(dataReaderValidacion["Contraseña"]));

                                validacionBasica.Add(parLogValido);

                            }
                        }
                    }
                }
                sqlConnection.Close();
            }
            return validacionBasica;
        }


        public static bool modificarUsuario(PutUsuario usuario)
        {
            using (SqlConnection sqlConnection = new SqlConnection(connectionString))
            {
                var queryUpdate = "UPDATE Usuario SET Nombre = @Nombre, Apellido = @Apellido, NombreUsuario = @NombreUsuario, Contraseña = @Contraseña, Mail = @Mail WHERE Id = @Id";

                bool update = false;

                sqlConnection.Open();

                using (SqlCommand sqlCommand = new SqlCommand(queryUpdate, sqlConnection))
                {
                    sqlCommand.Parameters.Add(new SqlParameter("Nombre", System.Data.SqlDbType.VarChar) { Value = usuario._nombreUClass });
                    sqlCommand.Parameters.Add(new SqlParameter("Apellido", System.Data.SqlDbType.VarChar) { Value = usuario._apellidoUClass});
                    sqlCommand.Parameters.Add(new SqlParameter("NombreUsuario", System.Data.SqlDbType.VarChar) { Value = usuario._nombreUsuarioUClass});
                    sqlCommand.Parameters.Add(new SqlParameter("Contraseña", System.Data.SqlDbType.VarChar) { Value = usuario._contraseñaUClass});
                    sqlCommand.Parameters.Add(new SqlParameter("Mail", System.Data.SqlDbType.VarChar) { Value = usuario._mailUClass});
                    sqlCommand.Parameters.Add(new SqlParameter("Id", System.Data.SqlDbType.BigInt) { Value = usuario._idUClass});

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
