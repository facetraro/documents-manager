using DocumentsManager.BusinessLogic;
using DocumentsManager.Exceptions;
using DocumentsManager.Web.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DocumentsManager.Web.Api.Controllers
{
    public class LogInController : ApiController
    {
        private UserBusinessLogic logic;
        public LogInController() {
            logic = new UserBusinessLogic();
        }
        // GET: api/LogIn
        public IHttpActionResult Get()
        {
            return NotFound();
        }

        // GET: api/LogIn/5
        public IHttpActionResult Get(int id)
        {
            return NotFound();
        }

        // POST: api/LogIn
        public IHttpActionResult Post(string username,[FromBody]LogInModel model)
        {
            try
            {
                Guid token = logic.LogIn(username, model.Password);
                LoggedToken.SetToken(token);
                return Ok(token);
            }
            catch (LostConnectionWithDataBase exception)
            {
                return BadRequest(exception.Message);
            }
            catch (UserAlreadyLogged alreadyLogged)
            {
                return BadRequest(alreadyLogged.Message);
            }
            catch (InvalidCredentialException credentialsException)
            {
                return BadRequest(credentialsException.Message);
            }

        }

        // PUT: api/LogIn/5
        public IHttpActionResult Put(int id, [FromBody]string value)
        {
            return NotFound();
        }

        // DELETE: api/LogIn/5
        public IHttpActionResult Delete(int id)
        {
            return NotFound();
        }
    }
}
