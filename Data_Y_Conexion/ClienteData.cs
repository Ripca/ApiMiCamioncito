using ApiMiCamioncito.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Data_Y_Conexion
{
    public class ClienteData
    {
        //Ver Clientes
        public static List<Cliente> VerClientes()
        {
            List<Cliente> ListaCliente = new List<Cliente>();

            try
            {
                using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
                {
                    oConexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("cliente_listar", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaCliente.Add(new Cliente()
                                {
                                    IdCliente = Convert.ToInt32(dr["id_cliente"]),
                                    NombreCliente = dr["nombre_cliente"].ToString(),
                                    Correo = dr["correo"].ToString(),
                                    DPI = dr["dpi"].ToString()
                                });
                            }
                        }
                    }

                }
                return ListaCliente;

            }
            catch (Exception ex)
            {
                return ListaCliente;
                //Cuando lo modifiques podes agregar un alert para decir que esta vacio
            }

        }

        //Registrar Clientes
        public static bool RegistrarCliente(Cliente cliente)
        {
            try
            {
                using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
                {
                    oConexion.Open();
                    //PENDIENTE DE ESTA LINEA SI DA UN ERROR PORQUE EL PROCEDIMIENTO ESTABA asi: cliente_modificar
                    using (MySqlCommand cmd = new MySqlCommand("cliente_registrar", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_nombre_cliente", cliente.NombreCliente);
                        cmd.Parameters.AddWithValue("@_correo", cliente.Correo);
                        cmd.Parameters.AddWithValue("@_dpi", cliente.DPI);
                        cmd.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }


        //Eliminar Cliente
        public static bool EliminarCliente(int idEliminar)
        {

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("cliente_eliminar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_id_eliminar", idEliminar);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (MySqlException ex)
                {
                    // Manejo de excepciones, puedes mostrar un mensaje de error o registrar el error en un archivo de registro, por ejemplo.
                    return false;
                }
            }
        }

        //SI DA TIEMPOOOOOOOOOOOOOOOOOOOO
        //A la hora de modificar vas a ser uso de estos dos metodos, el que te trae los datos cuando escribis el id 
        //en un input y te despliega los datos en los inputs, y el de modificar cuando le des al boton guardar
        public static Cliente ObtenerCliente(int idCliente)
        {
            Cliente cliente = null;

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("cliente_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_id_cliente", idCliente);

                try
                {
                    oConexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            cliente = new Cliente()
                            {
                                IdCliente = Convert.ToInt32(dr["id_cliente"]),
                                NombreCliente = dr["nombre_cliente"].ToString(),
                                Correo = dr["correo"].ToString(),
                                DPI = dr["dpi"].ToString()

                            };
                        }
                    }
                    return cliente;
                }
                catch (Exception ex)
                {
                    //Pones un alert de que no existe
                    return cliente;
                }
            }
        }
        //AQUI VAS A RECIBIR COMO PARAMETRO EL CLIENTE QUE TE VA A DAR EL METODO OBTENER
        public static bool ModificarCliente(Cliente cliente)
        {

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("cliente_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_id_cliente", cliente.IdCliente);
                cmd.Parameters.AddWithValue("@_nombre_cliente", cliente.NombreCliente);
                cmd.Parameters.AddWithValue("@_correo", cliente.Correo);
                cmd.Parameters.AddWithValue("@_dpi", cliente.DPI);

                try
                {
                    oConexion.Open();
                    cmd.ExecuteNonQuery();
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }
        }



    }
}