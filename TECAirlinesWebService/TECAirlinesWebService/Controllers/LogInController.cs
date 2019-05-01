using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TECAirlinesDataAccess;

namespace TECAirlinesWebService.Controllers
{
    public class LogInController : ApiController
    {
        [Route("LogIn/{email}/{password}")]
        [HttpGet]
        public Boolean Check(string email, string password)
        {
            using (TECAirlinesDBEntities entities = new TECAirlinesDBEntities())
            {
                var ent = entities.CLIENTs.FirstOrDefault(e => e.CLIENT_EMAIL == email);
                var en = entities.CLIENTs.FirstOrDefault(e => e.CLIENT_PASSWRD == password);

                if (ent != null & en != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
