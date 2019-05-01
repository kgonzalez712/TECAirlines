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
 * El link tiene la forma ip/TECAirlinesAPI/Airplanes
 */
    public class AirplanesController : ApiController
    {

        /**
 * Retorna los aviones de la base de datos
 */
        [Route("Airplanes")]
        [HttpGet]
        public List<PLANE_INFO> GetAirplanes()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.PLANE_INFO.ToList();
            }
        }

        /**
 * Retorna un avion de la base de datos
 */
        [Route("Airplanes/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAirplaneByid(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.GET_PLANE_INFO_BYID(id).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL avión con identificación " + id + "no existe.");
                }
            }
        }

        /**
 * agrega un avion a la base de datos
 */
        [Route("Airplanes/NewAirplane")]
        [HttpPost]
        public HttpResponseMessage PostAirplane([FromBody] AIRPLANE plane)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.INSERT_AIRPLANE(plane.AIRPLANE_ID, plane.PILOT_ID);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, plane);
                    message.Headers.Location = new Uri(Request.RequestUri + plane.AIRPLANE_ID.ToString());
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
