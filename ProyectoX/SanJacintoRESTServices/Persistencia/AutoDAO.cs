using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SanJacintoRESTServices.Dominio;
using System.Data.SqlClient;

namespace SanJacintoRESTServices.Persistencia
{
    public class AutoDAO
    {
        public Auto Crear(Auto autoACrear)
        {
            Auto autoCreado = null;

            string sql = "INSERT INTO tb_auto VALUES (@cod, @marca, @modelo, @precio, @categoria, @estado, @placa, @imagen )";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", autoACrear.Codigo));
                    com.Parameters.Add(new SqlParameter("@marca", autoACrear.Marca));
                    com.Parameters.Add(new SqlParameter("@modelo", autoACrear.Modelo));
                    com.Parameters.Add(new SqlParameter("@precio", autoACrear.Precio));
                    com.Parameters.Add(new SqlParameter("@categoria", autoACrear.Categoria));
                    com.Parameters.Add(new SqlParameter("@estado", autoACrear.Estado));
                    com.Parameters.Add(new SqlParameter("@placa", autoACrear.Placa));
                    com.Parameters.Add(new SqlParameter("@imagen", autoACrear.Imagen));
                    com.ExecuteNonQuery();
                }
            }
            autoCreado = Obtener(autoACrear.Codigo);
            return autoCreado;
        }
        public Auto Obtener(int codigo)
        {
            Auto autoEncontrado = null;
            string sql = "SELECT * FROM tb_auto WHERE codigo=@cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", codigo));
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        if (resultado.Read())
                        {
                            autoEncontrado = new Auto()
                            {
                                Codigo = (int)resultado["codigo"],
                                Marca = (int)resultado["marca"],
                                Modelo = (int)resultado["modelo"],
                                Precio = (decimal)resultado["precio"],
                                Categoria = (int)resultado["categoria"],
                                Estado = (int)resultado["estado"],
                                Placa = (string)resultado["placa"],
                                Imagen = (string)resultado["imagen"],


                            };
                        }
                    }
                }
            }
            return autoEncontrado;
        }

        public Auto Modificar(Auto autoAModificar)
        {
            Auto autoCreado = null;
            string sql = "UPDATE tb_auto " +
                        "SET marca = @marca, modelo = @modelo, precio = @precio, categoria = @categoria, estado = @estado, placa = @placa, imagen = @imagen "
                        + "WHERE codigo = @cod";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    com.Parameters.Add(new SqlParameter("@cod", autoAModificar.Codigo));
                    com.Parameters.Add(new SqlParameter("@marca", autoAModificar.Marca));
                    com.Parameters.Add(new SqlParameter("@modelo", autoAModificar.Modelo));
                    com.Parameters.Add(new SqlParameter("@precio", autoAModificar.Precio));
                    com.Parameters.Add(new SqlParameter("@categoria", autoAModificar.Categoria));
                    com.Parameters.Add(new SqlParameter("@estado", autoAModificar.Estado));
                    com.Parameters.Add(new SqlParameter("@placa", autoAModificar.Placa));
                    com.Parameters.Add(new SqlParameter("@imagen", autoAModificar.Imagen));

                    com.ExecuteNonQuery();
                }
            }
            autoCreado = Obtener(autoAModificar.Codigo);
            return autoCreado;
        }
        public void Eliminar(int codigoAutoAEliminar)
        {
            try
            {
                using (var sc = new SqlConnection(ConexionUtil.Cadena))
                using (var cmd = sc.CreateCommand())
                {
                    sc.Open();
                    cmd.CommandText = "DELETE FROM tb_auto WHERE codigo=@cod";
                    cmd.Parameters.AddWithValue("@cod", codigoAutoAEliminar);
                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception e)
            {

            }

        }
        public List<Auto> ListarTodos()
        {
            Auto autoEncontrado = null;
            List<Auto> lista = new List<Auto>();
            string sql = "SELECT * FROM tb_auto";
            using (SqlConnection con = new SqlConnection(ConexionUtil.Cadena))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(sql, con))
                {
                    using (SqlDataReader resultado = com.ExecuteReader())
                    {
                        while (resultado.Read())
                        {
                            autoEncontrado = new Auto()
                            {
                                Codigo = (int)resultado["codigo"],
                                Marca = (int)resultado["marca"],
                                Modelo = (int)resultado["modelo"],
                                Precio = (decimal)resultado["precio"],
                                Categoria = (int)resultado["categoria"],
                                Estado = (int)resultado["estado"],
                                Placa = (string)resultado["placa"],
                                Imagen = (string)resultado["imagen"],
                            };
                            lista.Add(autoEncontrado);
                        }
                    }
                }
            }
            return lista;
        }
    }
}