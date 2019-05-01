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
* El link tiene la froma ip/TECAirlinesAPI/Universities
*/
    public class UniversitiesController : ApiController
    {
        /**
* Retorna las universidades de la base de datos
*/
        [Route("Universities")]
        [HttpGet]
        public List<GET_ALL_UNIVERSITY_Result> GetUniversity()
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                return entities.GET_ALL_UNIVERSITY().ToList();
            }
        }

        /**
* Retorna una universidad de la base de datos
*/
        [Route("Universities/{id}")]
        [HttpGet]
        public HttpResponseMessage GetUniversityByid(int id)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.GET_UNIVERSITY_BYID(id).ToList();

                if (ent != null)
                {
                    return Request.CreateResponse(HttpStatusCode.OK, ent);
                }
                else
                {
                    return Request.CreateErrorResponse(HttpStatusCode.NotFound,
                        "La universidad con identificación " + id + "no existe.");
                }
            }
        }

        /**
* Agrega una universidad a la base de datos
*/
        [Route("Universities/NewUniversity")]
        [HttpPost]
        public HttpResponseMessage PostUniversity([FromBody] UNIVERSITY uni)
        {
            try
            {
                using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
                {
                    entities.UNIVERSITies.Add(uni);
                    //entities.INSERT_UNIVERSITY(uni.UNIVERSITY_NAME);
                    entities.SaveChanges();

                    var message = Request.CreateResponse(HttpStatusCode.Created, uni);
                    message.Headers.Location = new Uri(Request.RequestUri + uni.UNIVERSITY_ID.ToString());
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
