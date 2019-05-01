using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECAirlinesDataAccess;

namespace TECAirlinesWebService.Controllers
{
    /**
 * El link tiene la forma ip/TECAirlinesApi/Pilots
 */
    public class PilotsController : ApiController
    {
        /**
 * Retorna los pilotos de la base de datos
 */
        [Route("Pilots")]
        [HttpGet]
        public List<GET_ALL_PILOT_Result> GetPilots()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_ALL_PILOT().ToList();
            }
        }

        /**
 * Retorna un piloto de la base de datos
 */
        [Route("Pilots/{id}")]
        [HttpGet]
        public HttpResponseMessage GetPilotByid(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.GET_PILOT_BYID(id).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL piloto con identificación " + id + "no existe.");
                }
            }
        }

        /**
 * Agrega un piloto a la base de datos
 */
        [Route("Pilots/NewPilot")]
        [HttpPost]
        public HttpResponseMessage PostPilot([FromBody] PILOT pilot)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.INSERT_PILOT(pilot.PILOT_ID, pilot.PILOT_FNAME, pilot.PILOT_LNAME);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, pilot);
                    message.Headers.Location = new Uri(Request.RequestUri + pilot.PILOT_ID.ToString());
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
