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
 * El link tiene la froma ip/TECAirlinesAPI/Airports
 */
    public class AirportsController : ApiController
    {
        /**
 * Retorna los aeropuertos de la base de datos
 */
        [Route("Airports")]
        [HttpGet]
        public List<GET_ALL_AIRPORTS_Result> GetAirports()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_ALL_AIRPORTS().ToList();
            }
        }

        /**
 * Retorna un aeropuerto de la base de datos
 */
        [Route("Airports/{id}")]
        [HttpGet]
        public HttpResponseMessage GetAirportByid(string id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.GET_AIRPORT_BYID(id).ToList();
                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL aeropuerto con identificación " + id + "no existe.");
                }
            }
        }

        /**
 * agrega un aeropuerto a la base de datos
 */
        [Route("Airports/NewAirport")]
        [HttpPost]
        public HttpResponseMessage PostAirport([FromBody] AIRPORT airport)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.INSERT_AIRPORT(airport.AIRPORT_NAME, airport.IATA_CODE, airport.STATE_CODE,
                        airport.COUNTRY_CODE, airport.COUNTRY_NAME);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, airport);
                    message.Headers.Location = new Uri(Request.RequestUri + airport.IATA_CODE);
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
