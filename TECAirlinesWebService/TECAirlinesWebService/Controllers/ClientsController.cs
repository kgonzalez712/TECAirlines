using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECAirlinesDataAccess;
using TECAirlinesWebService.Models;

namespace TECAirlinesWebService.Controllers
{
    /**
     * el link tiene la forma ip/TECAirlinesAPI/Clients
     */
    public class ClientsController : ApiController
    {
        private Encriptor en = new Encriptor();
        /**
         * Retorna los clientes de la base de datos
         */
        [Route("Clients")]
        [HttpGet]
        public List<CLIENT_INFO> GetClients()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.CLIENT_INFO.ToList();
            }
        }

        /**
 * Retorna un cliente de la base de datos
 */
        [Route("Clients/{id}")]
        [HttpGet]
        public HttpResponseMessage GetClientByid(string id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.GET_CLIENT_INFO_BYID(id).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL cliente con identificación " + id + "no existe.");
                }
            }
        }

                /**
         * Retorna la tarjeta de credito de un cliente desencriptada de la base de datos
         */
        [Route("Clients/CardNo/{id}")]
        [HttpGet]
        public HttpResponseMessage GetClientCCByid(string id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.CLIENTs.FirstOrDefault(e => e.CLIENT_ID == id);

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, en.EncryptDecrypt(ent.CLIENT_CARDNO, 200));
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL cliente con identificación " + id + "no existe.");
                }
            }
        }

        /**
* Modifica el checkin de la reservacion en la base de datos
*/
        [Route("Clients/Miles/{id}/{miles}")]
        [HttpPut]
        public void AddMiles(int id, int miles)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                entities.ADD_MILES(id,miles);
            }
        }

        /*
        * Retorna el de un cliente desencriptada de la base de datos
        */
        [Route("Clients/ID/{id}")]
        [HttpGet]
        public HttpResponseMessage GetId(string id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.GET_CLIENT_ID(id);

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL cliente con identificación " + id + "no existe.");
                }
            }
        }




        /**
 * Retorna los clientes que son estudiantes de la base de datos
 */
        [Route("Clients/Students")]
        [HttpGet]
        public List<GET_STUDENT_Result> GetStudents()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_STUDENT().ToList();
            }
        }


        /**
 * Retorna los clientes regulares de la base de datos
 */
        [Route("Clients/RegularClients")]
        [HttpGet]
        public List<GET_NOT_STUDENT_Result> GetRegClients()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_NOT_STUDENT().ToList();
            }
        }

        /**
 * Agrega un cliente a la base de datos
 */
        [Route("Clients/AddClient")]
        [HttpPost]
        public HttpResponseMessage PostClient([FromBody] CLIENT client)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.INSERT_CLIENT(client.CLIENT_ID, client.CLIENT_FNAME, client.CLIENT_LNAME,
                        client.CLIENT_UID,
                        client.CLIENT_PHONENO, en.EncryptDecrypt(client.CLIENT_CARDNO, 200), client.CLIENT_MILES, client.CLIENT_EMAIL,
                        client.CLIENT_PASSWRD, client.UNIVERSITY_ID);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, client);
                    message.Headers.Location = new Uri(Request.RequestUri + client.CLIENT_ID);
                    return message;
                }
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex);
            }
        }
    }
}
