using ApiMiCamioncito.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Data_Y_Conexion
{
    public class VehiculoData
    {
        //Ver Vehiculos
        public static List<Vehiculo> VerVehiculos()
        {
            List<Vehiculo> ListaVehiculo = new List<Vehiculo>();

            try
            {
                using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
                {
                    oConexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("vehiculo_listar", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaVehiculo.Add(new Vehiculo()
                                {
                                    IdVehiculo = Convert.ToInt32(dr["id_vehiculo"]),
                                    TipoVehiculo = dr["tipo_vehiculo"].ToString(),
                                    CapacidadCarga = dr["capacidad_carga"].ToString(),
                                    CombustiblePorKm = dr["combustible_por_km"].ToString(),
                                    Disponibilidad = dr["disponibilidad"].ToString(),
                                    DepreciacionPorKm = dr["depreciacion_por_km"].ToString(),
                                    TipoCarga = dr["tipo_carga"].ToString()

                                });
                            }
                        }
                    }

                }
                return ListaVehiculo;

            }
            catch (Exception ex)
            {
                return ListaVehiculo;
            }

        }

        
        //Registrar Vehiculos 
        public static bool RegistrarVehiculo(Vehiculo vehiculo)
        {
            try
            {
                using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
                {
                    oConexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("vehiculo_registrar", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_tipo_vehiculo", vehiculo.TipoVehiculo);
                        cmd.Parameters.AddWithValue("@_capacidad_carga", vehiculo.CapacidadCarga);
                        cmd.Parameters.AddWithValue("@_combustible_por_km", vehiculo.CombustiblePorKm);
                        cmd.Parameters.AddWithValue("@_disponibilidad", vehiculo.Disponibilidad);
                        cmd.Parameters.AddWithValue("@_depreciacion_por_km", vehiculo.DepreciacionPorKm);
                        cmd.Parameters.AddWithValue("@_tipo_carga", vehiculo.TipoCarga);


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
        public static bool EliminarVehiculo(int idEliminar)
        {

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("vehiculo_eliminar", oConexion);
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


        public static Vehiculo ObtenerVehiculo(int idVehiculo)
        {
            Vehiculo vehiculo = null;

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("vehiculo_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_id_vehiculo", idVehiculo);

                try
                {
                    oConexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            vehiculo = new Vehiculo()
                            {
                                IdVehiculo = Convert.ToInt32(dr["id_vehiculo"]),
                                TipoVehiculo = dr["tipo_vehiculo"].ToString(),
                                CapacidadCarga = dr["capacidad_carga"].ToString(),
                                CombustiblePorKm = dr["combustible_por_km"].ToString(),
                                Disponibilidad = dr["disponibilidad"].ToString(),
                                DepreciacionPorKm = dr["depreciacion_por_km"].ToString(),
                                TipoCarga = dr["tipo_carga"].ToString()
                            };
                        }
                    }
                    return vehiculo;
                }
                catch (Exception ex)
                {
                    //Pones un alert de que no existe
                    return vehiculo;
                }
            }
        }



        //AQUI VAS A RECIBIR COMO PARAMETRO EL CLIENTE QUE TE VA A DAR EL METODO OBTENER
        public static bool ModificarVehiculo(Vehiculo vehiculo)
        {

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("vehiculo_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_id_vehiculo", vehiculo.IdVehiculo);
                cmd.Parameters.AddWithValue("@_tipo_vehiculo", vehiculo.TipoVehiculo);
                cmd.Parameters.AddWithValue("@_capacidad_carga", vehiculo.CapacidadCarga);
                cmd.Parameters.AddWithValue("@_combustible_por_km", vehiculo.CombustiblePorKm);
                cmd.Parameters.AddWithValue("@_disponibilidad", vehiculo.Disponibilidad);
                cmd.Parameters.AddWithValue("@_depreciacion_por_km", vehiculo.DepreciacionPorKm);
                cmd.Parameters.AddWithValue("@_tipo_carga", vehiculo.TipoCarga);
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



        //Se implenta de igual forma que en los clientes solo tienes que crear los procedimientos almacenados
        //y hacer la asignacion de los correspondientes vehiculos

        //METODO PARA REGISTRAR VEHICULOS
        //METODO PARA ELIMINAR VEHICULOS


    }
}