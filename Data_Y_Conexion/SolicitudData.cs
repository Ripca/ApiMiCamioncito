using ApiMiCamioncito.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace ApiMiCamioncito.Data_Y_Conexion
{
    public class SolicitudData
    {
        //Ver Solicitudes
        public static List<Solicitud> VerSolicitudes()
        {
            List<Solicitud> ListaSolicitud = new List<Solicitud>();

            try
            {
                using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
                {
                    oConexion.Open();

                    using (MySqlCommand cmd = new MySqlCommand("solicitud_listar", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        using (MySqlDataReader dr = cmd.ExecuteReader())
                        {
                            while (dr.Read())
                            {
                                ListaSolicitud.Add(new Solicitud()
                                {
                                    IdSolicitud = Convert.ToInt32(dr["id_solicitud"]),
                                    FechaSolicitud = dr.GetDateTime(dr.GetOrdinal("fecha_solicitud")),
                                    IdCliente = Convert.ToInt32(dr["id_cliente"]),
                                    IdConductor = Convert.ToInt32(dr["id_conductor"]),
                                    IdAyudante = Convert.ToInt32(dr["id_ayudante"]),
                                    IdVehiculo = Convert.ToInt32(dr["id_vehiculo"]),
                                    DireccionOrigen = dr["direccion_origen"].ToString(),
                                    DireccionDestino = dr["direccion_destino"].ToString(),
                                    EstadoSolicitud = dr["estado_solicitud"].ToString(),
                                    PrecioTotal = Convert.ToDouble(dr["precio_total"])

                                });
                            }
                        }
                    }

                }
                return ListaSolicitud;

            }
            catch (Exception ex)
            {
                return ListaSolicitud;
                //Cuando lo modifiques podes agregar un alert para decir que esta vacio
            }

        }

        ////Registrar Solicitudes
        public static bool RegistrarSolicitud(Solicitud solicitud)
        {
            try
            {
                using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
                {
                    oConexion.Open();
                    using (MySqlCommand cmd = new MySqlCommand("solicitud_registrar", oConexion))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@_id_cliente", solicitud.IdCliente);
                        cmd.Parameters.AddWithValue("@_id_conductor", solicitud.IdVehiculo);
                        cmd.Parameters.AddWithValue("@_id_ayudante", solicitud.IdAyudante);
                        cmd.Parameters.AddWithValue("@_id_vehiculo", solicitud.IdVehiculo);
                        cmd.Parameters.AddWithValue("@_direccion_origen", solicitud.DireccionOrigen);
                        cmd.Parameters.AddWithValue("@_direccion_destino", solicitud.DireccionDestino);
                        cmd.Parameters.AddWithValue("@_estado_solicitud", solicitud.EstadoSolicitud);
                        cmd.Parameters.AddWithValue("@_precio_total", solicitud.PrecioTotal);
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

        public static Solicitud ObtenerSolicitud(int idSolicitud)
        {
            Solicitud solicitud = null;

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("solicitud_obtener", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_id_solicitud", idSolicitud);

                try
                {
                    oConexion.Open();

                    using (MySqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            solicitud = new Solicitud()
                            {
                                IdSolicitud = Convert.ToInt32(dr["id_solicitud"]),
                                FechaSolicitud = dr.GetDateTime(dr.GetOrdinal("fecha_solicitud")),
                                IdCliente = Convert.ToInt32(dr["id_cliente"]),
                                IdConductor = Convert.ToInt32(dr["id_conductor"]),
                                IdAyudante = Convert.ToInt32(dr["id_ayudante"]),
                                IdVehiculo = Convert.ToInt32(dr["id_vehiculo"]),
                                DireccionOrigen = dr["direccion_origen"].ToString(),
                                DireccionDestino = dr["direccion_destino"].ToString(),
                                EstadoSolicitud = dr["estado_solicitud"].ToString(),
                                PrecioTotal = Convert.ToDouble(dr["precio_total"])
                            };
                        }
                    }
                    return solicitud;
                }
                catch (Exception ex)
                {
                    //Pones un alert de que no existe
                    return solicitud;
                }
            }
        }
        //AQUI VAS A RECIBIR COMO PARAMETRO EL CLIENTE QUE TE VA A DAR EL METODO OBTENER
        public static bool ModificarSolicitud(Solicitud solicitud)
        {

            using (MySqlConnection oConexion = new MySqlConnection(Conexion.RutaConexion))
            {
                MySqlCommand cmd = new MySqlCommand("solicitud_modificar", oConexion);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@_id_solicitud", solicitud.IdSolicitud);
                cmd.Parameters.AddWithValue("@_estado_solicitud", solicitud.EstadoSolicitud);
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