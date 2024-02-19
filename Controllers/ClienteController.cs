using ApiMiCamioncito.Data_Y_Conexion;
using ApiMiCamioncito.Models;
using System.Collections.Generic;
using System.Web.Http;
using System;
using System.Linq;
using System.Web;
using System.Web.Mvc;

//NOTA PERSONAL, SIEMPRE AGREGA LAS REFERENCIAS A DONDE ESTA LOS MODELS. EL using miproyecto.Models y
//el .Data_Y_Conexion, la carpeta en donde tenes la conexion y las acciones que hacen los metodos
//y el apiController tambien cambiaselo porque siempre aparece solo como controller

namespace ApiMiCamioncito.Controllers
{
    public class ClienteController : ApiController   //Esta parte cambiarla a ApiController, siempre te aparece solo Controller
    {

        public List<Cliente> Get()
        {   
            return ClienteData.VerClientes();
        }

        // GET api/<controller>/5
        public Cliente Get(int id)
        {
            return ClienteData.ObtenerCliente(id);
        }

        public bool Post([FromBody] Cliente cliente)
        {
            return ClienteData.RegistrarCliente(cliente);
        }

        // DELETE api/<controller>/5
        public bool Delete(int id)
        {
            return ClienteData.EliminarCliente(id);
        }

        // Put api/<controller>/5
        public bool Put([FromBody] Cliente cliente)
        {
            return ClienteData.ModificarCliente(cliente);
        }


    }
}
