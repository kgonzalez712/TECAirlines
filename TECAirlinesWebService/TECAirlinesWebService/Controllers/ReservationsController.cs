using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECAirlinesDataAccess;
using TECAirlinesReports;

namespace TECAirlinesWebService.Controllers
{
    /**
 * El link tiene la forma ip/TECAirlinesAPI/Reservations
 */
    public class ReservationsController : ApiController
    {
        /**
 * Retorna las reservaciones de la base de datos
 */
        [Route("Reservations")]
        [HttpGet]
        public List<SELECT_RESERVATION_Result> GetReservations()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.SELECT_RESERVATION().ToList();
            }
        }

        /**
 * Retorna una reservacion de la base de datos
 */
        [Route("Reservations/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReservationByid(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.SELECT_RESERVATION_ID(id).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "La reservación con identificación " + id + "no existe.");
                }
            }
        }

        /**
 * Modifica el checkin de la reservacion en la base de datos
 */
        [Route("Reservations/CheckIn/{id}")]
        [HttpPut]
        public void SetCheckIn(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                entities.CHECKIN(id);
            }
        }

        /**
 * Reservaciones por cliente
 */
        [Route("Reservations/Client/{id}")]
        [HttpGet]
        public HttpResponseMessage GetReservationByClientId(string id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.SELECT_RESERVATION_BYCID(id).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "La reservación del cliente " + id + "no existe.");
                }
            }
        }

        /**
 * Modifica los asientos de la reservacion en la base de datos
 */
        [Route("Reservations/SetSeats/{id}")]
        [HttpPut]
        public void SetSeats([FromBody] int id, string seats)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                entities.SET_SEATS(id, seats);
            }
        }

       // [Route("Reservations/EmailConfirm")]
        //[HttpGet]
       // public void GetReservationConfirmByid()
       // {
           // using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
           // {
                //entities.EMAIL_CONFIRMATION();
           // }
       // }

        /**
 * Agrega una reservacion a la base de datos
 */
        [Route("Reservations/NewReservation")]
        [HttpPost]
        public HttpResponseMessage PostClient([FromBody] RESERVATION reservation)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.INSERT_RESERVATION(reservation.TICKET_COUNT, reservation.LUGGAGE_COUNT, reservation.SEATS,
                        reservation.CHECKIN,
                        reservation.T_TYPE, reservation.PRICE, reservation.CLIENT_ID, reservation.FLIGHT_ID);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, reservation);
                    message.Headers.Location = new Uri(Request.RequestUri + reservation.RESERVATION_ID.ToString());
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
