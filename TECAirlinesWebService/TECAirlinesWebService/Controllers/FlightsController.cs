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
 * El link tiene la forma ip/TECAirlines/Flights
 */
    public class FlightsController : ApiController
    {
        /**
 * Retorna los vuelos de la base de datos
 */
        [Route("Flights")]
        [HttpGet]
        public List<ALL_FLIGHT> GetFlight()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.ALL_FLIGHT.ToList();
            }
        }

        /**
 * Retorna los id del vuelo de la base de datos
 */
        [Route("FlightID")]
        [HttpGet]
        public List<int?> GetFlightID()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_FLIGHT_ID().ToList();
            }
        }

        /**
 * Retorna un vuelo de la base de datos
 */
        [Route("Flights/{id}")]
        [HttpGet]
        public HttpResponseMessage GetFlightByid(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.SELECT_FLIGHT_ID(id).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL vuelo con identificación " + id + "no existe.");
                }
            }
        }

        /**
 * Retorna los vuelos de la base de datos por origen y destino
 */
        [Route("Flights/{o}/{d}")]
        [HttpGet]
        public HttpResponseMessage GetFlightByOD(string o, string d)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.GET_FLIGHT_BYOD(o, d).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "EL vuelo con origen " + o + " y destino " + d + "no existe.");
                }
            }
        }
        /**
 * Modifica el estado del vuelo
 */
        [Route("Flights/ChangeStatus/{id}")]
        [HttpPut]
        public HttpResponseMessage GetFlightPromotions(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.CHANGE_STATUS(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
        }

        /**
 * Retorna los vuelos promocion de la base de datos
 */
        [Route("Flights/Promotions")]
        [HttpGet]
        public List<GET_PROMTIONS_Result> GetFlightPromotions()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_PROMTIONS().ToList();
            }
        }

        /**
 * Retorna los vuelos normales de la base de datos
 */
        [Route("Flights/RegularFlights")]
        [HttpGet]
        public List<GET_REGULAR_FLIGHTS_Result> GetRegularFlights()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_REGULAR_FLIGHTS().ToList();
            }
        }

        /**
 * Agrega un vuelo a la base de datos
 */
        [Route("Flights/AddFlight")]
        [HttpPost]
        public HttpResponseMessage PostFlight([FromBody] FLIGHT flight)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.INSERT_FLIGHT(flight.FLIGHT_ID, flight.PLANE_ID, flight.ORIGIN_AIRPORT,
                        flight.DESTINATION_AIRPORT, flight.FSTATUS);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, flight);
                    message.Headers.Location = new Uri(Request.RequestUri + flight.FLIGHT_ID.ToString());
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
