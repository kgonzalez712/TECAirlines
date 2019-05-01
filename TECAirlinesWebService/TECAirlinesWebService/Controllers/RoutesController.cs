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
* El link tiene la forma ip/TECAirlinesAPI/Routes
*/
    public class RoutesController : ApiController
    {
        /**
 * Retorna la ruta por id de la base de datos
 */
        [Route("Routes/{id}")]
        [HttpGet]
        public HttpResponseMessage GetRoutesByFlightid(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.FROUTEs.FirstOrDefault(e => e.FLIGHT_ID == id);

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "Las rutas con vuelo " + id + "no existen.");
                }
            }
        }

        /**
* Agrega una ruta a la base de datos
*/
        [Route("Routes/AddRoute")]
        [HttpPost]
        public HttpResponseMessage PostRoute([FromBody] FROUTE route)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.INSERT_ROUTE(route.FLIGHT_ID, route.ORIGIN, route.DESTINATION, route.FLIGHT_MILES,
                        route.CAPACITY, route.ECO_PRICE, route.EJE_PRICE, route.DATE_HOUR, route.IS_PROMOTION,
                        route.LUGGAGE_CAPACITY);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, route);
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
